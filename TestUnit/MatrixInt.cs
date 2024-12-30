using NUnit.Framework;

public class MatrixInt
{
    
    public int[,] matrixTable;

    //Exercice 1
    public MatrixInt(int rowsNumber, int columnsNumber)
    {
        matrixTable = new int[rowsNumber, columnsNumber];
    }
    
    

    

    public int[,] ToArray2D()
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
    
    public MatrixInt(int[,] matrixContent)
    {
        matrixTable = matrixContent;
    }
    
    //Exercice 2
    public int this[int row, int column]
    {
        get { return matrixTable[row, column]; }
        set { matrixTable[row, column] = value; }
    }

    public MatrixInt(MatrixInt matrix)
    {
        MatrixInt tempMatrix = new MatrixInt(matrix.NbLines(), matrix.NbColumns());
        for (int i = 0; i < matrix.NbLines(); i++)
        {
            for (int j = 0; j < matrix.NbColumns(); j++)
            {
                tempMatrix[i, j] = matrix[i, j];
            }
        }

        matrixTable = tempMatrix.matrixTable;
    }

    //Exercice 3
    public static MatrixInt Identity(int degree)
    {
        MatrixInt matrix = new MatrixInt(degree, degree);
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

    public bool IsIdentity()
    {
        if (matrixTable.GetLength(1) == matrixTable.GetLength(0))
        {
            for (int i = 0; i < matrixTable.GetLength(0); i++)
            {
                for (int j = 0; j < matrixTable.GetLength(1); j++)
                {
                    if (i == j)
                    {
                        if (matrixTable[i, j] != 1)
                        {
                            return false;
                        }
                    }
                    else
                    {
                        if (matrixTable[i, j] != 0)
                        {
                            return false;
                        }
                    }
                    
                }
            }
        }
        else
        {
            return false;
        }

        return true;
    }
    
    //Exercice 4
    public void Multiply(int coefficient)
    {
        for (int i = 0; i < matrixTable.GetLength(0); i++)
        {
            for (int j = 0; j < matrixTable.GetLength(1); j++)
            {
                matrixTable[i, j] *= coefficient;
            }
        }
    }
    
    public static MatrixInt Multiply(MatrixInt matrix, int coefficient)
    {
        //copier la matrice prise en param
        MatrixInt newMatrix = new MatrixInt(matrix);
        for (int i = 0; i < matrix.NbLines(); i++)
        {
            for (int j = 0; j < matrix.NbColumns(); j++)
            {
                newMatrix.matrixTable[i, j] *= coefficient;
            }
        }

        return newMatrix;
    }
    
    
    public static MatrixInt operator *(MatrixInt matrix, int coefficient)
        => Multiply(matrix, coefficient);
    public static MatrixInt operator *(int coefficient, MatrixInt matrix)
        => Multiply(matrix, coefficient);
    public static MatrixInt operator -(MatrixInt matrix)
        => Multiply(matrix, -1);

    //Exercice 5
    public void Add(MatrixInt matrix)
    {
        if (matrix.NbLines() == this.NbLines() && matrix.NbColumns() == this.NbColumns())
        {
            for (int i = 0; i < this.NbLines(); i++)
            {
                for (int j = 0; j < this.NbColumns(); j++)
                {
                    this.matrixTable[i, j] += matrix[i, j];
                }
            }

        }
        else
        {
            throw new MatrixSumException();
        }
    }

    public static MatrixInt Add(MatrixInt matrix1, MatrixInt matrix2)
    {
        MatrixInt tempMatrix = new MatrixInt(matrix1.NbLines(), matrix1.NbColumns());
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
    
    public static MatrixInt operator +(MatrixInt matrix1, MatrixInt matrix2)
        => Add(matrix1, matrix2);
    public static MatrixInt operator -(MatrixInt matrix1, MatrixInt matrix2)
        => Add(matrix1, Multiply(matrix2, -1));
    
    //Exercice 6
    
    public MatrixInt Multiply(MatrixInt matrix)
    {
        //Determine la taille de la matrice en prenant la plus grande largeur et hauteur des deux matrices
        MatrixInt tempMatrix = new MatrixInt(Math.Max(this.NbLines(), matrix.NbLines()), Math.Max(this.NbColumns(), matrix.NbColumns()));
        if (this.NbColumns() == matrix.NbLines())
        {
            for (int i = 0; i < tempMatrix.NbLines(); i++)
            {
                for (int j = 0; j < tempMatrix.NbColumns(); j++)
                {
                    int value = 0;
                    for (int k = 0; k < this.NbColumns(); k++)
                    {
                        value += this[i, k] * matrix[k, j];
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
    public static MatrixInt Multiply(MatrixInt matrix1, MatrixInt matrix2)
    {
        //Determine la taille de la matrice en prenant la plus grande largeur et hauteur des deux matrices
        MatrixInt tempMatrix = new MatrixInt(Math.Max(matrix1.NbLines(), matrix2.NbLines()), Math.Max(matrix1.NbColumns(), matrix2.NbColumns()));
        if (matrix1.NbColumns() == matrix2.NbLines())
        {
            for (int i = 0; i < tempMatrix.NbLines(); i++)
            {
                for (int j = 0; j < tempMatrix.NbColumns(); j++)
                {
                    int value = 0;
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
    public static MatrixInt operator *(MatrixInt matrix1, MatrixInt matrix2)
        => Multiply(matrix1, matrix2);
    
    //Exercice 7

    public MatrixInt Transpose()
    {
        MatrixInt tempMatrix = new MatrixInt(this.NbColumns(), this.NbLines());
        for (int i = 0; i < this.NbLines(); i++)
        {
            for (int j = 0; j < this.NbColumns(); j++)
            {
                tempMatrix.matrixTable[j, i] = this.matrixTable[i, j];
            }
        }
        return tempMatrix;
    }
    public static MatrixInt Transpose(MatrixInt matrix)
    {
        MatrixInt tempMatrix = new MatrixInt(matrix.NbColumns(), matrix.NbLines());
        for (int i = 0; i < matrix.NbLines(); i++)
        {
            for (int j = 0; j < matrix.NbColumns(); j++)
            {
                tempMatrix.matrixTable[j, i] = matrix.matrixTable[i, j];
            }
        }
        return tempMatrix;
    }
    
    //Exercice 9

    public static MatrixInt GenerateAugmentedMatrix(MatrixInt matrix1, MatrixInt matrix2)
    {
        MatrixInt tempMatrix = new MatrixInt(matrix1.NbLines(), matrix1.NbColumns() + matrix2.NbColumns());
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

    public (MatrixInt, MatrixInt) Split(int column)
    {
        MatrixInt firstMatrix = new MatrixInt(this.NbLines(), column + 1);
        MatrixInt secondMatrix = new MatrixInt(this.NbLines(), this.NbColumns() - (column + 1));
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
}

public class MatrixElementaryOperations
{
    //Exercice 8
    public static void SwapLines(MatrixInt matrix, int line1, int line2)
    {
        for (int i = 0; i < matrix.NbColumns(); i++)
        {
            (matrix.matrixTable[line1, i], matrix.matrixTable[line2, i]) = (matrix.matrixTable[line2, i], matrix.matrixTable[line1, i]);
        }
    }
    public static void SwapColumns(MatrixInt matrix, int column1, int column2)
    {
        for (int i = 0; i < matrix.NbLines(); i++)
        {
            (matrix.matrixTable[i, column1], matrix.matrixTable[i, column2]) = (matrix.matrixTable[i, column2], matrix.matrixTable[i, column1]);
        }
    }

    public static void MultiplyLine(MatrixInt matrix, int line, int coef)
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
    
    public static void MultiplyColumn(MatrixInt matrix, int column, int coef)
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

    public static void AddLineToAnother(MatrixInt matrix, int lineToAdd, int lineChanged, int coef)
    {
        
        for (int i = 0; i < matrix.NbColumns(); i++)
        {
            matrix.matrixTable[lineChanged, i] += (matrix.matrixTable[lineToAdd, i] * coef);
        }
    }
    
    public static void AddColumnToAnother(MatrixInt matrix, int columnToAdd, int columnChanged, int coef)
    {
        
        for (int i = 0; i < matrix.NbLines(); i++)
        {
            matrix.matrixTable[i, columnChanged] += (matrix.matrixTable[i, columnToAdd] * coef);
        }
    }
    
    
}

public class MatrixSumException : Exception{}
public class MatrixMultiplyException : Exception{}
public class MatrixScalarZeroException : Exception{}

