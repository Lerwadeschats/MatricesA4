using NUnit.Framework;

namespace Maths_Matrices.Tests
{
    [TestFixture]
    public class Tests27_QuaternionsMatrix
    {
        [Test, DefaultFloatingPointTolerance(0.01f)]
        public void TestQuaternionMatrixXAxis()
        {

            Quaternion q = Quaternion.AngleAxis(30f, new Vector3(1f, 0f, 0f));
            
            Assert.That(q.Matrix.ToArray2D(), Is.EqualTo(new[,]
            {
                { 1f, 0f, 0f, 0f },
                { 0f, 0.866f, -0.5f, 0f },
                { 0f, 0.5f, 0.866f, 0f },
                { 0f, 0f, 0f, 1f },
            }));

        }
        
        [Test, DefaultFloatingPointTolerance(0.01f)]
        public void TestQuaternionMatrixYAxis()
        {

            Quaternion q = Quaternion.AngleAxis(30f, new Vector3(0f, 1f, 0f));
            
            Assert.That(q.Matrix.ToArray2D(), Is.EqualTo(new[,]
            {
                { 0.866f, 0f, 0.5f, 0f },
                { 0f, 1f, 0f, 0f },
                { -0.5f, 0f, 0.866f, 0f },
                { 0f, 0f, 0f, 1f },
            }));

        }
        
        [Test, DefaultFloatingPointTolerance(0.01f)]
        public void TestQuaternionMatrixZAxis()
        {

            Quaternion q = Quaternion.AngleAxis(30f, new Vector3(0f, 0f, 1f));
            
            Assert.That(q.Matrix.ToArray2D(), Is.EqualTo(new[,]
            {
                { 0.866f, -0.5f, 0f, 0f },
                { 0.5f, 0.866f, 0f, 0f },
                { 0f, 0f, 1f, 0f },
                { 0f, 0f, 0f, 1f },
            }));

        }
        
        [Test, DefaultFloatingPointTolerance(0.01f)]
        public void TestQuaternionMatrixMultipleAxis()
        {

            Quaternion rotationXAxis = Quaternion.AngleAxis(30f, new Vector3(1f, 0f, 0f));
            Quaternion rotationYAxis = Quaternion.AngleAxis(90f, new Vector3(0f, 1f, 0f));

            Quaternion result = rotationXAxis * rotationYAxis;
            Assert.That(result.Matrix.ToArray2D(), Is.EqualTo(new[,]
            {
                { 0f, 0f, 1f, 0f },
                { 0.5f, 0.866f, 0f, 0f },
                { -0.866f, 0.5f, 0f, 0f },
                { 0f, 0f, 0f, 1f },
            }));

            Quaternion invertedResult = rotationYAxis * rotationXAxis;
            Assert.That(invertedResult.Matrix.ToArray2D(), Is.EqualTo(new[,]
            {
                { 0f, 0.5f, 0.866f, 0f },
                { 0f, 0.866f, -0.5f, 0f },
                { -1f, 0f, 0f, 0f },
                { 0f, 0f, 0f, 1f },
            }));

        }
        
        [Test, DefaultFloatingPointTolerance(0.01f)]
        public void TestQuaternionMatrixIdentity()
        {

            Quaternion q = Quaternion.Identity;
            
            Assert.That(q.Matrix.ToArray2D(), Is.EqualTo(new[,]
            {
                { 1f, 0f, 0f, 0f },
                { 0f, 1f, 0f, 0f },
                { 0f, 0f, 1f, 0f },
                { 0f, 0f, 0f, 1f },
            }));

        }

    }
}