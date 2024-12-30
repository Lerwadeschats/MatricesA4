using Maths_Matrices.Tests;
using NUnit.Framework;

public class Transform
{

    public Vector3 LocalPosition
    {
        get => _localPosition;
        set
        {
            _localPosition = value;
            UpdateLocalPositionMatrix();
        }
    }

    public Vector3 LocalRotation
    {
        get => _localRotation;
        set
        {
            _localRotation = value;
            _localRotationQuaternion = Quaternion.Euler(_localRotation.x, _localRotation.y, _localRotation.z);
            UpdateLocalRotationMatrix();
        }
    }
    public Vector3 LocalScale
    {
        get => _localScale;
        set
        {
            _oldScale = _localScale;
            
            _localScale = value;
            UpdateLocalScaleMatrix();
        }
    }

    public Quaternion LocalRotationQuaternion
    {
        get => _localRotationQuaternion;
        set
        {
            _localRotationQuaternion = value;
            _localRotation = _localRotationQuaternion.EulerAngles;
            UpdateLocalRotationMatrix();
        } 
    }

    private Vector3 _localPosition = new Vector3(0, 0, 0);
    private Vector3 _localRotation = new Vector3(0, 0, 0);
    private Vector3 _localScale = new Vector3(1, 1, 1);
    private Vector3 _oldScale = new Vector3(1, 1, 1);
    private Vector3 _worldPosition = new Vector3(0, 0, 0);
    private Vector3 _worldRotation = new Vector3(0, 0, 0);
    private Vector3 _worldScale = new Vector3(1, 1, 1);
    private Vector3 _oldWorldScale = new Vector3(1, 1, 1);
    public Transform parent = null;
    
    public Quaternion _localRotationQuaternion = new Quaternion(0, 0, 0, 1);
    
    public Transform()
    {
        LocalPosition = new Vector3(0, 0, 0);
        LocalRotation = new Vector3(0, 0, 0);
        LocalScale = new Vector3(1, 1, 1);
        WorldPosition = LocalPosition;
        WorldRotation = LocalRotation;
        WorldScale = LocalScale;
    }

    //Local Transform Matrix
    public MatrixFloat LocalTranslationMatrix = MatrixFloat.Identity(4);

    public MatrixFloat LocalRotationXMatrix = MatrixFloat.Identity(4);
    public MatrixFloat LocalRotationYMatrix = MatrixFloat.Identity(4);
    public MatrixFloat LocalRotationZMatrix = MatrixFloat.Identity(4);
    public MatrixFloat LocalRotationMatrix = MatrixFloat.Identity(4);

    public MatrixFloat LocalScaleMatrix = MatrixFloat.Identity(4);
    
    //World Transform Matrix
    public MatrixFloat WorldTranslationMatrix = MatrixFloat.Identity(4);

    public MatrixFloat WorldRotationXMatrix = MatrixFloat.Identity(4);
    public MatrixFloat WorldRotationYMatrix = MatrixFloat.Identity(4);
    public MatrixFloat WorldRotationZMatrix = MatrixFloat.Identity(4);
    public MatrixFloat WorldRotationMatrix = MatrixFloat.Identity(4);

    public MatrixFloat WorldScaleMatrix = MatrixFloat.Identity(4);
    
    

    public MatrixFloat LocalToWorldMatrix = MatrixFloat.Identity(4);
    public MatrixFloat WorldToLocalMatrix = MatrixFloat.Identity(4);


    public Vector3 WorldPosition
    {
        get => _worldPosition;
        set
        {
            _worldPosition = value;
            if (parent != null)
            {
                _localPosition = _worldPosition - (parent.LocalPosition * parent.WorldToLocalMatrix);
            }
            else
            {
                _localPosition = _worldPosition;
            }
            
            UpdateWorldPosition();
        }
    }

    public Vector3 WorldRotation
    {
        get => _worldRotation;
        set
        {
            _worldRotation = value;
            UpdateWorldRotation();
        }
    }

    public Vector3 WorldScale
    {
        get => _worldScale;
        set
        {
            
            _oldWorldScale = _worldScale;
            _worldScale = value;
            UpdateWorldScale();
        }
    } 
    public void SetParent(Transform _parent)
    {
        LocalToWorldMatrix = _parent.LocalToWorldMatrix * LocalToWorldMatrix;
        parent = _parent;
        UpdateWorldTransform();
    }
    
    
    
    void UpdateLocalPositionMatrix()
    {
        LocalTranslationMatrix = new MatrixFloat(new float[,]
        {
            { 1f, 0f, 0f, LocalPosition.x },
            { 0f, 1f, 0f, LocalPosition.y },
            { 0f, 0f, 1f, LocalPosition.z },
            { 0f, 0f, 0f, 1f },
        });
        UpdateWorldTransform();
        UpdateLocalWorldMatrix();
    }
    
