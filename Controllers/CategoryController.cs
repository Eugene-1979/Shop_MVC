using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Shop_MVC.Data;

using ShopMVC.Models;

namespace Shop_MVC.Controllers
    {
    public class CategoryController : Controller
        {
        List<Shop> shopAll = DataShop.value;
       




        public ActionResult IndexAll()
            {
            List<Category> categories = shopAll.SelectMany(q=>q.Categorys).ToList();

            return View("Index",categories);
            }



        // GET: HomeController
        public ActionResult Index(int id)
            {
            Shop shop = shopAll.Single(q => q.PrimaryKey == id);
            ViewBag.Shopid = id;
            return View(shop.Categorys);
            }


        // GET: HomeController/Delete/5
        public ActionResult Delete(Category cat)
            {
            Shop shop = shopAll.Single(q => q.PrimaryKey == cat.ShopId);








            
            Category category = shop.Categorys.First(q => q.PrimaryKey == cat.PrimaryKey);
Console.WriteLine(cat.GetHashCode());
            Console.WriteLine(category.GetHashCode());
            /*  Console.WriteLine(category.Equals(cat));
              Console.WriteLine(cat.Equals(category));*/
            Console.WriteLine(shop.Categorys.Contains(category));
            Console.WriteLine(shop.Categorys.Contains(cat));
        


             shop.Categorys.Remove(cat);






            cat.MyShop = null;

            return View("Index",shop.Categorys);
            }








        // GET: HomeController/Details/5
        public ActionResult Details(int id)
            {
            Category cat = shopAll.SelectMany(q => q.Categorys).Single(w => w.PrimaryKey == id);
            Shop shop = shopAll.Single(q => q.PrimaryKey == cat.ShopId);
            ViewBag.shopName = shop.Name;

            return View(cat);
            }

     /*   public ActionResult Detailsid()
            {
            

            return RedirectToAction("Details",category);
            }*/


        // GET: HomeController/Create
        public ActionResult Create()
            {

            
            SelectList sl = new SelectList(shopAll, "PrimaryKey", "Name");
            ViewBag.Shops =sl;
            return View();
            }

        // POST: HomeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
            {
            try
                {
                Category temp = new Category();
                Setter.SetValue(temp, collection);
                Shop shop = shopAll.Single(q=>q.PrimaryKey==temp.ShopId);
                shop.Categorys.Add(temp);
                temp.MyShop= shop;
                temp.PrimaryKey = DataShop.iCategory++;


                return View(nameof(Index),shop.Categorys);
                }
            catch
                {
                return View();
                }
            }

        // GET: HomeController/Edit/5
        public ActionResult Edit(Category cat)
            {
           ViewBag.ShopName=shopAll.Single(q => q.PrimaryKey == cat.ShopId).Name;
            return View(cat);
            }

        // POST: HomeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int PrimaryKey, IFormCollection collection)
            {
            try
                {

                Category category = shopAll.SelectMany(q => q.Categorys).Single(w => w.PrimaryKey == PrimaryKey);
                Setter.SetValue(category, collection);


                return RedirectToAction(nameof(Index),new {id=category.ShopId });
                }
            catch
                {
                return View();
                }
            }







        public ActionResult IndexAllNameAsc(int id)
            {
            List<Category> categories = null;
            
if(id == 0) {categories= shopAll.SelectMany(q => q.Categorys).OrderBy(q => q.Name).ToList(); }
            else { categories = shopAll.Single(q=>q.PrimaryKey==id).Categorys.OrderBy(q => q.Name).ToList(); }      
            return View("Index", categories);
            }



        public ActionResult IndexAllNameDesc(int id)
            {
            List<Category> categories = null;
            if(id == 0) { categories = shopAll.SelectMany(q => q.Categorys).OrderByDescending(q => q.Name).ToList(); }
            else { categories = shopAll.Single(q => q.PrimaryKey == id).Categorys.OrderByDescending(q => q.Name).ToList(); }
            return View("Index", categories);
            }




        public ActionResult IndexAllShopidAsc(int id)
            {
            List<Category> categories = null;
            if(id == 0) { categories = shopAll.SelectMany(q => q.Categorys).OrderBy(q => q.ShopId).ToList(); }
            else { categories = shopAll.Single(q => q.PrimaryKey == id).Categorys.OrderBy(q => q.ShopId).ToList(); }
            return View("Index", categories);
            }
        public ActionResult IndexAllShopidDesc(int id)
            {
            List<Category> categories = null;
            if(id == 0) { categories = shopAll.SelectMany(q => q.Categorys).OrderByDescending(q => q.ShopId).ToList(); }
            else { categories = shopAll.Single(q => q.PrimaryKey == id).Categorys.OrderByDescending(q => q.ShopId).ToList(); }
            return View("Index", categories);
            }



























        // POST: HomeController/Delete/5
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
