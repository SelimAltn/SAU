/****************************************************************************
** SAKARYA ÜNİVERSİTESİ
** BİLGİSAYAR VE BİLİŞİM BİLİMLERİ FAKÜLTESİ
** BİLGİSAYAR MÜHENDİSLİĞİ BÖLÜMÜ
** PROGRAMLAMAYA GİRİŞİ DERSİ
**
** ÖDEV NUMARASI : 2 .
** ÖĞRENCİ ADI :SELİM ALTIN .
** ÖĞRENCİ NUMARASI :G231210558 .
** DERS GRUBU : B .
****************************************************************************/
#include <iostream>
#include <string>
#include <cmath>
#include<ctime>
#include <clocale>
#pragma warning (disable : 4996)
using namespace std;
enum ENhesapTuru {genelHesap = 1,OzelHesap = 2};
struct user
{
    int HesapNumarasi;
    //"SelimPay" kripto paradır ve kısaltması "SLMP"
    double  SLMPcuzdan=0,TLcuzdan=0;
    double SLMPsonHali ;
    int gun, ay, yıl;
    string kullancıAdı, kullancıSoyAdı;
    ENhesapTuru hesapTuru;
    bool HesapAcilisTarihiGuncelendimi=0;
    int dusuGunleri[3];
}user1[100];
int hesapsayi = 0;
class Hesap
{    
public :
    user info[100];
    bool cinHataDurumu()
    {
        //kullanıcının doğru bir giriş yapmasını kontrol eder. Eğer giriş doğruysa true döndürür, hatalıysa hata mesajı gösterip girişi temizler ve false döndürür.
        if (cin.good())
                return 1;
        else
        {
                cout << "sadece rakam girebilirsiniz \n\a";
                cin.clear(); // cin'in hata durumunu temizle
                cin.ignore(numeric_limits<streamsize>::max(), '\n'); // Hatalı girdiyi atla
                return 0;
        }
    }
    void GenelHesapAc()
    {
        system("cls");//cmd silen emir
        cout << "merheba... yeni genel hesap açmak üzerindesiniz \n";
        cout << "adınız giriniz\n";
        //-->Bu ifade, cin ile okuma yapıldıktan sonra girdi isim kalan yeni satır karakterini ('\n') temizlemek için kullanılır.
        cin.ignore(numeric_limits<streamsize>::max(), '\n');
        getline(cin, info[hesapsayi].kullancıAdı);
        cout << "soy adınız giriniz \n";
        cin >> info[hesapsayi].kullancıSoyAdı;
        while (1)//-->Sürekli çalışan döngü, geçerli bir id giriş yapılana kadar devam eder.
        {
              cout << "lutfen hesap id giriniz \n";
              cin >> info[hesapsayi].HesapNumarasi;
              if (cin.good()) //-->Girişin doğruluğunu kontrol eder , doğruysa döngüden çıkar.
                      break;
              else
              {
                      cout << "id rakamlardan oluşur tekrar giriniz : \n";
                      cin.clear();
                      cin.ignore(numeric_limits<streamsize>::max(), '\n'); //--> Hatalı girdiyi atla
              }
        }
       
       
       
       
        cout << "teprikler yeni hesap açtınız .\a\n";
        system("cls");//cmd silen emir
        cout << "hesap numarınız = " << info[hesapsayi].HesapNumarasi << endl;
        
        SistemTarihi();
        info[hesapsayi].hesapTuru = genelHesap;

        //Mevcut hesaplar arasında dolaşarak yeni girilen hesap numarasının benzersiz olup olmadığını kontrol eder.
        for (int i = 0; i < hesapsayi; i++)
              
        {   
               while (info[hesapsayi].HesapNumarasi == info[i].HesapNumarasi)
                   // Girilen hesap numarasının zaten var olup olmadığını kontrol eder. Eğer varsa, kullanıcıdan yeni bir numara girmesini ister.
               {    
                       cout << "Bu hesap numarası zaten kullanımda. Lütfen başka bir numara giriniz : ";
                       while (1)  //--> Kullanıcı doğru bir hesap numarası girene kadar devam eden döngü. Doğru giriş yapılırsa döngüden çıkar.
                         
                       {
                              
                              cin >> info[hesapsayi].HesapNumarasi;
                              if (cin.good())//-->Girişin doğruluğunu kontrol eder , doğruysa döngüden çıkar.
                                      break;
                              else
                              {
                                      cout << "id rakamlardan oluşur tekrar giriniz : \n";
                                      cin.clear();
                                      cin.ignore(numeric_limits<streamsize>::max(), '\n'); // Hatalı girdiyi atla
                              }
                       }
               }    
        }   
        hesapsayi++;
        cout << "teprikler yeni hesap açtınız .\a\n";
        cout << "işleminiz tamamlama için lutfen TL yukleyiniz \n";
        TLyatırma(hesapsayi - 1);//-->hesap açılış için kullancı para yüklemesi için çağırılır.
        system("cls");//cmd silen emir
        cout << "ana listeye yönlendirilyorsunuz \n"<<endl;
        
    }
    void OzelHesapAc()
    {
        system("cls");//cmd silen emir
        cout << "merheba... yeni özel hesap açmak üzerindesiniz \n";
        cout << "adınız giriniz\n";
        //-->Bu ifade, cin ile okuma yapıldıktan sonra girdi isim kalan yeni satır karakterini ('\n') temizlemek için kullanılır.
        cin.ignore(numeric_limits<streamsize>::max(), '\n');
        getline(cin, info[hesapsayi].kullancıAdı);
        cout << "soy adınız giriniz \n";
        cin >> info[hesapsayi].kullancıSoyAdı;
        while (1)//-->// Kullanıcıdan hesap ID'si alır,eğer giriş sayısal değilse hata mesajı verir ve tekrar giriş yapmasını ister. Doğru giriş yapılana kadar döngü devam eder.
        {
               cout << "lutfen hesap id giriniz \n";
               cin >> info[hesapsayi].HesapNumarasi;
               if (cin.good())//-->Girişin doğruluğunu kontrol eder , doğruysa döngüden çıkar.
                       break;
               else 
               {
                       cout << "id rakamlardan oluşur tekrar giriniz : \n";
                       cin.clear();
                       cin.ignore(numeric_limits<streamsize>::max(), '\n'); // Hatalı girdiyi atla
               }
        }    
        system("cls");//cmd silen emir
        cout << "hesap numarınız = " << info[hesapsayi].HesapNumarasi << endl;
        SistemTarihi();
        info[hesapsayi].hesapTuru = OzelHesap;
        //Mevcut hesaplar arasında dolaşarak yeni girilen hesap numarasının benzersiz olup olmadığını kontrol eder.
        for (int i = 0; i < hesapsayi; i++)
            
        {
               while (info[hesapsayi].HesapNumarasi == info[i].HesapNumarasi)
               {
                       cout << "Bu hesap numarası zaten kullanımda. Lütfen başka bir numara giriniz : ";
                       while (1)
                           //Girilen hesap numarasının zaten var olup olmadığını kontrol eder.Eğer varsa, kullanıcıdan yeni bir numara girmesini ister.
                       {
                     
                              cin >> info[hesapsayi].HesapNumarasi;
                              if (cin.good())//-->Girişin doğruluğunu kontrol eder , doğruysa döngüden çıkar.
                                     break;
                              else
                              {
                                     cout << "id rakamlardan oluşur tekrar giriniz : \n";
                                     cin.clear();
                                     cin.ignore(numeric_limits<streamsize>::max(), '\n'); // Hatalı girdiyi atla
                              }
                       }
               }     
        }    
        hesapsayi++;
        cout << "teprikler yeni hesap açtınız .\a\n";
        cout << "işleminiz tamamlama için lutfen TL yukleyiniz \n";
        TLyatırma(hesapsayi - 1);//-->hesap açılış için kullancı para yüklemesi için çağırılır.
        system("cls");//cmd silen emir
        cout << "ana listeye yönlendirilyorsunuz \n"<<endl;
        
    }
    void SLMPal()
        //SLMP kripto parası satın alınmasına yarar
    {
        double cuzdandanCekilcekTutrar=0;
        int idkontrolu;
        string dongudenCıkmak;
        bool idDogrulı=0;
        while (1)
            // Kullanıcıdan hesap ID'si istenir. Eğer girilen değer sayısal değilse, uyarı mesajı verilir ve kullanıcıdan tekrar giriş yapması istenir. Geçerli bir giriş alınıncaya kadar döngü devam eder.
        {
                 cout << "hesap id iniz giriniz : \n";
                 cin >> idkontrolu;
                 
                 if (cin.good())
                          break;
                 else
                 {
                          cout << "id rakamlardan oluşur tekrar giriniz \n \a";
                          cin.clear(); // cin'in hata durumunu temizle
                          cin.ignore(numeric_limits<streamsize>::max(), '\n'); // Hatalı girdiyi atla
                 }
        }
        for (int i = 0; i != hesapsayi; i++)//-->Mevcut hesapların tümünü tarar, hesapsayi kadar iterasyon yapar.
        {
                if (idkontrolu == info[i].HesapNumarasi)//-->Kullanıcının girdiği ID'nin her bir hesapla eşleşip eşleşmediğini kontrol eder.
                {
                          idDogrulı = 1;
                          system("cls");//cmd silen emir
                          cout << "hoşgeldin " << info[i].kullancıAdı << " " << info[i].kullancıSoyAdı<<endl;
                          cout << "merhaba...her bir SLMP = 500TL \n ";
                          //girilen tutar mevcut TL bakiyesinden fazla olup olmadığını kontrol eder. 
                          do 
                          {
                                      cout << "cüzdanızında bulunan para = " << info[i].TLcuzdan << "TL " << endl;
                                      // Kullanıcı doğru bir miktar girene kadar devam eden döngü. Geçerli bir miktar girişi yapıldığında döngüden çıkar.
                                      while (1)
                                         
                                      {     
                                               cout << "kaç liralık SLMP para satın almak istiyorsunuz ? \n";
                                               cin >> cuzdandanCekilcekTutrar;
                                               if (cin.good())//--> Kullanıcı girişinin doğruluğunu kontrol eder. Eğer giriş hatalıysa, hata mesajı verilir ve yeniden denemesi için döngüye devam edilir.
                                                         break;
                                               else
                                               {
                                                         cout << "sadece rakam girebilirsiniz \n\a";
                                                         cin.clear(); // cin'in hata durumunu temizle
                                                         cin.ignore(numeric_limits<streamsize>::max(), '\n'); // Hatalı girdiyi atla
                                               }
                                      }
                                      if (cuzdandanCekilcekTutrar > info[i].TLcuzdan)//-->girilem miktar TL bakiyesinden fazla olup olmadığını kontrol eder. Fazlaysa, yetersiz bakiye uyarısı verir.
                                      {
                                              cout << "bakiye yetersiz \n\a";
                                              do//-->Kullanıcıya bir işlemi iptal etmek için "1"e veya tekrar denemek için "0"a basma seçeneği sunar.
                                              {
                                                      cout << "çıkmak istiyorsanız 1'basınız ,tekrar denemek için 0'basınız"<<endl;
                                                      cin >> dongudenCıkmak;
                                                      system("cls");//cmd silen emir
                                                      if (dongudenCıkmak == "1")//--> Kullanıcı "1" veya "0" dışında bir giriş yaparsa, bu döngü kullanıcı "1" veya "0" girinceye kadar devam eder. "1" girilirse, fonksiyondan çıkılır.
                                                               return;
                                                     
                                              }     while (dongudenCıkmak != "1" && dongudenCıkmak != "0");
                                              system("cls");//cmd silen emir
                                      }    
                          } while (cuzdandanCekilcekTutrar > info[i].TLcuzdan);
                         
                          cout <<"cuzdanızdan çekilcek tutar = "<<cuzdandanCekilcekTutrar << endl;
                          info[i].TLcuzdan = info[i].TLcuzdan - cuzdandanCekilcekTutrar;
                          cout << "Kalan cuzdanızda TL bakiye =  " << info[i].TLcuzdan <<endl;
                
                          info[i].SLMPcuzdan = info[i].SLMPcuzdan+(cuzdandanCekilcekTutrar / 500);
                          cout << "SLM bakiye : " << info[i].SLMPcuzdan << endl;
                          return;
                }
                else
                {
                         cout << " ana listeye yönlendirilyorsunuz ";
                }
        }
        if (!idDogrulı)//-->id döğru değil ise kullancıya uyarır.
                cout << "geçersiz id ! \n";
    }

