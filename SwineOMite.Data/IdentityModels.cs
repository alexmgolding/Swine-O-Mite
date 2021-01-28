using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SwineOMite.Data.Entities;

namespace SwineOMite.Data
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        
        public DbSet<CompleteIngredient> CompleteIngredients { get; set; }
        public DbSet<Direction> Directions { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<IngredientQuantity> IngredientQuantities { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<SmokingWood> SmokingWoods { get; set; }
        public DbSet<WoodQuantity> WoodQuantities { get; set; }
        public DbSet<SmokingWoodQuantity> SmokingWoodQuantities { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder
            .Conventions
            .Remove<PluralizingTableNameConvention>();

            modelBuilder
                .Configurations
                .Add(new IdentityUserLoginConfiguration())
                .Add(new IdentityUserRoleConfiguration());

            modelBuilder
                .Entity<Recipe>()
                .HasMany<CompleteIngredient>(r => r.CompleteIngredients)
                .WithMany(c => c.Recipes)
                .Map(cr =>
                {
                    cr.MapLeftKey("Recipe");
                    cr.MapRightKey("CompleteIngredient");
                    cr.ToTable("RecipeCompleteIngredient");
                });

            //modelBuilder
                //.Entity<SmokingWoodQuantity>()
                //.HasRequired(r => r.SmokingWood)
                //.WithMany(s => s.)
               // .Property(t => t.SmokingWoodQuantityId)
               // .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute()));

        }


    }
    public class IdentityUserLoginConfiguration : EntityTypeConfiguration<IdentityUserLogin>
    {
        public IdentityUserLoginConfiguration()
        { 
            HasKey(iul => iul.UserId);
        }
    }

    public class IdentityUserRoleConfiguration : EntityTypeConfiguration<IdentityUserRole>
    { 
        public IdentityUserRoleConfiguration()
        {
            HasKey(iur => iur.UserId);
        }
    }
}