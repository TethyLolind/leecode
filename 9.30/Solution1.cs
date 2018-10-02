using System;
using System.Collections.Generic;

namespace _9._30
//n皇后问题
{
    public class Solution1
    {
        static void Main()
        {

            var a = new Solution1();
            var result = a.JudgeSquareSum(2147482647);
            Console.WriteLine(result);
        }
        public bool JudgeSquareSum(int c)//kuai!
        {
            int cc = Convert.ToInt32(Math.Sqrt(c));
            if (cc * cc == c)
            {
                return true;
            }

            var length = cc + 1;
            for (int i = 0; i < length; i++)
            {
                for (int j = i; j < length; j++)
                {
                    
                    {
                        int try1 = i * i + j * j;
                        if (try1 == c)
                        {
                            return true;
                        }
                        else if(try1>c)
                        {
                            length--;
                            break;
                        }

                    }


                }
            }

            return false;
        }

        public bool JudgeSquareSum1(int c)
        {
            bool f = false;
            List<int> lis = new List<int>();
            int pps = 0;
            int input = Convert.ToInt32(Math.Sqrt(c));
            for (int i = 0; i < input + 1; i++)
            {
                pps = i * i;
                lis.Add(pps);
            }

            for (int i = 0; i < lis.Count; i++)
            {
                for (int j = i; j < lis.Count; j++)
                {
                    if (lis[i]+lis[j]==c)
                    {
                        f = true;
                    }
                }
            }


            
           

            return f;
        }
    }
}
