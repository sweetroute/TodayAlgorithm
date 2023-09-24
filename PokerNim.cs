using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodayAlgorithm
{
    /// <summary>
    /// [171114][HackerRank](C#)Poker Nim
    /// 문제>
    /// * 플레이어는 두명이다.
    ///  선수들은 교대로 움직이고 다음 작업중 하나를 해야한다.
    /// - 한 더미에서 하나 이상의 칩을 제거.
    /// - 단일 더미에서 하나 이상의 칩을 추가.
    /// 최소한 1칩은 매 회전마다 추가되거나 제거되어야 합니다.
    /// 마지막 칩을 제거한 플레이어가 게임에서 승리한다.
    /// 
    /// T는 게임 수.
    /// 이 것을 감안할 때, n(더미 수), k(개별 플레이어가 일부 더미에 칩을 추가할 수 있는 최대 수i)
    /// ci는 각각의 더미에 남아있는 수.
    /// 
    /// 더미에 남아있는 수로 유추했을 때 승자를 찾아내라는 듯.
    /// </summary>
    class PokerNim
    {
        /// <summary>
        /// 해결방법.
        /// 참고 : http://elwlsek.tistory.com/454 
        /// * XOR사용.
        /// - 님게임시 2진법으로 변환해서 xor연산으로 했을 때
        /// - 0이면(짝수) second 승
        /// - 0이상(홀수)면 first승.
        /// </summary>
        public void PokerNim_()
        {
            int T = int.Parse(Console.ReadLine());
            int[] data = null;
            int[] next_data = null;

            while (T > 0)
            {
                data = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                next_data = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                int sum = next_data[0];

                for (int i = 1; i < data[0]; i++)
                {
                    sum ^= next_data[i];
                }
                if (sum == 0)
                    Console.WriteLine("Second");
                else
                    Console.WriteLine("First");
                T -= 1;
            }
        }
    }
}
