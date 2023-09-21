using System;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;

class SortingAlgorithms
{
    public static void AlsonotMain()
    {

        // Create a random number generator
        Random rng = new Random();

        System.Console.WriteLine("How many items should the list contain? -->");
        var amount = int.Parse(Console.ReadLine());
        System.Console.WriteLine("If you want each item to be randomly generated between 1-100, enter '1'.");
        int randomornot = int.Parse(Console.ReadLine());
        int[] array_of_numbers = new int[amount];

        if(randomornot == 1){
            for (int i = 0; i < amount; i++) {              
                array_of_numbers[i] = rng.Next(1, 101);   
            }
        }

        else{
            for (int i = 0; i < amount; i++) {              
                array_of_numbers[i] = i + 1;      
            }
        }

        // Shuffle the array using OrderBy
        var original_shuffled_array_of_numbers = array_of_numbers.OrderBy(x => rng.Next()).ToArray();
        int[] sorted_array_of_numbers;
        /// Print the shuffled array
        Console.WriteLine(string.Join(", ", original_shuffled_array_of_numbers));


        // Call the methods and print sorted list as proof

        System.Console.WriteLine("Sorting Now: Insertion Sort");
        sorted_array_of_numbers = InsertionSort(original_shuffled_array_of_numbers);
        Console.WriteLine(string.Join(", ", sorted_array_of_numbers));

        System.Console.WriteLine("Sorting Now: Bubble Sort");
        sorted_array_of_numbers = BubbleSort(original_shuffled_array_of_numbers);
        Console.WriteLine(string.Join(", ", sorted_array_of_numbers));

        System.Console.WriteLine("Sorting Now: Selection Sort");
        sorted_array_of_numbers = SelectionSort(original_shuffled_array_of_numbers);
        Console.WriteLine(string.Join(", ", sorted_array_of_numbers));

        System.Console.WriteLine("Sorting Now: Pigeonhole Sort");
        sorted_array_of_numbers = PigeonholeSort(original_shuffled_array_of_numbers);
        Console.WriteLine(string.Join(", ", sorted_array_of_numbers));

    }

    public static int[] InsertionSort(int[] shuffled_array)
    {
        int item_to_insert;
        int j;
        for (int i = 0; i < shuffled_array.Length; i++){
            item_to_insert = shuffled_array[i];
            j = i-1;
            while (j>=0 && shuffled_array[j] > item_to_insert){
                shuffled_array[j+1] = shuffled_array[j];
                j -= 1;
            }
            shuffled_array[j+1] = item_to_insert;
        }
        return shuffled_array;
    }

    static int[] BubbleSort(int[] shuffled_array){
        bool swapped = true;
        while(swapped){
            swapped = false;
            for(int i = 0; i < shuffled_array.Length-1; i++){
                if(shuffled_array[i] > shuffled_array[i+1]){
                    int temp = shuffled_array[i];
                    shuffled_array[i] = shuffled_array[i + 1];
                    shuffled_array[i + 1] = temp;
                    swapped = true;
                }
            }
        }
        return shuffled_array;
    }

    static int[] SelectionSort(int[] shuffled_array){
        for(int i = 0; i < shuffled_array.Length; i++){
            int lowest_value_index = i;
            for(int j =i+1; j < shuffled_array.Length; j++){
                if(shuffled_array[j] < shuffled_array[lowest_value_index]){
                    lowest_value_index = j;
                }
            }

            int temp = shuffled_array[i];
            shuffled_array[i] = shuffled_array[lowest_value_index];
            shuffled_array[lowest_value_index] = temp;     


        }
        return shuffled_array;
    }
    static bool IsSorted(int[] array)
    {
        for (int i = 1; i < array.Length; i++)
        {
            if (array[i] < array[i - 1])
            {
                return false;
            }
        }
        return true;
    }
    static int[] BogoSort(int[] array)   //Incredibly efficient, I know.
    {
        Random rng = new Random();
        while (!IsSorted(array))
        {
            array = array.OrderBy(x => rng.Next()).ToArray();
        }
        return array;
    }

    static int[] PigeonholeSort(int[] array){
        int high = array.Max();
        int low = array.Min();
        int[] pigeonholes = new int[high - low + 1];

        foreach (int num in array)
        {
            pigeonholes[num - low]++;
        }

        int index = 0;
        for (int i = 0; i < pigeonholes.Length; i++)
        {
            while (pigeonholes[i] > 0)
            {
                array[index] = i + low;
                pigeonholes[i]--;
                index++;
            }
        }
        return array;
    }


}