using System;
using NCalc;
using System.Diagnostics;

namespace ItzPowerTerm // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        public static string term_history = "";
        public static string input = "";
        static void Main(string[] args)
        {

            //var secondWord = str.Split(' ').Skip(1).FirstOrDefault();
            Console.WriteLine("ItzPowerTerm v0.1 by DINKONDBD (dinkondbd.github.io)");
            string usr_input = "";
            while(usr_input != "exit")
            {
                Term();
            }
        }
        static void Term()
        {
            Console.Write(">>");
            input = Console.ReadLine();

            switch(input.Split(' ').FirstOrDefault().ToLower())
            {
                default: if(input != "") Console.WriteLine("Command " + input + " is not exists"); break;

                case "calc":
                    try
                    {
                        var result = new Expression(input.Split(' ').Skip(1).FirstOrDefault()).Evaluate();
                        Console.WriteLine(result);
                    }
                    catch
                    {
                        Console.WriteLine("error was occured");
                    }

                    break;

                case "history":
                    if (term_history != "") Console.WriteLine("Your terminal session history: \n" + term_history);
                    break;

                case "start":
                    try
                    {
                        System.Diagnostics.Process.Start(input.Split(' ').Skip(1).FirstOrDefault());
                    }
                    catch
                    {
                        Console.WriteLine("error was occured");
                    }
                    
                    break;
                case "ls":
                    try
                    {
                        if (input.Split(' ').Skip(1).FirstOrDefault() == "-a")
                        {
                            DirectorySearch(input.Split(' ').Skip(2).FirstOrDefault());
                        }
                        else if (input.Split(' ').Skip(1).FirstOrDefault() == "-s")
                        {
                            if (input.Split(' ').Skip(2).FirstOrDefault() == "" || input.Split(' ').Skip(2).FirstOrDefault() == null)
                            {
                                Console.WriteLine("Type path to list all sub folders");
                            }
                            else
                            {
                                string[] fileArray = Directory.GetDirectories(input.Split(' ').Skip(2).FirstOrDefault());

                                for (int i = 0; i < fileArray.Length; i++)
                                {

                                    Console.WriteLine(fileArray[i]);
                                }
                            }

                        }
                        else
                        {
                            Console.WriteLine("parameter " + input.Split(' ').Skip(2).FirstOrDefault() + " was not found");
                        }
                    }
                    catch
                    {
                        Console.WriteLine("error was occured");
                    }

                    break;
            }   
            term_history += DateTime.Now.ToString("h:mm:ss tt")+ " " + input + "\n";
        }
        public static void DirectorySearch(string dir)
        {
            try
            {
                foreach (string f in Directory.GetFiles(dir))
                {
                    Console.WriteLine(Path.GetFileName(f));
                }
                foreach (string d in Directory.GetDirectories(dir))
                {
                    Console.WriteLine(Path.GetFileName(d));
                    DirectorySearch(d);
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}