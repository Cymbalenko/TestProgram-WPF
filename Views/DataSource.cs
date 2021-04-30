using System;
using System.Collections.Generic;
using System.Linq;
using TestProgram.ViewModal;
using TestProgram.DataModal;
using TestProgram.Commands;
using System.Windows;
using System.IO;
using System.Windows.Media;
using System.Windows.Threading;
using System.Threading; 
namespace TestProgram.Views
{
    class DataSource : BaseViewModel
    { 
        //viewModal

        AnsverViewModal avm = new AnsverViewModal();
        public IEnumerable<Ansver> Avm => avm.Ansvers;

        QuestionViewModal qvm = new QuestionViewModal();
        public IEnumerable<Question> Qvm => qvm.Questions;

        ThemeViewModal tvm = new ThemeViewModal();
        public IEnumerable<Theme> Tvm => tvm.Themes;

        HistoryViewModal hvm = new HistoryViewModal();
        public IEnumerable<History> Hvm => hvm.Historyes;

        private List<Question> questionTesting = new List<Question>();
        public List<Question> QuestionTesting
        {
            get
            {
                return questionTesting;
            }
            set
            {
                questionTesting = value;
                OnPropertyChanged(nameof(QuestionTesting));
            }
        }
        private List<Ansver> answerTesting = new List<Ansver>();
        public List<Ansver> AnswerTesting
        {
            get
            {
                return answerTesting;
            }
            set
            {
                answerTesting = value;
                OnPropertyChanged(nameof(AnswerTesting));
            }
        }

        //selectedModals
        private Theme selectedTheme = new Theme();
        public Theme SelectedTheme
        {
            get => selectedTheme;
            set
            {
                if (selectedTheme == null)
                {
                    selectedTheme = value;
                    qvm.LoadQuestions(selectedTheme);
                    avm.LoadAnsvers(selectedQuestion);
                    OnPropertyChanged(nameof(SelectedTheme));
                }
                else if (!selectedTheme.Equals(value))
                {
                    selectedTheme = value;
                    if (selectedTheme != null)
                    {
                        qvm.LoadQuestions(selectedTheme);
                        avm.LoadAnsvers(selectedQuestion);
                    }
                    OnPropertyChanged(nameof(SelectedTheme));
                }

            }
        }
        private Theme addSelectedTheme = new Theme();
        public Theme AddSelectedTheme
        {
            get => addSelectedTheme;
            set
            {
                if (addSelectedTheme == null)
                {
                    addSelectedTheme = value;
                    OnPropertyChanged(nameof(AddSelectedTheme));
                }
                else if (!addSelectedTheme.Equals(value))
                {
                    addSelectedTheme = value;
                    if (addSelectedTheme != null)
                        qvm.LoadQuestions(addSelectedTheme);
                    OnPropertyChanged(nameof(AddSelectedTheme));
                }

            }
        }
        private Theme testingTheme = new Theme();
        public Theme TestingTheme
        {
            get => testingTheme;
            set
            {
                testingTheme = value;
                OnPropertyChanged(nameof(TestingTheme));
            }
        }

        private Question selectedQuestion = new Question();
        public Question SelectedQuestion
        {
            get => selectedQuestion;
            set
            {
                if (selectedQuestion == null)
                {
                    selectedQuestion = value;
                    avm.LoadAnsvers(selectedQuestion);
                    OnPropertyChanged(nameof(SelectedQuestion));
                }
                else if (!selectedQuestion.Equals(value))
                {
                    selectedQuestion = value;
                    if (selectedQuestion != null)
                        avm.LoadAnsvers(selectedQuestion);
                    OnPropertyChanged(nameof(SelectedQuestion));
                }

            }
        }
        private Question addselectedQuestion = new Question();
        public Question AddSelectedQuestion
        {
            get => addselectedQuestion;
            set
            {

                addselectedQuestion = value;
                OnPropertyChanged(nameof(AddSelectedQuestion));
            }
        }
        private Question currentQuestion = new Question();
        public Question CurrentQuestion
        {
            get => currentQuestion;
            set
            {
                currentQuestion = value;
                if (value.Check == 1)
                    CheckQuestion = false;
                else if (value.Check == 0)
                    CheckQuestion = true;
                OnPropertyChanged(nameof(CurrentQuestion));


            }
        }

        private Ansver selectedAnsver = new Ansver();
        public Ansver SelectedAnsver
        {
            get => selectedAnsver;
            set
            {
                if (value == null)
                { 
                    selectedAnsver = value;
                    OnPropertyChanged(nameof(SelectedAnsver));
                }
                else if (selectedAnsver == null)
                {
                    selectedAnsver = value;
                    OnPropertyChanged(nameof(SelectedAnsver));
                }
                else if (!selectedAnsver.Equals(value))
                {
                    value.CountBall = (int)value.CountBall;
                    selectedAnsver = value;
                    OnPropertyChanged(nameof(SelectedAnsver));
                }

            }
        }
        private Ansver addSelectedAnsver = new Ansver();
        public Ansver AddSelectedAnsver
        {
            get => addSelectedAnsver;
            set
            {
                if (value == null)
                {
                    addSelectedAnsver = value;
                    OnPropertyChanged(nameof(AddSelectedAnsver));
                }
                else if(addSelectedAnsver == null)
                {
                    addSelectedAnsver = value;
                    OnPropertyChanged(nameof(AddSelectedAnsver));
                }
                else if (!addSelectedAnsver.Equals(value))
                {
                    value.CountBall = (int)value.CountBall;
                    addSelectedAnsver = value;
                    OnPropertyChanged(nameof(AddSelectedAnsver));
                }

            }
        }
        private Ansver currentAnsver1 = new Ansver();
        public Ansver CurrentAnsver1
        {
            get => currentAnsver1;
            set
            {
                currentAnsver1 = value;
                if (value.Check == 1)
                    SelectCheck1 = true;
                else
                    SelectCheck1 = false;
                OnPropertyChanged(nameof(CurrentAnsver1));

            }
        }
        private Ansver currentAnsver2 = new Ansver();
        public Ansver CurrentAnsver2
        {
            get => currentAnsver2;
            set
            {
                currentAnsver2 = value;
                if (value.Check == 1)
                    SelectCheck2 = true;
                else
                    SelectCheck2 = false;
                OnPropertyChanged(nameof(CurrentAnsver2));


            }
        }
        private Ansver currentAnsver3 = new Ansver();
        public Ansver CurrentAnsver3
        {
            get => currentAnsver3;
            set
            {
                currentAnsver3 = value;
                if (value.Check == 1)
                    SelectCheck3 = true;
                else
                    SelectCheck3 = false;
                OnPropertyChanged(nameof(CurrentAnsver3));

            }
        }
        private Ansver currentAnsver4 = new Ansver();
        public Ansver CurrentAnsver4
        {
            get => currentAnsver4;
            set
            {
                currentAnsver4 = value;
                if (value.Check == 1)
                    SelectCheck4 = true;
                else
                    SelectCheck4 = false;
                OnPropertyChanged(nameof(CurrentAnsver4));

            }
        }
        private Ansver currentAnsver5 = new Ansver();
        public Ansver CurrentAnsver5
        {
            get => currentAnsver5;
            set
            {
                currentAnsver5 = value;
                if (value.Check == 1)
                    SelectCheck5 = true;
                else
                    SelectCheck5 = false;
                OnPropertyChanged(nameof(CurrentAnsver5));
            }
        }

