using System;

namespace TwoPointerAndSlidingWindows
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string a = "aba";
            string b = "aabba";
            Console.WriteLine($"Задание 1: {CanConstruct(a, b)}");

            int[] array = { 3, 3, 1, 2, 3, 4, 5, 6, 7, 8, 2 };
            Console.WriteLine($"Задание 2: {FindLucky(array)}");

            int[] nums = { 0, 1, 1, 0, 1, 1, 0, 0, 1, 1, 1, 1, 1, 0 };
            int k = 2;
            Console.WriteLine($"Задание 3: {LongestOnes(nums, k)}");
        }
        public static bool CanConstruct(string ransomNote, string magazine)
        {
            char[] noteArr = ransomNote.ToCharArray();
            char[] magArr = magazine.ToCharArray();
            Array.Sort(noteArr);
            Array.Sort(magArr);

            int i = 0;
            int j = 0;
            while (i < noteArr.Length && j < magArr.Length)
            {
                if (noteArr[i] == magArr[j])
                {
                    i++;
                    j++;
                }
                else if (magArr[j] < noteArr[i])
                {
                    j++;
                }
                else
                {
                    return false;
                }
            }
            return i == noteArr.Length;
        }
        public static int FindLucky(int[] arr)
        {
            Array.Sort(arr);
            int maxLucky = 0;
            int n = arr.Length;
            int slow = 0;

            for (int fast = 0; fast <= n; fast++)
            {
                if (fast == n || arr[fast] != arr[slow])
                {
                    int count = fast - slow;
                    if (count == arr[slow])
                    {
                        maxLucky = Math.Max(maxLucky, arr[slow]);
                    }
                    slow = fast;
                }
            }
            return maxLucky;
        }

        public static int LongestOnes(int[] nums, int k)
        {
            int left = 0, maxLen = 0, zeroCount = 0;
            for (int right = 0; right < nums.Length; right++)
            {
                if (nums[right] == 0) zeroCount++;

                while (zeroCount > k)
                {
                    if (nums[left] == 0) zeroCount--;
                    left++;
                }
                maxLen = Math.Max(maxLen, right - left + 1);
            }
            return maxLen;
        }
    }
}