using System.Diagnostics;
using System.Runtime.InteropServices;
using NUnit.Framework;
using NUnit.Framework.Constraints;

public class MatrixFloat
{

    public float[,] matrixTable;

    //Exercice 10
    public MatrixFloat(int rowsNumber, int columnsNumber)
    {
        matrixTable = new float[rowsNumber, columnsNumber];
    }

    public float[,] ToArray2D()
    {
        return matrixTable;
    }

    public int NbLines()
    {
        return matrixTable.GetLength(0);
    }

    public int NbColumns()
    {
        return matrixTable.GetLength(1);
    }

    public MatrixFloat(float[,] matrixContent)
    {
        matrixTable = matrixContent;
    }

    public float this[int row, int column]
    {
        get { return matrixTable[row, column]; }
        set { matrixTable[row, column] = value; }
    }

    public MatrixFloat(MatrixFloat matrix)
    {
        MatrixFloat tempMatrix = new MatrixFloat(matrix.NbLines(), matrix.NbColumns());
        for (int i = 0; i < matrix.NbLines(); i++)
        {
            for (int j = 0; j < matrix.NbColumns(); j++)
            {
                tempMatrix[i, j] = matrix[i, j];
            }
        }

        matrixTable = tempMatrix.matrixTable;
    }
    public static MatrixFloat GenerateAugmentedMatrix(MatrixFloat matrix1, MatrixFloat matrix2)
    {
        MatrixFloat tempMatrix = new MatrixFloat(matrix1.NbLines(), matrix1.NbColumns() + matrix2.NbColumns());
        for (int i = 0; i < tempMatrix.NbLines(); i++)
        {
            for (int j = 0; j < tempMatrix.NbColumns(); j++)
            {
                if (j < matrix1.NbColumns())
                {
                    tempMatrix.matrixTable[i, j] = matrix1[i, j];
                }
                else
                {
                    tempMatrix.matrixTable[i, j] = matrix2[i, j - matrix1.NbColumns()];
                }
            }
        }
        return tempMatrix;
    }
    public (MatrixFloat, MatrixFloat) Split(int column)
    {
        MatrixFloat firstMatrix = new MatrixFloat(this.NbLines(), column + 1);
        MatrixFloat secondMatrix = new MatrixFloat(this.NbLines(), this.NbColumns() - (column + 1));
        for (int i = 0; i < this.NbLines(); i++)
        {
            for (int j = 0; j < this.NbColumns(); j++)
            {
                if (j <= column)
                {
                    firstMatrix.matrixTable[i, j] = this[i, j];
                }
                else
                {
                    secondMatrix.matrixTable[i, j - (column + 1)] = this[i, j];
                }
            }
        }
        return (firstMatrix, secondMatrix);
    }

    public static MatrixFloat Identity(int degree)
    {
        MatrixFloat matrix = new MatrixFloat(degree, degree);
        for (int i = 0; i < degree; i++)
        {
            for (int j = 0; j < degree; j++)
            {
                if (i == j)
                {
                    matrix[i, j] = 1;
                }
                else
                {
                    matrix[i, j] = 0;
                }
            }
        }

        return matrix;
    }
    
    public static MatrixFloat Multiply(MatrixFloat matrix, float coefficient)
    {
       
        MatrixFloat newMatrix = new MatrixFloat(matrix);
        for (int i = 0; i < matrix.NbLines(); i++)
        {
            for (int j = 0; j < matrix.NbColumns(); j++)
            {
                newMatrix.matrixTable[i, j] *= coefficient;
            }
        }

        return newMatrix;
    }
    
    public static MatrixFloat Multiply(MatrixFloat matrix1, MatrixFloat matrix2)
    {
        //Determine la taille de la matrice en prenant la plus grande largeur et hauteur des deux matrices
        MatrixFloat tempMatrix = new MatrixFloat(Math.Max(matrix1.NbLines(), matrix2.NbLines()), Math.Max(matrix1.NbColumns(), matrix2.NbColumns()));
        if (matrix1.NbColumns() == matrix2.NbLines())
        {
            for (int i = 0; i < tempMatrix.NbLines(); i++)
            {
                for (int j = 0; j < tempMatrix.NbColumns(); j++)
                {
                    float value = 0;
                    for (int k = 0; k < matrix1.NbColumns(); k++)
                    {
                        value += (matrix1[i, k] * matrix2[k, j]);
                    }

                    tempMatrix.matrixTable[i, j] = value;
                }
            }
        }
        else
        {
            throw new MatrixMultiplyException();
        }
        return tempMatrix;
    }
    public static MatrixFloat operator *(MatrixFloat matrix1, MatrixFloat matrix2)
        => Multiply(matrix1, matrix2);
    
    public static MatrixFloat Add(MatrixFloat matrix1, MatrixFloat matrix2)
    {
        MatrixFloat tempMatrix = new MatrixFloat(matrix1.NbLines(), matrix1.NbColumns());
        if (matrix1.NbLines() == matrix2.NbLines() && matrix1.NbColumns() == matrix2.NbColumns())
        {
            for (int i = 0; i < tempMatrix.NbLines(); i++)
            {
                for (int j = 0; j < tempMatrix.NbColumns(); j++)
                {
                    tempMatrix.matrixTable[i, j] = matrix1[i, j] + matrix2[i, j];
                }
            }
        }
        else
        {
            throw new MatrixSumException();
        }
        return tempMatrix;
    }
    
