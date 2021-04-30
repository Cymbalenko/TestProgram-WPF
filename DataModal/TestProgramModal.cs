using System.Data.Entity;

namespace TestProgram.DataModal
{
    class TestProgramModal : DbContext
    {
        public TestProgramModal()
            : base("name=TestProgramModal")
        { }
        public DbSet<Theme> Themes { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Ansver> Ansvers { get; set; }
        public DbSet<History> Historys { get; set; }
    }
}
