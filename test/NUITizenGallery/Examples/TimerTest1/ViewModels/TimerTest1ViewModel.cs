using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Tizen.NUI.Binding;
using Tizen.NUI;
using System.Diagnostics;

namespace NUITizenGallery.ViewModels
{
    public class TimerTest1ViewModel : INotifyPropertyChanged, IDisposable
    {
        private readonly Timer timer;
        private readonly Stopwatch stopWatch = new Stopwatch();
        private bool timerStarted;
        private string hoursMinutesSeconds;
        private string miliseconds;
        private bool disposed = false;

        public ICommand StartTimer
        {
            get;
            private set;
        }

        public ICommand StopTimer
        {
            get;
            private set;
        }

        public TimerTest1ViewModel()
        {
            timerStarted = false;
            timer = new Timer(100);

            timer.Tick += OnTimerIntervalElapsed;
            timer.Stop();

            StartTimer = new Command(ExecuteStartTimer);
            StopTimer = new Command(ExecuteStopTimer);
            HoursMinutesSeconds = "00:00";
            Miliseconds = ".00";
        }

        private bool OnTimerIntervalElapsed(object sender, Timer.TickEventArgs e)
        {
            var ts = stopWatch.Elapsed;
            HoursMinutesSeconds = ts.Hours == 0 ?
                string.Format("{0:00}:{1:00}", ts.Minutes, ts.Seconds) :
                string.Format("{0:00}:{1:00}:{2:00}", ts.Hours, ts.Minutes, ts.Seconds);

            Miliseconds = string.Format(".{0:00}", ts.Milliseconds / 10);

            return true;
        }

        public bool TimerStarted
        {
            get => timerStarted;
            set
            {
                if (timerStarted != value)
                {
                    timerStarted = value;
                    RaisePropertyChagend();
                }
            }
        }

        public string HoursMinutesSeconds
        {
            get => hoursMinutesSeconds;
            set
            {
                if (hoursMinutesSeconds != value)
                {
                    hoursMinutesSeconds = value;
                    RaisePropertyChagend();
                }
            }
        }

        public string Miliseconds
        {
            get => miliseconds;
            set
            {
                if (miliseconds != value)
                {
                    miliseconds = value;
                    RaisePropertyChagend();
                }
            }
        }

        private void ExecuteStartTimer()
        {
            TimerStarted = true;
            timer.Start();
            stopWatch.Start();
        }


        private void ExecuteStopTimer()
        {
            TimerStarted = false;
            timer.Stop();
            stopWatch.Stop();
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChagend([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    timer.Tick -= OnTimerIntervalElapsed;
                    timer?.Dispose();
                }

                disposed = true;
            }
        }
    }
}
