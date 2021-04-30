using System.ComponentModel.DataAnnotations; 

namespace TestProgram.DataModal
{
    class Setting
    {
        public int Id { get; set; }
        [Required]
        public string SelectedTheme { get; set; }
        [Required]
        public string Language { get; set; }
    }
}
