using System.Linq;
using Project1;
using CsvHelper;
using System.Collections.Generic;
using System.IO;
using System;

public class Friendship{
    public int FirstFriend { get; set;}
    public int SecondFriend { get;set;}

     public override bool Equals(object obj)
    {
        var item = obj as Friendship;

        if (item == null)
        {
            return false;
        }

        return this.FirstFriend == item.FirstFriend && this.SecondFriend == item.SecondFriend;
    }

    public override int GetHashCode()
    {
        return this.FirstFriend.GetHashCode();
    }
}

public class FriendshipStore {

    // public static List<Friendship> GetRequestCollection(){
        
    //     return 
    // }
     public static List<Friendship> friendships {get;set;}

    public static void InitDb(){
        using (var sr = new StreamReader(@"friendships.csv"))
        {
           
                var reader = new CsvReader(sr);
                friendships = new List<Friendship>();
                friendships = reader.GetRecords<Friendship>().ToList();
            
        }
    }
    public static void SaveChanges(){
        using (var writer = new StreamWriter("friendships.csv"))
        {
            using (var csvWriter = new CsvWriter(writer))
            {
                csvWriter.Configuration.Delimiter = ",";
               
                csvWriter.WriteRecords(friendships);
            }
        }
    }   //public static List<Friendship> GetCollection(){}
}