using Infrastructure.Models;
using System.Runtime.CompilerServices;

namespace Presentation.ProductApp.Presentation;

public class MenuService
{

    public void OpenMainMenu()
    {
        while (true)
        {
            Console.WriteLine("---- MAIN MENU ----");
            Console.WriteLine("/n 1. Add New Product ");
            Console.WriteLine("/n 2. Show All Products ");
            Console.WriteLine("/n 3.Get Products From File ");
            Console.WriteLine("/n 4. Save Products To File ");
            Console.WriteLine("/n Q. Quit...");

            var menuOption = Console.ReadLine().ToUpperInvariant();

            switch (menuOption)
            {
                case "1":

                    break;

                case "2":

                    break;

                case "3":

                    break;

                case "4":

                    break;

                case "Q":

                    break;
            }
        }
    }
}
