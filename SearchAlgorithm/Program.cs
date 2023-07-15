using System;

namespace DataStructures_C
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int[] numbers_arr = { 10, 11, 13, 14, 16, 18, 20, 23, 24, 27, 30, 31, 32, 33, 35, 38 };
            int search_target = 18;
            int bottom = 0;
            int top = numbers_arr.Length - 1;
            int hops = 0;

            
            Console.WriteLine("Standard Interpolation Search:");
            Interpolation_Search(numbers_arr, search_target, bottom, top, ref hops);
            Console.WriteLine("");

            Console.WriteLine("Interpolation with Linear Search:");
            Interpolation_Linear_Search(numbers_arr, search_target, bottom, top, ref hops);
            Console.WriteLine("");

            Console.WriteLine("Interpolation with Binary Search:");
            Interpolation_Binary_Search(numbers_arr, search_target, bottom, top, ref hops);
            Console.WriteLine("");

            Console.WriteLine("Interpolation with Exponential Search:");
            Interpolation_Exponential_Search(numbers_arr, search_target, bottom, top, ref hops);
            Console.WriteLine("");
            Console.ReadKey();
        }
        /// <summary>
        /// Standard interpolation search
        /// </summary>
        /// <param name="numbers_arr"></param>
        /// <param name="search_target"></param>
        /// <param name="bottom"></param>
        /// <param name="top"></param>
        /// <param name="hops"> ref hops records the value hops each time the recursive method loads</param>
        public static void Interpolation_Search(int[] numbers_arr, int search_target, int bottom, int top, ref int hops)
        {
            //i = ((top - bottom) * ((k - Value_bottom) / (Value_top - Value_bottom) + bottom)

            //Values
            int val_bottom = numbers_arr[bottom];
            int val_top = numbers_arr[top];

            //Check if search has failed
            if (bottom > top || search_target > val_top)
            {
                Console.WriteLine("Search target not found! ");
                return;
            }



            //Run equation

            int predict = (((top - bottom) * (search_target - val_bottom)) / (val_top - val_bottom) + bottom);

            //Check next steps
            //If target found, search done
            if (numbers_arr[predict] == search_target)
            {
                hops++;
                Console.WriteLine("Search target found! Hops: " + hops);
            }
            else
            {

                hops++;
                if (numbers_arr[predict] > search_target)
                {
                    Interpolation_Search(numbers_arr, search_target, bottom, predict - 1, ref hops);

                }
                else
                {
                    Interpolation_Search(numbers_arr, search_target, predict + 1, top, ref hops);
                }
            }
        }
        public static void Interpolation_Linear_Search(int[] numbers_arr, int search_target, int bottom, int top, ref int hops)
        {
            //The beginning of this code is exactly the same as the Interpolation_Search Method

            //Values
            int val_bottom = numbers_arr[bottom];
            int val_top = numbers_arr[top];

            //Check if search has failed
            if (bottom > top || search_target > val_top)
            {
                Console.WriteLine("Search target not found! ");
                return;
            }



            //Run equation

            int predict = (((top - bottom) * (search_target - val_bottom)) / (val_top - val_bottom) + bottom);

            //If found, search done
            //Check next steps
            //If target found, search done
            if (numbers_arr[predict] == search_target)
            {
                hops++;
                Console.WriteLine("Search target found! Hops: " + hops);
            }
            else
            {

                hops++;
                if (numbers_arr[predict] > search_target)
                {
                    for (int i = bottom; i < numbers_arr[predict - 1]; i++)
                    {
                        hops++;
                        if (numbers_arr[i] == search_target)
                        {

                            return;
                        }
                    }
                    Console.WriteLine("Search target found! Hops: " + hops);

                }
                else
                {
                    for (int i = numbers_arr[predict] + 1; i < numbers_arr.Length - 1; i++)
                    {


                        if (numbers_arr[i] == search_target)
                        {

                            return;
                        }
                        hops++;
                    }
                    Console.WriteLine("Search target found! Hops: " + hops);//Counts an extra hop, not sure why

                }

            }
        }
        public static void Interpolation_Binary_Search(int[] numbers_arr, int search_target, int bottom, int top, ref int hops)
        {
            //The beginning of this code is exactly the same as the Interpolation_Search Method

            //Values
            int val_bottom = numbers_arr[bottom];
            int val_top = numbers_arr[top];

            //Check if search has failed
            if (bottom > top || search_target > val_top)
            {
                Console.WriteLine("Search target not found! ");
                return;
            }



            //Run equation

            int predict = (((top - bottom) * (search_target - val_bottom)) / (val_top - val_bottom) + bottom);

            //If found, search done
            //Check next steps
            //If target found, search done
            if (numbers_arr[predict] == search_target)
            {
                hops++;
                Console.WriteLine("Search target found! Hops: " + hops);
            }
            else
            {
                if (numbers_arr[predict] > search_target)
                {
                    top = predict - 1;
                    while (bottom <= top)
                    {
                        int midpoint = (bottom + top) / 2;
                        hops++;

                        if (numbers_arr[midpoint] == search_target)
                        {
                            Console.WriteLine("Search target found! Hops: " + hops);
                            Console.WriteLine(numbers_arr[midpoint]);

                            return;
                        }
                        else if (numbers_arr[midpoint] > search_target)
                        {
                            top = midpoint - 1;
                            //Binary_Search(numbers_arr, search_target, bottom, top, ref hops);

                        }
                        else if (numbers_arr[midpoint] < search_target)
                        {
                            bottom = midpoint + 1;
                            //Binary_Search(numbers_arr, search_target, bottom, top, ref hops);
                        }
                    }
                    //Binary_Search(numbers_arr, search_target, bottom, top, ref hops);
                    //Console.WriteLine(Binary_Search(numbers_arr, search_target, bottom, top, ref hops));
                    return;
                }
                else if (numbers_arr[predict] < search_target)
                {
                    bottom = predict + 1;
                    while (bottom <= top)
                    {
                        int midpoint = (bottom + top) / 2;
                        hops++;

                        if (numbers_arr[midpoint] == search_target)
                        {
                            Console.WriteLine("Search target found! Hops: " + hops);
                            Console.WriteLine(numbers_arr[midpoint]);

                            return;
                        }
                        else if (numbers_arr[midpoint] > search_target)
                        {
                            top = midpoint - 1;
                            //Binary_Search(numbers_arr, search_target, bottom, top, ref hops);

                        }
                        else if (numbers_arr[midpoint] < search_target)
                        {
                            bottom = midpoint + 1;
                            //Binary_Search(numbers_arr, search_target, bottom, top, ref hops);
                        }
                    }
                    //Binary_Search(numbers_arr, search_target, bottom, top, ref hops);
                    // Console.WriteLine(Binary_Search(numbers_arr, search_target, bottom, top, ref hops));

                }


            }
            Console.WriteLine("Search not found!");
        }
        /* public static void Binary_Search(int[] numbers_arr, int search_target, int bottom, int top, ref int hops)
         {
             bool one_item = false;
             int item_count = 0;
             //check in which half will be


             while (bottom <= top)
             {
                 int midpoint = (bottom + top) / 2;
                 if (numbers_arr[midpoint] == search_target)
                 {
                     return;
                     Console.WriteLine(numbers_arr[midpoint]);
                     Console.WriteLine(midpoint);
                 }
                 else if (numbers_arr[midpoint] > search_target)
                 {
                     top = midpoint - 1;
                     //Binary_Search(numbers_arr, search_target, bottom, top, ref hops);

                 }
                 else if (numbers_arr[midpoint] < search_target)
                 {
                     bottom = midpoint + 1;
                     //Binary_Search(numbers_arr, search_target, bottom, top, ref hops);
                 }
             }

 ;



         }*/
        public static void Interpolation_Exponential_Search(int[] numbers_arr, int search_target, int bottom, int top, ref int hops)
        {
            //The beginning of this code is exactly the same as the Interpolation_Search Method

            //Values
            int val_bottom = numbers_arr[bottom];
            int val_top = numbers_arr[top];

            //Check if search has failed
            if (bottom > top || search_target > val_top)
            {
                Console.WriteLine("Search target not found! ");
                return;
            }



            //Run equation

            int predict = (((top - bottom) * (search_target - val_bottom)) / (val_top - val_bottom) + bottom);

            //If found, search done
            //Check next steps
            //If target found, search done
            if (numbers_arr[predict] == search_target)
            {
                hops++;
                Console.WriteLine("Search target found! Hops: " + hops);
            }
            else
            {
                if (numbers_arr[predict] > search_target)
                {
                    int new_i = bottom;
                    top = predict - 1;
                    while (new_i < numbers_arr.Length && numbers_arr[new_i] < search_target)
                    {
                        hops++;
                        if (numbers_arr[new_i] == search_target)
                        {
                            Console.WriteLine("Search target found! Hops: " + hops);
                            Console.WriteLine(numbers_arr[new_i]);
                            return;
                        }
                        new_i = new_i * 2;
                        //How to continue
                    }

                    int new_bottom = new_i / 2;//Beginning of i will be half od the highset value as we are duplicating every loop time
                    int new_top = Math.Min(new_i, numbers_arr.Length);

                    //Then we perform a binary search
                    while (new_bottom <= new_top)
                    {
                        int midpoint = new_bottom + (new_top - new_bottom) / 2;
                        hops++;

                        if (numbers_arr[midpoint] == search_target)
                        {
                            Console.WriteLine("Search target found! Hops: " + hops);
                            Console.WriteLine(numbers_arr[midpoint]);

                            return;
                        }
                        else if (numbers_arr[midpoint] > search_target)
                        {
                            new_top = midpoint - 1;
                            //Binary_Search(numbers_arr, search_target, bottom, top, ref hops);

                        }
                        else if (numbers_arr[midpoint] < search_target)
                        {
                            new_bottom = midpoint + 1;
                            //Binary_Search(numbers_arr, search_target, bottom, top, ref hops);
                        }
                    }

                }
                else if (numbers_arr[predict] < search_target)
                {
                    //https://en.wikipedia.org/wiki/Exponential_search
                    int new_i = predict + 1;
                    while (new_i < numbers_arr.Length && numbers_arr[new_i] < search_target)
                    {
                        hops++;
                        if (numbers_arr[new_i] == search_target)
                        {
                            Console.WriteLine("Search target found! Hops: " + hops);
                            Console.WriteLine(numbers_arr[new_i]);
                            return;
                        }
                        new_i = new_i * 2;
                        //How to continue
                    }

                    int new_bottom = new_i / 2;//Beginning of i will be half od the highset value as we are duplicating every loop time
                    int new_top = Math.Min(new_i, numbers_arr.Length);

                    //Then we perform a binary search
                    while (new_bottom <= new_top)
                    {
                        int midpoint = new_bottom + (new_top - new_bottom) / 2;
                        hops++;

                        if (numbers_arr[midpoint] == search_target)
                        {
                            Console.WriteLine("Search target found! Hops: " + hops);
                            Console.WriteLine(numbers_arr[midpoint]);

                            return;
                        }
                        else if (numbers_arr[midpoint] > search_target)
                        {
                            new_top = midpoint - 1;
                            //Binary_Search(numbers_arr, search_target, bottom, top, ref hops);

                        }
                        else if (numbers_arr[midpoint] < search_target)
                        {
                            new_bottom = midpoint + 1;
                            //Binary_Search(numbers_arr, search_target, bottom, top, ref hops);
                        }
                    }



                }


            }
            Console.WriteLine("Search not found!");
        }
    }
}