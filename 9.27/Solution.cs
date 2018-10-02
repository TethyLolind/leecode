namespace _9._27
{
    public class Solution
    {
        public int[] TwoSum(int[] nums, int target)
        {
            var toSortArray=nums;

            //List<Tuple<int, int>> result=new List<Tuple<int, int>>();

            int[] result=new int[2];

            for (int i = 0; i < toSortArray.Length; i++)
            {
                for (int j = toSortArray.Length-1; j > i; j--)
                {
                    if (toSortArray[i] + toSortArray[j] == target)
                    {
                        result = new int[2] {i, j};
                    }
                    else
                    {
                        continue;
                    }
                }

               
            }

            return result;
            //int[][] realResult = new int[result.Count][];
            //var resultArray = result.ToArray();
            //for (int i = 0; i < resultArray.Length; i++)
            //{
            //    realResult[i]=new int[2]{resultArray[i].Item1,resultArray[i].Item2};
            //}





        }
    }
}