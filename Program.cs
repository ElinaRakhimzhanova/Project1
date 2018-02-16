using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using CsvHelper;

namespace Project1
{
    class Program
    {
        static void Main(string[] args)
        {
            Account account;

           
           
        //     while ( true){
        //     AccountStore.InitDb();
        //     account = LoginScreen.DrawLogin();
            
        //     Console.ReadKey();
        //    }


            AccountStore.InitDb();
            account = AccountStore.FindUser("fe", "fe");
            FriendshipStore.InitDb();
            // System.Console.WriteLine(FriendshipStore.friendships.First().FirstFriend);
            RequestStore.InitDb();
            MainScreen.DrawProfile(account);
            
            
            // RequestStore.InitDb();
            // RequestStore.remove(new Friendship{ FirstFriend = 1, SecondFriend = 6});
            // RequestStore.SaveChanges();
    }}
}