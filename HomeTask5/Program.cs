using Microsoft.VisualBasic;
using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
class Work
{
    static void Main()
    {
        const int SmallFunctionalThisClass = 2;
        try
        {
            Console.Write("С чем вы будете работать: \n1.С файлом\n2.С текстом из консоли");
            WorkToString obj;
            string[] ListOperationFromArray =
            {
            "Найти слова, содержащие максимальное количество цифр",
            "Найти самое длинное слово и определить, сколько раз оно встретилось в тексте",
            "Заменить цифры от 0 до 9 на слова ",
            "Вывести на экран сначала вопросительные, а затем восклицательные предложения",
            "Вывести на экран только предложения, не содержащие запятых",
            "Найти слова, начинающиеся и заканчивающиеся на одну и ту же букву"
        };
            Console.WriteLine();


            switch (Convert.ToUInt32(Console.ReadLine()))
            {
                case 1:


                    Console.Write("Впишите путь до текстового файла: ");
                    obj = new WorkToStringInFile(Console.ReadLine() + ".txt");
                    CollectionFileMethod objHasfunctionThisClass = (CollectionFileMethod)obj;
                    int counter = 1;
                    Console.WriteLine("Выберите операцию: ");
                    for (int i = 0; i < ListOperationFromArray.Length; i++)
                    {
                        Console.WriteLine($"{counter}.{ListOperationFromArray[i]}");
                        counter++;
                    }
                    switch (Convert.ToUInt32(Console.ReadLine()))
                    {
                        case 1:
                            Console.WriteLine(obj.TheBiggestStringHasNum());
                            break;
                        case 2:
                            int res = obj.TheLongestWordAppear();
                            Console.WriteLine($"Самое длинное слово {obj.TheBiggestWord} оно встретилось {res} раз");
                            break;
                        case 3:
                            Console.WriteLine(obj.ReplaceNumOfStr());
                            break;
                        case 4:
                            objHasfunctionThisClass.ShowMeInterrogativeAndyExclamatorySentence();
                            break;
                        case 5:
                            objHasfunctionThisClass.ShowMeSentenceHasNotComma();
                            break;
                        case 6:
                            objHasfunctionThisClass.ShowMeWordWhereEndESStart();
                            break;
                        default:
                            Console.WriteLine("Такого действия нет");
                            break;
                    }
                    break;
                case 2:
                    Console.Write("Впишите текст: ");
                    obj = new WorkToStringInConsole(Console.ReadLine());
                    Console.WriteLine("Выберите операцию: ");
                    for (int i = 1; i < ListOperationFromArray.Length - SmallFunctionalThisClass; i++)
                    {
                        Console.WriteLine($"{i}.{ListOperationFromArray[i - 1]}");
                    }
                    switch (Convert.ToUInt32(Console.ReadLine()))
                    {
                        case 1:
                            Console.WriteLine(obj.TheBiggestStringHasNum());
                            break;
                        case 2:
                            int res = obj.TheLongestWordAppear();
                            Console.WriteLine($"Самое длинное слово {obj.TheBiggestWord} оно встретилось {res} раз");
                            break;
                        case 3:
                            Console.WriteLine(obj.ReplaceNumOfStr());
                            break;
                        default:
                            Console.WriteLine("Такого действия нет");
                            break;

                    }
                    break;
            }
        }
        catch
        {
            Console.WriteLine("Произошла ошибка");
        }
        
        
       
    }
}
abstract class WorkToString
{
    public abstract string ReplaceNumOfStr();
    public abstract string TheBiggestStringHasNum();
    public abstract int TheLongestWordAppear();
    public abstract string TheBiggestWord { get;  set; }
   

}
interface CollectionFileMethod
{
    public void ShowMeInterrogativeAndyExclamatorySentence();
    public void ShowMeSentenceHasNotComma();
    public void  ShowMeWordWhereEndESStart();
}
class WorkToStringInFile : WorkToString, CollectionFileMethod
{
    private string path;
    private FileStream? file;
    public WorkToStringInFile(string pathFromFile)
    {
        string Error = string.Empty;
        path = pathFromFile;
        const string formatFile = ".txt";
        
        file = new FileStream(pathFromFile, FileMode.Open, FileAccess.ReadWrite);
    }
    public override string TheBiggestWord { get; set; } = string.Empty;
    public override int TheLongestWordAppear()
    {
        WorkToStringInConsole obj = new WorkToStringInConsole();
        int value = obj.TheLongestWordAppear(ValueFromFile());
        TheBiggestWord = obj.TheBiggestWord;
        return value;
    }
    private string[] ValueFromFile()
    {
        string Value = string.Empty;
        string RecordingStr;
        StreamReader objReader = new StreamReader(file);
        while (!objReader.EndOfStream)
        {
            RecordingStr = new string(objReader.ReadLine().Where(x => x != '\n').ToArray());
            Value += RecordingStr;
        }
        objReader.Close();
        return Value.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
    }
    public override string TheBiggestStringHasNum()
    {
        return new WorkToStringInConsole().TheBiggestStringHasNum(ValueFromFile());
    }
    public override string ReplaceNumOfStr()
    {
        string[] strings = ValueFromFile();
        string Saver = string.Empty;
        StreamWriter objWriter = new StreamWriter(path, append: false);
        WorkToStringInConsole obj = new WorkToStringInConsole();
        objWriter.Write(strings);
        return "Success";
    }
    void CollectionFileMethod.ShowMeInterrogativeAndyExclamatorySentence()
    {
        string[] strings = ValueFromFile();
        string[] arrayInterrogativeSentence = string.Join(" ", strings).Split(new char['?']);
        string[] arrayExclamatorySentence = string.Join(" ", strings).Split(new char['!']);
        ShowSentence(arrayExclamatorySentence, "Все восклицательные предложения: ", '!');
        ShowSentence(arrayInterrogativeSentence, "Все вопросительные предложения: ", '?');
    }
    void CollectionFileMethod.ShowMeSentenceHasNotComma()
    {

        string[] strings = ValueFromFile();
        List<string> list = new List<string>();
        bool redFlag = true;
        foreach(string str in strings)
        {
            foreach(char ch in str)
            {
                if(ch == ',')
                {
                    redFlag = false;
                }
            }
            if(redFlag) { list.Add(str); }
            else { redFlag = true; }
        }
        ShowSentence(list.ToArray(), "Все предложения содержащие не содержащие запятых");
    }
    void CollectionFileMethod.ShowMeWordWhereEndESStart() => ShowSentence(ValueFromFile().Where(x => x[0] == x[x.Length-1]).ToArray(), "Все слова начинающиеся и заканчивающиеся на один символ: ");
    
