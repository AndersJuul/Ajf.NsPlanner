using Ajf.NsPlanner.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ajf.NsPlanner.Infrastructure.Data.Data
{
    public class EventRequestConfiguration : IEntityTypeConfiguration<EventRequest>
    {
        public void Configure(EntityTypeBuilder<EventRequest> builder)
        {
            builder
                .HasOne<Assignment>()
                .WithOne(a=>a.EventRequest)
                .IsRequired()
                .HasForeignKey<Assignment>()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}