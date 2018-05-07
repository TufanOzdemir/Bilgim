using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Media;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using QuizTest.Droid;
using QuizTest.Interface;
using Xamarin.Forms;

[assembly: Dependency(typeof(Audio))]
namespace QuizTest.Droid
{

    public class Audio : IAudio
    {
        private MediaPlayer _mediaPlayer;

        public bool PlayAudio(int SoundName)
        {
            bool result;
            
            
            if(SoundName.Equals(Resource.Raw.timeSound))
            {
                _mediaPlayer = MediaPlayer.Create(global::Android.App.Application.Context, SoundName);
                _mediaPlayer.Looping = true;
                _mediaPlayer.Start();
                result = true;
            }
            if (SoundName.Equals(Resource.Raw.winSound))
            {
                _mediaPlayer = MediaPlayer.Create(global::Android.App.Application.Context, SoundName);
                _mediaPlayer.Looping = false;
                _mediaPlayer.Start();
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }
        public void StopAudio()
        {
            _mediaPlayer.Stop();
            _mediaPlayer.Dispose();
        }
    }
}