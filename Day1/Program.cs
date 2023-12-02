var lines = File.ReadAllLines("input.txt");
int result = 0;

string[] numbers = { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

foreach (string currentLine in lines)
{
    int first = -1, second = -1;
    
    for (int j = 0; j < currentLine.Length; j++)
    {
        char currentChar = currentLine[j];
        if (char.IsAsciiDigit(currentChar))
        {
            if (first < 0)
            {
                first = int.Parse($"{currentChar}");
                second = int.Parse($"{currentChar}");
            }
            else
            {
                second = int.Parse($"{currentChar}");
            }
            
            continue;
        }

        int maxLenght = currentLine.Length - j;
        int length = maxLenght < 5 ? maxLenght : 5;
        string part = currentLine[j .. (j + length)];

        for (int k = 1; k < numbers.Length + 1; k++)
        {
            string currentNumber = numbers[k - 1];
            bool valid = true;
            
            if (part.Length < currentNumber.Length)
            {
                continue;
            }

            for (int i = 0; i < 5 - currentNumber.Length; i++)
            {
                if (char.IsNumber(part[i]))
                {
                    valid = false;
                    break;
                }
            }
            
            if (!valid)
            {
                continue;
            }
            
            if (part.Contains(currentNumber))
            {
                if (first < 0)
                {
                    first = k;
                    second = k;
                }
                else
                {
                    second = k;
                }
                
                break;
            }
        }
    }
    
    int number = int.Parse($"{first}{second}");
    result += number;
    Console.WriteLine($"First number: {first}, Second number: {second}, Number: {number}, Current state: {result}, Line: {currentLine}");
}

Console.WriteLine(result);