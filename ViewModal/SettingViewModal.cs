using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProgram.DataModal;

namespace TestProgram.ViewModal
{
    class SettingViewModal : Setting
    {
        TestProgramModal db = new TestProgramModal();
        public ObservableCollection<Setting> Settings { set; get; }

        public SettingViewModal()
        {
            Settings = new ObservableCollection<Setting>();
        }
        public void LoadQuestions()
        {
            Settings.Clear();
            foreach (Setting pr in db.Settings)
            {
                Settings.Add(pr);
            }
        }
         
        public void AddSettings(Setting setting)
        {
            if (setting == null)
                return;
            db.Settings.Add(new Setting { Language=setting.Language, SelectedTheme=setting.SelectedTheme });

            db.SaveChanges();
        }
        public void EditSettings(Setting s)
        {
            if (s == null)
                return;
            try
            {
                var obj = db.Settings.SingleOrDefault(item => item.Id == s.Id);
                db.Entry(obj).CurrentValues.SetValues(s);
                db.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void RemoveSettings(Setting s)
        {
            if (s == null)
                return;
            try
            {
                Setting se = db.Settings
    .Where(c => c.Id == s.Id)
    .FirstOrDefault();
                db.Settings.Remove(se);
                db.SaveChanges();
            }
            catch (ArgumentNullException)
            {
                throw;
            }
        }
    }
}
