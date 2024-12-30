using NUnit.Framework;

namespace Maths_Matrices.Tests
{
    [TestFixture]
    public class Tests23_NewQuaternions
    {
        [Test]
        public void TestNewQuaternion()
        {
            Quaternion q = new Quaternion(0f, 0.71f, 0f, 0.71f);
            Assert.That(q.x, Is.EqualTo(0f));
            Assert.That(q.y, Is.EqualTo(0.71f));
            Assert.That(q.z, Is.EqualTo(0f));
            Assert.That(q.w, Is.EqualTo(0.71f));
        }
        
        [Test]
        public void TestNewQuaternionFromAnother()
        {
            Quaternion q1 = new Quaternion(0f, 0.71f, 0f, 0.71f);
            Quaternion q2 = q1;
            q2.x = 0.71f;

            Assert.That(q2.x, Is.EqualTo(0.71f));
            Assert.That(q2.y, Is.EqualTo(0.71f));
            Assert.That(q2.z, Is.EqualTo(0f));
            Assert.That(q2.w, Is.EqualTo(0.71f));
            
            Assert.That(q1.x, Is.EqualTo(0f));
            Assert.That(q1.y, Is.EqualTo(0.71f));
            Assert.That(q1.z, Is.EqualTo(0f));
            Assert.That(q1.w, Is.EqualTo(0.71f));
        }
        
        [Test]
        public void TestQuaternionIdentity()
        {
            //An identity quantity is a quaternion with no rotation
            Quaternion q = Quaternion.Identity;
            Assert.That(q.x, Is.EqualTo(0f));
            Assert.That(q.y, Is.EqualTo(0f));
            Assert.That(q.z, Is.EqualTo(0f));
            Assert.That(q.w, Is.EqualTo(1f));
        }
    }
}