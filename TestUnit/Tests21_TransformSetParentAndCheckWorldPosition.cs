using NUnit.Framework;

namespace Maths_Matrices.Tests
{
    [TestFixture]
    public class Tests21_TransformSetParentAndCheckWorldPosition
    {
        [Test, DefaultFloatingPointTolerance(0.001f)]
        public void TestParentChangePosition()
        {
            
            Transform tParent = new Transform();
            tParent.LocalPosition = new Vector3(10f, 5f, 2f);

            Transform tChild = new Transform();
            tChild.SetParent(tParent);
        
            Assert.That(tParent.LocalToWorldMatrix.ToArray2D(), Is.EqualTo(new[,]
            {
                { 1f, 0f, 0f, 10f },
                { 0f, 1f, 0f, 5f },
                { 0f, 0f, 1f, 2f },
                { 0f, 0f, 0f, 1f },
            }));

            Assert.That(tParent.WorldPosition.x, Is.EqualTo(10f));
            Assert.That(tParent.WorldPosition.y, Is.EqualTo(5f));
            Assert.That(tParent.WorldPosition.z, Is.EqualTo(2f));
            
            Assert.That(tChild.LocalToWorldMatrix.ToArray2D(), Is.EqualTo(new[,]
            {
                { 1f, 0f, 0f, 10f },
                { 0f, 1f, 0f, 5f },
                { 0f, 0f, 1f, 2f },
                { 0f, 0f, 0f, 1f },
            }));

            Assert.That(tChild.WorldPosition.x, Is.EqualTo(10f));
            Assert.That(tChild.WorldPosition.y, Is.EqualTo(5f));
            Assert.That(tChild.WorldPosition.z, Is.EqualTo(2f));
            
        }
        
        [Test, DefaultFloatingPointTolerance(0.001f)]
        public void TestDoubleParentChangePosition()
        {

            //tRoot (10,5,2)
            //  -> tParent (1,4,42) => (11,9,44)
            //      -> tChild (1,2,3) => (12,11,47)
            
            Transform tRoot = new Transform();
            tRoot.LocalPosition = new Vector3(10f, 5f, 2f);

            Transform tParent = new Transform();
            tParent.LocalPosition = new Vector3(1f, 4f, 42f);
            tParent.SetParent(tRoot);

            Transform tChild = new Transform();
            tChild.LocalPosition = new Vector3(-1f, 2f, 3f);
            tChild.SetParent(tParent);
            
            //Check tParent Matrix and World Position
            Assert.That(tParent.LocalToWorldMatrix.ToArray2D(), Is.EqualTo(new[,]
            {
                { 1f, 0f, 0f, 11f },
                { 0f, 1f, 0f, 9f },
                { 0f, 0f, 1f, 44f },
                { 0f, 0f, 0f, 1f },
            }));
            
            Assert.That(tParent.WorldPosition.x, Is.EqualTo(11f));
            Assert.That(tParent.WorldPosition.y, Is.EqualTo(9f));
            Assert.That(tParent.WorldPosition.z, Is.EqualTo(44f));
        
            //Check tChild Matrix and World Position
            Assert.That(tChild.LocalToWorldMatrix.ToArray2D(), Is.EqualTo(new[,]
            {
                { 1f, 0f, 0f, 10f },
                { 0f, 1f, 0f, 11f },
                { 0f, 0f, 1f, 47f },
                { 0f, 0f, 0f, 1f },
            }));
            
            Assert.That(tChild.WorldPosition.x, Is.EqualTo(10f));
            Assert.That(tChild.WorldPosition.y, Is.EqualTo(11f));
            Assert.That(tChild.WorldPosition.z, Is.EqualTo(47f));
            
        }

        [Test, DefaultFloatingPointTolerance(0.001f)]
        public void TestParentChangePositionAndRotation()
        {
            
            Transform tParent = new Transform();
            tParent.LocalPosition = new Vector3(10f, 5f, 2f);
            tParent.LocalRotation = new Vector3(0f, 0f, 45f);

            Transform tChild = new Transform();
            tChild.LocalPosition = new Vector3(1f, 0f, 0f);
            tChild.SetParent(tParent);
        
            Assert.That(tChild.LocalToWorldMatrix.ToArray2D(), Is.EqualTo(new[,]
            {
                { 0.707f, -0.707f, 0.000f, 10.707f },
                { 0.707f, 0.707f, 0.000f, 5.707f },
                { 0.000f, 0.000f, 1.000f, 2.000f },
                { 0.000f, 0.000f, 0.000f, 1.000f },
            }));

            Assert.That(tChild.WorldPosition.x, Is.EqualTo(10.707f));
            Assert.That(tChild.WorldPosition.y, Is.EqualTo(5.707f));
            Assert.That(tChild.WorldPosition.z, Is.EqualTo(2f));
        }
        
        [Test, DefaultFloatingPointTolerance(0.001f)]
        public void TestParentChangePositionAndScale()
        {
 
            
            Transform tParent = new Transform();
            tParent.LocalPosition = new Vector3(100f, 0f, -20f);
            tParent.LocalScale = new Vector3(2f, 4f, 6f);

            Transform tChild = new Transform();
            tChild.LocalPosition = new Vector3(1f, 1f, 1f);
            tChild.SetParent(tParent);
        
            Assert.That(tChild.LocalToWorldMatrix.ToArray2D(), Is.EqualTo(new[,]
            {
                { 2f, 0f, 0f, 102f },
                { 0f, 4f, 0f, 4f },
                { 0f, 0f, 6f, -14f },
                { 0f, 0f, 0f, 1f },
            }));

            Assert.That(tChild.WorldPosition.x, Is.EqualTo(102f));
            Assert.That(tChild.WorldPosition.y, Is.EqualTo(4f));
            Assert.That(tChild.WorldPosition.z, Is.EqualTo(-14f));
            
        }
    }
}
