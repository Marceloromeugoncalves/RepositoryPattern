# RepositoryPattern

Exemplo de Repository Pattern com C# e Windows Forms

![image](https://user-images.githubusercontent.com/34606551/130065884-8306e90b-a75c-4d5b-8f45-ca158e2c3869.png)

Construção do padrão de projeto Repository Pattern com Dapper utilizando a injeção de dependência. Para a injeção de dependência foi utilizado o Autofac 6.0.0.

```C#
public class Product
{
	public string ProductId {get;set;}
	public string ProductName {get;set;}
	public decimal UnitPrice {get;set;}
	public string Barcode {get;set;}
	public int UnitsInStock {get;set;}
}

public interface IProductRepository
{
	IEnumerable<Product> GetProducts();
	bool Insert(Product product);
	bool Update(Product product);
	bool Delete(string productId);
}

public class ProductRepository : IProductRepository
{
	//Implementar os métodos da interface.
}

public class AppConnection
{
	public static string ConnectionString => ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
}

using System;
using System.Collections.Generic;

namespace WindowsFormsApp1.Models
{
    public class ProductRepository : IProductRepository
    {
        public bool Delete(string productId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetProducts()
        {
			using IDbConnection db = new SqlConnection(AppConnection.ConnectionString)
			{
				if (db.State == ConnectionState.Closed)
				{
					db.Open();
				}

     			        return db.Query<Product>("SELECT ProductId, ProductName, UnitPrice, Barcode, UnitsInStock FROM Products;", commandType: CommandType.Text);
			}
        }

        public bool Insert(Product product)
        {
            throw new NotImplementedException();
        }

        public bool Update(Product product)
        {
            throw new NotImplementedException();
        }
    }
}

public partial class Form1: Form1
{
	IProductRepository _productRepository;
	
	public Form1(IProductRepository productRepository)
	{
		InitializeComponents();
		_productRepository = productRepository;
	}
	
	private void Form1_Load(object sender, EventArgs e)
	{
		dataGridView.DataSource = _productRepository.GetProducts();
		labelTotalRecords.Text = $"Total Records: {dataGridView.RowCount}";
	}
}

//Autofac 6.0.0

static class Program
{
	public static IContainer Container;
	
	static void Main()
	{
		Application.SetHighDpiMode(HighDpiMode.SystemAware);
		Application.EnableVisualStyles();
		Application.SetCompatibleTextRenderDefault(false);
		Container = Configure();
		Application.Run(new Form1(Container.Resolve<IProductRepository>()));
	}
	
	//Settings Dependency Injection
	static IContainer Configure()
	{
		var builder = new ContainerBuildeer();
		builder.RegisterType<ProductRepository>().As<IProductRepository>();
		builder.RegisterType<Form1>();
		return builder.Build();
	}
}
```
