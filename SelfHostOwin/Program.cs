using System;
using AremtyCore;

namespace SelfHostOwin
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceApplication app = new ServiceApplication();
            app.Init();
            app.StartServices();

            Console.WriteLine("Service is start. Press ENTER key to exit");
            Console.ReadLine();

            app.StopServices();

        }
    }
}
