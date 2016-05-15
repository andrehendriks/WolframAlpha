using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.ServiceModel.Description;
using System.Web.Services.Description;
using WolframAlphaNET;
using WolframAlphaNET.Enums;
using WolframAlphaNET.Misc;
using WolframAlphaNET.Objects;
using System.Speech;
namespace WolframAlpha
{
    class Program
    {
        
        static void Main(string[] args)
        {
            System.Speech.Synthesis.SpeechSynthesizer speak = new System.Speech.Synthesis.SpeechSynthesizer();
            WolframAlphaNET.WolframAlpha wolfram = new WolframAlphaNET.WolframAlpha(Properties.Resources.String1);
            var appid = Properties.Resources.String1;
            string input =  Console.ReadLine();
            var Url = "http://api.wolframalpha.com/v2/query"  + Properties.Resources.String2 + appid + Properties.Resources.String3 + input;

            QueryResult results = wolfram.Query(input);

            foreach (Pod pod in results.Pods)
            {
                Console.WriteLine(pod.Title);

                foreach (SubPod subPod in pod.SubPods)
                {
                    Console.WriteLine(subPod.Title);
                    Console.WriteLine(subPod.Plaintext);
                    speak.Speak(subPod.Plaintext);
                }
            }
            Console.WriteLine("press enter to close....");
            Console.Read();
        }
    }
}
