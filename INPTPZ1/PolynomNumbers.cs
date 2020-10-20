using System.Collections.Generic;

namespace INPTPZ1
{

    namespace Mathematics
    {
        class PolynomNumbers
        {
            public List<ComplexNumber> ListOfComplexNumber { get; set; }

            public PolynomNumbers() => ListOfComplexNumber = new List<ComplexNumber>();

            public PolynomNumbers Derive()
            {
                PolynomNumbers newPolynomNumber = new PolynomNumbers();
                for (int i = 1; i < ListOfComplexNumber.Count; i++)
                {
                    newPolynomNumber.ListOfComplexNumber.Add(ListOfComplexNumber[i].Multiply(new ComplexNumber() { RealPartOfNumber = i }));
                }

                return newPolynomNumber;
            }

            public ComplexNumber Eval(ComplexNumber number)
            {
                ComplexNumber newNumber = ComplexNumber.ComplexZero;
                for (int i = 0; i < ListOfComplexNumber.Count; i++)
                {
                    ComplexNumber multiplier = ListOfComplexNumber[i];
                    ComplexNumber multlplicator = number;
                    int power = i;

                    if (i > 0)
                    {
                        for (int j = 0; j < power - 1; j++)
                            multlplicator = multlplicator.Multiply(number);

                        multiplier = multiplier.Multiply(multlplicator);
                    }

                    newNumber = newNumber.Add(multiplier);
                }

                return newNumber;
            }

            public override string ToString()
            {
                string outputString = "";
                for (int i = 0; i < ListOfComplexNumber.Count; i++)
                {
                    outputString += ListOfComplexNumber[i];
                    if (i > 0)
                    {
                        for (int j = 0; j < i; j++)
                        {
                            outputString += "x";
                        }
                    }
                    outputString += " + ";
                }
                return outputString;
            }
        }
    }
}
