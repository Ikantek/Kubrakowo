using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kubrakowo.WebApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kubrakowo.WebApp.Domain.Configuration
{
    public class ImageConfiguration : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.HasKey(x => x.ImageId);
        }
    }
}
