using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using TestProgram.DataModal; 

namespace TestProgram.ViewModal
{
    class AnsverViewModal : BaseViewModel
    {
        readonly TestProgramModal db = new TestProgramModal();
        private ObservableCollection<Ansver> ansvers;

        public ObservableCollection<Ansver> Ansvers
        {
            get => ansvers;
            set
            {
                ansvers = value;
                OnPropertyChanged(nameof(Ansvers));
            }
        }

        public AnsverViewModal()
        {
            ansvers = new ObservableCollection<Ansver>(); 
        }
        public void LoadAnsvers()
        {
            Ansvers.Clear();
            foreach (Ansver a in db.Ansvers.ToList())
            {
                Ansvers.Add(a);
            }
        }
        public void LoadAnsvers(Question questionId) 
        { 
            if (questionId == null)
                return;
            Ansvers.Clear();
            var obj = db.Questions.Include("Ansvers").SingleOrDefault(item => item.Id == questionId.Id);
            foreach (Ansver pr in obj.Ansvers)
            { 
                    Ansvers.Add(pr);
            }
        }
        public void AddAnsver(Theme bufth,Question bufqu, Ansver bufan)
        { 
            if (bufan == null)
                return;
            if (bufqu == null)
                return;
            if (bufth == null)
                return;
            try
            {
                Theme t = db.Themes.Where(a => a.Id == bufth.Id).FirstOrDefault();
                Question q = db.Questions.Where(a => a.Id == bufqu.Id).FirstOrDefault();
                Ansver ans = new Ansver { Name = bufan.Name, Check = bufan.Check, CorrectAnsver = bufan.CorrectAnsver, CountBall = bufan.CountBall, Question = q };
                db.Ansvers.Add(ans);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                throw;
            }
        }
        public void RemoveAnsver(Ansver buf)
        {
            if (buf == null)
                return; 
            db.Ansvers.Attach(buf);
            db.Ansvers.Remove(buf);
            db.SaveChanges();
        }

         

        public void EditAnsver(Ansver an)
        {
            if (an == null)
                return;
            try
            { 
                var obj = db.Ansvers.FirstOrDefault(item => item.Id == an.Id); 
                if (obj != an)
                {
                    db.Entry(obj).CurrentValues.SetValues(an); 

                    db.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
