using System;

namespace LargestSumKArray
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string input = @"4
4
-4 -2 1 -3
2
6
1 1 1 1 1 1
2
5
1 -2 -3 4 5
3
27
-1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -2 -2 -2 -1 -1 -1 -1 98 100 100 100 -22 -23 -24 -25 -26 -27
4";
            input = input.Replace("\r", "");
            Test[] tests = parseInput(input);

            foreach(Test t in tests)
            {
                int largest = t.findLargest();
                Console.WriteLine(largest);
            }
        }


        public static Test[] parseInput(string input)
        {
            string[] inputs = input.Split('\n');
            Test[] tests = null;
            Test test = null;
            int testPosition = 0;
            int position = 0;
            for(int i = 0; i < inputs.Length; i++)
            {
                if(position == 1) //Size of array
                {
                    int size = Int32.Parse(inputs[i]);
                    test = new Test(size);
                    position = 2;
                }
                else if (position == 2) //Array items
                {
                    string[] array = inputs[i].Split(' ');

                    for(int j = 0; j < array.Length; j++)
                    {
                        int number = Int32.Parse(array[j]);
                        test.array[j] = number;
                    }
                    position = 3;
                }
                else if (position == 3) //K subset
                {
                    int K = Int32.Parse(inputs[i]);
                    test.K = K;
                    position = 1;

                    tests[testPosition] = test;
                    testPosition++;
                }
                else if (i == 0) //Number of tests
                {
                    int num_of_tests = Int32.Parse(inputs[0]);
                    tests = new Test[num_of_tests];
                    position = 1;
                }
            }
            return tests;
        }
        
    }

    public class Test
    {
        public int K;
        public int[] array;

        public Test (int size)
        {
            array = new int[size];
        }

        public int findLargest()
        {
            int size = K;
            int largest = int.MinValue;
            while(array.Length >= size)
            {
                int sum = findLargestInSize(size);
                if(sum > largest)
                {
                    largest = sum;
                }
                size++;
            }
            return largest;
        }

        public int findLargestInSize(int size)
        {
            int largest = int.MinValue;

            for (int i = 0; i <= array.Length - size; i++)
            {
                int sum = 0;
                
                for (int j = i; j < i + size; j++)
                {
                    sum += array[j];
                }
                if ( sum > largest)
                {
                    largest = sum;
                }
            }

            return largest;
        }
    }
}
