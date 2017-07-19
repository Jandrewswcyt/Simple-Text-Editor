using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTextEditor
{
    class Program
    {
        static Stack<string> prevString; 

        static void Main(string[] args)
        {

            int numOfActions = 0;
            string s = ""; 
            prevString = new Stack<string>(); 

            numOfActions = Int32.Parse(Console.ReadLine()); 
            for(int i = 0; i < numOfActions; ++i)
            {
                string[] actionString = Console.ReadLine().Split(' '); 
                int action = Int32.Parse(actionString[0]); 
                if(action == 1 ) // Append 
                {
                    s = AppendToString(s, ref actionString[1]); 
                }
                else if(action == 2) // delete
                {
                    int numToDelete = Int32.Parse(actionString[1]);
                    s = DeleteNumCharacters(s, numToDelete); 
                }
                else if (action == 3) //Print
                {
                    int characterToPrint = Int32.Parse(actionString[1]);
                    PrintKCharacters(s, characterToPrint);
                }
                else //Undo
                {
                    if(prevString.Count > 0)
                    {
                        s = prevString.Pop(); 
                    }
                }
            }

            Console.ReadLine(); 

        }

        static string AppendToString(string baseString, ref string stringToAppened)
        {
            prevString.Push(baseString);
            baseString += stringToAppened;
            return baseString; 
        }

        static string DeleteNumCharacters(string baseString, int numToDelete)
        {
            prevString.Push(baseString); 

            if(baseString.Length > numToDelete)
            {
                string temp = baseString.Remove(baseString.Length - numToDelete);
                return temp; 
            }
            else
            {
                return ""; 
            }

        }

        static void PrintKCharacters(string baseString, int charToPrint)
        {
            if(charToPrint <= baseString.Length)
                Console.WriteLine(baseString[charToPrint - 1]); 
        }
    }
}
