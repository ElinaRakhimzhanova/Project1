using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using CsvHelper;

public class LogIn
{
    public static Account LogOn()
    {
        bool loggingInFinished = true;
        Account logginUser = null;
        while (loggingInFinished)
        {

            Console.Clear();
            Console.WriteLine("Pishi name,sup");
            string login = Console.ReadLine();
            Console.Clear();
            System.Console.WriteLine("Pishi password");
            string password = Console.ReadLine();
            logginUser = AccountStore.FindUser(login, password);
            if (logginUser == null)
            {
                continue;
            }
            
            
            loggingInFinished = false;
            return logginUser;
        }
        return logginUser;
    }
}