using System;
using System.IO;

namespace module1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\nWelcome to the ticketing system!");
            
            string file = "Tickets.csv";
            string choice;
            
            do
            {
                // select menu option
                Console.WriteLine("\n1) Read data from file.");
                Console.WriteLine("2) Create or append file from data.");
                Console.WriteLine("Enter any other key to exit.");

                // input menu choice
                choice = Console.ReadLine();

                // read data from file
                if (choice == "1")
                {
                    // read data from file
                    if (File.Exists(file))
                    {
                        // title
                        Console.WriteLine("\nList of Tickets\n");

                        StreamReader sr = new StreamReader(file);
                        while (!sr.EndOfStream)
                        {
                            // read first line of information
                            string line = sr.ReadLine();

                            // convert string to array
                            string[] arr = line.Split(',', '|');

                            // display ticket information
                            Console.WriteLine("TicketID: {0}\n" + 
                                "Summary: {1}\n" + 
                                "Status: {2}\n" + 
                                "Priority: {3}\n" +
                                "Submitter: {4}\n" +
                                "Assigned: {5}\n" +
                                "Watching: {6}, {7}, {8}\n", 
                                arr[0], arr[1], arr[2], arr[3], 
                                arr[4], arr[5], arr[6], arr[7], arr[8]);
                        }
                        sr.Close();
                    }
                    else
                    {
                        Console.WriteLine("\nFile does not exist.\n");
                    }
                }

                // create file from data
                else if (choice == "2")
                {
                    
                    StreamWriter sw = new StreamWriter(file, append: true);

                    string response;
                    do 
                    {
                        // add ticket?
                        Console.WriteLine("\nEnter a ticket (Y/N)?");
                        response = Console.ReadLine().ToUpper();

                        // end loop if not adding ticket
                        if (response != "Y") { break; }

                        

                        // TicketID
                        Console.WriteLine("What is the ticket ID?");
                        string ticketID = Console.ReadLine();

                        // Summary
                        Console.WriteLine("What is the summary?");
                        string summary = Console.ReadLine();
                        
                        // Status
                        Console.WriteLine("What is the status?");
                        string status = Console.ReadLine();
                        
                        // Priority
                        Console.WriteLine("What is the priority?");
                        string priority = Console.ReadLine();
                        
                        // Submitter
                        Console.WriteLine("Who is the submitter?");
                        string submitter = Console.ReadLine();
                        
                        // Assigned
                        Console.WriteLine("Who is assinged?");
                        string assigned = Console.ReadLine();
                        
                        // Watching 1
                        Console.WriteLine("Who is the first person watching?");
                        string watching1 = Console.ReadLine();
                        
                        // Watching 2
                        Console.WriteLine("Who is the second person watching?");
                        string watching2 = Console.ReadLine();
                        
                        // Watching 3
                        Console.WriteLine("Who is the third person watching?");
                        string watching3 = Console.ReadLine();
                        
                        // write line to file
                        sw.WriteLine("{0},{1},{2},{3},{4},{5},{6}|{7}|{8}", 
                        ticketID, summary, status, priority, submitter, assigned, 
                        watching1, watching2, watching3);

                        // add line for formatting 
                        Console.WriteLine("");
                    } while (response == "Y");
                    sw.Close();
                    
                }
            } while (choice == "1" || choice == "2");

            Console.WriteLine("\nGoodbye.\n");
        }
    }
}
