/*
Given an integer x, return true if x is a palindrome, and false otherwise.
    Do NOT convert to another data type, keep it as a number

Example 1:
    Input: x = 121
    Output: true

    Explanation: 121 reads as 121 from left to right and from right to left.

Example 2:
    Input: x = -121
    Output: false

    Explanation: From left to right, it reads -121. From right to left, it becomes 121-. Therefore it is not a palindrome.
*/

namespace Assignment_5._1._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int testNumber = 0;

            // Example 1; assignment example
            Console.WriteLine($"**Test {++testNumber}**");
            int x = 121;
            Console.WriteLine($"{x} is a palindrome: {IsPalindrome(x)}");
            Console.WriteLine($"Result using List: {IsPalindrome_ListSolution(x)}\n");

            // Example 2; assignment example
            Console.WriteLine($"**Test {++testNumber}**");
            x = -121;
            Console.WriteLine($"{x} is a palindrome: {IsPalindrome(x)}");
            Console.WriteLine($"Result using List: {IsPalindrome_ListSolution(x)}\n");

            // Example 3
            Console.WriteLine($"**Test {++testNumber}**");
            x = 45678;
            Console.WriteLine($"{x} is a palindrome: {IsPalindrome(x)}");
            Console.WriteLine($"Result using List: {IsPalindrome_ListSolution(x)}\n");

            // Example 4
            Console.WriteLine($"**Test {++testNumber}**");
            x = 11;
            Console.WriteLine($"{x} is a palindrome: {IsPalindrome(x)}");
            Console.WriteLine($"Result using List: {IsPalindrome_ListSolution(x)}\n");

            // Example 5
            Console.WriteLine($"**Test {++testNumber}**");
            x = 72618;
            Console.WriteLine($"{x} is a palindrome: {IsPalindrome(x)}");
            Console.WriteLine($"Result using List: {IsPalindrome_ListSolution(x)}\n");

            // Example 6
            Console.WriteLine($"**Test {++testNumber}**");
            x = 0;
            Console.WriteLine($"{x} is a palindrome: {IsPalindrome(x)}");
            Console.WriteLine($"Result using List: {IsPalindrome_ListSolution(x)}\n");

            // Example 7; test -0 to see what happens (I believe it'll just show as "0"?)
            Console.WriteLine($"**Test {++testNumber}**");
            x = -0;
            Console.WriteLine($"{x} is a palindrome: {IsPalindrome(x)}");
            Console.WriteLine($"Result using List: {IsPalindrome_ListSolution(x)}\n");
        }

        static bool IsPalindrome(int input)
        {
            // I had to look up how to mathematically find the first digit of a number (did not look up any code)
            // I'm sure there is a much better way to do this, because this is super messy
            
            // If input is negative, return false
            if (input < 0) return false;


            // If number >= 10, there are 2+ digits left; compare them
            while (input >= 10)
            {
                // Get the int of Log10 to get number of "zeroes" in the number (e.g., 123 = 100 = 2 "zeroes")
                int numDigits = Convert.ToInt32(Math.Floor(Math.Log10(input)));
                //Console.WriteLine("Num 0s: " + numDigits);

                // Get the first number
                int firstNum = Convert.ToInt32(Math.Floor(input / Math.Pow(10, numDigits)));
                //Console.WriteLine("1st #: " + firstNum);

                // Get the last number
                int lastNum = input % 10;
                //Console.WriteLine("Last#: " + lastNum);

                // If first and last numbers don't match, return false
                if (firstNum != lastNum) return false;

                // Remove first and last number
                // Remove first number
                input = input - Convert.ToInt32(Math.Floor(Math.Pow(10, numDigits) * firstNum));

                // Remove last number
                input /= 10;

                //Console.WriteLine("New #: " + input);
            }

            // If number < 10, there is only 1 digit left; return true
            return true;
        }

        static bool IsPalindrome_ListSolution(int input)
        {
            // If I couldn't convert the integer to a string, I would put each digit into a List and compare with two pointers
            // This is the only solution I could come up with without looking up the mathematical logic to find the first digit

            // If input is negative, return false
            if (input < 0) return false;

            // If input is a positive number, create a List to hold each digit
            List<int> numList = new();

            // If number > 0, insert each digit into List
            while (input > 0)
            {
                numList.Add(input % 10);
                input /= 10;
            }

            // Use two pointers in List to check for palindrome
            for (int i = 0; i < numList.Count/2; i++)
            {
                int lastNum = numList.Count - 1;
                
                // If numbers don't match, return false
                if (numList[i] != numList[lastNum - i])
                    return false;
            }

            return true;
        }
    }
}
