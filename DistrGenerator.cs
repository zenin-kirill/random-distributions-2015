using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DemoLab1._1
{

    //Генератор псевдослучайных чисел с равномерным и гауссовым распределением значений//
    public class DistrGenerator
    {
        private static Random rand = new Random();
        public static double[] gaussMass { get; set; }
        public static double[] uniformMass { get; set; }

        //==Функция теоретического расчета относительной плотности частоты нормального распределения

        public static double CalculateGaussFunc(double x, double mu = 0, double si = 1)
        {
            return 1 / (si * Math.Sqrt(2 * Math.PI)) * Math.Exp(-Math.Pow((x - mu), 2) / (2 * Math.Pow(si, 2)));
        }

        //Генерация сигнала с нормальным распределением методом Бокса — Мюллера//

        public static double[] GetSelectOfGaussDistrBM(long selectionLength = 1000)
        {
            double u1;     //числа, сгенерированные ген. случ. чисел с равномерным распредел.
            double u2; 

            gaussMass = new Double[selectionLength];       //массив чисел с гауссовым распределением величины

            for (int i = 0; i < selectionLength; i++)            //генерируем необходимое кол-во отсчетов
            {
                u1 = rand.NextDouble();
                u2 = rand.NextDouble(); 
                gaussMass[i] = Math.Sqrt(-2.0 * Math.Log(u1)) *
                                Math.Sin(2.0 * Math.PI * u2);
            }
            return gaussMass;                           //возвращаем результирующий массив
        }

        //Генерация сигнала с нормальным распределением методом усреднения// 

        public static double[] GetSelectOfGaussDistrS(long selectionLength = 1000)
        {
            double randNum = 0;         
            double sumOfRand = 0;

            gaussMass = new Double[selectionLength];             //массив чисел с гауссовым распределением величины

            for (int i = 0; i < selectionLength; i++)                               //длина массива равна selectionLength отсчетов
            {
                sumOfRand = 0;
                for (int j = 0; j <= 8; j++)                                             //формируем гауссовость
                {
                    //for (int h = 0; h <= 4; h++)                                       //дополнительно прореживаем поток от ДСЧ (берем только каждый 5-й отсчет)
                        randNum = rand.NextDouble() - 0.5;                          //центрируем
                    sumOfRand = sumOfRand + randNum;
                }
                gaussMass[i] = Math.Sqrt(12.0) * sumOfRand / 3;               //сохраняем дисперсию гауссового сигнала = 1
            }
            return gaussMass;                                     //возвращаем результирующий массив
        }

        public static double[] GetSelectOfUniformDistr(long selectionLength = 1000)
        {
            uniformMass = new Double[selectionLength];                      //массив чисел с равномерным распределением величины

            for (int i = 0; i < selectionLength; i++)                              //длина массива равна selectionLength отсчетов
                uniformMass[i] = rand.NextDouble() - 0.5;       
            return uniformMass;                                 //возвращаем результирующий массив
        }
    }
}
