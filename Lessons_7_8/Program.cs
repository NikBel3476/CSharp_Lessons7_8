using Lessons_7_8;

var list = new MyList<string>(new [] { "a" });

list.Add("b");
Console.WriteLine($"{list}. Capacity: {list.Capacity}, Count: {list.Count}");

list.Add("c");
Console.WriteLine($"{list}. Capacity: {list.Capacity}, Count: {list.Count}");

list.Add("d");
list.Add("e");
Console.WriteLine($"{list}. Capacity: {list.Capacity}, Count: {list.Count}");

list.RemoveAt(2);
Console.WriteLine($"{list}. Capacity: {list.Capacity}, Count: {list.Count}");

list.Remove("a");
Console.WriteLine($"{list}. Capacity: {list.Capacity}, Count: {list.Count}");

Console.WriteLine($"Первый элемент: {list[0]}");

list[1] = "new";
Console.WriteLine($"{list}. Capacity: {list.Capacity}, Count: {list.Count}");