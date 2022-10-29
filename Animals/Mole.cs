namespace Lessons_7_8;

public class Mole : Animal
{
    public Mole(int age, string color) : base(age, color)
    {
    }

    public override void Breath()
    {
        Console.WriteLine("Дышу");
    }

    public override void Move()
    {
        Console.WriteLine("Рою");
    }

    public override void Eat()
    {
        Console.WriteLine("Ем насекомых");
    }
}