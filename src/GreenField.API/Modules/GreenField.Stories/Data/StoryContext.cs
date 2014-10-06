using GreenField.Books.Data.DomainModels;
using GreenField.Framework.Data;
using GreenField.Framework.Data.DomainModels;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Reflection;

namespace GreenField.Books.Data
{
    public class StoryContext : BookContext
    {
        public StoryContext()
            : base("GFContext")
        {
            
        }

        public virtual IDbSet<Story> Stories { get; set; }

        public virtual IDbSet<Teller> Tellers { get; set; }

        public virtual IDbSet<StoryEntityPicture> StoryEntityPictures { get; set; }

        public virtual IDbSet<TellerEntityPicture> TellerEntityPictures { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //dynamically load all configuration

            var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
            .Where(type => !String.IsNullOrEmpty(type.Namespace))
            .Where(type => type.BaseType != null && type.BaseType.IsGenericType && type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>));
            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.Configurations.Add(configurationInstance);
            }

        }
    }
}
