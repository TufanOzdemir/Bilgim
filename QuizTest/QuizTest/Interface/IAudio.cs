using System;
using System.Collections.Generic;
using System.Text;

namespace QuizTest.Interface
{
    public interface IAudio
    {
        bool PlayAudio(int SoundName);
        void StopAudio();
        void WaitDownandStopAudio();
    }
}
