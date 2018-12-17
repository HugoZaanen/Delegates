using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21._6
{
    class Delegates
    {
        //delegate for a function that receveis an int and returns a bool
        public delegate bool NumberPredicate(int number);

        static void Main(string[] args)
        {
            int[] numbers = {1,2,3,4,5,6,7,8,9,10};

            //create an instance of the NumberPredicate delegate type
            NumberPredicate evenPredicate = IsEven;

            //Call IsEven eusing a delegate variable
            Console.WriteLine(
                $"Call IsEven using a delegate variable: {evenPredicate}");

            //filter the even numbers using method IsEven
            List<int> evenNumbers = FilterArray(numbers, evenPredicate);

            //display the result
            DisplayList("Use IsEven to filter even numbers: ", evenNumbers);

            //filter the odd numbers using method IsOdd
            List<int> oddNumbers = FilterArray(numbers, IsOdd);

            //display the result
            DisplayList("Use IsOdd to filter odd numbers: ", oddNumbers);

            //filter numbers greater than 5 using method IsOver5
            List<int> numbersOver5 = FilterArray(numbers, IsOver5);

            //display the result
            DisplayList("Use IsOver5 to filter numbers over 5: ", numbersOver5);
            Console.Read();
        }

        //select an array's elements that satisfy the predicate
        private static List<int> FilterArray(int[] intArray,
            NumberPredicate predicate)
        {
            //hold the selected elements
            var result = new List<int>();

            //iterate over each element in the array
            foreach(var item in intArray)
            {
                //if the element satisfies the predicate
                if(predicate(item))//invokes method referenced by predicate
                {
                    result.Add(item);//add the element to the result
                }
            }

            return result;
        }

        //determine wheter an int is even
        private static bool IsEven(int number) => number % 2 == 0;

        //determine wheter an int is odd
        private static bool IsOdd(int number) => number % 2 == 1;

        //determine wheter an int is greater than 5
        private static bool IsOver5(int number) => number > 5;

        //display the elements if a List
        private static void DisplayList(string description, List<int> list)
        {
            Console.Write(description);

            //iterate over each element in the List
            foreach(var item in list)
            {
                Console.Write($"{item} ");
            }

            Console.WriteLine();
        }
    }
}
