﻿
using Business.Concrete;
using Business.Constants;
using DataAccess.Concrete.EntityFramework;


public class Program {

   
    static void Main(string[] args)
    {
        ProductTest();
        //CategoryTest();
    }

    public static void CategoryTest()
    {
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        foreach (var category in categoryManager.GetAll())
        {
            Console.WriteLine(category.CategoryName);
        }
        Console.ReadLine();
    }

     public static void ProductTest()
    {
        ProductManager productManager = new ProductManager(new EfProductDal());

        var result = productManager.GetProductDetails();

        if (result.Success == true)
        {

            foreach (var product in productManager.GetProductDetails().Data)
            {
                Console.WriteLine(product.ProductName + "/" + product.CategoryName);

            }
        }
        else {
            Console.WriteLine(result.Message);
        }

       
        Console.ReadLine();
    }
}