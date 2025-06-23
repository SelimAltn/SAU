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
#include <iomanip>
using namespace std;
string const NamesArr[42] = { "Mehmet","Fatih","Ali","Aras","Can","Esra","Sena","Selin","Tuba","Abdulselam","Doğan","Elif","Mellisa","Serhat","Fatih","Ali","Aras","Can","Esra","Sena","Selin","Tuba","Abdulselam","Doğan","Elif","Mellisa","Serhat" ,"Fatih","Ali","Aras","Can","Esra","Sena","Selin","Tuba","Abdulselam","Doğan","Elif","Mellisa","Serhat" };
string const SurnameArr[37] = { "Kaya","Dağlar","Yılmaz","Aslan","Kaya","Özdemir","Yüksel","Acar","Akkoç","Aytaç","Bozoğlu","Kaplan","Demir" ,"Dağlar","Yılmaz","Aslan","Kaya","Özdemir","Yüksel","Acar","Akkoç","Aytaç","Bozoğlu","Kaplan","Demir" ,"Dağlar","Yılmaz","Aslan","Kaya","Özdemir","Yüksel","Acar","Akkoç","Aytaç","Bozoğlu","Kaplan","Demir" };

struct sStudent {
    string name, surname;
    double midtermScore;
    double homeWork1Score, homeWork2Score, quiz1Score, quiz2Score;
    double courseAverage;
    string letterGrade;
    bool highestAverage = false;
    bool lowestAverage = false;
    bool isSuccessful = true;
};

struct sCourseStatistics
{
    short NumberStudentsReceivingAA=0, NumberStudentsReceivingBA=0, NumberStudentsReceivingBB=0, NumberStudentsReceivingCB=0, NumberStudentsReceivingCC=0, NumberStudentsReceivingDC=0, NumberStudentsReceivingDD=0, NumberStudentsReceivingFD=0, NumberStudentsReceivingFF=0;
    double ClassAverage;
    sStudent studentHighestScore, studentLowestScore;
    double standardDeviation;

};

struct sCourse
{

    string CourseName;
    int weightMidterm;
    int weightHomeWork1, weightHomework2, weightQuiz1, weightQuiz2;
    double passGradeYearWork;
    vector<sStudent> vStudents;
    sCourseStatistics courseStatistics;


};