    void SLMPsat()
    {
        string  dongudenCıkmak;
        int idkontrolu;
        bool idDogrulu=0;
        while (1)//-->// Kullanıcıdan hesap ID'si istenir. Eğer girilen değer sayısal değilse, uyarı mesajı verilir ve kullanıcıdan tekrar giriş yapması istenir. Geçerli bir giriş alınıncaya kadar döngü devam eder.
        {
                  cout << "hesap id iniz giriniz : \n";
                  cin >> idkontrolu;
                if (cin.good())//-->Girişin doğruluğunu kontrol eder , doğruysa döngüden çıkar.
                       break;
                else
                {
                       cout << "id rakamlardan oluşur tekrar giriniz \n \a";
                       cin.clear(); // cin'in hata durumunu temizle
                       cin.ignore(numeric_limits<streamsize>::max(), '\n'); // Hatalı girdiyi atla
                }
        }
        for (int i = 0; i != hesapsayi; i++)//-->Mevcut hesapların tümünü tarar, hesapsayi kadar iterasyon yapar.
        {
           

                if (idkontrolu == info[i].HesapNumarasi)//-->Kullanıcının girdiği ID'nin her bir hesapla eşleşip eşleşmediğini kontrol eder.
                {
                          double satmakİstediSLMP;
                          system("cls");//cmd silen emir
                          idDogrulu = 1;
                          cout << "hoşgeldin " << info[i].kullancıAdı << " " << info[i].kullancıSoyAdı << endl;
                          cout << "merhaba... her bir SLMP = 500TL \n ";
                          do
                          {
                                   // Hesabın açılış tarihinin güncellenip güncellenmediğini kontrol eder. Güncellenmişse güncellenmiş zamlı bakiyeyi, değilse mevcut bakiyeyi gösterir.
                                   if (info[i].HesapAcilisTarihiGuncelendimi)
                                       
                                   {
                                           cout << "kripto cüzdanızında bulunan SLMP = " << info[i].SLMPsonHali << endl;
                                   }
                                   else
                                   {
                                           cout << "kripto cüzdanızında bulunan SLMP = " << info[i].SLMPcuzdan << endl;
                                   }


                                   while (1)//-->// Kullanıcıdan geçerli bir SLMP satış miktarı alana kadar döngü devam eder. Hatalı girişlerde hata mesajı verilir ve tekrar giriş yapılması istenir.
                                   {
                                           cout << "SLMP para satmak istediğiniz tutarı giriniz : \n";
                                           cin >> satmakİstediSLMP;
                                           if (cin.good())//-->Girişin doğruluğunu kontrol eder , doğruysa döngüden çıkar.
                                                   break;
                                           else
                                           {
                                                   cout << "sadece rakam girebilirsiniz \n\a";
                                                   cin.clear(); // cin'in hata durumunu temizle
                                                   cin.ignore(numeric_limits<streamsize>::max(), '\n'); // Hatalı girdiyi atla
                                           }
                                   }

                                   if (info[i].HesapAcilisTarihiGuncelendimi) 
                                   {
                                            if (satmakİstediSLMP > info[i].SLMPsonHali)//--> Kullanıcının satmak istediği SLMP miktarının mevcut bakiyesinden fazla olup olmadığını kontrol eder. Eğer fazlaysa, yetersiz bakiye uyarısı verilir.
                                            {   
                                                   cout << "yetersiz bakiye \a\n";
                                                   do
                                                   {
                                                           cout << "çıkmak istiyorsanız 1'basınız ,tekrar denemek için 0'basınız" << endl;
                                                           cin >> dongudenCıkmak;
                                                           if (dongudenCıkmak == "1")
                                                                    return;
                                                   } while (dongudenCıkmak != "1" && dongudenCıkmak != "0");
                                                   system("cls");//cmd silen emir
                                            }   
                                            else
                                            {
                                                   info[i].SLMPsonHali = info[i].SLMPsonHali - satmakİstediSLMP;
                                                   info[i].TLcuzdan = info[i].TLcuzdan + satmakİstediSLMP * 500;
                                                   cout << "Yeni TL bakiyeniz : " << info[i].TLcuzdan << endl;
                                                   cout << "deneme " << info[i].SLMPsonHali << endl;
                                                   return;
                                            }
                                   }
                                   //kullanıcının bakiyesi yetersizse uyarı veriyor ve çıkmak ya da tekrar denemek için seçenek sunuyor.
                                   else if (satmakİstediSLMP > info[i].SLMPcuzdan)
                                   {
                                            cout << "yetersiz bakiye \a\n";
                                            do
                                            {
                                                   cout << "çıkmak istiyorsanız 1'basınız ,tekrar denemek için 0'basınız" << endl;
                                                   cin >> dongudenCıkmak;
                                                   if (dongudenCıkmak == "1")
                                                           return;
                                          
                                          
                                            } while (dongudenCıkmak != "1" && dongudenCıkmak != "0");
                                               system("cls");//cmd silen emir
                                   }      
                                   else
                                   {
                                             info[i].SLMPcuzdan = info[i].SLMPcuzdan - satmakİstediSLMP;
                                             info[i].TLcuzdan = info[i].TLcuzdan + satmakİstediSLMP * 500;
                                             cout << "Yeni TL bakiyeniz : " << info[i].TLcuzdan << endl;
                                             cout << "SLMP bakiye : " << info[i].SLMPcuzdan << endl;
                                             return;
                                   }
                          } while (satmakİstediSLMP > info[i].SLMPcuzdan || satmakİstediSLMP == 0);
                          // Kullanıcı, geçerli bir SLMP satış miktarı girene kadar bu döngüyü tekrarlar. Eğer bakiye yetersizse veya sıfır girilirse, kullanıcıya çıkmak veya tekrar denemek için seçenek sunulur.
                }
                else 
                    cout<< "ana listeye yönlendirilyorsunuz , ";
        }
        if (!idDogrulu)//-->id döğru değil ise kullancıya uyarır.
            cout << "geçersiz id ! \n";
    }
  
