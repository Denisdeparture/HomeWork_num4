using System.Numerics;
using System.Threading.Channels;

class Work
{
    enum OptionsFromHMFive
    {
        defaultUserOptins,
        ProgrammerTestOptions
    }
    static void Main()
    {
        HomeWork5(OptionsFromHMFive.ProgrammerTestOptions);
    }
    static void HomeWork1()
    {
        for (int i = 1; i < 99; i++)
        {
            if (i % 2 != 0) Console.WriteLine("число - {0} не чётное", i);
        }
    }
    static void HomeWork2()
    {
        for(int i = 5; i > 1; i--)
        {
            Console.WriteLine(i);
        }
    }
    static void HomeWork3()
    {
        Console.Write("Введите положительное число: ");
        try
        {
            uint counter = 1;
            for (; counter < Convert.ToUInt32(Console.ReadLine());)
            {
                counter++;
            }
            Console.WriteLine("ваше сумма всех чисел от 1 до {0} = {0}", counter);
        }
        catch
        {
            Console.WriteLine("Вы ввели не положительное число");
        }
    }
    static void HomeWork4()
    {
        int secondFactor = 1;
        for (int i = 7; i < 98;)
        {
            i *= secondFactor++;
            Console.WriteLine(i);
        }
    }
    static void HomeWork5(OptionsFromHMFive options)
    {
        int[] arrayOne = new int[5].Select(i => new Random().Next(0, 10)).ToArray(), 
        arrayTwo = new int[5].Select(i => new Random().Next(0, 10)).ToArray();
        // можно использовать любой из 2 массивов, у них одинаковая длинна
        (int, int) nums = (0, 0);
        for(int i = 0; i < arrayOne.Length; i++)
        {
            nums.Item1 += arrayOne[i];
            nums.Item2 += arrayTwo[i];
        }
        if (options == (OptionsFromHMFive.defaultUserOptins | OptionsFromHMFive.ProgrammerTestOptions))
        {
            Console.WriteLine(((nums.Item1 / 5) > (nums.Item2 / 5)) ? "среднее арифметическое массива один больше" : ((nums.Item1 / 5) < (nums.Item2 / 5) ? "среднее арифметическое второго массив больше" : "среднее арифметическое массивов равны"));
        }
        #region Доп опции 
        if (options == OptionsFromHMFive.ProgrammerTestOptions)
        {
            Console.WriteLine("Массив 1 был: ");
            foreach (int i in arrayOne) Console.Write(i + ",");
            Console.WriteLine();
            Console.WriteLine("Массив 2 был: ");
            foreach (int i in arrayTwo) Console.Write(i + ",");
        }
        #endregion
    }
}
