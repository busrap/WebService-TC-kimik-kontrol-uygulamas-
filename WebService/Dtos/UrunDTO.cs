using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebService.Dtos
{
    public class UrunDTO
    {
        //DTO= Data Transfer Object

        [Key]
        public int UrunID { get; set; }

        [Required]
        [StringLength(40)]
        public string UrunAdi { get; set; }

        public int? TedarikciID { get; set; }

        public int? KategoriID { get; set; }

        [StringLength(20)]
        public string BirimdekiMiktar { get; set; }

        [Column(TypeName = "money")]
        public decimal? Fiyat { get; set; }

        public short? Stok { get; set; }

        public short? YeniSatis { get; set; }

        public short? EnAzYenidenSatisMikatari { get; set; }

        public bool Sonlandi { get; set; }

    }
}