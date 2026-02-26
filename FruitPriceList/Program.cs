using System;
using System.Threading;

FruitPriceList fpl = new FruitPriceList(5);
fpl.Add("사과", 1500);
fpl.Add("바나나", 3000);
fpl.Add("딸기", 8000);

Console.WriteLine($"등록된 과일 수: {fpl.Count}개");
Console.WriteLine();
Console.WriteLine($"사과 가격: {fpl["사과"]}원");
Console.WriteLine($"바나나 가격: {fpl["바나나"]}원");
Console.WriteLine($"포도 가격: {fpl["포도"]}원");
Console.WriteLine();

for (int i = 0; i < fpl.Count; i++)
{
    Console.WriteLine($"{i}번: {fpl[i]}");
}

class FruitPriceList
{
    private string[] _names;
    private int[] _prices;
    private int _count;

    public FruitPriceList(int capacity)
    {
        _names = new string[capacity];
        _prices = new int[capacity];
        _count = 0;
    }

    public int Count
    {
        get { return _count; }
        private set { _count = value; }
    }

    public void Add(string name, int price)
    {
        if (_count >= _names.Length)
        {
            Console.WriteLine("가격표가 가득 찼습니다.");
            return;
        }
        _names[_count] = name;
        _prices[_count] = price;
        _count++;
    }

    public int this[string name]
    {
        get
        {
            int price = -1;
            for (int i = 0; i < _names.Length; i++)
            {
                if (name == _names[i])
                {
                    price = _prices[i];
                    break;
                }
            }
            return price;
        }
    }

    public string this[int index]
    {
        get
        {
            if (index >= _names.Length || index < 0)
            {
                return "";
            }
            return _names[index];
        }
    }
}