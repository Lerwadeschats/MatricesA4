using NUnit.Framework;

namespace Maths_Matrices.Tests
{
    [TestFixture]
    public class Tests22_TransformChangeWorldPosition
    {
        [Test, DefaultFloatingPointTolerance(0.001f)]
        public void TestChangeWorldPosition()
        {

            Transform t = new Transform();
            t.WorldPosition = new Vector3(100f, 1f, 42f);

            Assert.That(t.LocalToWorldMatrix.ToArray2D(), Is.EqualTo(new[,]
            {
                { 1f, 0f, 0f, 100f },
                { 0f, 1f, 0f, 1f },
                { 0f, 0f, 1f, 42f },
                { 0f, 0f, 0f, 1f },
            }));

            Assert.That(t.LocalPosition.x, Is.EqualTo(100f));
            Assert.That(t.LocalPosition.y, Is.EqualTo(1f));
            Assert.That(t.LocalPosition.z, Is.EqualTo(42f));
            
        }

        [Test, DefaultFloatingPointTolerance(0.001f)]
        public void TestChangeWorldPositionInsideParent()
        {

            Transform tParent = new Transform();
            tParent.LocalPosition = new Vector3(100f, 1f, 42f);

            Transform tChild = new Transform();
            tChild.SetParent(tParent);
            tChild.WorldPosition = new Vector3(0f, 0f, 0f);

            Assert.That(tChild.LocalToWorldMatrix.ToArray2D(), Is.EqualTo(new[,]
            {
                { 1f, 0f, 0f, 0f },
                { 0f, 1f, 0f, 0f },
                { 0f, 0f, 1f, 0f },
                { 0f, 0f, 0f, 1f },
            }));

            Assert.That(tChild.LocalPosition.x, Is.EqualTo(-100f));
            Assert.That(tChild.LocalPosition.y, Is.EqualTo(-1f));
            Assert.That(tChild.LocalPosition.z, Is.EqualTo(-42f));
            
        }

        [Test, DefaultFloatingPointTolerance(0.001f)]
        public void TestChangeWorldPositionInsideParentWithRotation()
        {

            Transform tParent = new Transform();
            tParent.LocalPosition = new Vector3(20f, 0f, 0f);
            tParent.LocalRotation = new Vector3(0f, 0f, 45f);

            Transform tChild = new Transform();
            tChild.SetParent(tParent);
            tChild.WorldPosition = new Vector3(0f, 0f, 0f);

            Assert.That(tChild.LocalToWorldMatrix.ToArray2D(), Is.EqualTo(new[,]
            {
                { 0.707f, -0.707f, 0f, 0f },
                { 0.707f, 0.707f, 0f, 0f },
                { 0f, 0f, 1f, 0f },
                { 0f, 0f, 0f, 1f },
            }));

            Assert.That(tChild.LocalPosition.x, Is.EqualTo(-14.142f));
            Assert.That(tChild.LocalPosition.y, Is.EqualTo(14.142f));
            Assert.That(tChild.LocalPosition.z, Is.EqualTo(0f));
            
        }

        [Test, DefaultFloatingPointTolerance(0.001f)]
        public void TestChangeWorldPositionInsideParentWithScale()
        {

            Transform tParent = new Transform();
            tParent.LocalPosition = new Vector3(200, -10f, 9f);
            tParent.LocalScale = new Vector3(2f, 4f, 6f);

            Transform tChild = new Transform();
            tChild.SetParent(tParent);
            tChild.WorldPosition = new Vector3(0f, 0f, 0f);

            Assert.That(tChild.LocalToWorldMatrix.ToArray2D(), Is.EqualTo(new[,]
            {
                { 2f, 0f, 0f, 0f },
                { 0f, 4f, 0f, 0f },
                { 0f, 0f, 6f, 0f },
                { 0f, 0f, 0f, 1f },
            }));

            Assert.That(tChild.LocalPosition.x, Is.EqualTo(-100f));
            Assert.That(tChild.LocalPosition.y, Is.EqualTo(2.5f));
            Assert.That(tChild.LocalPosition.z, Is.EqualTo(-1.5f));
            
        }
    }
}