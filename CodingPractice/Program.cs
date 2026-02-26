using System;
using System.Collections;

{
    Catalog catalog = new Catalog();
    Console.WriteLine(catalog[0]);
    Console.WriteLine(catalog[1]);
    Console.WriteLine(catalog[2]);
}

{
    Car car = new Car(3);

    car[0] = "CLA";
    car[1] = "CLS";
    car[2] = "AMG";

    for (int i = 0; i < car.Length; i++)
    {
        Console.WriteLine(car[i]);
    }
}

{
    Week week = new Week(3);

    week[0] = "일요일";
    week[1] = "월요일";
    week[2] = "화요일";

    for (int i = 0; i < week.Length; i++)
    {
        Console.WriteLine(week[i]);
    }
}

{
    var nick = new NickName();

    nick["홍길동"] = "RedPlus";
    nick["김철수"] = "BlueStar";

    Console.WriteLine($"{nick["홍길동"]}, {nick["김철수"]}");
}

{
    MultiIndexer multi = new MultiIndexer();
    multi[0] = "첫 번째 값";
    multi["name"] = "홍길동";
    multi["city"] = "서울";

    Console.WriteLine($"multi[0] = {multi[0]}");
    Console.WriteLine($"multi[\"name\"] = {multi["name"]}");
    Console.WriteLine($"multi[\"city\"] = {multi["city"]}");
}

{
    Example ex = new Example();
    ex.Name = "홍길동";
    Console.WriteLine(ex.Name);

    ex[0] = "첫 번째";
    ex[1] = "두 번째";
    Console.WriteLine($"{ex[0]}, {ex[1]}");
}

class Catalog
{
    public string this[int index]
    {
        get
        {
            return (index % 2 == 0) ? $"{index}: 짝수 반환" : $"{index}: 홀수 반환";
        }
    }
}

class Car
{
    private string[] _names;
    public Car(int length)
    {
        _names = new string[length];
    }

    public int Length
    {
        get { return _names.Length; }
    }
    public string this[int index]
    {
        get { return _names[index]; }
        set { _names[index] = value; }
    }
}

class Week
{
    private string[] _weekDays;
    public Week()
    {
        Length = 7;
        _weekDays = new string[Length];
    }

    public Week(int length)
    {
        Length = length;
        _weekDays = new string[Length];
    }
    public int Length { get; }

    public string this[int index]
    {
        get { return _weekDays[index]; }
        set { _weekDays[index] = value; }
    }
}

class NickName
{
    private Hashtable _names = new Hashtable();
    public string this[string key]
    {
        get { return _names[key].ToString(); }
        set { _names[key] = value; }
    }
}

class MultiIndexer
{
    private Hashtable _data = new Hashtable();

    public string this[int index]
    {
        get { return (_data[index].ToString()); }
        set { _data[index] = value; }
    }
    public string this[string key]
    {
        get { return _data[key].ToString(); }
        set { _data[key] = value; }
    }
}

class Example
{
    private string _name;
    private string[] _items = new string[10];

    public string Name
    {
        get { return _name; } set { _name = value; }
    }

    public string this[int index]
    {
        get { return _items[index]; }
        set { _items[index] = value; }
    }
}