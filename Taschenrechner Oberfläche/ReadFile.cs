using System;
using System.Collections.Generic;
using System.Text;

namespace Taschenrechner_Oberfläche
{/// <summary>
/// Diese Klasse enthält Methoden, um .txt-Dateien einzulsen, die Terme enthalten, einzulesen.
/// Hierbei gibt es zwei Methoden:
///     ShowInConsole, welche die Ergebnisse direkt in der Konslle anzeigt
///     
///     SaveInFile, welche eine neue .txt-Datei erstellt, die die gelösten Terme enthält.
/// </summary>
    class ReadFile
    {

        public static void ShowInConsole ()
        {
            string path = "";
            path = @"C:\Users\lerichsen\Desktop\Aufgaben.txt";
            if (path == "")
            {
                path = Console.ReadLine();
            }

            string[] fileContent = { "" };
            if (System.IO.File.Exists(path))
            {
                fileContent = System.IO.File.ReadAllLines(path);
            }
            else
            {
                Console.WriteLine("Die Datei existier nicht");
            }

            for (int i = 0; i < fileContent.Length; i++)
            {
                Console.WriteLine(fileContent[i] + " = " + Parser.Start(fileContent[i]) );
            }
        }

        public static void SaveInFile ()
        {
            string path = ""; 
            path = @"C:\Users\lerichsen\Desktop\Aufgaben.txt";
            string destinationPath = "";
            destinationPath = @"C:\Users\lerichsen\Desktop\Lösungen.txt";
            if (path == "")
            {
                Console.WriteLine("Pfad der die Aufgaben enthaltenden Datei:");
                path = Console.ReadLine();
            }
            if (destinationPath == "")
            {
                Console.WriteLine("Pfad der Datei, die die Lösungen enthalten soll:");
                destinationPath = Console.ReadLine();
            }
            string[] fileContent = { "" };
            if (System.IO.File.Exists(path))
            {
                fileContent = System.IO.File.ReadAllLines(path);
            }
            else
            {
                Console.WriteLine("Die Datei existier nicht");
            }

            string[] Answers = new string[fileContent.Length];

            for (int i = 0; i < fileContent.Length; i++)
            {
                Answers[i] = (fileContent[i] + " = " + Parser.Start(fileContent[i]));
            }

            System.IO.File.WriteAllLines(destinationPath, Answers);
            Console.WriteLine("Die Datei wurde in " + destinationPath + " gespeichert");
        }

    }
}
