using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ZedGraph;

namespace DemoLab1._1
{
    //Класс для организации работы формы

    public partial class Form1 : Form
    {
        public int modeNumber = 0;                       // выбор мода: 0 - кривая, 1 - отсчеты

        private int numberOfDigits = 100;               // интервал добавления новых данных
        private int numberOfSteps = 15;                 // количество интервалов на гистограмме частот

        private double uniformAllSizeOfSteps = 0;       // размеры шага    
        private double gaussAllSizeOfSteps = 0;

        private double uniformSelectSizeOfSteps = 0;
        private double gaussSelectSizeOfSteps = 0;

        private Random r = new Random();            // генератор псевдослуч. чисел по равномер. закону распределения.

        PointPairList uniformSelectRandList;          // массивы точек линий графиков    
        PointPairList gaussSelectRandList;

        PointPairList uniformAllDistList;
        PointPairList gaussAllDistList;

        PointPairList uniformSelectDistList;
        PointPairList gaussSelectDistList;

        //

        GraphPane uniformSelectRandPane;           // панели отрисовки графиков
        GraphPane gaussSelectRandPane;

        GraphPane uniformAllDistPane;
        GraphPane gaussAllDistPane;

        GraphPane uniformSelectDistPane;
        GraphPane gaussSelectDistPane;

        private List<double> uniformDistributionMass = new List<double>();              //массивы чисел, значения которых, разпределенны по равномерному
        private List<double> gaussDistributionMass = new List<double>();                // и нормальнуму законам

        private List<double> uniformAllFrequencyMass = new List<double>();             //массивы отн. пл. частот накопленных данных
        private List<double> gaussAllFrequencyMass = new List<double>();

        private List<double> uniformSelectFrequencyMass = new List<double>();        //массивы отн. пл. частот текущих данных
        private List<double> gaussSelectFrequencyMass = new List<double>();

        private List<double> uniformTheoryAllFrequencyMass = new List<double>();    //массивы теор. отн. пл. частот 
        private List<double> gaussTheoryAllFrequencyMass = new List<double>();

        public Form1()
        {
            InitializeComponent();      // инициализация формы
        }

        //==Функция, вызываемая при загрузке формы==/

        private void Form1_Load(object sender, EventArgs e)
        {
            newCalculateRandom(100);   // генерация начального интервала значений
            updateRandomGraphs();       // вывод значений сигналов в виде графиков
            calculateAllFrequency();        // расчет частот для накопленного сигнала
            updateAllDistGraphs();         // прорисовка отн. пл. частот накопленного сигнала
            calculateSelectFrequency();   // расчет частот для текущей выборки сигнала
            updateSelectDistGraphs();    // прорисовка отн. пл. частот текущей выборки сигнала
        }

        //==Функция генерации нового набора значений==/

        private void newCalculateRandom(int numbRand = 0)
        {
            if (numbRand == 0)                      // автоматическое определение длины выборки
                numbRand = numberOfDigits;

            if (uniformDistributionMass.Capacity >= 10000)  // ограничение объема массива
            {
                button1.Text = "Конец эксперимента";
                button1.Enabled = false;
                return;
            }

            uniformDistributionMass.Capacity += numbRand;         // расширение массивов всех сгенерированных чисел
            gaussDistributionMass.Capacity += numbRand;

            DistrGenerator.GetSelectOfUniformDistr(numbRand);     // генерация нового интервала чисел
            //DistrGenerator.GetSelectOfGaussDistrS(numbRand);
            DistrGenerator.GetSelectOfGaussDistrBM(numbRand);
						
						// Сравнение двух методов генерации значений с гауссовым арспределением величин
           /*
            System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();
            watch.Start();
            DistrGenerator.GetSelectOfGaussDistrBM(numberOfDigits);
            //for (double i = 0; i < 100; i+= 0.01)
            //    Math.Sin(i);
            watch.Stop();
            Console.Out.WriteLine(watch.ElapsedTicks.ToString());
           
            watch.Restart();
            DistrGenerator.GetSelectOfGaussDistrS(numberOfDigits);
           // for (double i = 0; i < 10000; i++)
            //    Math.Sqrt(i);
            watch.Stop();
            Console.Out.WriteLine(watch.ElapsedTicks.ToString());
           */
    
            for (int i = 0; i < numbRand; i++)      // заполнение массивов новосгенерированными числами
            {
                uniformDistributionMass.Add(DistrGenerator.uniformMass[i]);
                gaussDistributionMass.Add(DistrGenerator.gaussMass[i]);
            }
        }

