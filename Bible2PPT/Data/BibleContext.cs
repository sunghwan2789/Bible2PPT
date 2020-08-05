﻿using System.Data.Entity;
using Bible2PPT.Bibles;
using Bible2PPT.PPT;
using SQLite.CodeFirst;

namespace Bible2PPT.Data
{
    class BibleContext : DbContext
    {
        public DbSet<Bible> Bibles { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Chapter> Chapters { get; set; }
        public DbSet<Verse> Verses { get; set; }
        public DbSet<Job> Jobs { get; set; }

        public BibleContext() : this("Data Source=./bible.db") { }

        public BibleContext(string connectionString) : base(connectionString)
        {
            var connection = Database.Connection;
            try
            {
                connection.Open();

                using var cmd = connection.CreateCommand();
                cmd.CommandText = "PRAGMA journal_mode=WAL;";
                cmd.ExecuteNonQuery();
            }
            catch
            {
                connection.Close();
                throw;
            }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            Database.SetInitializer(new SqliteDropCreateDatabaseWhenModelChanges<BibleContext>(modelBuilder));

            modelBuilder.Entity<Bible>().HasIndex(e => e.SourceId);

            modelBuilder.Entity<Book>().HasIndex(e => e.SourceId);
            modelBuilder.Entity<Book>().HasIndex(e => e.BibleId);

            modelBuilder.Entity<Chapter>().HasIndex(e => e.SourceId);
            modelBuilder.Entity<Chapter>().HasIndex(e => e.BookId);

            modelBuilder.Entity<Verse>().HasIndex(e => e.SourceId);
            modelBuilder.Entity<Verse>().HasIndex(e => e.ChapterId);

            modelBuilder.Entity<JobBible>().HasRequired(e => e.Job).WithMany(e => e.JobBibles);
            modelBuilder.Entity<JobBible>().HasRequired(e => e.Bible).WithMany();
        }
    }
}
