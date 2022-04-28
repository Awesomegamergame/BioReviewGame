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
            GameWindow.QTitle.Content = $"Question Number #{num} of {size}";
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
        public static void EndGame(bool timeover)
        {
            timer.Enabled = false;
            timer.Dispose();
            thread.Abort();
            if (timeover)
            {
                GameWindow.Dispatcher.Invoke(() =>
                {
                    GameWindow.BackgroundP.Visibility = Visibility.Visible;
                    GameWindow.EndTitle.Visibility = Visibility.Visible;
                    GameWindow.EndBody.Visibility = Visibility.Visible;
                    GameWindow.Score.Content = $"{score}/{size} Correct";
                    GameWindow.Score.Visibility = Visibility.Visible;
                    GameWindow.TimeLeft.Content = "Times Up";
                    GameWindow.TimeLeft.Visibility = Visibility.Visible;
                });
            }
            else
            {
                GameWindow.Dispatcher.Invoke(() =>
                {
                    GameWindow.BackgroundP.Visibility = Visibility.Visible;
                    GameWindow.EndTitle.Visibility = Visibility.Visible;
                    GameWindow.EndBody.Visibility = Visibility.Visible;
                    GameWindow.Score.Content = $"{score}/{size} Correct";
                    GameWindow.Score.Visibility = Visibility.Visible;
                    GameWindow.TimeLeft.Content = GameTimer.ScoreTimer;
                    GameWindow.TimeLeft.Visibility = Visibility.Visible;
                });
            }
        }
        public static void StopThread()
        {
            thread.Abort();
        }
    }
}
