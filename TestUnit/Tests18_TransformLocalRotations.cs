using NUnit.Framework;

namespace Maths_Matrices.Tests
{
    [TestFixture]
    public class Tests18_TransformLocalRotations
    {
        [Test, DefaultFloatingPointTolerance(0.001f)]
        public void TestDefaultValues()
        {
            
            Transform t = new Transform();
            
            //Default Rotation
            Assert.That(t.LocalRotation.x, Is.EqualTo(0f));
            Assert.That(t.LocalRotation.y, Is.EqualTo(0f));
            Assert.That(t.LocalRotation.z, Is.EqualTo(0f));

            //Default Matrices
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
                { 1f, 0f, 0f, 0f },
                { 0f, 1f, 0f, 0f },
                { 0f, 0f, 1f, 0f },
                { 0f, 0f, 0f, 1f },
            }));
            
            Assert.That(t.LocalRotationMatrix.ToArray2D(), Is.EqualTo(new[,]
            {
                { 1f, 0f, 0f, 0f },
                { 0f, 1f, 0f, 0f },
                { 0f, 0f, 1f, 0f },
                { 0f, 0f, 0f, 1f },
            }));
            
        }
        
        [Test, DefaultFloatingPointTolerance(0.001f)]
        public void TestChangeRotationXAxis()
        {
            
            Transform t = new Transform();
            
            t.LocalRotation = new Vector3(30f, 0f, 0f);
            Assert.That(t.LocalRotationXMatrix.ToArray2D(), Is.EqualTo(new[,]
            {
                { 1f, 0f, 0f, 0f },
                { 0f, 0.866f, -0.5f, 0f },
                { 0f, 0.5f, 0.866f, 0f },
                { 0f, 0f, 0f, 1f },
            }));
            
            Assert.That(t.LocalRotationMatrix.ToArray2D(), Is.EqualTo(new[,]
            {
                { 1f, 0f, 0f, 0f },
                { 0f, 0.866f, -0.5f, 0f },
                { 0f, 0.5f, 0.866f, 0f },
                { 0f, 0f, 0f, 1f },
            }));
            
        }
        
        [Test, DefaultFloatingPointTolerance(0.001f)]
        public void TestChangeRotationYAxis()
        {
            
            Transform t = new Transform();

            t.LocalRotation = new Vector3(0f, 30f, 0f);
            Assert.That(t.LocalRotationYMatrix.ToArray2D(), Is.EqualTo(new[,]
            {
                { 0.866f, 0f, 0.5f, 0f },
                { 0f, 1f, 0f, 0f },
                { -0.5f, 0f, 0.866f, 0f },
                { 0f, 0f, 0f, 1f },
            }));
            
            Assert.That(t.LocalRotationMatrix.ToArray2D(), Is.EqualTo(new[,]
            {
                { 0.866f, 0f, 0.5f, 0f },
                { 0f, 1f, 0f, 0f },
                { -0.5f, 0f, 0.866f, 0f },
                { 0f, 0f, 0f, 1f },
            }));
            
            
        }
        
        [Test, DefaultFloatingPointTolerance(0.001f)]
        public void TestChangeRotationZAxis()
        {
            
            Transform t = new Transform();

            t.LocalRotation = new Vector3(0f, 0f, 30f);
            Assert.That(t.LocalRotationZMatrix.ToArray2D(), Is.EqualTo(new[,]
            {
                { 0.866f, -0.5f, 0f, 0f },
                { 0.5f, 0.866f, 0f, 0f },
                { 0f, 0f, 1f, 0f },
                { 0f, 0f, 0f, 1f },
            }));
            
            Assert.That(t.LocalRotationMatrix.ToArray2D(), Is.EqualTo(new[,]
            {
                { 0.866f, -0.5f, 0f, 0f },
                { 0.5f, 0.866f, 0f, 0f },
                { 0f, 0f, 1f, 0f },
                { 0f, 0f, 0f, 1f },
            }));
            
        }
        
        [Test, DefaultFloatingPointTolerance(0.001f)]
        public void TestChangeRotationMultipleAxis()
        {
            
            Transform t = new Transform();
            
            //For LocalRotationMatrix attribute =>
            //Rotations are performed around the Z axis, the X axis, and the Y axis, in that order.
            //Like Unity => https://docs.unity3d.com/ScriptReference/Transform-eulerAngles.html
            //So the operation order is => RY * RX * RZ

            //Rotation to Multiple Axis
            t.LocalRotation = new Vector3(30f, 45f, 90f);
            Assert.That(t.LocalRotationMatrix.ToArray2D(), Is.EqualTo(new[,]
            {
                { 0.353f, -0.707f, 0.612f, 0f },
                { 0.866f, 0.000f, -0.500f, 0f },
                { 0.353f, 0.707f, 0.612f, 0f },
                { 0f, 0f, 0f, 1f },
            }));
            
        }
        
    }
}