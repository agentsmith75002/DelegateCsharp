using System;

namespace DelegateNamespace
{
    class Program
    {
        static void Main(string[] args)
        {
            Display(ToStringInt,12);

            IntProvider intProv = new IntProvider();
            intProv.ToStringHandler += ToStringInt;
            intProv.Display(12);
        }

        /// <summary>
        /// Execute l'évaluation du Func
        /// </summary>
        /// <param name="stringer">déclaration de fonction qui prend un int en arg et retourne string</param>
        /// <param name="val">value to display</param>
        static void Display(Func<int,string> stringer, int val)
        {
            Console.WriteLine("Console.Display: " + stringer(val));
        }

        static string ToStringInt(int val)
        {
            return $"{val}";
        }
    }

    public delegate string ToStringDelegate(int val);
    public class IntProvider
    {
        public ToStringDelegate ToStringHandler;

        /// <summary>
        /// Utilisation du delegate
        /// </summary>
        /// <param name="val"></param>
        public void Display(int val)
        {
            if(ToStringHandler != null) Console.WriteLine("IntProvider.Display: " + ToStringHandler(val));
        }

    }
}