    public static MatrixFloat operator +(MatrixFloat matrix1, MatrixFloat matrix2)
        => Add(matrix1, matrix2);
    
    
    
    public MatrixFloat InvertByRowReduction()
    {
        (MatrixFloat m1, MatrixFloat m2) = MatrixRowReductionAlgorithm.Apply(this, Identity(this.NbLines()), true);
        return m2;
    }

    public static MatrixFloat InvertByRowReduction(MatrixFloat matrix)
    {
        (MatrixFloat m1, MatrixFloat m2) = MatrixRowReductionAlgorithm.Apply(matrix, Identity(matrix.NbLines()));
        return m2;
    }

    public MatrixFloat SubMatrix(int row, int column)
    {
        MatrixFloat currentMatrix = new MatrixFloat(this);
        MatrixFloat subMatrix = new MatrixFloat(currentMatrix.NbLines() - 1, currentMatrix.NbColumns() - 1);
        int rowSubMatrix = 0;
        for (int i = 0; i < currentMatrix.NbLines(); i++)
        {
            if (i != row)
            {
                int columnSubMatrix = 0;
                for (int j = 0; j < currentMatrix.NbColumns(); j++)
                {
                    
                    if (j != column)
                    {    
                        subMatrix.matrixTable[rowSubMatrix, columnSubMatrix] = currentMatrix[i, j];
                        columnSubMatrix++;
                    }
                }
                rowSubMatrix++;
            }
        }

        return subMatrix;
    }
    
    public static MatrixFloat SubMatrix(MatrixFloat matrix, int row, int column)
    {
        MatrixFloat currentMatrix = new MatrixFloat(matrix);
        MatrixFloat subMatrix = new MatrixFloat(currentMatrix.NbLines() - 1, currentMatrix.NbColumns() - 1);
        int rowSubMatrix = 0;
        for (int i = 0; i < currentMatrix.NbLines(); i++)
        {
            if (i != row)
            {
                int columnSubMatrix = 0;
                for (int j = 0; j < currentMatrix.NbColumns(); j++)
                {
                    if (j != column)
                    {    
                        subMatrix.matrixTable[rowSubMatrix, columnSubMatrix] = currentMatrix[i, j];
                        columnSubMatrix++;
                    }
                }
                rowSubMatrix++;
            }
        }

        return subMatrix;
    }

    public static float Determinant(MatrixFloat matrix)
    {
        float determinant = 0;

        //Calcul du cofacteur
        float cofacteur = 1;
        if ((matrix.NbColumns() + matrix.NbLines()) % 2 == 0)
        {
            cofacteur = 1;
        }
        else
        {
            cofacteur = -1;
        }
        
        if(matrix.NbColumns() == 1)
        {
            determinant = matrix[0,0];
        }
        else
        {
            for (int i = 0; i < matrix.NbColumns(); i++)
            {
                determinant += cofacteur * (matrix[0, i] * Determinant(SubMatrix(matrix, 0, i)));
                cofacteur *= (-1);
            }
        }
        
        
        return determinant;

    }
    
    public MatrixFloat Transpose()
    {
        MatrixFloat tempMatrix = new MatrixFloat(this.NbColumns(), this.NbLines());
        for (int i = 0; i < this.NbLines(); i++)
        {
            for (int j = 0; j < this.NbColumns(); j++)
            {
                tempMatrix.matrixTable[j, i] = this.matrixTable[i, j];
            }
        }
        return tempMatrix;
    }

    public MatrixFloat Adjugate()
    {
        MatrixFloat tempMatrix = new MatrixFloat(this.NbLines(), this.NbColumns());
        for (int i = 0; i < this.NbLines(); i++)
        {
            for (int j = 0; j < this.NbColumns(); j++)
            {
                tempMatrix[i,j] = (float)Math.Pow(-1, i+j) * Determinant(SubMatrix(this, i, j));
            }
        }
        
        return tempMatrix.Transpose();
    }
    public static MatrixFloat Adjugate(MatrixFloat matrix)
    {
        MatrixFloat tempMatrix = new MatrixFloat(matrix.NbLines(), matrix.NbColumns());
        for (int i = 0; i < matrix.NbLines(); i++)
        {
            for (int j = 0; j < matrix.NbColumns(); j++)
            {
                tempMatrix[i,j] = (float)Math.Pow(-1, i+j) * Determinant(SubMatrix(matrix, i, j));
            }
        }
        
        return tempMatrix.Transpose();
    }

    public MatrixFloat InvertByDeterminant()
    {
        MatrixFloat adjMatrix = Adjugate(this);
        
        float detMatrix = Determinant(this);
        
        if (detMatrix == 0)
        {
            throw new MatrixInvertException();
        }
        
        return Multiply(adjMatrix, 1/detMatrix);
    }
    
