using System.Data.Entity.ModelConfiguration;

namespace GreenField.Books.Data.DomainModels
{
    public class StoryMap : EntityTypeConfiguration<Story>
    {
        public StoryMap()
        {
            ToTable("Story");
            HasKey(b => b.Id);

            HasRequired(s => s.Teller)
                .WithMany(t => t.Stories)
                .HasForeignKey(b => b.TellerId);

        }
    }
}
