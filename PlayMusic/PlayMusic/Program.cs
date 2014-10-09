using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using NAudio;
using NAudio.Wave;
using System.Threading;
namespace PlayMusic
{
    class Program
    {
        static Random rand = new Random();
        static bool EXITFLAG = false;
        static IWavePlayer waveOutDevice;
        static Thread AZUSA = new Thread(new ThreadStart(AZUSAListener));

        static void Main(string[] args)
        {


            if (!File.Exists("mp3.txt"))
            {
                Console.WriteLine("{SearchFor(\"*.mp3\")}?");
                string filepath = System.Web.HttpUtility.UrlDecode(Console.ReadLine());
                Console.WriteLine("Reading from " + filepath);
                if (!File.Exists("mp3.txt"))
                {
                    File.Move(filepath, "mp3.txt");
                }
                
            }

            AZUSA.Start();

            string[] playlist = File.ReadAllLines("mp3.txt", Encoding.UTF8);

            string filename;
            WaveStream mp3Reader;
            if (playlist.Count() > 0)
            {
                while (true)
                {

                    filename = playlist[rand.Next(playlist.Count())];
                    mp3Reader = new Mp3FileReader(filename);
                    if (mp3Reader.TotalTime.Minutes > 0)
                    {
                        PLAY(filename);
                    }

                }
            }

        }

        static void AZUSAListener()
        {
            Console.WriteLine("LinkRID(PauseMusic,false)");
            Console.WriteLine("LinkRID(StopMusic,false)");
            string cmd;
            while (true)
            {
                cmd = Console.ReadLine();
                if (cmd == "PauseMusic()")
                {
                    if (waveOutDevice.PlaybackState == PlaybackState.Paused)
                    {
                        waveOutDevice.Play();
                    }
                    else
                    {
                        waveOutDevice.Pause();
                    }

                }
                else if (cmd == "StopMusic()")
                {
                    EXITFLAG = true;
                    Environment.Exit(0);
                }
            }
        }

        //Async MP3 Player
        static void PLAY(string file)
        {
            //Declarations required for audio out and the MP3 stream

            AudioFileReader audioFileReader;
            waveOutDevice = new WaveOut();
            audioFileReader = new AudioFileReader(file);
            waveOutDevice.Init(audioFileReader);
            waveOutDevice.Play();
            waveOutDevice.PlaybackStopped += new EventHandler<StoppedEventArgs>(waveOutDevice_PlaybackStopped);

            while (true)
            {
                if (!EXITFLAG)
                {
                    Thread.Sleep(1000);
                }
            }
        }

        static void waveOutDevice_PlaybackStopped(object sender, StoppedEventArgs e)
        {
            EXITFLAG = true;
        }
    }
}
