using System;

namespace Test_NurEinmalErsetzen
{
    class Program
    {
        static void Main(string[] args)
        {
            string Alles = "Hallo Welt!";
            string Ersetzen = "llo We";
            string Einsetzen = "äke";
            
            Console.WriteLine(Alles);

            Alles = replaceFirst(Alles, Ersetzen, Einsetzen);

            Console.WriteLine(Alles);

        }


        public static string replaceFirst(string wholeTerm, string oldSubterm, string newSubterm)
        {
            int oldSubtermLength = oldSubterm.Length;
            string ReplAllStr = wholeTerm;

            Console.WriteLine(oldSubtermLength);

            for (int i = 0; i < ReplAllStr.Length - (oldSubtermLength); i++)
            {
                Console.WriteLine(ReplAllStr.Substring(i, oldSubtermLength));
                Console.WriteLine(ReplAllStr.Substring(i, oldSubtermLength).Contains(oldSubterm));
                Console.WriteLine("-------------");
                if (ReplAllStr.Substring(i, oldSubtermLength).Contains(oldSubterm))
                {
                    ReplAllStr = ReplAllStr.Remove(i, oldSubtermLength);
                    Console.WriteLine(ReplAllStr);
                    ReplAllStr =  ReplAllStr.Insert(i, newSubterm);
                    Console.WriteLine(ReplAllStr);
                    i = ReplAllStr.Length + 1000;
                }
            }

            return ReplAllStr;
        }
    }


}
