using System.Configuration;
using Microsoft.EntityFrameworkCore;
using ScientificDatabase.Models.Hierarchy;
using ScientificDatabase.Models.TypeObject;

namespace ScientificDatabase.Models
{
    public partial class ScientificContext : DbContext
    {
        public ScientificContext()
        {
        }

        public ScientificContext(DbContextOptions<ScientificContext> options)
            : base(options)
        {
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Area> Areas { set; get; }
        public virtual DbSet<Section> Sections { set; get; }
        public virtual DbSet<DataObject> DataObjects { set; get; }
        public virtual DbSet<Property> Properties { set; get; }
        public virtual DbSet<TypeObject.TypeObject> TypeObjects { set; get; }
        public virtual DbSet<ValuePropertyObject> ValuePropertyObjects { set; get; }
        public virtual DbSet<Research> Researches { set; get; }

        /// <summary>
        /// Страка подключения используемая при миграции базы данных
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (!optionsBuilder.IsConfigured)
            //{
            optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS01;Database=Scientific;Trusted_Connection=True;MultipleActiveResultSets=true");
            //}
        }

        public void NewMethod(object Foo)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