struct GradeMapping
{
    double minScore;
    const char* letter;
};

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
              (student.homeWork2Score  * corse.weightHomework2 / 100) +
              (student.quiz1Score      * corse.weightQuiz1     / 100) +
              (student.quiz2Score      * corse.weightQuiz2     / 100);
    student.courseAverage = average;
}
void calculateStudentLetterGrade(sStudent &student) {
    
    double average = student.courseAverage;
    
    for (const auto& grad : gradeTable) {
        if (average >= grad.minScore) {
            student.letterGrade = grad.letter;
            if (student.letterGrade == "FD" || student.letterGrade == "FF")
                student.isSuccessful = false;
            break;
        }
       
   }

}
void calculateCourseGradeStats(sCourse& coruse, sStudent student) {
    if(student.letterGrade=="AA")
        coruse.courseStatistics.NumberStudentsReceivingAA++;
    else if (student.letterGrade=="BA")
        coruse.courseStatistics.NumberStudentsReceivingBA++;
    else if (student.letterGrade == "BB")
        coruse.courseStatistics.NumberStudentsReceivingBB++;
    else if (student.letterGrade == "CB")
        coruse.courseStatistics.NumberStudentsReceivingCB++;
    else if (student.letterGrade == "CC")
        coruse.courseStatistics.NumberStudentsReceivingCC++;
    else if (student.letterGrade == "DC")
        coruse.courseStatistics.NumberStudentsReceivingDC++;
    else if (student.letterGrade == "DD")
        coruse.courseStatistics.NumberStudentsReceivingDD++;
    else if (student.letterGrade == "FD")
        coruse.courseStatistics.NumberStudentsReceivingFD++;
    else if (student.letterGrade == "FF")
        coruse.courseStatistics.NumberStudentsReceivingFF++;
}
void CalculateLowestHighestScores(sCourse &course) {
    if (!course.vStudents.empty()) {
        double highestAverage = course.vStudents[0].courseAverage;
        double lowestAverage  = course.vStudents[0].courseAverage;
        for (sStudent& student : course.vStudents) {
            if (student.courseAverage > highestAverage)
                highestAverage = student.courseAverage;
            if (student.courseAverage < lowestAverage)
                lowestAverage = student.courseAverage;
        }
        for (auto& student : course.vStudents) {
            if ((student.courseAverage == highestAverage)) {
                student.highestAverage = (student.courseAverage == highestAverage);
                course.courseStatistics.studentHighestScore = student;
            }
            if ((student.courseAverage == lowestAverage)) {
                student.lowestAverage = (student.courseAverage == lowestAverage);
                course.courseStatistics.studentLowestScore = student;
            }
        }
    }    
}
void calculateStandardDeviation(sCourse& course) {
    double classAverage = course.courseStatistics.ClassAverage;
    double sum =0.0;
    for (auto student : course.vStudents)
        sum += pow((student.courseAverage - classAverage), 2);
    double variance = sum / course.vStudents.size();
    course.courseStatistics.standardDeviation = sqrt(variance);
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
        &student.homeWork2Score,
        &student.quiz1Score,
        &student.quiz2Score
    };
    for (double* score : scores) {
        *score = RandomNumber(minScore,maxScore);
    }
}
void printStudentInformation(sStudent student,short number) {
    cout << "---------------------"<<number<<"------------------------------\n";
    cout << "Name : " << student.name << " " << student.surname << endl;
    cout << "Midterm exam score : " << student.midtermScore << endl;
    cout << "1st homework score : " << student.homeWork1Score << endl;
    cout << "2st homework score : " << student.homeWork2Score << endl;
    cout << "1st quiz score : "     << student.quiz1Score << endl;
    cout << "2st quiz score : "     << student.quiz2Score << endl;
    cout << "student average : " << student.courseAverage << endl;
    cout << "letter grade the student received : " << student.letterGrade << endl;
    if (student.isSuccessful)
        cout << "The student passed the course (succeeded)" << endl;
    else
        cout << "student failed the course " << endl;
    cout << "------------------------------------------------------------\n";
}
void printGradeStat(string gradeName, short count, short total) {
    double percentage = (double)count * 100.0 / total;
    cout << left << setw(30) << "Number of students receiving " << gradeName << " : " << count << " " << setw(5) << gradeName << " class percentage = " << percentage << "%" << endl;
}
void printCourseStatistics(sCourse course) {
    cout << "-----------------------Course Statistics--------------------------\n";
    cout << "Class average : " << course.courseStatistics.ClassAverage << endl;
    cout << "highest score in class : " << course.courseStatistics.studentHighestScore.courseAverage << endl;
    cout << "lowest  score in class : " << course.courseStatistics.studentLowestScore.courseAverage << endl;
    cout << "standard deviation of the class : " << course.courseStatistics.standardDeviation << endl;
    printGradeStat("AA", course.courseStatistics.NumberStudentsReceivingAA, course.vStudents.size());
    printGradeStat("BA", course.courseStatistics.NumberStudentsReceivingBA, course.vStudents.size());
    printGradeStat("BB", course.courseStatistics.NumberStudentsReceivingBB, course.vStudents.size());
    printGradeStat("CB", course.courseStatistics.NumberStudentsReceivingCB, course.vStudents.size());
    printGradeStat("CC", course.courseStatistics.NumberStudentsReceivingCC, course.vStudents.size());
    printGradeStat("DC", course.courseStatistics.NumberStudentsReceivingDC, course.vStudents.size());
    printGradeStat("DD", course.courseStatistics.NumberStudentsReceivingDD, course.vStudents.size());
    printGradeStat("FD", course.courseStatistics.NumberStudentsReceivingFD, course.vStudents.size());
    printGradeStat("FF", course.courseStatistics.NumberStudentsReceivingFF, course.vStudents.size());
   
    cout << "-------------------------------------------------------------------\n";

}
void printStudentsInformation(sCourse course) {
    int i = 1;
    for (sStudent& student : course.vStudents) {
        printStudentInformation(student, i);
        i++;
    }
}

const short HIGH_MIN = 80, HIGH_MAX = 100;
const short MID_MIN  = 50, MID_MAX  = 80;
const short LOW_MIN  = 0,  LOW_MAX  = 50;

void distributeGradesToStudents(sCourse &course) {
    // 20 % will be randomly determined between 80 and 100, 50 % between 80 and 50, and 30 % between 50 and 0.
    int total = course.vStudents.size();
    int highCount = round(total * 0.20);
    int midCount  = round(total * 0.50);
    int lowCount  = total - highCount - midCount;
    int index = 0;
    
    for (; index < highCount; index++) {
        generateRandomGrade(course.vStudents[index], HIGH_MIN, HIGH_MAX);
    }
    for (; index<highCount+midCount; index++) {
        generateRandomGrade(course.vStudents[index], MID_MIN, MID_MAX);
    }
    for (; index < total; index++) {
        generateRandomGrade(course.vStudents[index], LOW_MIN, LOW_MAX);
    }
    double classAverage = 0.0;
    for (sStudent &student : course.vStudents)
    {
        calculateStudentCourseAverage(student, course);
        calculateStudentLetterGrade(student);
        calculateCourseGradeStats(course, student);
        classAverage += student.courseAverage;
    }
    course.courseStatistics.ClassAverage = classAverage / course.vStudents.size();
    CalculateLowestHighestScores(course);
    calculateStandardDeviation(course);
}


int main()
{
    srand(time(0));
    setlocale(LC_ALL, "Turkish");

    sCourse course;
    int numberOfStudents = ReadNumber(1, 10000, "Please enter the number of students in your class.", "Only 1-10000");
    course = ReadCourseInformations();
    course.vStudents = CreateStudents(numberOfStudents);
    distributeGradesToStudents(course);
    printStudentsInformation(course);
    printCourseStatistics(course);
   

    return 0;

}