using System;
using System.Collections.ObjectModel;
using System.Linq;
using TestProgram.DataModal;

namespace TestProgram.ViewModal
{
    class ThemeViewModal: BaseViewModel
    {
        TestProgramModal db = new TestProgramModal();
        public ObservableCollection<Theme> Themes { set; get; }

        public ThemeViewModal()
        {
            Themes = new ObservableCollection<Theme>();
             
            LoadThemes();
        }
        public void LoadThemes()
        {
            Themes.Clear();
            foreach (Theme th in db.Themes)
            {
                Themes.Add(th);
            }
        }

        public void AddTheme(Theme t)
        {
            if (t == null)
                return;
            db.Themes.Add(new Theme { Name=t.Name, Procent=t.Procent, FalseText=t.FalseText, TrueText=t.TrueText});
            db.SaveChanges();
        }
        public void AddQuestionToTheme(Theme bufth, Question bufqu)
        {
            if (bufqu == null)
                return;
            if (bufth == null)
                return;
            Theme t = db.Themes.Where(a => a.Id == bufth.Id).FirstOrDefault();
             db.Questions.Add(new Question { Theme=t,Name=bufqu.Name, AudioPath=bufqu.AudioPath, PhotoPath=bufqu.PhotoPath, CountTrueAnsverToQuestion=bufqu.CountTrueAnsverToQuestion });
           
            db.SaveChanges();
        }
        public void RemoveQuestionToTheme(Question bufqu)
        {
            if (bufqu == null)
                return;
            Question buf = db.Questions.Where(a => a.Id == bufqu.Id).FirstOrDefault();
            db.Questions.Remove(buf); 
            db.SaveChanges();
        } 
        public void EditTheme(Theme t)
        {
            if (t == null)
                return;
            try
            {
                var obj = db.Themes.SingleOrDefault(item => item.Id == t.Id);
                db.Entry(obj).CurrentValues.SetValues(t);
                db.SaveChanges();
                
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void RemoveTheme(Theme t)
        {
            if (t == null)
                return;
            try
            {
                Theme theme = db.Themes
    .Where(c => c.Id == t.Id)
    .FirstOrDefault();
                var q = db.Questions.Where(c => c.Theme.Id == theme.Id).ToList();
                foreach (var item in q)
                {
                    var an = db.Ansvers.Where(c => c.Question.Id == item.Id).ToList();
                    db.Entry(item).Collection(c => c.Ansvers).Load();
                    foreach (var i in an)
                    {
                        db.Ansvers.Remove(i);
                    }
                    db.Questions.Remove(item);
                }
                db.Entry(theme).Collection(c => c.Questions).Load(); 
                db.Themes.Remove(theme);
                db.SaveChanges();
                LoadThemes();
                 
            }
            catch (ArgumentNullException)
            {
                throw;
            }
        }
    }
}