        //==Функция вычисления частот для накопленных значений==//

        private void calculateAllFrequency()
        {
            uniformAllFrequencyMass.Clear();   // очищаем массивы частот
            gaussAllFrequencyMass.Clear();

            uniformTheoryAllFrequencyMass.Clear();
            gaussTheoryAllFrequencyMass.Clear();

            uniformAllFrequencyMass.Capacity = numberOfSteps;                       // инициализируем массивы частот
            uniformAllFrequencyMass.AddRange(new double[numberOfSteps]);
            gaussAllFrequencyMass.Capacity = numberOfSteps;
            gaussAllFrequencyMass.AddRange(new double[numberOfSteps]);

            uniformTheoryAllFrequencyMass.Capacity = numberOfSteps;
            uniformTheoryAllFrequencyMass.AddRange(new double[numberOfSteps]);
            gaussTheoryAllFrequencyMass.Capacity = numberOfSteps;
            gaussTheoryAllFrequencyMass.AddRange(new double[numberOfSteps]);

            double uniformMaxValue = uniformDistributionMass.Max();                // находим граничные значения
            double gaussMaxValue = gaussDistributionMass.Max();

            double uniformMinValue = uniformDistributionMass.Min();
            double gaussMinValue = gaussDistributionMass.Min();

            uniformAllSizeOfSteps = (uniformMaxValue - uniformMinValue) / numberOfSteps;    // вычисляем длину шага
            gaussAllSizeOfSteps = (gaussMaxValue - gaussMinValue) / numberOfSteps;

            for (int i = 0; i < uniformDistributionMass.Count; i++)                     // распределяем отсчеты по интервалам
            {

                for (int j = 0; j < numberOfSteps; j++)
                    if (uniformDistributionMass[i] <= (uniformMinValue + (uniformAllSizeOfSteps * (j + 1))))
                    {
                        uniformAllFrequencyMass[j] += 1;
                        break;
                    }

                for (int j = 0; j < numberOfSteps; j++)
                    if (gaussDistributionMass[i] <= (gaussMinValue + (gaussAllSizeOfSteps * (j + 1))))
                    {
                        gaussAllFrequencyMass[j] += 1;
                        break;
                    }

            }

            for (int i = 0; i < numberOfSteps; i++)             // вычисляем теоретические значения
            {
                uniformTheoryAllFrequencyMass[i] = 1 / (uniformMaxValue - uniformMinValue);
                gaussTheoryAllFrequencyMass[i] = DistrGenerator.CalculateGaussFunc(gaussMinValue + (0.5 * gaussAllSizeOfSteps) + (i * gaussAllSizeOfSteps));
            }
        }

        //==Функция вычисления частот для текущей выборки значений==//

