using System.Data.Entity.ModelConfiguration;

namespace GreenField.Books.Data.DomainModels
{
    public class TellerMap : EntityTypeConfiguration<Teller>
    {
        public TellerMap()
        {
            ToTable("Teller");
            HasKey(b => b.Id);

            HasOptional(a => a.LoginUser);
        }
    }
}
