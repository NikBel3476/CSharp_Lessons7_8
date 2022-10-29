using Exceptions;

try
{
    Random rnd = new Random();
    int i = rnd.Next(0, 3);
    switch (i)
    {
        case 0:
            throw new MyException("Unauthorized", 401);
        case 1:
            int zero = 0;
            int result = 1 / zero;
            break;
        case 2:
            var array = Array.Empty<string>();
            var element = array[1];
            break;
    }
}
catch (MyException e)
{
    Console.WriteLine($"{e.Message} {e.ErrorCode}");
}
catch (DivideByZeroException e)
{
    Console.WriteLine("Деление на ноль");
}
catch (IndexOutOfRangeException e)
{
    Console.WriteLine("Выход за границы массива");
}