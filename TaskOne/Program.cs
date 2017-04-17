using System;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace TaskOne
{
    public class Program
    {
        public static void Main()
        {
            var host = new ServiceHost(typeof(LibraryService), new Uri("http://localhost:8886/library"));
            var smb = new ServiceMetadataBehavior {HttpGetEnabled = true};
            host.Description.Behaviors.Add(smb);

            host.Open();

            Console.WriteLine("Press enter...");
            Console.ReadLine();

            host.Close();
        }
    }
}