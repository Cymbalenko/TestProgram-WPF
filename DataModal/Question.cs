using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace TestProgram.DataModal
{
    public class Question
    {
        public Question()
        {
            Ansvers = new ObservableCollection<Ansver>();
            Theme = new Theme();
        }
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        
        public int Check { get; set; }
        public string PhotoPath { get; set; }
        public string AudioPath { get; set; }
        public int Response { get; set; }
        public int CountTrueAnsverToQuestion { get; set; }

        [Required]
        public int CountTrue { get; set; }

        [Required]
        public int CountFalse { get; set; }
        public Theme Theme { get; set; }
        //навигационные ссылки
        public virtual ObservableCollection<Ansver> Ansvers { set; get; }
    }
}
