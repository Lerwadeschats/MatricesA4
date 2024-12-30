using NUnit.Framework;

namespace Maths_Matrices.Tests
{
    [TestFixture]
    public class Tests01NewMatrices
    {
        [Test]
        public void TestNewEmptyMatrices()
        {
            MatrixInt m1 = new MatrixInt(3, 2);
            Assert.That(m1.ToArray2D(), Is.EqualTo(new[,]
            {
                { 0, 0 },
                { 0, 0 },
                { 0, 0 }
            }));
            Assert.That(m1.NbLines, Is.EqualTo(3));
            Assert.That(m1.NbColumns, Is.EqualTo(2));

            MatrixInt m2 = new MatrixInt(2, 3);
            Assert.That(m2.ToArray2D(), Is.EqualTo(new[,]
            {
                { 0, 0, 0 },
                { 0, 0, 0 },
            }));
            Assert.That(m2.NbLines, Is.EqualTo(2));
            Assert.That(m2.NbColumns, Is.EqualTo(3));
        }

        [Test]
        public void TestNewMatricesFrom2DArray()
        {
            //See GetLength documentation to retrieve length of a multi-dimensional array
            //https://docs.microsoft.com/en-us/dotnet/api/system.array.getlength
            MatrixInt m = new MatrixInt(new[,]
                {
                    { 1, 2, 3 },
                    { 4, 5, 6 },
                    { 7, 8, 9 },
                }
            );
            Assert.That(m.NbLines, Is.EqualTo(3));
            Assert.That(m.NbColumns, Is.EqualTo(3));

            //See Indexers Documentation =>
            //https://docs.microsoft.com/fr-fr/dotnet/csharp/programming-guide/indexers/
            Assert.That(m[0, 0], Is.EqualTo(1));
            Assert.That(m[0, 1], Is.EqualTo(2));
            Assert.That(m[0, 2], Is.EqualTo(3));
            Assert.That(m[1, 0], Is.EqualTo(4));
            Assert.That(m[1, 1], Is.EqualTo(5));
            Assert.That(m[1, 2], Is.EqualTo(6));
            Assert.That(m[2, 0], Is.EqualTo(7));
            Assert.That(m[2, 1], Is.EqualTo(8));
            Assert.That(m[2, 2], Is.EqualTo(9));
        }
    }
}