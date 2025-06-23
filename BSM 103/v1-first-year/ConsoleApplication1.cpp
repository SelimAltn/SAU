/****************************************************************************
** SAKARYA ÜNİVERSİTESİ
** BİLGİSAYAR VE BİLİŞİM BİLİMLERİ FAKÜLTESİ
** BİLGİSAYAR MÜHENDİSLİĞİ BÖLÜMÜ
** PROGRAMLAMAYA GİRİŞİ DERSİ
**
** ÖDEV NUMARASI:1 .
** ÖĞRENCİ ADI : SELİM ALTIN .
** DERS GRUBU : B .
****************************************************************************/
#include <iostream>
#include <string>
#include <cmath>
#include <locale.h>	
#include <ctime>
using namespace std;

struct strağırlık
{
    float  vize, ödevbir, ödeviki, kısasınavbir, kısasınaviki;
};

struct strdeğerlendirilen
{
    float vize, ödevbir, ödeviki, kısasınavbir, kısasınaviki;
    short puanının_geçme_not;
};
struct strbirders
{
    strağırlık ağırlık;
    strdeğerlendirilen değerlendirilen;
};
float koşulbir(int form, int to)
{
    int sayı = form;
    cin >> sayı;
    //-->kullanıcı tarafından girilen bir sayının belirli bir aralıkta olup olmadığını kontrol etmek için kullanılır. 
    while (sayı<form || sayı>to)
    {
        cout << "yalnış sayı girdiniz.\a gerilcek sayı " << form << " ile " << to << " arasında olucaktır . \n ";
        cout << "lütfen tekrar giriniz .";
        cin >> sayı;
    }
    return sayı;
}

void ağırlıklar(strbirders& info)
{
    float sum;
    //-->bu döngü ağırlıklar toplamı 100 olmadığı durumunda tekrar tekrar girilncek .
    do {
        cout << "lütfen vizenin ağırlığnı giriniz : \n";
        info.ağırlık.vize = koşulbir(0, 100);
        cout << "lütfen 1.ödevin ağırlığnı giriniz : \n";
        info.ağırlık.ödevbir = koşulbir(0, 100);
        cout << "lütfen 2.ödevin ağırlığnı giriniz : \n";
        info.ağırlık.ödeviki = koşulbir(0, 100);
        cout << "lütfen 1.kısa sınav ağırlığnı giriniz : \n";
        info.ağırlık.kısasınavbir = koşulbir(0, 100);
        cout << "lütfen 2.kısa saınav ağırlığnı giriniz : \n";
        info.ağırlık.kısasınaviki = koşulbir(0, 100);
        sum = info.ağırlık.vize + info.ağırlık.ödevbir + info.ağırlık.ödeviki + info.ağırlık.kısasınavbir + info.ağırlık.kısasınaviki;

        if (sum != 100)
        {
            cout << "girilcek ağırlıklar toplamı 100 olucaktır \a lütfen tekrar giriniz " << endl;
        }
    } while (sum != 100);
    cout << endl;
    cout << "lütfen Yıl içi puanının geçme notuna etkisi giriniz : " << endl;
    info.değerlendirilen.puanının_geçme_not = koşulbir(0, 100);
}

struct Strisimler
{

    string admatrisi[42] = { "Mehmet","Fatih","Ali","Aras","Can","Esra","Sena","Selin","Tuba","Abdulselam","Doğan","Elif","Mellisa","Serhat","Fatih","Ali","Aras","Can","Esra","Sena","Selin","Tuba","Abdulselam","Doğan","Elif","Mellisa","Serhat" ,"Fatih","Ali","Aras","Can","Esra","Sena","Selin","Tuba","Abdulselam","Doğan","Elif","Mellisa","Serhat" };
    string soyadmatrisi[37] = { "Kaya","Dağlar","Yılmaz","Aslan","Kaya","Özdemir","Yüksel","Acar","Akkoç","Aytaç","Bozoğlu","Kaplan","Demir" ,"Dağlar","Yılmaz","Aslan","Kaya","Özdemir","Yüksel","Acar","Akkoç","Aytaç","Bozoğlu","Kaplan","Demir" ,"Dağlar","Yılmaz","Aslan","Kaya","Özdemir","Yüksel","Acar","Akkoç","Aytaç","Bozoğlu","Kaplan","Demir" };
};

