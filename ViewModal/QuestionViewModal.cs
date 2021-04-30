using System;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using TestProgram.DataModal;

namespace TestProgram.ViewModal
{
    class QuestionViewModal : BaseViewModel
    {
        TestProgramModal db = new TestProgramModal();
        public ObservableCollection<Question> Questions { set; get; }

        public QuestionViewModal()
        {
            Questions = new ObservableCollection<Question>();
        }
        public void LoadQuestions()
        {
            Questions.Clear();
            foreach (Question pr in db.Questions)
            {
                Questions.Add(pr);
            }
        }

        public void LoadQuestions(Theme ThemeId)
        {
            Questions.Clear();
            if (ThemeId == null)
                return;
            Theme obj = db.Themes.Where(a => a.Id == ThemeId.Id).FirstOrDefault();
            if (obj != null)
            {
                foreach (Question pr in obj.Questions)
                {
                    if (pr.Theme.Id == ThemeId.Id)
                        Questions.Add(pr);
                }
            }
        }
        public void LoadQuestions(Theme ThemeId,int min, int max)
        {
            Questions.Clear();
            if (ThemeId == null)
                return;
            Theme theme = db.Themes.Where(a => a.Id == ThemeId.Id).FirstOrDefault();
            db.Entry(theme).Collection(c => c.Questions).Load();
             
            var obj = db.Themes.Include("Questions").
                Where(item => item.Id == ThemeId.Id).FirstOrDefault().
                Questions.Skip(min).Take(max - min).ToList(); ;
            
            if (obj != null)
            {
                foreach (Question pr in obj)
                {
                    db.Entry(pr).Collection(c => c.Ansvers).Load();
                    Questions.Add(pr);
                }
            }
        }
        public void AddQuestion(Question bufqu, Theme bufth)
        {
            if (bufqu == null)
                return;
            if (bufth == null)
                return;
            Theme t = db.Themes.Where(a => a.Id == bufth.Id).FirstOrDefault();
            db.Questions.Add(new Question { Theme = t, Name = bufqu.Name, AudioPath = bufqu.AudioPath, PhotoPath = bufqu.PhotoPath, CountTrueAnsverToQuestion = bufqu.CountTrueAnsverToQuestion });
            db.SaveChanges();
        }
        public void EditQuestion(Question q)
        {
            if (q == null)
                return;
            try
            {
                var obj = db.Questions.SingleOrDefault(item => item.Id == q.Id);
                db.Entry(obj).CurrentValues.SetValues(q);
                db.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void RemoveAnsverToQuestion(Ansver bufan)
        {
            if (bufan == null)
                return;
            db.Ansvers.Remove(bufan);
            db.SaveChanges();
        }
        public void RemoveQuestion(Question q)
        {
            if (q == null)
                return;
            try
            {
                Question buf = db.Questions.Where(a => a.Id == q.Id).FirstOrDefault();
                    var an = db.Ansvers.Where(c => c.Question.Id == q.Id).ToList();
                    db.Entry(buf).Collection(c => c.Ansvers).Load();
                    foreach (var i in an)
                    {
                        db.Ansvers.Remove(i);
                    }
                    db.Questions.Remove(buf);
                
               
                db.SaveChanges(); 

            }
            catch (ArgumentNullException)
            {
                throw;
            }
        }
    }
}
