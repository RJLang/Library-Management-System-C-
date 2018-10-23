using System;
using System.Collections.Generic;
using System.Linq;

namespace Library_Management_System_C_
{
    class Program
    {
        public static List<Account> account = new List<Account>();
        static void Main(string[] args)
        {

            Console.WriteLine("Currently Under Construction. Please check back in a few weeks.");


            Console.WriteLine("******************");

            while (true)
            {
                Console.WriteLine("0. Exit");
                Console.WriteLine("1. Create an account");
                Console.WriteLine("2. Print account info");
                Console.WriteLine("3. Add Inventory");
                Console.WriteLine("4. Remove Inventory");
                Console.WriteLine("5. Check out");
                Console.WriteLine("6. Return media");
                Console.WriteLine("%%. etc");
                Console.Write("Please select an option: ");


                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "0":
                        return;
                    case "1":
                        Console.Write("Email Address: ");
                        var emailAddress = Console.ReadLine();
                        Console.Write("Name:");
                        var name = Console.ReadLine();

                        var account = Library.CreateAccount(emailAddress, name);

                        Console.WriteLine($"Account successfully created.");
                        Console.WriteLine($"Your account number is: {account.AccountNumber}");

                        break;
                    case "2":
                        Console.Write("Please enter account number: ");
                        var accountNumber = Convert.ToInt32(Console.ReadLine());

                        var acc = Library.AccountLookup(accountNumber);                       
                        
                        Console.WriteLine("********");
                        Console.WriteLine($"Account Number: {acc.AccountNumber}");
                        Console.WriteLine($"Account Name: {acc.Name}");
                        Console.WriteLine($"Creation Date: {acc.CreatedDate}");
                        Console.WriteLine($"E-Mail Address: {acc.EmailAddress}");
                        Console.WriteLine($"Current Fees: ${acc.Fees}");
                        Console.WriteLine($"Current Holds: {string.Join("`n", acc.Holds)}");
                        Console.WriteLine($"Current Loans: {string.Join("`n", acc.Loans)}");
                        Console.WriteLine("********");
                        
                        break;
                    case "3":
                        Console.WriteLine("Title of new material: ");
                        var title = Console.ReadLine();
                        Console.WriteLine("Number of copies to add: ");
                        var totalCopies = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Account Types: ");
                        var types = Enum.GetNames(typeof(TypeOfMedia));
                        for (var i = 0; i < types.Length; i++)
                        {
                            Console.WriteLine($"{i + 1}. { types[i]}");
                        }
                        Console.Write("Select the media type: ");
                        var typeOption = Convert.ToInt32(Console.ReadLine());
                        var type = (TypeOfMedia)Enum.Parse(typeof(TypeOfMedia), types[typeOption - 1]);

                        Console.Write("Categories: ");
                        var cats = Enum.GetNames(typeof(Categories));
                        for (var i = 0; i < cats.Length; i++)
                        {
                            Console.WriteLine($"{i + 1}. { cats[i]}");
                        }
                        Console.Write("Select the media type: ");
                        var catsOptions = Convert.ToInt32(Console.ReadLine());
                        var category = (Categories)Enum.Parse(typeof(Categories), cats[catsOptions - 1]);

                        Console.WriteLine("Author of material: ");
                        var author = Console.ReadLine();

                        Console.WriteLine("Date of Creation: ");
                        var orginDate = Convert.ToDateTime(Console.ReadLine());


                        var newMedia = Library.AddInv(title, totalCopies, type, category, author, orginDate);

                        Console.WriteLine("********");
                        Console.WriteLine($"Author: {newMedia.Author}");
                        Console.WriteLine($"Total Copies: {newMedia.TotalCopies}");
                        Console.WriteLine($"Category: {newMedia.Category}");
                        Console.WriteLine($"Media ID: {newMedia.ID}");
                        Console.WriteLine($"Creation Date: {newMedia.OrginDate}");
                        Console.WriteLine($"Type: {newMedia.Type}");

                        break;


                    default:
                        break;
                }


            }



            // var media = Library.addInv(1, 1,TypeOfMedia 1, 0, "Sally",DateTime.Now);


            //Console.WriteLine(string.Join("`n",account.Loans));
        }


    }
}


            
