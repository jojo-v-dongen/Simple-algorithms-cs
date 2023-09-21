using System;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata;

class Program
{
    static void Main()
    {

        // Create a random number generator
        Random rng = new Random();

        System.Console.WriteLine("How many items should the list contain? -->");
        var amount = int.Parse(Console.ReadLine());
        int[] array_of_numbers = new int[amount];       // Make an array to put `amount` elements in array
        for (int i = 0; i < amount; i++) {              
            array_of_numbers[i] = i + 1;      
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

    }

    static int[] InsertionSort(int[] shuffled_array)
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

}