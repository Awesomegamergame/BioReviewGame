using System.IO;
using System.Windows;
using Microsoft.Win32;

namespace BioReviewGame
{
    public partial class MainWindow : Window
    {
        public static MainWindow GameWindow;
        public static int QuestionNumber;
        public int size;
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
                    QuestionNumber = Game.Start(QuestionNumber);
                    MessageBox.Show("Correct!");
                }
                else
                {
                    MessageBox.Show("Correct! You have finished the game!");
                    Application.Current.Shutdown();
                }
            }
            else
                MessageBox.Show("Wrong answer!");
        }
        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            if (Button2.Tag.Equals("correct"))
            {
                if (QuestionNumber < size)
                {
                    QuestionNumber = Game.Start(QuestionNumber);
                    MessageBox.Show("Correct!");
                }
                else
                {
                    MessageBox.Show("Correct! You have finished the game!");
                    Application.Current.Shutdown();
                }
            }
            else
                MessageBox.Show("Wrong answer!");
        }
        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            if (Button3.Tag.Equals("correct"))
            {
                if (QuestionNumber < size)
                {
                    QuestionNumber = Game.Start(QuestionNumber);
                    MessageBox.Show("Correct!");
                }
                else
                {
                    MessageBox.Show("Correct! You have finished the game!");
                    Application.Current.Shutdown();
                }
            }
            else
                MessageBox.Show("Wrong answer!");
        }
        private void Button4_Click(object sender, RoutedEventArgs e)
        {
            if (Button4.Tag.Equals("correct"))
            {
                if (QuestionNumber < size)
                {
                    QuestionNumber = Game.Start(QuestionNumber);
                    MessageBox.Show("Correct!");
                }
                else
                {
                    MessageBox.Show("Correct! You have finished the game!");
                    Application.Current.Shutdown();
                }
            }
            else
                MessageBox.Show("Wrong answer!");
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
                MessageBox.Show($"A Dll Or Data File is missing. Please make sure you have the correct files in the correct folder.\n\nError Code: {ex}");
                Application.Current.Shutdown();
            }
            Embed.Visibility = Visibility.Collapsed;
            BackgroundP.Visibility = Visibility.Collapsed;
            Start.Visibility = Visibility.Collapsed;
            Select.Visibility = Visibility.Collapsed;
            QuestionNumber = Game.Start(0);
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
                    MessageBox.Show($"A Dll Or Data File is missing. Please make sure you have the correct files in the correct folder.\n\nError Code: {ex}");
                    Application.Current.Shutdown();
                }
                Embed.Visibility = Visibility.Collapsed;
                BackgroundP.Visibility = Visibility.Collapsed;
                Start.Visibility = Visibility.Collapsed;
                Select.Visibility = Visibility.Collapsed;
                QuestionNumber = Game.Start(0);
            }
        }
    }
}
