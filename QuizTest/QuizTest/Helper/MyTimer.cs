using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace QuizTest.Helper
{
    //Oyun için zamanlayıcı genel sınıfı
    public class MyTimer
    {
        private readonly TimeSpan _timespan;
        private readonly Action _callback;
        private readonly bool _repeat;
        public double timer;

        public bool _running;
        private bool _timerCallbackPending;

        public MyTimer(TimeSpan timespan, Action callback, bool repeat)
        {
            _timespan = timespan;
            _callback = callback;
            _repeat = repeat;
        }

        public void Start()
        {
            _running = true;
            ScheduleTimerIfNeeded();
        }

        public void Stop()
        {
            _running = false;
        }

        private void ScheduleTimerIfNeeded()
        {
            if (!_timerCallbackPending)
            {
                {
                    _timerCallbackPending = true;
                    Device.StartTimer(_timespan, TimerCallback);
                }
            }
        }

        private bool TimerCallback()
        {
            if (_running)
            {
                _callback.Invoke();
            }

            bool reschedule = _repeat && _running;

            _timerCallbackPending = reschedule;

            return reschedule;
        }

        public void StartTime(double value)
        {
            _running = true;
            timer = value;
            Device.StartTimer(_timespan, TimerCallbackTime);
        }

        private bool TimerCallbackTime()
        {
            if (_running)
            {
                _callback.Invoke();
            }
            bool result = timer > 0 && _running;
            if (result)
            {
                timer--;
            }
            else
            {
                Stop();
            }
            return result;
        }
    }
}