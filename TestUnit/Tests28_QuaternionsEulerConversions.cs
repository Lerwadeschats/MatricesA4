using NUnit.Framework;

namespace Maths_Matrices.Tests
{
    [TestFixture]
    public class Tests28_QuaternionsEulerConversions
    {
        [Test, DefaultFloatingPointTolerance(0.01f)]
        public void TestQuaternionFromEulerCustomAxis1()
        {
            
            //Quaternion Euler : Return the product of quaternions with the following order
            //qRY: Quaternion that rotates y degrees around y axis (0,1,0)
            //qRX: Quaternion that rotates x degrees around x axis (1,0,0)
            //qRZ: Quaternion that rotates z degrees around z axis (0,0,1)
            //So the final equation is => q = qRY * qRX * qRZ
            Quaternion q = Quaternion.Euler(30f, 45f, 90f);
            
            Assert.That(q.x, Is.EqualTo(0.430f));
            Assert.That(q.y, Is.EqualTo(0.092f));
            Assert.That(q.z, Is.EqualTo(0.561f));
            Assert.That(q.w, Is.EqualTo(0.701f));
            
        }

        [Test, DefaultFloatingPointTolerance(0.1f)]
        public void TestQuaternionToEulerCustomAxis1()
        {
            
            //You can use Quaternion Matrix to retrieve the euler angles
            //See this video for more info => https://youtu.be/vxPVw_EgyJI
            Quaternion q = new Quaternion(0.430f, 0.092f, 0.561f, 0.701f);
            Vector3 eulerAngles = q.EulerAngles;
            Assert.That(eulerAngles.x, Is.EqualTo(30f));
            Assert.That(eulerAngles.y, Is.EqualTo(45f));
            Assert.That(eulerAngles.z, Is.EqualTo(90f));
            
        }
        
        [Test, DefaultFloatingPointTolerance(0.01f)]
        public void TestQuaternionFromEulerCustomAxis2()
        {
            
            Quaternion q = Quaternion.Euler(45f, 0f, 90f);
            
            Assert.That(q.x, Is.EqualTo(0.271));
            Assert.That(q.y, Is.EqualTo(-0.271f));
            Assert.That(q.z, Is.EqualTo(0.653f));
            Assert.That(q.w, Is.EqualTo(0.653f));
            
        }
        
        [Test, DefaultFloatingPointTolerance(0.1f)]
        public void TestQuaternionToEulerCustomAxis2()
        {
            
            Quaternion q = new Quaternion(0.271f, -0.271f, 0.653f, 0.653f);
            Vector3 eulerAngles = q.EulerAngles;
            Assert.That(eulerAngles.x, Is.EqualTo(45f));
            Assert.That(eulerAngles.y, Is.EqualTo(0f));
            Assert.That(eulerAngles.z, Is.EqualTo(90f));
            
        }
    }
}