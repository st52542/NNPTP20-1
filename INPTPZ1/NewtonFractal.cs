using System;
using System.Collections.Generic;
using System.Drawing;
using INPTPZ1.Mathematics;

namespace INPTPZ1
{
    class NewtonFractal
    {
        private const double NEWCOMPLEXZERO = 0.0001;
        private const double TOLERANCE = 0.5;
        private static int bitmapWidht, bitmapHeight;
        private static string output;
        private static Bitmap bitmap;
        private static double xMinimum, xMaximum, yMinimum, yMaximum, xStep, yStep;
        private static List<ComplexNumber> roots;
        private static PolynomNumbers listOfPolynomNumbers, derivedPolynomNumber;
        private static Color[] colors;

        static void Main(string[] args)
        {
            Variables(args);
            listOfPolynomNumbers.ListOfComplexNumber.Add(new ComplexNumber() { RealPartOfNumber = 1 });
            listOfPolynomNumbers.ListOfComplexNumber.Add(ComplexNumber.ComplexZero);
            listOfPolynomNumbers.ListOfComplexNumber.Add(ComplexNumber.ComplexZero);
            listOfPolynomNumbers.ListOfComplexNumber.Add(new ComplexNumber() { RealPartOfNumber = 1 });
            derivedPolynomNumber = listOfPolynomNumbers.Derive();

            Console.WriteLine(listOfPolynomNumbers);
            Console.WriteLine(derivedPolynomNumber);

            for (int i = 0; i < bitmapWidht; i++)
            {
                for (int j = 0; j < bitmapHeight; j++)
                {
                    double numberImaginarPart = yMinimum + i * yStep;
                    double numberRealPart = xMinimum + j * xStep;

                    ComplexNumber newComplexNumber = new ComplexNumber()
                    {
                        RealPartOfNumber = numberRealPart,
                        ImaginarPartOfNumber = numberImaginarPart
                    };

                    if (newComplexNumber.RealPartOfNumber == 0)
                        newComplexNumber.RealPartOfNumber = NEWCOMPLEXZERO;
                    if (newComplexNumber.ImaginarPartOfNumber == 0)
                        newComplexNumber.ImaginarPartOfNumber = NEWCOMPLEXZERO;

                    int iteration = 0;

                    NewtonIteration(iteration, newComplexNumber, listOfPolynomNumbers, derivedPolynomNumber);

                    var id = 0;
                    FindRootNumbers(newComplexNumber, id);

                    var color = colors[id % colors.Length];
                    color = Color.FromArgb(color.R, color.G, color.B);
                    color = Color.FromArgb(Math.Min(Math.Max(0, color.R - (int)iteration * 2), 255), Math.Min(Math.Max(0, color.G - (int)iteration * 2), 255), Math.Min(Math.Max(0, color.B - (int)iteration * 2), 255));
                    bitmap.SetPixel(j, i, color);
                }
            }
            bitmap.Save(output ?? "../../../out.png");
        }

        private static void Variables(string[] args)
        {
            bitmapWidht = int.Parse(args[0]);
            bitmapHeight = int.Parse(args[1]);
            output = args[6];
            bitmap = new Bitmap(bitmapWidht, bitmapHeight);
            xMinimum = double.Parse(args[2]);
            xMaximum = double.Parse(args[3]);
            yMinimum = double.Parse(args[4]);
            yMaximum = double.Parse(args[5]);
            xStep = (xMaximum - xMinimum) / bitmapWidht;
            yStep = (yMaximum - yMinimum) / bitmapHeight;
            roots = new List<ComplexNumber>();
            listOfPolynomNumbers = new PolynomNumbers();
            colors = new Color[]
            {
                Color.Red, Color.Blue, Color.Green, Color.Yellow, Color.Orange, Color.Fuchsia, Color.Gold, Color.Cyan, Color.Magenta
            };
        }

        private static void NewtonIteration(int iteration, ComplexNumber newComplexNumber, PolynomNumbers listOfPolynomNumbers, PolynomNumbers derivedPolynomNumber)
        {
            for (int i = 0; i < 30; i++)
            {
                var diferents = listOfPolynomNumbers.Eval(newComplexNumber).Divide(derivedPolynomNumber.Eval(newComplexNumber));
                newComplexNumber = newComplexNumber.Subtract(diferents);

                if (Math.Pow(diferents.RealPartOfNumber, 2) + Math.Pow(diferents.ImaginarPartOfNumber, 2) >= TOLERANCE)
                {
                    i--;
                }
                iteration++;
            }
        }

        private static void FindRootNumbers(ComplexNumber newComplexNumber, int id)
        {
            bool known = false;
            int maxid = 0;
            for (int i = 0; i < roots.Count; i++)
            {
                if (Math.Pow(newComplexNumber.RealPartOfNumber - roots[i].RealPartOfNumber, 2) + Math.Pow(newComplexNumber.ImaginarPartOfNumber - roots[i].ImaginarPartOfNumber, 2) <= 0.01)
                {
                    known = true;
                    id = i;
                }
            }
            if (!known)
            {
                roots.Add(newComplexNumber);
                id = roots.Count;
                maxid = id + 1;
            }
        }
    }

}
