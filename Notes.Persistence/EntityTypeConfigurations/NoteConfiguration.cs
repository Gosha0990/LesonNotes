using Microsoft.EntityFrameworkCore;
using Notes.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Notes.Persistence.EntityTypeConfigurations
{
    public class NoteConfiguration : IEntityTypeConfiguration<Note>
    {
        public void Configure(EntityTypeBuilder<Note> build)
        {
            build.HasKey(note => note.Id);
            build.HasIndex(note => note.Id).IsUnique();
            build.Property(note => note.Title).HasMaxLength(250);
        }
    }
}
