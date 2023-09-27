using System.Text.RegularExpressions;

namespace Acceleration_.NET_Tasks
{
    internal class Program
    {

        
        static void Main(string[] args)
        {
            //
        }

        //Below are implementations of first five problems
        //some problems have multiple solutions

        //**** TASK #1 ****
        static bool isPalindrome(string text)
        {
            int left = 0;
            int right = text.Length - 1;

            while (left < right)
            {
                if (!char.IsLetterOrDigit(text[left]))
                {
                    left++;
                    continue;
                }
                if (!char.IsLetterOrDigit(text[right]))
                {
                    right--;
                    continue;
                }
                if (text[left] != text[right])
                {
                    return false;
                }
                right--;
                left++;
            }

            return true;
        }

        //**** TASK #2 ****
        static int MinSplit(int amount)
        {
            int minCount = 0;

            //we have 1,5,10,20 and 50 coins
            int[] coins = { 50, 20, 10, 5, 1 };

            //We should return max amount with min caunt of coins

            //1st way to implement the function
            for (int i = 0; i < coins.Length; i++)
            {
                while(amount >= coins[i])
                {
                    amount -= coins[i];
                    minCount++;
                }
            }


            //2nd way
            /*
            while (amount != 0)
            {
                if (amount - 50 >= 0)
                {
                    amount -= 50;
                    minCount++;
                    continue;
                }
                if (amount - 20 >= 0)
                {
                    amount -= 20;
                    minCount++;
                    continue;
                }
                if (amount - 10 >= 0)
                {
                    amount -= 10;
                    minCount++;
                    continue;
                }
                if (amount - 5 >= 0)
                {
                    amount -= 5;
                    minCount++;
                    continue;
                }
                if (amount - 1 >= 0)
                {
                    amount -= 1;
                    minCount++;
                    continue;
                }
            }
            */


            return minCount;
        }

        //**** TASK #3 ****
        static int NotContains(int[] array)
        {
            int minNotContained = 1; //by default
            if (array == null) { return minNotContained; } //since min value missing should be 1

            //now we need to create some storage to save positive integers
            HashSet<int> posInts = new HashSet<int>();
            for (int i = 0; i < array.Length; i++)
            {
                if(array[i] > 0)
                    posInts.Add(array[i]);
            }

            //now we need to find which min value is missing
            while(posInts.Contains(minNotContained))
            {
                minNotContained++;
            }
            return minNotContained;
        }

        //**** TASK #4 ****
        static bool IsProperly(string sequence)
        {
            //to solve this problem, we can use stack 
            Stack<Char> seq = new Stack<char>();

            for (int i = 0; i < sequence.Length; i++)
            {
                if (sequence[i] == '(')
                {
                    seq.Push('(');
                }
                if (sequence[i] == ')')
                {
                    if (seq.Count == 0) return false; //automatically it is unmatched case
                    seq.Pop();
                }
            }

            //NOTE***: In case if we have empty string, this code will assume true for a return val
            if (seq.Count == 0)
            {
                return true;
            }

            return false;
        }

        //**** TASK #5 ****

        //***NOTE***: there are 3 different approaches of how
        //            to solve this problem, the best one is uncommented

        /* 
         //WAY #1
         //basically it is Fibonacci sequence problem
        //time complexity is O(2^n) (since we have 2 recursive calls, so there is branching)
        //space compexity is O(n) (stack space is used)
        //overall, pretty inefficient, but easy solution

        static int CountVariants(int stairCount)
        {
            if (stairCount <= 1) return 1;
            return CountVariants(stairCount - 1) + CountVariants(stairCount - 2);
        } 
        */


        /*
         //WAY #2
        //time complexity is O(a*stairCount/2) => O(n)
        //space compexity is O(1)
        //overall, this method is more efficient than previous one

        static int CountVariants(int stairCount)
        {
            //MATHEMATICAL EXPLANATION
            // we have n number of stairs: 1 1 1 1 1 1 1 1 1...  ...(n-times)
            // if we have zero 2 stairs => 1 way
            // if we have one 2 stairs => n - 1 possible ways
            // if we have two 2 stairs => (n - 2)!/(2! * (n - 2 - 2)!) ways
            // if we have three 2 stairs => (n - 3)!/(3! * (n - 3 - 3)!) ways
            //...
            //...
            //if we have k 2 stairs => (n - k)!/(k! * (n - 2*k)!) ways


            //if n is zero or one, I consider, we have 1 case

            //I use [n/2] since maximum number of the 2-staired steps could be half of the stairs
            //ex.: 5 => (2,2,1) max 2; 9 => (2,2,2,2,1) max 4;
            //if n is even stairCount = SUM(i = 0 to i = [n/2])[(n - i)!/(i! * (n - 2*i)!)] = SUM(i = 0 to i = [n/2])[C(n-i, i)]
            //NOTE***: [n/2] is whole part of the quotient (ex.: [5/2] = 2)

            if (stairCount <= 1) return 1;
            int possComb = 0;

            for (int i = 0; i <= (int)stairCount/2; i++)
            {
                possComb += factorial(stairCount - i) / (factorial(stairCount - 2 * i) * factorial(i));
            }

            return possComb;

        } 

        static int factorial(int a)
        {
            int fact = 1;
            for (int i = 1; i <= a; i++)
            {
                fact *= i;
            }
            return fact;
        } 
        */



        // WAY #3
        // One more way could be directly using explicit Fibonacci formula
        // An = ( (1+sqrt(5))^n  -  (1-sqrt(5))^n ) / ( sqrt(5) * 2^n )
        // time compexity is O(1)
        // space complexity is O(1)
        // overall, this is the best option
        static int CountVariants(int stairCount)
        {
            // the only thing to consider here is that fibonacci series starts with f0 = 0, and procceeds f1 = f2 = 1...
            //in our case, we start at f1 = 1, f2 = 2...
            //so we should increase N by 1
            stairCount++;
            return (int)((Math.Pow(1 + Math.Sqrt(5), stairCount) - Math.Pow(1 - Math.Sqrt(5), stairCount)) / ((Math.Sqrt(5)) * Math.Pow(2, stairCount)));

        }

    }
}