    void TLcekme()
    {
        int idKontrolu;
        double cekicekpara;
        bool idDogrulu = 0;
        // Kullanıcıdan hesap ID'si istenir. Eğer girilen değer sayısal değilse, uyarı mesajı verilir ve kullanıcıdan tekrar giriş yapması istenir.
        while (1)
        {
                  
                  cout << "hesap id iniz giriniz : \n";
                  cin >> idKontrolu;
                  if (cin.good())//-->Girişin doğruluğunu kontrol eder , doğruysa döngüden çıkar.
                            break;
                  else
                  {
                            cout << "id rakamlardan oluşur tekrar giriniz \n \a";
                            cin.clear(); // cin'in hata durumunu temizle
                            cin.ignore(numeric_limits<streamsize>::max(), '\n'); // Hatalı girdiyi atla
                  }
        }
        for (int i = 0; i != hesapsayi; i++)//-->Mevcut hesapların tümünü tarar, hesapsayi kadar iterasyon yapar.
        {
                  //Kullanıcının hesap numarasını kontrol eder.
                  if (idKontrolu == info[i].HesapNumarasi)
                  {
                      //Doğru hesap numarası bulunursa, bakiye gösterilir ve TL çekme işlemine başlanır.
                              idDogrulu = 1;
                              system("cls");//cmd silen emir
                              cout << "TL bakiyeniz = " << info[i].TLcuzdan << endl;
                              cout << "TL çekme işlemi yapma üzerindesiniz\n";
                              while (1)
                              {
                                         cout << "çekmek istediniz TL miktarı giriniz \n";
                                         cin >> cekicekpara;
                                         if (cin.good())//-->Girişin doğruluğunu kontrol eder , doğruysa döngüden çıkar.
                                                 break;
                                         else
                                         {
                                                 cout << "sadece rakam girebilirsiniz \n\a";
                                                 cin.clear(); // cin'in hata durumunu temizle
                                                 cin.ignore(numeric_limits<streamsize>::max(), '\n'); // Hatalı girdiyi atla
                                         }

                              }
                              /*Girilen miktar sıfırdan küçük veya eşitse hata mesajı verilir.
                              Bakiyeden fazla miktar girilirse yetersiz bakiye uyarısı yapılır.*/
                              if (cekicekpara <= 0)
                              {
                                         cout << "Geçersiz miktar. Lütfen pozitif bir değer giriniz.\n";
                                         return;
                              }
                              else if (cekicekpara > info[i].TLcuzdan)
                              {
                                         cout << "yetersiz bakiye...ana listeye yönlendirilyorsunuz\n";
                                         return;
                              }

                              info[i].TLcuzdan -= cekicekpara;
                              cout << "Para çekme işlemi başarılı! Yeni TL bakiyeniz: " << info[i].TLcuzdan << " TL\n";
                              break;
                  }

        }
        if (!idDogrulu)//-->id döğru değil ise kullancıya uyarır.
        {
                  cout << "Geçersiz ID.Lütfen geçerli bir ID giriniz \n";
        }
    }
    void TLyatirmaİcinİDkontrolu()
    {
        int idKontrolu = 0;
        bool idDogrulu = 0;
         
        
            while (!idDogrulu)
            {
                      cout << "hesap id iniz giriniz : \n";
                      cin >> idKontrolu;
                      if (!cinHataDurumu())
                      {
                              cin.clear();
                              cin.ignore(numeric_limits<streamsize>::max(), '\n');
                              continue;  // Eğer hata varsa, kullanıcıdan tekrar giriş yapmasını iste
                      }
                      for (int i = 0; i < hesapsayi; i++)
                      {
                              if (info[i].HesapNumarasi == idKontrolu)
                              {
                                     idDogrulu = 1;
                                     TLyatırma(i);
                                     break;
                              }

                      }
                      if (!idDogrulu)
                      {
                              cout << "Geçersiz ID. Lütfen geçerli bir hesap ID'si giriniz.\n";
                      }
            }       

    }
    void TLyatırma(int Hesapİndex)
    {
        double eklenenpara=0;
      
            cout << "TL yatırma işlemi yapma üzerindesiniz\n";
            //Eğer işlem yapılacak hesap ilk müşteriye aitse ve daha önce bu özel durum uygulanmadıysa, özel işlem başlatılır.
            if (Hesapİndex == 0 && !İlkMusteriOzelDurumuYaptimi)
            {
                   İlkMusteriOzelDurumuYaptimi = true;
                   system("cls");//cmd silen emir
                   cout << "özel durum\a\a\n";
                   cout << "ilk müşterimize özel \a\n";
                   cout << "bir kere mahsus HER SLMP = 1 TL (not : yukliceniz TL miktarı direk SLMP çevirlcek ) \n";
                   //Kullanıcıdan yatırmak istediği TL miktarı istenir.Miktar negatifse, pozitif bir değer girilmesi istenir.
                   while (!cinHataDurumu() || eklenenpara <= 0)
                   {

                          cout << "yatırmak istediniz TL miktarı giriniz : \n";
                          cin >> eklenenpara;
                          //Miktar negatifse, pozitif bir değer girilmesi istenir.
                          if (eklenenpara < 0)
                          {
                                 cout << "Lütfen pozitif bir değer giriniz.\n";
                          }

                   }
                   //Geçerli bir miktar girildiğinde, ilk müşterinin SLMP cüzdan bakiyesi, girilen TL miktarına eşitlenir.
                   info[0].SLMPcuzdan = eklenenpara;

            }   
            else 
            {
                   //Kullanıcıdan yatırmak istediği TL miktarı istenir.Miktar negatifse, pozitif bir değer girilmesi istenir.
                   while (!cinHataDurumu() || eklenenpara <= 0)
                   {    

                          cout << "yatırmak istediniz TL miktarı giriniz : \n";
                          cin >> eklenenpara;
                          //Miktar negatifse, pozitif bir değer girilmesi istenir.
                          if (eklenenpara < 0)
                          {
                                 cout << "Lütfen pozitif bir değer giriniz.\n";
                          }

                   }    
                  
                   info[Hesapİndex].TLcuzdan += eklenenpara;
                   cout << "Para yatırma işlemi başarılı! Yeni TL bakiyeniz: " << info[Hesapİndex].TLcuzdan << " TL\n";


            }
            

    }
 
