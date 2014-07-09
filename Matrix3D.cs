using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeSim
{
    ////////////////////////////////////////////////////////////////////////////////////////////
    //Name:			Matrix3D																	
    //Author:		Sean Robinson (Sean.T.Robinson@googlemail.com)								
    //Description:	Manipulation of vectors in 3 dimensional space are done through the use of
	//              matrices.  We use a 4x4 homogenous matrix configuration to enable
    //              vector manipulation in 3D space.  Basic matrix operations such as rotate
    //              and translate are supplied.
    ////////////////////////////////////////////////////////////////////////////////////////////
    public class Matrix3D
    {

        private double[,] _matrix;
        private double[,] matrix() { return _matrix; }
        public Matrix3D()
        {
            _matrix = new double[4, 4];
            for (int i=0; i<4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    _matrix[i, j] = 0.0;
                }
            }
            _matrix[0, 0] = 1.0;
            _matrix[1, 1] = 1.0;
            _matrix[2, 2] = 1.0;
            _matrix[3, 3] = 1.0;

        }

        private void setMatrix(double[,] mat) { _matrix = mat; }

        public double this[int col, int row]
        {
            get
            {
                if (indicesAreValid(col, row))
                {
                    return _matrix[col, row];
                }
                throw new ArgumentException("Invalid index for 4x4 homoegenous matrix. Use 0..4");
            }
            set
            {
                if (indicesAreValid(col, row))
                {
                    _matrix[col, row] = value;
                }
                else
                {
                    String errorString = String.Format("Invalid index ([{0}, {1}]) for 4x4 homoegenous matrix. Use 0..3", col, row);
                    throw new ArgumentException(errorString);
                }
            }
        }
   
        private bool indicesAreValid(int col,int row)
        {
 	        return (
                col >=0 && col <=4
                &&
                row >=0 && row <= 4) ? true : false;
        }

	    ////////////////////////////////////////////////////////////////////////////////////////////
	    //Name:				* operator.																
	    //In:				Matrix3D b:		The matrix to concatenate with.							
	    //Out:				Matrix3D:		A concatenated matrix.																						
	    //Postcondition:	The matrices are concatenated together.  This result is then returned.	
	    //Description:		Matrix concatenation forms one of the most critical components of this	
	    //					class as it is with this operation that rotation matrices are generated.
	    //					It is important to concatenate matrices in the correct order.  This		
	    //					uses the order A * B.
		//											    
        //                  The chart below indicates the position in the matrix of each array element.
        //				   |00		01		02		03|												
        //				   |10		11		12		13|												
        //				   |20		21		22		23|												
        //				   |30		31		32		33|	
        //
	    ////////////////////////////////////////////////////////////////////////////////////////////									
        public static Matrix3D operator * (Matrix3D a, Matrix3D b)
        {
	        Matrix3D C = new Matrix3D();
	        //Column 1
	        C._matrix[0, 0] =	((a._matrix[0, 0] * b._matrix[0, 0]) + 
						         (a._matrix[0, 1] * b._matrix[1, 0]) + 
						         (a._matrix[0, 2] * b._matrix[2, 0]) + 
						         (a._matrix[0, 3] * b._matrix[3, 0]));

	        C._matrix[1, 0] =	((a._matrix[1, 0] * b._matrix[0, 0]) + 
						         (a._matrix[1, 1] * b._matrix[1, 0]) + 
						         (a._matrix[1, 2] * b._matrix[2, 0]) + 
						         (a._matrix[1, 3] * b._matrix[3, 0]));

	        C._matrix[2, 0] =	((a._matrix[2, 0] * b._matrix[0, 0]) + 
						         (a._matrix[2, 1] * b._matrix[1, 0]) + 
						         (a._matrix[2, 2] * b._matrix[2, 0]) + 
						         (a._matrix[2, 3] * b._matrix[3, 0]));

	        C._matrix[3, 0] =	((a._matrix[3, 0] * b._matrix[0, 0]) + 
						         (a._matrix[3, 1] * b._matrix[1, 0]) + 
						         (a._matrix[3, 2] * b._matrix[2, 0]) + 
						         (a._matrix[3, 3] * b._matrix[3, 0]));

	        //Column 2
	        C._matrix[0, 1] =	((a._matrix[0, 0] * b._matrix[0, 1]) + 
						         (a._matrix[0, 1] * b._matrix[1, 1]) + 
						         (a._matrix[0, 2] * b._matrix[2, 1]) + 
						         (a._matrix[0, 3] * b._matrix[3, 1]));

	        C._matrix[1, 1] =	((a._matrix[1, 0] * b._matrix[0, 1]) + 
						         (a._matrix[1, 1] * b._matrix[1, 1]) + 
						         (a._matrix[1, 2] * b._matrix[2, 1]) + 
						         (a._matrix[1, 3] * b._matrix[3, 1]));

	        C._matrix[2, 1] =	((a._matrix[2, 0] * b._matrix[0, 1]) + 
						         (a._matrix[2, 1] * b._matrix[1, 1]) + 
						         (a._matrix[2, 2] * b._matrix[2, 1]) + 
						         (a._matrix[2, 3] * b._matrix[3, 1]));

	        C._matrix[3, 1] =	((a._matrix[3, 0] * b._matrix[0, 1]) + 
						         (a._matrix[3, 1] * b._matrix[1, 1]) + 
						         (a._matrix[3, 2] * b._matrix[2, 1]) + 
						         (a._matrix[3, 3] * b._matrix[3, 1]));

	        //Column 3
	        C._matrix[0, 2] =	((a._matrix[0, 0] * b._matrix[0, 2]) + 
						         (a._matrix[0, 1] * b._matrix[1, 2]) + 
						         (a._matrix[0, 2] * b._matrix[2, 2]) + 
						         (a._matrix[0, 3] * b._matrix[3, 2]));

	        C._matrix[1, 2] =	((a._matrix[1, 0] * b._matrix[0, 2]) + 
						         (a._matrix[1, 1] * b._matrix[1, 2]) + 
						         (a._matrix[1, 2] * b._matrix[2, 2]) + 
						         (a._matrix[1, 3] * b._matrix[3, 2]));

	        C._matrix[2, 2] =	((a._matrix[2, 0] * b._matrix[0, 2]) + 
						         (a._matrix[2, 1] * b._matrix[1, 2]) + 
						         (a._matrix[2, 2] * b._matrix[2, 2]) + 
						         (a._matrix[2, 3] * b._matrix[3, 2]));

	        C._matrix[3, 2] =	((a._matrix[3, 0] * b._matrix[0, 2]) + 
						         (a._matrix[3, 1] * b._matrix[1, 2]) + 
						         (a._matrix[3, 2] * b._matrix[2, 2]) + 
						         (a._matrix[3, 3] * b._matrix[3, 2]));

	        //Column 4
	        C._matrix[0, 3] =	((a._matrix[0, 0] * b._matrix[0, 3]) + 
						         (a._matrix[0, 1] * b._matrix[1, 3]) + 
						         (a._matrix[0, 2] * b._matrix[2, 3]) + 
						         (a._matrix[0, 3] * b._matrix[3, 3]));

	        C._matrix[1, 3] =	((a._matrix[1, 0] * b._matrix[0, 3]) + 
						         (a._matrix[1, 1] * b._matrix[1, 3]) + 
						         (a._matrix[1, 2] * b._matrix[2, 3]) + 
						         (a._matrix[1, 3] * b._matrix[3, 3]));

	        C._matrix[2, 3] =	((a._matrix[2, 0] * b._matrix[0, 3]) + 
						         (a._matrix[2, 1] * b._matrix[1, 3]) + 
						         (a._matrix[2, 2] * b._matrix[2, 3]) + 
						         (a._matrix[2, 3] * b._matrix[3, 3]));

	        C._matrix[3, 3] =	((a._matrix[3, 0] * b._matrix[0, 3]) + 
						         (a._matrix[3, 1] * b._matrix[1, 3]) + 
						         (a._matrix[3, 2] * b._matrix[2, 3]) + 
						         (a._matrix[3, 3] * b._matrix[3, 3]));

	        return C;
}


	    ////////////////////////////////////////////////////////////////////////////////////////////
	    //Name:				* operator.																
	    //In:				double scalar:	The value to multiply attributes by.					
	    //Out:				Matrix3D:		A transformed matrix.									
	    //Precondition:		A valid Matrix3D object has been generated and supplied with appropriate
	    //					values.  A floating point value must be supplied.								
	    //Description:		This simply scales each element of the  matrix by the scalar value		
	    //					supplied as a parameter.												
	    ////////////////////////////////////////////////////////////////////////////////////////////
        public static Matrix3D operator * (Matrix3D m, double scalar)
        {
            Matrix3D newMatrix = new Matrix3D();
	        for(int i = 0; i < 4; i++)
            {
		        for (int j = 0; j < 4; j++)
                {
			        newMatrix[i,j] = m[i,j] * scalar;
		        }
	        }
            return newMatrix;
        }

        //Alternative method, use methods implemented above
        //with values stripped from supplied vector.
        public void Matrix3DTranslate(Vector3D vec)
        {
            Matrix3D translationMatrix = Matrix3DCreator.getTranslationMatrix(vec.x, vec.y, vec.z);
	        Matrix3D result = this * translationMatrix;
            _matrix = result._matrix;
        }

        public void Matrix3DRotate(Vector3D vec)
        {
            Matrix3D rotationMatrix = Matrix3DCreator.getRotationMatrix(vec.x, vec.y, vec.z);
            Matrix3D result = this * rotationMatrix;
            _matrix = result._matrix;
        }

        public void Matrix3DScale(Vector3D vec)
        {
            Matrix3D scaleMatrix = Matrix3DCreator.getScaleMatrix(vec.x, vec.y, vec.z);
            Matrix3D result = this * scaleMatrix;
            _matrix = result._matrix;
        }

        public void Matrix3DTranslate(double x, double y, double z) { Matrix3DTranslate(new Vector3D(x, y, z)); }
        public void Matrix3DRotate(double x, double y, double z) { Matrix3DRotate(new Vector3D(x, y, z)); }
        public void Matrix3DScale(double x, double y, double z) { Matrix3DScale(new Vector3D(x, y, z)); }

        //String output of current state of matrix
        public override string ToString() {
	        string output = "";
	        for(int i = 0; i < 4; i++)
            {
		        for (int j = 0; j < 4; j++)
                {
			        output += +_matrix[i, j] + "\t";			
		        }
		        output += "\n";
	        }
	        return output;
        }
    }
}