    public static MatrixFloat InvertByDeterminant(MatrixFloat matrix)
    {
        MatrixFloat adjMatrix = Adjugate(matrix);
        
        float detMatrix = Determinant(matrix);

        if (detMatrix == 0)
        {
            throw new MatrixInvertException();
        }
        
        return Multiply(adjMatrix, 1/detMatrix);
    }
    
    
}

public class MatrixRowReductionAlgorithm
{
    public static void SwapLines(MatrixFloat matrix, int line1, int line2)
    {
        for (int i = 0; i < matrix.NbColumns(); i++)
        {
            (matrix.matrixTable[line1, i], matrix.matrixTable[line2, i]) = (matrix.matrixTable[line2, i], matrix.matrixTable[line1, i]);
        }
    }
    
    public static void AddLineToAnother(MatrixFloat matrix, int lineToAdd, int lineChanged, float coef)
    {
        
        for (int i = 0; i < matrix.NbColumns(); i++)
        {
            matrix.matrixTable[lineChanged, i] += (matrix.matrixTable[lineToAdd, i] * coef);
        }
    }
    public static void MultiplyLine(MatrixFloat matrix, int line, float coef)
    {
        if (coef != 0)
        {
            for (int i = 0; i < matrix.NbColumns(); i++)
            {
                matrix.matrixTable[line, i] *= coef;
            }
        }
        else
        {
            throw new MatrixScalarZeroException();
        }
    }
    
    
    public static (MatrixFloat, MatrixFloat) Apply(MatrixFloat matrix1, MatrixFloat matrix2, bool doThrowException = false)
    {
        MatrixFloat augmentedMatrix = MatrixFloat.GenerateAugmentedMatrix(matrix1, matrix2);

        for (int i = 0; i < augmentedMatrix.NbLines(); i++)
        {
            float biggestNumber = 0;
            int index = 0;
            for (int k = i; k < augmentedMatrix.NbLines(); k++)
            {
                if ((augmentedMatrix[k, i] > biggestNumber || biggestNumber == 0) && augmentedMatrix[k, i] != 0 )
                {
                    biggestNumber = augmentedMatrix[k, i];
                    index = k;
                }
                
            }

            if (biggestNumber == 0) //Si toute la colonne est nulle
            {
                if (doThrowException)
                {
                    throw new MatrixInvertException();
                }
                
            }

            if (augmentedMatrix[i, i] != 0)
            {
                if (i != index)
                {
                    SwapLines(augmentedMatrix, i, index);
                }
            
                MultiplyLine(augmentedMatrix, i , 1 / augmentedMatrix.matrixTable[i, i]);
            
                for (int r = 0; r < augmentedMatrix.NbLines(); r++)
                {
                    if (r != i)
                    {
                        AddLineToAnother(augmentedMatrix, i, r, -1 * augmentedMatrix.matrixTable[r, i]);
                    }
                }
            }
            
        }
        
        return augmentedMatrix.Split(matrix1.NbColumns() - 1);
    }

    
}
public class MatrixFloatElementaryOperations
{
    public static void SwapLines(MatrixFloat matrix, int line1, int line2)
    {
        for (int i = 0; i < matrix.NbColumns(); i++)
        {
            (matrix.matrixTable[line1, i], matrix.matrixTable[line2, i]) = (matrix.matrixTable[line2, i], matrix.matrixTable[line1, i]);
        }
    }
    public static void SwapColumns(MatrixFloat matrix, int column1, int column2)
    {
        for (int i = 0; i < matrix.NbLines(); i++)
        {
            (matrix.matrixTable[i, column1], matrix.matrixTable[i, column2]) = (matrix.matrixTable[i, column2], matrix.matrixTable[i, column1]);
        }
    }

    public static void MultiplyLine(MatrixFloat matrix, int line, float coef)
    {
        if (coef != 0)
        {
            for (int i = 0; i < matrix.NbColumns(); i++)
            {
                matrix.matrixTable[line, i] *= coef;
            }
        }
        else
        {
            throw new MatrixScalarZeroException();
        }
    }
    
    public static void MultiplyColumn(MatrixFloat matrix, int column, int coef)
    {
        if (coef != 0)
        {
            for (int i = 0; i < matrix.NbLines(); i++)
            {
                matrix.matrixTable[i, column] *= coef;
            }
        }
        else
        {
            throw new MatrixScalarZeroException();
        }
    }

    public static void AddLineToAnother(MatrixFloat matrix, int lineToAdd, int lineChanged, int coef)
    {
        
        for (int i = 0; i < matrix.NbColumns(); i++)
        {
            matrix.matrixTable[lineChanged, i] += (matrix.matrixTable[lineToAdd, i] * coef);
        }
    }
    
    public static void AddColumnToAnother(MatrixFloat matrix, int columnToAdd, int columnChanged, int coef)
    {
        
        for (int i = 0; i < matrix.NbLines(); i++)
        {
            matrix.matrixTable[i, columnChanged] += (matrix.matrixTable[i, columnToAdd] * coef);
        }
    }
    
    
}
public class MatrixInvertException : Exception{}

    

