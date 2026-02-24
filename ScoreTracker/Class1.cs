using System;
using System.Collections.Generic;
using System.Text;

class ScoreTracker
{
    private const int maxscore = 100;
    private const int minscore = 0;
    private readonly string subjects = "";
    private int currentscore = 0;
    private int bonus = 0;
    public ScoreTracker(string subject)
    {
        this.subjects = subject;
    }
    public void SetScore(int score)
    {
        if (score >= minscore && score <= maxscore)
        {
            this.currentscore = score;
            Console.WriteLine($"점수를 {score}점으로 설정했습니다.");
        }
        else
        {
            Console.WriteLine($"점수는 {minscore}~{maxscore} 사이여야 합니다.");
        }
    }
    public void AddBonus(int score)
    {
        this.currentscore += score;
        this.bonus++;

        string message = $"{score}점 보너스 적용! 현재 점수: ";
        if (this.currentscore >= maxscore)
        {
            this.currentscore = maxscore;
            Console.WriteLine(message + $"{currentscore}점 (최대 점수 도달)");
        }
        else
        {
            Console.WriteLine(message + $"{currentscore}점");
        }
    }

    public void ShowScore()
    {
        Console.WriteLine($"=== {subjects} ===");
        Console.WriteLine($"점수: {currentscore} / {maxscore}");
        Console.WriteLine($"보너스 적용 횟수: {bonus}");


    }
}