using System.ComponentModel.DataAnnotations;
using System;
namespace TestProgram.DataModal
{
    class History
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string ThemeName { get; set; }
        [Required]
        public string CountProcent { get; set; }
        [Required]
        public DateTime DateTime { get; set; }
        [Required]
        public string Passet { get; set; }
    }
}
