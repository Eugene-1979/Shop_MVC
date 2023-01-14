using Shop_MVC.Models;

namespace ShopMVC.Models
    {
    public class Shop : AbstractCategory, IEquatable<Shop?>
        {
      /*  public int PrimaryKey { get; set; }
        public string Name { get; set; }*/

public List<Category> Categorys { get; set; }=new List<Category>();

        public override bool Equals(object? obj)
            {
            return Equals(obj as Shop);
            }

        public bool Equals(Shop? other)
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
