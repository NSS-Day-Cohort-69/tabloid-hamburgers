using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Tabloid.Models;

namespace Tabloid.Data;

public class TabloidDbContext : IdentityDbContext<IdentityUser>
{
    private readonly IConfiguration _configuration;

    public DbSet<UserProfile> UserProfiles { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<DemoteAdmin> DemoteAdmins { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<PostReaction> PostReactions { get; set; }
    public DbSet<PostTag> PostTags { get; set; }
    public DbSet<Reaction> Reactions { get; set; }
    public DbSet<Subscription> Subscriptions { get; set; }
    public DbSet<Tag> Tags { get; set; }

    public TabloidDbContext(DbContextOptions<TabloidDbContext> context, IConfiguration config)
        : base(context)
    {
        _configuration = config;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder
            .Entity<IdentityRole>()
            .HasData(
                new IdentityRole
                {
                    Id = "c3aaeb97-d2ba-4a53-a521-4eea61e59b35",
                    Name = "Admin",
                    NormalizedName = "admin"
                }
            );

        modelBuilder
            .Entity<IdentityUser>()
            .HasData(
                new IdentityUser[]
                {
                    new IdentityUser
                    {
                        Id = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                        UserName = "Administrator",
                        Email = "admina@strator.comx",
                        PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(
                            null,
                            _configuration["AdminPassword"]
                        )
                    },
                    new IdentityUser
                    {
                        Id = "d8d76512-74f1-43bb-b1fd-87d3a8aa36df",
                        UserName = "JohnDoe",
                        Email = "john@doe.comx",
                        PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(
                            null,
                            _configuration["AdminPassword"]
                        )
                    },
                    new IdentityUser
                    {
                        Id = "a7d21fac-3b21-454a-a747-075f072d0cf3",
                        UserName = "JaneSmith",
                        Email = "jane@smith.comx",
                        PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(
                            null,
                            _configuration["AdminPassword"]
                        )
                    },
                    new IdentityUser
                    {
                        Id = "c806cfae-bda9-47c5-8473-dd52fd056a9b",
                        UserName = "AliceJohnson",
                        Email = "alice@johnson.comx",
                        PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(
                            null,
                            _configuration["AdminPassword"]
                        )
                    },
                    new IdentityUser
                    {
                        Id = "9ce89d88-75da-4a80-9b0d-3fe58582b8e2",
                        UserName = "BobWilliams",
                        Email = "bob@williams.comx",
                        PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(
                            null,
                            _configuration["AdminPassword"]
                        )
                    },
                    new IdentityUser
                    {
                        Id = "d224a03d-bf0c-4a05-b728-e3521e45d74d",
                        UserName = "EveDavis",
                        Email = "Eve@Davis.comx",
                        PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(
                            null,
                            _configuration["AdminPassword"]
                        )
                    },
                }
            );

        modelBuilder
            .Entity<IdentityUserRole<string>>()
            .HasData(
                new IdentityUserRole<string>[]
                {
                    new IdentityUserRole<string>
                    {
                        RoleId = "c3aaeb97-d2ba-4a53-a521-4eea61e59b35",
                        UserId = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f"
                    },
                    new IdentityUserRole<string>
                    {
                        RoleId = "c3aaeb97-d2ba-4a53-a521-4eea61e59b35",
                        UserId = "d8d76512-74f1-43bb-b1fd-87d3a8aa36df"
                    },
                }
            );
        modelBuilder
            .Entity<UserProfile>()
            .HasData(
                new UserProfile[]
                {
                    new UserProfile
                    {
                        Id = 1,
                        IdentityUserId = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                        FirstName = "Admina",
                        LastName = "Strator",
                        ImageLocation =
                            "https://robohash.org/numquamutut.png?size=150x150&set=set1",
                        CreateDateTime = new DateTime(2022, 1, 25),
                        IsDeactivated = false
                    },
                    new UserProfile
                    {
                        Id = 2,
                        FirstName = "John",
                        LastName = "Doe",
                        CreateDateTime = new DateTime(2023, 2, 2),
                        ImageLocation =
                            "https://robohash.org/nisiautemet.png?size=150x150&set=set1",
                        IdentityUserId = "d8d76512-74f1-43bb-b1fd-87d3a8aa36df",
                        IsDeactivated = false
                    },
                    new UserProfile
                    {
                        Id = 3,
                        FirstName = "Jane",
                        LastName = "Smith",
                        CreateDateTime = new DateTime(2022, 3, 15),
                        ImageLocation =
                            "https://robohash.org/molestiaemagnamet.png?size=150x150&set=set1",
                        IdentityUserId = "a7d21fac-3b21-454a-a747-075f072d0cf3",
                        IsDeactivated = false
                    },
                    new UserProfile
                    {
                        Id = 4,
                        FirstName = "Alice",
                        LastName = "Johnson",
                        CreateDateTime = new DateTime(2023, 6, 10),
                        ImageLocation =
                            "https://robohash.org/deseruntutipsum.png?size=150x150&set=set1",
                        IdentityUserId = "c806cfae-bda9-47c5-8473-dd52fd056a9b",
                        IsDeactivated = false
                    },
                    new UserProfile
                    {
                        Id = 5,
                        FirstName = "Bob",
                        LastName = "Williams",
                        CreateDateTime = new DateTime(2023, 5, 15),
                        ImageLocation =
                            "https://robohash.org/quiundedignissimos.png?size=150x150&set=set1",
                        IdentityUserId = "9ce89d88-75da-4a80-9b0d-3fe58582b8e2",
                        IsDeactivated = true
                    },
                    new UserProfile
                    {
                        Id = 6,
                        FirstName = "Eve",
                        LastName = "Davis",
                        CreateDateTime = new DateTime(2022, 10, 18),
                        ImageLocation =
                            "https://robohash.org/hicnihilipsa.png?size=150x150&set=set1",
                        IdentityUserId = "d224a03d-bf0c-4a05-b728-e3521e45d74d",
                        IsDeactivated = false
                    }
                }
            );
        // Seed data
        modelBuilder
            .Entity<Post>()
            .HasData(
                new Post
                {
                    Id = 1,
                    Title = "First Post",
                    AuthorId = 1,
                    Content = "This is the content of the first post.",
                    CategoryId = 1,
                    IsApproved = true,
                    Publication = DateTime.Now
                },
                new Post
                {
                    Id = 2,
                    Title = "Second Post",
                    AuthorId = 2,
                    Content = "This is the content of the second post.",
                    CategoryId = 2,
                    IsApproved = true,
                    Publication = DateTime.Now
                }
            );

        modelBuilder
            .Entity<Category>()
            .HasData(
                new Category { Id = 1, CategoryName = "Tech" },
                new Category { Id = 2, CategoryName = "Lifestyle" }
            );

        modelBuilder
            .Entity<Tag>()
            .HasData(
                new Tag { Id = 1, TagName = "EFCore" },
                new Tag { Id = 2, TagName = "CSharp" }
            );

        modelBuilder
            .Entity<PostTag>()
            .HasData(
                new PostTag
                {
                    Id = 1,
                    PostId = 1,
                    TagId = 1
                },
                new PostTag
                {
                    Id = 2,
                    PostId = 2,
                    TagId = 2
                }
            );

        modelBuilder
            .Entity<Comment>()
            .HasData(
                new Comment
                {
                    Id = 1,
                    Subject = "First Comment",
                    Content = "This is the first comment.",
                    PostId = 1,
                    CommenteerId = 2,
                    CreationDate = DateTime.Now
                },
                new Comment
                {
                    Id = 2,
                    Subject = "Second Comment",
                    Content = "This is the second comment.",
                    PostId = 2,
                    CommenteerId = 1,
                    CreationDate = DateTime.Now
                }
            );

        modelBuilder
            .Entity<Subscription>()
            .HasData(
                new Subscription
                {
                    Id = 1,
                    SubscriberId = 1,
                    FollowerId = 2,
                    SubbedDate = DateTime.Now,
                    UnsubbedDate = null
                }
            );

        modelBuilder
            .Entity<Reaction>()
            .HasData(
                new Reaction { Id = 1, ImageURL = "https://example.com/reaction1.png" },
                new Reaction { Id = 2, ImageURL = "https://example.com/reaction2.png" }
            );

        modelBuilder
            .Entity<PostReaction>()
            .HasData(
                new PostReaction
                {
                    Id = 1,
                    PostId = 1,
                    ReactorId = 2,
                    ReactionId = 1
                },
                new PostReaction
                {
                    Id = 2,
                    PostId = 2,
                    ReactorId = 1,
                    ReactionId = 2
                }
            );

        modelBuilder
            .Entity<DemoteAdmin>()
            .HasData(
                new DemoteAdmin
                {
                    Id = 1,
                    AdminApprovalId = 1,
                    AdminToDemoteId = 2
                }
            );
    }
}
