/* ---------------------------------------------------------------------------
    Student code: E4886
    Module code: P175B118
-----------------------------------------------------------------------------*/
using System;

namespace Question2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // delimiters 
            string d = " .,;?!:\t\n";

            // Given test line for editing operations
            string s = " A 00AAAAAAA00 ARa  A0   0000000000000000 ,,,,,,,,,,,,,,YRa   AAAAAAAAA...... BBBBBBBBB  ";

            Console.WriteLine("Original line is:\n" + s);
            int startInd = -1;
            string searchWord = "";
            s = EditLine(s, d, ref startInd, ref searchWord);
            Console.WriteLine("Edited line is:\n" + s);
            Console.WriteLine("Start index of word is {0}", startInd);
            
        }

        // TODO: implement method by given header
        // Moves the first word with most letters (analyze only Latin alphabet)
        // to the beginning of the line

        // Returns new edited line (after move procedure) via method name
        // s - original line of characters
        // d - set of delimiters
        // p - starting position (in original line) of found word 
        // W - found word itself
        static string EditLine(string s, string d, ref int p, ref string W)
        {
            string[] words = s.Split(d.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            int max = 0;
            int maxInd = -1;
            for (int i = 0; i < words.Length; i++)
            {
                int counter = 0;
                for (int j = 0; j < words[i].Length; j++)
                {
                    if (char.IsLetter(words[i][j]))
                    {
                        counter++;
                    }
                }
                if(counter > max)
                {
                    maxInd = i;
                    max = counter;
                }
                

            }
            W = words[maxInd];
            p = s.IndexOf(words[maxInd]);
            s = s.Remove(p, words[maxInd].Length);
            s = s.Insert(s.Length, words[maxInd]);
            return s;
        }

    }
}
