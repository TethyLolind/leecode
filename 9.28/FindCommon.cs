using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9._28
{
    public class FindCommon
    {
        //static void Main()
        //{
        //    var test=new String[]{ "flower", "flow", "flight" };
        //    var a=new Solution();
        //    var result=a.LongestCommonPrefix(test);
        //    Console.WriteLine(result);
        //}
        public string LongestCommonPrefix(string[] strs)
        {
            if (strs==null)
            {
                return string.Empty;
            }
            var charArrayList=new List<char[]>();
            for (int i = 0; i < strs.Length; i++)
            {
                var chars=strs[i].ToCharArray();
                charArrayList.Add(chars);
            }


            var example = FindShortest(strs).ToCharArray();
            var index=NewMethod(example, charArrayList);

            

            string result = string.Empty;
            for (int i = 0; i < index; i++)
            {
                result += example[i];
            }

            return result;
        }

        private static string FindShortest(string[] strs)
        {
            string temp = string.Empty;
            int length = strs.FirstOrDefault().Length;
            for (int i = 0; i < strs.Length; i++)
            {
                if (strs[i].Length < length)
                {
                    length = strs[i].Length;
                    temp = strs[i];
                }
            }
            return temp;
        }

        private static int NewMethod(char[] example, List<char[]> charArrayList)
        {
            for (int i = 0; i < example.Length; i++)
            {
                var verifyChar = example[i];
                foreach (var chararray in charArrayList)
                {
                    if (chararray[i] == example[i])
                    {
                        continue;
                    }
                    else
                    {
                        return i; 
                    }
                }
            }

            return example.Length;
        }
    }
}
