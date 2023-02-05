using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace Project
{
    class Program
    {
        static void Main(string[] args)
        {
            MenuGenerator();

        }
        
        public static void MenuGenerator()
        {

            char menuAnswer = 'a';

            while (menuAnswer != 'q')
            {
                Console.WriteLine("Welcome to the WCTC Ticketing System Menu");
                Console.WriteLine("1. Review Ticket Log");
                Console.WriteLine("2. Create New Ticket");
                Console.WriteLine(".........................................");
                Console.Write("Please Enter Menu Number (q for quit): ");
                menuAnswer = Console.ReadLine().ToLower()[0];

                if (menuAnswer == '1')
                {
                    ReadFile();
                }

                else if (menuAnswer == '2')
                {
                    NewTicket();
                }
                else if (menuAnswer == 'q')
                {
                    Exit();
                }
                else
                {
                    Console.WriteLine("\n\n");
                    Console.WriteLine("Try again\n\n");
                }
                    
            }
        }
        public static void ReadFile()
        {

            string fs = "Files/tickets.csv";
            if (File.Exists(fs))
                
            {
                FileStream file = new FileStream("Files/tickets.csv", FileMode.OpenOrCreate, FileAccess.ReadWrite);
                StreamReader sr = new StreamReader(file);
                var line = sr.ReadLine();

                Console.WriteLine($"TicketID, Summary, Status, Priority, Submitter, Assigned, Watching");
                while (!sr.EndOfStream)

                {
                    
                    line = sr.ReadLine();
                    string[] column = line.Split(',');

                    
                    Console.WriteLine(
                        "{0}, {1}, {2}, {3}, {4}, {5}, {6}",
                        column[0], column[1], column[2], column[3], column[4], column[5], column[6]);

                }
                sr.Close();
                file.Close();
                
            }
            else
            {
                Console.WriteLine("No List.");
            }

            
        }

        public static void NewTicket()
        {
            FileStream fileTicketNum = new FileStream("Files/tickets.csv", FileMode.OpenOrCreate, FileAccess.ReadWrite);
                  StreamReader sr = new StreamReader(fileTicketNum);
                  string line = sr.ReadLine();  
                  //To get last ticket number
                    var lastLine = "";
                    while (sr.EndOfStream == false)
                    {
                        lastLine = sr.ReadLine();
                    }
                    var columnSplitForId = lastLine.Split(',');
                    var ticketId = columnSplitForId[0];
                    int nextTicketId = Convert.ToInt32(ticketId) + 1;
                    sr.Close();
                    fileTicketNum.Close();

                    
                    Console.WriteLine("\n\n");
                    Console.WriteLine("Enter Summary: ");
                    var summary = Console.ReadLine();
                    Console.WriteLine("Enter Status (Open/Closed/Hold): ");
                    var status = Console.ReadLine();
                    Console.WriteLine("Enter Priority (High/Medium/Low): ");
                    var priority = Console.ReadLine();
                    Console.WriteLine("Enter Submitter Name (First Last): ");
                    var submitter = Console.ReadLine();
                    Console.WriteLine("Enter Assignee Name (First Last): ");
                    var assigned = Console.ReadLine();
                    string watchingIndividual = "";
                    string watching = "";

                    while (watchingIndividual != "done")
                    {
                        Console.WriteLine("Enter Team Members Watching Name (First Last) Type done to quit: ");
                         watchingIndividual = Console.ReadLine().ToLower();
                         if (watchingIndividual != "done")
                         {
                             watching = watching + watchingIndividual + "|";
                         }
                         else
                         {

                         }
                    }
                    
                    FileStream file = new FileStream("Files/tickets.csv", FileMode.Append, FileAccess.Write);

                    //write file
                   StreamWriter sw = new StreamWriter(file);
                

                    string newTicket = nextTicketId + "," + summary + "," +status + "," + priority +
                                       "," + submitter + "," + assigned + "," + watching;
                   


                    
                    sw.WriteLine(newTicket);
                    sw.Flush();
                    sw.Close();
                    file.Close();

                    Console.WriteLine("Ticket Added");
        }

        public static void Exit()
        {
            
            Console.WriteLine("\n\n");
            Console.WriteLine("Thank you for using the WCTC Ticketing System");
        }

    }
}