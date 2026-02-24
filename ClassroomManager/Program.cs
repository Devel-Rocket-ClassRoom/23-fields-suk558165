using System;

ClassroomManager class1 = new ClassroomManager("1반");
class1.AddStudent("홍길동");
class1.AddStudent("김철수");
class1.AddStudent("이영희");
class1.ShowStudents();
Console.WriteLine();

ClassroomManager class2 = new ClassroomManager("2반");
class2.AddStudent("박민수");
class2.AddStudent("정수진");
class2.ShowStudents();
Console.WriteLine();

ClassroomManager.ShowTotalClassrooms();
class ClassroomManager
{
    private const int Maxstudents = 5;
    private readonly string className;
    private string[] students;
    private int currentClassrooms = 0;
    private static int TotalClassrooms = 0;
  public ClassroomManager(string name)
    {
        this.className = name;
        this.students = new string[Maxstudents];
        TotalClassrooms++; // 생성될 때마다 전체 카운트 증가
    }
    public void AddStudent(string name)
    {
        if (currentClassrooms < Maxstudents)
        {
            students[currentClassrooms] = name;
            currentClassrooms++;
        }
        
    }
    // 학생 목록 출력 메서드
    public void ShowStudents()
    {
        Console.WriteLine($"=== {className} 학생 목록 ({currentClassrooms}/{Maxstudents}) ===");
        for (int i = 0; i < currentClassrooms; i++) // 현재 추가된 학생만큼만 반복
        {
            Console.WriteLine($"{i + 1}. {students[i]}");
        }
    }
    public static void ShowTotalClassrooms()
    {
        Console.WriteLine($"전체 교실 수: {TotalClassrooms}");
    }
}