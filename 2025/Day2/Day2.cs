


public class Day2
{
        long AddUpInvalidIdsPart1()
        {

        string input = string.Join("", File.ReadAllLines("./Day2/input.txt"));
        //create an array split by commas
        //split each element again by the '-'
        string[] rangesArray = input.Split(",");

        

        //add up all invalid Ids
        long count = 0;
    
        for(int i = 0; i < rangesArray.Length; i++)
        {
            //Split the values into any array of strings using .Split(",");
            //Create a new array of tuples by splitting the strings again at the '-'
            //ranges[i] = (parts[0], parts[1]);
            //Console.WriteLine($"First Number: {ranges[i].start} and the Second Number: {ranges[i].end}");

            //find the length of the number while its in string form
            //if it has an even amount of digits we need to compare first half to second half
            //Gather the first half digits - I believe we can just compare the strings
            //Gather the second half digits
            //if they are identical, they are considered an invalid ID and should be added to the count.

            var parts = rangesArray[i].Split("-");
            long start = long.Parse(parts[0]);
            long end = long.Parse(parts[1]);

            for(long y = start; y < end; y++ )
            {
                

                string stringNum = y.ToString();
                
                if(stringNum.Length % 2 == 0)
                {
                    //Console.WriteLine($"StringNum Lenth: {stringNum.Length} and StringNum value: {stringNum}");
                    string sub1 = stringNum.Substring(0, stringNum.Length/2);
                    string sub2 = stringNum.Substring(stringNum.Length/2);
                    //Console.WriteLine($"StrinNum Value: {stringNum} Substring 1: {sub1} and Substring 2: {sub2}");
                    if(sub1 == sub2) count += y;
                }
            
            }
        }
        Console.WriteLine(count);
        return count;

        }


    long AddUpInvalidIdsPart2()
    {
        string input = string.Join("", File.ReadAllLines("./Day2/input.txt"));
        string[] rangesArray = input.Split(",");

        long count = 0;

        foreach (var r in rangesArray)
        {
            var parts = r.Split("-");
            long start = long.Parse(parts[0]);
            long end = long.Parse(parts[1]);

            for (long y = start; y <= end; y++) // include 'end'
            {
                string str = y.ToString();
                int len = str.Length;
                bool invalid = false;

                // try all possible sequence lengths
                for (int seqLen = 1; seqLen <= len / 2; seqLen++)
                {
                    if (len % seqLen != 0) continue; // must divide evenly

                    string seq = str.Substring(0, seqLen);
                    int repeats = len / seqLen;

                    string candidate = string.Concat(Enumerable.Repeat(seq, repeats));

                    if (candidate == str)
                    {
                        invalid = true;
                        break; // found repeated sequence, no need to check longer ones
                    }
                }

                if (invalid)
                    count += y;
            }
        }

        Console.WriteLine(count);
        return count;
    }

    
}
