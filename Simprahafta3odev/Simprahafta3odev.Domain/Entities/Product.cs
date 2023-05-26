﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simprahafta3odev.Domain.Entities
{
    [Table("Product", Schema = "dbo")]
    public class Product 
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string Tag { get; set; }
        public int Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public Category Category { get; set; }

    }

    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CreatedAt).IsRequired(false);
            builder.Property(x => x.CreatedBy).IsRequired(false).HasMaxLength(50);

            builder.Property(x => x.Name).IsRequired(true).HasMaxLength(30);
            builder.Property(x => x.Url).IsRequired(true).HasMaxLength(30);
            builder.Property(x => x.Tag).IsRequired(true).HasMaxLength(100);
            builder.Property(x => x.CategoryId).IsRequired(true);

            builder.HasIndex(x => x.Name).IsUnique(true);
            builder.HasOne(x => x.Category)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.CategoryId)
                .IsRequired();
        }
    }
}
