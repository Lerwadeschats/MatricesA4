using NUnit.Framework;

namespace Maths_Matrices.Tests
{
    [TestFixture]
    public class Tests05_MatricesAddAndSubtract
    {
        [Test]
        public void TestSumMatricesInstances()
        {
            MatrixInt m1 = new MatrixInt(new[,]
            {
                { 1, 7 },
                { 8, 5 },
                { 4, 17 }
            });

            MatrixInt m2 = new MatrixInt(new[,]
            {
                { 65, 4 },
                { 3, 1 },
                { 48, 2 }
            });

            m1.Add(m2);

            Assert.That(m1.ToArray2D(), Is.EqualTo(new[,]
            {
                { 66, 11 },
                { 11, 6 },
                { 52, 19 },
            }));
            
            Assert.That(m2.ToArray2D(), Is.EqualTo(new[,]
            {
                { 65, 4 },
                { 3, 1 },
                { 48, 2 }
            }));
        }
        
        [Test]
        public void TestSumMatricesStatic()
        {
            MatrixInt m1 = new MatrixInt(new[,]
            {
                { 1, 7 },
                { 8, 5 },
                { 4, 17 }
            });

            MatrixInt m2 = new MatrixInt(new[,]
            {
                { 65, 4 },
                { 3, 1 },
                { 48, 2 }
            });

            MatrixInt m3 = MatrixInt.Add(m1, m2);
            
            Assert.That(m3.ToArray2D(), Is.EqualTo(new[,]
            {
                { 66, 11 },
                { 11, 6 },
                { 52, 19 },
            }));
            
            Assert.That(m1.ToArray2D(), Is.EqualTo(new[,]
            {
                { 1, 7 },
                { 8, 5 },
                { 4, 17 }
            }));
            
            Assert.That(m2.ToArray2D(), Is.EqualTo(new[,]
            {
                { 65, 4 },
                { 3, 1 },
                { 48, 2 }
            }));
        }
        
        [Test]
        public void TestSumMatricesOperator()
        {
            MatrixInt m1 = new MatrixInt(new[,]
            {
                { 1, 7 },
                { 8, 5 },
                { 4, 17 }
            });

            MatrixInt m2 = new MatrixInt(new[,]
            {
                { 65, 4 },
                { 3, 1 },
                { 48, 2 }
            });

            MatrixInt m3 = m1 + m2;
            
            Assert.That(m3.ToArray2D(), Is.EqualTo(new[,]
            {
                { 66, 11 },
                { 11, 6 },
                { 52, 19 },
            }));
            
            Assert.That(m1.ToArray2D(), Is.EqualTo(new[,]
            {
                { 1, 7 },
                { 8, 5 },
                { 4, 17 }
            }));
            
            Assert.That(m2.ToArray2D(), Is.EqualTo(new[,]
            {
                { 65, 4 },
                { 3, 1 },
                { 48, 2 }
            }));
        }

        [Test]
        public void TestSubtractMatricesOperator()
        {
            MatrixInt m1 = new MatrixInt(new[,]
            {
                { 1, 62 },
                { 17, 2 },
                { 3, 5 },
            });

            MatrixInt m2 = new MatrixInt(new[,]
            {
                {-3, 51},
                {9, 1},
                {4, 18},
            });

            MatrixInt m3 = m1 - m2;
            
            Assert.That(m3.ToArray2D(), Is.EqualTo(new[,]
            {
                { 4, 11 },
                { 8, 1 },
                { -1, -13 },
            }));
        }
        
        [Test]
        public void TestImpossibleSumMatrices()
        {
            MatrixInt m1 = new MatrixInt(new[,]
            {
                { 3, 4 },
                { 8, 5 },
            });

            MatrixInt m2 = new MatrixInt(new[,]
            {
                { 1, 7 },
                { 7, 4 },
                { 2, 0 },
            });
            
            //Add Methods need to throw exception if size are different
            //See Exception Documentation =>
            //https://docs.microsoft.com/fr-fr/dotnet/csharp/fundamentals/exceptions/
            //https://docs.microsoft.com/fr-fr/dotnet/api/system.exception?view=net-6.0
            
            Assert.Throws<MatrixSumException>(() =>
            {
                m1.Add(m2);
            });
            
            Assert.Throws<MatrixSumException>(() =>
            {
                MatrixInt.Add(m1, m2);
            });
            
            Assert.Throws<MatrixSumException>(() =>
            {
                MatrixInt m3 = m1 + m2;
            });
        }
    }
}