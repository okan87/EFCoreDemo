using System.ComponentModel.DataAnnotations;

namespace EFCoreDemo.Models
{
    public class Yazar
    {
        public Yazar()
        {
            Kitaps = new HashSet<Kitap>();
        }

        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public virtual HashSet<Kitap> Kitaps { get; set; }
    }
}
