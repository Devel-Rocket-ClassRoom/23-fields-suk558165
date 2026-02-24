using System;

ScoreTracker math = new ScoreTracker("수학");
math.ShowScore();
Console.WriteLine();

math.SetScore(85);
math.AddBonus(10);
math.AddBonus(20);
math.SetScore(-10);
Console.WriteLine();

math.ShowScore();

