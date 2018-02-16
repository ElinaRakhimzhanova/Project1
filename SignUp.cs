using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using CsvHelper;

public class SignUp
{
    public static void CreateAccount()
    {
        Console.Clear();
        Console.WriteLine("Pishi,sup");
        string name = Console.ReadLine();
        Console.Clear();
        System.Console.WriteLine("Pishi familiyu");
        string surname = Console.ReadLine();
        Console.Clear();
        System.Console.WriteLine("Pishi login");
        string login = Console.ReadLine();
        Console.Clear();
        System.Console.WriteLine("Pishi password");
        string password = Console.ReadLine();
        using (var writer = new StreamWriter("new.csv", true))
        {
            using (var csvWriter = new CsvWriter(writer))
            {
                csvWriter.Configuration.Delimiter = ",";
                csvWriter.WriteField(name);
                csvWriter.WriteField(surname);
                csvWriter.WriteField(login);
                csvWriter.WriteField(password);
                csvWriter.WriteField(AccountStore.accounts.Count);
                
                csvWriter.NextRecord();
            }
        }
         AccountStore.InitDb();
    }
}