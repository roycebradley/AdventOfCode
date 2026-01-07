//Think of it as a grid: grid[row][col]
//(r-1, c-1)  (r-1, c)  (r-1, c+1)
//(r,   c-1)            (r,   c+1)
//(r+1, c-1)  (r+1, c)  (r+1, c+1)

using System.Globalization;
using System.Runtime.ConstrainedExecution;

class Day4
{
    public static void AccessibleRolls()
    {
        string path = "Day4/input4.txt";
        string[] inputLines = File.ReadAllLines(path);
        char[][] grid = new char[inputLines.Length][];

        for(int row = 0; row < inputLines.Length; row++)
        {
            grid[row] = inputLines[row].ToCharArray();
        }

        //Console.WriteLine(grid[0][5]);

        //for each '@' value we land on in our foreach loop
        //we need to check the 3x3 grid around it using nested
        //for loops.
        //Considerations: if the values all exist (ex. edges/corners)
        //if there are 4 or more '@' symbols around our symbol
        
        int finalCount = 0;

        for(int r = 0; r < grid.Length; r++)
        {
            for(int c = 0; c < grid[r].Length; c++)
            {
                //if value == @
                //nested loop that spans 3 x 3
                //if count is less than 4 than we add to total count

                if(grid[r][c] == '@')
                {

                    int count = 0;

                    for(int row = -1; row <= 1; row ++)
                    {
                        for(int col = -1;  col <= 1; col++)
                        {
                            if(r + row < 0 || c + col < 0 || r + row >= grid.Length || c + col >= grid[r].Length)
                            {
                              continue;  
                            } 
                            
                            if((grid[r + row][c + col] == '@') && !(row == 0 && col == 0))
                            {
                                count++;
                            }
                        }
                    }
                
                if(count < 4) finalCount++;
                }
            }
        }

        Console.WriteLine(finalCount);
    }


    public static List<(int,int)> ToRemove(char[][] grid)
    {
       //char[][] grid = Day4.GetInputFile();

        int finalCount = 0;
        List<(int, int)> rcToRemove = new List<(int, int)>();

        for(int r = 0; r < grid.Length; r++)
        {
            for(int c = 0; c < grid[r].Length; c++)
            {
                //if value == @
                //nested loop that spans 3 x 3
                //if count is less than 4 than we add to total count

                if(grid[r][c] == '@')
                {

                    int count = 0;

                    for(int row = -1; row <= 1; row ++)
                    {
                        for(int col = -1;  col <= 1; col++)
                        {
                            if(r + row < 0 || c + col < 0 || r + row >= grid.Length || c + col >= grid[r].Length)
                            {
                              continue;  
                            } 
                            
                            if((grid[r + row][c + col] == '@') && !(row == 0 && col == 0))
                            {
                                count++;
                    
                            }
                        }
                    }
                
                    if(count < 4)
                    {
                    
                    finalCount++;
                    //remove accessible roll 
                    rcToRemove.Add((r,c));
                    }
            
                }
            }
        }

       return rcToRemove;
    }


    private static char[][] RemoveRolls(List<(int, int)> coordinates, char[][] grid)
    {
        for(int i = 0; i < coordinates.Count; i++)
        {
            grid[coordinates[i].Item1][coordinates[i].Item2] = '.';
        }

        return grid;
    }

    private static char[][] GetInputFile()
    {
        string path = "Day4/input4.txt";
        string[] inputLines = File.ReadAllLines(path);
        char[][] grid = new char[inputLines.Length][];

        for(int row = 0; row < inputLines.Length; row++)
        {
            grid[row] = inputLines[row].ToCharArray();
        }

        return grid;
    }


    public static void AccessibleRollsPart2()
    {
        bool rollsRemoved = true;
        char[][] grid = GetInputFile();
        int finalCount = 0;
        
        while(rollsRemoved == true)
        {
            List<(int,int)> coordinates = ToRemove(grid);
            if(coordinates.Count == 0)
            {
                //Console.WriteLine(finalCount);
                rollsRemoved = false;
            }
            else
            {
                finalCount += coordinates.Count;
                RemoveRolls(coordinates, grid);
            }
        }
        Console.WriteLine(finalCount);
    }
}

// mark all acessible rolls as true using existing function. Return list of coordinates to remove - ToRemove()
//create a second function that removes these coordinates taking in the list - Remove()