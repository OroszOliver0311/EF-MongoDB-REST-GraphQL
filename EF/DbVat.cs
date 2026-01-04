using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ef
{
    [Table("VAT")]
    public class DbVat
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int Percentage { get; set; }
        public List<DbProduct> Products { get; set; }
    }
}
