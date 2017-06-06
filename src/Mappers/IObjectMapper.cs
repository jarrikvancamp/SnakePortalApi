using System.Collections.Generic;
using DTO.PortalUser;
using DTO.PortalUserWithScores;
using DTO.Score;
using Entities.PlayerScore;
using Entities.User;
using Entities.Posts;
using DTO.Post;
using DTO.Menu;
using Entities.Menu;

namespace Mappers
{
    /// <summary>
    ///     Interface to loosely couple AutoMapper (or any object mapping package)
    /// </summary>
    public interface IObjectMapper
    {
        BlogPostDto Map(BlogPost entity);
        BlogPost Map(BlogPostDto entity);
        FeedEntryDto Map(FeedEntry entity);
        FeedEntry Map(FeedEntryDto entity);
        List<BlogPostDto> Map(IEnumerable<BlogPost> entities);
        List<BlogPost> Map(IEnumerable<BlogPostDto> entities);
        List<FeedEntryDto> Map(IEnumerable<FeedEntry> entities);
        List<FeedEntry> Map(IEnumerable<FeedEntryDto> entities);
        List<MenuElementDto> Map(IEnumerable<MenuElement> entities);
        List<MenuElement> Map(IEnumerable<MenuElementDto> entities);
        List<PortalUserDto> Map(IEnumerable<PortalUser> entities);
        List<PortalUser> Map(IEnumerable<PortalUserDto> entities);
        List<ScoreDto> Map(IEnumerable<Score> entities);
        List<Score> Map(IEnumerable<ScoreDto> entities);
        MenuElementDto Map(MenuElement entity);
        MenuElement Map(MenuElementDto entity);
        PortalUserDto Map(PortalUser entity);
        PortalUserWithScoresDto Map(PortalUser entity, bool detailscores);
        PortalUser Map(PortalUserDto entity);
        ScoreDto Map(Score entity);
        Score Map(ScoreDto entity);
    }
}