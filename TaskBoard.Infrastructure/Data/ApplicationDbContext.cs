using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using TaskBoard.Infrastructure.Models;
using Task = TaskBoard.Infrastructure.Models.Task;

namespace TaskBoard.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<Task> Tasks { get; set; } = null!;
        public DbSet<Board> Boards { get; set; } = null!;

        private IdentityUser TestUser { get; set; } = null!;
        private Board OpenBoard { get; set; }
        private Board InProgressBoard { get; set; } = null!;
        private Board DoneBoard { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Task>()
                .HasOne(t => t.Board)
                .WithMany(t => t.Tasks)
                .OnDelete(DeleteBehavior.Restrict);

            SeedUsers();
            builder.Entity<IdentityUser>()
                .HasData(TestUser);

            SeedBoards();
            builder.Entity<Board>()
                .HasData(OpenBoard, InProgressBoard, DoneBoard);

            builder.Entity<Task>()
                .HasData(new Task()
                {
                    Id=1,
                    Title = "Improve CSS styles",
                    Description = "Implement better styling for all public pages",
                    CreatedOn = DateTime.Now.AddDays(-200),
                    OwnerId = TestUser.Id,
                    BoardId = OpenBoard.Id,
                },
                new Task()
                {
                    Id = 2,
                    Title = "Android Client App",
                    Description = "Create android client app for the TaskBoard RESTful API",
                    CreatedOn = DateTime.Now.AddMonths(-5),
                    OwnerId = TestUser.Id,
                    BoardId = OpenBoard.Id,
                },
                new Task()
                {
                    Id = 3,
                    Title = "Desctop Client App",
                    Description = "Create Windows Form desktop client app for the TaskBoard RESTful API",
                    CreatedOn = DateTime.Now.AddMonths(-1),
                    OwnerId = TestUser.Id,
                    BoardId = InProgressBoard.Id,
                },
                new Task()
                {
                    Id = 4,
                    Title = "Create Tasks",
                    Description = "Implement [Create Tasks] page for adding new tasks",
                    CreatedOn = DateTime.Now.AddYears(-1),
                    OwnerId = TestUser.Id,
                    BoardId = DoneBoard.Id,
                });

            base.OnModelCreating(builder);
        }

        private void SeedUsers()
        {
            var hasher = new PasswordHasher<IdentityUser>();

            TestUser = new IdentityUser()
            {
                UserName = "testUser@test.bg",
                NormalizedUserName = "TESTUSER@TEST.BG"

            };

            TestUser.PasswordHash = hasher.HashPassword(TestUser, "aaaaaa");
        }

        private void SeedBoards()
        {
            OpenBoard = new Board()
            {
                Id = 1,
                Name = "Open"
            };

            InProgressBoard = new Board()
            {
                Id = 2,
                Name = "In Progress"
            };

            DoneBoard = new Board()
            {
                Id = 3,
                Name = "Done"
            };
        }
    }
}
