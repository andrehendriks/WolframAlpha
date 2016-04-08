using System;
using System.Speech.Synthesis;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.CSharp;
using RestSharp;
using System.Net;
using WolframAlphaNET;
using WolframAlphaNET.Enums;
using WolframAlphaNET.Misc;
using WolframAlphaNET.Objects;

namespace WolframAlphaApi2
{
    public partial class Program
    {
        
        public static void Main(string[] args)
        {
            WolframAlpha wolfram = new WolframAlpha(Properties.Resources.String1);
            SpeechSynthesizer speak = new SpeechSynthesizer();
            string input = Console.ReadLine();
            QueryResult results = wolfram.Query(input);
            foreach (Pod pod in results.Pods)
            {

                Console.WriteLine(pod.Title);
                foreach (SubPod subpod in pod.SubPods)
                {

                    Console.WriteLine(subpod.Title);
                    Console.WriteLine(subpod.Plaintext);
                    speak.Speak(subpod.Plaintext);
                }
            }

            Console.WriteLine(Properties.Resources.String2);
            Console.Read();
        }
    }
}
