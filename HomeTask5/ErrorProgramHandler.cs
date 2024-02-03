using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFromHomeTask
{
    public class ErrorProgramHandler : ApplicationException
    {
        public ErrorProgramHandler(MyError obj) : base(obj.textError)
        {
        }
    }
    public abstract class MyError : ApplicationException
    {
        public abstract string textError { get; }
       
    }
    public class MyFormatExeption : MyError
    {
       
        public string Recomendation = "Используйте файл с форматом .txt";
        public override string textError => "Error "  + " " + typeof(MyFormatExeption) + Recomendation;
        
    }
}
