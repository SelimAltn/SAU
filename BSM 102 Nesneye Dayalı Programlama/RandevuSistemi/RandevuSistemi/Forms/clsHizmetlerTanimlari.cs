using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace RandevuSistemi.Forms
{
    public class clsHizmetlerTanimlari 
    {
        public BindingList<clsHizmetler> lsHizmet = new BindingList<clsHizmetler>();
      
        public void CilitBakimi(clsHizmetler cilitbakimi)
        {
         
            lsHizmet.Add(cilitbakimi);
            cilitbakimi.Adi = "Cilt Bakımı";
            cilitbakimi.Bilgi1 = " Cilt yüzeyindeki kir,\n yağ ve makyaj kalıntılarının uzaklaştırılması \niçin özel temizleyiciler kullanılır. \nBu adım cildi temizler ve hazırlar.";
            cilitbakimi.Bilgi2 = " Buhar, cildi nemlendirir \nve gözeneklerin açılmasını sağlar.\n Bu, cildin daha derinlemesine temizlenmesine \nve diğer ürünlerin etkisinin artmasına yardımcı olur.";
            cilitbakimi.Bilgi3 = " Yüz ve boyun bölgesine yapılan masaj,\n kan dolaşımını artırır, \nkasları rahatlatır ve\n cildin genç ve canlı\n görünmesini sağlar.\r\nMaske Uygulaması: \nCildin ihtiyacına göre seçilen özel maskeler,\n cildi besler, nemlendirir,\n canlandırır veya tedavi eder.";
            cilitbakimi.yanHizmet1 = "Yüz Temizleme:";
            cilitbakimi.yanHizmet2 = "Buhar:";
            cilitbakimi.yanHizmet3 = "Masaj ve Maske Uygulaması:";
           

        }
        public void Makyaj(clsHizmetler makyaj)
        {
            lsHizmet.Add(makyaj);
            makyaj.Adi = "Makyaj";
            makyaj.Bilgi1 = "Doğal ve hafif bir makyaj uygulamasıdır,\n günlük kullanım için idealdir.";
            makyaj.Bilgi2 = " Daha belirgin ve dikkat çekici bir makyaj uygulamasıdır,\n özel davetler veya etkinlikler için tercih edilir.";
            makyaj.Bilgi3 = "Gelinlere özel olarak tasarlanmış makyaj uygulamasıdır,\n gelinlik ve tema renklerine\n uygun olarak yapılır.";
            makyaj.yanHizmet1 = "Gündelik Makyaj:";
            makyaj.yanHizmet2 = "Özel Etkinlikler İçin Makyaj:";
            makyaj.yanHizmet3 = "Gelin Makyajı:";


        }
        public void SacBakimi(clsHizmetler sac)
        {
            lsHizmet.Add(sac);
            sac.Adi = "Saç Bakımı";
            sac.Bilgi1 = " Saçın istenilen şekle ve uzunluğa göre\n kesilmesi işlemidir.";
            sac.Bilgi2 = "Saçın istenilen renge boyanması\n veya renk tonunun değiştirilmesi işlemidir.";
            sac.Bilgi3 = " Saçın dalgalandırılması veya kıvırcık\n hale getirilmesi işlemidir.";
            sac.yanHizmet1 = "Kesim: ";
            sac.yanHizmet2 = "Renklendirme:";
            sac.yanHizmet3 = "Perma:";

        }
        
        public void Manikur(clsHizmetler manikur)
        {
            lsHizmet.Add(manikur);
            manikur.Adi = "Manikür ve Pedikür:";
            manikur.Bilgi1 = "Tırnakların şekillendirilmesi,\n törpülenmesi ve cilalanması işlemidir.";
            manikur.Bilgi2 = "Tırnaklara oje veya tırnak cilası uygulanması işlemidir.";
            manikur.Bilgi3 = " Ölü deri ve kalınlaşmış deri tabakası,\n özel dosya ve aletler kullanılarak\n nazikçe temizlenir ve \ntopuk kremleri uygulanarak nemlendirilir.";
            manikur.yanHizmet1 = "Tırnak Bakımı: ";
            manikur.yanHizmet2 = "Cila Uygulamaları:";
            manikur.yanHizmet3 = "Topuk Bakımı: ";


        }
        public void Epilisyon(clsHizmetler epilisyon)
        {    
            lsHizmet.Add(epilisyon);
            epilisyon.Adi = "Epilasyon ve Ağda";
            epilisyon.Bilgi1 = "Epilasyon: Vücuttaki istenmeyen tüylerin\n kalıcı olarak uzaklaştırılması işlemidir.";
            epilisyon.Bilgi2 = " Vücuttaki istenmeyen tüylerin geçici olarak uzaklaştırılması işlemidir,\n genellikle sıcak veya soğuk ağda kullanılır.";
            epilisyon.Bilgi3 = "  Cildin üst tabakasındaki ölü deri hücrelerinin temizlenmesi\n için kullanılan özel peeling ürünleri ile yapılan uygulamadır.";
            epilisyon.yanHizmet1 = "Epilasyon: ";
            epilisyon.yanHizmet2 = "Ağda:";
            epilisyon.yanHizmet3 = "Vücut Peelingi:";


        } 
        public void Mesaj(clsHizmetler mesaj)
        {   
            lsHizmet.Add(mesaj);
            mesaj.Adi = "Masaj Terapisi:";
            mesaj.Bilgi1 = " Vücuttaki kasları gevşetmek, stresi azaltmak ve\n genel rahatlama sağlamak amacıyla yapılan masaj türüdür.";
            mesaj.Bilgi2 = "  Sırt bölgesine özel olarak uygulanan masaj,\n sırt kaslarını gevşetir,\n ağrıları azaltır ve stresi giderir.";
            mesaj.Bilgi3 = "  Bitkisel yağlar kullanılarak yapılan masajdır,\n hem fiziksel hem de duygusal rahatlama sağlar.";
            mesaj.yanHizmet1 = "Vücut Masajı:";
            mesaj.yanHizmet2 = "Sırt Masajı:";
            mesaj.yanHizmet3 = "Aromaterapi Masajı: ";


        }
        public void Kirpik(clsHizmetler kirpik)
        {
            lsHizmet.Add(kirpik);
            kirpik.Adi = "Kaş ve Kirpik Bakımı:";
            kirpik.Bilgi1 = "  Kaşların istenilen şekle göre düzeltilmesi\n veya şekillendirilmesi işlemidir.";
            kirpik.Bilgi2 = "  Kaşların renklendirilmesi veya daha \nbelirgin hale getirilmesi işlemidir.";
            kirpik.Bilgi3 = "   Kirpiklerin kıvrılarak daha belirgin\n hale getirilmesi işlemidir.\nKirpiklerin uzatılması ve dolgunlaştırılması için \nyapay kirpiklerin uygulanması işlemidir.";
            kirpik.yanHizmet1 = "Kaş Şekillendirme:";
            kirpik.yanHizmet2 = "Kaş Boyama:";
            kirpik.yanHizmet3 = "Kirpik Kıvırma Ve Uzatma: ";


        }
        public void Bronz(clsHizmetler bronz)
        {
            lsHizmet.Add(bronz);
            bronz.Adi = "Güneşlenme ve Bronzlaşma:";
            bronz.Bilgi1 = "  Sunağın yapay olarak \noluşturulduğu cihazlarda güneşlenme işlemidir.\r\n";
            bronz.Bilgi2 = "  Ciltte bronz bir renk elde etmek için\n bronzlaşma kremi veya sprey kullanılması işlemidir.";
            bronz.Bilgi3 = "   ,Ciltteki nem dengesini korurken bronz bir görünüm elde etmek\n isteyen müşteriler için ideal bir seçenektir.";
            bronz.yanHizmet1 = "Solaryum: ";
            bronz.yanHizmet2 = "Bronzlaşma:";
            bronz.yanHizmet3 = "Doğal bronzlaşma maskeleri: ";


        }
        public void Danisma(clsHizmetler danisma)
        {
           lsHizmet.Add(danisma);
           danisma.Adi = "Güzellik Bakımı Konsültasyonu:";
           danisma.Bilgi1 = "  Müşterilerin cilt tipi, saç yapısı,\nmakyaj tercihleri ve kişisel stil hakkında uzman görüşü \n" +
           "alabilecekleri bir danışmanlık hizmetidir.\nUzmanlar, müşterilerin ihtiyaçlarını belirleyerek\n en uygun bakım ve makyaj yöntemlerini önerirler";

        }





    }
}
