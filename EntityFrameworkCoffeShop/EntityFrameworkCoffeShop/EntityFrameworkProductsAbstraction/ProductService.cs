﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spectre.Console;

namespace EntityFrameworkCoffeeShop.EntityFrameworkProductsAbstraction
{
    public class ProductService
    {
        public static Product GetProductOptionInput()
        {
            var products = ProductController.GetAllProducts();
            var productsArray = products.Select(x => x.Name).ToArray();
            
            var option = AnsiConsole.Prompt(new SelectionPrompt<string>()
                .Title("Choose product")!
                .AddChoices(productsArray));


            var id = products.Single(x => x.Name == option).Id;
            var product = GetProductById(id);
            
            return product;
        }

        public static Product GetProductById(int id)
            => new ProductsContext().Products.SingleOrDefault(x => x.Id == id)
               ?? new Product();
    }
}
