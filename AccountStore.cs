using System.Linq;
using Project1;
using CsvHelper;
using System.Collections.Generic;
using System.IO;
using System;
public class AccountStore
{
    public AccountStore()
    {
        InitDb();

    }
    static public List<Account> accounts {get;set;}
    public static void InitDb()
    {
        using (var sr = new StreamReader(@"new.csv"))
        {
           
                var reader = new CsvReader(sr);
                accounts = new List<Account>();
                accounts = reader.GetRecords<Account>().ToList();
       
        }
    }
    // public void AddAccount(){
    // }
    
    public static Account FindUser(string name, string password)
    {
        return accounts.FirstOrDefault(x => x.Name == name && x.Password == password);
    }
}