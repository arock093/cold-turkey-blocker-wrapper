using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;

namespace ColdTurkeyBlockerWrapper
{
    internal class Program
    {
        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        
        [DllImport("user32.dll")]
        static extern bool IsWindowVisible(IntPtr hWnd);
        static void Main(string[] args)
        {
            Console.WriteLine("Are you sure you want to proceed?");
            Console.ReadLine();
            Console.WriteLine("How long do you need to pause block for?");

            int duration = 0;
            do
            {
                Console.Write("Enter duration in minutes: ");
                string durationS = Console.ReadLine();
                try
                {
                    duration = Int32.Parse(durationS);
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
            } while (duration == 0); 

            string blockName = "test";
            string pw = "1234";
            int baseRate = 6;
            int numberOfLetters = baseRate * duration;

            int numTimes = 0;
            string recievedLetter;
            int prevValue = 0;
            char letter = 'A';
            while (numTimes < numberOfLetters)
            {
                if (numTimes != prevValue)
                {
                    letter = GetLetter();
                    prevValue = numTimes;
                }
                Console.WriteLine(letter);
                recievedLetter = "";
                recievedLetter = Console.ReadLine();
                if (recievedLetter.Length == 1 && recievedLetter[0] == letter)
                {
                    numTimes++;
                }
            }
            Console.WriteLine("Are you still absolutely sure you want to procced?");
            Console.ReadLine();

            string path = @"C:\Program Files\Cold Turkey\Cold Turkey Blocker.exe";
            Process process = new Process();
            process.StartInfo.FileName = path;
            process.StartInfo.Arguments = $"-stop {blockName} -password {pw}";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;
            process.Start();

            var handle = GetConsoleWindow();
            bool visible = true;
            while (visible)
            {
                ShowWindow(handle, 0);
                visible = IsWindowVisible(handle);
            }

            Thread.Sleep(60000 * duration);

            process.StartInfo.Arguments = $"-start {blockName} -password {pw}";
            process.Start();
        }

        private static char GetLetter()
        {
            string chars = "$%#@!*abcdefghijklmnopqrstuvwxyz1234567890?;:ABCDEFGHIJKLMNOPQRSTUVWXYZ^&(){}";
            Random rand = new Random();
            int num = rand.Next(0, chars.Length);
            return chars[num];
        }
    }
}
