using Bogus;


namespace ShopMVC.Models
{
    public static class DataShop
        {
        const int start = 1;

        public static int iShop = start;
        public static int iCategory = start;
        public static int iProduct = start;


        public static int startShop=5;
        public static int startCategory=20;
        public static int startProduct=100;





        public static List<Shop> value=Generate(startShop,startCategory,startProduct); 


        public static List<Shop> Generate(int shopCount, int categoryCount, int productCount) {


            var tshop = new Faker<Shop>()
             .RuleFor(q => q.PrimaryKey, w => iShop++)
             .RuleFor(q => q.Name, q => $"{iShop-1} "+q.Lorem.Word())
             .Generate(shopCount);
          



           var tcategory = new Faker<Category>().
           RuleFor(q => q.PrimaryKey, w => iCategory++)
           .RuleFor(q => q.Name, q => $"{iCategory-1}  "+q.Lorem.Word()).
           RuleFor(q => q.ShopId, (w,categ) => {
               /*return w.Random.Int(start, shopCount);*/

               var temp = w.Random.Int(start, shopCount);
               Shop shop = tshop.Single(shop => shop.PrimaryKey == temp);
              /*---------------------------*/
               shop.Categorys.Add(categ);
               categ.MyShop = shop;
              /* -----------------------------*/
               return temp;
           }).
           Generate(categoryCount);
           


          /* 2 вариант*/
        /*   tcategory.ForEach(q =>
            {                Shop shop = tshop.FirstOrDefault(shop => shop.ShopId == q.ShopId);
                shop.Categorys.Add(q);});*/


          /*  3 вариант*/

           /*   foreach(var itemCat in tcategory)
                   {                  foreach(var itemShop in tshop)
                       {if(itemShop.ShopId == itemCat.ShopId) { itemShop.Categorys.Add(itemCat);
                           break;
                       }}}*/


          



            var tproduct = new Faker<Product>().
         RuleFor(q => q.PrimaryKey, w => iProduct++)
           .RuleFor(q => q.Name, q => $"{iProduct - 1}  "+q.Lorem.Word()).
           RuleFor(q => q.Sale, w => w.Random.Int(0, 10000)).
            RuleFor(q => q.CategoryId, (w,prod) =>
            {

                var temp = w.Random.Int(start, categoryCount);
                Category cat = tcategory.Single(cat => cat.PrimaryKey == temp);
                /*---------------------------------*/
                cat.Products.Add(prod);
                prod.MyCategory = cat;
                /*-----------------------------------*/
          
                return temp;
            }                     
            ).
           Generate(productCount);
            
   
            return tshop;


            }




        }


  

  
    }
