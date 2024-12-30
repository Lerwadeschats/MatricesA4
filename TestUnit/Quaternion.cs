using Maths_Matrices.Tests;
using NUnit.Framework;

public struct Quaternion
{

    public float x;
    public float y;
    public float z;
    public float w;
    public MatrixFloat Matrix = MatrixFloat.Identity(4);

    public Vector3 EulerAngles
    {
        get => GetEulerAngles();
    }
    
    public Quaternion(float X = 0, float Y = 0, float Z = 0, float W = 0)
    {
        x = X;
        y = Y;
        z = Z;
        w = W;
    }

    public static Quaternion Identity = new Quaternion(0, 0, 0, 1);

    public static  Quaternion AngleAxis(float angle, Vector3 axis)
    {
        Vector3 normalizedAxis = axis.normalized;
        float angleRad = ((float)Math.PI/180) * angle;
        float X = normalizedAxis.x * (float)Math.Sin(angleRad / 2);
        float Y = normalizedAxis.y * (float)Math.Sin(angleRad / 2);
        float Z = normalizedAxis.z * (float)Math.Sin(angleRad / 2);
        float W = (float)Math.Cos(angleRad / 2);
        
        Quaternion result = new Quaternion(X, Y, Z, W);
        result.Matrix = Quaternion.GetQuaternionMatrix(result);

        return result;
    }

    public static Quaternion Multiply(Quaternion q1 , Quaternion q2)
    {
        Quaternion result = new Quaternion(0, 0, 0, 0);
        result.x = q1.w * q2.x + q1.x * q2.w + q1.y * q2.z - q1.z * q2.y;
        result.y = q1.w * q2.y + q1.y * q2.w + q1.z * q2.x - q1.x * q2.z;
        result.z = q1.w * q2.z + q1.z * q2.w + q1.x * q2.y - q1.y * q2.x;
        result.w = q1.w * q2.w - q1.x * q2.x - q1.y * q2.y - q1.z * q2.z;
        result.Matrix = Quaternion.GetQuaternionMatrix(result);
        return result;
    }
    
    public static Quaternion operator *(Quaternion q1, Quaternion q2)
    {
        return Quaternion.Multiply(q1, q2);
    }
    
    public static Vector3 Multiply(Quaternion q , Vector3 v)
    {
        
        Quaternion angleQuat = new Quaternion(v.x, v.y, v.z, 0);
        Quaternion quatConjugate = Quaternion.Conjugate(q);
        Quaternion result =  q * angleQuat * quatConjugate;
        return new Vector3(result.x, result.y, result.z);
    }
    
    public static Vector3 operator *(Vector3 v, Quaternion q)
    {
        return Quaternion.Multiply(q, v);
    }
    
    public static Vector3 operator *(Quaternion q, Vector3 v)
    {
        return Quaternion.Multiply(q, v);
    }

    public static Quaternion Conjugate(Quaternion q)
    {
        return new Quaternion(-q.x, -q.y, -q.z, q.w);
    }

    public static MatrixFloat GetQuaternionMatrix(Quaternion q)
    {
        float a0 = 1 - 2 * (q.y * q.y + q.z * q.z); //m11
            //2 * (q.w * q.w + q.x * q.x) - 1;
        float a1 = 2 * (q.x * q.y - q.w * q.z); //m21
        float a2 = 2 * (q.x * q.z + q.w * q.y); //m31
        
        float b0 = 2 * (q.x * q.y + q.w * q.z); //m12
        float b1 = 1 - 2 * (q.x * q.x + q.z * q.z); //m22
            //2 * (q.w * q.w + q.y * q.y) - 1;
        float b2 = 2 * (q.y * q.z - q.w * q.x); //m32
        
        float c0 = 2 * (q.x * q.z - q.w * q.y); //m13
        float c1 = 2 * (q.y * q.z + q.w * q.x); //m23
        float c2 = 1 - 2 * (q.x * q.x + q.y * q.y); //m33
            //2 * (q.w * q.w + q.z * q.z) - 1;
        
        MatrixFloat resultMatrix = new MatrixFloat(new float[,]
        {
            { a0, a1, a2, 0 },
            { b0, b1, b2, 0 },
            { c0, c1, c2, 0 },
            { 0, 0, 0, 1 }
        });
        return resultMatrix;
    }

    public static Quaternion Euler(float xRotation, float yRotation, float zRotation)
    {
        Quaternion yRotationQuat = Quaternion.AngleAxis(yRotation, new Vector3(0, 1, 0));
        Quaternion xRotationQuat = Quaternion.AngleAxis(xRotation, new Vector3(1, 0, 0));
        Quaternion zRotationQuat = Quaternion.AngleAxis(zRotation, new Vector3(0, 0, 1));
        Quaternion result = yRotationQuat * xRotationQuat * zRotationQuat;
        return result;
    }

    public Vector3 GetEulerAngles()
    {
        Matrix = GetQuaternionMatrix(this);
        
        //pitch = around X axis
        float pitch = MathF.Asin(-1 * Matrix[1, 2]);
        
        //yaw = heading = around Y axis
        float yaw = 0;
        if (MathF.Cos(pitch) == 0)
        {
            yaw = MathF.Atan2(-1 * Matrix[2, 0], Matrix[0, 0]);
        }
        else
        {
            yaw = MathF.Atan2(Matrix[0, 2], Matrix[2, 2]);
        }
        
        //roll = bank = around Z axis
        float roll = 0;
        if (MathF.Cos(pitch) != 0)
        {
            roll = MathF.Atan2(Matrix[1,0], Matrix[1,1]);
        }
        
        float rad2deg = 180f/MathF.PI;

        pitch *= rad2deg;
        yaw *= rad2deg;
        roll *= rad2deg;
        return new Vector3(pitch, yaw, roll);
    } 
}
