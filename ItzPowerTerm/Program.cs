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
                case "help":
                    try
                    {
                        Console.WriteLine("Commands:" +
                            "\n calc - Shows output evaluation of argument [1 args]" +
                            "\n clear - clears console [0 args]" +
                            "\n history - show current terminal session history [0 args]" +
                            "\n ls - shows subfolders or all files [2 args] arg -s show all subfolders -a shows all files (requires to type path) (example ls -a C:/) " +
                            "\n start - starts file or program from argument [1 args]");
                    }
                    catch (System.Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;

                case "calc":
                    try
                    {
                        var result = new Expression(input.Split(' ').Skip(1).FirstOrDefault()).Evaluate();
                        Console.WriteLine(result);
                    }
                    catch (System.Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                break;
                case "clear":
                    try
                    {
                        Console.Clear();
                    }
                    catch (System.Exception ex)
                    {
                        Console.WriteLine(ex.Message);
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
                    catch (System.Exception ex)
                    {
                        Console.WriteLine(ex.Message);
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
                    catch (System.Exception ex)
                    {
                        Console.WriteLine(ex.Message);
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