
class Day7
{
    private static char[][] GetInputfile()
    {
        string path = "Day7/input2.txt";
        string[] inputLines = File.ReadAllLines(path);
        char[][] grid = new char[inputLines.Length][];

        for(int i = 0; i < inputLines.Length; i++)
        {
            grid[i] = inputLines[i].ToCharArray();
        }

        return grid;
    }

    public static void FindTimesSplit()
    {
        char[][] grid = GetInputfile();


        //Console.WriteLine(grid[2][7]);

        //Beam starts at S
        var currentBeams = new HashSet<int>();
        int splitCount = 0;

        //currentBeams.Add(7);

        for(int i = 0; i < grid.Length; i++)
        {
            var newBeams = new HashSet<int>(currentBeams);
            

            for(int y = 0; y < grid[i].Length; y++)
            {
                
                //find where S is in the first row

                if(grid[i][y] == 'S')
                {
                    currentBeams.Add(y);
                }
                
                //if current beams contains the y index of a row that now has a '^' we need to split

                if(grid[i][y] == '^' && currentBeams.Contains(y))
                {
                    newBeams.Remove(y);
                    newBeams.Add(y + 1);
                    newBeams.Add(y - 1);
                    splitCount++;
                }

                //Console.Write($"{grid[i][y]} ");
            }

            if(newBeams.Count > 0)
            {
                currentBeams = newBeams;
            }
            
        }

        Console.WriteLine(splitCount);
    }
}