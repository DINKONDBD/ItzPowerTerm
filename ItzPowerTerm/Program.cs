using System;
using NCalc;

namespace ItzPowerTerm // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        public static string usr_input = "";
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
            usr_input = Console.ReadLine();
            switch(usr_input.Split(' ').FirstOrDefault())
            {
                default: Console.WriteLine("Command " + usr_input + " is not exists"); break;
                case "calc":
                    var result = new Expression(usr_input.Split(' ').Skip(1).FirstOrDefault()).Evaluate();
                    Console.WriteLine(result);
                    break;
            }
        }
    }
}