using System.Data.Entity.ModelConfiguration;

namespace GreenField.Books.Data.DomainModels
{
    public class TellerMap : EntityTypeConfiguration<Teller>
    {
        public TellerMap()
        {
            ToTable("Author");
            HasKey(b => b.Id);

            HasOptional(a => a.LoginUser);
        }
    }
}
