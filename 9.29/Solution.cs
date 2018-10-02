using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9._29
{
    public class Solution
    {
        private int length;
        private byte[,] blob;
        private List<Tuple<int, int>> result=new List<Tuple<int, int>>();

        private  HashSet<string> finalHashSet=new HashSet<string>();
        private List<int> tagList=new List<int>();

        static void Main()
        {
            var t=new Solution();
            Console.WriteLine(t.TotalNQueens(5));
            
        }

        public int TotalNQueens(int n)
        {
            length = n;
            blob = new byte[n, n];
            Inicialize(ref blob);

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j <n; j++)
                {
                    blob[i, j] = 1;
                    result.Add(new Tuple<int, int>(i, j));

                    Callbackhell();
                    

                    if (result.Count == n)
                    {
                        for (int k = 0; k < result.Count; k++)
                        {
                            var tag=result[k].Item1.ToString() + result[k].Item2.ToString();
                            var tagnum=Convert.ToInt32(tag);
                            tagList.Add(tagnum);
                            
                        }
                        tagList.Sort();
                        string temp = string.Empty;
                        foreach (var tag in tagList)
                        {
                            temp += tag.ToString();
                        }
                        finalHashSet.Add(temp);

                        Inicialize(ref blob);
                        tagList=new List<int>();
                        result = new List<Tuple<int, int>>();
                        
                    }
                    if (result.Count < n)
                    {
                        result = new List<Tuple<int, int>>();
                        Inicialize(ref blob);
                    }
                }
            }


             return finalHashSet.Count;
        }

        private void Inicialize( ref byte[,] blob)
        {
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    blob[i, j] = 0;
                }
            }
        }

       
        private void Callbackhell()
        {
            for (int k = 0; k < length; k++)
            {
                for (int l = 0; l < length; l++)
                {
                    var line = Sumline(k, l);
                    var row = Sumrow(k, l);
                    var curve = Sumcurve(k, l);
                    bool flag = line  +row  + curve == 0;
                    
                    if (flag)
                    {
                        blob[k, l] = 1;
                        result.Add(new Tuple<int, int>(k, l));
                        
                        if (k<length-1)
                        {
                            Callbackhell();
                        }
                        else
                        {
                            return;
                        }

                        if (result.Count<length)
                        {
                            Inicialize(ref blob);
                        }

                    }
                    
                }
                
        
            }

            




            //如果放不下n个皇后，就会结束这一轮调用，result长度不变

        }

        public int Sumline(int k,int l)
        {
            int sum=0;
            for (int i = 0; i < length; i++)
            {
                sum += blob[k, i];
            }

            return sum;
        }
        public int Sumrow(int k, int l)
        {
            int sum = 0;
            for (int i = 0; i < length; i++)
            {
                sum += blob[i, l];
            }

            return sum;
        }
        public int Sumcurve(int k, int l)
        {
            int sum = 0;
            int target1 = k;
            int target2 = l;
                
        
            while (target1 < length && target2 < length)
            {
                sum += blob[target1++, target2++];
            }
            target1 = k;
            target2 = l;

            while (target1 >=0 && target2 >= 0)
            {
                sum += blob[target1--, target2--];
            }

            target1 = k;
            target2 = l;

            while (target1 >= 0 && target2 < length)
            {
                sum += blob[target1--, target2++];
            }

            target1 = k;
            target2 = l;

            while (target1 < length && target2 >= 0)
            {
                sum += blob[target1++, target2--];
            }
            
            //////////////////三种计算都包含了自己
            return sum;
        }
    }
}
