/****************************************************************************
** SAKARYA ÜNİVERSİTESİ
** BİLGİSAYAR VE BİLİŞİM BİLİMLERİ FAKÜLTESİ
** BİLGİSAYAR MÜHENDİSLİĞİ BÖLÜMÜ
** PROGRAMLAMAYA GİRİŞİ DERSİ
**
** PROJE 
** ÖĞRENCİ ADI :SELİM ALTIN .
** ÖĞRENCİ NUMARASI :G231210558 .
** DERS GRUBU : B .
****************************************************************************/
#include <iostream>
#include<string>
#include <ctime>
#include<vector>
#include<fstream>
#include<set>

using namespace std;
void GirilenDegiskenDogrulu(int& number)
{
    //Bu fonksiyon, kullanıcıdan alınan bir sayının geçerliliğini kontrol eder.
    while (1)
    {
        cin >> number;
        if (cin.good())
            break;
        else//-->Geçersiz bir giriş olduğunda, kullanıcıya hata mesajı gösterilir
        {
            cout << "Hatalı giriş! Lütfen bir sayı giriniz." << endl;
            // cin akışını temizle
            cin.clear();

            // Hatalı girdiyi atla
            cin.ignore(numeric_limits<streamsize>::max(), '\n');
        }
    }//doğru bir sayı girilene kadar tekrar tekrar değer istenir.

}
int ReadNumber(int form, int to, int& number)
{

    do
    {
        cout << "istediniz işlem numarası giriniz : " << endl;
        GirilenDegiskenDogrulu(number);
        if (number<form || number>to)
            cout << "işlem numarası " << form << "-" << to << " arasında olmak zorunda \n\a";
    } while (number < form || number > to);


    return number;
}

class Takimclass
{
public:
    struct STRtakimBilgileri
    {
        string TakimAdi, Adresi, Telefon = "", Yoneticiİsimi;
        short oyuncuSayisi = 0, puan = 0;
        int takiminKodu;
    };
    // Takım bilgilerini saklamak için bir vektör
    vector<STRtakimBilgileri>takimlarVectoru;
    // Takımlar listesine erişmek için bir metod
    vector<STRtakimBilgileri>& getTakimlar() {
        return takimlarVectoru;
    }
    //takım kodlarını saklamak için kullanır.
    set<int> takimKodlariSET;

    set<string> takimAdresleriSET;

