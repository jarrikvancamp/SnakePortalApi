using System.Data.Entity;
using System.Data.Entity.SqlServer;
using Entities.PlayerScore;
using Entities.User;
using Entities.Posts;
using Entities.Menu;

namespace DAL.Infrastructure
{
	public class EfDbContext : DbContext
	{
		#region Constructor

		public EfDbContext() : base(_connectionAzureJarrik)
		{
			// Database.SetInitializer(new DbSeeder(500));
			var instance = SqlProviderServices.Instance;
		}

		#endregion

		public DbSet<Score> Scores { get; set; }
		public DbSet<PortalUser> PortalUsers { get; set; }
		public DbSet<BlogPost> Blogposts { get; set; }
		public DbSet<FeedEntry> FeedEntries { get; set; }
		public DbSet<MenuElement> MenuElements { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Score>().ToTable("Scores")
				.HasKey(x => x.Id)
				.Property(f => f.CreatedOn)
				.HasColumnType("datetime2");
			modelBuilder.Entity<PortalUser>().ToTable("PortalUsers").HasKey(x => x.Id).Property(f => f.CreatedOn)
				.HasColumnType("datetime2");
			modelBuilder.Entity<PortalUser>().ToTable("PortalUsers").HasKey(x => x.Id).Property(f => f.ModifiedOn)
				.HasColumnType("datetime2");
			modelBuilder.Entity<BlogPost>().ToTable("Blogposts").HasKey(x => x.Id).Property(f => f.CreatedOn)
				.HasColumnType("datetime2");
			modelBuilder.Entity<FeedEntry>().ToTable("FeedEntries").HasKey(x => x.Id).Property(f => f.CreatedOn)
				.HasColumnType("datetime2");
			modelBuilder.Entity<MenuElement>().ToTable("MenuElements").HasKey(x => x.Id);

			base.OnModelCreating(modelBuilder);
		}

		#region Private Members

		private static readonly string _connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SnakePortal;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

		private static readonly string _connectionAzureJarrik = @"Server=tcp:snakeportal-projectwerk.database.windows.net" +
			",1433;Initial Catalog=snakeportal;Persist Security Info=False;" +
			"User ID=jarrikvancamp;Password=SnakePortal2017;MultipleActiveResultSets=False;Encrypt=True" +
			";TrustServerCertificate=False;Connection Timeout=30;";
		private static readonly string _azureConnectionStringCedric =
			"Server=tcp:snakeportal.database.windows.net,1433;Database=SnakePortal;" +
			"User ID=SnakeAdmin@snakeportal;Password=S14519%%;Trusted_Connection=False;Encrypt=True;Connection Timeout=30;";

		private static readonly string _productionConnectionString = @"Data Source=snakeportal-projectwerk.database.windows.net;Initial Catalog=db-snakeportal-prod;Integrated Security=False;User ID=jarrikvancamp;Password=********;Connect Timeout=60;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

		#endregion
	}
}