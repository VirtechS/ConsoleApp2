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
    public List<Product> Products { get; set; }

    public ProductCategory(string name, List<Product> products)
    {
        this.Name = name;
        this.Products = products;
    }
}

class Program
{
    //Enum константы категорий
    private enum CategorySelection
    {
        Meat = 1,
        Bakery = 2,
        Beverages = 3,
        Dessert = 4
    }

    // Метод отображения товаров
    private static void DisplayProducts(ProductCategory productCategory)
    {
        Console.WriteLine("Выберите товар:");
        for (int i = 0; i < productCategory.Products.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {productCategory.Products[i].Name} - {productCategory.Products[i].Price}");
        }
    }

    // Метод отображения категорий и возвращения выбора
    private static ProductCategory DisplayCategories(List<ProductCategory> productCategories)
    {
        Console.WriteLine("Выберите категорию:");
        for (int i = 0; i < productCategories.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {productCategories[i].Name}");
        }

        int selectedCategory;
        while (!int.TryParse(Console.ReadLine(), out selectedCategory)
            || !Enum.IsDefined(typeof(CategorySelection), selectedCategory))
        {
            Console.WriteLine("Неизвестная категория, попробуйте еще раз:");
        }

        return productCategories[selectedCategory - 1];
    }

    static void Main(string[] args)
    {
        // Создание категорий
        var productCategories = new List<ProductCategory>
        {
            new ProductCategory("Мясо", new List<Product> {
                new Product("Пельмени", 580),
                new Product("Колбаса", 430),
                new Product("Стейк", 230)
            }),
            new ProductCategory("Выпечка", new List<Product> {
                new Product("Хлеб", 50),
                new Product("Булка", 70)
            }),
            new ProductCategory("Напитки", new List<Product> {
                new Product("Колла", 120),
                new Product("Вода", 100),
                new Product("Сок", 90)
            }),
            new ProductCategory("Десерты", new List<Product> {
                new Product("Кекс", 700),
                new Product("Печенье", 350),
                new Product("Тор", 400)
            }),
        };

        //Создание переменной выбора
        var selectedProducts = new List<Product>();

        //Выбор 3ех продуктов
        for (int i = 0; i < 3; i++)
        {
            var selectedCategory = DisplayCategories(productCategories);
            if (selectedCategory.Products != null)
            {
                DisplayProducts(selectedCategory);

                int selectedProduct;
                while (!int.TryParse(Console.ReadLine(), out selectedProduct)
                    || selectedProduct < 1
                    || selectedProduct > selectedCategory.Products.Count)
                {
                    Console.WriteLine("Неизвестный товар, попробуйте еще раз:");
                }
                selectedProduct--;
                selectedProducts.Add(selectedCategory.Products[selectedProduct]);
            }
        }

        int totalPrice = 0;
        Console.WriteLine("Чек:");
        for (int i = 0; i < selectedProducts.Count; i++)
        {
            Console.WriteLine(selectedProducts[i].Name + " - " + selectedProducts[i].Price);
            totalPrice += selectedProducts[i].Price;
        }
        Console.WriteLine("Сумма: " + totalPrice + " руб.");
    }
}