    STRtakimBilgileri TakimOlusturma()
    {
        STRtakimBilgileri yenitakim;
        string sehirler[81] = { "Adana", "Adıyaman", "Afyonkarahisar", "Ağrı", "Amasya", "Ankara", "Antalya", "Artvin",
                                "Aydın", "Balıkesir", "Bilecik", "Bingöl", "Bitlis", "Bolu", "Burdur", "Bursa", "Çanakkale",
                                "Çankırı", "Çorum", "Denizli", "Diyarbakır", "Edirne", "Elazığ", "Erzincan", "Erzurum",
                                "Eskişehir", "Gaziantep", "Giresun", "Gümüşhane", "Hakkâri", "Hatay", "Isparta", "Mersin",
                                "İstanbul", "İzmir", "Kars", "Kastamonu", "Kayseri", "Kırklareli", "Kırşehir", "Kocaeli",
                                "Konya", "Kütahya", "Malatya", "Manisa", "Kahramanmaraş", "Mardin", "Muğla", "Muş",
                                "Nevşehir", "Niğde", "Ordu", "Rize", "Sakarya", "Samsun", "Siirt", "Sinop", "Sivas",
                                "Tekirdağ", "Tokat", "Trabzon", "Tunceli", "Şanlıurfa", "Uşak", "Van", "Yozgat", "Zonguldak",
                                "Aksaray", "Bayburt", "Karaman", "Kırıkkale", "Batman", "Şırnak", "Bartın", "Ardahan",
                                "Iğdır", "Yalova", "Karabük", "Kilis", "Osmaniye", "Düzce" };


        string YoneticiAdi[30]{ "Ahmet", "Mehmet", "Ali", "Hasan", "Hüseyin", "Murat", "Ömer", "Yusuf",
                                "Emre", "Can", "Cem", "Deniz", "Berat", "Burak", "Oğuz", "Kerem",
                                "Baran", "Kaan", "Emir", "Yiğit", "Alper", "Arda", "Ege", "Onur",
                                "Berk", "Taylan", "Cenk", "Doğukan", "Eren", "Sercan" };


        string YoneticiSoyAdi[30]{ "Yılmaz", "Kaya", "Demir", "Şahin", "Çelik", "Yıldız", "Yıldırım", "Öztürk",
                                 "Aydın", "Özdemir", "Arslan", "Doğan", "Kılıç", "Aslan", "Çetin", "Karabulut",
                                 "Korkmaz", "Özer", "Güler", "Şimşek", "Polat", "Durmaz", "Kara", "Koç",
                                 "Tekin", "Aksoy", "Güneş", "Keskin", "Ünal", "Can" };

        int TakimAsmaTuru;
        system("cls");//cmd silen emir
        cout << "Yeni takım oluşturmak üzerindesiniz \n";
        cout << "TAKIM OLUŞTURMA menu : "<<endl;
        cout << "--------------------------------------------------"<<endl;
        cout << "1. otoamatik takım olusturma (rastgele bilgiler)\n";
        cout << "2. normal Takım manuel olarak oluşturma\n  ";
        cout << "--------------------------------------------------"<<endl;
        cout << "Takım olusturma Yontemi Ekleyiniz : (1,2)\n";
    
        ReadNumber(1,2,TakimAsmaTuru);
       
        
        if (TakimAsmaTuru == 1)//-->kullancı 1 seçerse randum ile takım bilgileri kaydedilir 
        {
            do
            {
                // Rastgele bir şehir seç ve takım adını oluştur
                yenitakim.Adresi = sehirler[rand() % 81];
                yenitakim.TakimAdi = yenitakim.Adresi + " SPOR";
            } while (takimAdresleriSET.find(yenitakim.Adresi) != takimAdresleriSET.end()); // Adres benzersiz olana kadar döngüde kal
            takimAdresleriSET.insert(yenitakim.Adresi); // Adresi benzersiz adresler setine ekle

            // Rastgele bir yönetici ismi oluştur
            yenitakim.Yoneticiİsimi = YoneticiAdi[(rand() % 30)] + " " + YoneticiSoyAdi[(rand() % 30)];
            // Rastgele bir telefon numarası oluştur      
            for (int i = 1; i <= 10; i++)
            {
                yenitakim.Telefon += '0' + rand() % 10; //'0'için : 0 ascii göre =48 + randum çıkan değer = randum çıkan değer ascii de . 
            }

            do
            {
                yenitakim.takiminKodu = (rand() % 1000) + 1;

            } while (takimKodlariSET.find(yenitakim.takiminKodu) != takimKodlariSET.end()); // Kod benzersiz olana kadar döngüde kal
            takimKodlariSET.insert(yenitakim.takiminKodu);//Benzersiz kodu sete ekle
            return yenitakim;
        }
        else if (TakimAsmaTuru == 2)
        {
            cout << "Takım adı : " << endl;
            getline(cin >> ws, yenitakim.TakimAdi);
            cout << "Takımın adresi : " << endl;
            cin >> yenitakim.Adresi;
            cout << "Yonetici İsimi   : " << endl;
            cin >> yenitakim.Yoneticiİsimi;
            cout << "Takım Telefon numarası : " << endl;
            cin >> yenitakim.Telefon;
            do
            {
                yenitakim.takiminKodu = (rand() % 1000) + 1;

            } while (takimKodlariSET.find(yenitakim.takiminKodu) != takimKodlariSET.end()); // Kod benzersiz olana kadar döngüde kal
            takimKodlariSET.insert(yenitakim.takiminKodu);//Benzersiz kodu sete ekle
            // Oluşturulan takımı vektöre ekle
            return yenitakim;
        }
    }
    void TakimEkle(STRtakimBilgileri yenitakim)
    {
        // Vektöre yeni takımı ekle
        takimlarVectoru.push_back(yenitakim);
        // Vektördeki takım sayısını ekrana yaz
        cout << takimlarVectoru.size();
        cout << ".Takım eklendi \n";
    }
    void TakimleriListele()
    {
        fstream takimDosyasi;
        // "takim.txt" dosyasını yazma modunda aç
        takimDosyasi.open("takim.txt", ios::out );
        short sayac=0;
        // Vektördeki her bir takım için döngü
        for (const auto& Takim : takimlarVectoru)
        {
            sayac++;
            // Sıra numarası ve takım bilgilerini dosyaya yaz
            takimDosyasi << sayac<< ". : " << endl;
            takimDosyasi << "oluşturmak istediniz takım adı (rastgele seçildi!) : " << Takim.TakimAdi<<endl;
            takimDosyasi << "yonetici adı soy adı : " << Takim.Yoneticiİsimi << endl;
            takimDosyasi << "takım telefon numarası : +90" << Takim.Telefon << endl;
            takimDosyasi << "Takimda oyuncu sayisi : " << Takim.oyuncuSayisi<<endl;
            takimDosyasi << "takmin kodu : " << Takim.takiminKodu << endl;
            takimDosyasi << "-----------------------------------------------\n";
        }
        // Dosyayı kapat
        takimDosyasi.close();
    }
    void TakimleriYazdir()
    {
        system("cls");//cmd silen emir
        short sayac = 0;
        // Vektördeki her bir takım için döngü
        for (const auto& Takim : takimlarVectoru)
        {
            sayac++;
            // Sıra numarası ve takım bilgilerini dosyaya yaz
            cout << sayac << ". : " << endl;
            cout << "oluşturmak istediniz takım adı (rastgele seçildi!) : " << Takim.TakimAdi << endl;
            cout << "yonetici adı soy adı : " << Takim.Yoneticiİsimi << endl;
            cout << "takım telefon numarası : +90" << Takim.Telefon << endl;
            cout << "Takimda oyuncu sayisi : " << Takim.oyuncuSayisi << endl;
            cout << "takmin kodu : " << Takim.takiminKodu << endl;
            cout << "-----------------------------------------------\n";
        }
    }
};
class oyuncularclass 
{
public:
    struct STRoyuncuBilgileri
    {
        string TC, OyuncuAdi, OyuncuSoyAdi, oyundakkiKonumu;
        int oyuncununUcreti, oyuncuKodu;
        string baglaiOlduTakim;
        int baglaiOlduTakimKodu;
        string dogumTarihi;
        short gun, ay, yil;
        int golSayisi = 0;
    };
    // oyuncu bilgilerini saklamak için bir vektör
    vector<STRoyuncuBilgileri>oyuncuVektoru;
    // // Oyuncular listesine erişmek için bir metod
    vector<STRoyuncuBilgileri>& getOyuncuVektoru() {
        return oyuncuVektoru;
    }
    //oyuncu kodlarını saklamak için kullanır.
    set<int> OyuncuKodlariSET;

