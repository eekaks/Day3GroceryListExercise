using System;
using System.IO;
using System.Text;

namespace Day3GroceryListExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string path = "groceries.txt";
                
                Console.WriteLine("This is your grocery list. What would you like to buy?\n0 to quit. 1 to print list. 'DELETE' to delete your grocery list.\nEnter your item:");
                string userInput = Console.ReadLine();

                if (userInput == "0")
                {
                    break;
                }
                else if (userInput == "DELETE")
                {
                    File.Delete(path);
                }
                else if (userInput == "1")
                {
                    if (File.Exists(path))
                    {
                        using (StreamReader sr = File.OpenText(path))
                        {
                            string line = String.Empty;

                            while ((line = sr.ReadLine()) != null)
                            {
                                Console.WriteLine(line);
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("File doesn't exist.");
                    }
                }
                else
                {
                    if (!File.Exists("groceries.txt"))
                        using (StreamWriter sw = File.CreateText(path))
                        {
                            sw.WriteLine(userInput);
                        }
                    else
                    {
                        using (StreamWriter sw = File.AppendText(path))
                        {
                            sw.WriteLine(userInput);
                        }
                    }
                }
                Console.WriteLine();
            }
        }
        
    }
}