        private History testingHistory = new History();
        public History TestingHistory
        {
            get => testingHistory;
            set
            {
                testingHistory = value;
                OnPropertyChanged(nameof(TestingHistory));
            }
        }
        //DispatcherTimer
        DispatcherTimer Timer = new DispatcherTimer();
        //Commands
        public RelayCommand SaveThemeCommand { get; private set; }
        public RelayCommand SaveQuestionCommand { get; private set; }
        public RelayCommand SaveAnsverCommand { get; private set; }
        public RelayCommand SaveLoadFileCommand { get; private set; }
        public RelayCommand ShowSaveThemeCommand { get; private set; }
        public RelayCommand ShowSaveQuestionCommand { get; private set; }
        public RelayCommand ShowSaveAnsverCommand { get; private set; }
        public RelayCommand ShowStartTestCommand { get; private set; }
        public RelayCommand DeleteQuestionCommand { get; private set; }
        public RelayCommand DeleteThemeCommand { get; private set; }
        public RelayCommand DeleteAnsverCommand { get; private set; }
        public RelayCommand StartTestingCommand { get; private set; }
        public RelayCommand NextQuestionCommand { get; private set; }
        public RelayCommand LastQuestionCommand { get; private set; }
        public RelayCommand OpenFileCommand { get; private set; }
        public RelayCommand OpenFileAudioCommand { get; private set; }
        public RelayCommand OpenFileImageCommand { get; private set; }
        public RelayCommand CheckAnswerCommand { get; private set; }
        public RelayCommand MediaPlayerCommand { get; private set; }
        public RelayCommand OpenFullScreenImageCommand { get; private set; }
        //datatime
        DateTime dateTime = new DateTime();
        //mediaPlayer
        private MediaPlayer mediaPlayer = new MediaPlayer();
        public MediaPlayer MediaPlayer
        {
            get
            {
                return mediaPlayer;
            }
            set
            {
                mediaPlayer = value;
                OnPropertyChanged(nameof(MediaPlayer));
            }
        }
        //bitmap
        private System.Windows.Media.Imaging.BitmapImage selectedBitmap=new System.Windows.Media.Imaging.BitmapImage();
        public System.Windows.Media.Imaging.BitmapImage SelectedBitmap
        {
            set
            {
                selectedBitmap = value;
                OnPropertyChanged(nameof(SelectedBitmap));
            }
            get
            {
                return selectedBitmap;
            }
        }
        //string
        private string nameStudent { get; set; }
        public string NameStudent
        {
            get => nameStudent;
            set
            {
                nameStudent = value;
                OnPropertyChanged(nameof(NameStudent));
            }
        }
        private string ballStudent { get; set; }
        public string BallStudent
        {
            get => ballStudent;
            set
            {
                ballStudent = value;
                OnPropertyChanged(nameof(BallStudent));
            }
        }
        private string timerText { get; set; }
        public string TimerText
        {
            get => timerText;
            set
            {
                timerText = value;
                OnPropertyChanged(nameof(TimerText));
            }
        }
        private string countAnsver { get; set; }
        public string CountAnsver
        {
            get => countAnsver;
            set
            {
                countAnsver = value;
                OnPropertyChanged(nameof(CountAnsver));
            }
        }
        private string documentPath { get; set; }
        public string DocumentPath
        {
            get => documentPath;
            set
            {
                documentPath = value;
                OnPropertyChanged(nameof(DocumentPath));
            }
        }
        private string selectTest { get; set; }
        public string SelectTest
        {
            get => selectTest;
            set
            {
                selectTest = value;
                OnPropertyChanged(nameof(SelectTest));
            }
        }
        //Brush
        private Brush selectbrushes1 { get; set; }
        public Brush SelectBrushes1
        {
            get => selectbrushes1;
            set
            {
                selectbrushes1 = value;
                OnPropertyChanged(nameof(SelectBrushes1));
            }
        }
        private Brush selectbrushes2 { get; set; }
        public Brush SelectBrushes2
        {
            get => selectbrushes2;
            set
            {
                selectbrushes2 = value;
                OnPropertyChanged(nameof(SelectBrushes2));
            }
        }
        private Brush selectbrushes3 { get; set; }
        public Brush SelectBrushes3
        {
            get => selectbrushes3;
            set
            {
                selectbrushes3 = value;
                OnPropertyChanged(nameof(SelectBrushes3));
            }
        }
        private Brush selectbrushes4 { get; set; }
        public Brush SelectBrushes4
        {
            get => selectbrushes4;
            set
            {
                selectbrushes4 = value;
                OnPropertyChanged(nameof(SelectBrushes4));
            }
        }
        private Brush selectbrushes5 { get; set; }
        public Brush SelectBrushes5
        {
            get => selectbrushes5;
            set
            {
                selectbrushes5 = value;
                OnPropertyChanged(nameof(SelectBrushes5));
            }
        }


