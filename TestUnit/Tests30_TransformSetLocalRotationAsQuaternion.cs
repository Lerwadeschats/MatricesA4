using NUnit.Framework;

namespace Maths_Matrices.Tests
{
    [TestFixture]
    public class Tests30_TransformSetLocalRotationAsQuaternion
    {
        [Test, DefaultFloatingPointTolerance(0.1f)]
        public void TestTransformSetLocalRotationQuaternionXAxis()
        {
            
            Transform t = new Transform();
            t.LocalRotationQuaternion = new Quaternion(0.259f, 0f, 0f, 0.966f);

            Vector3 localRotation = t.LocalRotation;
            Assert.That(localRotation.x, Is.EqualTo(30f));
            Assert.That(localRotation.y, Is.EqualTo(0f));
            Assert.That(localRotation.z, Is.EqualTo(0f));
            
            Assert.That(t.LocalRotationMatrix.ToArray2D(), Is.EqualTo(new[,]
            {
                { 1f, 0f, 0f, 0f },
                { 0f, 0.866f, -0.5f, 0f },
                { 0f, 0.5f, 0.866f, 0f },
                { 0f, 0f, 0f, 1f },
            }));
            
            Assert.That(t.LocalRotationXMatrix.ToArray2D(), Is.EqualTo(new[,]
            {
                { 1f, 0f, 0f, 0f },
                { 0f, 0.866f, -0.5f, 0f },
                { 0f, 0.5f, 0.866f, 0f },
                { 0f, 0f, 0f, 1f },
            }));
            
            Assert.That(t.LocalRotationYMatrix.ToArray2D(), Is.EqualTo(new[,]
            {
                { 1f, 0f, 0f, 0f },
                { 0f, 1f, 0f, 0f },
                { 0f, 0f, 1f, 0f },
                { 0f, 0f, 0f, 1f },
            }));
            
            Assert.That(t.LocalRotationZMatrix.ToArray2D(), Is.EqualTo(new[,]
            {
                { 1f, 0f, 0f, 0f },
                { 0f, 1f, 0f, 0f },
                { 0f, 0f, 1f, 0f },
                { 0f, 0f, 0f, 1f },
            }));

        }
        
        [Test, DefaultFloatingPointTolerance(0.1f)]
        public void TestTransformSetLocalRotationQuaternionYAxis()
        {
            
            Transform t = new Transform();
            t.LocalRotationQuaternion = new Quaternion(0f, 0.259f, 0f, 0.966f);

            Vector3 localRotation = t.LocalRotation;
            Assert.That(localRotation.x, Is.EqualTo(0f));
            Assert.That(localRotation.y, Is.EqualTo(30f));
            Assert.That(localRotation.z, Is.EqualTo(0f));
            
            Assert.That(t.LocalRotationMatrix.ToArray2D(), Is.EqualTo(new[,]
            {
                { 0.866f, 0f, 0.5f, 0f },
                { 0f, 1f, 0f, 0f },
                { -0.5f, 0f, 0.866f, 0f },
                { 0f, 0f, 0f, 1f },
            }));
            
            Assert.That(t.LocalRotationXMatrix.ToArray2D(), Is.EqualTo(new[,]
            {
                { 1f, 0f, 0f, 0f },
                { 0f, 1f, 0f, 0f },
                { 0f, 0f, 1f, 0f },
                { 0f, 0f, 0f, 1f },
            }));
            
            Assert.That(t.LocalRotationYMatrix.ToArray2D(), Is.EqualTo(new[,]
            {
                { 0.866f, 0f, 0.5f, 0f },
                { 0f, 1f, 0f, 0f },
                { -0.5f, 0f, 0.866f, 0f },
                { 0f, 0f, 0f, 1f },
            }));
            
            Assert.That(t.LocalRotationZMatrix.ToArray2D(), Is.EqualTo(new[,]
            {
                { 1f, 0f, 0f, 0f },
                { 0f, 1f, 0f, 0f },
                { 0f, 0f, 1f, 0f },
                { 0f, 0f, 0f, 1f },
            }));

        }
        
