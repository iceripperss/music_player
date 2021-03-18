using System;
using System.Threading;

///                         _         ____  __                     
///   ____ ___  __  _______(_)____   / __ \/ /___ ___  _____  _____
///  / __ `__ \/ / / / ___/ / ___/  / /_/ / / __ `/ / / / _ \/ ___/
/// / / / / / / /_/ (__  ) / /__   / ____/ / /_/ / /_/ /  __/ /    
/// _/ /_/ /_/\__,_/____/_/\___/  /_/   /_/\__,_/\__, /\___/_/     
///                                             /____/                                              

//happyBirthday = "80;8G4;8G4;4A4;4G4;4C5;2H4;8G4;8G4;4A4;4G4;4D5;2C5;8G4;8G4;4G5;4E5;4C5;4H4;4A4;8F5;8F5;4E5;4C5;4D5;4C5;";
//furElise = "80;8E5;8D#5;8E5;8D#5;8E5;8H4;8D5;8C5;4A4;8P;8C4;8E4;8A4;4H4;8P;8E4;8G#4;8H4;4C5;";

namespace Task18
{
    class Program
    {
        static void Main(string[] args)
        {
            string Notes = "80;8E5;8D#5;8E5;8D#5;8E5;8H4;8D5;8C5;4A4;8P;8C4;8E4;8A4;4H4;8P;8E4;8G#4;8H4;4C5;";

            string[] NoteArray = Notes.Split(';', Notes.Length, StringSplitOptions.RemoveEmptyEntries);

            int bpm = int.Parse(NoteArray[0]); // ритм, метр музыки
            int quarterMilliseconds = (int)(60.0 / bpm * 1000); // сколько в миллисекундах будет звучать четвертая нота

            for (int index = 1; index < NoteArray.Length; index++)
            {
                string temp = NoteArray[index];
                int noteIntegrity = int.Parse(temp.Substring(0,1));

                string notaVOctave = temp.Substring(1);
                int frequancy = Frequency(notaVOctave);

                Console.WriteLine(NoteArray[index]);

                if (notaVOctave != "P")
                {
                    if(notaVOctave.Contains('#'))    
                    Console.Beep(frequancy + 100, (durationMs(quarterMilliseconds, noteIntegrity)));

                    Console.Beep(frequancy, (durationMs(quarterMilliseconds, noteIntegrity)));
                }
                else
                {
                    Thread.Sleep(durationMs(quarterMilliseconds, noteIntegrity));
                }
            }
        }
        public static int durationMs(int quarterMs, int duration)
        {
            int durationMilliseconds = (int)(quarterMs / (duration / 4.0)); // сколько в миллисекундах будет звучать нота определенной длительности, целая, половинная, четвертая и т.д.
            return durationMilliseconds;
        }
        // длительность ноты, может быть 1, 2, 4, 8, 16
        public static int Frequency(string notaVOctave)
        {

            switch (notaVOctave)
            {
                case "C4":
                    {
                        return 263;
                    }
                case "D4":
                    {
                        return 293;
                    }
                case "E4":
                    {
                        return 329;
                    }
                case "F4":
                    {
                        return 349;
                    }
                case "G4":
                    {
                        return 392;
                    }
                case "G#4":
                    {
                        return 413;
                    }
                case "A4":
                    {
                        return 440;
                    }
                case "H4":
                    {
                        return 493;
                    }
                case "C5":
                    {
                        return 523;
                    }
                case "D5":
                    {
                        return 587;
                    }
                case "D#5":
                    {
                        return 620;
                    }
                case "E5":
                    {
                        return 659;
                    }
                case "F5":
                    {
                        return 698;
                    }
                case "G5":
                    {
                        return 783;
                    }
                case "A5":
                    {
                        return 880;
                    }
                case "H5":
                    {
                        return 987;
                    }
                default:
                    {
                        return 1000;
                    }
            }

        }
    }
}

