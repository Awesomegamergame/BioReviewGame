using System;
using System.IO;
using System.Windows;
using System.Timers;
using Microsoft.Win32;

namespace BioReviewGame
{
    public partial class MainWindow : Window
    {
        public static MainWindow GameWindow;
        public static int QuestionNumber;
        public static int size;
        public static int score;
        public bool tryagain = false;
        public static Timer timer = new Timer();
        public static System.Threading.Thread thread = new System.Threading.Thread(GameTimer.StartTimer);
        public MainWindow()
        {
            InitializeComponent();
            GameWindow = this;
        }
        #region Quiz Buttons
        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            if (Button1.Tag.Equals("correct"))
            {
                if (QuestionNumber < size)
                {
                    if (tryagain)
                        tryagain = false;
                    else
                        score++;
                    QuestionNumber = Game.Start(QuestionNumber);
                    MessageBox.Show("Correct!");
                }
                else
                {
                    if (tryagain)
                        tryagain = false;
                    else
                        score++;
                    Game.EndGame(false);
                }
            }
            else 
            {
                tryagain = true;
                MessageBox.Show("Wrong answer!");
            }
        }
        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            if (Button2.Tag.Equals("correct"))
            {
                if (QuestionNumber < size)
                {
                    if (tryagain)
                        tryagain = false;
                    else
                        score++;
                    QuestionNumber = Game.Start(QuestionNumber);
                    MessageBox.Show("Correct!");
                }
                else
                {
                    if (tryagain)
                        tryagain = false;
                    else
                        score++;
                    Game.EndGame(false);
                }
            }
            else
            {
                tryagain = true;
                MessageBox.Show("Wrong answer!");
            }
        }
        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            if (Button3.Tag.Equals("correct"))
            {
                if (QuestionNumber < size)
                {
                    if (tryagain)
                        tryagain = false;
                    else
                        score++;
                    QuestionNumber = Game.Start(QuestionNumber);
                    MessageBox.Show("Correct!");
                }
                else
                {
                    if (tryagain)
                        tryagain = false;
                    else
                        score++;
                    Game.EndGame(false);
                }
            }
            else
            {
                tryagain = true;
                MessageBox.Show("Wrong answer!");
            }
        }
        private void Button4_Click(object sender, RoutedEventArgs e)
        {
            if (Button4.Tag.Equals("correct"))
            {
                if (QuestionNumber < size)
                {
                    if (tryagain)
                        tryagain = false;
                    else
                        score++;
                    QuestionNumber = Game.Start(QuestionNumber);
                    MessageBox.Show("Correct!");
                }
                else
                {
                    if (tryagain)
                        tryagain = false;
                    else
                        score++;
                    Game.EndGame(false);
                }
            }
            else
            {
                tryagain = true;
                MessageBox.Show("Wrong answer!");
            }
        }
        #endregion
        private void Embed_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                size = Json.JsonReaderEmbed();
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show($"A Dll is missing. Please make sure you have the correct files in the correct folder.\n\nError Code: {ex}");
                Application.Current.Shutdown();
            }
        }
        private void Select_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Title = "Choose Questions .json File",
                Filter = "Json Files|*.json;*.JSON;"
            };
            bool? result = openFileDialog.ShowDialog();
            if(result == true)
            {
                try
                {
                    size = Json.JsonReader(openFileDialog.FileName);
                }
                catch (FileNotFoundException ex)
                {
                    MessageBox.Show($"A Dll File is missing. Please make sure you have the correct files in the correct folder.\n\nError Code: {ex}");
                    Application.Current.Shutdown();
                }
            }
        }
        private void Start_Click(object sender, RoutedEventArgs e)
        {
            try { timer.Interval = Json.time; }
            catch (ArgumentException) { MessageBox.Show("Time can't be zero"); return; }
            timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            timer.Enabled = true;
            thread.Start();
            BackgroundP.Visibility = Visibility.Collapsed;
            Embed.Visibility = Visibility.Collapsed;
            Start.Visibility = Visibility.Collapsed;
            Select.Visibility = Visibility.Collapsed;
            GameTitle.Visibility = Visibility.Collapsed;
            QuestionNumber = Game.Start(0);
        }
        public void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            Game.EndGame(true);
        }
    }
}
