using PersonalContactList.Domain.Entities;
using PersonalContactList.Infra.Data.Repositories;
using PersonalContactList.MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PersonalContactList.MVC.Controllers
{
    public class CategoryController : Controller
    {
        private readonly CategoryRepository _categoryRepository = new CategoryRepository();

        // GET: Category
        public ActionResult Index()
        {
            //retrieve data 
            IEnumerable<Category> categoriesFromBase = _categoryRepository.FindAll();

            //do the manual parse
            List<CategoryViewModel> categoriesToView = new List<CategoryViewModel>();
            foreach(Category category in categoriesFromBase)
            {
                categoriesToView.Add(new CategoryViewModel
                {
                    CategoryID = category.CategoryID,
                    CategoryName = category.CategoryName,
                    EspecialCategory = category.EspecialCategory
                });
            }
            
            return View(categoriesToView);
        }

        // GET: Category/Details/5
        public ActionResult Details(int id)
        {
            Category categoryFromBase = _categoryRepository.FindById(id);
            CategoryViewModel categoryViewModel = new CategoryViewModel
            {
                CategoryID = categoryFromBase.CategoryID,
                CategoryName = categoryFromBase.CategoryName,
                EspecialCategory = categoryFromBase.EspecialCategory
            };
            return View(categoryViewModel);
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Category/Create
        [HttpPost]
        public ActionResult Create(CategoryViewModel categoryViewModel)
        {
            Category categoryToBase = new Category
            {
                CategoryName = categoryViewModel.CategoryName,
                EspecialCategory = categoryViewModel.EspecialCategory
            };
            _categoryRepository.Add(categoryToBase);

            return RedirectToAction("Index");
        }

        // GET: Category/Edit/5
        public ActionResult Edit(int id)
        {
            Category categoryFromBase = _categoryRepository.FindById(id);
            CategoryViewModel categoryViewModel = new CategoryViewModel
            {
                CategoryName = categoryFromBase.CategoryName,
                EspecialCategory = categoryFromBase.EspecialCategory
            };
            return View(categoryViewModel);
        }

        // POST: Category/Edit/5
        [HttpPut]
        public ActionResult Edit(int id, CategoryViewModel categoryViewModel)
        {
            Category category = _categoryRepository.FindById(id);
            category.CategoryName = categoryViewModel.CategoryName;
            category.EspecialCategory = categoryViewModel.EspecialCategory;
            _categoryRepository.Update(category);

            return RedirectToAction("Index");
        }

        // GET: Category/Delete/5
        public ActionResult Delete(int id)
        {
            Category categoryFromBase = _categoryRepository.FindById(id);
            CategoryViewModel categoryViewModel = new CategoryViewModel
            {
                CategoryName = categoryFromBase.CategoryName,
                EspecialCategory = categoryFromBase.EspecialCategory
            };
            return View(categoryViewModel);

        }

        // POST: Category/Delete/5
        [HttpDelete]
        public ActionResult Delete(int id, CategoryViewModel categoryViewModel)
        {
            Category categoryToBase = _categoryRepository.FindById(id);
            _categoryRepository.Delete(categoryToBase);

            return RedirectToAction("Index");
           
        }
    }
}
