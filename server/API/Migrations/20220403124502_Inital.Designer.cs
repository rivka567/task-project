// <auto-generated />
using System;
using API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace API.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220403124502_Inital")]
    partial class Inital
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("API.Entities.TaskData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCompleted");

                    b.Property<string>("DescribeTask");

                    b.Property<bool>("RepeatTask");

                    b.Property<bool?>("TaskCompleted");

                    b.Property<string>("TaskName");

                    b.Property<TimeSpan>("TaskTime");

                    b.Property<int>("TaskTypeId");

                    b.HasKey("Id");

                    b.HasIndex("TaskTypeId");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("API.Entities.TaskType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Type");

                    b.HasKey("Id");

                    b.ToTable("Types");
                });

            modelBuilder.Entity("API.Entities.TaskData", b =>
                {
                    b.HasOne("API.Entities.TaskType", "TaskType")
                        .WithMany("TaskData")
                        .HasForeignKey("TaskTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
