using System.ComponentModel.DataAnnotations.Schema;

namespace ef
{
    [Table("Product")]
    public class DbProduct
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }

        [ForeignKey("VatID")]
        public DbVat Vat { get; set; }
       
        public int VatID { get; set; }
    }
}
