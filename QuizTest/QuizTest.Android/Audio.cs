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
            _mediaPlayer = MediaPlayer.Create(global::Android.App.Application.Context,SoundName);
            _mediaPlayer.Start();
            if(SoundName.Equals(Resource.Raw.timeSound))
            {
                _mediaPlayer.Looping = true;
                result = true;
            }
            if (SoundName.Equals(Resource.Raw.winSound))
            {
                _mediaPlayer.Looping = false;
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
        }
    }
}