    private void ShowSentence(string[] array, string text, char endSymb = ' ')
    {
        Console.WriteLine(text);
        foreach (string str in array)
        {
            Console.WriteLine(str + endSymb.ToString());
        }
    }

}
class WorkToStringInConsole : WorkToString
{

    private string[] strings;
    const int rulesArray = 1;
    public WorkToStringInConsole(string text)
    {
       strings = text.Trim().Split(new char[] { ' ', '\n','\t' }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.ToLower()).ToArray();
    }
    public WorkToStringInConsole()
    {
    }
        public override string ReplaceNumOfStr()
        {
            StringBuilder stringBuilder = new StringBuilder();
            string Saver = string.Empty;
            int result;
            foreach (string s in strings)
            {
                stringBuilder = new StringBuilder(s);
                foreach (char ch in s)
                {
                    if (int.TryParse(ch.ToString(), out result))
                    {
                        stringBuilder.Replace(result.ToString(), result.RUNum());
                    }

                }
                Saver += stringBuilder.ToString();
            }
            return Saver;
        }
    public string ReplaceNumOfStr(string[] defaultFilterArray)
    {
        StringBuilder stringBuilder = new StringBuilder();
        string Saver = string.Empty;
        int result;
        foreach (string s in defaultFilterArray)
        {
            stringBuilder = new StringBuilder(s);
            foreach (char ch in s)
            {
                if (int.TryParse(ch.ToString(), out result))
                {
                    stringBuilder.Replace(result.ToString(), result.RUNum());
                }

            }
            Saver += stringBuilder.ToString();
        }
        return Saver;
    }
    public override string TheBiggestStringHasNum()
    {
        int index = default, result;
        string Saver = string.Empty;
        List<string> listStrHasNum = new List<string>();
        for (int i = 0; i < strings.Length; i++)
        {
            foreach (char c in strings[i])
            {
                if (int.TryParse(c.ToString(), out result))
                {
                    Saver += result.ToString();

                }
                else
                {
                    continue;
                }
            }
            listStrHasNum.Add(Saver);
            Saver = string.Empty;
        }
        string MaxValueNum = listStrHasNum[0];
        
        for (int i = 0; i < listStrHasNum.Count; i++)
        {
            if (MaxValueNum.Length <= listStrHasNum[i].Length)
            {
                MaxValueNum = listStrHasNum[i];
                index = i;
            }
        }
        return string.Format("Самое большое количество цифр {0} в {1} строке", MaxValueNum, index + rulesArray);

    }
    public  string TheBiggestStringHasNum(string[] defaultFilterText)
    {
        int index = default, result;
        string Saver = string.Empty;
        List<string> listStrHasNum = new List<string>();
        for (int i = 0; i < defaultFilterText.Length; i++)
        {
            foreach (char c in defaultFilterText[i])
            {
                if (int.TryParse(c.ToString(), out result))
                {
                    Saver += result.ToString();

                }
                else
                {
                    continue;
                }
            }
            listStrHasNum.Add(Saver);
            Saver = string.Empty;
        }
        string MaxValueNum = listStrHasNum[0];

        for (int i = 0; i < listStrHasNum.Count; i++)
        {
            if (MaxValueNum.Length <= listStrHasNum[i].Length)
            {
                MaxValueNum = listStrHasNum[i];
                index = i;
            }
        }
        return string.Format("Самое большое количество цифр {0} в {1} строке", MaxValueNum, index + rulesArray);

    }
    public override string TheBiggestWord { get; set; } = string.Empty;
    public override int TheLongestWordAppear()
        {
            
            string MaxValue = strings[0];
            
            int index = default;
            for (int i = 0; i < strings.Length; i++)
            {
                if (MaxValue.Length < strings[i].Length)
                {
                    MaxValue = strings[i];
                    index = i;
                }
            }

            TheBiggestWord = MaxValue;
            return strings.Count(x => x == MaxValue);
        }
    public int TheLongestWordAppear(string[] defaultFilterText)
    {
        
        string MaxValue = defaultFilterText[0];
        int index = default;
        for (int i = 0; i < defaultFilterText.Length; i++)
        {
            if (MaxValue.Length < defaultFilterText[i].Length)
            {
                MaxValue = defaultFilterText[i];
                index = i;
            }
        }

        TheBiggestWord = MaxValue;
        return defaultFilterText.Count(x => x == MaxValue);
    }
}
static class MyWork
    {
        public static string RUNum(this int num)
        {
            string[] arrayRuVersionNum =
            {
            "ноль",
            "один",
            "два",
            "три",
            "четыре",
            "пять",
            "шесть",
            "семь",
            "восемь",
            "девять",
        };
            return arrayRuVersionNum[num];
        }
    }

