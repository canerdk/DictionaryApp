using DictionaryBlazor.Api.Domain.Models;
using DictionaryBlazor.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryBlazor.Infrastructure.Persistence.EntityConfigurations.Entry
{
    public class EntryFavoriteEntityConfiguration : BaseEntityConfiguration<EntryFavorite>
    {
        public override void Configure(EntityTypeBuilder<EntryFavorite> builder)
        {
            base.Configure(builder);

            builder.ToTable("entryfavorite", DictionaryBlazorContext.DEFAULT_SCHEMA);

            builder.HasOne(x => x.Entry)
                .WithMany(x => x.EntryFavorites)
                .HasForeignKey(x => x.EntryId);

            builder.HasOne(x => x.CreatedUser)
                .WithMany(x => x.EntryFavorites)
                .HasForeignKey(x => x.CreatedById)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
