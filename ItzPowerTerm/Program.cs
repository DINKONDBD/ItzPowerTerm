using NCalc;
#pragma warning disable CS8601 
#pragma warning disable CS8602
#pragma warning disable CS8604
namespace ItzPowerTerm // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        public static string term_history = "";
        public static string input = "";
        public static string lastcd = "";
        public static bool Islastcd = false;
        static void Main(string[] args)
        {

            //var secondWord = str.Split(' ').Skip(1).FirstOrDefault();
            Console.WriteLine("ItzPowerTerm v0.2 by DINKONDBD (dinkondbd.github.io)");
            while (input != "exit")
            {
                Term();
            }
        }
        static void Term()
        {
            Console.Write(lastcd + ">>");
                            
            input = Console.ReadLine();

            switch (input.Split(' ').FirstOrDefault().ToLower())
            {
                default: if (input != "") Console.WriteLine("Command " + input + " is not exists"); break;

                case "file":
                    crowrfile(input.Split(' ').Skip(2).FirstOrDefault(), input.Split(' ').Skip(1).FirstOrDefault(), input.Split(' ').Skip(3).FirstOrDefault());
                    break;

                case "cd":
                    string a = input.Replace("/", @"\");
                    Console.WriteLine(input.Split(' ').Skip(1).FirstOrDefault());
                    if (a.Split(' ').Skip(1).FirstOrDefault() == null || a.Split(' ').Skip(1).FirstOrDefault() == "")
                    {
                        Islastcd = false;
                        lastcd = "";
                    }
                    else
                    {
                        if (Islastcd)
                        {
                            if (Directory.Exists(lastcd + @"\" + a.Split(' ').Skip(1).FirstOrDefault()))
                            {
                                lastcd = lastcd += @"\" + a.Split(' ').Skip(1).FirstOrDefault();
                                Islastcd = true;


                            }
                            else
                            {
                                Console.WriteLine("wrong path");
                            }
                        }
                        else if (!Islastcd)
                        {
                            if (Directory.Exists(a.Split(' ').Skip(1).FirstOrDefault()))
                            {


                                lastcd = a.Split(' ').Skip(1).FirstOrDefault() + @"\";
                                Islastcd = true;


                            }
                            else
                            {
                                Console.WriteLine("wrong path");
                            }
                        }

                    }
                    

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
                    try
                    {
                        Console.WriteLine(input.Remove(0, 5));
                    }
                    catch (System.Exception e)
                    {
                        Console.WriteLine(e);
                    }


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

                    case "-c":

                        if (Islastcd)
                        {
                            var b = input.Remove(0, input.IndexOf(arg) + 3);
                            var c = System.IO.File.Create(lastcd + @"\" + b); c.Close();
                        }
                        else
                        {
                            var b = input.Remove(0, input.IndexOf(arg) + 3);
                            var c = System.IO.File.Create(b); c.Close();
                        }

                        break;

                    case "-d":
                        if (Islastcd)
                        {
                            var b = input.Remove(0, input.IndexOf(arg) + 3);
                            System.IO.File.Delete(lastcd + @"\" + b);

                        }
                        else
                        {
                            System.IO.File.Delete(path);
                        }
                        break;
                    case "-e":
                        if (Islastcd)
                        {
                            var b = input.Remove(0, input.IndexOf(arg) + 3);
                            System.IO.File.Encrypt(lastcd + @"\" + b);

                        }
                        else
                        {
                            var b = input.Remove(0, input.IndexOf(arg) + 3);
                            System.IO.File.Encrypt(b);
                        }
                        break;

                    case "-t":
                        if (Islastcd)
                        {
                            var b = input.Remove(0, input.IndexOf(arg) + 3);
                            System.IO.File.Decrypt(lastcd + @"\" + b);

                        }
                        else
                        {
                            var b = input.Remove(0, input.IndexOf(arg) + 3);
                            System.IO.File.Decrypt(b);
                        }
                        break;

                    case "-r":
                        if (Islastcd)
                        {
                            var b = input.Remove(0, input.IndexOf(arg) + 3);
                            Console.WriteLine(System.IO.File.ReadAllText(lastcd + @"\" + b));


                        }
                        else
                        {
                            var b = input.Remove(0, input.IndexOf(arg) + 3);
                            Console.WriteLine(System.IO.File.ReadAllText(b));
                        }
                        break;

                    case "-w":
                        if (Islastcd)
                        {
                            var b = input.Remove(0, input.IndexOf(arg) + 3);
                            var bd = input.Remove(0, input.IndexOf(arg2));
                            System.IO.File.WriteAllText(lastcd + @"\" + b, bd);


                        }
                        else
                        {
                            var b = input.Remove(0, input.IndexOf(arg) + 3);
                            var bd = input.Remove(0, input.IndexOf(arg2));
                            System.IO.File.WriteAllText(b, bd);


                        }
                        break;

                    case "-m":
                        if (Islastcd)
                        {
                            var b = input.Remove(0, input.IndexOf(arg) + 3);
                            var bd = input.Remove(0, input.IndexOf(arg2));
                            moveFile(lastcd + @"\" + b, bd);

                        }
                        else
                        {
                            var b = input.Remove(0, input.IndexOf(arg) + 3);
                            var bd = input.Remove(0, input.IndexOf(arg2));
                            moveFile(b, bd);
                        }
                        break;

                    case "-p":
                        if (Islastcd)
                        {
                            var b = input.Remove(0, input.IndexOf(arg) + 3);
                            System.IO.File.Copy(lastcd + @"\" + b, input.Remove(0, input.IndexOf(arg2)));
                        }
                        else
                        {
                            var b = input.Remove(0, input.IndexOf(arg) + 3);
                            System.IO.File.Copy(b, input.Remove(0, input.IndexOf(arg2)));
                        }


                        break;


                }


            }
            catch (System.Exception e)
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
        private static void showhistory() { if (term_history != "") Console.WriteLine("Your terminal session history: \n" + term_history); }

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
                if (Islastcd)
                {
                    if (input.Split(' ').Skip(1).FirstOrDefault() == "-a")
                    {
                        DirectorySearch(lastcd);

                    }
                    else if (input.Split(' ').Skip(1).FirstOrDefault() == "-s")
                    {
                        string[] fileArray = Directory.GetDirectories(lastcd);

                        for (int i = 0; i < fileArray.Length; i++)
                        {

                            Console.WriteLine(fileArray[i]);
                        }

                    }
                    else
                    {
                        Console.WriteLine("argument " + input.Split(' ').Skip(1).FirstOrDefault() + " was not found");
                    }
                }
                else
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
            }

            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}