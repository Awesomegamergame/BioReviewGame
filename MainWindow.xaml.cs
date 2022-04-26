using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BioReviewGame
{
    public partial class MainWindow : Window
    {
        public static MainWindow GameWindow;
        public static int QuestionNumber;
        public static int size;
        public MainWindow()
        {
            InitializeComponent();
            GameWindow = this;
            size = Json.JsonReader();
            QuestionNumber = Game.Start(0);
        }

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
    }
}
