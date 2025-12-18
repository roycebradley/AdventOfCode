
using System.Text.RegularExpressions;

class Day1
{


    public static int TimesPassed100(int dialPosition, int turnDial, char direction)
    {
        

    int pos = dialPosition;
    int count = 0;

    for (int i = 0; i < turnDial; i++)
    {
        if (direction == 'L')
        {
            pos = (pos - 1 + 100) % 100;
        }
        else // 'R'
        {
            pos = (pos + 1) % 100;
        }

        if (pos == 0) count++;
    }

    return count;
    }
    
    public static int MoveDialWithRollOver(int dialPosition, int turnDial, char direction)
    {

        if(direction == 'L')
        { 
            return (dialPosition - turnDial + 100) % 100;
            
        }
        else { 

            //add to count if number passes 100

            return (dialPosition + turnDial) % 100;
        }
    }

    public static int GetDoorCodePart1()
    {
        int dialPos = 50;
        int count = 0;
        int timesToTurnDial;

        //Read in input and convert to a string array with no control characters
        string path = "./Day1/input.txt"; 
        string[] inputArray = File.ReadAllLines(path);
        
        for(int i = 0; i < inputArray.Length; i++)
        {
            string num = $"{inputArray[i].Substring(1)}";
            int.TryParse(num, out timesToTurnDial);
            
            dialPos = MoveDialWithRollOver(dialPos, timesToTurnDial, inputArray[i][0]);

            if(dialPos == 0)count++;        
          
        }     
        Console.WriteLine($"Answer to Part 1: {count}");
        return count;
    }

    public static int GetDoorCodePart2()
    {
        int dialPos = 50;
        int count = 0;
        int timesToTurnDial;

        //Read in input and convert to a string array with no control characters
        string path = "./Day1/input.txt"; 
        string[] inputArray = File.ReadAllLines(path);
        
        for(int i = 0; i < inputArray.Length; i++)
        {
            string num = $"{inputArray[i].Substring(1)}";
            int.TryParse(num, out timesToTurnDial);
            
            count += TimesPassed100(dialPos, timesToTurnDial, inputArray[i][0]);
            dialPos = MoveDialWithRollOver(dialPos, timesToTurnDial, inputArray[i][0]);

            //if(dialPos == 0)count++;        
          
        }     
        Console.WriteLine($"Answer to Part 2: {count}");
        return count;
    }


    static void Run(string[] args)
    {
        
        GetDoorCodePart1();
        GetDoorCodePart2();
  
    }
    
}