    void HesapinAnlikDurum()
    {
        int idKontrolu;
        bool idDogrulu = 0;
        // Kullanıcıdan hesap ID'si istenir. Eğer girilen değer sayısal değilse, uyarı mesajı verilir ve kullanıcıdan tekrar giriş yapması istenir.
        while (1)
        {
                  cout << "istediniz Hesap Anlık durumu Görmek için  ";
                  cout << "id iniz giriniz : \n";
                  cin >> idKontrolu;
                  if (cin.good())//-->Girişin doğruluğunu kontrol eder , doğruysa döngüden çıkar.
                          break;
                  else
                  {
                          cout << "id rakamlardan oluşur tekrar giriniz \n \a";
                          cin.clear(); // cin'in hata durumunu temizle
                          cin.ignore(numeric_limits<streamsize>::max(), '\n'); // Hatalı girdiyi atla
                  }
        }
        for (int i = 0; i != hesapsayi; i++)//-->Mevcut hesapların tümünü tarar, hesapsayi kadar iterasyon yapar.
        {
                 //Kullanıcının hesap numarasını kontrol eder,döğru ise kullancı bilgileri ekrana yazılır.
                 if (idKontrolu == info[i].HesapNumarasi)
                 {
                         idDogrulu = 1;
                         system("cls");//cmd silen emir
                         cout << "hoşgeldin " << info[i].kullancıAdı << " " << info[i].kullancıSoyAdı << endl;
                         cout << "Hesap id : " << info[i].HesapNumarasi << endl;
                         //kullancı açılış tarihi guncelenmedi ise zamsız bakiyei yazar.
                         if (info[i].HesapAcilisTarihiGuncelendimi == 0)
                         {
                                  cout << "NOT : SLMP satma işlemi yaptıysanız Karşılıklı değeri TL cuzdanızında yatırlcak \n ";
                                  cout << "TL bakiyeniz : " << info[i].TLcuzdan <<" TL " << endl;
                                  cout << "mevcud SLMP (TL bekiye olmadan) : " << info[i].SLMPcuzdan << " SLMP " << endl;
                                  cout << "Hesap'da mevcut SLMP bakiye (NOT: TL bakiyeniz otomatik olarak SLMP'ye çevirlcektir.) = " << info[i].SLMPcuzdan + info[i].TLcuzdan / 500 << endl;
                         }
                         //kullancı açılış tarihi guncelendi ise zamlı bakiyei yazar.
                         else if (info[i].HesapAcilisTarihiGuncelendimi == 1)
                         {
                                  cout << "NOT : SLMP satma işlemi yaptıysanız Karşılıklı değeri TL cuzdanızında yatırlcak \n ";
                                  cout << "TL bakiyeniz : " << info[i].TLcuzdan << " TL " << endl;
                                  cout << "mevcud SLMP (TL bekiye olmadan) : " << info[i].SLMPsonHali - info[i].TLcuzdan/500 << " SLMP " << endl;
                                  cout << "Hesap'da mevcut SLMP bakiye (NOT: TL bakiyeniz otomatik olarak SLMP'ye çevirlcektir.) = " << info[i].SLMPsonHali << endl;
                                  break;
                         }
                   
                 }

        }
        if (!idDogrulu)//-->id döğru değil ise kullancıya uyarır.
        {
                 cout << "Geçersiz ID.Lütfen geçerli bir ID giriniz \n";
        }

    }
  
