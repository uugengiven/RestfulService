﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceProcess;
using System.Configuration.Install;
using System.Reflection;
using Microsoft.Owin.Hosting;
using System.Net.Http;


namespace Service_Test01
{
    public class Program : ServiceBase
    {

        public static string ServiceName = "OBS API Service";
        public static string baseAddress = "localhost";
        public static string basePort = "9000";
        

        public Program()
        {
            // This is where normal program stuff goes
        }

        protected override void OnStart(string[] args)
        {
            StartOptions options = new StartOptions();
            // Create multiple urls - 127.0.0.1, machine name and the given name in baseAddress so it responds to all requests - could also use *
            options.Urls.Add(string.Format("http://{0}:{1}", baseAddress, basePort));
            options.Urls.Add(string.Format("http://{0}:{1}", "127.0.0.1", basePort));
            options.Urls.Add(string.Format("http://{0}:{1}", Environment.MachineName, basePort));

            WebApp.Start<ApiStartup>(options);
        }

        protected override void OnStop()
        {
            //stop any threads here and wait for them to be stopped.
        }

        protected override void Dispose(bool disposing)
        {
            //clean your resources if you have to
            base.Dispose(disposing);
        }

        private static bool IsServiceInstalled()
        {
            return ServiceController.GetServices().Any(s => s.ServiceName == ServiceName);
        }

        private static void InstallService()
        {
            if (IsServiceInstalled())
            {
                UninstallService();
            }

            ManagedInstallerClass.InstallHelper(new string[] { Assembly.GetExecutingAssembly().Location });
        }

        private static void UninstallService()
        {
            ManagedInstallerClass.InstallHelper(new string[] { "/u", Assembly.GetExecutingAssembly().Location });
        }

        static void Main(string[] args)
        {
            bool debugMode = false;
            if (args.Length > 0)
            {
                for (int ii = 0; ii < args.Length; ii++)
                {
                    switch (args[ii].ToUpper())
                    {
                        case "/NAME":
                            if (args.Length > ii + 1)
                            {
                                ServiceName = args[++ii];
                            }
                            break;
                        case "/I":
                            InstallService();
                            return;
                        case "/U":
                            UninstallService();
                            return;
                        case "/D":
                            debugMode = true;
                            break;
                        default:
                            break;
                    }
                }
            }

            if (debugMode)
            {
                Program service = new Program();
                service.OnStart(null);
                Console.WriteLine("Service Started...");
                Console.WriteLine("<press any key to exit...>");
                Console.Read();
            }
            else
            {
                System.ServiceProcess.ServiceBase.Run(new Program());
            }
        }
    }
}