    STRoyuncuBilgileri OyuncuOlusturma()
    {
        STRoyuncuBilgileri oyuncu;
        string OyuncuAdlar[41]{ "Lionel", "Cristiano", "Neymar", "Kylian", "Robert", "Mohamed", "Virgil", "Kevin",
                              "Sergio", "Luka", "Eden", "Karim", "Luis", "Harry", "Raheem", "Sadio", "Paul",
                              "Antoine", "Alisson", "Thibaut", "Toni", "Gerard", "Ederson", "Kalidou", "Jan",
                              "Sergio", "Frenkie", "Joshua", "Leroy", "Romelu", "Erling", "Jadon", "Kai", "Trent",
                              "Bruno", "Marc-Andre", "Heung-Min", "Riyad", "Phil", "Zlatan","yasin"};


        string OyuncuSoyAdlar[41]{ "Messi", "Ronaldo", "Jr", "Mbappe", "Lewandowski", "Salah", "van Dijk", "De Bruyne",
                                 "Ramos", "Modric", "Hazard", "Benzema", "Suarez", "Kane", "Sterling", "Mane", "Pogba",
                                 "Griezmann", "Becker", "Courtois", "Kroos", "Pique", "Moraes", "Koulibaly", "Oblak",
                                 "Aguero", "de Jong", "Kimmich", "Sane", "Lukaku", "Haaland", "Sancho", "Havertz", "Alexander-Arnold",
                                 "Fernandes", "ter Stegen", "Son", "Mahrez", "Foden", "Ibrahimovic","bonu"};

        string OyuncuKonumlari[15]{ "GK - Goalkeeper","CB - Center Back","LB - Left Back","RB - Right Back","SW - Sweeper","CDM - Central Defensive Midfielder",
                             "CM - Central Midfielder","CAM - Central Attacking Midfielder", "LM - Left Midfielder", "RM - Right Midfielder",
                             "LW - Left Winger","RW - Right Winger","CF - Center Forward", "ST - Striker", "SS - Second Striker" };
        // Rastgele doğum tarihi oluştur
        oyuncu.gun = (rand() % 30) + 1;
        oyuncu.ay = (rand() % 12) + 1;
        oyuncu.yil = (rand() % 26) + 1980;//1980-2005
        oyuncu.dogumTarihi = to_string(oyuncu.gun) + "." + to_string(oyuncu.ay) + "." + to_string(oyuncu.yil);
        
        // Min ve max arasında rastgele bir değer seç. Bu aralık, oyuncunun alabileceği minimum ve maksimum maaşı temsil eder.
        // Rand fonksiyonu ile bu aralıkta bir değer üretilir ve maaş olarak atanır.
        int min = 50000, max = 10000000;
        oyuncu.oyuncununUcreti = (rand() % ((max - min) / 10000 + 1) * 10000);//Örneğin, (10,000,000 - 50,000) / 10,000 = 995, 995 + 1 = 996 1den 995 kadar sonra *10000 yaparız

        // Rastgele pozisyon seç
        oyuncu.oyundakkiKonumu = OyuncuKonumlari[(rand() % 15) ];

        // Rastgele ad ve soyad seç
        oyuncu.OyuncuAdi = OyuncuAdlar      [(rand() % 41) ];
        oyuncu.OyuncuSoyAdi = OyuncuSoyAdlar[(rand() % 41) ];
        
        do
        {
            oyuncu.oyuncuKodu = (rand() % 1000) + 1;
        }while(OyuncuKodlariSET.find(oyuncu.oyuncuKodu) != OyuncuKodlariSET.end()); // Kod benzersiz olana kadar döngüde kal
        OyuncuKodlariSET.insert(oyuncu.oyuncuKodu);// Kodu benzersiz kodlar vectora setine ekle
       
        // Rastgele TC numarası oluştur
        for (int i = 1; i <= 11; i++)
        {
            oyuncu.TC += '1' + rand() % 9; //Aciil gore 1 =49 ve +'1' nedeni bir rakamdan karektere dönüşturmek için kullanırız .
        }
        return oyuncu;
    }
    void OyuncuEkle(STRoyuncuBilgileri yenioyuncu)
    {
        // Vektöre yeni oyuncuyu ekle
        oyuncuVektoru.push_back(yenioyuncu);
        // Vektördeki oyuncu sayısını ekrana yaz
        cout << oyuncuVektoru.size() ;
        cout << ".oyuncu eklendi \n";
    }
    void cokSayidaOyuncuOlusturma()
    {
        int islemTuru;
        cout << "Oyuncu olusturma Menu : \n";
        cout << "------------------------------" << endl;
        cout << "1- bir defada oyuncu olusturma\n";
        cout << "2-tek oyuncu olusturma  \n";
        cout << "------------------------------" << endl;
        cout << "Lutfen seçiniz (1,2)\n";
        ReadNumber(1, 2, islemTuru);
        if (islemTuru == 1)
        {
            int OlusturmakİstediOyuncuSayisi;
            cout << "bir defada kaç oyuncu eklemek istiyorsunuz ? \n";
            GirilenDegiskenDogrulu(OlusturmakİstediOyuncuSayisi);
            for (int i = 1; i <= OlusturmakİstediOyuncuSayisi; i++)
            {
                OyuncuEkle(OyuncuOlusturma());
            }
        }
        else if (islemTuru == 2)
        {
            OyuncuEkle(OyuncuOlusturma());
        }
        
    }
    void OyuncuBilgileriYazdirma()
    {
        fstream futbolcuDosyası;
        // "futbolcu.txt" dosyasını yazma modunda aç
        futbolcuDosyası.open("futbolcu.txt", ios::out);
        short Sayac=0;
        // Vektördeki her bir oyuncu için döngü
        for (const auto& oyuncu : oyuncuVektoru)
        {
            Sayac++;
            
            futbolcuDosyası << Sayac << ". : \n";
            futbolcuDosyası << "oyuncu TC : " << oyuncu.TC << endl;
            futbolcuDosyası << "oyuncu adı : " << oyuncu.OyuncuAdi << endl;
            futbolcuDosyası << "oyuncu soy adı : " << oyuncu.OyuncuSoyAdi << endl;
            futbolcuDosyası << "oyuncu doğum tarihi : " << oyuncu.dogumTarihi << endl;
            futbolcuDosyası << "oyuncu bağlı oldu takım : " << oyuncu.baglaiOlduTakim << endl;
            futbolcuDosyası << "oyundaki konumu : " << oyuncu.oyundakkiKonumu << endl;
            futbolcuDosyası << "oyuncu ucreti : " << oyuncu.oyuncununUcreti << "TL" << endl;
            futbolcuDosyası << "oyuncu kodu : " << oyuncu.oyuncuKodu << endl;
            futbolcuDosyası << "-----------------------------------------------\n";
        }
        // Dosyayı kapat
        futbolcuDosyası.close();
    }
    void oyuncularListeleme()
    {
        short oyuncuSayac = 0;
        system("cls");//cmd silen emir
        // Vektördeki her bir oyuncu için döngü
        for (const auto& oyuncu : oyuncuVektoru)
        {
            oyuncuSayac++;

           cout << oyuncuSayac << ". : \n";
           cout << "oyuncu TC : " << oyuncu.TC << endl;
           cout << "oyuncu adı : " << oyuncu.OyuncuAdi << endl;
           cout << "oyuncu soy adı : " << oyuncu.OyuncuSoyAdi << endl;
           cout << "oyuncu doğum tarihi : " << oyuncu.dogumTarihi << endl;
           cout << "oyuncu bağlı oldu takım : " << oyuncu.baglaiOlduTakim << endl;
           cout << "oyundaki konumu : " << oyuncu.oyundakkiKonumu << endl;
           cout << "oyuncu ucreti : " << oyuncu.oyuncununUcreti << "TL" << endl;
           cout << "oyuncu kodu : " << oyuncu.oyuncuKodu << endl;
           cout << "-----------------------------------------------\n";
        }
    }
    void OyuncuBilgileriDuzenleme()
    {
        int kontrol, islemNumarasi;
        // Kullanıcıdan düzenlemek istediği oyuncunun kodunu al
        cout << "Güncelemek istediniz oyuncu kodunu giriniz : " << endl;
        GirilenDegiskenDogrulu(kontrol);
        system("cls");//cmd silen emir
        // Vektördeki her bir oyuncu için döngü
        for (auto& oyuncu : oyuncuVektoru)
        {
            // Eğer girilen kod, vektördeki bir oyuncunun koduyla eşleşiyorsa
            if (kontrol == oyuncu.oyuncuKodu)
            {
                cout << "OYUNCU BİLGİLERİ DUZELTMEK \n";
                cout << "--------------------------------------------\n";
                cout << "1. oyuncunun oyundaki konumu " << endl;
                cout << "2. oyuncunun ucreti " << endl;
                cout << "--------------------------------------------\n";

                // Kullanıcıdan düzenleme türünü seçmesini iste
                cout << "oyuncuda duzeltmek istediniz bilgi turunun numarası giriniz : \n";
                ReadNumber(1, 2, islemNumarasi);
                // Seçilen düzenleme türüne göre işlem yap
                switch (islemNumarasi)
                {
                case 1:
                    cout << "oyuncunun oyundaki konumu değiştirmek uzerindesiniz \n";
                    cout << "istediniz yeni konumu giriniz \n";
                    cin >> oyuncu.oyundakkiKonumu;
                    cout << "Değişikler kaydetildi\n";
                    break;

                case 2:
                    cout << "oyuncunun ucreti değiştirmek uzerindesiniz \n";
                    cout << "istediniz ucret giriniz \n";
                    GirilenDegiskenDogrulu(oyuncu.oyuncununUcreti);
                    cout << "Değişikler kaydetildi\n";
                    break;

                default:
                    cout << "Geçersiz işlem numarası.\n";

                }
                // Yapılan değişiklikleri kaydet ve göster
                OyuncuBilgileriYazdirma();
                return;
            }
        }
        cout << "Girilen oyuncu kodu geçersiz veya oyuncu bulunamadı.\n";
    }
    void OyuncuSilme(Takimclass& takimListesi)
    {
        int silinecekKod;
        cout << "silmek istediniz oyuncu kodunu giriniz : " << endl;
        GirilenDegiskenDogrulu(silinecekKod);
        // Vektördeki her bir oyuncu için döngü
        for (auto it = oyuncuVektoru.begin(); it != oyuncuVektoru.end(); ++it) 
        {
            // Eğer girilen kod, vektördeki bir oyuncunun koduyla eşleşiyorsa
            if (silinecekKod == it->oyuncuKodu) 
            {
                oyuncuVektoru.erase(it); // Vektörden oyuncuyu sil
                OyuncuKodlariSET.erase(silinecekKod); // Setten oyuncu kodunu sil
                cout << "Oyuncu silindi.\n";

                // Oyuncu listesini güncelle ve yazdır
                OyuncuBilgileriYazdirma();

                // Takımlar listesindeki her takımın oyuncu sayısını azalt
                for (auto& takim : takimListesi.takimlarVectoru)
                    takim.oyuncuSayisi--;
                return;
            }
        }
        // Eğer buraya ulaşıldıysa, oyuncu kodu bulunamamıştır
        cout << "Girilen oyuncu kodu geçersiz veya oyuncu bulunamadı.\n";
    }   
    void GolAtanOyuncuListesi()
    {
        for (auto& oyuncu : oyuncuVektoru)
        {
            // Eşleşen takım kodunu bul
            if (oyuncu.baglaiOlduTakimKodu != 0 && oyuncuVektoru.size() != 0)
            {
                if (oyuncu.golSayisi != 0)
                {
                    cout << oyuncu.OyuncuAdi << " " << oyuncu.OyuncuSoyAdi << " - Gol Sayısı: " << oyuncu.golSayisi << endl;
                }
            }
            
            else
            {
                cout << "lutfen takımlara oyuncu ekleyiniz\n";
                return;
            }      
        }
         if (oyuncuVektoru.size() == 0)
         {
           cout << "daha önce oyuncu oluşturlmadı ! \a\n";
           return;
         }

         
    }
};
void TakimSilme(oyuncularclass& OyuncuListesi,Takimclass& Takimlistesi)
{
    int silinecekKod;
    // Kullanıcıdan silinecek takımın kodunu al
    cout << "silmek istediniz takımın kodunu giriniz : " << endl;
    GirilenDegiskenDogrulu(silinecekKod);
    // Vektörde silinecek takımı ara
    system("cls");//cmd silen emir

    for (auto it =Takimlistesi.takimlarVectoru.begin(); it != Takimlistesi.takimlarVectoru.end(); ++it)
    {
        // Eğer bulunan takımın kodu, silinmek istenen kodla eşleşiyorsa
        if (silinecekKod == it->takiminKodu)
        {
            Takimlistesi.takimlarVectoru.erase(it); // Vektörden istenen Takım sil
            Takimlistesi.takimKodlariSET.erase(silinecekKod); // Setten Takım kodunu sil
            cout << "takım silindi.\n";
            // Güncellenmiş takım listesini göster
             // Takıma bağlı oyuncuların bağlantısını kaldır
            for (auto& oyuncu : OyuncuListesi.oyuncuVektoru)
            {
                if (oyuncu.baglaiOlduTakimKodu == silinecekKod)
                {
                    oyuncu.baglaiOlduTakim = "";
                    oyuncu.baglaiOlduTakimKodu = 0;
                }
            }
            Takimlistesi.TakimleriListele();
            return;
        }
    }
    // Eğer buraya ulaşıldıysa, takım kodu bulunamamıştır
    cout << "Girilen takım kodu geçersiz veya takım bulunamadı.\n";
}
void TakimlerKarsilasma(Takimclass& takimlistesi)
{
    system("cls");//cmd silen emir
    int takimSayisi = takimlistesi.takimlarVectoru.size();
   
    // Takımların sayısını kontrol ederek yeterli takım olup olmadığını kontrol et
    if ( takimSayisi< 2)
    {
        cout << "takım sayısı en az 2 olması gerikyor ! \a\n";
        cout << "Karşılaşma başlaması için lütfen daha fazla takım ekleyin\n";
        return;// Eğer yeterli takım yoksa, fonksiyonu sonlandır.
    }
    for (const auto& oyuncuSayisi : takimlistesi.takimlarVectoru)
    {
        if (oyuncuSayisi.oyuncuSayisi == 0)
        {
            cout << "takımdan biri yada tumu hiç oyuncusu yok ...lutfen oyuncu ekleyiniz \n";
            return;
        }

    }
 
    short macsayisi=0,haftaSayisi=1;
    string karisilasmaSonucu;
    // Her takım için karşılaşma düzenle
    cout << "KARŞILAŞMA KAYDI : \n";
    for (int i = 0; i != takimSayisi; i++)
    {
         int RastgeleTakim = rand() % takimSayisi;
         while (RastgeleTakim==i) // Kendi kendileriyle oynamasınlar
         {
             RastgeleTakim = rand() % takimSayisi;
         }
         //Maç sonucunu belirlemek için rastgele sayı ... 0 : kaybeti ,1:berabere ,2:kazandi
         int sonuc = rand() % 3;
       
         switch (sonuc)
         {
         case 0:
             takimlistesi.takimlarVectoru[RastgeleTakim].puan += 3; // Rakip takım kazanır
            
             karisilasmaSonucu = takimlistesi.takimlarVectoru[i].TakimAdi + " vs " +
                 takimlistesi.takimlarVectoru[RastgeleTakim].TakimAdi +
                 " - Kazanan: " + takimlistesi.takimlarVectoru[RastgeleTakim].TakimAdi + "\n";
             macsayisi += 1;

             break;
         case 1:// Beraberlik durumu
             takimlistesi.takimlarVectoru[i].puan += 1; // Beraberlik durumunda her iki takıma 1'er puan
             takimlistesi.takimlarVectoru[RastgeleTakim].puan += 1;
             karisilasmaSonucu = takimlistesi.takimlarVectoru[i].TakimAdi + " vs " +
                 takimlistesi.takimlarVectoru[RastgeleTakim].TakimAdi +
                 " - Berabere\n";
             macsayisi += 1;

             break;
         case 2:// Kazanma durumu
             takimlistesi.takimlarVectoru[i].puan += 3;
             
             karisilasmaSonucu = takimlistesi.takimlarVectoru[i].TakimAdi + " vs " +
                 takimlistesi.takimlarVectoru[RastgeleTakim].TakimAdi +
                 " - Kazanan: " + takimlistesi.takimlarVectoru[i].TakimAdi + "\n";
             macsayisi += 1;
             break;
         }
         if (macsayisi == 1 || macsayisi == 3 || macsayisi == 5 || macsayisi == 7) 
         {
             cout << haftaSayisi << ". hafta:\n";
             haftaSayisi++;
         }
         if (macsayisi<3)
         {
             cout << macsayisi << ".Karşılaşma ";
             cout << karisilasmaSonucu << endl;
           
             if (macsayisi == 2)
             {
                 for (const auto& takim : takimlistesi.takimlarVectoru)
                 {
                     cout << "Takım adı: " << takim.TakimAdi << ", Puan: " << takim.puan << endl; // Her takımın kodunu ve puanını yazdır
                 }
             }
         }
         else if (macsayisi < 5)
         {
             
             cout << macsayisi << ".Karşılaşma ";
             cout << karisilasmaSonucu << endl;
           
             if (macsayisi == 4)
             {
                 for (const auto& takim : takimlistesi.takimlarVectoru)
                 {
                     
                     cout << "Takım adı: " << takim.TakimAdi << ", Puan: " << takim.puan << endl; // Her takımın kodunu ve puanını yazdır
                 }
             }
         }
         else if (macsayisi < 7)
         {
             cout << macsayisi << ".Karşılaşma ";
             cout << karisilasmaSonucu << endl;
             if (macsayisi == 6)
             {
                 for (const auto& takim : takimlistesi.takimlarVectoru)
                 {
                     cout << "Takım adı: " << takim.TakimAdi << ", Puan: " << takim.puan << endl; // Her takımın kodunu ve puanını yazdır
                 }
             }
         }
         else
         {
             cout << macsayisi << ".Karşılaşma ";
             cout << karisilasmaSonucu << endl;
             macsayisi++;
         }
    }
    cout << "------------------------------------------\n";
    // En yüksek puanı ve kazanan takımı belirle
    int enYuksekPuan = 0;
    int kazananTakimIndeksi = -1;
    // Tüm takımlar için döngü
    for (int i = 0; i < takimSayisi; ++i) 
    {
        // Eğer mevcut takımın puanı en yüksek puandan yüksekse
        if (takimlistesi.takimlarVectoru[i].puan > enYuksekPuan) 
        {
            // En yüksek puanı güncelle
            enYuksekPuan = takimlistesi.takimlarVectoru[i].puan;
            // Kazanan takımın indeksini güncelle
            kazananTakimIndeksi = i;
        }
    }
    // Eğer bir kazanan varsa
    if (kazananTakimIndeksi != -1) 
    {
        cout << "Kazanan Takım: " << takimlistesi.takimlarVectoru[kazananTakimIndeksi].TakimAdi << " ile " << enYuksekPuan << " puan." << endl;
    }
    // Eğer kazanan yoksa
    else 
    {
        cout << "Kazanan takım belirlenemedi." << endl;
    }
    cout << "PUAN TABLOSU (son hali): \n";
    for (const auto& takim : takimlistesi.takimlarVectoru)
    {
        cout << "Takım adı: " << takim.TakimAdi << ", Puan: " << takim.puan << endl; // Her takımın kodunu ve puanını yazdır
    }
 }

