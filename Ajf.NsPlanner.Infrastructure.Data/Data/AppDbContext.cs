using System;
using System.IO;
using System.Linq;
using Ajf.NsPlanner.Domain.Abstractions;
using Ajf.NsPlanner.Domain.Entities;
using Ajf.NsPlanner.Domain.SharedKernel;
using Microsoft.EntityFrameworkCore;

namespace Ajf.NsPlanner.Infrastructure.Data.Data
{
    public class AppDbContext : DbContext, IUnitOfWork
    {
        private readonly IDomainEventDispatcher _dispatcher;

        public AppDbContext(DbContextOptions<AppDbContext> options, IDomainEventDispatcher dispatcher)
            : this(options)
        {
            _dispatcher = dispatcher;
        }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
            Id = Guid.NewGuid();
        }

        public AppDbContext()
        {
        }

        public Guid Id { get; }
        public DbSet<Counselor> Counselors { get; set; }
        public DbSet<Period> Periods { get; set; }
        public DbSet<EventRequest> EventRequests { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<AvailableDate> AvailableDates { get; set; }

        public override int SaveChanges()
        {
            // dispatch events only if save was successful
            var entitiesWithEvents = ChangeTracker.Entries<BaseEntity>()
                .Select(e => e.Entity)
                .Where(e => e.Events.Any())
                .ToArray();

            var result = base.SaveChanges();

            foreach (var entity in entitiesWithEvents)
            {
                var events = entity.Events.ToArray();
                entity.Events.Clear();
                foreach (var domainEvent in events) _dispatcher.Dispatch(domainEvent);
            }

            return result;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Server=juulserver2019a\\sqlexpress;Database=nsplanner;Trusted_Connection=True;MultipleActiveResultSets=true");
            var folderPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
            var nsFolderPath = Path.Combine(folderPath, "NsPlanner");
            var dbFilePath = Path.Combine(nsFolderPath, "NsPlanner.mdf");

            Directory.CreateDirectory(nsFolderPath);

            var connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;Database=nsplanner;AttachDbFilename=" +
                                   dbFilePath + ";Integrated Security=True;Connect Timeout=30";

            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new PeriodConfiguration());
        }
    }
}