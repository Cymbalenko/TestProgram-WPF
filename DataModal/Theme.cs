using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;

namespace TestProgram.DataModal
{
    public class Theme
    {

        public Theme()
        {
            Questions = new ObservableCollection<Question>();
        }
        public int Id { get; set; }

        [Required]
        [StringLength(1024)]
        public string Name { get; set; }
        public int Procent { get; set; }
        public string TrueText { get; set; }
        public string FalseText { get; set; }
        //навигационные ссылки
        public virtual ObservableCollection<Question> Questions { set; get; }
    }
}
