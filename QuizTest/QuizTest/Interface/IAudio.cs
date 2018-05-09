using System;
using System.Collections.Generic;
using System.Text;

namespace QuizTest.Interface
{
    //Dependency ile android ios ses konfigürasyonu yapıldı.
    public interface IAudio
    {
        bool PlayAudio(int SoundName);
        void StopAudio();
    }
}
