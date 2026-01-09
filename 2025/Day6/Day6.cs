


using System.Drawing;
using System.Runtime.InteropServices.Marshalling;
using System.Text;

class Day6
{
    private static string[][] GetInputFile()
    {
        string path = "Day6/input1.txt";
        string[] input = File.ReadAllLines(path);
        string[][] grid = new string[input.Length][];

        for(int i = 0; i < input.Length; i++)
        {
            grid[i] = input[i].Split(' ', StringSplitOptions.RemoveEmptyEntries);
        }
        
        return grid;
    }

    private static char[][] GetInputFilePart2()
    {
        string path = "Day6/input2.txt";
        string[] input = File.ReadAllLines(path);
        char[][] grid = new char[input.Length][];

        for(int row = 0; row < input.Length; row++)
        {
            grid[row] = input[row].ToCharArray();
        }

        return grid;
    }

    public static void CompleteMathHomeWorkPart1()
    {
        string[][] input = GetInputFile();
        long grandTotal = 0;
    
        // Console.WriteLine(input[0][4]);
        // Console.WriteLine(input.Length);
        //Length of input is 5


        for(int i = 0; i < input[0].Length; i++)
        {   

            long count;
            
            if(input[input.Length - 1][i] == "*")
            {
                count = 1;
            }
            else
            {
                count = 0;
            }

        

            for(int y = 0; y < input.Length-1; y++)
            {
                //Console.WriteLine(input[y][i]);

                if(input[input.Length - 1][i] == "*")
                {
                    long number = long.Parse(input[y][i]);
                    count *= number;
                    Console.WriteLine(input[y][i]);
                }
                else if(input[input.Length - 1][i] == "+")
                {
                    count += int.Parse(input[y][i]);
                    Console.WriteLine(input[y][i]);
                }
                
            }

            //Console.WriteLine($"Equals: {count}");
            //Console.WriteLine(" ");
            grandTotal += count;
            
       }

        // Console.WriteLine(input[0][2]);
        // Console.WriteLine(input[input.Length - 1][1]);
        Console.WriteLine(grandTotal);
        
    }

    public static void CompleteMathHomeWorkPart2()
    {
        char[][] grid = GetInputFilePart2();

        //Console.WriteLine(grid[0][0])


        long grandTotal = 0;
        List<string> values = new List<string>();
        char opr = '?'
;
        for(int i = grid[0].Length-1 ; i >= 0; i--)
        {
            StringBuilder s = new StringBuilder();
            bool emptyColumn = true;

            for(int y = 0; y < grid.Length-1; y++)
            {
                //Console.WriteLine(grid[y][i]);
                if(grid[y][i] != ' ')
                {
                    emptyColumn = false;

                }
                s.Append(grid[y][i]);
            }

            string str = s.ToString().Trim();

            if(str != "")
            {
                values.Add(str);
            }
            
            char bottom = grid[grid.Length - 1][i];
            if(bottom == '*' || bottom == '+')
            {  
              opr = bottom;  
            }
        
            
            if(emptyColumn)
            {
                long count;

                if(opr == '*')
                {
                    count = 1;
                }
                else
                {
                    count = 0;
                }
                 
                foreach(string v in values)
                {
                    long number = long.Parse(v);
                    
                    if(opr == '*')
                    {
                        count *= number;
                    }
                    else
                    {
                        count += number;
                    }
                }

                //Console.WriteLine("Empty Column Here");
                grandTotal += count;
                values.Clear();
                opr = '?';
            }

        }
    // Handle any remaining numbers for the leftmost problem
    if(values.Count > 0)
    {
        long count = (opr == '*') ? 1 : 0;

        foreach(string v in values)
        {
            long number = long.Parse(v);
            if(opr == '*')
                count *= number;
            else
                count += number;
        }

        grandTotal += count;
        values.Clear();
        opr = '?';
    }
        
        Console.WriteLine(grandTotal);
    }
    
}