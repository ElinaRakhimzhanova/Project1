using System.Collections.Generic;
using System.Linq;
using System;

public class MainScreen
{
    public static List<Account> friends;
    public static List<Friendship> requests;
    public static void DrawProfile(Account account)
    {
        System.Console.WriteLine("Welcome");

        // System.Console.WriteLine(account.Id);
        // System.Console.WriteLine(account.Login);
        // System.Console.WriteLine(account.Password);
        // System.Console.WriteLine(account.Surname);
        // System.Console.WriteLine(account.Name);

        var frds = AccountStore.accounts
            .Where(x => x.Id == account.Id)
            .Join(FriendshipStore.friendships,
                x => x.Id,
                y => y.SecondFriend,
                (x, y) => x).ToList();

        friends = AccountStore.accounts.Join(FriendshipStore.friendships.Where(x => x.FirstFriend == account.Id),
            x => x.Id,
            y => y.SecondFriend,
            (x, y) => x).ToList();

        // foreach (var item in friends)
        // {
        //     System.Console.WriteLine(item.Id + " " + item.Name);
        // }

        requests = RequestStore.requests.Where(x => x.FirstFriend == account.Id).ToList();
        // requests.Where(x=>x.SecondFriend ==)
        Console.CursorVisible = false;
        ConsoleKeyInfo btn;
        // foreach (var item in requests)
        // {
        //     System.Console.WriteLine(item.FirstFriend + " " +  item.SecondFriend);
        // }
        int cnt = 0;
        while (btn.Key != ConsoleKey.Escape)
        {
            draw(cnt);
            
            switch (btn.Key)
            {
                case ConsoleKey.UpArrow:
                    if(cnt > 0)
                        cnt--;
                    break;
                case ConsoleKey.DownArrow:
                    if(cnt < requests.Count - 1)
                        cnt++;
                    break;
                case ConsoleKey.Enter:

                    if (requests.Any())
                    {
                        FriendshipStore.friendships.Add(requests[cnt]);
                        RequestStore.remove(requests.ElementAt(cnt));
                        requests.RemoveAt(cnt);

                    }

                    cnt = 0;
                    break;
            }

            btn = Console.ReadKey();
        }

        // Console.WriteLine("Start");
        // foreach(var item in RequestStore.requests)
        // {
        //     Console.WriteLine(item.FirstFriend + " " + item.SecondFriend);
        // }
        // Console.WriteLine("Finish");

        RequestStore.SaveChanges();
        FriendshipStore.SaveChanges();

    }

    public static void Test()
    {
        RequestStore.InitDb();
        RequestStore.requests.RemoveAt(0);
        RequestStore.SaveChanges();

    }

    static void draw(int cur)
    {
        Console.Clear();
        Console.SetCursorPosition(0, 0);
        for (int i = 0; i < requests.Count(); i++)
        {
            if (cur == i)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.White;
            }

            System.Console.WriteLine(AccountStore.accounts.First(x => x.Id == requests[i].SecondFriend).Name);

        }
    }




}