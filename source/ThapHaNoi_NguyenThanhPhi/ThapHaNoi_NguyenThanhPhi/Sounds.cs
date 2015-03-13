using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

using Microsoft.Phone.BackgroundAudio;
using Microsoft.Xna.Framework.Audio;
using System.Windows.Controls;
using System.IO;
using Microsoft.Xna.Framework;

namespace ThapHaNoi_NguyenThanhPhi
{
    class Sounds
    {
        SoundEffect soundEffect;
        SoundEffectInstance main, play, win, lose, wrong, click, bangxephang, select;
        public bool mute;


        public Sounds()
        {
            mute = false;
            soundEffect = SoundEffect.FromStream(TitleContainer.OpenStream("./Assets/Audio/main.wav"));
            main = soundEffect.CreateInstance();
            main.IsLooped = true;

            soundEffect = SoundEffect.FromStream(TitleContainer.OpenStream("./Assets/Audio/click.wav"));
            click = soundEffect.CreateInstance();
            click.Volume = (float)0.6;

            
            soundEffect = SoundEffect.FromStream(TitleContainer.OpenStream("./Assets/Audio/thang.wav"));
            win = soundEffect.CreateInstance();
            win.Volume = (float)0.9;
             

            soundEffect = SoundEffect.FromStream(TitleContainer.OpenStream("./Assets/Audio/wrong.wav"));
            wrong = soundEffect.CreateInstance();
            wrong.Volume = (float)0.9;

            soundEffect = SoundEffect.FromStream(TitleContainer.OpenStream("./Assets/Audio/bangxephang.wav"));
            bangxephang = soundEffect.CreateInstance();
            bangxephang.Volume = (float)0.9;
            
        }

        public Sounds(string state)
        {

        }
        public void Play(string state)
        {
            if (mute) return;
            switch (state)
            {
                case "main": main.Play();
                    break;
                case "losegame": lose.Play();
                    break;
                case "playing": play.Play();
                    break;
                case "click": click.Play();
                    break;
                case "wrong": wrong.Play();
                    break;
                case "win": win.Play();
                    break;
                case "select": select.Play();
                    break;
                case "bangxephang":
                    bangxephang.Play();
                    break;
                default:
                    break;
            }
        }

        public void Stop(string state)
        {
            switch (state)
            {
                case "wingame":
                    if (win.State == SoundState.Playing)
                    {
                        win.Stop();
                    }
                    break;

                case "main":
                    if (main.State == SoundState.Playing)
                    {
                        main.Stop();
                    }
                    break;

                case "losegame": if (lose.State == SoundState.Playing) lose.Stop();
                    break;

                case "playing": if (play.State == SoundState.Playing) play.Stop();
                    break;

                case "select": select.Stop();
                    break;

                case "win": win.Stop();
                    break;

                case "bangxephang": bangxephang.Stop();
                    break;
                default:
                    break;
            }
        }
    }
}
