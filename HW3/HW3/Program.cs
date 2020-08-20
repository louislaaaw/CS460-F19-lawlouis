using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HW3
{
    class Program
    {
        /** Print the command line usage for this program */
        private static void printUsage()
        {
            Console.WriteLine("Usage is:\n" +
            "\tHW3.exe C inputfile outputfile\n\n" +
            "Where:" +
            "  C is the column number to fit to\n" +
            "  inputfile is the input text file \n" +
            "  outputfile is the new output file base name containing the wrapped text.\n" +
            "e.g. HW3.exe 72 myfile.txt myfile_wrapped.txt");
        }

        /**
	    *  The main program. 
	    *
	    *@param  args  The command line arguments, see usage notes
	    */
        public static void Main(string[] args)
        {
            int C = 72;             // Column length to wrap to
            string inputFilename = "WarOfTheWorlds.txt";
            string outputFilename = "output.txt";
            StreamReader streamReader = new StreamReader(inputFilename);

            //Read the command line arguments ...
/*            if (args.Length != 3)
            {
                printUsage();
                Environment.Exit(exitCode: 1);
            }
            try
            {
                C = int.Parse(args[0]);
                inputFilename = args[1];
                outputFilename = args[2];
                streamReader = new StreamReader(inputFilename) ;
            }
            catch(FileNotFoundException e)
            { 
                Console.WriteLine("Could not find the input file.");
                Environment.Exit(exitCode: 1);
            }
            catch(Exception e)
            {
                Console.WriteLine("Something is wrong with the input.");
                printUsage();
                Environment.Exit(exitCode: 1);
            }*/

            // Read words and their lengths into these vectors
            QueueInterface<string> words = new LinkedQueue<string>();

            // Read input file, tokenize by whitespace

            string pattern = @"\b(\w+)\s+\b";
            Regex rgx = new Regex(pattern);
            string word = streamReader.ReadToEnd();
            MatchCollection matches = rgx.Matches(word);
            
            foreach(Match match in matches)
            {
                words.Push(match.Value);
            }
            
/*            string[] temp = word.Split(' ');
            for(int i = 0; i < temp.Length; i++)
            {
                words.Push(temp[i]);
            }*/
            
            streamReader.Close();

            int spacesRemaining = WrapSimply(words, C, outputFilename);
            Console.WriteLine("Total spaces remaining (Greedy): " + spacesRemaining);
            
        }

        private static int WrapSimply(QueueInterface<string> words, int columnLength, string outputFilename)
        {
            StreamWriter Out;
            try
            {
                Out = new StreamWriter(outputFilename);
            }
            catch(FileNotFoundException e)
            {
                Console.WriteLine("Cannot create or open " + outputFilename + "for writing. Using standard output instead.");
                Out = new StreamWriter(e.Message);
            }

            int col = 1;
            int spacesRemaining = 0;
            while (!words.IsEmpty())
            {
                string str = words.Peek();
                int len = str.Length;
                // See if we need to wrap to the next line
                if(col == 1)
                {
                    Out.Write(str);
                    col += len;
                    words.Pop();
                }
                else if( (col + len) >= columnLength)
                {
                    //go to the next line
                    Out.WriteLine();
                    spacesRemaining += (columnLength - col) + 1;
                    col = 1;
                }
                else
                {   //Typical case of printing the next word on the same line
                    Out.Write(" ");
                    Out.Write(str);
                    col += (len + 1);
                    words.Pop();
                } 
            }
            Out.WriteLine();
            Out.Flush();
            Out.Close();
            return spacesRemaining;
        } // end WrapSimply
    } // End class Main
}