void TakimdakiFutbolculariListeleme(oyuncularclass& oyuncuListesi, Takimclass& takimListesi)
{
    //Belirtilen takım koduna sahip takımın oyuncularını listeler.

    int  GirilentakimKodu, sayac = 0;
    cout << "oyuncuları görmek istediniz takım kodunu giriniz: ";
    GirilenDegiskenDogrulu(GirilentakimKodu);//-->Kullanıcıdan takım kodu alınır ve doğruluğu kontrol edilir.
    string TakımAdi = "";
    bool takimBolundu = 0;
    for (const auto& takim : takimListesi.takimlarVectoru)//-->Tüm takımlar arasında döngü yapılır.
    {
        // Girilen takım koduna uygun takım aranır.
        if (takim.takiminKodu == GirilentakimKodu)
        {
            takimBolundu = 1;
            break;

        }
    }
        if (takimBolundu) 
        {
            for (const auto& oyuncu : oyuncuListesi.oyuncuVektoru)//-->Tüm oyuncular arasında döngü yapılır.
            {
                if (oyuncu.baglaiOlduTakimKodu == GirilentakimKodu)//-->Oyuncunun bağlı olduğu takım, aranan takımla eşleşiyorsa
                {
                    sayac++;
                    cout << sayac << ". : " << endl;
                    cout << "oyuncu TC : " << oyuncu.TC << endl;
                    cout << "oyuncu adı : " << oyuncu.OyuncuAdi << endl;
                    cout << "oyuncu soy adı : " << oyuncu.OyuncuSoyAdi << endl;
                    cout << "oyuncu doğum tarihi : " << oyuncu.dogumTarihi << endl;
                    cout << "oyuncu bağlı oldu takım : " << oyuncu.baglaiOlduTakim << endl;
                    cout << "oyundaki konumu : " << oyuncu.oyundakkiKonumu << endl;
                    cout << "oyuncu ucreti : " << oyuncu.oyuncununUcreti << "TL" << endl;
                    cout << "oyuncu kodu : " << oyuncu.oyuncuKodu << endl;
                    cout << "-----------------------------------------------\n";
                }

            }
        }
        else    // Eşleşen takım kodu bulunamazsa, bilgi ver
            cout << "Girilen takım koduna ait takım bulunamadı." << endl;
}
void PrintMenu()
{
    cout << "-----------------------------------------------------" << endl;
    cout << "    TAKIM MENUSU : \n";
    cout << "1 - Takım oluşturma" << endl;
    cout << "2 - Takım silme" << endl;
    cout << "3 - Takıma futbolcu ekleme" << endl;
    cout << "4 - Takımdan futbolcu silme" << endl;
    cout << "5 - Takımdaki futbolcuları listeleme\n";
    cout << "6 - Takımlar listeleme\n";
    cout << "    OYUNCU MENUSU : \n";
    cout << "7 - Oyuncu ekleme\n";
    cout << "8 - Oyuncu silme(takıma atanan oyuncu önce takımdan silinmelidir.)\n";
    cout << "9 - Oyuncu güncelleme\n";
    cout << "10 - Oyuncular listeleme" << endl;
    cout << "    KARŞILAŞMA MENUSU : " << endl;
    cout << "11 - Futbol oyunu(Karşılaşma) başla \n";
    cout << "12 - Gol Atan Oyuncu Listesi \n";
    cout << "13 - Pogram sonlandır \n";
    cout << "-----------------------------------------------------" << endl;
   
}
void OyuncuyuTakimaEkle(oyuncularclass& oyuncuListesi, Takimclass& takimListesi) 
{
    int islemTuru;
    cout << "Oyuncu Ekleme Menu : \n";
    cout << "------------------------------"<<endl;
    cout << "1.Otomatik oyuncular takımlara ekle (rastgele)\n";
    cout << "2.menual oyuncu takıma ekle \n";
    cout << "------------------------------" << endl;
    cout << "Lutfen seçiniz (1,2)\n";
    do
    {
        GirilenDegiskenDogrulu(islemTuru);
        if (islemTuru != 1 && islemTuru != 2)
            cout << "sadece 1,2 girebilirsiniz\n";
    } while (islemTuru != 1 && islemTuru != 2);
    if (islemTuru == 1)
    {
        short oyuncuSayisi = oyuncuListesi.oyuncuVektoru.size();
        if (takimListesi.takimlarVectoru.empty())
        {
            cout << "Takım listesi boş. Lütfen önce takım ekleyin.\n";
            return;
        }
        else
        {
            cout << "Bir Takıma Bağlı Olmayan olan oyuncular rastgele diğer takımlar eklenicek !\n";
            for (auto it =oyuncuListesi.oyuncuVektoru.begin(); it !=oyuncuListesi.oyuncuVektoru.end(); ++it)
            {
                if (it->baglaiOlduTakim.empty())
                {
                    int Rastgeleİndex = rand() % (takimListesi.takimlarVectoru.size());
                    it->baglaiOlduTakim = takimListesi.takimlarVectoru[Rastgeleİndex].TakimAdi;
                    it->baglaiOlduTakimKodu = takimListesi.takimlarVectoru[Rastgeleİndex].takiminKodu;
                    // takımın oyuncu sayısını arttır
                    takimListesi.takimlarVectoru[Rastgeleİndex].oyuncuSayisi++;
                    it->golSayisi = rand() % 5; // Rastgele 0 ile 4 arası gol sayısı
                }
            }
        }
    }
    else if (islemTuru == 2)
    {
        int GirilenOyuncuKodu, GirilentakimKodu;
        // Kullanıcıdan istenen oyuncu ve takım kodlarını al
        cout << "Eklemek istediğiniz oyuncunun kodunu giriniz: ";
        GirilenDegiskenDogrulu(GirilenOyuncuKodu);
        cout << "Eklemek istediğiniz takımın kodunu giriniz: ";
        GirilenDegiskenDogrulu(GirilentakimKodu);

        system("cls");//cmd silen emir
        // Tüm oyuncuları döngü içinde kontrol et ve oyuncu bul.
        for (auto& oyuncu : oyuncuListesi.oyuncuVektoru)
        {
            // Eşleşen oyuncu kodunu bul
            if (oyuncu.oyuncuKodu == GirilenOyuncuKodu)
            {
                // Oyuncu zaten bir takıma bağlıysa, bilgi ver ve çık
                if (!oyuncu.baglaiOlduTakim.empty()) //baglı oldu takım boş mu değil 1 yada 0 verir
                {
                    cout << "Oyuncu zaten bu takıma atandı: " << oyuncu.baglaiOlduTakim;
                    cout << "Lutfen Takımdan futbolcu silme seçenekten oyuncu silin sonra başka takıma ekleyiniz " << endl;
                    return;
                }
                // Tüm takımları kontrol et
                for (auto& takim : takimListesi.takimlarVectoru)
                {
                    // Eşleşen takım kodunu bul
                    if (takim.takiminKodu == GirilentakimKodu)
                    {
                        // Oyuncuya takım adını ata
                        oyuncu.baglaiOlduTakim = takim.TakimAdi;
                        oyuncu.baglaiOlduTakimKodu = takim.takiminKodu;
                        // takımın oyuncu sayısını arttır
                        takim.oyuncuSayisi++;
                        cout << takim.oyuncuSayisi << endl;
                        cout << "Oyuncu " << GirilenOyuncuKodu << ", '" << takim.TakimAdi << "' takımına eklendi." << endl;
                        oyuncu.golSayisi = rand() % 5; // Rastgele 0 ile 4 arası gol sayısı
                        return;
                    }
                }
                // Eşleşen takım kodu bulunamazsa, bilgi ver
                cout << "oyuncu kodu bulunamadı." << endl;
                return;
            }
        }
        // Eşleşen oyuncu kodu bulunamazsa, bilgi ver
        cout << "Oyuncu kodu bulunamadı." << endl;
    }

}
void OyuncuyuTakimdenSil(oyuncularclass& oyuncuListesi, Takimclass& takimListesi) 
{
    int GirilenOyuncuKodu, GirilenTakimKodu;
    // Kullanıcıdan oyuncu ve takım kodlarını al
    cout << "Silmek istediğiniz oyuncunun kodunu giriniz: ";
    GirilenDegiskenDogrulu(GirilenOyuncuKodu);
    cout << " takımın kodunu giriniz: ";
    GirilenDegiskenDogrulu(GirilenTakimKodu);

    // Tüm oyuncuları döngü içinde kontrol et ve oyuncu bul.
    for (auto& oyuncu : oyuncuListesi.oyuncuVektoru)
    {
        // Eşleşen oyuncu kodunu bul
        if (oyuncu.oyuncuKodu == GirilenOyuncuKodu)
        {
            // Tüm takımları kontrol et
            for (auto& takim : takimListesi.takimlarVectoru) 
            {
                // Eşleşen takım kodunu bul
                if (takim.takiminKodu == GirilenTakimKodu)
                {
                    // Oyuncunun takım bağını kontrol et
                    if (oyuncu.baglaiOlduTakim == takim.TakimAdi) 
                    {
                        // Oyuncunun takım bağını kaldır ve takımın oyuncu sayısını azalt
                        oyuncu.baglaiOlduTakim = ""; 
                        takim.oyuncuSayisi--;
                        cout << "Oyuncu " << GirilenOyuncuKodu << ", '" << takim.TakimAdi << "' takımından çıkarıldı." << endl;
                       
                        return;
                    }
                    else //-->Oyuncu bu takımda değilse bilgi ver
                    {
                        cout << "Oyuncu bu takımda değil." << endl;
                        return;
                    }
                }
            }
            // Eşleşen takım kodu bulunamazsa, bilgi ver
            cout << "Takım kodu bulunamadı." << endl;
            return;
        }
    }
    // Eşleşen oyuncu kodu bulunamazsa, bilgi ver
    cout << "Oyuncu kodu bulunamadı." << endl;
}

