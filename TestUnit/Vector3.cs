using System.Runtime.CompilerServices;
using NUnit.Framework;

public class Vector3
{
    
    public float x;
    public float y;
    public float z;

    public float[] vector;
    
    
    public Vector3(float xValue, float yValue, float zValue)
    {
        x = xValue;
        y = yValue;
        z = zValue;
        vector = new float[]
        {
            xValue, yValue, zValue
        };
    }
    
    public float this[int row]
    {
        get { return vector[row]; }
        set { vector[row] = value; }
    }
    
    public Vector3 Multiply(MatrixFloat matrix)
    {
        float X = x * matrix[0,0] + y * matrix[0,1] + z * matrix[0,2];
        float Y = x * matrix[1,0] + y * matrix[1,1] + z * matrix[1,2];
        float Z = x * matrix[2,0] + y * matrix[2,1] + z * matrix[2,2];
        Vector3 tempVector = new Vector3(X, Y, Z);
        return tempVector;
    }

    public static Vector3 operator *(MatrixFloat matrix, Vector3 vector)
    {
        return vector.Multiply(matrix);
    }
    
    public static Vector3 operator *(Vector3 vector, MatrixFloat matrix)
    {
        return vector.Multiply(matrix);
    }

    public Vector3 Add(Vector3 _vector)
    {
        float X = x + _vector.x;
        float Y = y + _vector.y;
        float Z = z + _vector.z;
        Vector3 tempVector = new Vector3(X, Y, Z);
        return tempVector;
    }

    public static Vector3 operator +(Vector3 vector1, Vector3 vector2)
    {
        return vector1.Add(vector2);
    }
    
    public Vector3 Substract(Vector3 _vector)
    {
        float X = x - _vector.x;
        float Y = y - _vector.y;
        float Z = z - _vector.z;
        Vector3 tempVector = new Vector3(X, Y, Z);
        return tempVector;
    }

    public static Vector3 operator -(Vector3 vector1, Vector3 vector2)
    {
        return vector1.Substract(vector2);
    }

    public Vector3 DotProduct(Vector3 _vector)
    {
        float X = x * _vector.x;
        float Y = y * _vector.y;
        float Z = z * _vector.z;
        return new Vector3(X, Y, Z);
    }
    
    public static Vector3 operator *(Vector3 vector1, Vector3 vector2)
    {
        return vector1.DotProduct(vector2);
    }

    public Vector3 normalized
    {
        get => Normalize(this);
    }

    public static Vector3 Normalize(Vector3 vector)
    {
        Vector3 normalizedVector = new Vector3(vector.x / vector.magnitude,vector.y / vector.magnitude,vector.z / vector.magnitude);
        return normalizedVector;
    }

    public float magnitude
    {
        get => GetMagnitude(this);
    }

    public static float GetMagnitude(Vector3 vector)
    {
        float vectorMagnitude = (float)Math.Sqrt((vector.x * vector.x) + (vector.y * vector.y) + (vector.z * vector.z));
        return vectorMagnitude;
    }
}