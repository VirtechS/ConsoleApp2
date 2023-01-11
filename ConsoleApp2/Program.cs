using System;
using System.Collections.Generic;

interface IProduct
{
    string Name { get; }
    int Price { get; }
}

class Product : IProduct
{
    public string Name { get; private set; }
    public int Price { get; private set; }

    public Product(string name, int price)
    {
        this.Name = name;
        this.Price = price;
    }
}

interface ICategory
{
    string Name { get; }
    IEnumerable<IProduct> Products { get; }
}

class ProductCategory : ICategory
{
    public string Name { get; private set; }
    public IEnumerable<IProduct> Products { get; private set; }

    public ProductCategory(string name, IEnumerable<IProduct> products)
    {
        this.Name = name;
        this.Products = products;
    }
}

class Program
{
    private enum CategorySelection
    {
        Мясо = 1,
        Выпечка = 2,
        Напитки = 3,
        Десерт = 4
    }

    private static IProduct DisplayProducts(ICategory productCategory)
    {
        Console.WriteLine("Выберите товар:");
        int i = 0;
        foreach
            (var product in productCategory.Products)
        {
            Console.WriteLine($"{i + 1}. {product.Name} - {product.Price}");
            i++;
        }
        int selectedProduct;
        while (!int.TryParse(Console.ReadLine(), out selectedProduct)
            || selectedProduct < 1 || selectedProduct > i)
        {
            Console.WriteLine("Неизвестный товар, попробуйте еще раз:");
        }

        return productCategory.Products.ElementAt(selectedProduct - 1);
    }

    private static ICategory DisplayCategories(IEnumerable<ICategory> productCategories)
    {
        Console.WriteLine("Выберите категорию:");
        int i = 0;
        foreach (var category in productCategories)
        {
            Console.WriteLine($"{i + 1}. {category.Name}");
            i++;
        }

        int selectedCategory;
        while (!int.TryParse(Console.ReadLine(), out selectedCategory)
            || selectedCategory < 1 || selectedCategory > i)
        {
            Console.WriteLine("Неизвестная категория, попробуйте еще раз:");
        }

        return productCategories.ElementAt(selectedCategory - 1);
    }
    static void Main(string[] args)
    {
        var productCategories = new List<ICategory>
    {
        new ProductCategory("Мясо", new List<IProduct> {
            new Product("Пельмени", 580),
            new Product("Колбаса", 430),
            new Product("Стейк", 230)
        }),
        new ProductCategory("Выпечка", new List<IProduct> {
            new Product("Хлеб", 50),
            new Product("Булка", 70)
        }),
        new ProductCategory("Напитки", new List<IProduct> {
            new Product("Колла", 120),
            new Product("Вода", 100),
            new Product("Сок", 90)
        }),
        new ProductCategory("Десерты", new List<IProduct> {
            new Product("Кекс", 700),
            new Product("Печенье", 350),
            new Product("Тор", 400)
        }),
    };

        var selectedProducts = new List<IProduct>();

        for (int i = 0; i < 3; i++)
        {
            var selectedCategory = DisplayCategories(productCategories);
            var selectedProduct = DisplayProducts(selectedCategory);
            selectedProducts.Add(selectedProduct);
        }

        int totalPrice = 0;

        Console.WriteLine("Чек:");
        for (int i = 0; i < selectedProducts.Count; i++)
        {
            Console.WriteLine(selectedProducts[i].Name + " - " + selectedProducts[i].Price);
            totalPrice += selectedProducts[i].Price;
        }
        Console.WriteLine("Сумма: " + totalPrice + " руб.");

        Console.WriteLine("Нажмите любую клавишу для выхода");
        Console.ReadKey();
    }
}