int main()
{
    setlocale(LC_ALL, "Turkish"); // -->Türkçe karakter desteği için
    srand(time(0));//--> Rastgele sayı üreteci başlatılır
    Takimclass takimObject; // -->Takım nesnesi oluşturulur
    oyuncularclass OyuncuObject;// -->Oyuncu nesnesi oluşturulur
    PrintMenu();// -->Kullanıcıya menü gösterilir
    int number;
    while (1)
    {
        ReadNumber(1,13, number);// --> Kullanıcıdan bir sayı alınır
        switch (number) // -->Alınan sayıya göre işlem seçilir
        {
        case 1:
            takimObject.TakimEkle(takimObject.TakimOlusturma());
            takimObject.TakimleriListele();
            PrintMenu();
            break;
        case 2:
        
            TakimSilme(OyuncuObject, takimObject);
            takimObject.TakimleriListele();
            OyuncuObject.OyuncuBilgileriYazdirma();
            PrintMenu();
            break;
        case 3:
            OyuncuyuTakimaEkle(OyuncuObject, takimObject);
            takimObject.TakimleriListele();
            OyuncuObject.OyuncuBilgileriYazdirma();
            PrintMenu();
            break;
        case 4:
            OyuncuyuTakimdenSil(OyuncuObject, takimObject);
            OyuncuObject.OyuncuBilgileriYazdirma();
            takimObject.TakimleriListele();
            PrintMenu();
            break;
        case 5:
            TakimdakiFutbolculariListeleme(OyuncuObject, takimObject);
            takimObject.TakimleriListele();
            OyuncuObject.OyuncuBilgileriYazdirma();
            PrintMenu();
            break;
        case 6:takimObject.TakimleriYazdir();
            PrintMenu();
            break;
        case 7:
           OyuncuObject.cokSayidaOyuncuOlusturma();
           OyuncuObject.OyuncuBilgileriYazdirma();
           PrintMenu();
            break;
        case 8:
            OyuncuObject.OyuncuSilme(takimObject);
            takimObject.TakimleriListele();
            PrintMenu();
            break;
        case 9:
            OyuncuObject.OyuncuBilgileriDuzenleme();
            PrintMenu();
            break;
        case 10:
            OyuncuObject.oyuncularListeleme();
            PrintMenu();
            break;
        case 11: 
           TakimlerKarsilasma(takimObject);
           PrintMenu();
            break;
        case 12:
            OyuncuObject.GolAtanOyuncuListesi();
            PrintMenu();
            break;
        case 13:
            return 0;
            system("PAUSE");
        }
    }
}
