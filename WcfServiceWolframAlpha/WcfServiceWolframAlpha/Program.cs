﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.ServiceModel.Description;
using System.Web.Services.Description;

namespace WcfServiceWolframAlpha
{
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        [WebGet]
        string EchoWithGet(string s);

        [OperationContract]
        [WebInvoke]
        string EchoWithPost(string s);


        // TODO: Add your service operations here
    }

    public class Service1 : IService1
    {


        public string EchoWithGet(string s)
        {
            return "You said " + s;
        }

        public string EchoWithPost(string s)
        {
            return "You said " + s;
        }

    }
    public class Program
    {
        static void Main(string[] args)
        {
            WebServiceHost host = new WebServiceHost(typeof(Service), new Uri("http://localhost:60616"));
            try
            {

                ServiceEndpoint ep = host.AddServiceEndpoint(typeof(IService1), new WebHttpBinding(), "");
                host.Open();
                using (ChannelFactory<IService1> cf = new ChannelFactory<IService1>(new WebHttpBinding(), "http://localhost:60616"))
                {
                    cf.Endpoint.Behaviors.Add(new WebHttpBehavior());

                    IService1 channel = cf.CreateChannel();

                    string s;
                    Console.WriteLine("Calling EchoWithGet via HTTP GET: ");
                    s = channel.EchoWithGet("Hello, world");
                    Console.WriteLine("   Output: {0}", s);

                    Console.WriteLine("");
                    Console.WriteLine("This can also be accomplished by navigating to");
                    Console.WriteLine("http://localhost:60616/EchoWithGet?s=Hello, world!");
                    Console.WriteLine("in a web browser while this sample is running.");

                    Console.WriteLine("");

                    Console.WriteLine("Calling EchoWithPost via HTTP POST: ");
                    s = channel.EchoWithPost("Hello, world");
                    Console.WriteLine("   Output: {0}", s);
                    Console.WriteLine("");

                }



                Console.WriteLine("Press <ENTER> to terminate");
                Console.ReadLine();

                host.Close();

            }
            catch (CommunicationException cex)
            {
                Console.WriteLine("An exception occurred: {0}", cex.Message);
                host.Abort();
            }
        }
    }
}

            