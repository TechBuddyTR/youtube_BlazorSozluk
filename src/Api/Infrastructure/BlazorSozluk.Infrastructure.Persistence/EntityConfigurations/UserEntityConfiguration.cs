using BlazorSozluk.Api.Domain.Models;
using BlazorSozluk.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlazorSozluk.Api.Infrastructure.Persistence.EntityConfigurations;

public class UserEntityConfiguration : BaseEntityConfiguration<User>
{
    public override void Configure(EntityTypeBuilder<User> builder)
    {
        base.Configure(builder);

        builder.ToTable("user", BlazorSozlukContext.DEFAULT_SCHEMA);
    }
}
