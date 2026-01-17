using System.Runtime.CompilerServices;

public class Day9
{
    
    static List<(long,long)> GetInputFile()
    {
        string path = "Day9/input2.txt";
        string[] input = File.ReadAllLines(path);
        string[][] grid = new string[input.Length][];
        List<(long,long)> coordinates = new List<(long,long)>();
        
        for(int i = 0; i < input.Length; i++)
        {
           grid[i] = input[i].Split(',');
        }

        for(int y = 0; y < grid.Length; y++)
        {
            coordinates.Add((long.Parse(grid[y][0]), long.Parse(grid[y][1])));
        }

        return coordinates;
    }


    static long GetArea((long,long) coordinates1, (long,long) coordinates2)
    {
        //Remember First Number is column. Second Number is row
        //Get first set of coordiantes
        //Cycle through sets of coordinates and evaluate coordinates that have an x value >= to ours.
        //Find area using their x - our x to get width
        //Their y - our y will give us the height
        // -- remember here we have indexes here and we need to add 1 when doing our calculations for true numbers. Ex((7/1) to (11,7))
        //x - x would be 11 - 4 = 4. Looking at the example grid the width is really 5 between these becuase it includes the corners themselves.

        //for(int i = 0; i )

        //Area = l x w
        //Get Width
        //Get Length

        //x values: x - x + 1 should give us width
        long width = Math.Abs(coordinates2.Item1 - coordinates1.Item1);
        long length = Math.Abs(coordinates2.Item2 - coordinates1.Item2);
        width += 1;
        length += 1;


        return length * width;

    }
    public static void LargestRectangle()
    {
        //ideas
        //largest x axis and largest y axis possible?
        //First Number is column
        //Second Number is row
        // x check - grab a top left corner and search the max area we can create using length x width finding a bottom right corner. Do this for all remainging points.
        //then we need to do it backwards grabbing the bottom left corner and searching bottom to top for the farthest top right corner. 

        //Optimization
        //Treat each point as both top left and top right. Complete both checks for area.
        List<(long,long)> coordinates = GetInputFile();

        // foreach(var v in coordinates)
        // {
        //     Console.WriteLine(v);
        // }

        
        //these are coordinates, maybe we want to save it as a List containing tuples instead. Lets see what our functions might look like

        //for list of coordinates if xVal >= our xVal and y is > than our y(lower on the grid) - use TopLeftToBottomRight function
        //if x val is >= our x value and y is > than ours (its lower than using the top right to bottom left function.)

        //scratch the above we can check x values and y values either way and even if they are negative they should still give us accurate width or height I believe. So a simple conversion back to positive will work.

        //remember doesn't have to use this - just trying for now

        long currentLargestArea = 0;

        for(int i = 0; i < coordinates.Count; i++)
        {
            for(int y= i + 1; y < coordinates.Count; y++)
            {
                long area = GetArea(coordinates[i], coordinates[y]);
                //if area is larger than current largest the save it over current value
                if(area > currentLargestArea)
                {
                    currentLargestArea = area;
                    Console.WriteLine($"The Coordinates For the Final Pair Are: {coordinates[i]} and {coordinates[y]}");
                }
            }
        }

        Console.WriteLine(currentLargestArea);
    }
}