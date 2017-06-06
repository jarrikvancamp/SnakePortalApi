using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Entities.PlayerScore;
using Entities.User;
using Entities.Posts;

namespace DAL.Infrastructure
{
    /// <summary>
    ///     This Seeder works as this:
    ///     - The seeder runs if the model has been changed
    ///     - Create users
    ///     - Create amount of random scores (amount can be specified in constructor) tied to scores
    ///     - remark: I Use non-static randoms to select random users and generate scores.
    ///     Non-static randoms are usually a bad practice but because the for-loop is disposable it works just as well.
    /// </summary>
    public class DbSeeder : DropCreateDatabaseIfModelChanges<EfDbContext>
    {
        #region Private Members

        private readonly int _amountOfScores;

        #endregion

        #region Constructor

        /// <summary>
        /// </summary>
        public DbSeeder(int amountOfScores = 50)
        {
            if(amountOfScores <= 0) throw new ArgumentOutOfRangeException(nameof(amountOfScores));
            _amountOfScores = amountOfScores;
            
        }

        #endregion

        protected override void Seed(EfDbContext context)
        {
            if(!context.Database.Exists()) context.Database.CreateIfNotExists();

            SeedPortalUsers(context);

            ICollection<PortalUser> users = context.PortalUsers.ToList();

            SeedScores(context, users);

            //TODO
            SeedBlogPosts(context, users);
            SeedFeed(context, users);
            SeedMenuElements(context);

            base.Seed(context);
        }

        private void SeedBlogPosts(EfDbContext context, ICollection<PortalUser> users)
        {
            for(int i = 0; i < 30; i++)
            {
                context.Blogposts.Add(new BlogPost
                {
                    CreatedOn = DateTime.Now,
                    IsAllowedToEdit = false,
                    Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas sollicitudin, metus eu condimentum rutrum, dui est feugiat dolor, sit amet maximus ligula nibh id odio. Phasellus sit amet laoreet lorem. Sed a faucibus velit. Ut a euismod ligula. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Phasellus eleifend magna id leo tincidunt pharetra. Ut posuere porta elit, non tempor neque facilisis sed. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam mattis congue commodo. Aenean vestibulum vel metus ut porta. Nam et hendrerit nisl. In eget auctor tortor, sed sollicitudin purus. Nullam iaculis vehicula tincidunt.",
                    Title = $"Blogpost {i}",
                    ModifiedOn = DateTime.Now,
                    UserId = users.First().Id
                });
                context.SaveChanges();
            }
        }

        private void SeedFeed(EfDbContext context, ICollection<PortalUser> users)
        {
            for(int i = 0; i < 30; i++)
            {
                context.FeedEntries.Add(new FeedEntry
                {
                    CreatedOn = DateTime.Now,
                    IsRead = false,
                    Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas sollicitudin, metus eu condimentum rutrum.",
                    Title = $"FeedEntry {i}",
                    ModifiedOn = DateTime.Now,
                    UserId = users.First().Id
                });
                context.SaveChanges();
            }
        }

        private void SeedMenuElements(EfDbContext context)
        {
           //TODO
        }

        private void SeedPortalUsers(EfDbContext context)
        {
            if(!context.PortalUsers.Any())
            {
                context.PortalUsers.Add(new PortalUser
                {
                    UserName = "CedricJacobs",
                    FirstName = "Cedric",
                    LastName = "Jacobs",
                    Email = "cedric.jacobs@icloud.com",
                    CreatedOn = new DateTime(2017, 01, 01),
                    ModifiedOn = DateTime.Now
                });
                context.PortalUsers.Add(new PortalUser
                {
                    UserName = "JarrikVanCamp",
                    FirstName = "Jarrik",
                    LastName = "Van Camp",
                    Email = "jarrik.vancamp@ordina.be",
                    CreatedOn = new DateTime(2017, 01, 01),
                    ModifiedOn = DateTime.Now
                });
                context.PortalUsers.Add(new PortalUser
                {
                    UserName = "JerkeTaeymans",
                    FirstName = "Jerke",
                    LastName = "Taeymans",
                    Email = "Jerke_t@hotmail.com",
                    CreatedOn = new DateTime(2017, 01, 01),
                    ModifiedOn = DateTime.Now
                });
                context.SaveChanges();
            }
        }

        private void SeedScores(EfDbContext context, ICollection<PortalUser> users)
        {
            var amount = context.Scores.Count();
            if(amount < _amountOfScores)
            {
                var rnd = new Random();
                var rnd2 = new Random();

                var itemsToAdd = _amountOfScores - amount;
                for(var i = 1; i <= itemsToAdd; i++)
                {
                    var r = rnd.Next(0, users.Count());
                    var r2 = rnd2.Next(1, 250);
                    context.Scores.Add(new Score
                    {
                        UserId = users.ElementAt(r).Id,
                        PlayerScore = r2 * 1000,
                        MapId = 1,
                        CreatedOn = new DateTime(2017, 01, 01),
                        ModifiedOn = DateTime.Now
                    });
                }
                context.SaveChanges();
            }
        }
    }
}