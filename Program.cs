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
            Console.CursorVisible = false;
            ConsoleKeyInfo btn;
            var cur = 0;
            while (true)
            {
                Console.Clear();
                // System.Console.WriteLine(cur);
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

                    case ConsoleKey.Enter:
                        if (cur == 0)
                        {
                            Console.Clear();
                            System.Console.WriteLine(cur);
                            Console.WriteLine("Pishi,sup");
                            string name = Console.ReadLine();
                            Console.Clear();
                            System.Console.WriteLine("Pishi familiyu");
                            string surname = Console.ReadLine();
                            // Console.Clear();
                            // System.Console.WriteLine("Pishi familiyu");
                            // string login = Console.ReadLine();
                            // Console.Clear();
                            // System.Console.WriteLine("Pishi password");
                            // string password = Console.ReadLine();
                            using (var writer = new StreamWriter("new.csv", true))
                            {
                                using (var csvWriter = new CsvWriter(writer))
                                {
                                    csvWriter.Configuration.Delimiter = ",";
                                    csvWriter.WriteField(name);
                                    csvWriter.WriteField(surname);
                                    //csvWriter.WriteField(password);
                                    csvWriter.NextRecord();

                                }
                            }
                        }
                        else
                        {
                            Console.Clear();
                            System.Console.WriteLine(cur);
                            Console.WriteLine("Pishi,sup");
                            string login = Console.ReadLine();
                            Console.Clear();
                            System.Console.WriteLine("Pishi password");
                            string password = Console.ReadLine();
                            using (var sr = new StreamReader(@"new.csv"))
                            {
                                using (var sw = new StreamWriter(@"countrylistoutput.csv"))
                                {
                                    var reader = new CsvReader(sr);

                                    IEnumerable <DataRecord> records = reader.GetRecords<DataRecord>().ToList();
                                    DataRecord dt = new DataRecord { Name = login, Surname = password};
                                    //DataRecord sdt = new DataRecord { Name = login, Surname = password};
                                    System.Console.WriteLine(records.Contains(dt, new StudentComparer()));
                                    Console.ReadKey();
                                }
                            }
                        }
                        break;

                }
            }
        }
    }
}