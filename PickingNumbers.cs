using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodayAlgorithm
{
    /// <summary>
    /// [171113][HackerRank](C#)Picking Numbers
    /// 링크 : https://www.hackerrank.com/challenges/picking-numbers/problem
    /// 문제>
    /// * 두 수를 뺀 절대값이 1이하인 수의 집합 중 가장 수가 많은 집합을 구하라.
    /// * 집합 내에서 어떤 수들과 계산해도 1이하가 나와야 한다.
    /// </summary>
    class PickingNumbers
    {
        /// <summary>
        /// 해결방법.
        /// 1) 데이터를 리스트A로 만들어 정렬.
        /// 2) key에 숫자 value 숫자의 수를 넣을 딕셔너리B 생성.
        /// 3) 반복문을 돌면서
        /// - 리스트A의 0번째 값을 딕셔너리B의 키값으로 0번째 값을 리스트A에서 전부 지우고 지운 수를 value로 추가해준다.
        /// - 리스트A의 데이터 수가 0이 될때까지 반복.
        /// 4) 딕셔너리B를 순차로 읽어온다.
        /// - 딕셔너리B의 이전값과 현재값 사이의 key값 차를 구해서 절대값이 1보다 작거나 같으면 두 값의 value를 더한다.
        /// - 계산된 value를 outputCount에 저장해두었다가 다음 번에 들어오는 value의 합과 비교해 들어온 값이 크다면 교체해준다.
        /// - outputCount가 0이라면 현재의 value를 입력해준다.
        /// 5) 만약 가장 많은 숫자의 수가 outputCount보다 크다면 교체해준다.(뺀값보다 차이가 0이나는 숫자가 더 많을 때를 위함)
        /// </summary>
        public void PickingNumbers_()
        {
            Convert.ToInt32(Console.ReadLine());
            string[] a_temp = Console.ReadLine().Split(' ');
            int[] a = Array.ConvertAll(a_temp, Int32.Parse);

            List<int> dataA = new List<int>(a);
            dataA.Sort();
            Dictionary<int, int> dataB = new Dictionary<int, int>();
            while (dataA.Count > 0)
            {
                int removeValue = dataA[0];
                int removeCount = dataA.RemoveAll(obj => obj == removeValue);
                dataB.Add(removeValue, removeCount);
            }
            int outputCount = 0;
            int prevKey = 0;
            foreach (KeyValuePair<int, int> _data in dataB)
            {
                if (prevKey > 0)
                {
                    int _abs = _data.Key - prevKey;
                    _abs = _abs < 0 ? -_abs : _abs;
                    if (_abs <= 1)
                    {
                        int count = _data.Value + dataB[prevKey];
                        if (count > outputCount)
                        {
                            outputCount = count;
                        }
                    }
                }
                prevKey = _data.Key;
                if (outputCount == 0)
                    outputCount = _data.Value;
            }
            int _value = dataB.Max(obj => obj.Value);
            if (outputCount < _value)
                outputCount = _value;
            Console.WriteLine(outputCount);
        }
    }
}
