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
            Console.WriteLine("ItzPowerTerm v0.2 by DINKONDBD (dinkondbd.github.io)");
            string usr_input = "";
            while (usr_input != "exit")
            {
                Term();
            }
        }
        static void Term()
        {
            Console.Write(">>");
            input = Console.ReadLine();

            switch (input.Split(' ').FirstOrDefault().ToLower())
            {
                default: if (input != "") Console.WriteLine("Command " + input + " is not exists"); break;

                case "file":
                    crowrfile(input.Split(' ').Skip(2).FirstOrDefault(), input.Split(' ').Skip(1).FirstOrDefault(), input.Split(' ').Skip(3).FirstOrDefault());
                    break;
                case "help":

                    showHelp();

                    break;

                case "calc":

                    calc();

                    break;
                case "clear":

                    clear();

                    break;

                case "history":

                    showhistory();

                    break;

                case "start":

                    start();

                    break;
                case "ls":

                    ls();

                    break;
                case "echo":
                    Console.WriteLine(input.Remove(0, 5));

                    break;
            }
            term_history += DateTime.Now.ToString("h:mm:ss tt") + " " + input + "\n";
        }

        private static void calc()
        {
            try
            {
                var result = new Expression(input.Split(' ').Skip(1).FirstOrDefault()).Evaluate();
                Console.WriteLine(result);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private static void crowrfile(string path, string arg, string arg2)
        {
            
            try
            {
                
                switch (arg)
                {
                    default: Console.WriteLine("argument " + arg + " was not found"); break;
                    case "-c": var c = System.IO.File.Create(path); c.Close(); break;

                    case "-d":  System.IO.File.Delete(path); break;

                    case "-e":  System.IO.File.Encrypt(path); break;

                    case "-t": System.IO.File.Decrypt(path); break;

                    case "-r": Console.WriteLine(System.IO.File.ReadAllText(path)); break;

                    case "-w":
                        var a = input.Remove(0, input.IndexOf(arg2));
                        System.IO.File.WriteAllText(path, a); break;

                    case "-m":moveFile(path, arg2); break;

                    case "-p":System.IO.File.Copy(path, arg2); break;


                }

                
            }
            catch(System.Exception e)
            {
                Console.WriteLine(e);
            }
        }
        private static void showHelp()
        {
            try
            {
                Console.WriteLine("Commands:" +
                    "\n calc - Shows output evaluation of argument [1 args] \n" +
                    "\n clear - clears console [0 args]\n" +
                    "\n history - shows current terminal session history [0 args]\n" +
                    "\n ls - shows subfolders or all files [2 args]:" +
                    "\n -s show all subfolders" +
                    "\n -a shows all files (requires to type path) (example ls -a C:/)\n " +
                    "\n start - starts file or program from argument [1 args]\n" +
                    "\n file - does file manipulation [8 args]:" +
                    "\n -c creates file" +
                    "\n -d deletes file" +
                    "\n -e encrypts file" +
                    "\n -t decrypts file" +
                    "\n -r reads all text from file " +
                    "\n -w writes text to file" +
                    "\n -m moves file" +
                    "\n -p copies file\n" +
                    "\n echo shows text [1 arg] (example echo hello world)");
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void moveFile(string arg1, string arg2)
        {
            System.IO.File.Copy(arg1, arg2);
            System.IO.File.Delete(arg1);

        }
        private static void showhistory(){if (term_history != "") Console.WriteLine("Your terminal session history: \n" + term_history);}

        private static void clear()
        {
            try
            {
                Console.Clear();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void start()
        {
            try
            {
                System.Diagnostics.Process.Start(input.Split(' ').Skip(1).FirstOrDefault());
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

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

        private static void ls()
        {
            try
            {
                if (input.Split(' ').Skip(1).FirstOrDefault() == "-a")
                {
                    if (input.Split(' ').Skip(2).FirstOrDefault() == "" || input.Split(' ').Skip(2).FirstOrDefault() == null)
                    {
                        Console.WriteLine("Type path to list all files");
                    }
                    else
                    {
                        DirectorySearch(input.Split(' ').Skip(2).FirstOrDefault());
                    }

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
                    Console.WriteLine("argument " + input.Split(' ').Skip(1).FirstOrDefault() + " was not found");
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}