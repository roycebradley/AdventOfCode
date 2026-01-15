
class Day6
{
    private static string[][] GetInputFile()
    {
        string path = "Day6/input2.txt";
        string[] input = File.ReadAllLines(path);
        string[][] grid = new string[input.Length][];

        for(int i = 0; i < input.Length; i++)
        {
            grid[i] = input[i].Split(' ', StringSplitOptions.RemoveEmptyEntries);
        }
        
        return grid;
    }

    public static void CompleteMathHomeWorkPart1()
    {
        string[][] input = GetInputFile();
        string[] strings = new string[input.Length];
        int grandTotal = 0;
    
        
        // foreach(string s in input)
        // {
        //     strings = s.Split(' ');
        // }

        for(int i = 0; i < input.Length; i++)
        {   

            int count;
            
            if(input[input.Length - 1][i] == "*")
            {
                count = 1;
            }
            else
            {
                count = 0;
            }

            for(int y = 0; y < input[i].Length - 1; y++)
            {
                //Console.WriteLine(input[y][i]);

                if(input[input.Length - 1][i] == "*")
                {
                    count = count * int.Parse(input[y][i]);
                }
                else if(input[input.Length - 1][i] == "+")
                {
                    count += int.Parse(input[y][i]);
                }
                
            }

            //Console.WriteLine(count);
            grandTotal += count;
            
        }

        // Console.WriteLine(input[0][2]);
        // Console.WriteLine(input[input.Length - 1][1]);
        Console.WriteLine(grandTotal);

        


    }
}