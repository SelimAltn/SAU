/****************************************************************************
** SAKARYA ÜNİVERSİTESİ
** BİLGİSAYAR VE BİLİŞİM BİLİMLERİ FAKÜLTESİ
** BİLGİSAYAR MÜHENDİSLİĞİ BÖLÜMÜ
** PROGRAMLAMAYA GİRİŞİ DERSİ
**
** ÖDEV NUMARASI:1 .
** ÖĞRENCİ ADI : SELİM ALTIN .
** ÖĞRENCİ NUMARASI:G231210558 .
** DERS GRUBU : B .
****************************************************************************/
#include <iostream>
#include <string>
#include <cmath>
#include <locale.h>	
#include <ctime>
#include <vector>
using namespace std;
string const NamesArr[42] = { "Mehmet","Fatih","Ali","Aras","Can","Esra","Sena","Selin","Tuba","Abdulselam","Doğan","Elif","Mellisa","Serhat","Fatih","Ali","Aras","Can","Esra","Sena","Selin","Tuba","Abdulselam","Doğan","Elif","Mellisa","Serhat" ,"Fatih","Ali","Aras","Can","Esra","Sena","Selin","Tuba","Abdulselam","Doğan","Elif","Mellisa","Serhat" };
string const SurnameArr[37] = { "Kaya","Dağlar","Yılmaz","Aslan","Kaya","Özdemir","Yüksel","Acar","Akkoç","Aytaç","Bozoğlu","Kaplan","Demir" ,"Dağlar","Yılmaz","Aslan","Kaya","Özdemir","Yüksel","Acar","Akkoç","Aytaç","Bozoğlu","Kaplan","Demir" ,"Dağlar","Yılmaz","Aslan","Kaya","Özdemir","Yüksel","Acar","Akkoç","Aytaç","Bozoğlu","Kaplan","Demir" };
struct strağırlık
{
    float  vize, ödevbir, ödeviki, kısasınavbir, kısasınaviki;
};

struct strdeğerlendirilen
{
    float vize, ödevbir, ödeviki, kısasınavbir, kısasınaviki;
    short puanının_geçme_not;
};
struct sStudent {
    string name, surname;
    double midtermScore;
    double homeWork1Score, homework2Score, quiz1Score, quiz2Score;
    double courseAverage;
    string letterGrade;
};

struct sCourse
{
    
    string CourseName;
    short numberOfStudents;
    int weightMidterm;
    int weightHomeWork1, weightHomework2, weightQuiz1, weightQuiz2;
    double passGradeYearWork;
    vector<sStudent> vStudents;


};
struct GradeMapping
{
    double minScore;
    const char* letter;
};
// 90> AA >= 85.00 BA"  >= 80.00 BB  >= 75.00 CB >= 65.00 CC   >= 58.00 DC   >= 50.00 DD

const GradeMapping gradeTable[] = {
    {90,"AA"},
    {85,"BA"},
    {80,"BB"},
    {75,"CB"},
    {65,"CC"},
    {58,"DC"},
    {50,"DD"},
    {40,"FD"},
    {00,"FF"},

};

int randomIndex(int max) {
    return rand() % max;
}
double ReadDoubleNumber(short from, short to, string message, string ErrorMessage) {
    double number;
    do {
        cout << message << endl;
        cin >> number;
        if (number < from || number > to)
            cout << ErrorMessage << endl;
    } while (number < from || number > to);
    return number;
}
string ReadString(string message) {
    string Str;
    cout << message << endl;
    cin >> Str;
    return Str;
}
int RandomNumber(int from, int to) {
    return rand() % (to - from + 1) + from;
}

