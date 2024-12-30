using NUnit.Framework;

namespace Maths_Matrices.Tests
{
    [TestFixture]
    public class Tests19_TransformLocalScale
    {
        [Test, DefaultFloatingPointTolerance(0.001f)]
        public void TestDefaultValues()
        {
            
            
            Transform t = new Transform();

            //Default Scale
            Assert.That(t.LocalScale.x, Is.EqualTo(1f));
            Assert.That(t.LocalScale.y, Is.EqualTo(1f));
            Assert.That(t.LocalScale.z, Is.EqualTo(1f));
            
            //Default Matrix
            Assert.That(t.LocalScaleMatrix.ToArray2D(), Is.EqualTo(new[,]
            {
                { 1f, 0f, 0f, 0f },
                { 0f, 1f, 0f, 0f },
                { 0f, 0f, 1f, 0f },
                { 0f, 0f, 0f, 1f },
            }));
            
            
        }

        [Test, DefaultFloatingPointTolerance(0.001f)]
        public void TestChangeScale()
        {
            
            
            Transform t = new Transform();

            //Scale X
            t.LocalScale = new Vector3(2f, 1f, 1f);
            Assert.That(t.LocalScaleMatrix.ToArray2D(), Is.EqualTo(new[,]
            {
                { 2f, 0f, 0f, 0f },
                { 0f, 1f, 0f, 0f },
                { 0f, 0f, 1f, 0f },
                { 0f, 0f, 0f, 1f },
            }));
            
            //Scale Y
            t.LocalScale = new Vector3(1f, 5f, 1f);
            Assert.That(t.LocalScaleMatrix.ToArray2D(), Is.EqualTo(new[,]
            {
                { 1f, 0f, 0f, 0f },
                { 0f, 5f, 0f, 0f },
                { 0f, 0f, 1f, 0f },
                { 0f, 0f, 0f, 1f },
            }));
            
            //Scale Z
            t.LocalScale = new Vector3(1f, 1f, 23f);
            Assert.That(t.LocalScaleMatrix.ToArray2D(), Is.EqualTo(new[,]
            {
                { 1f, 0f, 0f, 0f },
                { 0f, 1f, 0f, 0f },
                { 0f, 0f, 23f, 0f },
                { 0f, 0f, 0f, 1f },
            }));
            
            
        }
    }
}