using System;

class OptimalProgram
{
    static void Main()
    {
      System.Console.WriteLine("1) Sorting algorithms \n2) Searching algorithms");
      int response = int.Parse(Console.ReadLine());
      if(response == 1){SortingAlgorithms.AlsonotMain();}
      else if(response == 2){SearchingAlgorithms.NotMain();}
      else{System.Console.WriteLine("Please only respond with the number '1' or '2'.");}
    }
}
