using System;

class Product
{
    public string Name { get; set; }
    public int Price { get; set; }

    public Product(string name, int price)
    {
        this.Name = name;
        this.Price = price;
    }
}

class ProductCategory
{
    public string Name { get; set; }
    public Product[] Products { get; set; }

    public ProductCategory(string name, Product[] products)
    {
        this.Name = name;
        this.Products = products;
    }
}

class Program
{
    static void Main(string[] args)
    {
        ProductCategory[] productCategories = new ProductCategory[] {
            new ProductCategory("Мясо", new Product[] {
                new Product("Колбаса", 580),
                new Product("Пельмени", 430),
                new Product("Фарш", 230)
            }),
            new ProductCategory("Выпечка", new Product[] {
                new Product("Хлеб", 50),
                new Product("Батон", 70)
            }),
            new ProductCategory("Напитки", new Product[] {
                new Product("Колла", 120),
                new Product("Вода", 100),
                new Product("Сок", 90)
            }),
            new ProductCategory("Десерты", new Product[] {
                new Product("Кекс", 700),
                new Product("Печенье", 350),
                new Product("Торт", 400)
            }),
        };

        Product[] selectedProducts = new Product[3];

        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine("Выберите категорию:");
            for (int j = 0; j < productCategories.Length; j++)
            {
                Console.WriteLine($"{j + 1}. {productCategories[j].Name}");
            }

            int selectedCategory = int.Parse(Console.ReadLine());
            while (selectedCategory < 1 || selectedCategory > productCategories.Length)
            {
                Console.WriteLine("Неизвестная категория, попробуйте еще раз:");
                selectedCategory = int.Parse(Console.ReadLine());
            }
            selectedCategory--;

            Console.WriteLine("Выберите товар:");
            for (int j = 0; j < productCategories[selectedCategory].Products.Length; j++)
            {
                Console.WriteLine($"{j + 1}. {productCategories[selectedCategory].Products[j].Name} - {productCategories[selectedCategory].Products[j].Price}");
            }

            int selectedProduct = int.Parse(Console.ReadLine());
            while (selectedProduct < 1 || selectedProduct > productCategories[selectedCategory].Products.Length)
            {
                Console.WriteLine("Неизвестный товар, попробуйте еще раз:");
                selectedProduct = int.Parse(Console.ReadLine());
            }
            selectedProduct--;

            selectedProducts[i] = productCategories[selectedCategory].Products[selectedProduct];
        }

        int totalPrice = 0;
        Console.WriteLine("Чек:");
        for (int i = 0; i < selectedProducts.Length; i++)
        {
            Console.WriteLine(selectedProducts[i].Name + " - " + selectedProducts[i].Price);
            totalPrice += selectedProducts[i].Price;
        }
        Console.WriteLine("Сумма: " + totalPrice + " руб.");
    }
}