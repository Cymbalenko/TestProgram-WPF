using System;
using System.Collections.ObjectModel;
using System.Linq;
using TestProgram.DataModal;

namespace TestProgram.ViewModal
{
    class HistoryViewModal : BaseViewModel
    {
        TestProgramModal db = new TestProgramModal();
        public ObservableCollection<History> Historyes { set; get; }

        public HistoryViewModal()
        {
            Historyes = new ObservableCollection<History>();
        }
        public void LoadHistoryes()
        {
            Historyes.Clear();
            foreach (History h in db.Historys)
            {
                Historyes.Add(h);
            }
        }
        public void AddHistoryes(History his)
        {
            if (his == null)
                return;
            db.Historys.Add(new History { Name=his.Name, CountProcent=his.CountProcent, DateTime=his.DateTime, Passet=his.Passet, ThemeName=his.ThemeName});

            db.SaveChanges();
        }
        public void EditHistoryes(History s)
        {
            if (s == null)
                return;
            try
            {
                var obj = db.Historys.SingleOrDefault(item => item.Id == s.Id);
                db.Entry(obj).CurrentValues.SetValues(s);
                db.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void RemoveHistoryes(History s)
        {
            if (s == null)
                return;
            try
            {
                History se = db.Historys
    .Where(c => c.Id == s.Id)
    .FirstOrDefault();
                db.Historys.Remove(se);
                db.SaveChanges();
            }
            catch (ArgumentNullException)
            {
                throw;
            }
        }
    }
}
