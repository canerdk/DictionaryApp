using DictionaryBlazor.Api.Domain.Models;
using DictionaryBlazor.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryBlazor.Infrastructure.Persistence.EntityConfigurations.EntryCommentConfiguration
{
    public class EntryCommentFavoriteEntityConfiguration : BaseEntityConfiguration<EntryCommentFavorite>
    {
        public override void Configure(EntityTypeBuilder<EntryCommentFavorite> builder)
        {
            base.Configure(builder);

            builder.ToTable("entrycommentfavorite", DictionaryBlazorContext.DEFAULT_SCHEMA);

            builder.HasOne(x => x.EntryComment)
                .WithMany(x => x.EntryCommentFavorites)
                .HasForeignKey(x => x.EntryCommentId);

            builder.HasOne(x => x.CreatedUser)
                .WithMany(x => x.EntryCommentFavorites)
                .HasForeignKey(x => x.CreatedById)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
