using NUnit.Framework;

namespace Maths_Matrices.Tests
{
    [TestFixture]
    public class Tests04_ScalarMultiplication
    {
        [Test]
        public void TestScalarMultiplicationInstance()
        {
            MatrixInt m = new MatrixInt(new[,]
            {
                { 1, 2, 3 },
                { 4, 5, 6 },
                { 7, 8, 9 }
            });

            m.Multiply(2);

            Assert.That(m.ToArray2D(), Is.EqualTo(new[,]
            {
                { 2, 4, 6 },
                { 8, 10, 12 },
                { 14, 16, 18 },
            }));
        }

        [Test]
        public void TestScalarMultiplicationStatic()
        {
            MatrixInt m = new MatrixInt(new[,]
            {
                { 0, 0, 0 },
                { 0, 5, 0 },
                { 0, 0, 0 }
            });

            MatrixInt m2 = MatrixInt.Multiply(m, 5);

            Assert.That(m2.ToArray2D(), Is.EqualTo(new[,]
            {
                { 0, 0, 0 },
                { 0, 25, 0 },
                { 0, 0, 0 },
            }));

            Assert.That(m.ToArray2D(), Is.EqualTo(new[,]
            {
                { 0, 0, 0 },
                { 0, 5, 0 },
                { 0, 0, 0 },
            }));
        }

        [Test]
        public void TestScalarMultiplicationOperator()
        {
            MatrixInt m = new MatrixInt(new[,]
            {
                { 1, 2, 3 },
                { 4, 5, 6 },
                { 7, 8, 9 }
            });

            //See Operator overloading documentation =>
            //https://docs.microsoft.com/fr-fr/dotnet/csharp/language-reference/operators/operator-overloading
            MatrixInt m2 = m * 2;

            Assert.That(m2.ToArray2D(), Is.EqualTo(new[,]
            {
                { 2, 4, 6 },
                { 8, 10, 12 },
                { 14, 16, 18 },
            }));

            Assert.That(m.ToArray2D(), Is.EqualTo(new[,]
            {
                { 1, 2, 3 },
                { 4, 5, 6 },
                { 7, 8, 9 }
            }));

            MatrixInt m4 = 4 * m;
            
            Assert.That(m4.ToArray2D(), Is.EqualTo(new[,]
            {
                { 4, 8, 12 },
                { 16, 20, 24 },
                { 28, 32, 36 },
            }));
        }

        [Test]
        public void TestNegativeMatrix()
        {
            MatrixInt m1 = new MatrixInt(new int[,]
            {
                { -1, 2, 3 },
                { 4, -5, 6 },
                { -7, 8, 9 }
            });

            MatrixInt m2 = -m1;
            
            Assert.That(m2.ToArray2D(), Is.EqualTo(new[,]
            {
                { 1, -2, -3 },
                { -4, 5, -6 },
                { 7, -8, -9 }
            }));
        }
    }
}