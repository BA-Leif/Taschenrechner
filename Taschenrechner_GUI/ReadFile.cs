using System;
using System.Collections.Generic;
using System.Text;

namespace Taschenrechner_GUI
{/// <summary>
/// Diese Klasse enthält Methoden, um .txt-Dateien einzulsen, die Terme enthalten, einzulesen.
/// Hierbei gibt es zwei Methoden:
///     ShowInConsole, welche die Ergebnisse direkt in der Konslle anzeigt
///     
///     SaveInFile, welche eine neue .txt-Datei erstellt, die die gelösten Terme enthält.
/// </summary>
    class ReadFile
    {

        public static string[] ReturnAsString (string loadingPath)
        {
            string path = "";
            path = @"C:\Users\lerichsen\Desktop\Aufgaben.txt";
            if (path == "")
            {
                path = Console.ReadLine();
            }

            string[] fileContent = { "" };
            if (System.IO.File.Exists(loadingPath))
            {
                fileContent = System.IO.File.ReadAllLines(loadingPath);
            }
            else
            {
                Console.WriteLine("Die Datei existiert nicht");
            }

            for (int i = 0; i < fileContent.Length; i++)
            {
                fileContent[i] = (fileContent[i] + " = " + Parser.Start(fileContent[i]) );
            }
            return fileContent;
        }

        public static void SaveInFile (string loadingPath, string savingPath)
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
            if (System.IO.File.Exists(loadingPath))
            {
                fileContent = System.IO.File.ReadAllLines(loadingPath);
            }
            else
            {
                Console.WriteLine("Die Datei existiert nicht");
            }

            string[] Answers = new string[fileContent.Length];

            for (int i = 0; i < fileContent.Length; i++)
            {
                Answers[i] = (fileContent[i] + " = " + Parser.Start(fileContent[i]));
            }

            System.IO.File.WriteAllLines(savingPath, Answers);
            Console.WriteLine("Die Datei wurde in " + savingPath + " gespeichert");
        }

    }
}
