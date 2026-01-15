using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

class Day8
{

    static string[][] GetInputFile()
    {
        string path = "Day8/input2.txt";
        string[] inputLines = File.ReadAllLines(path);
        string[][] grid = new string[inputLines.Length][];

        for(int i = 0; i < inputLines.Length; i++)
        {
            //grid[i] = inputLines[i].Split(',');
            grid[i] = inputLines[i].Split(',').Select(s => s.Trim()).ToArray();
        }
        return grid;

    }

    static List<(int box1, int box2, long distanceVal)> GetJunctionBoxDistances()
    {
        string[][] grid = GetInputFile();
    
        var listOfDistances = new List<(int box1, int box2, long distanceVal)>();

        for(int i = 0; i < grid.Length; i++)
        {
            for(int y = i + 1; y < grid.Length; y++)
            {
                long xDiff = long.Parse(grid[y][0]) - long.Parse(grid[i][0]);
                long yDiff = long.Parse(grid[y][1]) - long.Parse(grid[i][1]);
                long zDiff = long.Parse(grid[y][2]) - long.Parse(grid[i][2]);

                long distance = (xDiff * xDiff) + (yDiff * yDiff) + (zDiff * zDiff);

                //Console.WriteLine($"Distance of Box {i + 1} and Box{y + 1} is {distance}");

                listOfDistances.Add((i,y,distance));
                
            }
        }

       listOfDistances.Sort((a,b) => a.distanceVal.CompareTo(b.distanceVal));
        
        return listOfDistances;
    }


    static int Find(int x, int[] rootArray)
    {
        
        // for(int i=0; i < rootArray.Length; i++)
        // {
        //     if(rootArray[i] == x)
        //     {
        //         return x;
        //     }

        //     x = rootArray[x];
        // }
        // return x;

        while(rootArray[x] != x)
        {
            x = rootArray[x];
        }
        return x;
    }

    static void Union(int box1, int box2, int[] rootArray)
    {
        
        int rootOfBox1 = Find(box1, rootArray);
        int rootOfBox2 = Find(box2, rootArray);

        if(rootOfBox1 != rootOfBox2)
        {
            rootArray[rootOfBox2] = rootOfBox1;
        }
    }

    public static void ClosestJunctionBoxes()
    {
        string[][] stringArray = GetInputFile();
        var listOfDistances = GetJunctionBoxDistances();
        int[] rootArray = new int[stringArray.Length];

        for(int i=0; i < rootArray.Length; i++)
        {
            rootArray[i] = i;
        }

        for(int y = 0; y < 1000; y++)
        {
            Union(listOfDistances[y].box1, listOfDistances[y].box2, rootArray);
        }

        // foreach(var v in listOfDistances)//rootArray)
        // {
        //     Console.WriteLine(v);
        // }

       // Console.Write(listOfDistances[0].box2);

    //    var circuitSizes = new Dictionary<int, int>();
    //     for (int i = 0; i < rootArray.Length; i++)
    //     {
    //         int root = Find(i, rootArray);
    //         if (!circuitSizes.ContainsKey(root))
    //             circuitSizes[root] = 0;
    //         circuitSizes[root]++;
    //     }

    //     // Multiply the three largest sizes
    //     var largestThree = circuitSizes.Values.OrderByDescending(x => x).Take(3).ToArray();
    //     long result = (long)largestThree[0] * largestThree[1] * largestThree[2];
    //     Console.WriteLine(result);
    // 
    
        var circuitSizes = new Dictionary<long, long>();

        for(int i = 0; i < rootArray.Length; i++)
        {
            int root = Find(i, rootArray);
            
            if(!circuitSizes.ContainsKey(root))
            {
                circuitSizes[root] = 0;
            }
            
            circuitSizes[root]++;
            
        }

        var finalThree = circuitSizes
        .OrderByDescending(kv => kv.Value)
        .Take(3);
        
        long finalVal = 1;

        foreach(var v in finalThree)
        {
            finalVal *= v.Value;
        }

        Console.WriteLine(finalVal);
    
    }
}