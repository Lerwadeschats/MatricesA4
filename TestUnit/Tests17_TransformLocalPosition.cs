using NUnit.Framework;

namespace Maths_Matrices.Tests
{
    [TestFixture]
    public class Tests17_TransformLocalPosition
    {
        [Test, DefaultFloatingPointTolerance(0.001f)]
        public void TestDefaultValues()
        {
            
            
            Transform t = new Transform();
            
            //Default Position
            Assert.That(t.LocalPosition.x, Is.EqualTo(0f));
            Assert.That(t.LocalPosition.y, Is.EqualTo(0f));
            Assert.That(t.LocalPosition.z, Is.EqualTo(0f));

            //Default Translation Matrix
            Assert.That(t.LocalTranslationMatrix.ToArray2D(), Is.EqualTo(new[,]
            {
                { 1f, 0f, 0f, 0f },
                { 0f, 1f, 0f, 0f },
                { 0f, 0f, 1f, 0f },
                { 0f, 0f, 0f, 1f },
            }));
            
            
        }
        
        [Test, DefaultFloatingPointTolerance(0.001f)]
        public void TestTransformChangePosition()
        {

            Transform t = new Transform();
            
            //Translation
            t.LocalPosition = new Vector3(5f, 2f, 1f);
            Assert.That(t.LocalTranslationMatrix.ToArray2D(), Is.EqualTo(new[,]
            {
                { 1f, 0f, 0f, 5f },
                { 0f, 1f, 0f, 2f },
                { 0f, 0f, 1f, 1f },
                { 0f, 0f, 0f, 1f },
            }));
        }
        
    }
}