using NUnit.Framework;

namespace Maths_Matrices.Tests
{
    [TestFixture]
    public class Tests26_QuaternionsPointRotation
    {
        [Test, DefaultFloatingPointTolerance(0.01f)]
        public void TestQuaternionPointRotation1()
        {

            Vector3 point = new Vector3(1f, 0f, 0f);
            Quaternion rotateZAxis = Quaternion.AngleAxis(90f, new Vector3(0f, 0f, 1f));

            Vector3 rotatedPoint = rotateZAxis * point;
            
            Assert.That(rotatedPoint.x, Is.EqualTo(0f));
            Assert.That(rotatedPoint.y, Is.EqualTo(1f));
            Assert.That(rotatedPoint.z, Is.EqualTo(0f));

        }
        
        [Test, DefaultFloatingPointTolerance(0.01f)]
        public void TestQuaternionPointRotation2()
        {

            Vector3 point = new Vector3(0f, 2f, 1f);
            Quaternion rotateXAxis = Quaternion.AngleAxis(45f, new Vector3(1f, 0f, 0f));

            Vector3 rotatedPoint = rotateXAxis * point;
            
            Assert.That(rotatedPoint.x, Is.EqualTo(0f));
            Assert.That(rotatedPoint.y, Is.EqualTo(0.71f));
            Assert.That(rotatedPoint.z, Is.EqualTo(2.12f));

        }
    }
}