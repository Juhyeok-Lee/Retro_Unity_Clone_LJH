﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Problem_3
{
    internal class Program
    {
        // System.io를 추가하고 스트림리더와 스트림라이터를 사용하여 공간복잡도를 감소시킴.
        static StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        static StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        /** i,j는 시어핀스키 사각형의 (i, j) 원소를 가리킴. 각 원소는 '*' 혹은 ' '의 두 가지 상태를 가질 수 있음.
         * 시어핀스키 사각형을 그리는 기준이 있으므로 사각형의 차원(N의 세제곱근)이 얼마인지 안다면 (i, j) 원소가 빈 칸인지 아닌지 알 수 있음.
         */
        static void SquareSierpinski(int _i, int _j, int _N)                
        {
            if ((int)(_i / _N) % 3 == 1 && (int)(_j / _N) % 3 == 1)
            {
                sw.Write(" ");
            }
            else if (_N / 3 < 1)
            {
                sw.Write("*");
            }                    
            else
            {
                SquareSierpinski(_i, _j, _N / 3);
            }            
        }


        static void Main(string[] args)
        {
            // 스트림라이터를 사용하니 에러가 발생하여 Console.WriteLine을 사용함.
            Console.WriteLine("N을 입력하세요. (N은 3의 거듭제곱)");

            int N = int.Parse(sr.ReadLine());

            for (int i = 0; i < N; i++)                                     // 한 행씩 작성하는 것을 N만큼 반복
            {
                for (int j = 0; j < N; j++) SquareSierpinski(i, j, N);      // 한 행 작성
                sw.Write("\n");                                             // 한 줄마다 줄바꿈 문자를 추가해줌.
            }

            // 스트림리더와 스트림라이터는 사용자가 직접 닫아줘야 함.
            sr.Close();
            sw.Close();
        }
    }
}