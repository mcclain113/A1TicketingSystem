using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace Project
{
    class Program
    {
        static void Main(string[] args)
        {
          Console.WriteLine("Welcome to the WCTC Ticketing System Menu");
          Console.WriteLine("1. Review Ticket Log");
          Console.WriteLine("2. Create New Ticket");
          Console.WriteLine(".........................................");
          Console.Write("Please Enter Menu Number (q for quit): ");
          var menuAnswer = Console.ReadLine().ToLower()[0];

          while (menuAnswer != 'q')
          {
              
              string fs = "Files/tickets.csv";
             
              
              if (menuAnswer == '1')
              {

                  //read file
                  
                  if (File.Exists(fs))
                  {
                      FileStream file = new FileStream(@"C:\Users\barry\source\A1TicketingSystem\Project\Files\tickets.csv", FileMode.OpenOrCreate, FileAccess.ReadWrite);
                      StreamReader sr = new StreamReader(file);
                      string line = sr.ReadLine();
                      line.Split(',');
                      Console.WriteLine("\n\n");




                        while (!sr.EndOfStream)

                      {
                          line = sr.ReadLine();
                          var column = line.Split(',');

                          Console.WriteLine(
                              "TicketID: {0}, Summary: {1}, Status: {2}, Priority: {3}, Submitter: {4}, Assigned: {5}, Watching: {6}",
                              column[0], column[1], column[2], column[3], column[4], column[5], column[6]);
                      }

                      
                      sr.Close();
                        file.Close();
                  }
                  
                  Console.WriteLine("\n\n");
                  Console.WriteLine("Welcome to the WCTC Ticketing System Menu");
                  Console.WriteLine("1. Review Ticket Log");
                  Console.WriteLine("2. Create New Ticket");
                  Console.WriteLine(".........................................");
                  Console.Write("Please Enter Menu Number (q for quit): ");
                  menuAnswer = Console.ReadLine().ToLower()[0];




              }
              else if (menuAnswer == '2')
              {
                    
                  FileStream fileTicketNum = new FileStream(@"C:\Users\barry\source\A1TicketingSystem\Project\Files\tickets.csv", FileMode.OpenOrCreate, FileAccess.ReadWrite);
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
                    
                    FileStream file = new FileStream(@"C:\Users\barry\source\A1TicketingSystem\Project\Files\tickets.csv", FileMode.Append, FileAccess.Write);

                    //write file
                   StreamWriter sw = new StreamWriter(file);
                

                    string newTicket = nextTicketId + "," + summary + "," +status + "," + priority +
                                       "," + submitter + "," + assigned + "," + watching;
                   


                    
                    sw.WriteLine(newTicket);
                    sw.Flush();
                    sw.Close();
                    file.Close();
                    

                   // File.AppendAllText(@"C:\Users\barry\source\A1TicketingSystem\Project\Files\tickets.csv", newTicket);
  
                    Console.WriteLine("Ticket Added");

                    

                  Console.WriteLine("\n\n");
                  Console.WriteLine("Welcome to the WCTC Ticketing System Menu");
                  Console.WriteLine("1. Review Ticket Log");
                  Console.WriteLine("2. Create New Ticket");
                  Console.WriteLine(".........................................");
                  Console.Write("Please Enter Menu Number (q for quit): ");
                  menuAnswer = Console.ReadLine().ToLower()[0];
              }

              else
              {
                    Console.WriteLine("\n\n");
                    Console.WriteLine("Try again\n\n");
                    Console.WriteLine("Welcome to the WCTC Ticketing System Menu");
                    Console.WriteLine("1. Review Ticket Log");
                    Console.WriteLine("2. Create New Ticket");
                    Console.WriteLine(".........................................");
                    Console.Write("Please Enter Menu Number (q for quit): ");
                    menuAnswer = Console.ReadLine().ToLower()[0];
              }
          }

          Console.WriteLine("\n\n");
          Console.WriteLine("Thank you for using the WCTC Ticketing System");

        }
    }
}