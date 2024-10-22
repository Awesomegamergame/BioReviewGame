﻿using System.Windows;
using System.Windows.Controls;
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
            var tb = GameWindow.Button1.Content as TextBlock;
            tb.Text = Json.a1List[questionNumber];
            tb = GameWindow.Button2.Content as TextBlock;
            tb.Text = Json.a2List[questionNumber];
            tb = GameWindow.Button3.Content as TextBlock;
            tb.Text = Json.a3List[questionNumber];
            tb = GameWindow.Button4.Content as TextBlock;
            tb.Text = Json.a4List[questionNumber];
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
    }
}