        //int
        int currentIdTest = 0;
        //bool 
        private bool checkQuestion;
        public bool CheckQuestion
        {
            get
            {
                return checkQuestion;
            }
            set
            {
                checkQuestion = value;
                OnPropertyChanged(nameof(SelectCheck1));
            }
        }
        public bool SelectCheck1
        {
            get
            {
                if (CurrentAnsver1.Check == 1)
                    return true;
                return false;
            }
            set
            {
                if (value == true)
                    CurrentAnsver1.Check = 1;
                else
                    CurrentAnsver1.Check = 0;
                OnPropertyChanged(nameof(SelectCheck1));
            }
        }
        public bool SelectCheck2
        {
            get
            {
                if (CurrentAnsver2.Check == 1)
                    return true;
                return false;
            }
            set
            {
                if (value == true)
                    CurrentAnsver2.Check = 1;
                else
                    CurrentAnsver2.Check = 0;
                OnPropertyChanged(nameof(SelectCheck2));
            }
        }
        public bool SelectCheck3
        {
            get
            {
                if (CurrentAnsver3.Check == 1)
                    return true;
                return false;
            }
            set
            {
                if (value == true)
                    CurrentAnsver3.Check = 1;
                else
                    CurrentAnsver3.Check = 0;
                OnPropertyChanged(nameof(SelectCheck3));
            }
        }
        public bool SelectCheck4
        {
            get
            {
                if (CurrentAnsver4.Check == 1)
                    return true;
                return false;
            }
            set
            {
                if (value == true)
                    CurrentAnsver4.Check = 1;
                else
                    CurrentAnsver4.Check = 0;
                OnPropertyChanged(nameof(SelectCheck4));
            }
        }
        public bool SelectCheck5
        {
            get
            {
                if (CurrentAnsver5.Check == 1)
                    return true;
                return false;
            }
            set
            {
                if (value == true)
                    CurrentAnsver5.Check = 1;
                else
                    CurrentAnsver5.Check = 0;
                OnPropertyChanged(nameof(SelectCheck5));
            }
        }
        public DataSource()
        {
             
            hvm.LoadHistoryes();
            tvm.LoadThemes();
            ShowSaveThemeCommand = new RelayCommand(ShowSaveThemeCom, CanShowSaveThemeCom);
            ShowSaveQuestionCommand = new RelayCommand(ShowSaveQuestionCom, CanShowSaveQuestionCom);
            ShowSaveAnsverCommand = new RelayCommand(ShowSaveAnsverCom, CanShowSaveAnsverCom);
            ShowStartTestCommand = new RelayCommand(ShowStartTestCom, CanShowStartTestCom);
            SaveThemeCommand = new RelayCommand(SaveThemeCom, CanSaveThemeCom);
            SaveLoadFileCommand = new RelayCommand(SaveLoadFileCom, CanSaveLoadFileCom);
            SaveQuestionCommand = new RelayCommand(SaveQuestionCom, CanSaveQuestionCom);
            SaveAnsverCommand = new RelayCommand(SaveAnsverCom, CanSaveAnsverCom);
            DeleteThemeCommand = new RelayCommand(DeleteThemeCom, CanDeleteThemeCom);
            DeleteQuestionCommand = new RelayCommand(DeleteQuestionCom, CanDeleteQuestionCom);
            DeleteAnsverCommand = new RelayCommand(DeleteAnsverCom, CanDeleteAnsverCom);
            NextQuestionCommand = new RelayCommand(NextQuestionCom, CanNextQuestionCom);
            LastQuestionCommand = new RelayCommand(LastQuestionCom, CanLastQuestionCom);
            OpenFileCommand = new RelayCommand(OpenFileCom, CanOpenFileCom);
            OpenFileImageCommand = new RelayCommand(OpenFileImageCom, CanOpenFileImageCom);
            OpenFileAudioCommand = new RelayCommand(OpenFileAudioCom, CanOpenFileAudioCom);
            CheckAnswerCommand = new RelayCommand(CheckAnswerCom, CanCheckAnswerCom);
            MediaPlayerCommand = new RelayCommand(MediaPlayerCom, CanMediaPlayerCom);
            OpenFullScreenImageCommand = new RelayCommand(OpenFullScreenImageCom, CanOpenFullScreenImageCom);
            SelectBrushes1 = SelectBrushes2 = SelectBrushes3 = SelectBrushes4 = SelectBrushes5 = Brushes.Black;
            Timer.Interval = TimeSpan.FromSeconds(1);
            Timer.Tick += timer_Tick;
             
        }

