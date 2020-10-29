using System;

namespace INPTPZ1
{

    namespace Mathematics
    {
        public class ComplexNumber
        {
            public double RealPartOfNumber { get; set; }
            public double ImaginarPartOfNumber { get; set; }

            public override bool Equals(object objectForCheck)
            {
                if (objectForCheck is ComplexNumber)
                {
                    ComplexNumber complexNumber = objectForCheck as ComplexNumber;
                    return complexNumber.RealPartOfNumber == RealPartOfNumber && complexNumber.ImaginarPartOfNumber == ImaginarPartOfNumber;
                }
                return base.Equals(objectForCheck);
            }

            public static readonly ComplexNumber ComplexZero = new ComplexNumber()
            {
                RealPartOfNumber = 0,
                ImaginarPartOfNumber = 0
            };

            public ComplexNumber Multiply(ComplexNumber multlplicator)
            {
                ComplexNumber multiplier = this;

                return new ComplexNumber()
                {
                    RealPartOfNumber = multiplier.RealPartOfNumber * multlplicator.RealPartOfNumber - multiplier.ImaginarPartOfNumber * multlplicator.ImaginarPartOfNumber,
                    ImaginarPartOfNumber = (multiplier.RealPartOfNumber * multlplicator.ImaginarPartOfNumber + multiplier.ImaginarPartOfNumber * multlplicator.RealPartOfNumber)
                };
            }
            public double GetRoots()
            {
                return Math.Sqrt(RealPartOfNumber * RealPartOfNumber + ImaginarPartOfNumber * ImaginarPartOfNumber);
            }

            public ComplexNumber Add(ComplexNumber additionB)
            {
                ComplexNumber additionA = this;
                return new ComplexNumber()
                {
                    RealPartOfNumber = additionA.RealPartOfNumber + additionB.RealPartOfNumber,
                    ImaginarPartOfNumber = additionA.ImaginarPartOfNumber + additionB.ImaginarPartOfNumber
                };
            }
            public double GetAngleInDegrees()
            {
                return Math.Atan(ImaginarPartOfNumber / RealPartOfNumber);
            }
            public ComplexNumber Subtract(ComplexNumber subtrahend)
            {
                ComplexNumber minuend = this;
                return new ComplexNumber()
                {
                    RealPartOfNumber = minuend.RealPartOfNumber - subtrahend.RealPartOfNumber,
                    ImaginarPartOfNumber = minuend.ImaginarPartOfNumber - subtrahend.ImaginarPartOfNumber
                };
            }

            public override string ToString()
            {
                return $"({RealPartOfNumber} + {ImaginarPartOfNumber}i)";
            }

            internal ComplexNumber Divide(ComplexNumber divisor)
            {

                var dividendPart = this.Multiply(new ComplexNumber() { RealPartOfNumber = divisor.RealPartOfNumber, ImaginarPartOfNumber = -divisor.ImaginarPartOfNumber });
                var divisorPart = divisor.RealPartOfNumber * divisor.RealPartOfNumber + divisor.ImaginarPartOfNumber * divisor.ImaginarPartOfNumber;

                return new ComplexNumber()
                {
                    RealPartOfNumber = dividendPart.RealPartOfNumber / divisorPart,
                    ImaginarPartOfNumber = (dividendPart.ImaginarPartOfNumber / divisorPart)
                };
            }
        }
    }
}
