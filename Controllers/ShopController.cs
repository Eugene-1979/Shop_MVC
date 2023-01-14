using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop_MVC.Data;

using ShopMVC.Models;


namespace Shop_MVC.Controllers
{
    public class ShopController : Controller
        {
      
        List<Shop> shopAll = DataShop.value;




        // GET: ShopController
        public ActionResult Index()
            {
            return View(shopAll);
            }

        // GET: ShopController/Delete/5
        public ActionResult Delete(int id)
            {

            Shop shop = shopAll.Single(q => q.PrimaryKey == id);
            shopAll.Remove(shop);

            return View("Index",shopAll);
            }


        // GET: ShopController/Details/5
        public ActionResult Details(int id)
            {

            Shop shop = shopAll.Single(q => q.PrimaryKey == id);
            return View(shop);
            }



        // GET: ShopController/Edit/5
        public ActionResult Edit(int id)
            {
            Shop shop = shopAll.Single(q => q.PrimaryKey == id);

            return View(shop);
            }

        // POST: ShopController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
            {
            try
                {
                Shop shop = shopAll.Single(q => q.PrimaryKey == id);

                Setter.SetValue(shop, collection);


                /*   shop.Name=collection.*/



                return RedirectToAction(nameof(Index));
                }
            catch
                {
                return View();
                }
            }






        // GET: ShopController/Create
        public ActionResult Create()
            {
            return View();
            }



        // POST: ShopController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
            {
            try
                {
                Shop shop = new Shop() { PrimaryKey = DataShop.iShop++ };
                Setter.SetValue(shop, collection);
                shopAll.Add(shop);
                return RedirectToAction(nameof(Index));
                }
            catch
                {
                return View();
                }
            }












        public ActionResult IndexAscName()
            {

            List<Shop> shops = shopAll.OrderBy(q => q.Name).ToList();

            return View("Index", shops);
            }  
            public ActionResult IndexDeskName()
            {

            List<Shop> shops = shopAll.OrderByDescending(q => q.Name).ToList();
            return View("Index", shops);
            }






        public ActionResult CategoryAll(int id)
            {

            Shop shop = shopAll.Single(q => q.PrimaryKey == id);
            return View(shop);
            }











        


        // POST: ShopController/Delete/5
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
