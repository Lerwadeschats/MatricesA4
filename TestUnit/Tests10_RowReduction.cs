using NUnit.Framework;

namespace Maths_Matrices.Tests
{
    [TestFixture]
    public class Tests10_RowReduction
    {
        [Test, DefaultFloatingPointTolerance(0.001f)]
        public void TestApplyRowReduction_CourseExample()
        {
            MatrixFloat m1 = new MatrixFloat(new[,]
            {
                { 3f, 2f, -3f },
                { 4f, -3f, 6f },
                { 1f, 0f, -1f }
            });

            MatrixFloat m2 = new MatrixFloat(new[,]
            {
                { -13f },
                { 7f },
                { -5f }
            });

            //This method use deconstruction tuple system
            //More information here =>
            //https://docs.microsoft.com/fr-fr/dotnet/csharp/fundamentals/functional/deconstruct
            (m1, m2) = MatrixRowReductionAlgorithm.Apply(m1, m2);
            Assert.That(m1.ToArray2D(), Is.EqualTo(new[,]
            {
                { 1f, 0f, 0f },
                { 0f, 1f, 0f },
                { 0f, 0f, 1f }
            }));

            Assert.That(m2.ToArray2D(), Is.EqualTo(new[,]
            {
                { -2f },
                { 1f },
                { 3f }
            }));
        }

        [Test, DefaultFloatingPointTolerance(0.001f)]
        public void TestApplyRowReduction_Exercise()
        {
            MatrixFloat m1 = new MatrixFloat(new[,]
            {
                { 2f, 1f, 3f },
                { 0f, 1f, -1f },
                { 1f, 3f, -1f }
            });

            MatrixFloat m2 = new MatrixFloat(new[,]
            {
                { 0f },
                { 0f },
                { 0f }
            });

            //This method use deconstruction tuple system
            //More information here =>
            //https://docs.microsoft.com/fr-fr/dotnet/csharp/fundamentals/functional/deconstruct
            (m1, m2) = MatrixRowReductionAlgorithm.Apply(m1, m2);
            Assert.That(m1.ToArray2D(), Is.EqualTo(new[,]
            {
                { 1f, 0f, 2f },
                { 0f, 1f, -1f },
                { 0f, 0f, 0f }
            }));

            Assert.That(m2.ToArray2D(), Is.EqualTo(new[,]
            {
                { 0f },
                { 0f },
                { 0f }
            }));
        }
    }
}