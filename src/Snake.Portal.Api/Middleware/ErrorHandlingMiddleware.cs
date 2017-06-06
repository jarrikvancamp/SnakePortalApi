using Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;


namespace Snake.Portal.Api.Middleware
{
	public class ErrorHandlingMiddleware
	{
		private readonly RequestDelegate next;
		private readonly ILogger _logger;

		public ErrorHandlingMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
		{
			this.next = next;
			_logger = loggerFactory.CreateLogger<ErrorHandlingMiddleware>();

			_logger.LogInformation($"Middleware created: {nameof(ErrorHandlingMiddleware)}");
		}

		public async Task Invoke(HttpContext context)
		{
			try
			{
				await next(context);
			}
			catch (Exception ex)
			{
				await HandleExceptionAsync(context, ex);
			}
		}

		private Task HandleExceptionAsync(HttpContext context, Exception exception)
		{
			var code = GenerateCode(exception);
			var result = GenerateExceptionMessage(code);

			context.Response.ContentType = "application/json";
			context.Response.StatusCode = (int)code;

			_logger.LogError($"[{code}] {exception.GetType()}: {exception.Message}");
			return context.Response.WriteAsync(result);
		}

		private static string GenerateExceptionMessage(HttpStatusCode code)
		{
			switch (code)
			{
				case HttpStatusCode.BadRequest:
					return JsonConvert.SerializeObject(new { error = $"{code}: {DefaultExceptionMessages.ENTITY_VALIDATION_EXCEPTION}" });
				case HttpStatusCode.NotFound:
					return JsonConvert.SerializeObject(new { error = $"{code}: {DefaultExceptionMessages.NOT_FOUND_EXCEPTION}" });
				case HttpStatusCode.NotImplemented:
					return JsonConvert.SerializeObject(new { error = $"{code}: {DefaultExceptionMessages.NOT_IMPLEMENTED_EXCEPTION}" });
				case HttpStatusCode.Unauthorized:
					return JsonConvert.SerializeObject(new { error = $"{code}: {DefaultExceptionMessages.UNAUTHORIZED_EXCEPTION}" });
				default:
					return JsonConvert.SerializeObject(new { error = $"{code}: {DefaultExceptionMessages.INTERNAL_SERVER_EXCEPTION}" });
			}
		}

		private static HttpStatusCode GenerateCode(Exception exception)
		{
			if (exception is EntityValidationException) return HttpStatusCode.BadRequest;
			if (exception is EntityNotFoundException) return HttpStatusCode.NotFound;
			if (exception is NotImplementedException) return HttpStatusCode.NotImplemented;
			if (exception is UnauthorizedAccessException) return HttpStatusCode.Unauthorized;

			return HttpStatusCode.InternalServerError;
		}
	}
}
