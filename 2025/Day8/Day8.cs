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

    // long FunctionThatReturnsTopCountOfDictionary()
    // {
    //     int root = Find(i, rootArray);
            
    //         if(!circuitSizes.ContainsKey(root))
    //         {
    //             circuitSizes[root] = 0;
    //         }
            
    //         circuitSizes[root]++;

    //     return;
    // }


    public static void ClosestJunctionBoxes2()
    {
        string[][] stringArray = GetInputFile();
        var listOfDistances = GetJunctionBoxDistances();
        int[] rootArray = new int[stringArray.Length];

        for(int i=0; i < rootArray.Length; i++)
        {
            rootArray[i] = i;
        }

        //goal - create one big circuit with all boxes connected to the same root
        //multiply the x values of the last two boxes that create the circuit

        //go through the list of distances completly performing a union on anything that isn't already connected to the same root (union function may already check this)
        //need a way to check if the circuit contains all boxes so we can end early if possible - we can use the dictionary to check if the top count equals the number of boxes from our input file

        //------//

        //init Dictionary

        for(int i = 0; i < listOfDistances.Count; i++)
        {
            int box1 = listOfDistances[i].box1;
            int box2 = listOfDistances[i].box2;
            

            if(Find(box1, rootArray) != Find(box2, rootArray))
            {
                Union(box1, box2, rootArray);
                
                var circuitSizes = new Dictionary<int, int>();

                for(int y = 0; y < rootArray.Length; y++)
                {
                    int root = Find(y, rootArray);
            
                    if(!circuitSizes.ContainsKey(root))
                    {
                        circuitSizes[root] = 0;
                    }
            
                    circuitSizes[root]++;
                }
                
                int maxValueInDict = circuitSizes.Values.Max();

                if(maxValueInDict == stringArray.Length)
                {
                    var maxKey = circuitSizes.OrderByDescending(kv => kv.Value).Take(1);

                    foreach(var v in maxKey)
                    {
                        Console.WriteLine($"Max Key is {v.Key} and Value is {v.Value}");
                    }
                    Console.WriteLine("Everything is in 1 circuit!!!");
                    Console.WriteLine($"Length of rootArray: {rootArray.Length} - Top Circuit Length {maxValueInDict} ");
                    Console.WriteLine($"Final Union is: {box1} and {box2} ");
                    Console.WriteLine($"i index is currently: {i} which is {listOfDistances[i]}");
                    Console.WriteLine($"List of Distances Which Includes all Possible Connections Length {listOfDistances.Count}");
                    Console.WriteLine($"Box 692 is {stringArray[692][0]}");
                    Console.WriteLine($"Box 875 is {stringArray[875][0]}");
                    Console.WriteLine($"X value of box1 is: {stringArray[listOfDistances[i].box1][0]}");
                    Console.WriteLine($"X value of box2 is: {stringArray[listOfDistances[i].box2][0]}");
                    Console.WriteLine($"Multiplied Together the Answer is: {long.Parse(stringArray[listOfDistances[i].box1][0]) * long.Parse(stringArray[listOfDistances[i].box2][0])}");

                    // for(int y = 0; y < rootArray.Length; y++)
                    // {
                    //     Console.WriteLine($"Index: {y} Root is: {Find(y,rootArray)}");
                    // }

                    // for(int y = 0; y < listOfDistances.Count; y++)
                    // {
                    //     Console.WriteLine(listOfDistances[y]);
                    // }
                    // return;
                    
                }
            }
    
        }
    
    }
}