using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using DeviceManager.Api.Data;

namespace DeviceManager.Api.Migrations
{
    [DbContext(typeof(DeviceContext))]
    [Migration("20180913101824_InitialCreate4")]
    partial class InitialCreate4
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DeviceManager.Api.Data.Model.Device", b =>
                {
                    b.Property<Guid>("DeviceId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DeviceTitle");

                    b.HasKey("DeviceId");

                    b.ToTable("Devices");
                });
        }
    }
}
