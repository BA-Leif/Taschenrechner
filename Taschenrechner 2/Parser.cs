using System;
using System.Collections.Generic;
using System.Text;

namespace Taschenrechner
{
    public class Parser
    {
        /// <summary>
        /// Die Funktion Start vom Parser organisiert die Abfolge der einzelnen Funktionen, die den Ausdruck interpretieren.
        /// Die Konsolen-Befehle diesen lediglich der nachvollziehbarkeit und sind optional.
        /// 
        /// Funktion FindBrackets
        ///     Hierbei wird zuerst nach dem Term in der innersten, linken Klammer gesucht und dierer isoliert.
        /// Funktion OrderOfoperations
        ///     Die Funktion sucht innerhalb des vorher isolierten Termes nach der Rechenoperation mit der höchsten Priorisierung.
        ///     Im Falle mehrere gleicher Operationen, wird diejenige bevorzugt, welche weiter links steht.
        ///     Dann wird der Term isoliert, welcher nur diese Operation und die angrenzenden Zahlen enthält.
        /// Funktion PrepareforCalculations
        ///     diese Funktion wandelt den isolierten Term, welcher nur noch eine Rechenoperation enthält in Zahlen um. 
        ///     Die Rechenoperation wird hierbei als eine Zahl codiert, damit die Information weitergegeben werden kann.
        ///     Diese Drei Werte werden dann in die Funktion Calculation.ChooseOperation weitergegeben.
        ///     
        /// Anschliessend wird die Schleife wiederholt, sofern sie nicht  mit einem Term gestartet ist, der nur eine Rechenoperation enthält.
        /// Dabei wird die Eingabe teilweise überschrieben, indem der im letzten Schritt berechnete Term "subInputWithoutBrackets"
        ///     durch das ermittelte Ergebnis "subInputAnswer" ersetzt wird
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>

        static Boolean Fehler = false;

        public static double Start (String input)
        {
            //Definieren der Variablen, welche die Zwischenterme speichern
            String subInput = "nichts";
            String subInputWithoutBrackets = "nichts";
            String subInputAnswer = "nichts";

            //Definieren einer Laufvariable, die die Durchläufe der while-Schleife zählt.
            int calculationSteps = 0;

            //Konvertieren der Eingabe zu kleinbuchstaben


            //Starten der do-whle Schleife, die ein letztes Mal durchläuft, wenn "input" nur noch eine Rechenpoeration enthält.
            do
            {
                calculationSteps++;
                //Ersetzen des zuvor berechneten Termes durch seinen Wert. Sollten dabei leere Klammern entstehen, werden diese entfernt.

                if (subInputWithoutBrackets == subInputAnswer)
                {
                    input = input.Replace("("+ subInputWithoutBrackets +")", subInputAnswer);
                }
                else
                {
                    input = input.Replace(subInputWithoutBrackets, subInputAnswer);
                    input = input.Replace("()", "");
                }

                //Console.WriteLine();
                //Console.WriteLine("Parsen Schritt " + calculationSteps.ToString());
               // Console.WriteLine("Input: " + input);
                //Die Funktion FindBrackets sucht den linkesten, innersten Term und schreibt diesen in die Variable "subinput".
                subInput = FindBrackets(input);               
               // Console.WriteLine("subInput evtl. in Klammern:              " + subInput);

                //Die Funktin OrderOfOperations, wählt ein Rechenzeichen mit der höchsten Priorität und isoliert dieses zusammen mit den beiden angrenzenden Zahlen.
                //  Dieser wird dann in die Variable subInputWithoutBrackets geschrieben
                subInputWithoutBrackets = OrderOfOperation(subInput);
                //Console.WriteLine("priorisierter Teil von subInput:     " + subInputWithoutBrackets);

                //Die Funktion PrepareForCalculation wandelt den kleinen Term in Zahlenwerte um, welche dann über eine Funktion Calculate.ChooseOperation ausgewertet werden.
                subInputAnswer = PrepareForCalculation(subInputWithoutBrackets);
                
                //Console.WriteLine("Ergebnis vom priorisierten Teil     " + subInputAnswer);
                //Console.WriteLine("Einsetzen von " + subInputAnswer + " anstatt von " + subInputWithoutBrackets + " in " + input);

    //Console.ReadLine();
            } 
                while (input != subInputWithoutBrackets || Fehler);
            //Initialisieren und übergeben der Ausgabeveriable 
            double output = 0;
            try
            {
                output = Double.Parse(subInputAnswer);
            }
            catch (Exception)
            {
                Console.WriteLine("_____________________Fehlerhafte Eingabe im Subterm " + subInput +". Versuche es erneut.");
            }
            if (Fehler)
            {
                Console.WriteLine("Es ist ein Fehler aufgetreten. Versuche es erneut.");
            }
            return output;
        }

