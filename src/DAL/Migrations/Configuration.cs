using System.Data.Entity.Migrations;
using DAL.Infrastructure;
using System.Collections.Generic;
using Entities.User;
using System.Linq;
using Entities.Posts;
using System;
using Entities.PlayerScore;
using Snake.Portal.Api.Helpers;
using BL.Enums;
using System.Text;

namespace DAL.Migrations
{
	internal sealed class Configuration : DbMigrationsConfiguration<EfDbContext>
	{
		public Configuration()
		{
			AutomaticMigrationsEnabled = false;
			ContextKey = "DAL.Infrastructure.EFDbContext";
		}

		protected override void Seed(EfDbContext context)
		{
			if (!context.Database.Exists()) context.Database.CreateIfNotExists();

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
			for (int i = 0; i < 30; i++)
			{
				context.Blogposts.Add(new BlogPost
				{
					IsAllowedToEdit = false,
					Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas sollicitudin, metus eu condimentum rutrum, dui est feugiat dolor, sit amet maximus ligula nibh id odio. Phasellus sit amet laoreet lorem. Sed a faucibus velit. Ut a euismod ligula. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Phasellus eleifend magna id leo tincidunt pharetra. Ut posuere porta elit, non tempor neque facilisis sed. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam mattis congue commodo. Aenean vestibulum vel metus ut porta. Nam et hendrerit nisl. In eget auctor tortor, sed sollicitudin purus. Nullam iaculis vehicula tincidunt.",
					Title = $"Blogpost {i}",
					CreatedOn = new DateTime(2017, 01, 01),
					ModifiedOn = new DateTime(2017, 01, 01),
					UserId = users.First().Id
				});
				context.SaveChanges();
			}
		}

		private void SeedFeed(EfDbContext context, ICollection<PortalUser> users)
		{
			for (int i = 0; i < 30; i++)
			{
				context.FeedEntries.Add(new FeedEntry
				{
					CreatedOn = new DateTime(2017, 5, 20),
					IsRead = false,
					Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas sollicitudin, metus eu condimentum rutrum.",
					Title = $"FeedEntry {i}",
					ModifiedOn = new DateTime(2017, 01, 01),
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
			if (!context.PortalUsers.Any())
			{
				context.PortalUsers.Add(new PortalUser
				{
					UserName = "CedricJacobs",
					FirstName = "Cedric",
					LastName = "Jacobs",
					Email = "cedric.jacobs@icloud.com",
					CreatedOn = new DateTime(2017, 01, 01),
					ModifiedOn = new DateTime(2017, 01, 01),
					Password = SimpleHash.ComputeHash("Test123",HashAlgoritms.SHA512,Encoding.ASCII.GetBytes("0")),
					Salt = "0"
				});
				context.PortalUsers.Add(new PortalUser
				{
					UserName = "JarrikVanCamp",
					FirstName = "Jarrik",
					LastName = "Van Camp",
					Email = "jarrik.vancamp@ordina.be",
					CreatedOn = new DateTime(2017, 01, 01),
					ModifiedOn = new DateTime(2017, 01, 01),
					Password = SimpleHash.ComputeHash("Test123", HashAlgoritms.SHA512, Encoding.ASCII.GetBytes("1")),
					Salt = "1"
				});
				context.PortalUsers.Add(new PortalUser
				{
					UserName = "JerkeTaeymans",
					FirstName = "Jerke",
					LastName = "Taeymans",
					Email = "Jerke_t@hotmail.com",
					CreatedOn = new DateTime(2017, 01, 01),
					ModifiedOn = new DateTime(2017, 01, 01),
					Password = SimpleHash.ComputeHash("Test123", HashAlgoritms.SHA512, Encoding.ASCII.GetBytes("2")),
					Salt = "2"
				});
				context.SaveChanges();
			}
		}

		int _amountOfScores = 50;
		private void SeedScores(EfDbContext context, ICollection<PortalUser> users)
		{
			var amount = context.Scores.Count();
			if (amount < _amountOfScores)
			{
				var rnd = new Random();
				var rnd2 = new Random();

				var itemsToAdd = _amountOfScores - amount;
				for (var i = 1; i <= itemsToAdd; i++)
				{
					var r = rnd.Next(0, users.Count());
					var r2 = rnd2.Next(1, 250);
					context.Scores.Add(new Score
					{
						UserId = users.ElementAt(r).Id,
						PlayerScore = r2 * 1000,
						MapId = 2,
						CreatedOn = new DateTime(2017, 01, 01),
						ModifiedOn = new DateTime(2017, 01, 01)
					});
				}
				context.SaveChanges();
			}
		}
	}
}