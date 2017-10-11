using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin.Hosting;
using AremtyCore;

namespace SelfHostOwin
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceApplication app = new ServiceApplication();
            app.Init();

            Console.WriteLine("Service is start. Press ENTER key to exit");
            Console.ReadLine();

        }
    }
}
