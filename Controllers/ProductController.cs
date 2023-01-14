using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Shop_MVC.Data;

using ShopMVC.Models;

namespace Shop_MVC.Controllers
    {
    public class ProductController : Controller
        {
        List<Shop> shopAll = DataShop.value;
    





        // GET: ProductController
        public ActionResult IndexAll()
            {
            return View("Index",  shopAll.SelectMany(q=>q.Categorys).SelectMany(w=>w.Products));

            
            }

        // GET: ProductController
        public ActionResult Index(int id)
            {
            Category category = shopAll.SelectMany(q => q.Categorys).Single(w => w.PrimaryKey == id);




            return View(category.Products);
            }

        // GET: ProductController/Delete/5
        public ActionResult Delete(Product prod)
            {
      Category myCategory =shopAll.SelectMany(q => q.Categorys).Single(w => w.PrimaryKey == prod.CategoryId);
            myCategory.Products.Remove(prod);
            prod.MyCategory = null;

            return RedirectToAction("Index",new {id=myCategory.PrimaryKey } );
            }

















        // GET: ProductController/Details/5
        public ActionResult Details(int id)
            {
            Product product = shopAll.SelectMany(q => q.Categorys).
            SelectMany(w => w.Products).
            Single(e => e.PrimaryKey == id);

            Category category = shopAll.SelectMany(q => q.Categorys).Single(w => w.PrimaryKey == product.CategoryId);
            ViewBag.CategoryName = category.Name;

            return View(product);
            }




        // GET: ProductController/Create
        public ActionResult Create()
            {
            SelectList sl = new SelectList(shopAll.SelectMany(q=>q.Categorys), "PrimaryKey", "Name");
            ViewBag.Category = sl;



            return View();
            }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
            {
            try
                {

                Product temp = new Product();
                Setter.SetValue(temp, collection);
temp.PrimaryKey = DataShop.iProduct++;


                Category category = shopAll.SelectMany(q => q.Categorys).Single(q => q.PrimaryKey == temp.CategoryId);
                category.Products.Add(temp);
                temp.MyCategory = category;
                
                return RedirectToAction(nameof(Index),new {id=temp.CategoryId});
                }
            catch
                {
                return View();
                }
            }

        // GET: ProductController/Edit/5
        public ActionResult Edit(Product prod)
            {

            Category category = shopAll.SelectMany(q => q.Categorys).Single(q => q.PrimaryKey == prod.CategoryId);
            ViewBag.categoryName = category.Name;
            return View(prod);
            }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int PrimaryKey, IFormCollection collection)
            {
            try
                {

Product product = shopAll.SelectMany(q => q.Categorys).SelectMany(w=>w.Products).Single(w => w.PrimaryKey == PrimaryKey);
                Setter.SetValue(product, collection);





                if(collection.ContainsKey("Sale")) {
                    var sale = collection["sale"];
                    if(Int32.TryParse(sale, out int result)) {

                        if(result < 0) {
                            product.Sale = 0;
                        
                        }
                    }
                }




                

                return RedirectToAction(nameof(Index), new { id = product.CategoryId });
                }
            catch
                {
                return View();
                }
            }


        public ActionResult SortedNameAsc()
            {
            List<Product> products = shopAll.SelectMany(q => q.Categorys).SelectMany(w => w.Products).OrderBy(e => e.Name).ToList();
            return View("Index", products);
            }
            public ActionResult SortedNameDesc()
            {
            List<Product> products = shopAll.SelectMany(q => q.Categorys).SelectMany(w => w.Products).OrderByDescending(e => e.Name).ToList();
            return View("Index", products);
            }
            public ActionResult SortedSaleAsc()
            {

            List<Product> products = shopAll.SelectMany(q => q.Categorys).SelectMany(w => w.Products).OrderBy(e => e.Sale).ToList();
            return View("Index", products);
            }
            public ActionResult SortedSaleDesc()
            {
            List<Product> products = shopAll.SelectMany(q => q.Categorys).SelectMany(w => w.Products).OrderByDescending(e => e.Sale).ToList();
            return View("Index", products);
            }
            public ActionResult SortedCatAsc()
            {
            List<Product> products = shopAll.SelectMany(q => q.Categorys).SelectMany(w => w.Products).OrderBy(e => e.CategoryId).ToList();
            return View("Index", products);
            }
            public ActionResult SortedCatDesc()
            {
            List<Product> products = shopAll.SelectMany(q => q.Categorys).SelectMany(w => w.Products).OrderByDescending(e => e.CategoryId).ToList();
            return View("Index", products);
            }















        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
            {
            try
                {
                return RedirectToAction(nameof(Index));
                }
            catch
                {
                return View();
                }
            }
        }
    }