        private void calculateSelectFrequency()
        {
            uniformSelectFrequencyMass.Clear();   // очищаем массивы частот
            gaussSelectFrequencyMass.Clear();

            uniformSelectFrequencyMass.Capacity = numberOfSteps;                    // инициализируем массивы частот
            uniformSelectFrequencyMass.AddRange(new double[numberOfSteps]);
            gaussSelectFrequencyMass.Capacity = numberOfSteps;
            gaussSelectFrequencyMass.AddRange(new double[numberOfSteps]);

            double uniformMaxValue = -9999;     // вычисление граничных значений
            double uniformMinValue = 9999;

            for (int i = uniformDistributionMass.Count - numberOfDigits; i < uniformDistributionMass.Count; i++)
            {
                if (uniformDistributionMass[i] > uniformMaxValue)
                    uniformMaxValue = uniformDistributionMass[i];
                if (uniformDistributionMass[i] < uniformMinValue)
                    uniformMinValue = uniformDistributionMass[i];
            }

            double gaussMaxValue = -9999;
            double gaussMinValue = 9999;

            for (int i = gaussDistributionMass.Count - numberOfDigits; i < gaussDistributionMass.Count; i++)
            {
                if (gaussDistributionMass[i] > gaussMaxValue)
                    gaussMaxValue = gaussDistributionMass[i];
                if (gaussDistributionMass[i] < gaussMinValue)
                    gaussMinValue = gaussDistributionMass[i];
            }

            uniformSelectSizeOfSteps = (uniformMaxValue - uniformMinValue) / numberOfSteps; // вычисление величины шага
            gaussSelectSizeOfSteps = (gaussMaxValue - gaussMinValue) / numberOfSteps;

            for (int i = gaussDistributionMass.Count - numberOfDigits; i < uniformDistributionMass.Count; i++)
            {                                                           // распределяем отсчеты по интервалам
                for (int j = 0; j < numberOfSteps; j++)
                    if (uniformDistributionMass[i] < (uniformMinValue + (uniformSelectSizeOfSteps * (j + 1))))
                    {
                        uniformSelectFrequencyMass[j] += 1;
                        break;
                    }

                for (int j = 0; j < numberOfSteps; j++)
                    if (gaussDistributionMass[i] < (gaussMinValue + (gaussSelectSizeOfSteps * (j + 1))))
                    {
                        gaussSelectFrequencyMass[j] += 1;
                        break;
                    }
            }
        }

        //==Функция вывода сгенерированного интервала чисел в виде графиков

