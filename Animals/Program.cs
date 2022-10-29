using Lessons_7_8;

var mole = new Mole(2, "gray");
var frog = new Frog(1, "yellow");
var sloth = new Sloth(3, "brown");

Console.WriteLine("Крот:");
mole.Breath();
mole.Move();
mole.Eat();

Console.WriteLine();
Console.WriteLine("Лягушка:");
frog.Breath();
frog.Move();
frog.Eat();

Console.WriteLine();
Console.WriteLine("Ленивец:");
sloth.Breath();
sloth.Move();
sloth.Eat();