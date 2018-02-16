using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using CsvHelper;
using Project1;
class LoginScreen{

    public static Account DrawLogin (){

            Console.CursorVisible = false;
            ConsoleKeyInfo btn;
            var cur = 0;
            bool chosen = true;
            while(chosen){
                    Console.Clear();                    
                   if (cur == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    System.Console.WriteLine("registration");
                    Console.ForegroundColor = ConsoleColor.White;
                    System.Console.WriteLine("sinin");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    System.Console.WriteLine("registration");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    System.Console.WriteLine("sinin");
                }
                btn = Console.ReadKey();

                switch (btn.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (cur == 0)
                        {
                            cur = 1;
                        }
                        else cur = 0;
                        break;

                    case ConsoleKey.DownArrow:
                        if (cur == 0)
                        {
                            cur = 1;
                        }
                        else cur = 0;
                        break;

                    case ConsoleKey.Enter : 
                        if(cur==1) {
                            chosen = false; 
                            return LogIn.LogOn();
                        }
                        else{
                            SignUp.CreateAccount();
                        }
                    break;
            }
        }
        return null;
    }
}