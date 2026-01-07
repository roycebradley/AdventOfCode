
class Day5
{
    private static string[] GetInputFile()
    {
        string path = "Day5/input.txt";
        string[] lines = File.ReadAllLines(path);
        // foreach(var l in lines)
        // {
        //     Console.WriteLine(l);
        // }
        return lines;
    }

    public static void FreshFoodsPart1()
    {
        string[] lines = GetInputFile();

        //break values up into two lists

        bool beforeSpace = true;
        var validIDs = new List<(long, long)>();
        var productIds = new List<long>();
        int finalCount = 0;

        for(int i = 0; i < lines.Length; i++)
        {
            if(string.IsNullOrWhiteSpace(lines[i]))
            {
                beforeSpace = false;
                continue;
            }

            if(!beforeSpace)
            {
                long num = long.Parse(lines[i]);
                productIds.Add(num);
            }
            else
            {
                var parts = lines[i].Split("-");
                long start = long.Parse(parts[0]);
                long end = long.Parse(parts[1]);
                validIDs.Add((start, end));
            }
        }

        //add ranges to a set

        //check if rest of values are in the set 

        foreach(var v in productIds)
        {
            for(int i = 0; i < validIDs.Count; i++)
                if(v >= validIDs[i].Item1 && v <= validIDs[i].Item2)
                {
                    finalCount++;
                    break;
                }
        }

        Console.WriteLine(finalCount);
    }


        public static void FreshFoodsPart2()
    {
        string[] lines = GetInputFile();
   
        var validIDs = new List<(long, long)>();
        long finalCount = 0;

        for(int i = 0; i < lines.Length; i++)
        {
            if(string.IsNullOrWhiteSpace(lines[i]))
            {
                break;
            }

            var parts = lines[i].Split("-");
                long start = long.Parse(parts[0]);
                long end = long.Parse(parts[1]);
                validIDs.Add((start, end));
        }

        validIDs.Sort();
        var nonOverlappingValidIDs = new List<(long, long)>();

        foreach(var range in validIDs)
        {
            if(nonOverlappingValidIDs.Count == 0)
            {
                nonOverlappingValidIDs.Add(range);
            }

            var last = nonOverlappingValidIDs[nonOverlappingValidIDs.Count - 1];

            if(range.Item1 <= last.Item2 + 1)
            {
                nonOverlappingValidIDs[nonOverlappingValidIDs.Count - 1] = (last.Item1, Math.Max(range.Item2, last.Item2));
            }
            else
            {
                nonOverlappingValidIDs.Add((range.Item1, range.Item2));
            }
        }

        foreach(var range in nonOverlappingValidIDs)
        {
            finalCount += range.Item2 - range.Item1 + 1;
        }

        Console.WriteLine(finalCount);
    
    }
}