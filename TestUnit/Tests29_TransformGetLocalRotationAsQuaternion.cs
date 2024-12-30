using NUnit.Framework;

namespace Maths_Matrices.Tests
{
    [TestFixture]
    public class Tests29_TransformGetLocalRotationAsQuaternion
    {
        [Test, DefaultFloatingPointTolerance(0.01f)]
        public void TestTransformGetLocalRotationQuaternionDefault()
        {

            Transform t = new Transform();
            
            Quaternion q = t.LocalRotationQuaternion;
            Assert.That(q.x, Is.EqualTo(0f));
            Assert.That(q.y, Is.EqualTo(0f));
            Assert.That(q.z, Is.EqualTo(0f));
            Assert.That(q.w, Is.EqualTo(1f));

        }
        
        [Test, DefaultFloatingPointTolerance(0.001f)]
        public void TestTransformGetLocalRotationQuaternionXAxis()
        {
            
            Transform t = new Transform();
            t.LocalRotation = new Vector3(30f, 0f, 0f);
            
            Quaternion q = t.LocalRotationQuaternion;
            Assert.That(q.x, Is.EqualTo(0.259f));
            Assert.That(q.y, Is.EqualTo(0f));
            Assert.That(q.z, Is.EqualTo(0f));
            Assert.That(q.w, Is.EqualTo(0.966f));

        }
        
        [Test, DefaultFloatingPointTolerance(0.001f)]
        public void TestTransformGetLocalRotationQuaternionYAxis()
        {
            
            Transform t = new Transform();
            t.LocalRotation = new Vector3(0f, 30f, 0f);
            
            Quaternion q = t.LocalRotationQuaternion;
            Assert.That(q.x, Is.EqualTo(0f));
            Assert.That(q.y, Is.EqualTo(0.259f));
            Assert.That(q.z, Is.EqualTo(0f));
            Assert.That(q.w, Is.EqualTo(0.966f));

        }
        
        [Test, DefaultFloatingPointTolerance(0.001f)]
        public void TestTransformGetLocalRotationQuaternionZAxis()
        {
            
            Transform t = new Transform();
            t.LocalRotation = new Vector3(0f, 0f, 30f);
            
            Quaternion q = t.LocalRotationQuaternion;
            Assert.That(q.x, Is.EqualTo(0f));
            Assert.That(q.y, Is.EqualTo(0f));
            Assert.That(q.z, Is.EqualTo(0.259f));
            Assert.That(q.w, Is.EqualTo(0.966f));

        }
        
        [Test, DefaultFloatingPointTolerance(0.001f)]
        public void TestTransformGetLocalRotationQuaternionMultipleAxis()
        {
            
            Transform t = new Transform();
            t.LocalRotation = new Vector3(30f, 45f, 90f);
            
            Quaternion q = t.LocalRotationQuaternion;
            Assert.That(q.x, Is.EqualTo(0.430f));
            Assert.That(q.y, Is.EqualTo(0.092f));
            Assert.That(q.z, Is.EqualTo(0.561f));
            Assert.That(q.w, Is.EqualTo(0.701f));
            
       }
    }
}