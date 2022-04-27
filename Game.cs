using System.Windows;
using static BioReviewGame.MainWindow;

namespace BioReviewGame
{
    internal class Game
    {
        public static int Start(int questionNumber)
        {
            int num = questionNumber;
            num++;
            GameWindow.QTitle.Content = $"Question Number #{num}";
            GameWindow.Question.Text = Json.questionlist[questionNumber];
            GameWindow.Button1.Content = Json.a1List[questionNumber];
            GameWindow.Button2.Content = Json.a2List[questionNumber];
            GameWindow.Button3.Content = Json.a3List[questionNumber];
            GameWindow.Button4.Content = Json.a4List[questionNumber];
            Tag(questionNumber);
            questionNumber++;
            return questionNumber;
        }
        public static void Tag(int questionNumber)
        {
            int number = int.Parse(Json.cList[questionNumber]);
            switch (number)
            {
                case 1:
                    GameWindow.Button1.Tag = "correct";
                    GameWindow.Button2.Tag = "wrong";
                    GameWindow.Button3.Tag = "wrong";
                    GameWindow.Button4.Tag = "wrong";
                    break;
                case 2:
                    GameWindow.Button1.Tag = "wrong";
                    GameWindow.Button2.Tag = "correct";
                    GameWindow.Button3.Tag = "wrong";
                    GameWindow.Button4.Tag = "wrong";
                    break;
                case 3:
                    GameWindow.Button1.Tag = "wrong";
                    GameWindow.Button2.Tag = "wrong";
                    GameWindow.Button3.Tag = "correct";
                    GameWindow.Button4.Tag = "wrong";
                    break;
                case 4:
                    GameWindow.Button1.Tag = "wrong";
                    GameWindow.Button2.Tag = "wrong";
                    GameWindow.Button3.Tag = "wrong";
                    GameWindow.Button4.Tag = "correct";
                    break;
            }
        }
        public static void EndGame()
        {
            MessageBox.Show("You have finished the game!");
            GameWindow.BackgroundP.Visibility = Visibility.Visible;
            timer.Enabled = false;
            timer.Dispose();
            thread.Abort();
        }
    }
}