        /// <summary>
        /// Die Funktion sucht innerhalb eines Strings nach Klammern und gibt einen Teil des Strings aus, der eine der innersten Klammern enthält.
        ///     Sollten keine Klammern enthlaten sein, wird die Übergabvariable unverändert ausgegeben.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        static string FindBrackets (string input)
        {
            //Definieren/ Initialisieren Variablen
            string subInput;
            int firstRightBracket = -1;
            int lastLeftBracket = 0;

            lastLeftBracket = input.LastIndexOf("(");
            //firstRightBracket = input.IndexOf(")");
            //Suchen nach der auf die letzte Linksklammer folgende Rechtsklammer
            for (int i = lastLeftBracket+1; i < input.Length; i++)
            {
                if (input[i] == ')')
                {
                    firstRightBracket = i;
                    break;
                }
            }


            //Entscheidung, ob der Term unverändert oder der Klammerausschnitt weitergegeben wird
            if (firstRightBracket == -1)
                subInput = input;
            else
                //subInput = input.Substring(lastLeftBracket, (firstRightBracket + 1) - lastLeftBracket);
                subInput = input[lastLeftBracket..(firstRightBracket+1)];
            return subInput;
        }

        /// <summary>
        /// Die Funktion sucht nach dem Operator mit der höchsten Priorität. und gibt den kleinensten ihn enthaltenden Term aus.
        /// 
        ///
        /// </summary>
        /// <param name="sub"></param>
        /// <returns></returns>
        static string OrderOfOperation (String sub)
        {
            //Sofern die Übergabevariable in Klammern eingefasst war, werden diese hier entfernt
            if (sub.Contains(')'))
            {
                //sub = sub.Substring((0 + 1), (sub.Length - 1) - 1);
                sub = sub[1..(sub.Length - 1)];
            }

            // Definition eines Tupel, welche die möglichen Rechenzeichen in ihrer Priorität enthält
            char[] operationHierarchy = { '!', '%', '^', 'v', '/', '*', '+', '-' };
            string output = "0";
            //operationPosition, speichert die Position des Priorisirten Rechenzeichens
            int operationPosition = 0;
            //operationIndex speichert die Art der Rechenoperation
            int operationIndex = 99;

            //"Scannen" des Termes "sub" von links nach rechts. Hierbei werden die Rechenoperationen, welche eine hohe Priorität haben zuerst gesucht.
            //      Wurde eine Operation gefunden, so wird die Suche sofort beendet und die Variablen operationPosition und operationIndex beschrieben.
            for (int n = 0; n < operationHierarchy.Length; n++)
            {
                for (int i = (0); i <= (sub.Length - 1); i++)
                {
                    if (sub[i] == operationHierarchy[n] && i != 0)
                    {
                        operationPosition = i;
                        //if (sub[i] == operationHierarchy[n])
                        {
                            operationIndex = n;
                            break;
                        }                     
                    }
                }
                if (operationPosition != 0)
                    break;
            }
    //Console.WriteLine("--Parsen(OoO)    priorisierter Rechenoperator an Stelle " + (operationPosition+1));


            //Ermitteln der Zahl, links vom Rechenoperator. Hierbei werden die Zeichen vor diesem überprüft und eine Zahl eingetragen, 
            //      wenn der Anfang des Termes erreicht oder ein Rechenzeichen gefuden wurde.
            string XString = "";
            //Überprüfen, ob ein Rechenoperator enthalten ist. Wenn nicht, so wird die Übergabevariable ungeändert weitergegeben 
            if (operationPosition != 0)
            {
                for (int i = (operationPosition - 1); i >= 0; i--)
                {
                    //Zeichen ist am Anfang oder werder Ziffer noch Dezimalpunkt
                    if ((!(Char.IsNumber(sub[i]) || sub[i] == ',') || i == 0))
                    {
                        //Suche bis zum Anfang gelaufen
                        if (i == 0)
                        {
                            XString = sub[(i)..(operationPosition)];
                            break;
                        }
                        //Suche hat ein Rechenzeichen gefunden, vor dessen selbst auch ein Rechenzeichen ist
                        //      also ist das gefundene Zeichen ein Vorzeichen und kein Rechenzeichen
                        else if (!Char.IsNumber(sub[i - 1]))
                        {
                            XString = sub[(i)..(operationPosition)];
                            break;
                        }
                        //Suche hat ein Rechenzeichen gefunden
                        else
                        {
                            XString = sub[(i+1)..(operationPosition)];
                            break;
                        }

                    }
                }
    //Console.WriteLine("X= " + XString);


                //Ermitteln der Zahl rechts vom Rechenzeichen. Hierbei wird überprüft, wann ein Zeichen keine Ziffer mehr ist oder die Suche am End des Termes angelangt ist.
                string YString = "";
                //Ausnahme für Fakultät, da diese rechts keine Zahl besitzt
                if (operationIndex != 0)
                {
                    
                    for (int i = (operationPosition + 1) ; i <= sub.Length -1; i++)
                    {
                        //den ersten Schtirr der for-Schleife überspringen, wenn das Zeichen direkt hinter dem Rechenoperator ein Vorzeichen ist
                         if (!(i == (operationPosition + 1) && !(Char.IsNumber(sub[i]))))
                        {
                            //betrachtetes Zeichen ist weder eine Ziffer oder ein Dezimalpunkt  oder    Suche ist am ende angelangt
                            if (!(Char.IsNumber(sub[i]) || sub[i] == ',') || i == (sub.Length - 1))
                            {
                                //Suche ist am ende angelangt
                                if (i == (sub.Length - 1))
                                {
                                    YString = sub[(operationPosition + 1)..(sub.Length)];
                                    break;
                                }
                                //Suche ist auf eine Rechenoperation gestoßen (kann kein Vorzeichen sein)
                                else
                                {
                                    YString = sub[(operationPosition + 1)..i];
                                    break;
                                }

                            }
                        }
                    }
                }
    //Console.WriteLine("Y= " + YString);
                //Schreiben des untersuchten Termes in die Variable output
                output = XString + sub[operationPosition] + YString;
            }
            //Schreiben der Ausgabe variable mit der Übergabevariable
            else
            {
                output = sub;
            }
            return output;
        }

