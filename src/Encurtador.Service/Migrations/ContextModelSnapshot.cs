// <auto-generated />
using Encurtador.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Encurtador.Service.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.4");

            modelBuilder.Entity("Encurtador.Service.Model.EncurtadorEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("LinkEncurt")
                        .HasColumnType("TEXT");

                    b.Property<string>("LinkOrig")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Encurtador");
                });
#pragma warning restore 612, 618
        }
    }
}
