using System;
using System.Runtime;

class SearchingAlgorithms
{
    public static void NotMain()
    {
      System.Console.WriteLine("How many items should the list contain? -->");
      var amount = int.Parse(Console.ReadLine());
      Random rng = new Random();

      int[] array_of_numbers = new int[amount];       // Make an array to put `amount` elements in array
      for (int i = 0; i < amount; i++)
      {
          array_of_numbers[i] = rng.Next(1, 10001); // Generates a random number between 1 and 10000
      }
      array_of_numbers = SortingAlgorithms.InsertionSort(array_of_numbers);
      Console.WriteLine(string.Join(", ", array_of_numbers));
      System.Console.WriteLine("Choose which element (number) you would like to find:");
      int target = int.Parse(Console.ReadLine());



      int position = BinarySearch(array_of_numbers, target);
      System.Console.WriteLine("\n\nBINARY SEARCH");
      if(position == -1){ System.Console.WriteLine($"{target} is not an element in the list."); }
      else{ System.Console.WriteLine($"{target} is in position {position} of the list."); }
      System.Console.WriteLine("\nLINEAR SEARCH");
      position = LinearSearch(array_of_numbers, target);
      if(position == -1){ System.Console.WriteLine($"{target} is not an element in the list."); }
      else{ System.Console.WriteLine($"{target} is in position {position} of the list."); }
    }

    static int BinarySearch(int[] nums, int target){
      int low = 0;
      int high = nums.Length - 1;
      int mid;

      while(low<=high){
        mid = (low+high) / 2;

        if(nums[mid] == target){
          return mid;
        }
        else if(nums[mid] < target){ low = mid + 1; }
        else{high = mid - 1;}

      }
      return -1;
    }
    static int LinearSearch(int[] nums, int target){

      for(int i = 0; i<nums.Length; i++){
        if(nums[i] == target){
          return i;
        }
      }
      return -1;


    }








}