        /// <summary>
        /// Die Funktion wandelt einen Term, der nur eine Rechenoperation besitzt in Werte um, die dann an die Funktion Calculation.ChooseOperation weitergegeben werden. 
        ///         Diese kann damit dann den Wert des Termes bestimmen.
        ///         
        /// </summary>
        /// <param name="sub"></param>
        /// <returns></returns>
        static string PrepareForCalculation (string sub)
        {
            //Definition und Initialisierung von Variablen.
            string output;
            int operationPosition = 0;
            char[] operationHierarchy = { '!', '%', '^', 'v', '*', '/', '+', '-' };

            double X = 0;
            double Y = 0;
            double operationIndex = 99;

            //Bestimmen der Position und der Art der Rechenoperation
            for (int n = 0; n < operationHierarchy.Length; n++)
            {
                for (int i = (0); i <= (sub.Length - 1); i++)
                {
                    if (sub[i] == operationHierarchy[n] && i != 0)
                    {
                        operationPosition = i;
                        if (sub[i] == operationHierarchy[n])
                        {
                            operationIndex = n;
                            break;
                        }
                    }
                }
                if (operationPosition != 0)
                    break;
            }

            //Umwandeln der Zahlen und Variablen der Art Double und weitergeben der Werte an die Funktion.Calculation.ChooseOperation, sofern eine Rechenoperation enthalten ist
            if (operationPosition != 0)
            {
                try
                {
                    //X = Double.Parse(sub.Substring(0, operationPosition));
                    X = Double.Parse(sub[0..(operationPosition)]);

                    if (sub[operationPosition] != '!')
                    {
                        //Y = Double.Parse(sub.Substring(operationPosition + 1, (sub.Length - (operationPosition + 1))));
                        Y = Double.Parse(sub[(operationPosition + 1)..sub.Length]);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("_____________________Ungültige Eingabe im Subterm " + sub + "." );
                    Fehler = true;
                }               
                output = Calculation.ChooseOperation(X, Y, operationIndex).ToString();
            }
            //Weitergeben der Übergabevariable, wenn kein Rechenzeichen enthalten ist
            else
            {
                output = sub;
            }
            
            return output;
        }
    }
}
