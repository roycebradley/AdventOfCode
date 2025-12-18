using System.Dynamic;
using System.Runtime.InteropServices.Marshalling;

class Day3
{
    public static int TotalJoltagePart1()
    {
        string path = "./Day3/input.txt";
        string[] input = File.ReadAllLines(path);
        int count = 0;


        foreach(string s in input)
        {   

            char maxI = '0';
            char maxY = '0';

            for(int i = 0; i < s.Length; i++)
            {
                if(s[i] > maxI && i + 1 != s.Length)
                {
                    maxI = s[i];
                    maxY = '0';
                    for(int y = i + 1; y < s.Length; y++)
                    {
                    
                        if(s[y] > maxY)
                        {
                            maxY = s[y];
                        }
                    }
                }
            }

            string numValue = $"{maxI}{maxY}";
            Console.WriteLine(numValue);
            count += int.Parse(numValue);
        }
        Console.WriteLine(count);
        return 0;
    }

    public static long TotalJoltagePart2()
    {

        string path = "./Day3/input.txt";
        string[] input = File.ReadAllLines(path);
        long count = 0;

        foreach(string s in input)
        {
            var stack = new Stack<char>();
            int canRemove = s.Length - 12;

            foreach(char c in s)
            {
                while(stack.Count > 0 && canRemove > 0 && stack.Peek() < c)
                {
                    stack.Pop();
                    canRemove--;
                }
                stack.Push(c);
            }

            while(canRemove > 0)
            {
                stack.Pop();
                canRemove--;
            }

            char[] joltArr = stack.Reverse().ToArray();
            string joltString = new string(joltArr);
            Console.WriteLine(joltString);
            count += long.Parse(joltString);
            Console.WriteLine(count);
        }
        
        return 0;
    }

    // static void Run()
    // {
    //     TotalJoltagePart1();
    // }
}
