using Library.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Library.Data
{
    public class AppDbContext : IdentityDbContext<AppUSer>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<MemberBook> MemberBooks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityUserLogin<string>>()
                .HasKey(ul => new { ul.LoginProvider, ul.ProviderKey });

            modelBuilder.Entity<MemberBook>()
                .HasKey(mb => new { mb.MemberId, mb.BookId });

            modelBuilder.Entity<MemberBook>()
                .HasOne(mb => mb.Member)
                .WithMany(m => m.MemberBooks)
                .HasForeignKey(mb => mb.MemberId);

            modelBuilder.Entity<MemberBook>()
                .HasOne(mb => mb.Book)
                .WithMany(b => b.MemberBooks)
                .HasForeignKey(mb => mb.BookId);
        }
    }
}