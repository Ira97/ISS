using System.Configuration;
using Microsoft.EntityFrameworkCore;
using ScientificDatabase.Models.Hierarchy;

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

        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        //public virtual DbSet<UserRole> UserRole { get; set; }
        public virtual DbSet<Area> Area { set; get; }
        public virtual DbSet<Section> Section { set; get; }
        // public virtual DbSet<AreaSection> AreaSection { set; get; }

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