        public void updateRandomGraphs()
        {
            if (uniformSelectRandPane == null)  //если объекты графики не проинициализированы, инициализием их
            {
                uniformSelectRandPane = uniformRandGraph.GraphPane;
                uniformSelectRandList = new PointPairList();

                gaussSelectRandPane = gaussRandGraph.GraphPane;
                gaussSelectRandList = new PointPairList();

                uniformSelectRandPane.XAxis.Title = "отс.";       //подпись графиков
                uniformSelectRandPane.YAxis.Title = "x1(t)";
                uniformSelectRandPane.Title = "Сигнал с равномерно распределенными значениями";

                gaussSelectRandPane.XAxis.Title = "отс.";
                gaussSelectRandPane.YAxis.Title = "x2(t)";
                gaussSelectRandPane.Title = "Сигнал с нормально распределенными значениями";
            }
            
            uniformSelectRandPane.CurveList.Clear();  // удаление старых значений
            gaussSelectRandPane.CurveList.Clear();
            uniformSelectRandList.Clear();
            gaussSelectRandList.Clear();

            int startPoints = uniformDistributionMass.Count - numberOfDigits;   //нахождение начала и конца текущей выборки
            int endPoints = uniformDistributionMass.Count;

            for (int x = startPoints; x < endPoints; x++)   //заполняем массивы точек полученными значениями
            {
                uniformSelectRandList.Add(x, uniformDistributionMass[x]);
                gaussSelectRandList.Add(x, gaussDistributionMass[x]);
            }

            if (modeNumber == 0)    //отображение сигнала в виде кривой
            {
                //добавление на палели отрисовки графиков
                LineItem uniformDistributionLine = uniformSelectRandPane.AddCurve("", uniformSelectRandList,
                                                                                              Color.SlateBlue, SymbolType.None);
                LineItem gaussDistributionLine = gaussSelectRandPane.AddCurve("", gaussSelectRandList,
                                                                                                 Color.SeaGreen, SymbolType.None);
                uniformDistributionLine.Line.Width = 2F;           //устанавка толщины линий
                gaussDistributionLine.Line.Width = 2F;

                uniformDistributionLine.Line.IsSmooth = true;    //установка сглаживания графика
                gaussDistributionLine.Line.IsSmooth = true;
            }
            else                            //отображение сигнала в виде отдельных отстчетов
            {

                LineItem uniformDistributionLine = uniformSelectRandPane.AddCurve("", uniformSelectRandList,
                                                                                              Color.Black, SymbolType.Circle);
                LineItem gaussDistributionLine = gaussSelectRandPane.AddCurve("", gaussSelectRandList,
                                                                                                 Color.Black, SymbolType.Circle);

                uniformDistributionLine.Line.IsVisible = false;             // скрываем линию
                gaussDistributionLine.Line.IsVisible = false;

                uniformDistributionLine.Symbol.Fill.IsVisible = true;     // показываем заливку маркера
                gaussDistributionLine.Symbol.Fill.IsVisible = true;

                uniformDistributionLine.Symbol.Fill.Type = FillType.Solid;  // устанавливаем тип заливки маркера
                gaussDistributionLine.Symbol.Fill.Type = FillType.Solid;

                uniformDistributionLine.Symbol.Fill.Color = Color.SlateBlue;    // цвет заливки маркера
                gaussDistributionLine.Symbol.Fill.Color = Color.SeaGreen;

                uniformDistributionLine.Symbol.Size = 30/trackBar1.Value+8;     // автоматическое масштабирвоание маркеров
                gaussDistributionLine.Symbol.Size = 30/trackBar1.Value+8;

                LineItem[] lines = new LineItem[numberOfDigits];        // рисуем пунктирные линии

                for (int i = startPoints; i < endPoints; i++)
                {
                    lines[i - startPoints] = uniformSelectRandPane.AddCurve("", new double[] { i, i }, new double[] { 0, uniformDistributionMass[i] }, Color.Gray, SymbolType.None);
                    lines[i - startPoints].Line.Style = System.Drawing.Drawing2D.DashStyle.Dash;
                }

                for (int i = startPoints; i < endPoints; i++)
                {
                    lines[i - startPoints] = gaussSelectRandPane.AddCurve("", new double[] { i, i }, new double[] { 0, gaussDistributionMass[i] }, Color.Gray, SymbolType.None);
                    lines[i - startPoints].Line.Style = System.Drawing.Drawing2D.DashStyle.Dash;
                }

            }

            uniformSelectRandPane.XAxis.Min = startPoints - 1;                  //установка границ обласи отображения графиков
            uniformSelectRandPane.XAxis.Max = endPoints + 1;
            uniformSelectRandPane.YAxis.Min = uniformDistributionMass.Min() + (uniformDistributionMass.Min()/5);
            uniformSelectRandPane.YAxis.Max = uniformDistributionMass.Max() + (uniformDistributionMass.Max()/5);

            gaussSelectRandPane.XAxis.Min = startPoints - 1;
            gaussSelectRandPane.XAxis.Max = endPoints + 1;
            gaussSelectRandPane.YAxis.Min = gaussDistributionMass.Min() + (gaussDistributionMass.Min() / 5);
            gaussSelectRandPane.YAxis.Max = gaussDistributionMass.Max() + (gaussDistributionMass.Max() / 5);

            uniformRandGraph.AxisChange();
            gaussRandGraph.AxisChange();

            uniformRandGraph.Invalidate();
            gaussRandGraph.Invalidate();
        }

        //==Функция обновления гистограмм с накоплением==//