    short SayiAgralik(short form,short to ,string message)//-->kullanıcıdan belirli bir aralıkta bir sayı girmesini isteyen bir fonksiyon
    {
        int number;
        /*Kullanıcıdan bir sayı girmesi istenir.
         girdi doğru formatta mı diye kontrol eder.
        Girilen sayı belirlenen form ve to aralığının dışındaysa, kullanıcıya uygun aralıkta bir sayı girmesi için uyarı yapılır.*/
        do
        {
               cout << message << endl;
               cin >> number;
               while (!cinHataDurumu())
               {
                      cout << message << endl;
                      cin >> number;
                   
               }
               if (number<form || number>to)
                        cout << "lütfen " << form << "-" << to << " arasındaki sayılar giriniz \n";
        } while (number<form || number>to);
        //Doğru aralıkta bir sayı girildiğinde, bu sayı fonksiyondan döndürülür.
        return number;
      
    }

    void BakiyeGunceleme(user &hesap , int gunSayisi )
    {
        // genel hesapsa, başlangıçta SLMP ve TL bakiyeleri dikkate alınarak bir hesaplama yapılı,genel hesap oldğundan kontrol eder.
        if (hesap.hesapTuru == genelHesap)
        {
               hesap.SLMPsonHali = hesap.SLMPcuzdan + hesap.TLcuzdan / 500;
               //Her gün için bakiye %1 artırılır.
               for (int j = 0; j < gunSayisi; j++)
               {
                      hesap.SLMPsonHali *= 1.01;
                      if ((j + 1) % 15 == 0)//-->Her 15 günde bir bakiye %5 azaltılır
                      {
                             hesap.SLMPsonHali *= 0.95;
                      }
               }
        }   
        //özel hesapsa, başlangıçta SLMP ve TL bakiyeleri dikkate alınarak bir hesaplama yapılı,özel hesap oldğundan kontrol eder.
        else if (hesap.hesapTuru == OzelHesap)
        {
               hesap.SLMPsonHali = hesap.SLMPcuzdan + hesap.TLcuzdan / 500;
               //her gün bakiye % 5 artırılır
               for (int k = 0; k < gunSayisi; k++)
               {
                      hesap.SLMPsonHali *= 1.05;
                      if ((k + 1) % 30 == 0)//-->Her 30 günde bir bakiye %30 azaltılır
                      {
                          hesap.SLMPsonHali *= 0.3;
                      }
               }
        }
    }
    void HesapAcilisTarihiDuzenlemek()
    {
     int idKontrolu;
     bool idDogrulu = 0;
     
      cout << "hesap id iniz giriniz : \n";
      cin >> idKontrolu;
      // girilen hesap ID'sinin doğru formatta olup olmadığını kontrol eder.
      while (!cinHataDurumu())
      {
             cout << "hesap id iniz giriniz : \n";
             cin >> idKontrolu;
      }
     
      short gunSayisi=0;

     for (int i = 0; i != hesapsayi; i++)//-->Mevcut hesapların tümünü tarar, hesapsayi kadar iterasyon yapar.
     {
             //Kullanıcı tarafından girilen idKontrolu, mevcut hesaplar birinden ile eşleşiyorsa, işlem devam eder.
             if (idKontrolu == info[i].HesapNumarasi)
             {
                     //Kullanıcı hesap açılış tarihi bilgileri düzenler.
                     idDogrulu = 1;
                     system("cls");//cmd silen emir
                     cout << "Hesap açılış tarihi düzenlemek üzerindesiniz \n";
                     info[i].HesapAcilisTarihiGuncelendimi=1;
                     info[i].gun = SayiAgralik(1, 30, "hesap açılış günu giriniz");
                     info[i].ay = SayiAgralik(1, 12, "hesap açılış ayı giriniz ");
                     info[i].yıl = SayiAgralik(2020, 2024, "hesap açılış yılı giriniz ");
                     time_t şuan = time(0);
                     struct tm zaman = *localtime(&şuan);
                    //Eğer girilen tarih geçerliyse, hesap açılışından bu yana geçen gün sayısı hesaplanır ve bu süreye göre hesabın bakiyesi güncellenir.
                    gunSayisi = (((zaman.tm_year + 1900) - info[i].yıl) * 360) + (((zaman.tm_mon + 1) - info[i].ay) * 30) + zaman.tm_mday - info[i].gun;
                    if (gunSayisi < 0)//-->ayar gun sayısı negatif ise açılış tarihi gelecekten seçilmiş gosterir ve hata verir,sonra eski(sistem tarihi) düzenlenir. 
                    {
                             cout << "Hesap tarihi yalnış girdiniz \a! Sadece geçmişten bir hesap açma tarihi seçebilirsiniz \n";
                             info[i].HesapAcilisTarihiGuncelendimi=0;
                             time_t şuan = time(0);
                             struct tm zaman = *localtime(&şuan);
                             info[i].gun = zaman.tm_mday;
                             info[i].ay = zaman.tm_mon + 1;
                             info[i].yıl = zaman.tm_year + 1900;
                             return;
                    }
                    
                    else
                    {
                             cout << "Hesap açılışa geçen gun sayısı = " << gunSayisi << endl;
                             BakiyeGunceleme(info[i], gunSayisi);
                    }
                    
                    
             }

             

     }
     if (!idDogrulu)//-->id döğru değil ise kullancıya uyarır.
     {
             cout << "Geçersiz ID.Lütfen geçerli bir ID giriniz \n";
             return;
     }

    }

