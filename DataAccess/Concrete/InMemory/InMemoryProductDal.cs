using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
	public class InMemoryProductDal : IProductDal
	{
		List<Product> _products;
		public InMemoryProductDal()
		{
			_products = new List<Product> 
			{
				new Product{ProductId=1,CategoryId=1,ProductName="Bardak",UnitPrice=15,UnitsInStock=15},
				new Product{ProductId=2,CategoryId=1,ProductName="Kamera",UnitPrice=200,UnitsInStock=8},
				new Product{ProductId=3,CategoryId=2,ProductName="Mouse",UnitPrice=150,UnitsInStock=9},
				new Product{ProductId=4,CategoryId=2,ProductName="Telefon",UnitPrice=140,UnitsInStock=14},
				new Product{ProductId=5,CategoryId=2,ProductName="Klavye",UnitPrice=63,UnitsInStock=12}
			};
		}
		public void Add(Product product)
		{
			_products.Add(product);
		}

		public void Delete(Product product)
		{
			//LINQ - Language Integrated Query

			/*
			Product productToDelete;
			
			 * foreach (var p in _products)
			{
				if (product.ProductId== p.ProductId)
				{
					productToDelete = p;
				}
			}
			*/

			Product productToDelete = _products.SingleOrDefault(p=>p.ProductId==product.ProductId); //yukarıdaki foreach döngüsü yerine yazdık, bu kısım daha kullanışlı

			_products.Remove(productToDelete);
	    }

		public List<Product> GetAll()
		{
			return _products;
		}

		public void Update(Product product)
		{
			//gönderdiğim ürün ıd sine sahip olan listedeki id sine sahip ürünü bul
			Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);

			productToUpdate.ProductName = product.ProductName;
			productToUpdate.CategoryId = product.CategoryId;
			product.UnitPrice = product.UnitPrice;
			product.UnitsInStock = product.UnitsInStock;
		}
		public List<Product> GetAllByCategory(int categoryId)
		{
			return _products.Where(p => p.CategoryId == categoryId).ToList();
		}

		public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
		{
			throw new NotImplementedException();
		}

		public Product Get(Expression<Func<Product, bool>> filter)
		{
			throw new NotImplementedException();
		}

		public List<ProductDetailDto> GetProductDetails()
		{
			throw new NotImplementedException();
		}
	}
}
