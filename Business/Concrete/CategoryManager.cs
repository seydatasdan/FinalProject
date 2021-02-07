using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
	public class CategoryManager : ICategoryService
	{
		ICategoryDal _categoryDal;

		public CategoryManager(ICategoryDal categoryDal)
		{
			_categoryDal = categoryDal;
		}

		public List<Category> GetAll()
		{
			//İş kodları
			return _categoryDal.GetAll();
		}

		//Select * from Categories where CategoryId = 3
		public Category GetById(int categoryID)
		{
			return _categoryDal.Get(c => c.CategoryId == categoryID);
	
		}
	}
}
