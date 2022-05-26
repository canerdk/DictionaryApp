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
    public class EntryCommentVoteEntityConfiguration : BaseEntityConfiguration<EntryCommentVote>
    {
        public override void Configure(EntityTypeBuilder<EntryCommentVote> builder)
        {
            base.Configure(builder);

            builder.ToTable("entrycommentvote", DictionaryBlazorContext.DEFAULT_SCHEMA);

            builder.HasOne(x => x.EntryComment)
                .WithMany(x => x.EntryCommentVotes)
                .HasForeignKey(x => x.EntryCommentId);

        }
    }
}
