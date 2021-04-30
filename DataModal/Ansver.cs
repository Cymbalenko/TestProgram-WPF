using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace TestProgram.DataModal
{
    public class Ansver
    {
        public Ansver()
        {
            Question = new Question();
        }
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } 
        public int Check { get; set; } 
        public int CorrectAnsver { get; set; } 
        public int CountBall { get; set; }
        //навигационные ссылки
        public Question Question { get; set; }
    }
}