sStudent CreateStudent() {
    sStudent student;
    student.name = NamesArr[randomIndex(sizeof(NamesArr)/sizeof(NamesArr[0]))];
    student.surname = SurnameArr[randomIndex(sizeof(SurnameArr)/sizeof(SurnameArr[0]))];
    return student;
}
vector<sStudent> CreateStudents(short numberOfStudents) {
    vector <sStudent> vStudents;
    for (int i = 0; i < numberOfStudents; i++)
    {
        vStudents.push_back(CreateStudent());
    }
    return vStudents;
}
int ReadNumber(short from , short to , string message , string ErrorMessage) {
    int number;
    do {
        cout << message << endl;
        cin >> number;
        if (number < from || number > to)
            cout << ErrorMessage << endl;
    } while (number < from || number > to);
    return number;
}
void calculateStudentCourseAverage(sStudent& student,sCourse corse) {
    double average;
    average = (student.midtermScore    * corse.weightMidterm   / 100) +
              (student.homeWork1Score  * corse.weightHomeWork1 / 100) +
              (student.homework2Score  * corse.weightHomework2 / 100) +
              (student.quiz1Score      * corse.weightQuiz1     / 100) +
              (student.quiz2Score      * corse.weightQuiz2     / 100);
    student.courseAverage = average;
}
void calculateStudentLetterGrade(sStudent &student) {
    
    double average = student.courseAverage;
    
    for (const auto& grad : gradeTable) {
        if (average >= grad.minScore) {
            student.letterGrade = grad.letter;
            break;
        }
       
   }

}
sCourse  ReadCourseInformations() {
    sCourse Course;
    Course.CourseName      = ReadString("Enter the name of the course");
    
    short sum;
    do {
        sum = 0;
        Course.weightMidterm   = ReadNumber(10, 90, "Please enter the weight of the midterm.", "Only 10 - 90 weight of the midterm");
        Course.weightHomeWork1 = ReadNumber(1, 90, "Please enter the weight of the first assignment.", "Only 1  - 90 weight of the assignment");
        Course.weightHomework2 = ReadNumber(1, 90, "Please enter the weight of the second assignment.", "Only 1  - 90 weight of the assignment");
        Course.weightQuiz1     = ReadNumber(1, 20, "Please enter the weight of the first quiz.", "Only 1  - 20 weight of the quiz");
        Course.weightQuiz2     = ReadNumber(1, 20, "Please enter the weight of the second quiz.", "Only 1  - 20 weight of the quiz");
        sum = Course.weightMidterm + Course.weightHomeWork1 + Course.weightHomework2 + Course.weightQuiz1 + Course.weightQuiz2;
        if (sum > 100)
            cout << "The total weight cannot exceed 100. Please enter the values again." << endl;
    } while (sum > 100);
    Course.passGradeYearWork = ReadDoubleNumber(30, 70, "Enter your passing score during the year", "Only 30,70");
    return Course;
}

void generateRandomGrade(sStudent &student,short minScore,short maxScore) {

    double* scores[]{
        &student.midtermScore,
        &student.homeWork1Score,
        &student.homework2Score,
        &student.quiz1Score,
        &student.quiz2Score
    };
    for (double* score : scores) {
        *score = RandomNumber(minScore,maxScore);
    }
}
const short HIGH_MIN = 80, HIGH_MAX = 100;
const short MID_MIN  = 50, MID_MAX  = 80;
const short LOW_MIN  = 0,  LOW_MAX  = 50;
void distributeGradesToStudents(sCourse &coruse) {
    // 20 % will be randomly determined between 80 and 100, 50 % between 80 and 50, and 30 % between 50 and 0.
    int total = coruse.numberOfStudents;
    int highCount = total * 0.20;
    int midCount = total * 0.50;
    int lowCount = total - highCount - midCount;
    int index = 0;
    
    for (; index < highCount; index++) {
        generateRandomGrade(coruse.vStudents[index], HIGH_MIN, HIGH_MAX);
    }
    for (; index<highCount+midCount; index++) {
        generateRandomGrade(coruse.vStudents[index], MID_MIN, MID_MAX);
    }
    for (; index < total; index++) {
        generateRandomGrade(coruse.vStudents[index], LOW_MIN, LOW_MAX);
    }
    for (sStudent &student : coruse.vStudents)
    {
        calculateStudentCourseAverage(student, coruse);
        calculateStudentLetterGrade(student);
    }
}
void  rastgele_puan(sCourse& info, int& öğrenci_sayısı)
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

    sCourse info;
    int NumberOfStudents;

    NumberOfStudents = ReadNumber(1,10000,"Please enter the number of students in your class.","Only 1-10000");


    ağırlıklar(info);
    rastgele_puan(info, NumberOfStudents);

    return 0;

}