 void Listele()
 {
     system("cls");//cmd silen emir
     for (int i = 0; i != hesapsayi; i++)
     {      

               cout << i + 1 << ". hesap bilgileri : " << endl;
               cout << "hesap turu : ";
               if (info[i].hesapTuru == genelHesap)
                         cout << "genel hesap'tır\n";
               else
                         cout << "özel hesap'tır\n";

               cout << info[i].kullancıAdı << " " << info[i].kullancıSoyAdı << endl;
               cout << "hesap id :  " << info[i].HesapNumarasi << endl;
               cout << "SLMP bakiyeniz = " << info[i].SLMPcuzdan << endl;
               cout << "TL bakiyeniz = " << info[i].TLcuzdan << endl;
               cout << "TL bakiyeniz SLMP'ye çevirsek ve eski SLMP bakiyeniz'le toplarsak = " << info[i].SLMPcuzdan + info[i].TLcuzdan / 500 << " SLMP olur. " << endl;
               cout << "hesap açılış tarihi : " << info[i].gun << "." << info[i].ay << "." << info[i].yıl << endl;
               if (info[i].HesapAcilisTarihiGuncelendimi)
                         cout << "SLMP son hali : " << info[i].SLMPsonHali << endl;
               cout << "________________________________________\n";
     }      
 }
 
    
private:
    void SistemTarihi()
    {
        //şu anki tarihi alıp bir hesap bilgisi yapısına kaydediyor
        time_t şuan = time(0);
        struct tm zaman=*localtime(&şuan);
        info[hesapsayi].gun = zaman.tm_mday;
        info[hesapsayi].ay = zaman.tm_mon+1;
        info[hesapsayi].yıl = zaman.tm_year+1900;

    }
    bool İlkMusteriOzelDurumuYaptimi = false;
   

};
void PrintListe()
{
    cout << "--------------------------------------------\n";
    cout << "İşlem Menumuz : " << endl;
    cout << "1. Genel Hesap Aç  " << endl;
    cout << "2. Özel Hesap Aç " << endl;
    cout << "3. TL Yatırma\n";
    cout << "4. TL Çekme \n";
    cout << "5. SLMP Satın almak \n";
    cout << "6. SLMP Satmak \n";
    cout << "7. Hesapın Anlık Durumu " << endl;
    cout << "8. Tarih Duzenlemek \n";
    cout << "9. Listele \n";
    cout << "10. Program Sonlandırmak İçin \n";
    cout << "--------------------------------------------\n";
}

