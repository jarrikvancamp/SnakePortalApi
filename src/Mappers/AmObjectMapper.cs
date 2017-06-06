using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DTO.PortalUser;
using DTO.PortalUserWithScores;
using DTO.Score;
using Entities.PlayerScore;
using Entities.User;
using DTO.Post;
using Entities.Posts;
using DTO.Menu;
using Entities.Menu;

namespace Mappers
{
	/// <summary>
	///     Implementation of IObjectMapper for AutoMapper
	/// </summary>
	public class AmObjectMapper : IObjectMapper
	{
		#region Private Members

		private readonly IMapper _mapper;

		#endregion

		#region Constructor

		public AmObjectMapper()
		{
			var config = new MapperConfiguration(cfg =>
			{
				cfg.CreateMap<Score, ScoreDto>().ReverseMap();
				cfg.CreateMap<BlogPost, BlogPostDto>().ForMember(x => x.UserId, cnf => cnf.MapFrom(ol => ol.User.Id)).ReverseMap();
				cfg.CreateMap<FeedEntry, FeedEntryDto>().ForMember(x => x.UserId, cnf => cnf.MapFrom(ol => ol.User.Id)).ReverseMap();
			});
			_mapper = config.CreateMapper();
		}

		#endregion

		#region Specific mapping for PortalUserWithScores

		public PortalUserWithScoresDto Map(PortalUser entity, bool detailscores)
		{
			var scores = Map(entity.Scores);
			var portalUserWithScores = new PortalUserWithScoresDto
			{
				Id = entity.Id.ToString(),
				CreatedDate = entity.CreatedOn,
				Email = entity.Email,
				FirstName = entity.FirstName,
				LastName = entity.LastName,
				Scores = detailscores ? scores : null,
				TotalScore = entity.Scores.Sum(x => x.PlayerScore),
				UserName = entity.UserName
			};
			return portalUserWithScores;
		}

		#endregion

		#region Two-way mapping for Score & ScoreDto

		public List<ScoreDto> Map(IEnumerable<Score> entities)
		{
			return entities.Select(Map).ToList();
		}

		public ScoreDto Map(Score entity)
		{
			return _mapper.Map<ScoreDto>(entity);
		}

		public List<Score> Map(IEnumerable<ScoreDto> entities)
		{
			return entities.Select(Map).ToList();
		}

		public Score Map(ScoreDto entity)
		{
			return _mapper.Map<Score>(entity);
		}

		#endregion

		#region Two-way mapping for PortalUser & PortalUserDto

		public List<PortalUserDto> Map(IEnumerable<PortalUser> entities)
		{
			return entities.Select(Map).ToList();
		}

		public PortalUserDto Map(PortalUser entity)
		{
			return _mapper.Map<PortalUserDto>(entity);
		}

		public List<PortalUser> Map(IEnumerable<PortalUserDto> entities)
		{
			return entities.Select(Map).ToList();
		}

		public PortalUser Map(PortalUserDto entity)
		{

			return new PortalUser
			{
				Id = entity.Id,
				CreatedOn = entity.CreatedOn,
				Email = entity.Email,
				FirstName = entity.FirstName,
				LastName = entity.LastName,
				Scores = new List<Score>(),
				UserName = entity.UserName,
				Password = entity.Password,
				Salt = entity.Salt
			};
		}

		#endregion

		#region BlogPost
		public List<BlogPostDto> Map(IEnumerable<BlogPost> entities)
		{
			return entities.Select(Map).ToList();
		}

		public BlogPostDto Map(BlogPost entity)
		{
			var user = Map(entity.User, false);
			var blogpost = new BlogPostDto
			{
				CreatedOn = entity.CreatedOn,
				IsAllowedToEdit = entity.IsAllowedToEdit,
				Id = entity.Id,
				Message = entity.Message,
				ModifiedOn = entity.ModifiedOn,
				Title = entity.Title,
				UserId = entity.UserId,
			};
			return blogpost;
		}

		public List<BlogPost> Map(IEnumerable<BlogPostDto> entities)
		{
			return entities.Select(Map).ToList();
		}

		public BlogPost Map(BlogPostDto entity)
		{
			return _mapper.Map<BlogPost>(entity);
		}
		#endregion

		#region FeedEntry

		public List<FeedEntryDto> Map(IEnumerable<FeedEntry> entities)
		{
			return entities.Select(Map).ToList();
		}

		public FeedEntryDto Map(FeedEntry entity)
		{
			var user = Map(entity.User, false);
			var blogpost = new FeedEntryDto
			{
				CreatedOn = entity.CreatedOn,
				IsRead = entity.IsRead,
				Id = entity.Id,
				Message = entity.Message,
				ModifiedOn = entity.ModifiedOn,
				Title = entity.Title,
				UserId = entity.UserId,
			};
			return blogpost;
		}

		public List<FeedEntry> Map(IEnumerable<FeedEntryDto> entities)
		{
			return entities.Select(Map).ToList();
		}

		public FeedEntry Map(FeedEntryDto entity)
		{
			return _mapper.Map<FeedEntry>(entity);
		}
		#endregion

		#region MenuElement

		public List<MenuElementDto> Map(IEnumerable<MenuElement> entities)
		{
			return entities.Select(Map).ToList();
		}

		public MenuElementDto Map(MenuElement entity)
		{
			return _mapper.Map<MenuElementDto>(entity);
		}

		public List<MenuElement> Map(IEnumerable<MenuElementDto> entities)
		{
			return entities.Select(Map).ToList();
		}

		public MenuElement Map(MenuElementDto entity)
		{
			return _mapper.Map<MenuElement>(entity);
		}
		#endregion
	}
}