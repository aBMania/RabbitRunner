using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class ScoreList
{
    static List<Score> scoreList;

    static ScoreList()
    {
        scoreList = new List<Score>();
    }

    public static void add(Score score)
    {
        scoreList.Add(score);
    }

    public static List<Score> getList()
    {
        return scoreList;
    }
}

