﻿using System.Globalization;
using EntityFrameworkCoffeeShop.Models;
using EntityFrameworkCoffeeShop.Services;
using Spectre.Console;

namespace EntityFrameworkCoffeeShop.CoffeeShopMenu;

public static class UserInterface
{

    public static void MainMenu()
    {
        const bool appRunning = true;

        while (appRunning)
        {
            Console.Clear();
            var option = AnsiConsole.Prompt(
                new SelectionPrompt<MenuOptionsEnum>()
                    .Title("Choose the command (1-6)")
                    .AddChoices(
                        MenuOptionsEnum.AddProduct,
                        MenuOptionsEnum.AddCategory,
                        MenuOptionsEnum.ShowAllCategories,
                        MenuOptionsEnum.RemoveProduct,
                        MenuOptionsEnum.UpdateProduct,
                        MenuOptionsEnum.ShowProduct,
                        MenuOptionsEnum.ShowAllProducts,
                        MenuOptionsEnum.Exit));

            switch (option)
            {
                case MenuOptionsEnum.AddProduct:
                    {
                        ProductService.AddProductService();
                        break;
                    }
                case MenuOptionsEnum.AddCategory:
                    {
                        CategoryService.AddCategoryService();
                        break;
                    }
                case MenuOptionsEnum.ShowAllCategories:
                    {
                        CategoryService.ShowAllCategories();
                        break;
                    }
                case MenuOptionsEnum.RemoveProduct:
                    {
                        ProductService.RemoveProductService();
                        break;
                    }
                case MenuOptionsEnum.UpdateProduct:
                    {
                        ProductService.UpdateProductService();
                        break;
                    }
                case MenuOptionsEnum.ShowProduct:
                    {
                        ProductService.ShowProduct();
                        break;
                    }
                case MenuOptionsEnum.ShowAllProducts:
                    {
                        ProductService.ShowAllProducts();
                        break;
                    }
                case MenuOptionsEnum.Exit:
                    {
                        Console.WriteLine("Exiting the app...");
                        Environment.Exit(0);
                        break;
                    }
            }
        }
    }

    public static void ShowProductsTable(List<Product> products)
    {
        var table = new Table();
        table.AddColumn("Id");
        table.AddColumn("Name");
        table.AddColumn("Price");
        table.AddColumn("Category");

        foreach (var product in products)
        {
            
            table.AddRow(
                product.ProductId.ToString(),
                product.Name,
                product.Price.ToString(CultureInfo.CurrentCulture),
                product.Category!.Name
                );
        }

        AnsiConsole.Write(table);

        Console.WriteLine("Enter any key to continue");
        Console.ReadLine();
    }

    public static void ShowProductDetails(Product product)
    {
        var panel = new Panel($"""
                                Id: {product.ProductId} 
                                Name: {product.Name}
                                Price: {product.Price}
                                Category: {product.Category!.Name}
                                """)
        {
            Header = new PanelHeader("Product details"),
            Padding = new Padding(2, 2, 2, 2),
        };

        AnsiConsole.Write(panel);

        Console.WriteLine("Enter any key to continue");
        Console.ReadLine();
    }

    public static void ShowCategoriesTable(List<Category> categories)
    {
        var table = new Table();
        table.AddColumn("Id");
        table.AddColumn("Name");

        foreach (var category in categories)
        {
            table.AddRow(
                category.CategoryId.ToString(),
                category.Name
            );
        }

        AnsiConsole.Write(table);

        Console.WriteLine("Enter any key to continue");
        Console.ReadLine();
    }
}

