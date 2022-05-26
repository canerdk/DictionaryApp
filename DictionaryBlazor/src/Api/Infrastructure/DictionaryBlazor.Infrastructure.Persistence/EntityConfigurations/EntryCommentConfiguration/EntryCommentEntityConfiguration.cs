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
    public class EntryCommentEntityConfiguration : BaseEntityConfiguration<EntryComment>
    {
        public override void Configure(EntityTypeBuilder<EntryComment> builder)
        {
            base.Configure(builder);

            builder.ToTable("entrycomment", DictionaryBlazorContext.DEFAULT_SCHEMA);

            builder.HasOne(x => x.CreatedBy)
                .WithMany(x => x.EntryComments)
                .HasForeignKey(x => x.CreatedById)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Entry)
                .WithMany(x => x.EntryComments)
                .HasForeignKey(x => x.EntryId);
        }
    }
}
