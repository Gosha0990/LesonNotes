using Microsoft.EntityFrameworkCore;
using Neotes.Application.Interfaces;
using Notes.Domain;
using Notes.Persistence.EntityTypeConfigurations;


namespace Notes.Persistence
{
    class NotesDbContext : DbContext, INoteDbContext
    {
        public DbSet<Note> Notes { get; set; }

        public NotesDbContext(DbContextOptions<NotesDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new NoteConfiguration());
            base.OnModelCreating(builder);
        }
    }
}
