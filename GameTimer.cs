using System;
using System.Threading;
using static BioReviewGame.MainWindow;

namespace BioReviewGame
{
    internal class GameTimer
    {
        public static string ScoreTimer = "";
        public static void StartTimer()
        {
            int time = Json.time / 1000;
            while (time != -1)
            {
                TimeSpan timespan = TimeSpan.FromSeconds(time);
                ScoreTimer = string.Format("{0} Min(s) and {1} Second(s) left", timespan.Minutes, timespan.Seconds);
                GameWindow.Dispatcher.Invoke(() =>
                {
                    GameWindow.Timer.Content = ScoreTimer;
                });
                Thread.Sleep(1000);
                time--;
            }
        }
    }
}
