enum VersionSort
{
    Reverse,
    Normal
}
enum RetutnedTypeNum
{
    Positive, Negative
}
enum Actions
{
    Sort,
    Return,
    Invers
}

class Programma
{
    public void Start(Actions actions, int[,] matrics)
    {
       
        ShowMeArray(matrics);
        MethodAction(actions, matrics);
    }
    public void MethodAction(Actions actions, int[,] matrics)
    {
        try
        {
            Console.Write(actions == Actions.Return ? "Показать только отрицательные/положительные: " : (actions == Actions.Sort) ? "Отсортировать массив в обратном/нормальном порядке: " : "Инверсирую...");
            switch (actions)
            {
                case Actions.Return:
                    switch (Console.ReadLine())
                    {
                        case "положительные":
                            Console.WriteLine(matrics.TakeMeAllTypesNumber(RetutnedTypeNum.Positive));
                            break;
                        case "отрицательные":
                            Console.WriteLine(matrics.TakeMeAllTypesNumber(RetutnedTypeNum.Negative));
                            break;
                        default:
                            Console.WriteLine(matrics.TakeMeAllTypesNumber(RetutnedTypeNum.Positive));
                            Console.WriteLine(matrics.TakeMeAllTypesNumber(RetutnedTypeNum.Negative));
                            break;
                    }
                    break;

                case Actions.Sort:
                    switch (Console.ReadLine())
                    {
                        case "обратном":
                            ShowMeArray(matrics.SortNumbers(VersionSort.Reverse));
                            break;
                        case "нормальном":
                            ShowMeArray(matrics.SortNumbers(VersionSort.Normal));
                            break;
                        default:
                            Console.WriteLine("Не один из вариантов не был выбран");
                            break;
                    }
                    break;
                case Actions.Invers:
                    Console.WriteLine();
                    ShowMeArray(matrics.InversNumbers());
                    break;
            }
        }
        catch
        {
            Console.WriteLine("Произошла ошибка");
        }
    }
    static void ShowMeArray(int[,] array)
    {
        for(int i = 0;i < array.GetLength(0); i++)
        {
            for (int j = 0;j < array.GetLength(1); j++)
            {
                Console.Write(array[i,j] + " ");
            }
            Console.WriteLine();
        }
    }
}
class Work
{
    static void Main()
    {

        try
        {
            Console.Write("Введите размеры матрицы: ");
            uint sizeMatrics = Convert.ToUInt32(Console.ReadLine());
            int[,] matrics = new int[sizeMatrics, sizeMatrics];
            for (int i = 0; i < matrics.GetLength(0); i++)
            {
                for (int j = 0; j < matrics.GetLength(1); j++)
                {
                    matrics[i, j] = new Random().Next(-10, 10);
                }
            }
            Console.WriteLine("Выберите действия: \n1.Показать сколько положительных/отрицательных чисел\n2.Отсортировать массив\n3.Инверсировать массив.");
            var program = new Programma();
            switch (Convert.ToInt32(Console.ReadLine()))
            {
                case 1:
                    program.Start(Actions.Return, matrics);

                    break;
                case 2:
                    program.Start(Actions.Sort, matrics);
                    break;
                case 3:
                    program.Start(Actions.Invers, matrics);
                    break;
                default: Console.WriteLine("Не соответствует списку"); break;
            }
        }
        catch
        {
            Console.WriteLine("произошла ошибка");
        }

    }
    
}
static class MyWorkToArray
{
    public static int[,] InversNumbers(this int[,] array)
    {
        int[] saver = new int[array.GetLength(0)];
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                saver[saver.Length - 1 - j] = array[i, j];
            }
            for (int k = 0; k < array.GetLength(1); k++)
            {
                array[i, k] = saver[k];
            }
        }
        return array;
    }
    
    public static string TakeMeAllTypesNumber(this int[,] array, RetutnedTypeNum type)
    {
        (int, int) counters = (0, 0);
        for(int i = 0; i < array.GetLength(0); i++)
        {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                   counters.Item1 += (Convert.ToInt32(array[i, j]) > 0) ? 1 : 0;
                   counters.Item2 += (Convert.ToInt32(array[i, j]) < 0) ? 1 : 0;
                 
                }
        }
        return (type == RetutnedTypeNum.Positive) ? "Pos number:" + counters.Item1.ToString() : "Neg number:" + counters.Item2.ToString();
    }
    public static int[,] SortNumbers(this int[,] array,VersionSort sortOptions)
    {
        
        int[] arraySaver = new int[array.GetLength(0)];
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                arraySaver[j] = array[i, j];
            }
            Sorter(ref arraySaver,sortOptions);
            for(int k = 0;  k < array.GetLength(1); k++)
            {
                array[i, k] = arraySaver[k];
            }
        }
        return array;
    }
    static void Sorter(ref int[] array, VersionSort sortOptions)
    {
        int NumSaver;
        for (int i = 1;i < array.Length; i++)
        {
            for(int j = 0; j < array.Length - i; j++)
            {
                if (sortOptions == VersionSort.Normal)
                {
                    if (array[j] > array[j + 1])
                    {
                        NumSaver = array[j + 1];
                        array[j + 1] = array[j];
                        array[j] = NumSaver;
                    }
                }
                if(sortOptions == VersionSort.Reverse)
                {
                    if (array[j] < array[j + 1])
                    {
                        NumSaver = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = NumSaver;
                    }
                }
            }
        }
       
    }
}