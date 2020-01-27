using System;
using System.Collections.Generic;
using System.Text;

namespace Taschenrechner_Oberfläche
{
    public class Calculation
    {
        /// <summary>
        /// Die Funktion wählt anhand der Übergabevariable operationIndex die passende Rechenoperation aus 
        ///     und wendet diese auf die Übergabevariable X und Y an.
        ///     
        /// Die Kodierung von operationIndex ist:
        ///     operationIndex      Rechenoperation                 
        ///     0                   !
        ///     1                   %
        ///     2                   ^
        ///     3                   Wurzel ziehen
        ///     4                   *
        ///     5                   /
        ///     6                   +
        ///     7                   -
        ///     8
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <param name="operationIndex"></param>
        /// <returns></returns>
        public static Double ChooseOperation(double X, double Y, double operationIndex)
        {
            double output = 0.0;

            switch (operationIndex)
            {
                case 6:
                    output = X + Y;
                    //Console.WriteLine(X + " + " + Y + " = " + output);
                    break;

                case 7:
                    output = X - Y;
                    //Console.WriteLine(X + " - " + Y + " = " + output);
                    break;

                case 4:
                    output = X * Y;
                    //Console.WriteLine(X + " * " + Y + " = " + output);
                    break;

                case 5:
                    output = X / Y;
                    //Console.WriteLine(X + " / " + Y + " = " + output);
                    break;

                case 2:
                    output = Math.Pow(X, Y);
                    //Console.WriteLine(X + " ^ " + Y + " = " + output);
                    break;

                case 3:
                    output = Math.Pow(X, 1 / Y);
                    //Console.WriteLine(X + " ^ (1/" + Y + ") = " + output);
                    break;

                case 0:
                    output = 1;
                    for (int i = 1; i <= X; i++)
                    {
                        output = output * i;
                    }
                    //Console.WriteLine(X + "!= " + output);
                    break;

                case 1:
                    output = X%Y;
                    //Console.WriteLine(X + " mod " + Y + " = " + output);
                    break;

                default:
                    //Console.WriteLine("Ungültige Eingabe. Versuche es erneut.");
                    break;
            }
            return output;

        }
        /// <summary>
        /// Diese UnterFunktion wandelt eine String-Variable, welche bestimme Bedingungen erfüllt in eine Zufällige ganze Zahl um.
        /// 
        /// Die Funktion zerlegt die Eingabe der Nutzers in relevante Informationen und wandelt diese je nach Art der Eingabe in
        ///     eine zufällige Zahl um.
        ///     Eingabe:    R(Integer X          ): zufällige Zahl aus dem Bereich 0 bis X
        ///                 R(Integer X,Integer Y): zufällige Zahl aus dem Bereich X bis Y
        /// 
        /// Übergabewert: String input
        ///                 Die Variable, muss mit "R(" Starten und mit ")" enden.
        ///                 Die Variable darf BIS ZU zwei ganze Zahlen enthalten, die durch ein Koma getrennt werden.
        ///                 Es sind Keine Leerzeichen enthalten.
        /// Ausgabewert:  Double output (output ist immer eine ganze Zahl)
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static Int32 RandomNumber(string input)
        {
            //Initialisieren einer Zufallsvariable
            Random rnd = new Random();
            //Initialisieren von relevanten Variablen
            int positionOfPeriod = 0;
            int lowerBorder = 0;
            int upperBorder = 100;
            int output = 0;

            //Zerlegen und Anpassen der Eingabe, welche in input gespeichert ist
            input = input.Substring(2, ((input.Length - 1) - 2));
            input = input.Replace('.', ',');
            //Überprüfen, ob die Eingabe  ein Komma enthält und Speichern der Position dessen
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == ',')
                {
                    positionOfPeriod = i;
                }
            }
            //Überprüfen, ob der Input verwendbar ist. (Nur ein Komma und sonst nur Zahlen)
            //  Sofern dies der Fall ist, wirddie zur Eingabe passende zufallszahl bestimmt.
            //  Sollte kein Komma existieren (PositionOfPerion = 0, so wird eine Zahl vom Bereich 0 bis X gewünscht)
            //        andererseits wird eine Zahl aus einem Intervall gesucht, welches nicht bei 0 beginnt.
            try
            {
                //Überprüfen der Eingabe, die hier Erzeugt Double wird nicht weichter verwendet
                Double.Parse(input);
                //Ausführen der passenden Zufallsfunktion
                if (positionOfPeriod == 0)
                {
                    upperBorder = Int32.Parse(input);
                    output = rnd.Next(0, upperBorder);
                }
                else
                {
                    lowerBorder = Int32.Parse(input.Substring(0, (positionOfPeriod)));
                    upperBorder = Int32.Parse(input.Substring((positionOfPeriod + 1), (input.Length - (positionOfPeriod + 1))));
                    output = rnd.Next(lowerBorder, upperBorder);
                }
                //Darstellen und Ausgabe der Zufallsahl
                Console.WriteLine("Zufall: " + output);
                return output;
            }
            //Sollte die Ausgabe fehlerhaft sein, wird eine spezifische Fehlermeldung ausgegeben und die Variable WrongInput = true gesetzt,
            //      was eine erneute Abfrage seitens des Programms startet
            catch (Exception)
            {
                Console.WriteLine("Ungültige Eingabe. Versuche es erneut oder beende das Programm mit [E]");
                Console.WriteLine("     Zufällige Zahlen: R(Max) oder R(Min,Max) ohne Leerzeichen");
            }
            return output;
        }


    }
}
