using System.Linq;
using Project1;
using CsvHelper;
using System.Collections.Generic;
using System.IO;
using System;
public class RequestStore
{
    public RequestStore()
    {
        InitDb();

    }
    static public List<Friendship> requests {get;set;}
    public static void InitDb()
    {
        using (var sr = new StreamReader(@"requests.csv"))
        {
           
                var reader = new CsvReader(sr);
                requests = new List<Friendship>();
                requests = reader.GetRecords<Friendship>().ToList();
       
        }
    } 
    public static void SaveChanges(){
        
        using (var writer = new StreamWriter("requests.csv"))
        {
            using (var csvWriter = new CsvWriter(writer))
            {
                csvWriter.Configuration.Delimiter = ",";
               
                csvWriter.WriteRecords(requests);
            }
        }
    }
    public static void remove(Friendship elem){
        requests.Remove(elem);
    }
}