using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Wpf_Async
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private List<CancellationTokenSource> sources = new List<CancellationTokenSource>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private async Task<bool> Delay(int seconds, int id, CancellationTokenSource cts)
        {
            sources.Add(cts);

            try
            {
                await Task.Delay(TimeSpan.FromSeconds(seconds), cts.Token);
            }
            catch (TaskCanceledException ex)
            {
                if (id == 0)
                {
                    tb.Text = "Click - cancelled";
                    tb.Foreground = Brushes.Red;
                }
                if (id == 1)
                {
                    tb1.Text = "Click1 - cancelled";
                    tb1.Foreground = Brushes.Red;
                }
                if (id == 2)
                {
                    tb2.Text = "Click2 - cancelled";
                    tb2.Foreground = Brushes.Red;
                }
                return false;
            }
            finally
            {
                cts.Dispose();
                sources.Remove(cts);
            }
            return true;
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            CancellationTokenSource cts = new CancellationTokenSource();

            tb.Text = "wait 2 seconds";
            tb.Foreground = Brushes.Orange;
            if (!await Delay(2, 0, cts))
                return;
            tb.Text = "Click Done after 2 second wait";
            tb.Foreground = Brushes.Green;
        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            CancellationTokenSource cts = new CancellationTokenSource();

            tb1.Text = "wait 10 seconds";
            tb1.Foreground = Brushes.Orange;
            if (!await Delay(10, 1, cts))
                return;
            tb1.Text = "Click1 Done after 10 second wait";
            tb1.Foreground = Brushes.Green;
        }

        private async void Button_Click_2(object sender, RoutedEventArgs e)
        {
            CancellationTokenSource cts = new CancellationTokenSource();

            tb2.Text = "wait 7 seconds";
            tb2.Foreground = Brushes.Orange;
            if (!await Delay(7, 2, cts))
                return;
            tb2.Text = "Click2 Done after 7 second wait";
            tb2.Foreground = Brushes.Green;
        }

        private void CancelAllClick(object sender, RoutedEventArgs e)
        {
            foreach (var s in sources)
            {
                if (s.Token.CanBeCanceled)
                    s.Cancel();
            }
        }

        private void ParallelClick(object sender, RoutedEventArgs e)
        {
            Button[] btns = { b, b1, b2 };

            Parallel.Invoke(() =>
            {
                Button_Click(null, null);
                Button_Click_1(null, null);
                Button_Click_2(null, null);
            });

        }


        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            tb.Text = "Click";
            tb.Foreground = Brushes.Black;
            tb1.Text = "Click1";
            tb1.Foreground = Brushes.Black;
            tb2.Text = "Click2";
            tb2.Foreground = Brushes.Black;
        }
    }
}
