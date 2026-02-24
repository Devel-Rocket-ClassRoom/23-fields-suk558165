using System;
using System.Diagnostics.Metrics;
using System.Numerics;
using System.Reflection;
using System.Xml.Linq;

//## 과제 1: 필드가 있는 클래스 만들기
Player player = new Player();
player.ShowStatus();
class Player
{
    string name;
    int health;

    public void ShowStatus()
    {
        Console.WriteLine("이름: " + name);
        Console.WriteLine("체력: " + health);
    }
}
//## 과제 2: public 필드
Character hero = new Character();
hero.name = "용사";
hero.level = 10;
Console.WriteLine(hero.name);
Console.WriteLine(hero.level);
class Character
{
    public string name;
    public int level;
}
Character hero = new Character();
hero.name = "용사";           // 외부에서 접근 가능
hero.level = 10;
Console.WriteLine(hero.name);
Console.WriteLine(hero.level);

class Character
{
    public string name;
    public int level;
}
//## 과제 4: 선언과 동시에 초기화
Player player = new Player();
player.ShowStatus();
class Player
{
    private string name = "이름없음";
    private int health = 100;
    private int level = 1;

    public void ShowStatus()
    {
        Console.WriteLine("이름: " + name);
        Console.WriteLine("체력: " + health);
        Console.WriteLine("레벨: " + level);
    }
}



//## 과제 5: 필드 이니셜라이저
Say say = new Say();
say.Hi();
class Say
{
    private string message = "안녕하세요.";
    public void Hi()
    {
        message = "반갑습니다.";
        Console.WriteLine(message);
    }
}


//## 과제 6: 배열 필드 초기화
Schedule schedule = new Schedule();
schedule.PrintWeekDays();

class Schedule
{
    private string[] weekDays = { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };

    public void PrintWeekDays()
    {
        foreach (var day in weekDays)
        {
            Console.Write(day + "\t");
        }
        Console.WriteLine();
    }
}
//## 과제 7: 기본값 확인
DefaultValues dv = new DefaultValues();
dv.ShowDefaults();
class DefaultValues
{
    private int number;
    private bool flag;
    private string text;

    public void ShowDefaults()
    {
        Console.WriteLine("number: " + number);
        Console.WriteLine("flag: " + flag);
        Console.WriteLine("text: " + (text == null ? "null" : text));

    }

}
//## 과제 8: 정적 필드 선언과 사용
Counter c1 = new Counter();
Console.WriteLine("현재 카운트: " + Counter.count);
Counter c2 = new Counter();
Console.WriteLine("현재 카운트: " + Counter.count);
Counter c3 = new Counter();
Console.WriteLine("현재 카운트: " + Counter.count);
class Counter
{
    public static int count = 0;
    public Counter()
    {
        count++;
    }
}
//## 과제 9: 인스턴스 필드 vs 정적 필드
Player p1 = new Player("용사");
Player p2 = new Player("마법사");
Player p3 = new Player("궁수");
Console.WriteLine(p1.name);
Console.WriteLine(p2.name);
Console.WriteLine(p3.name);
Console.WriteLine("총 플레이어 수: " + Player.totalCount);

class Player
{
    public string name;
    public static int totalCount;

    public Player(string n)
    {
        name = n;
        totalCount++;
    }
}
//## 과제 10: readonly 필드
GameConfig config = new GameConfig(4);
config.ShowConfig();

class GameConfig
{
    public readonly string version = "1.0.0";
    public readonly int maxPlayers;

    public GameConfig(int max)
    {
        maxPlayers = max;
    }
    public void ShowConfig()
    {
        Console.WriteLine("버전: " + version);
        Console.WriteLine("최대 플레이어: " + maxPlayers);
    }
}
//## 과제 11: readonly vs const 비교
Example ex = new Example();
ex.ShowValues();
class Example
{
    public const double Pi = 3.14159;
    public readonly DateTime createdAt = DateTime.Now;
    public void ShowValues()
    {
        Console.WriteLine("원주율: " + Pi);
        Console.WriteLine("생성 시간: " + createdAt);
    }

}
//## 과제 12: this 키워드
Player player = new Player();
player.SetInfo("용사", 10);
player.ShowInfo();
class Player
{
    private string name;
    private int level;

    public void SetInfo(string name, int level)
    {
        this.name = name;
        this.level = level;

    }
    public void ShowInfo()
    {
        Console.WriteLine("이름: " + this.name);
        Console.WriteLine("레벨: " + this.level);
    }

}
//## 과제 13: 다양한 필드 타입 활용
Person person = new Person();
person.ShowProfile();
class Person
{
    private string name = "홍길동";
    private const int Age = 21;
    private readonly string nickName = "길동이";
    private string[] websites = { "네이버", "구글" };
    public void ShowProfile()
    {
        Console.WriteLine("이름: " + name);
        Console.WriteLine("나이: " + Age);
        Console.WriteLine("닉네임: " + nickName);
        Console.WriteLine("사이트: " + string.Join(", ", websites));
    }
}

//## 과제 14: 게임 캐릭터 클래스

`GameCharacter` 클래스에 인스턴스 필드, 정적 필드, 읽기 전용 필드, 상수를 모두 활용합니다. 2명의 캐릭터를 만들고 상태를 출력한 뒤, 한 캐릭터가 데미지를 받는 과정을 구현합니다.
GameCharacter hero = new GameCharacter("용사", 15);
GameCharacter mage = new GameCharacter("마법사", 25);

hero.ShowStatus();
Console.WriteLine();
mage.ShowStatus();
Console.WriteLine();

hero.TakeDamage(30);
hero.TakeDamage(50);
hero.TakeDamage(50);

Console.WriteLine();
GameCharacter.ShowTotalCharacters();

class GameCharacter
{
    private string name;
    private int health;
    private int attack;

    private static int characterCount = 0;
    private readonly int maxHealth = 100;
    private const int MinHealth = 0;
    public GameCharacter(string name, int attack)
    {
        this.name = name;
        this.health = maxHealth;
        this.attack = attack;
        characterCount++;
    }
    public void TakeDamage(int attack)
    {
        health = health - attack;
        if (health < MinHealth)
        {
            health = MinHealth;
        }
        Console.WriteLine(name + "이(가) " + attack + " 데미지를 받음! 남은 체력: " + health);
    }
    public void ShowStatus()
    {
        Console.WriteLine("=== " + name + " ===");
        Console.WriteLine("체력: " + health + "/" + maxHealth);
        Console.WriteLine("공격력: " + attack);
    }
    public static void ShowTotalCharacters()
    {
        Console.WriteLine("총 캐릭터 수: " + characterCount);
    }
}
