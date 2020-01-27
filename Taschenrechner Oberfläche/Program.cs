using System;

namespace Taschenrechner_Oberfläche
{
    /// <summary>
    /// Zum Umsetzen:
    /// 
    /// Feherhafte Eingaben erkennen
    ///
    /// </summary>
    class Program
    {
        /// Definition der Klassenvariablen
        ///

        static Boolean End = false;

        ///     H A U P T P R O G R A M M 

        /// <summary>
        /// Das Hauptprogramm, welches in einer Endlosschleife läuft, bis die Variable END auf true gesetzt wurde.
        /// Innerhalb dieser Schleife startet die Unterfunktion ConsoleInterface.
        /// </summary>
        /// <param name="args"></param>
        static void FormerMain(string[] args)
        {
            double art = 3.2;
            Console.WriteLine(3+-2);
            Console.WriteLine(art);
            Console.WriteLine(art.ToString());
            string test = "01234()567";
            Console.WriteLine(test);
            test = test.Replace("()", "");
            Console.WriteLine(test);
            


            while (!End)
            {
                ConsoleInterface();
                //Console.ReadLine();
            }
        }






        /// <summary>
        /// Die Funktion consoleMainMenu stellt das Hauptmenü in der Konsole dar und fordert den Nutzer auf einen Term einzugeben 
        ///     Dieser Term wird, sofern der Nutzer das Programm nicht beenden möchte, dem Parser übergeben, der diesen in kleine Abschnitte unterteilt
        ///     und diese zum berechnen weitergibt.
        /// 
        /// </summary>
        static void ConsoleInterface()
        {
            //Darstellung des Hauptmenüs mit den möglichen Optionen und wichtigen Hinweisen.
            Console.WriteLine("Berechnen sie einen Term ihrer Wahl.");
            Console.WriteLine();

            Console.WriteLine("Wählen sie zwischen den folgenden Rechenoptionen:");
            Console.WriteLine("     +: Addition                 -: Subtraktion");
            Console.WriteLine("     *: Multiplikation           /: Division");
            Console.WriteLine("   x^n: n-te Potenz von x      xVn: n-te Wurzel von x");
            Console.WriteLine("     !: Fakultät                 ");
            Console.WriteLine("    (): Klammersetzung                 ");
            Console.WriteLine("WICHTIG: Verwenden sie keine Leerzeichen."); //beim Parser Leerzeichen entfernen??
            Console.WriteLine();
            Console.WriteLine("     D: Datei einlesen und die Ergebnisse in der Konsole anzeigen.");
            Console.WriteLine("     A: Datei einlesen und Ergebnisse in einer Ausgabe-Datei speichern.");
            Console.WriteLine();


            Console.WriteLine("     E: Programm beenden");
            Console.WriteLine();

            //Aufnahme der Eingabe des Nutzers
            string input;
            input = Console.ReadLine();
            input = input.ToLower();

            //Überprüfen, ob der Nutzer das Programm beenden möchte.
            //  Wenn die nicht der Fall ist, wird die Eingabe dem Parser übergeben und das Ergebnis wird angezeigt.
            if (input == "e")
            {
                End = true;
            }
            else if (input == "")
            {

            }
            else if (input == "h") 
            {
                OptionsHelp();
            }
            else if (input == "d")
            {
                ReadFile.ShowInConsole();
                Console.ReadLine();
            }
            else if (input == "a")
            {
                ReadFile.SaveInFile();
                Console.ReadLine();
            }
            else if (input == "r")
            {

            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("E R G E B N I S: " + Parser.Start(input));
                Console.WriteLine();
                Console.WriteLine("Drücke eine Taste...");
                Console.ReadLine();
            }
        }


        #region Optinen
        /// Ab hier folgen Unterprogramme, welche die sonstigen Optionen des Programmes bearbeiten.
        ///

        /// <summary>
        /// Das Programm optionsHelp zeigt die Hilfe an.
        /// </summary>
        static void OptionsHelp()
        {
            Console.WriteLine("Hier stehen theoretisch hilfreiche Dinge.");

            Console.ReadLine();
        }
    }

    #endregion
}