        public void updateAllDistGraphs()
        {
            if (uniformAllDistPane == null)  //если объекты графики не проинициализированы, инициализием их
            {
                uniformAllDistPane = uniformAllDistGraph.GraphPane;
                uniformAllDistList = new PointPairList();

                gaussAllDistPane = gaussAllDistGraph.GraphPane;
                gaussAllDistList = new PointPairList();

                uniformAllDistPane.XAxis.Title = "относительная плотность частоты";       //подпись графиков
                uniformAllDistPane.YAxis.Title = "n";
                uniformAllDistPane.Title = "Гистограмма";

                gaussAllDistPane.XAxis.Title = "относительная плотность частоты";
                gaussAllDistPane.YAxis.Title = "n";
                gaussAllDistPane.Title = "Гистограмма";
            }

            uniformAllDistPane.CurveList.Clear();  // удаление старых значений
            gaussAllDistPane.CurveList.Clear();

            double[] barPositions = new double[numberOfSteps];      // расчет позиций столбцов диаграмм и точек теор. кривых

            for (int i = 0; i < numberOfSteps; i++)
            {
                barPositions[i] = i + 1;
            }

            //добавление на палели отрисовки графиков
            LineItem uniformTheoryFrequencyLine = uniformAllDistPane.AddCurve("", uniformTheoryAllFrequencyMass.ToArray(), barPositions, 
                                                                                          Color.Red, SymbolType.None);
            LineItem gaussTheoryFrequencyLine = gaussAllDistPane.AddCurve("", gaussTheoryAllFrequencyMass.ToArray(), barPositions, 
                                                                                             Color.Red, SymbolType.None);
            uniformTheoryFrequencyLine.Line.Width = 2F;           //устанавка толщины линий
            gaussTheoryFrequencyLine.Line.Width = 2F;

            uniformTheoryFrequencyLine.Line.IsSmooth = true;    //установка сглаживания графика
            gaussTheoryFrequencyLine.Line.IsSmooth = true;
            //


            double[] uniformBarLengths = new double[numberOfSteps]; //массив длин столбцов гистограмм
            double[] gaussBarLengths = new double[numberOfSteps];

            for (int i = 0; i < numberOfSteps; i++)     // расчет и добавление относительной плотности частоты
            {
                uniformBarLengths[i] = (uniformAllFrequencyMass[i]/uniformDistributionMass.Count) / uniformAllSizeOfSteps;
                gaussBarLengths[i] = (gaussAllFrequencyMass[i] / uniformDistributionMass.Count) / gaussAllSizeOfSteps;
            }

             // Добавление гистограмм

            BarItem uniformBar = uniformAllDistPane.AddBar("", uniformBarLengths, barPositions, Color.Gray);
            BarItem gaussBar = gaussAllDistPane.AddBar("", gaussBarLengths, barPositions, Color.Gray);

            uniformAllDistPane.BarBase = BarBase.Y;     // установка гистограмм вертикально
            gaussAllDistPane.BarBase = BarBase.Y;

            uniformAllDistPane.MinClusterGap = 0.0f;     // расстояние между столбцами
            gaussAllDistPane.MinClusterGap = 0.0f;

            uniformBar.Bar.Fill.Color = Color.SlateBlue;        // заливка гистограмм
            uniformBar.Bar.Fill.Type = FillType.GradientByX;

            gaussBar.Bar.Fill.Color = Color.SeaGreen;
            gaussBar.Bar.Fill.Type = FillType.GradientByX;

            uniformAllDistPane.YAxis.Min = 0;                    // выравнвание гистограмм
            uniformAllDistPane.YAxis.Max = numberOfSteps+1;

            gaussAllDistPane.YAxis.Min = 0;
            gaussAllDistPane.YAxis.Max = numberOfSteps+1;

            uniformAllDistGraph.AxisChange();
            gaussAllDistGraph.AxisChange();

            uniformAllDistGraph.Invalidate();
            gaussAllDistGraph.Invalidate();
        }

        //==Функция обновления гистограмм с накоплением==//

