using Shop_MVC.Models;

namespace ShopMVC.Models
    {
    public class Category :AbstractCategory, IEquatable<Category?>
        {

        public List<Product> Products { get; set; } = new List<Product>();
      /*  public int PrimaryKey { get; set; }
        public string? Name { get; set; }*/
        public int ShopId { get; set; }

        public Shop MyShop { get; set; }

        public override bool Equals(object? obj)
            {
            return Equals(obj as Category);
            }

        public bool Equals(Category? other)
            {
            return other is not null &&
                   PrimaryKey == other.PrimaryKey;
            }

        public override int GetHashCode()
            {
            return HashCode.Combine(PrimaryKey);
            }
        }
    }
