using System;
using System.IO;
using System.Windows.Media;

namespace CrossEngine
{
    public class SoundSystem
    {
        public static float UniversalAudioVolume = 1;

       static MediaPlayer mediaPlayer;

        public static void Play(string filename , float volume)
        {
            mediaPlayer = new MediaPlayer();
            mediaPlayer.Volume = (volume / 100.0f) * UniversalAudioVolume;

            mediaPlayer.Open(new Uri(filename));
            mediaPlayer.Play();
        }
    }
}