        public void updateSelectDistGraphs()
        {
            if (uniformSelectDistPane == null)  //если объекты графики не проинициализированы, инициализием их
            {
                uniformSelectDistPane = uniformSelectDistGraph.GraphPane;
                uniformSelectDistList = new PointPairList();

                gaussSelectDistPane = gaussSelectDistGraph.GraphPane;
                gaussSelectDistList = new PointPairList();

                uniformSelectDistPane.XAxis.Title = "относительная плотность частоты";       //подпись графиков
                uniformSelectDistPane.YAxis.Title = "n";
                uniformSelectDistPane.Title = "Гистограмма";

                gaussSelectDistPane.XAxis.Title = "относительная плотность частоты";
                gaussSelectDistPane.YAxis.Title = "n";
                gaussSelectDistPane.Title = "Гистограмма";
            }

            uniformSelectDistPane.CurveList.Clear();  // удаление старых значений
            gaussSelectDistPane.CurveList.Clear();

            double[] barPositions = new double[numberOfSteps];  // расчет позиций столбцов диаграмм и точек теор. кривых

            for (int i = 0; i < numberOfSteps; i++)
            {
                barPositions[i] = i + 1;
            }

            double[] uniformBarLengths = new double[numberOfSteps];
            double[] gaussBarLengths = new double[numberOfSteps];

            for (int i = 0; i < numberOfSteps; i++) // расчет и добавление относительной плотности частоты
            {
                uniformBarLengths[i] = (uniformSelectFrequencyMass[i]/numberOfDigits) / uniformSelectSizeOfSteps;
                gaussBarLengths[i] = (gaussSelectFrequencyMass[i]/numberOfDigits) / gaussSelectSizeOfSteps;
            }

            BarItem uniformBar = uniformSelectDistPane.AddBar("", uniformBarLengths, barPositions, Color.Gray);
            BarItem gaussBar = gaussSelectDistPane.AddBar("", gaussBarLengths, barPositions, Color.Gray);

            uniformSelectDistPane.BarBase = BarBase.Y;
            gaussSelectDistPane.BarBase = BarBase.Y;

            uniformSelectDistPane.MinClusterGap = 0.0f;
            gaussSelectDistPane.MinClusterGap = 0.0f;

            uniformBar.Bar.Fill.Color = Color.SlateBlue;
            uniformBar.Bar.Fill.Type = FillType.GradientByX;

            gaussBar.Bar.Fill.Color = Color.SeaGreen;
            gaussBar.Bar.Fill.Type = FillType.GradientByX;

            uniformSelectDistPane.YAxis.Min = 0;
            uniformSelectDistPane.YAxis.Max = numberOfSteps + 1;

            gaussSelectDistPane.YAxis.Min = 0;
            gaussSelectDistPane.YAxis.Max = numberOfSteps + 1;

            uniformSelectDistGraph.AxisChange();
            gaussSelectDistGraph.AxisChange();

            uniformSelectDistGraph.Invalidate();
            gaussSelectDistGraph.Invalidate();
        }

        //==Функция обработки событий регулировки масштаба графиков с отсчетами==//

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            numberOfDigits = this.trackBar1.Value * 10;     // регулировка от 10 до 100 текущих отсчетов
            updateRandomGraphs();   // вывод значений сигналов в виде графиков
            calculateAllFrequency();    // пересчет частот
            updateAllDistGraphs();     // обновление графиков частот
            calculateSelectFrequency();
            updateSelectDistGraphs();
            label4.Text = "Текущая реализация ( " + numberOfDigits.ToString() +" отсчетов)";
            label7.Text = "(по последним " + numberOfDigits.ToString() + " отсчетам)";
        }

        //==Функция обработки событий регулировки масштаба графиков с гистограммами==//

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            numberOfSteps = this.trackBar2.Value * 5;   // регулировка от 5 до 20 шагов
            updateRandomGraphs();   // вывод значений сигналов в виде графиков
            calculateAllFrequency();    // пересчет частот
            updateAllDistGraphs();     // обновление графиков частот
            calculateSelectFrequency();
            updateSelectDistGraphs();
        }

        //==Функция обработки события нажатия на кнопку генерации новых отсчетов==//

        private void button1_Click(object sender, EventArgs e)
        {
            newCalculateRandom();   // генерация начального интервала значений
            updateRandomGraphs();  // вывод значений сигналов в виде графиков
            calculateAllFrequency();   // пересчет частот
            updateAllDistGraphs();    // обновление графиков частот
            calculateSelectFrequency();
            updateSelectDistGraphs();
            label9.Text = "(для " + uniformDistributionMass.Count.ToString() + " отсчетов)";
        }

        //==Функция обработки события нажатия на переключатель режима отображения==//

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                radioButton2.Checked = false;
                modeNumber = 0;
                updateRandomGraphs();  // вывод значений сигналов в виде графиков
                updateAllDistGraphs();    // обновление графиков частот
                updateSelectDistGraphs();
            }
        }

        //==Функция обработки события нажатия на переключатель режима отображения==//

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                radioButton1.Checked = false;
                modeNumber = 1;
                updateRandomGraphs();  // вывод значений сигналов в виде графиков
                updateAllDistGraphs();    // обновление графиков частот
                updateSelectDistGraphs();
            }
        }

        //==Функция обработки события нажатия на кнопку выхода==//

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
