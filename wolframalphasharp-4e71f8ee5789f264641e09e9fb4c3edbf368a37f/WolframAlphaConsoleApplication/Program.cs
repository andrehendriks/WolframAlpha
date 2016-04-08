using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Speech.Synthesis;
using WolframAlphaNET;
using WolframAlphaNET.Enums;
using WolframAlphaNET.Misc;
using WolframAlphaNET.Objects.Errors;
using WolframAlphaNET.Objects.Output;
using WolframAlphaNET.Objects.Warnings;
using WolframAlphaNET.Objects;

[assembly: CLSCompliant(true)]

namespace WolframAlphaConsoleApplication
{
    public static class Program
    {
        

        static void Main(string[] args)
        {
            
            var appid = Properties.Resources.String4;
            WolframAlpha wolfram = new WolframAlpha(appid);
            

            Math.BigMul(230, 12);
            Math.IEEERemainder(8.0, 10.0); Math.Abs(1);
            Math.Truncate(5.0);Math.Truncate(7.0);
            Math.Max(4, 2);
            Math.Min(8, 5);
            Math.Sqrt(15.0);

            string input = Console.ReadLine();
            QueryResult results = wolfram.Query(input);
            wolfram.ApiUrl = "http://api.wolframalpha.com/v2/query" + Properties.Resources.String5 + appid + Properties.Resources.String6 + input;


            Assumption Asume = new Assumption();
            Asume.Word = Properties.Resources.String1;
            Asume.Word = Properties.Resources.String2;
            Asume.Word = Properties.Resources.String3;
            
            
            wolfram.ApiUrl = "http://api.wolframalpha.com/v2/query" + Properties.Resources.String5 + appid + Properties.Resources.String6 + input + Properties.Resources.String7 + Asume;
            Reinterpret reinterpret = new Reinterpret();
            reinterpret.Text = Properties.Resources.String8;
            reinterpret.Text = Properties.Resources.String9;
            reinterpret.Text = Properties.Resources.String10;
            wolfram.ApiUrl = "http://api.wolframalpha.com/v2/query" + Properties.Resources.String5 + appid + Properties.Resources.String6 + input + Properties.Resources.String7 + reinterpret;
            
                foreach (Pod pod in results.Pods)
                {
                    Console.WriteLine(pod.Title);

                    foreach (SubPod subPod in pod.SubPods)
                    {
                        SpeechSynthesizer Speak = new SpeechSynthesizer();
                        Console.WriteLine(subPod.Title);
                        Console.WriteLine(subPod.Plaintext);
                        Speak.Speak(subPod.Plaintext);
                    }
                }
            
            
            Console.WriteLine(Properties.Resources.String11);
            Console.Read();
        }
        
    }
}
