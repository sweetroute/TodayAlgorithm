using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// [171109][HackerRank](C#)Missing Numbers
/// 링크 : https://www.hackerrank.com/challenges/missing-numbers/problem
/// 문제>
/// 두개의 리스트 A와 B를 비교해서
/// * A에 없는 B의 값
/// * 반복 수가 다른 값
/// 을 찾아서 오름차순으로 출력.
/// </summary>
namespace TodayAlgorithm
{
    /// <summary>
    /// 해결방법 1.
    /// 1)A리스트와 B리스트를 정렬.    
    /// 2)반복문을 돌면서 B리스트의 0번째 값과 같은값을 A리스트와 B리스트에서 전부 찾는다.
    /// - 찾아온 수를 비교해서 다르면 B리스트의 0번째 값을 출력할 데이터에 추가.
    /// - B리스트에서 B리스트의 0번째 값과 같은 값을 전부 삭제.
    /// - B리스트가 0이 될 때까지 반복.
    /// </summary>
    class MissingNumbers
    {
        public void MissingNumbers1()
        {
            List<int> AList = new List<int>(Array.ConvertAll(Console.ReadLine().Split(' '), Int32.Parse));
            List<int> BList = new List<int>(Array.ConvertAll(Console.ReadLine().Split(' '), Int32.Parse));
            string outNum = string.Empty;
            AList.Sort();
            BList.Sort();
            while (BList.Count > 0)
            {
                int removeNum = BList[0];
                int findACount = AList.FindAll(obj => obj == removeNum).Count;
                int findBCount = BList.FindAll(obj => obj == removeNum).Count;

                if (findACount != findBCount)
                {
                    outNum += removeNum.ToString() + ' ';
                }

                if (findBCount > 0)
                    BList.RemoveRange(0, findBCount);
            }
            Console.WriteLine(outNum);
        }

        /// <summary>
        /// 해결방법 2.
        /// 1)반복문을 돌면서 B리스트의 0번째 값과 같은 값을 A리스트와 B리스트에서 전부 삭제.
        /// - 삭제 된 수를 비교해서 다를 경우 C리스트에 추가.
        /// - B리스트가 0이 될 때까지 반복.
        /// 2)C리스트를 정렬.
        /// 3)C리스트를 출력할 데이터에 추가.
        /// </summary>
        public void MissingNumbers2()
        {
            List<int> AList = new List<int>(Array.ConvertAll(Console.ReadLine().Split(' '), Int32.Parse));
            List<int> BList = new List<int>(Array.ConvertAll(Console.ReadLine().Split(' '), Int32.Parse));
            List<int> CList = new List<int>();

            while (BList.Count > 0)
            {
                int removeNum = BList[0];
                int findACount = AList.RemoveAll(obj => obj == removeNum);
                int findBCount = BList.RemoveAll(obj => obj == removeNum);
                if (findACount != findBCount)
                {
                    CList.Add(removeNum);
                }
            }
            CList.Sort();
            string outNum = string.Empty;
            for (int i = 0; i < CList.Count; i++)
            {
                outNum += CList[i].ToString() + ' ';
            }
            Console.WriteLine(outNum);
        }

        /// <summary>
        /// 해결방법 3.
        /// 1)A리스트와 B리스트를 정렬.
        /// 2)반복문을 돌면서 B리스트의 0번째 값과 다른 값의 번지를 찾는다.
        /// - 만약 찾아온 번지가 0보다 작거나 같으면 각각의 리스트의 잔여 수로 변경.
        /// - 찾아온 A리스트와 B리스트의 번지가 다르면 출력할 데이터에 추가.
        /// - A리스트와 B리스트에서 위의 찾아온 번지까지 삭제.
        /// </summary>
        public void MissingNumbers3()
        {
            List<int> AList = new List<int>(Array.ConvertAll(Console.ReadLine().Split(' '), Int32.Parse));
            List<int> BList = new List<int>(Array.ConvertAll(Console.ReadLine().Split(' '), Int32.Parse));
            string outNum = string.Empty;
            AList.Sort();
            BList.Sort();

            while (BList.Count > 0)
            {
                int removeNum = BList[0];
                int findACount = AList.FindIndex(obj => obj != removeNum);
                int findBCount = BList.FindIndex(obj => obj != removeNum);
                findACount = findACount <= 0 ? AList.Count : findACount;
                findBCount = findBCount <= 0 ? BList.Count : findBCount;
                if (findACount != findBCount)
                {
                    outNum += removeNum.ToString() + ' ';
                }
                if (findACount > 0)
                    AList.RemoveRange(0, findACount);

                if (findBCount > 0)
                    BList.RemoveRange(0, findBCount);
            }
            Console.WriteLine(outNum);
        }

        /// <summary>
        /// 해결방법 4.
        /// 1)A리스트와 B리스트를 정렬.
        /// 2)반복문을 돌면서 B리스트의 0번째 값과 같은 값을 A리스트와 B리스트에서 전부 삭제.
        /// - 삭제 된 수를 비교해서 다르면 B리스트의 0번째 값을 출력할 데이터에 추가.
        /// - B리스트가 0이 될 때까지 반복.
        /// </summary>
        public void MissingNumbers4()
        {
            List<int> AList = new List<int>(Array.ConvertAll(Console.ReadLine().Split(' '), Int32.Parse));
            List<int> BList = new List<int>(Array.ConvertAll(Console.ReadLine().Split(' '), Int32.Parse));

            AList.Sort();
            BList.Sort();

            string outData = string.Empty;

            while (BList.Count > 0)
            {
                int removeNum = BList[0];
                int findACount = AList.RemoveAll(obj => obj == removeNum);
                int findBCount = BList.RemoveAll(obj => obj == removeNum);
                if (findACount != findBCount)
                {
                    outData += removeNum.ToString() + ' ';
                }
            }
            Console.WriteLine(outData);
        }
    }
}