        private void ShowSaveThemeCom(object parameter)
        {
            AddSelectedTheme = new Theme();
            AddAndEditThemeWindow win = new AddAndEditThemeWindow();
            var name = (string)parameter;
            if (name == "Update")
                AddSelectedTheme = SelectedTheme;
            win.DataContext = this;
            if (name == "Save")
                win.bSave.Content = "Save";
            else
            {
                win.NUDTheme.Value = (decimal)AddSelectedTheme.Procent;
                win.bSave.Content = "Update";
            }
            win.ShowDialog();
            //SelectedTheme = AddSelectedTheme;
        }
        private bool CanShowSaveThemeCom(object parameter)
        {
            var name = (string)parameter;
            if (name == "Save")
                return true;
            if (SelectedTheme != null)
                return true;
            return false;
        }
        private void ShowSaveQuestionCom(object parameter)
        {
            addselectedQuestion = new Question();
            AddAndEditQuestionWindow win = new AddAndEditQuestionWindow();
            var name = (string)parameter;

            if (name == "Update")
            {
                AddSelectedQuestion = SelectedQuestion;
                if (AddSelectedQuestion.PhotoPath != null && AddSelectedQuestion.PhotoPath != "")
                {
                    SelectedBitmap = new System.Windows.Media.Imaging.BitmapImage();
                    SelectedBitmap.BeginInit();
                    SelectedBitmap.UriSource = new Uri(AddSelectedQuestion.PhotoPath, UriKind.RelativeOrAbsolute);
                    SelectedBitmap.EndInit();
                }
            }
            win.DataContext = this;
            if (name == "Save")
                win.bSave.Content = "Save";
            else
                win.bSave.Content = "Update";
            win.ShowDialog();
        }
        private bool CanShowSaveQuestionCom(object parameter)
        {
            var name = (string)parameter;

            if (SelectedQuestion != null||(name=="Save"&&SelectedTheme!=null))
                return true;
            return false;
        }
        private void ShowSaveAnsverCom(object parameter)
        {
            AddSelectedAnsver = new Ansver();
            AddAndEditAnsverWindow win = new AddAndEditAnsverWindow();
            var name = (string)parameter;
            if (name == "Update")
                AddSelectedAnsver = SelectedAnsver;
            win.DataContext = this;
            if (name == "Save")
                win.bSave.Content = "Save";
            else
            {
                win.bSave.Content = "Update";
                if (SelectedAnsver.CorrectAnsver == 1)
                {
                    win.rbCorrect.IsChecked = true;
                    win.rbWrong.IsChecked = false;
                }
                else
                {
                    win.rbWrong.IsChecked = true;
                    win.rbCorrect.IsChecked = false;
                }
                win.NUDAnsver.Value = AddSelectedAnsver.CountBall;
            }
            if (win.ShowDialog() == false)
            {
                SelectedAnsver = AddSelectedAnsver;
                 
            }
        }
        private bool CanShowSaveAnsverCom(object parameter)
        {
            var name = (string)parameter;
            if (SelectedAnsver != null || (name == "Save" && SelectedQuestion != null))
                return true;
            return false;
        }
        private void ShowStartTestCom(object parameter)
        {
            int min = 0;
            int max = 0;
            TestingWindow win = new TestingWindow();
            var values = (object[])parameter;
            bool FullQuestion = (bool)(values[0]);
            bool First = (bool)(values[1]);
            bool FromTo = (bool)(values[2]);
            string From = (values[3] as string).Trim(' ');
            string To = (values[4] as string).Trim(' ');
            bool Random = (bool)(values[5]);
            bool AllowTestFix = (bool)(values[6]);
            bool ShowTrueAnsver = (bool)(values[7]);
            bool ShowCountTrueAnsver = (bool)(values[8]);
            bool RNoTime = (bool)(values[9]);
            bool RTime = (bool)(values[10]);
            decimal TimeMinets = (decimal)values[11];
            string FirstCount = (values[12] as string).Trim(' ');
            if (FromTo)
            {
                min = int.Parse(From);
                max = int.Parse(To);
            }
            else
            {
                min = 0;
            }
            if (FullQuestion)
            {
                LoadTests(Random);
            }
            if (First)
            {
                max = int.Parse(FirstCount);
                LoadTests(max, Random);
            }
            if(FromTo)
                LoadTests(min, max, Random);
            win.DataContext = this;
            win.BLast.IsEnabled = AllowTestFix;
            win.LShowTimer.IsEnabled = RTime;
            if (RTime)
            {
                Timer.Start();
                dateTime = DateTime.Now;
                dateTime=dateTime.AddMinutes((double)TimeMinets);
            }
            else 
            {
                TimerText = "";
            }
            win.LCount.IsEnabled = ShowCountTrueAnsver;
            win.LShowCountAnswer.IsEnabled = ShowCountTrueAnsver;
            win.BCheck.IsEnabled = ShowTrueAnsver;
            if (win.ShowDialog() == false)
            {
                CalcBall();
                ResultWindow resWin = new ResultWindow();
                resWin.DataContext = win.DataContext;
                if ((BallStudent==null||(int.Parse(BallStudent) == 0)) || (int)System.Math.Round(double.Parse(BallStudent)) < TestingTheme.Procent)
                {
                    TestingHistory.Passet = "NOT PASSED";
                    resWin.LHeader.Content = "NOT PASSED";
                    resWin.LHeader.Foreground = Brushes.Red;
                    resWin.LText.Content = TestingTheme.FalseText;
                }
                else
                {
                    TestingHistory.Passet = "PASSED";

                    resWin.LHeader.Content = "PASSED";
                    resWin.LHeader.Foreground = Brushes.Green;
                    resWin.LText.Content = TestingTheme.TrueText;
                }
                TestingHistory.CountProcent = BallStudent;
                TestingHistory.DateTime = DateTime.Now;
                TestingHistory.ThemeName = TestingTheme.Name;
                TestingHistory.Name = NameStudent;
                if (resWin.ShowDialog() == false)
                {
                    if (RTime)
                    {
                        Timer.Stop();
                    }
                    hvm.AddHistoryes(TestingHistory);
                } 
            }
            AnswerTesting.ForEach(a=>a.Check=0);
        }
        private bool CanShowStartTestCom(object parameter)
        {
            if (TestingTheme == null)
                return false;
            if ((TestingTheme.Id != 0) && (NameStudent != null) && (NameStudent.Length > 2))
                return true;
            return false;
        }
        private void DeleteQuestionCom(object parameter)
        {
            var buf = MessageBox.Show($"Подтверждаете удаление вопроса?\n{SelectedQuestion.Name}", "Удаление вопроса", MessageBoxButton.YesNo, MessageBoxImage.Information);
            qvm.RemoveQuestion(SelectedQuestion);
            qvm.LoadQuestions(SelectedTheme);
            avm.LoadAnsvers(SelectedQuestion);

        }
        private bool CanDeleteQuestionCom(object parameter)
        {
            if (SelectedQuestion != null)
                return true;
            return false;
        }
        private void DeleteAnsverCom(object parameter)
        {
            var buf = MessageBox.Show($"Подтверждаете удаление варианта ответа?\n{SelectedQuestion.Name}", "Удаление варианта ответа", MessageBoxButton.YesNo, MessageBoxImage.Information);
            //qvm.RemoveAnsverToQuestion(SelectedAnsver);
            if (buf == System.Windows.MessageBoxResult.Yes)
            {
                avm.RemoveAnsver(SelectedAnsver);
                avm.LoadAnsvers(SelectedQuestion);
            }
        }
        private bool CanDeleteAnsverCom(object parameter)
        {
            if (SelectedAnsver != null)
                return true;
            return false;
        }
        private void DeleteThemeCom(object parameter)
        {
            var buf = MessageBox.Show($"Подтверждаете удаление темы?\n{SelectedTheme.Name}", "Удаление темы", MessageBoxButton.YesNo, MessageBoxImage.Information);
            if (buf == MessageBoxResult.Yes)
            {
                tvm.RemoveTheme(SelectedTheme);
                qvm.LoadQuestions(SelectedTheme);
                avm.LoadAnsvers(SelectedQuestion);
            }

        }
        private bool CanDeleteThemeCom(object parameter)
        {
            if (SelectedTheme != null)
                return true;
            return false;
        }
        private void SaveThemeCom(object parameter)
        {
            var values = (object[])parameter;
            string name = (string)(values[0]);
            decimal count = (decimal)(values[1]);
            if (name == "Save")
            {
                Theme t = new Theme
                {
                    Name = AddSelectedTheme.Name,
                    FalseText = AddSelectedTheme.FalseText,
                    Procent = (int)count,
                    TrueText = AddSelectedTheme.TrueText
                };
                AddSelectedTheme.Procent = (int)count;
                tvm.AddTheme(t);
            }
            else
            {
                AddSelectedTheme.Procent = (int)count;
                tvm.EditTheme(AddSelectedTheme);
            }
            
            tvm.LoadThemes();
            qvm.LoadQuestions(SelectedTheme);
            avm.LoadAnsvers(SelectedQuestion);
        }
        private bool CanSaveThemeCom(object parameter)
        {
            return true;
        }
        private void SaveLoadFileCom(object parameter)
        {
            var values = (object[])parameter;
            string FullPath = (values[0] as string).Trim(' ');
            string sep1 = (values[1] as string).Trim(' ');
            string sep2 = (values[2] as string).Trim(' ');
            string sep3 = (values[3] as string).Trim(' ');
            string themeName = (values[4] as string).Trim(' ');
            string textTrue = (values[5] as string).Trim(' ');
            string textFalse = (values[6] as string).Trim(' ');
            string procent = (values[7] as string).Trim(' ');
            FullPath = DocumentPath;
            string bufText;

            {
                System.Windows.Forms.RichTextBox richTextBox = new System.Windows.Forms.RichTextBox();
                richTextBox.LoadFile(FullPath);
                bufText = richTextBox.Text;
            };
             


            Theme t = new Theme
            {
                Name = themeName,
                FalseText = textFalse,
                Procent = int.Parse(procent),
                TrueText = textTrue
            };
            tvm.AddTheme(t);

            LoadFromFile(t, bufText.Split(sep1[0]), sep2[0], sep3[0]);



        }
        private bool CanSaveLoadFileCom(object parameter)
        {
            if (DocumentPath!=null)
                return true;
            return false;
        }
        private void SaveQuestionCom(object parameter)
        {
            var name = (string)parameter;
            if (name == "Save")
            {
                qvm.AddQuestion(AddSelectedQuestion, SelectedTheme);
            }
            else
            {
                qvm.EditQuestion(AddSelectedQuestion);
            }
            if (SelectedTheme != null)
                qvm.LoadQuestions(SelectedTheme);
        }
        private bool CanSaveQuestionCom(object parameter)
        {
            return true;
        }
        private void SaveAnsverCom(object parameter)
        {
            var values = (object[])parameter;
            string name = (values[0] as string).Trim(' ');
            bool cor = (bool)(values[1]);
            bool uncor = (bool)(values[2]);
            Ansver buf = new Ansver()
            {
                Name = AddSelectedAnsver.Name,
                CountBall = AddSelectedAnsver.CountBall,
                Question = SelectedQuestion,
                Id=AddSelectedAnsver.Id
            };
            if (cor ==true)
            {
                buf.CorrectAnsver = 1;
                AddSelectedAnsver.CorrectAnsver = 1;
            }
            else
            {
                buf.CorrectAnsver = 0;
                AddSelectedAnsver.CorrectAnsver = 0;
            }
            if (name == "Save") 
            {
                avm.LoadAnsvers(SelectedQuestion);
                avm.AddAnsver(SelectedTheme, SelectedQuestion, buf);
            }
            else
            {
                avm.EditAnsver(AddSelectedAnsver);
            }
            if (SelectedQuestion != null)
                avm.LoadAnsvers(SelectedQuestion);
        }
        private bool CanSaveAnsverCom(object parameter)
        {
            return true;
        }
       
