namespace Lessons_7_8;

public class Sloth : Animal
{
    public Sloth(int age, string color) : base(age, color)
    {
    }

    public override void Breath()
    {
        Console.WriteLine("Дышу");
    }

    public override void Move()
    {
        Console.WriteLine("Ползу");
    }

    public override void Eat()
    {
        Console.WriteLine("Ем листья");
    }
}