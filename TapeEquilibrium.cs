using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodayAlgorithm
{
    /// <summary>
    /// [171115][Codility](C#)TapeEquilibrium
    /// 링크 : https://codility.com/programmers/lessons/3-time_complexity/tape_equilibrium/
    /// 문제>
    /// * n개의 배열에서 A[0]~A[p-1]
    ///     까지의 합(=P)과 A[p]~A[n-1]
    ///     까지의 합(=N)의 차(P-N)의 절대값을 구해 가장 작은 수를 출력하라.
    /// ** P = A[0] +.. + A[p - 1]);
    /// ** N = A[p] +.. + A[n - 1];
    /// ** abs = | P - N |;
    /// </summary>
    class TapeEquilibrium
    {
        /// <summary>
        /// 해결방법 0. ( 정확도 100%, 퍼포먼스 33% ) 쓰레기..
        /// *) 2중 for문 사용.
        /// 1) 첫번째 for문에서 A의 0~n-1개 까지 누적으로 더하고( = P)
        /// - 내부의 두번째 for문 p 부터 n - 1을 더한다( = N)
        /// - N과 P를 뺀 절대값을 누적해서 더 작은 값이 나올 때 교체해준다.
        /// * 첫번째 for문 돌때 내부의 for문이 남은 수 만큼 계속 돌기 때문에 좋은 방법이 아니다.
        /// </summary>
        public int TapeEquilibrium1(int[] A)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            int P = 0;
            int N = 0;
            int output = -1;

            int abs = 0;


            for (int i = 0; i < A.Length - 1; i++)
            {
                P += A[i];
                N = 0;
                for (int j = i + 1; j < A.Length; j++)
                {
                    N += A[j];
                }

                abs = Math.Abs(P - N);
                output = output == -1 ? abs : output < abs ? output : abs;

            }
            return output;
        }

        /// <summary>
        /// 해결방법 1. ( 정확도 100%, 퍼포먼스 100% )
        /// 1) A의 값을 전부 더한다. = N
        /// 2) for문을 A의 수만큼 돌면서 N서 순차로 뺴고 뺀 값을 P에 더한다.
        /// - N과 P를 뺀 절대값을 누적해서 더 작은 값이 나올 때 교체해준다.
        /// * 미리 N의 합을 구해놓고 N에서 뺀 값을 P에 더하기 때문에 매번 N의 합을 구하는 계산이 줄어든다.
        /// </summary>
        public int TapeEquilibrium2(int[] A)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)

            int N = 0;
            int P = 0;
            int output = -1;
            int abs = 0;
            for (int i = 0; i < A.Length; i++)
            {
                N += A[i];
            }
            for (int i = 0; i < A.Length - 1; i++)
            {
                N -= A[i];
                P += A[i];
                abs = Math.Abs(P - N);
                output = output == -1 ? abs : output < abs ? output : abs;

            }
            return output;
        }
    }
}