        private void CheckAnswerCom(object parameter)
        {
            CurrentQuestion.Check = 1;
            if (SelectCheck1 || CurrentAnsver1.CorrectAnsver == 1)
            {
                if (CurrentAnsver1.CorrectAnsver == 1)
                {
                    SelectBrushes1 = Brushes.LimeGreen;
                }
                else
                    SelectBrushes1 = Brushes.Red;
            }
            if (SelectCheck2 || CurrentAnsver2.CorrectAnsver == 1)
            {
                if (CurrentAnsver2.CorrectAnsver == 1)
                {
                    SelectBrushes2 = Brushes.LimeGreen;
                }
                else
                    SelectBrushes2 = Brushes.Red;
            }
            if (SelectCheck3 || CurrentAnsver3.CorrectAnsver == 1)
            {
                if (CurrentAnsver3.CorrectAnsver == 1)
                {
                    SelectBrushes3 = Brushes.LimeGreen;
                }
                else
                    SelectBrushes3 = Brushes.Red;
            }
            if (SelectCheck4 || CurrentAnsver4.CorrectAnsver == 1)
            {
                if (CurrentAnsver4.CorrectAnsver == 1)
                {
                    SelectBrushes4 = Brushes.LimeGreen;
                }
                else
                    SelectBrushes4 = Brushes.Red;
            }
            if (SelectCheck5 || CurrentAnsver5.CorrectAnsver == 1)
            {
                if (CurrentAnsver5.CorrectAnsver == 1)
                {
                    SelectBrushes5 = Brushes.LimeGreen;
                }
                else
                    SelectBrushes5 = Brushes.Red;
            }


        }
        private bool CanCheckAnswerCom(object parameter)
        {
            return true;
        }
        private void NextQuestionCom(object parameter)
        {
            SelectBrushes1 = SelectBrushes2 = SelectBrushes3 = SelectBrushes4 = SelectBrushes5 = Brushes.Black;
            currentIdTest++;
            if (currentIdTest == questionTesting.Count())
                currentIdTest--;
            CurrentQuestion.Check = 1;
            SelectTest = $"{currentIdTest + 1} of {questionTesting.Count()}";
            CurrentQuestion = QuestionTesting[currentIdTest];
            if (CurrentQuestion.PhotoPath != null)
            {
                SelectedBitmap = new System.Windows.Media.Imaging.BitmapImage();
                SelectedBitmap.BeginInit();
                SelectedBitmap.UriSource = new Uri(CurrentQuestion.PhotoPath, UriKind.RelativeOrAbsolute);
                SelectedBitmap.EndInit();
            }
            var buf = AnswerTesting.Where(a => a.Question.Id == CurrentQuestion.Id).ToList();
            for (int i = 0; i < buf.Count(); i++)
            {
                if (i == 0)
                {
                    CurrentAnsver1 = buf[i];
                }
                if (i == 1)
                {
                    CurrentAnsver2 = buf[i];
                }
                if (i == 2)
                {
                    CurrentAnsver3 = buf[i];
                }
                if (i == 3)
                {
                    CurrentAnsver4 = buf[i];
                }
                if (i == 4)
                {
                    CurrentAnsver5 = buf[i];
                }
            }
            CalcCountAnswer();
        }
        private bool CanNextQuestionCom(object parameter)
        {
            if (currentIdTest != questionTesting.Count()-1)
                return true;
            return false;
        }
        private void LastQuestionCom(object parameter)
        {
            SelectBrushes1 = SelectBrushes2 = SelectBrushes3 = SelectBrushes4 = SelectBrushes5 = Brushes.Black;
            currentIdTest--;
            if (currentIdTest < 0)
                currentIdTest = 0;
            SelectTest = $"{currentIdTest + 1} of {questionTesting.Count()}";
            CurrentQuestion = QuestionTesting[currentIdTest];
            if (CurrentQuestion.PhotoPath != null)
            {
                SelectedBitmap = new System.Windows.Media.Imaging.BitmapImage();
                SelectedBitmap.BeginInit();
                SelectedBitmap.UriSource = new Uri(CurrentQuestion.PhotoPath, UriKind.RelativeOrAbsolute);
                SelectedBitmap.EndInit();
            }
            var buf = AnswerTesting.Where(a => a.Question.Id == CurrentQuestion.Id).ToList();
            for (int i = 0; i < buf.Count(); i++)
            {
                if (i == 0)
                    CurrentAnsver1 = buf[i];
                if (i == 1)
                    CurrentAnsver2 = buf[i];
                if (i == 2)
                    CurrentAnsver3 = buf[i];
                if (i == 3)
                    CurrentAnsver4 = buf[i];
                if (i == 4)
                    CurrentAnsver5 = buf[i];
            }
            CalcCountAnswer();
        }
        private bool CanLastQuestionCom(object parameter)
        {
            if (currentIdTest!=0)
                return true;
            return false;
        }

