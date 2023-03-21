using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodayAlgorithm
{
    /// <summary>
    /// [171110][HackerRank](C#)Jim and the Orders
    /// 링크 : https://www.hackerrank.com/challenges/jim-and-the-orders/problem
    /// 문제>
    /// 주문받은 시간과 걸리는
    /// * 시간을 합하여
    /// * 가장 짧은 순서로
    /// * 주문번호를 출력할것.
    /// </summary>
    class JimandtheOrders
    {
        /// <summary>
        /// 해결방법
        /// 1) 주문시간과 걸리는시간을 합한 리스트A를 만든다.
        /// 2) 출력할 리스트를 담을 빈 리스트C와 리스트A를 복사한 리스트B를 하나 더 만들어 정렬.
        /// 3) 주문 수 만큼 반복문을 돌면서 리스트 A를 순서대로 정렬된 리스트B에서 몇번째 번지에 있는지 찾는다.
        /// - 찾은 번지가 리스트 C에 이미 있다면 +1을 해서 같은 값이 없을 때 까지 번지를 증가.
        /// - 리스트C에 추가.
        /// 4) 리스트C의 수만큼 반복문을 돌면서 순서대로 주문 번호를 찾아서 출력.
        /// </summary>
        public void JimandtheOrders_()
        {
            int orderCount = int.Parse(Console.ReadLine());
            List<int> orderTime = new List<int>();
            for (int i = 0; i < orderCount; i++)
            {
                List<int> readData = new List<int>(Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse));

                int data = 0;
                for (int j = 0; j < readData.Count; j++)
                {
                    data += readData[j];
                }
                orderTime.Add(data);
            }
            List<int> outputList = new List<int>();
            string _output = string.Empty;
            List<int> copyOrderTime = new List<int>(orderTime);
            copyOrderTime.Sort();
            for (int i = 0; i < orderTime.Count; i++)
            {
                int num = copyOrderTime.FindIndex(obj => obj == orderTime[i]);
                while (outputList.Contains(num) == true)
                {
                    num += 1;
                }
                outputList.Add(num);
            }
            for (int i = 0; i < outputList.Count; i++)
            {
                int tmp = outputList.FindIndex(obj => obj == i) + 1;
                _output += tmp.ToString() + " ";
            }
            Console.WriteLine(_output);
        }
    }
}
