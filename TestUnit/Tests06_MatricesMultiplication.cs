using NUnit.Framework;

namespace Maths_Matrices.Tests
{
    [TestFixture]
    public class Tests06_MatricesMultiplication
    {
        [Test]
        public void TestMatricesMultiplicationInstance()
        {
            MatrixInt m1 = new MatrixInt(new[,]
            {
                { 1, 2 },
                { 7, 10 },
                { 4, 5 },
                { 3, 1 }
            });

            MatrixInt m2 = new MatrixInt(new[,]
            {
                { 4, 4, 2, 2, 7 },
                { 1, 7, 1, 2, 0 }
            });

            MatrixInt m3 = m1.Multiply(m2);

            Assert.That(m3.ToArray2D(), Is.EqualTo(new[,]
            {
                { 6, 18, 4, 6, 7 },
                { 38, 98, 24, 34, 49 },
                { 21, 51, 13, 18, 28 },
                { 13, 19, 7, 8, 21 },
            }));
        }
        
        [Test]
        public void TestMatricesMultiplicationStatic()
        {
            MatrixInt m1 = new MatrixInt(new[,]
            {
                { 1, 4 },
                { 2, 1 },
                { 7, 5 }
            });

            MatrixInt m2 = new MatrixInt(new[,]
            {
                { 4, 3, 5 },
                { 1, 2, 1 }
            });

            MatrixInt m3 = MatrixInt.Multiply(m1, m2);

            Assert.That(m3.ToArray2D(), Is.EqualTo(new[,]
            {
                { 8, 11, 9 },
                { 9, 8, 11 },
                { 33, 31, 40 }
            }));
        }
        
        [Test]
        public void TestMatricesMultiplicationOperator()
        {
            MatrixInt m1 = new MatrixInt(new[,]
            {
                { 1, 4 },
                { 2, 2 },
                { 7, 6 },
                { 23, 1 },
            });

            MatrixInt m2 = new MatrixInt(new[,]
            {
                { 8, 5, 2 },
                { 3, 1, 2 }
            });

            MatrixInt m3 = m1 * m2;

            Assert.That(m3.ToArray2D(), Is.EqualTo(new[,]
            {
                { 20, 9, 10 },
                { 22, 12, 8 },
                { 74, 41, 26 },
                { 187, 116, 48 }
            }));
        }
        
        [Test]
        public void TestImpossibleMultiplication()
        {
            MatrixInt m1 = new MatrixInt(new[,]
            {
                { 1, 2 },
                { 3, 4 }
            });

            MatrixInt m2 = new MatrixInt(new[,]
            {
                { 0, 1, 5, 9 },
                { 7, 4, 20, 36 },
                { 2, 0, 87, 1 },
                { 0, 0, 0, 1 },
                { 2, 4, 6, 8 }
            });
            
            //Multiply Methods is possible only if m1.NbColumns and m2.NbLines are equals
            //Throw Exception instead
            //See Exception Documentation =>
            //https://docs.microsoft.com/fr-fr/dotnet/csharp/fundamentals/exceptions/
            //https://docs.microsoft.com/fr-fr/dotnet/api/system.exception?view=net-6.0
            
            Assert.Throws<MatrixMultiplyException>(() =>
            {
                m1.Multiply(m2);
            });
            
            Assert.Throws<MatrixMultiplyException>(() =>
            {
                MatrixInt.Multiply(m1, m2);
            });
            
            Assert.Throws<MatrixMultiplyException>(() =>
            {
                MatrixInt m3 = m1 * m2;
            });
        }
    }
}