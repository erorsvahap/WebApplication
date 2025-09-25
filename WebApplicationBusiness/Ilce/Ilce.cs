using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplicationBusiness.Ilce
{
    public class Ilce
    {
        public Ilce() { }
        public string IlceAd { get; set; }
        public int IlceId { get; set; }
        public int IlId { get; set; }
        // farklı property kullanımları istersen set ve get leri kontroler seklınde yazımı 
        //    private string _ilceAd;
        //    private int _ilceId;
        //    private int _ilId;

        //    public string IlceAd
        //    {
        //        get { return _ilceAd; }
        //        set
        //        {
        //            if (!string.IsNullOrEmpty(value))
        //                _ilceAd = value;
        //            else
        //                _ilceAd = "Bilinmiyor"; // boş olmasın diye kontrol
        //        }
        //    }

        //    public int IlceId
        //    {
        //        get { return _ilceId; }
        //        set
        //        {
        //            if (value > 0)
        //                _ilceId = value;
        //        }
        //    }

        //    public int IlId
        //    {
        //        get { return _ilId; }
        //        set
        //        {
        //            if (value > 0)
        //                _ilId = value;
        //        }
        //    }


    }
}
    