        [Test, DefaultFloatingPointTolerance(0.1f)]
        public void TestTransformSetLocalRotationQuaternionZAxis()
        {
            
            Transform t = new Transform();
            t.LocalRotationQuaternion = new Quaternion(0f, 0f, 0.259f, 0.966f);

            Vector3 localRotation = t.LocalRotation;
            Assert.That(localRotation.x, Is.EqualTo(0f));
            Assert.That(localRotation.y, Is.EqualTo(0f));
            Assert.That(localRotation.z, Is.EqualTo(30f));
            
            Assert.That(t.LocalRotationMatrix.ToArray2D(), Is.EqualTo(new[,]
            {
                { 0.866f, -0.5f, 0f, 0f },
                { 0.5f, 0.866f, 0f, 0f },
                { 0f, 0f, 1f, 0f },
                { 0f, 0f, 0f, 1f },
            }));
            
            Assert.That(t.LocalRotationXMatrix.ToArray2D(), Is.EqualTo(new[,]
            {
                { 1f, 0f, 0f, 0f },
                { 0f, 1f, 0f, 0f },
                { 0f, 0f, 1f, 0f },
                { 0f, 0f, 0f, 1f },
            }));
            
            Assert.That(t.LocalRotationYMatrix.ToArray2D(), Is.EqualTo(new[,]
            {
                { 1f, 0f, 0f, 0f },
                { 0f, 1f, 0f, 0f },
                { 0f, 0f, 1f, 0f },
                { 0f, 0f, 0f, 1f },
            }));
            
            Assert.That(t.LocalRotationZMatrix.ToArray2D(), Is.EqualTo(new[,]
            {
                { 0.866f, -0.5f, 0f, 0f },
                { 0.5f, 0.866f, 0f, 0f },
                { 0f, 0f, 1f, 0f },
                { 0f, 0f, 0f, 1f },
            }));

        }
        
        [Test, DefaultFloatingPointTolerance(0.1f)]
        public void TestTransformSetLocalRotationQuaternionMultipleAxis()
        {
            
            Transform t = new Transform();
            t.LocalRotationQuaternion = new Quaternion(0.430f, 0.092f, 0.561f, 0.701f);
            
            Vector3 localRotation = t.LocalRotation;
            Assert.That(localRotation.x, Is.EqualTo(30f));
            Assert.That(localRotation.y, Is.EqualTo(45f));
            Assert.That(localRotation.z, Is.EqualTo(90f));

            Assert.That(t.LocalRotationMatrix.ToArray2D(), Is.EqualTo(new[,]
            {
                { 0.353f, -0.707f, 0.612f, 0f },
                { 0.866f, 0.000f, -0.500f, 0f },
                { 0.353f, 0.707f, 0.612f, 0f },
                { 0f, 0f, 0f, 1f },
            }));
            
            Assert.That(t.LocalRotationXMatrix.ToArray2D(), Is.EqualTo(new[,]
            {
                { 1f, 0f, 0f, 0f },
                { 0f, 0.866f, -0.5f, 0f },
                { 0f, 0.5f, 0.866f, 0f },
                { 0f, 0f, 0f, 1f },
            }));
            
            Assert.That(t.LocalRotationYMatrix.ToArray2D(), Is.EqualTo(new[,]
            {
                { 0.707f, 0f, 0.707f, 0f },
                { 0f, 1f, 0f, 0f },
                { -0.707f, 0f, 0.707f, 0f },
                { 0f, 0f, 0f, 1f },
            }));
            
            Assert.That(t.LocalRotationZMatrix.ToArray2D(), Is.EqualTo(new[,]
            {
                { 0f, -1f, 0f, 0f },
                { 1f, 0f, 0f, 0f },
                { 0f, 0f, 1f, 0f },
                { 0f, 0f, 0f, 1f },
            }));
            
        }
    }
}