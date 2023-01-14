using Shop_MVC.Models;

namespace ShopMVC.Models
    {
    public class Product : AbstractCategory, IEquatable<Product?>
        {

      /*  public int PrimaryKey { get; set; }
        public string? Name { get; set; }*/
        public int Sale { get; set; }



       

        public int CategoryId { get; set; }
        public Category MyCategory { get; set; }

        public override bool Equals(object? obj)
            {
            return Equals(obj as Product);
            }

        public bool Equals(Product? other)
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
