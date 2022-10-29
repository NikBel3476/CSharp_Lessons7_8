namespace Lessons_7_8;

public abstract class Animal
{
    protected string Color { get; set; }
    protected int Age { get; set; }

    protected Animal(int age, string color)
    {
        Age = age;
        Color = color;
    }

    public abstract void Breath();

    public abstract void Move();

    public abstract void Eat();
}