using System;

ScoreBoard sb = new ScoreBoard(5);
sb.Register("김민수", 85);
sb.Register("이지영", 92);
sb.Register("박서준", 78);

Console.WriteLine($"등록된 학생 수: {sb.Count}");

for (int i = 0; i < sb.Count; i++)
{
    Console.WriteLine($"{i}번: {sb[i]}");
}

Console.WriteLine($"김민수 점수: {sb["김민수"]}");
Console.WriteLine($"이지영 점수: {sb["이지영"]}");
Console.WriteLine($"홍길동 점수: {sb["홍길동"]}");

sb["김민수"] = 95;

Console.WriteLine($"김민수 수정된 점수: {sb["김민수"]}");

class ScoreBoard
{
    private string[] _names;
    private int[] _scores;
    private int _count;

    public ScoreBoard(int capacity)
    {
        _names = new string[capacity];
        _scores = new int[capacity];
        _count = 0;
    }

    public int Count
    {
        get { return _count; } 
    }

    public void Register(string name, int score)
    {
        if (_count >= name.Length)
        {
            Console.WriteLine("성적표가 가득 찼습니다.");
            return;
        }
        _names[_count] = name;
        _scores[_count] = score;
        _count++;
    }

    public string this[int index]
    {
        get
        {
            if (index >= _names.Length)
            {
                return "";
            }
            return _names[index];
        }
    }

    public int this[string name]
    {
        get
        {
            int target = -1;
            for (int i = 0; i < _names.Length; i++)
            {
                if (name ==  _names[i])
                {
                    target = _scores[i];
                    break;
                }
            }
            return target;
        }
        set
        {
            for (int i = 0; i < _names.Length; ++i)
            {
                if (name == _names[i])
                {
                    _scores[i] = value;
                    break;
                }
            }
        }
    }
}