using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    public static class DefaultExceptionMessages
    {
        public const string ENTITY_VALIDATION_EXCEPTION = "The entity you submitted has invalid value(s).";
        public const string INTERNAL_SERVER_EXCEPTION = "The server could not process your request.";
        public const string NOT_IMPLEMENTED_EXCEPTION = "This request is not implemented yet.";
        public const string NOT_FOUND_EXCEPTION = "The entity you requested was not found.";
        public const string UNAUTHORIZED_EXCEPTION = "You need to be logged in to make requests.";
        public const string PERMISSION_DENIED_EXCEPTION = "You have no permission to make requests.";
    }
}
