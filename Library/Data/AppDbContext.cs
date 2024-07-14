using Library.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Net;

namespace Library.Data
{
    public class AppDbContext : DbContext
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