    void UpdateLocalRotationMatrix()
    {
        LocalRotationXMatrix = new MatrixFloat(new float[,]
        {
            { 1f, 0f, 0f, 0 },
            { 0f, (float)Math.Cos((Math.PI / 180) * LocalRotation.x), -1 * (float)Math.Sin((Math.PI / 180) * LocalRotation.x), 0 },
            { 0f, (float)Math.Sin((Math.PI / 180) * LocalRotation.x), (float)Math.Cos((Math.PI / 180) * LocalRotation.x), 0 },
            { 0f, 0f, 0f, 1f },
        });
        
        LocalRotationYMatrix = new MatrixFloat(new float[,]
        {
            { (float)Math.Cos((Math.PI / 180) * LocalRotation.y), 0f, (float)Math.Sin((Math.PI / 180) * LocalRotation.y), 0 },
            { 0f, 1f, 0f, 0 },
            { -1 * (float)Math.Sin((Math.PI / 180) * LocalRotation.y), 0f, (float)Math.Cos((Math.PI / 180) * LocalRotation.y), 0 },
            { 0f, 0f, 0f, 1f },
        }); 
            
        LocalRotationZMatrix = new MatrixFloat(new float[,]
        {
            { (float)Math.Cos((Math.PI / 180) * LocalRotation.z), -1 * (float)Math.Sin((Math.PI / 180) * LocalRotation.z), 0f, 0 },
            { (float)Math.Sin((Math.PI / 180) * LocalRotation.z), (float)Math.Cos((Math.PI / 180) * LocalRotation.z), 0f, 0 },
            { 0f, 0f, 1f, 0 },
            { 0f, 0f, 0f, 1f },
        });
        
        LocalRotationMatrix = (LocalRotationYMatrix * LocalRotationXMatrix * LocalRotationZMatrix);
        UpdateWorldTransform();
        UpdateLocalWorldMatrix();
    }
    
    void UpdateLocalScaleMatrix()
    {
        MatrixFloatElementaryOperations.MultiplyLine(LocalScaleMatrix, 0,  LocalScale.x / _oldScale.x);
        MatrixFloatElementaryOperations.MultiplyLine(LocalScaleMatrix, 1,  LocalScale.y / _oldScale.y);
        MatrixFloatElementaryOperations.MultiplyLine(LocalScaleMatrix, 2,  LocalScale.z / _oldScale.z);
        UpdateWorldTransform();
        UpdateLocalWorldMatrix();
    }

    void UpdateLocalWorldMatrix()
    {
        LocalToWorldMatrix = (WorldTranslationMatrix * WorldRotationMatrix * WorldScaleMatrix);
        
        WorldToLocalMatrix = LocalToWorldMatrix.InvertByDeterminant();
        


    }


    void UpdateWorldTransform()
    {
        UpdateWorldScale();
        UpdateWorldRotation();
        UpdateWorldPosition();
        if (parent != null)
        {
            WorldScale = LocalScale * parent.WorldScale;
            WorldRotation = LocalRotation + parent.WorldRotation;
            WorldPosition = LocalPosition * WorldRotationMatrix * WorldScale + parent.WorldPosition;
        }
        else
        {
            WorldScale = LocalScale;
            WorldRotation = LocalRotation;
            WorldPosition = LocalPosition;
        }
        
        UpdateLocalWorldMatrix();

    }
    
    void UpdateWorldRotation()
    {
        
        WorldRotationXMatrix = new MatrixFloat(new float[,]
        {
            { 1f, 0f, 0f, 0 },
            { 0f, (float)Math.Cos((Math.PI / 180f) * WorldRotation.x ), -1 * (float)Math.Sin((Math.PI / 180f) * WorldRotation.x), 0 },
            { 0f, (float)Math.Sin((Math.PI / 180f) * WorldRotation.x), (float)Math.Cos((Math.PI / 180f) * WorldRotation.x), 0 },
            { 0f, 0f, 0f, 1f },
        });
        
        WorldRotationYMatrix = new MatrixFloat(new float[,]
        {
            { (float)Math.Cos((Math.PI / 180f) * WorldRotation.y), 0f, (float)Math.Sin((Math.PI / 180f) * WorldRotation.y), 0 },
            { 0f, 1f, 0f, 0 },
            { -1 * (float)Math.Sin((Math.PI / 180f) * WorldRotation.y), 0f, (float)Math.Cos((Math.PI / 180f) * WorldRotation.y), 0 },
            { 0f, 0f, 0f, 1f },
        }); 
            
        WorldRotationZMatrix = new MatrixFloat(new float[,]
        {
            { (float)Math.Cos((Math.PI / 180f) * WorldRotation.z), -1 * (float)Math.Sin((Math.PI / 180f) * WorldRotation.z), 0f, 0 },
            { (float)Math.Sin((Math.PI / 180f) * WorldRotation.z), (float)Math.Cos((Math.PI / 180f) * WorldRotation.z), 0f, 0 },
            { 0f, 0f, 1f, 0 },
            { 0f, 0f, 0f, 1f },
        });
        
        WorldRotationMatrix = (WorldRotationYMatrix * WorldRotationXMatrix * WorldRotationZMatrix);
        UpdateLocalWorldMatrix();
    }
    
    //WIP
    void UpdateWorldScale()
    {
        MatrixFloatElementaryOperations.MultiplyLine(WorldScaleMatrix, 0,  WorldScale.x / _oldWorldScale.x);
        MatrixFloatElementaryOperations.MultiplyLine(WorldScaleMatrix, 1,  WorldScale.y / _oldWorldScale.y);
        MatrixFloatElementaryOperations.MultiplyLine(WorldScaleMatrix, 2,  WorldScale.z / _oldWorldScale.z);
        UpdateLocalWorldMatrix();
    }
    void UpdateWorldPosition()
    {
        WorldTranslationMatrix = new MatrixFloat(new float[,]
        {
            { 1f, 0f, 0f, WorldPosition.x },
            { 0f, 1f, 0f, WorldPosition.y },
            { 0f, 0f, 1f, WorldPosition.z },
            { 0f, 0f, 0f, 1f },
        });
        UpdateLocalWorldMatrix();

    }


}