struct ISIMLER
{
    string ad;
    string soyad;
};

Strisimler strisimler;

void  rastgele_puan(strbirders& info, int& öğrenci_sayısı)
{
    int yüzdeyirmi, yüzdeelli, yuzdeotuz, rastgelepuan;
    yüzdeyirmi = öğrenci_sayısı * 0.20;
    rastgelepuan = öğrenci_sayısı;
    yüzdeelli = öğrenci_sayısı * 0.50;
    yuzdeotuz = öğrenci_sayısı * 0.30;
    float enBuyukNot = 100.0, enKucukNot = 0.0;
    float öğrencininortalama = 0.0, sınıf_ortalaması = 0.0;
    float* basariNotu = new float[öğrenci_sayısı];

    int AAalansayı = 0, BAalansayı = 0, BBalansayı = 0, CBalansayı = 0, CCalansayı = 0, DCalansayı = 0, DDalansayı = 0, FDalansayı = 0, FFalansayı = 0;
    ISIMLER ogrenci[1000];

    // Döngü: Sınıfın en üst %20'lik dilimindeki öğrenciler için not hesaplaması
    for (int i = 0; i < yüzdeyirmi; i++)
    {
        // Rastgele ad ve soyad atama işlemi
        ogrenci[i].ad = strisimler.admatrisi[rand() % 43];
        ogrenci[i].soyad = strisimler.soyadmatrisi[rand() % 38];
        // Öğrenciye ait vize, ödev ve kısa sınavlar için rastgele notlar atama işlemi
        info.değerlendirilen.vize = rand() % 21 + 80;
        info.değerlendirilen.ödevbir = rand() % 21 + 80;
        info.değerlendirilen.ödeviki = rand() % 21 + 80;
        info.değerlendirilen.kısasınavbir = rand() % 21 + 80;
        info.değerlendirilen.kısasınaviki = rand() % 21 + 80;
        // Öğrencinin adı, soyadı ve atanan notların ekrana yazdırılması
        cout << i + 1 << ".Öğrenci " << endl;
        cout << "Ad Soyad: " << ogrenci[i].ad << " " << ogrenci[i].soyad << endl;
        cout << "vize puanı = " << info.değerlendirilen.vize << endl;
        cout << "1.ödevin puanı = " << info.değerlendirilen.ödevbir << endl;
        cout << "2.ödev puanı =" << info.değerlendirilen.ödeviki << endl;
        cout << "1.kısa sınav puanı = " << info.değerlendirilen.kısasınavbir << endl;
        cout << "2.kısa sınav puanı = " << info.değerlendirilen.kısasınaviki << endl;
        // Öğrencinin dönem içi ortalamasının hesaplanması
        öğrencininortalama = ((info.değerlendirilen.vize * info.ağırlık.vize) / 100 +
            (info.değerlendirilen.ödevbir * info.ağırlık.ödevbir) / 100 +
            (info.değerlendirilen.ödeviki * info.ağırlık.ödeviki) / 100 +
            (info.değerlendirilen.kısasınavbir * info.ağırlık.kısasınavbir) / 100 +
            (info.değerlendirilen.kısasınaviki * info.ağırlık.kısasınaviki) / 100);
        // Ortalama puanın ekrana yazdırılması ve en yüksek/en düşük notların güncellenmesi
        cout << "öğrencini ortalaması = " << öğrencininortalama << endl;
        if (öğrencininortalama > enKucukNot)
        {
            enKucukNot = öğrencininortalama;
        }
        if (öğrencininortalama < enBuyukNot)
        {
            enBuyukNot = öğrencininortalama;
        };
        // Sınıf ortalamasının güncellenmesi
        sınıf_ortalaması += öğrencininortalama;

        basariNotu[i] = öğrencininortalama;

        // Öğrencinin notuna göre harf notunun belirlenmesi

        if (öğrencininortalama >= 90.00)
        {
            cout << "AA" << endl; AAalansayı++;
        }
        else if (öğrencininortalama >= 85.00)
        {
            cout << "BA" << endl; BAalansayı++;
        }
        else if (öğrencininortalama >= 80.00)
        {
            cout << "BB" << endl; BBalansayı++;
        }
        else if (öğrencininortalama >= 75.00)
        {
            cout << "CB" << endl; CBalansayı++;
        }
        else if (öğrencininortalama >= 65.00)
        {
            cout << "CC" << endl; CCalansayı++;
        }
        else if (öğrencininortalama >= 58.00)
        {
            cout << "DC" << endl; DCalansayı++;
        }
        else if (öğrencininortalama >= 50.00)
        {
            cout << "DD" << endl; DDalansayı++;
        }
        else if (öğrencininortalama >= 40.00)
        {
            cout << "FD" << endl; FDalansayı++;
        }
        else
        {
            cout << "FF" << endl; FFalansayı++;
        }
        // Öğrencinin geçme/kalma durumunun kontrolü ve ekrana yazdırılması
        if (öğrencininortalama <= info.değerlendirilen.puanının_geçme_not)
        {
            cout << "öğrenci derste kaldı, seneye bekleriz (: \n";
        }
        else { cout << "öğrenci  dersten geçti \n "; }


        cout << "-----------------------------------------" << endl;
    };
    // Döngü: Sınıfın %20 ile %50 arasındaki öğrencileri için not hesaplaması
    for (int i = yüzdeyirmi; i < yüzdeelli; i++)
    {
        // Öğrencilere orta seviye notlar atama işlemi
        info.değerlendirilen.vize = rand() % 31 + 50;
        info.değerlendirilen.ödevbir = rand() % 31 + 50;
        info.değerlendirilen.ödeviki = rand() % 31 + 50;
        info.değerlendirilen.kısasınavbir = rand() % 31 + 50;
        info.değerlendirilen.kısasınaviki = rand() % 31 + 50;

        // Öğrencilere rastgele ad ve soyad atama işlemi
        ogrenci[i].ad = strisimler.admatrisi[rand() % 43];
        ogrenci[i].soyad = strisimler.soyadmatrisi[rand() % 38];
        // Öğrencinin adı, soyadı ve atanan notların ekrana yazdırılması
        cout << i + 1 << ".Öğrenci " << endl;
        cout << "Ad Soyad: " << ogrenci[i].ad << " " << ogrenci[i].soyad << endl;
        cout << "vize puanı = " << info.değerlendirilen.vize << endl;
        cout << "1.ödevin puanı = " << info.değerlendirilen.ödevbir << endl;
        cout << "2.ödev puanı = " << info.değerlendirilen.ödeviki << endl;
        cout << "1.kısa sınav puanı = " << info.değerlendirilen.kısasınavbir << endl;
        cout << "2.kısa sınav puanı = " << info.değerlendirilen.kısasınaviki << endl;
        // Öğrencinin dönem içi ortalamasının hesaplanması
        öğrencininortalama = ((info.değerlendirilen.vize * info.ağırlık.vize) / 100 +
            (info.değerlendirilen.ödevbir * info.ağırlık.ödevbir) / 100 +
            (info.değerlendirilen.ödeviki * info.ağırlık.ödeviki) / 100 +
            (info.değerlendirilen.kısasınavbir * info.ağırlık.kısasınavbir) / 100 +
            (info.değerlendirilen.kısasınaviki * info.ağırlık.kısasınaviki) / 100);
        cout << "öğrencini ortalaması = " << öğrencininortalama << endl;
        // Ortalama puanın ekrana yazdırılması ve en yüksek/en düşük notların güncellenmesi
        if (öğrencininortalama > enKucukNot)
        {
            enKucukNot = öğrencininortalama;
        }
        if (öğrencininortalama < enBuyukNot)
        {
            enBuyukNot = öğrencininortalama;
        };
        // Sınıf ortalamasının güncellenmesi
        sınıf_ortalaması += öğrencininortalama;

        basariNotu[i] = öğrencininortalama;

        // Öğrencinin notuna göre harf notunun belirlenmesi ve ilgili sayacın artırılması
        if (öğrencininortalama >= 90.00)
        {
            cout << "AA" << endl; AAalansayı++;
        }
        else if (öğrencininortalama >= 85.00)
        {
            cout << "BA" << endl; BAalansayı++;
        }
        else if (öğrencininortalama >= 80.00)
        {
            cout << "BB" << endl; BBalansayı++;
        }
        else if (öğrencininortalama >= 75.00)
        {
            cout << "CB" << endl; CBalansayı++;
        }
        else if (öğrencininortalama >= 65.00)
        {
            cout << "CC" << endl; CCalansayı++;
        }
        else if (öğrencininortalama >= 58.00)
        {
            cout << "DC" << endl; DCalansayı++;
        }
        else if (öğrencininortalama >= 50.00)
        {
            cout << "DD" << endl; DDalansayı++;
        }
        else if (öğrencininortalama >= 40.00)
        {
            cout << "FD" << endl; FDalansayı++;
        }
        else
        {
            cout << "FF" << endl; FFalansayı++;
        }
        // Öğrencinin geçme/kalma durumunun kontrolü ve ekrana yazdırılması
        if (öğrencininortalama <= info.değerlendirilen.puanının_geçme_not)
        {
            cout << "öğrenci derste kaldı, seneye bekleriz (: \n";
        }
        else { cout << "öğrenci  dersten geçti \n "; }
        cout << "-----------------------------------------" << endl;


    };

    // Döngü: Sınıfın %50 ile %100 arasındaki öğrencileri için not hesaplaması
    for (int i = yüzdeelli; i < öğrenci_sayısı; i++)
    {
        // Öğrencilere düşük seviye notlar atama işlemi
        info.değerlendirilen.vize = rand() % 51;
        info.değerlendirilen.ödevbir = rand() % 51;
        info.değerlendirilen.ödeviki = rand() % 51;
        info.değerlendirilen.kısasınavbir = rand() % 51;
        info.değerlendirilen.kısasınaviki = rand() % 51;
        // Öğrencilere rastgele ad ve soyad atama işlemi
        ogrenci[i].ad = strisimler.admatrisi[rand() % 43];
        ogrenci[i].soyad = strisimler.soyadmatrisi[rand() % 38];
        // Öğrencinin adı, soyadı ve atanan notların ekrana yazdırılması
        cout << i + 1 << ".Öğrenci " << endl;
        cout << "Ad Soyad: " << ogrenci[i].ad << " " << ogrenci[i].soyad << endl;
        cout << "vize puanı = " << info.değerlendirilen.vize << endl;
        cout << "1.ödevin puanı = " << info.değerlendirilen.ödevbir << endl;
        cout << "2.ödev puanı = " << info.değerlendirilen.ödeviki << endl;
        cout << "1.kısa sınav puanı = " << info.değerlendirilen.kısasınavbir << endl;
        cout << "2.kısa sınav puanı = " << info.değerlendirilen.kısasınaviki << endl;
        // Öğrencinin dönem içi ortalamasının hesaplanması
        öğrencininortalama = ((info.değerlendirilen.vize * info.ağırlık.vize) / 100 +
            (info.değerlendirilen.ödevbir * info.ağırlık.ödevbir) / 100 +
            (info.değerlendirilen.ödeviki * info.ağırlık.ödeviki) / 100 +
            (info.değerlendirilen.kısasınavbir * info.ağırlık.kısasınavbir) / 100 +
            (info.değerlendirilen.kısasınaviki * info.ağırlık.kısasınaviki) / 100);
        // Ortalama puanın ekrana yazdırılması ve en yüksek/en düşük notların güncellenmesi
        cout << "öğrencini ortalaması = " << öğrencininortalama << endl;

        if (öğrencininortalama > enKucukNot)
        {
            enBuyukNot = öğrencininortalama;
        }
        if (öğrencininortalama < enBuyukNot)
        {
            enBuyukNot = öğrencininortalama;
        };
        // Sınıf ortalamasının güncellenmesi
        sınıf_ortalaması += öğrencininortalama;

        basariNotu[i] = öğrencininortalama;





        // Öğrencinin notuna göre harf notunun belirlenmesi ve ilgili sayacın artırılması
        if (öğrencininortalama >= 90.00)
        {
            cout << "AA" << endl; AAalansayı++;
        }
        else if (öğrencininortalama >= 85.00)
        {
            cout << "BA" << endl; BAalansayı++;
        }
        else if (öğrencininortalama >= 80.00)
        {
            cout << "BB" << endl; BBalansayı++;
        }
        else if (öğrencininortalama >= 75.00)
        {
            cout << "CB" << endl; CBalansayı++;
        }
        else if (öğrencininortalama >= 65.00)
        {
            cout << "CC" << endl; CCalansayı++;
        }
        else if (öğrencininortalama >= 58.00)
        {
            cout << "DC" << endl; DCalansayı++;
        }
        else if (öğrencininortalama >= 50.00)
        {
            cout << "DD" << endl; DDalansayı++;
        }
        else if (öğrencininortalama >= 40.00)
        {
            cout << "FD" << endl; FDalansayı++;
        }
        else
        {
            cout << "FF" << endl; FFalansayı++;
        }
        // Öğrencinin geçme/kalma durumunun kontrolü ve ekrana yazdırılması
        if (öğrencininortalama <= info.değerlendirilen.puanının_geçme_not)
        {
            cout << "öğrenci derste kaldı, seneye bekleriz (: \n";
        }
        else { cout << "öğrenci  dersten geçti \n "; }
        cout << "-----------------------------------------" << endl;
    };
    float sinifOrtalamasi = sınıf_ortalaması / öğrenci_sayısı;

    float standartSapma = 0.0;


    for (int i = 0; i < öğrenci_sayısı; i++)
    {
        standartSapma += pow(basariNotu[i] - sinifOrtalamasi, 2);
    };

    cout << "sınıfın ortalaması = " << sinifOrtalamasi << endl;

    cout << "En büyük not :" << enKucukNot << endl;
    cout << "Standart sapmasi = " << sqrt(standartSapma / (öğrenci_sayısı - 1)) << endl;
    cout << "En küçük not :" << enBuyukNot << endl;
    cout << "AA alan sayısı   = " << AAalansayı << "\t\t";
    cout << "AA sınıf yüzdesi = " << (static_cast<double>(AAalansayı) / öğrenci_sayısı) * 100 << "%" << endl;
    cout << "BA alan sayısı   = " << BAalansayı << "\t\t";
    cout << "BA sınıf yüzdesi = " << (static_cast<double>(BAalansayı) / öğrenci_sayısı) * 100 << "%" << endl;
    cout << "BB alan sayısı   = " << BBalansayı << "\t\t";
    cout << "BB sınıf yüzdesi = " << (static_cast<double>(BBalansayı) / öğrenci_sayısı) * 100 << "%" << endl;
    cout << "CB alan sayısı   = " << CBalansayı << "\t\t";
    cout << "CB sınıf yüzdesi = " << (static_cast<double>(CBalansayı) / öğrenci_sayısı) * 100 << "%" << endl;
    cout << "CC alan sayısı   = " << CCalansayı << "\t\t";
    cout << "CC sınıf yüzdesi = " << (static_cast<double>(CCalansayı) / öğrenci_sayısı) * 100 << "%" << endl;
    cout << "DC alan sayısı   = " << DCalansayı << "\t\t";
    cout << "DC sınıf yüzdesi = " << (static_cast<double>(DCalansayı) / öğrenci_sayısı) * 100 << "%" << endl;
    cout << "DD alan sayısı   = " << DDalansayı << "\t\t";
    cout << "DD sınıf yüzdesi = " << (static_cast<double>(DDalansayı) / öğrenci_sayısı) * 100 << "%" << endl;
    cout << "FD alan sayısı   = " << FDalansayı << "\t\t";
    cout << "FD sınıf yüzdesi = " << (static_cast<double>(FDalansayı) / öğrenci_sayısı) * 100 << "%" << endl;
    cout << "FF alan sayısı   = " << FFalansayı << "\t\t";
    cout << "FF sınıf yüzdesi = " << (static_cast<double>(FFalansayı) / öğrenci_sayısı) * 100 << "%" << endl;

}

int main()
{
    srand(time(0));
    setlocale(LC_ALL, "Turkish");

    strbirders info;
    int ogrenciSayisi;

    cout << "Lütfen Öğrenci Sayısı Giriniz : " << endl;
    cin >> ogrenciSayisi;


    ağırlıklar(info);
    rastgele_puan(info, ogrenciSayisi);

    return 0;

}