        private void OpenFileCom(object parameter)
        {
            System.Windows.Forms.OpenFileDialog ofd = new System.Windows.Forms.OpenFileDialog();
            ofd.Filter = "text files (*.rtf)|*.rtf";
            ofd.FilterIndex = 1;
            ofd.RestoreDirectory = true;
            ofd.Multiselect = false;
            DocumentPath = "";
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                DocumentPath = ofd.FileName;
                if (!File.Exists("../../DocumentTests/" + ofd.SafeFileName))
                    File.Copy(DocumentPath, "../../DocumentTests/" + ofd.SafeFileName);
                ofd.Dispose();
            }
        }
        private bool CanOpenFileCom(object parameter)
        {
            return true;
        }
        private void OpenFileImageCom(object parameter)
        {
            System.Windows.Forms.OpenFileDialog ofd = new System.Windows.Forms.OpenFileDialog();
            ofd.Filter = "images files (*.jpg)|*.jpg| (*.png)|*.png";
            ofd.FilterIndex = 1;
            ofd.RestoreDirectory = true;
            ofd.Multiselect = false;
           
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                AddSelectedQuestion.PhotoPath = ofd.FileName;
                SelectedBitmap = new System.Windows.Media.Imaging.BitmapImage();
                SelectedBitmap.BeginInit();
                SelectedBitmap.UriSource = new Uri(AddSelectedQuestion.PhotoPath, UriKind.RelativeOrAbsolute);
                SelectedBitmap.EndInit();
                if (!File.Exists("../../ImagesTest/" + ofd.SafeFileName))
                    File.Copy(ofd.FileName, "../../ImagesTest/" + ofd.SafeFileName);
                ofd.Dispose();
            }
        }
        private bool CanOpenFileImageCom(object parameter)
        {
            return true;
        }
        private void OpenFileAudioCom(object parameter)
        {
            System.Windows.Forms.OpenFileDialog ofd = new System.Windows.Forms.OpenFileDialog();
            ofd.Filter = "audio files (*.mp3)|*.mp3";
            ofd.FilterIndex = 1;
            ofd.RestoreDirectory = true;
            ofd.Multiselect = false;
            DocumentPath = "";
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                DocumentPath=AddSelectedQuestion.AudioPath = "../../AudioTest/" + ofd.SafeFileName;
                if (!File.Exists(AddSelectedQuestion.AudioPath))
                    File.Copy(ofd.FileName, AddSelectedQuestion.AudioPath);
                ofd.Dispose();
                mediaPlayer.Open(new Uri(AddSelectedQuestion.AudioPath, UriKind.Relative));
            }
        }
        private bool CanOpenFileAudioCom(object parameter)
        {
            return true;
        }

        private void MediaPlayerCom(object parameter)
        {
            var name = (string)parameter;
            switch (name)
            {
                case "Play":
                    if (!MediaPlayer.HasAudio)
                        MediaPlayer.Open(new Uri(AddSelectedQuestion.AudioPath, UriKind.Relative));
                    MediaPlayer.Play();
                    break;
                case "Pause":
                    MediaPlayer.Pause();
                    break;
                case "Stop":
                    MediaPlayer.Stop();
                    break;
                case "BPlay":
                    if (!MediaPlayer.HasAudio)
                        MediaPlayer.Open(new Uri(CurrentQuestion.AudioPath, UriKind.Relative));
                    MediaPlayer.Play();
                    break;
                case "BPause":
                    MediaPlayer.Pause();
                    break;
                case "BStop":
                    MediaPlayer.Stop();
                    break;
                default:
                    break;
            }
            
        }
        private bool CanMediaPlayerCom(object parameter)
        {
            var name = (string)parameter;
            switch (name)
            {
                case "BPlay":
                    if (CurrentQuestion.AudioPath != null && CurrentQuestion.AudioPath != "")
                        return true;
                    break;
                case "BPause":
                    if (CurrentQuestion.AudioPath != null && CurrentQuestion.AudioPath != "")
                        return true;
                    break;
                case "BStop":
                    if (CurrentQuestion.AudioPath != null && CurrentQuestion.AudioPath != "")
                        return true;
                    break;
                case "Play":
                    if (AddSelectedQuestion.AudioPath != null && AddSelectedQuestion.AudioPath != "")
                        return true;
                    break;
                case "Pause":
                    if (AddSelectedQuestion.AudioPath != null && AddSelectedQuestion.AudioPath != "")
                        return true;
                    break;
                case "Stop":
                    if (AddSelectedQuestion.AudioPath != null && AddSelectedQuestion.AudioPath != "")
                        return true;
                    break;
                default:
                    break;
            }
            return false;
        }

        private void OpenFullScreenImageCom(object parameter)
        {
            FullScreenImage fullScreenImage = new FullScreenImage();
            fullScreenImage.DataContext = this;
            fullScreenImage.ShowDialog();
        }
        private bool CanOpenFullScreenImageCom(object parameter)
        {
            return true;
        }
        //Metods
        private void CalcBall()
        {

            double maxBall = AnswerTesting.Where(a => a.CorrectAnsver == 1).ToList().Sum(a => a.CountBall);
            double studBall = AnswerTesting.Where(a => a.CorrectAnsver == 1).Where(b => b.Check == 1).ToList().Sum(a => a.CountBall);
            double n = (studBall * 100) / maxBall;
            BallStudent = System.Math.Round(n).ToString();

        }
        private void LoadTests(int min, int max, bool random)
        {
            SelectCheck1 = SelectCheck2 = SelectCheck3 = SelectCheck4 = SelectCheck5 = false;
            Random rand = new Random();
            QuestionTesting.Clear();
            AnswerTesting.Clear();
                qvm.LoadQuestions(TestingTheme, min, max);

            int o = 0;
            foreach (var item in qvm.Questions)
            {
                avm.LoadAnsvers(item);
                QuestionTesting.Add(item);
                var buf = avm.Ansvers;
                List<int> inRand = new List<int>();
                bool check = true;
                for (int i = 0; check; i++)
                {
                    int j = rand.Next(0, buf.Count());
                    if (!inRand.Contains(j))
                    {
                        inRand.Add(j);
                    }
                    if (inRand.Count() == buf.Count())
                    {
                        check = false;
                    }
                }
                for (int i = 0; i < buf.Count(); i++)
                {
                    AnswerTesting.Add(buf[inRand[i]]);
                }
                o++;
            }
            if(random)
                Shuffle(QuestionTesting);
            SelectTest = $"{currentIdTest + 1} of {questionTesting.Count()}";
            CurrentQuestion = QuestionTesting[0];
            SelectedBitmap = new System.Windows.Media.Imaging.BitmapImage();
            SelectedBitmap.BeginInit();
            SelectedBitmap.UriSource = new Uri(CurrentQuestion.PhotoPath, UriKind.RelativeOrAbsolute);
            SelectedBitmap.EndInit();
            for (int i = 0; i < AnswerTesting.Count(); i++)

            {
                if (i == 0)
                    CurrentAnsver1 = AnswerTesting[i];
                if (i == 1)
                    CurrentAnsver2 = AnswerTesting[i];
                if (i == 2)
                    CurrentAnsver3 = AnswerTesting[i];
                if (i == 3)
                    CurrentAnsver4 = AnswerTesting[i];
                if (i == 4)
                    CurrentAnsver5 = AnswerTesting[i];
            }
            CalcCountAnswer();
        }
        private void LoadTests(int value,bool random)
        {
            SelectCheck1 = SelectCheck2 = SelectCheck3 = SelectCheck4 = SelectCheck5 = false;
            Random rand = new Random();
            QuestionTesting.Clear();
            AnswerTesting.Clear();
            qvm.LoadQuestions(TestingTheme);
            var bufQuest = qvm.Questions.ToList();
            Shuffle(bufQuest);
                int o = 0;
                foreach (var item in bufQuest)
                {
                    if (value > o)
                    {
                        avm.LoadAnsvers(item);
                        QuestionTesting.Add(item);
                        var buf = avm.Ansvers;
                        List<int> inRand = new List<int>();
                        bool check = true;
                        for (int i = 0; check; i++)
                        {
                            int j = rand.Next(0, buf.Count());
                            if (!inRand.Contains(j))
                            {
                                inRand.Add(j);
                            }
                            if (inRand.Count() == buf.Count())
                            {
                                check = false;
                            }
                        }
                        for (int i = 0; i < buf.Count(); i++)
                        {
                            AnswerTesting.Add(buf[inRand[i]]);
                        }
                    }
                    o++;
                }
                if (random)
                    Shuffle(QuestionTesting);
                SelectTest = $"{currentIdTest + 1} of {questionTesting.Count()}";
                CurrentQuestion = QuestionTesting[0];
            SelectedBitmap = new System.Windows.Media.Imaging.BitmapImage();
            SelectedBitmap.BeginInit();
            SelectedBitmap.UriSource = new Uri(CurrentQuestion.PhotoPath, UriKind.RelativeOrAbsolute);
            SelectedBitmap.EndInit();
            for (int i = 0; i < AnswerTesting.Count(); i++)

                {
                    if (i == 0)
                        CurrentAnsver1 = AnswerTesting[i];
                    if (i == 1)
                        CurrentAnsver2 = AnswerTesting[i];
                    if (i == 2)
                        CurrentAnsver3 = AnswerTesting[i];
                    if (i == 3)
                        CurrentAnsver4 = AnswerTesting[i];
                    if (i == 4)
                        CurrentAnsver5 = AnswerTesting[i];
                }
            CalcCountAnswer();
        }
        private void LoadTests(bool random)
        {
            SelectCheck1 = SelectCheck2 = SelectCheck3 = SelectCheck4 = SelectCheck5 = false;
            Random rand = new Random();
            QuestionTesting.Clear();
            AnswerTesting.Clear();
            qvm.LoadQuestions(TestingTheme);
            var bufQuest = qvm.Questions.ToList();
            Shuffle(bufQuest);
            int o = 0;
            foreach (var item in bufQuest)
            { 
                    avm.LoadAnsvers(item);
                    QuestionTesting.Add(item);
                    var buf = avm.Ansvers;
                    List<int> inRand = new List<int>();
                    bool check = true;
                    for (int i = 0; check; i++)
                    {
                        int j = rand.Next(0, buf.Count());
                        if (!inRand.Contains(j))
                        {
                            inRand.Add(j);
                        }
                        if (inRand.Count() == buf.Count())
                        {
                            check = false;
                        }
                    }
                    for (int i = 0; i < buf.Count(); i++)
                    {
                        AnswerTesting.Add(buf[inRand[i]]);
                    }
                
                o++;
            }
            if (random)
                Shuffle(QuestionTesting);
            SelectTest = $"{currentIdTest + 1} of {questionTesting.Count()}";
            CurrentQuestion = QuestionTesting[0];
            if (CurrentQuestion.PhotoPath != null)
            {
                SelectedBitmap = new System.Windows.Media.Imaging.BitmapImage();
                SelectedBitmap.BeginInit();
                SelectedBitmap.UriSource = new Uri(CurrentQuestion.PhotoPath, UriKind.RelativeOrAbsolute);
                SelectedBitmap.EndInit();
            }
            for (int i = 0; i < AnswerTesting.Count(); i++)
            {
                if (i == 0)
                    CurrentAnsver1 = AnswerTesting[i];
                if (i == 1)
                    CurrentAnsver2 = AnswerTesting[i];
                if (i == 2)
                    CurrentAnsver3 = AnswerTesting[i];
                if (i == 3)
                    CurrentAnsver4 = AnswerTesting[i];
                if (i == 4)
                    CurrentAnsver5 = AnswerTesting[i];
            }
            CalcCountAnswer();
        }
        private void LoadFromFile(Theme theme, string[] text, char sep1, char sep2)
        {
            tvm.LoadThemes();

            Theme bufT = tvm.Themes.Where(a => a.Name == theme.Name).FirstOrDefault();
            string t = "";
            int j = 0;
            bool check = true;
            foreach (var item in text)
            {
                j++;
                t = item;
                var tx = t.Split(sep1);
                if (t != "")
                {
                    Question bufQ = new Question
                    {
                        Name = tx[0],
                        CountTrue = 0,
                        CountFalse = 0,
                        PhotoPath = "",
                        Response = 0,
                        CountTrueAnsverToQuestion = 1,
                        Check = 0,
                        AudioPath = "",
                        Theme = bufT
                    };
                    if (bufQ.Name != ""&& bufQ.Name!="\n")
                    {
                        qvm.AddQuestion(bufQ, bufT);  
                        Thread.Sleep(20);
                        qvm.LoadQuestions(bufT);
                        Question question = qvm.Questions.Where(q => q.Name == bufQ.Name).FirstOrDefault();
                        var textan = tx[1].Split(sep2);
                        check = true;
                        foreach (var i in textan)
                        {
                            if (i != "\n")
                            {
                                int n = 0;
                                if (check == true)
                                {
                                    n = 1;
                                }
                                check = false;
                                Ansver bufA = new Ansver
                                {
                                    CorrectAnsver = n,
                                    Name = i,
                                    Check = 0,
                                    CountBall = 1,
                                    Question = question
                                };
                                avm.AddAnsver(bufT, question, bufA);
                                Thread.Sleep(20);
                            }
                        }
                    }
                }

            }
            Thread.Sleep(1000);
            tvm.LoadThemes();
            qvm.LoadQuestions(SelectedTheme);
            avm.LoadAnsvers(SelectedQuestion);

        }
        
        public static void Shuffle<T>(List<T> list)
        {
            Random rand = new Random();

            for (int i = list.Count - 1; i >= 1; i--)
            {
                int j = rand.Next(i + 1);

                T tmp = list[j];
                list[j] = list[i];
                list[i] = tmp;
            }
        }
        void timer_Tick(object sender, EventArgs e)
        {
            TimeSpan timeSpan = new TimeSpan(10000000);
            TimerText = (dateTime - DateTime.Now).Minutes.ToString()+":"+ (dateTime - DateTime.Now).Seconds.ToString();
        }
        void CalcCountAnswer()
        {
          CountAnsver= AnswerTesting.Where(t => t.Question.Id == CurrentQuestion.Id).Where(a => a.CorrectAnsver == 1).Count().ToString();
             
        }

    }
}
