using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WebService
{
    using Models;
    using Dtos;
    using System.Web.Services.Protocols;

    /// <summary>
    /// Summary description for UrunlerServis
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]


    public class UrunlerServis : System.Web.Services.WebService
    {
        //Web Service Uygulaması
        /**
        SOAP Nedir?
            SOAP( Basit Nesne Erişim Protokolu) en temel anlamda, internet üzerinden küçük miktarda bilgileri yada mesajları aktarma protokoludur.
            SOAP mesajları XML formatındadırlar ve  genellikle HTTP(Hyper Text Transfer Protocol) protokolu(bazende TCP/IP) kullanılarak gönderilirler. 
            Burada dikkat edilmesi gereken en önemli durumlardan biri SOAP bizi XML tabanlı kullanıma mecbur bırakır. Bu konuda esnek değildir.
         */
        Model1 ctx = new Model1();

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        public Kimlik KimlikBilgisi { get; set; }


        //Aslında Ürün listesini Urunler Class'ından çekebilirdik fakat Urunler Class'ında Virtual tanımlanmış Proplar mevcut
        //Soap'da(Simple Object Access Protocol) sterilize adilmiş nesne alışverişine izin verilmektedir Virtual tanımlanmış alan olduğu için List<Urunler> den data çekmemiz halinde hata alındı
        //Bunun önüne geçmek için sterilize edilmiş nesneleri barındıran Dtos kalasörü içerisinde ki Classlar oluşturuldu
        //Daha sonrada Urunler Class'ı ile UrunDTO Class'ı lambda exp. yöntemi ile bir birine eşitlendi
        [WebMethod]
        [SoapHeader("KimlikBilgisi")]
        public List<UrunDTO> UrunlerListesi()
        {

            if (KimlikBilgisi.KullaniciAdi=="admin"&&KimlikBilgisi.Parola=="123")
            {
                return ctx.Urunlers.Select(x => new UrunDTO
                {
                    BirimdekiMiktar = x.BirimdekiMiktar,
                    Fiyat = x.Fiyat,
                    EnAzYenidenSatisMikatari = x.EnAzYenidenSatisMikatari,
                    Stok = x.Stok,
                    KategoriID = x.KategoriID,
                    TedarikciID = x.TedarikciID,
                    UrunAdi = x.UrunAdi,
                    UrunID = x.UrunID,
                    YeniSatis = x.YeniSatis,
                    Sonlandi = x.Sonlandi

                }).ToList();

            }
            else
            {
                return null;
            }
          
        }
    }
}
