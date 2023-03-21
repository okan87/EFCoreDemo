using System.ComponentModel.DataAnnotations;

namespace EFCoreDemo.Models
{
    public class Kitap
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Type { get; set; }
        public int YazarID { get; set; }
        public virtual Yazar Yazar { get; set; }
    }
}