short MenuİcinNumaraSecim()
{
    short numara;
    while (1)
    {
          cout << "yapmak istediniz işlem numarası giriniz : "<<endl;
          cin >> numara;
          // Girdi doğru ve belirtilen aralıkta, döngüyü kır
          if (cin.good() && numara > 0 && numara < 11)
          {
                 break;
          }
          else
          {
                 cout << "Lütfen 1 ile 10 arasında bir sayı giriniz." << endl;
                 cin.clear(); // cin'in hata durumunu temizle
                 cin.ignore(numeric_limits<streamsize>::max(), '\n'); // Hatalı girdiyi atla
          }
     
    }
    return numara;  
}
void SecilenSayiYonlendirme()
{
    Hesap using1;
    // Bu döngü, kullanıcı bir çıkış seçeneğini seçene kadar programın sürekli çalışmasını sağlar.
    while (1)
    {   

           PrintListe(); //--> Kullanıcıya mevcut işlemlerin listesini gösterir.
           short numara = MenuİcinNumaraSecim();
           switch (numara)//-->// Kullanıcının seçtiği numaraya göre uygun işlemi gerçekleştirir.
           {
           case 1:
               using1.GenelHesapAc();
               break;
           case 2:
               using1.OzelHesapAc();
               break;
           case 3:
               using1.TLyatirmaİcinİDkontrolu();
               break;
           case 4:
               using1.TLcekme();
               break;
           case  5:
               using1.SLMPal();
               cout << endl;
               break;
           case  6:
               using1.SLMPsat();
               break;
           case 7:
               using1.HesapinAnlikDurum();
               break;
           case 8:
               using1.HesapAcilisTarihiDuzenlemek();
               break;
           case 9:
               using1.Listele();
               break;
           case 10:
               system("cls");//cmd silen emir
               cout << "çıkış yapılıyor... \n";
               return ;
           }
    }   
}
int main()
{
    setlocale(LC_ALL, "Turkish");
    SecilenSayiYonlendirme();
    return 0; 
   
}

