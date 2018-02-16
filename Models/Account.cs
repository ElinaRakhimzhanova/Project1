using System;
using System.Collections.Generic;


    public class Account
    {
        public String  Name {get;set;}
        public String  Surname { get; set;}

        public String Login { get; set;}
        public String Password { get; set;}
        
        public int Id {get;set;}
        //List<Group> groups;
        // List<Account> friends;

    public override bool Equals(object obj)
    {
        var item = obj as Account;

        if (item == null)
        {
            return false;
        }

        return this.Password.Equals(item.Password);
    }

    public override int GetHashCode()
    {
        return this.Password.GetHashCode();
    }


    }

