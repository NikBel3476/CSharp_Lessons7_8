namespace Lessons_7_8;

public class Frog : Animal
{
    public Frog(int age, string color) : base(age, color)
    {
    }

    public override void Breath()
    {
        Console.WriteLine("Дышу");
    }

    public override void Move()
    {
        Console.WriteLine("Прыгаю");
    }

    public override void Eat()
    {
        Console.WriteLine("Ем насекомых");
    }
}