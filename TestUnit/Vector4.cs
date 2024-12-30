using NUnit.Framework;

public class Vector4
{
    
    public float x;
    public float y;
    public float z;
    public float w;

    public float[] vector;
    
    
    public Vector4(float xValue, float yValue, float zValue, float wValue)
    {
        x = xValue;
        y = yValue;
        z = zValue;
        w = wValue;
        vector = new float[]
        {
            xValue, yValue, zValue, wValue
        };
    }
    
    public float this[int row]
    {
        get { return vector[row]; }
        set { vector[row] = value; }
    }
    
    public Vector4 Multiply(MatrixFloat matrix)
    {
        float X = x * matrix[0,0] + y * matrix[0,1] + z * matrix[0,2] + w * matrix[0,3];
        float Y = x * matrix[1,0] + y * matrix[1,1] + z * matrix[1,2] + w * matrix[1,3];
        float Z = x * matrix[2,0] + y * matrix[2,1] + z * matrix[2,2] + w * matrix[2,3];
        float W = x * matrix[3,0] + y * matrix[3,1] + z * matrix[3,2] + w * matrix[3,3];
        Vector4 tempVector = new Vector4(X, Y, Z, W);
        return tempVector;
    }

    public static Vector4 operator *(MatrixFloat matrix, Vector4 vector)
    {
        return vector.Multiply(matrix);
    }
        

}