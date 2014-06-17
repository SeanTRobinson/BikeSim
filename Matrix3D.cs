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
    //Description:	The movement of objects governed by this physics engine is calculated using	
    //				a specialised vector class.  The vectors used to represent movement and		
    //				points within the solution are transformed using matrices, these are		
    //				created and manipulated here.  When a specialised matrix has been created,	
    //				it is returned to Vector3D to use in the manipulation of a vector.			
    ////////////////////////////////////////////////////////////////////////////////////////////
    class Matrix3D
    {

        private double[][] _matrix;
        private double[][] matrix() { return _matrix; }
        private void setMatrix(double[][] mat) { _matrix = mat; }

        public double this[int col, int row]
        {
            get
            {
                if (indicesAreValid(col, row))
                {
                    return _matrix[col][row];
                }
                throw new ArgumentException("Invalid index for 4x4 homoegenous matrix. Use 0..4");
            }
            set
            {
                if (indicesAreValid(col, row))
                {
                    _matrix[col][row] = value;
                }
                throw new ArgumentException("Invalid index for 4x4 homoegenous matrix. Use 0..4");
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
	        C._matrix[0][0] =	((a._matrix[0][0] * b._matrix[0][0]) + 
						         (a._matrix[0][1] * b._matrix[1][0]) + 
						         (a._matrix[0][2] * b._matrix[2][0]) + 
						         (a._matrix[0][3] * b._matrix[3][0]));

	        C._matrix[1][0] =	((a._matrix[1][0] * b._matrix[0][0]) + 
						         (a._matrix[1][1] * b._matrix[1][0]) + 
						         (a._matrix[1][2] * b._matrix[2][0]) + 
						         (a._matrix[1][3] * b._matrix[3][0]));

	        C._matrix[2][0] =	((a._matrix[2][0] * b._matrix[0][0]) + 
						         (a._matrix[2][1] * b._matrix[1][0]) + 
						         (a._matrix[2][2] * b._matrix[2][0]) + 
						         (a._matrix[2][3] * b._matrix[3][0]));

	        C._matrix[3][0] =	((a._matrix[3][0] * b._matrix[0][0]) + 
						         (a._matrix[3][1] * b._matrix[1][0]) + 
						         (a._matrix[3][2] * b._matrix[2][0]) + 
						         (a._matrix[3][3] * b._matrix[3][0]));

	        //Column 2
	        C._matrix[0][1] =	((a._matrix[0][0] * b._matrix[0][1]) + 
						         (a._matrix[0][1] * b._matrix[1][1]) + 
						         (a._matrix[0][2] * b._matrix[2][1]) + 
						         (a._matrix[0][3] * b._matrix[3][1]));

	        C._matrix[1][1] =	((a._matrix[1][0] * b._matrix[0][1]) + 
						         (a._matrix[1][1] * b._matrix[1][1]) + 
						         (a._matrix[1][2] * b._matrix[2][1]) + 
						         (a._matrix[1][3] * b._matrix[3][1]));

	        C._matrix[2][1] =	((a._matrix[2][0] * b._matrix[0][1]) + 
						         (a._matrix[2][1] * b._matrix[1][1]) + 
						         (a._matrix[2][2] * b._matrix[2][1]) + 
						         (a._matrix[2][3] * b._matrix[3][1]));

	        C._matrix[3][1] =	((a._matrix[3][0] * b._matrix[0][1]) + 
						         (a._matrix[3][1] * b._matrix[1][1]) + 
						         (a._matrix[3][2] * b._matrix[2][1]) + 
						         (a._matrix[3][3] * b._matrix[3][1]));

	        //Column 3
	        C._matrix[0][2] =	((a._matrix[0][0] * b._matrix[0][2]) + 
						         (a._matrix[0][1] * b._matrix[1][2]) + 
						         (a._matrix[0][2] * b._matrix[2][2]) + 
						         (a._matrix[0][3] * b._matrix[3][2]));

	        C._matrix[1][2] =	((a._matrix[1][0] * b._matrix[0][2]) + 
						         (a._matrix[1][1] * b._matrix[1][2]) + 
						         (a._matrix[1][2] * b._matrix[2][2]) + 
						         (a._matrix[1][3] * b._matrix[3][2]));

	        C._matrix[2][2] =	((a._matrix[2][0] * b._matrix[0][2]) + 
						         (a._matrix[2][1] * b._matrix[1][2]) + 
						         (a._matrix[2][2] * b._matrix[2][2]) + 
						         (a._matrix[2][3] * b._matrix[3][2]));

	        C._matrix[3][2] =	((a._matrix[3][0] * b._matrix[0][2]) + 
						         (a._matrix[3][1] * b._matrix[1][2]) + 
						         (a._matrix[3][2] * b._matrix[2][2]) + 
						         (a._matrix[3][3] * b._matrix[3][2]));

	        //Column 4
	        C._matrix[0][3] =	((a._matrix[0][0] * b._matrix[0][3]) + 
						         (a._matrix[0][1] * b._matrix[1][3]) + 
						         (a._matrix[0][2] * b._matrix[2][3]) + 
						         (a._matrix[0][3] * b._matrix[3][3]));

	        C._matrix[1][3] =	((a._matrix[1][0] * b._matrix[0][3]) + 
						         (a._matrix[1][1] * b._matrix[1][3]) + 
						         (a._matrix[1][2] * b._matrix[2][3]) + 
						         (a._matrix[1][3] * b._matrix[3][3]));

	        C._matrix[2][3] =	((a._matrix[2][0] * b._matrix[0][3]) + 
						         (a._matrix[2][1] * b._matrix[1][3]) + 
						         (a._matrix[2][2] * b._matrix[2][3]) + 
						         (a._matrix[2][3] * b._matrix[3][3]));

	        C._matrix[3][3] =	((a._matrix[3][0] * b._matrix[0][3]) + 
						         (a._matrix[3][1] * b._matrix[1][3]) + 
						         (a._matrix[3][2] * b._matrix[2][3]) + 
						         (a._matrix[3][3] * b._matrix[3][3]));

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

        ////////////////////////////////////////////////////////////////////////////////////////////
	    //Name:				getTranslationMatrix.														
	    //In:				double x, y, z:		The amounts that the created  matrix should			
	    //										move a point by along each axis.					
	    //Out:				Matrix3D:           A new translation matrix					
	    //Description:		This method creates a homogeneous translation matrix that can be used	
	    //					to translate a vector.  The created matrix takes the form of:			
	    //																							
	    //				   |1.0		0.0		0.0		0.0|											
	    //				   |0.0		1.0		0.0		0.0|											
	    //				   |0.0		0.0		1.0		0.0|											
	    //				   | x		 y		 z		1.0|											
	    ////////////////////////////////////////////////////////////////////////////////////////////
        public static Matrix3D getTranslationMatrix(double x, double y, double z)
        {
            Matrix3D m = new Matrix3D();
	        m._matrix[0][0] = 1.0;	m._matrix[0][1] = 0.0;	m._matrix[0][2] = 0.0;	m._matrix[0][3] = 0.0;
	        m._matrix[1][0] = 0.0;	m._matrix[1][1] = 1.0;	m._matrix[1][2] = 0.0;	m._matrix[1][3] = 0.0;
	        m._matrix[2][0] = 0.0;	m._matrix[2][1] = 0.0;	m._matrix[2][2] = 1.0;	m._matrix[2][3] = 0.0;
	        m._matrix[3][0] = x;		m._matrix[3][1] = y;		m._matrix[3][2] = z;		m._matrix[3][3] = 1.0;
            return m;
        }


        ////////////////////////////////////////////////////////////////////////////////////////////
	    //Name:				Matrix3DRotate.														
	    //In:				double x, y, z:		The amounts that the created matrix  should		
	    //										rotate a point by along each axis.					
	    //Out:				Matrix3D:           A rotation matrix built to rotate a vector by a specified angle.			
	    //Description:		This method creates a homogeneous rotation matrix that can be used		
	    //					to rotate a vector.  Three matrices each representing an axis of		
	    //					rotation are created and then concatenated together to generate a		
	    //					complete rotation matrix.												
	    ////////////////////////////////////////////////////////////////////////////////////////////
        public static Matrix3D getRotationMatrix(double x, double y, double z)
        {
	        Matrix3D X = constructXRotationMat(x);
	        Matrix3D Y = constructXRotationMat(y);
	        Matrix3D Z = constructXRotationMat(z);

	        Matrix3D rot = Z * Y * X;
            return rot;
        }

        //Rotation around X axis
        private static Matrix3D constructXRotationMat(double angle) {
	        Matrix3D m = new Matrix3D();
	        double PI = Math.PI;

	        m._matrix[0][0] = 1.0;	m._matrix[0][1] = 0.0;					    m._matrix[0][2] = 0.0;					    m._matrix[0][3] = 0.0;
	        m._matrix[1][0] = 0.0;	m._matrix[1][1] = Math.Cos(angle*PI/180);	m._matrix[1][2] = Math.Sin(angle*PI/180);	m._matrix[1][3] = 0.0;
	        m._matrix[2][0] = 0.0;	m._matrix[2][1] = -Math.Sin(angle*PI/180);	m._matrix[2][2] = Math.Cos(angle*PI/180);	m._matrix[2][3] = 0.0;
	        m._matrix[3][0] = 0.0;	m._matrix[3][1] = 0.0;					    m._matrix[3][2] = 0.0;					    m._matrix[3][3] = 1.0;

	        return m;
        }

        //Rotation around Y axis
        private static Matrix3D constructYRotationMat(double angle) {
	        Matrix3D m = new Matrix3D();
	        double PI = Math.PI;

	        m._matrix[0][0] = Math.Cos(angle*PI/180);	m._matrix[0][1] = 0.0;	m._matrix[0][2] = -Math.Sin(angle*PI/180);	m._matrix[0][3] = 0.0;
	        m._matrix[1][0] = 0.0;					    m._matrix[1][1] = 1.0;	m._matrix[1][2] = 0.0;					    m._matrix[1][3] = 0.0;
	        m._matrix[2][0] = Math.Sin(angle*PI/180);	m._matrix[2][1] = 0.0;	m._matrix[2][2] = Math.Cos(angle*PI/180);	m._matrix[2][3] = 0.0;
	        m._matrix[3][0] = 0.0;					    m._matrix[3][1] = 0.0;	m._matrix[3][2] = 0.0;					    m._matrix[3][3] = 1.0;

	        return m;
        }

        //Rotation around Z axis
        private static Matrix3D constructZRotationMat(double angle) {
	        Matrix3D m = new Matrix3D();
	        double PI = Math.PI;

	        m._matrix[0][0] = Math.Cos(angle*PI/180);	m._matrix[0][1] = Math.Sin(angle*PI/180);	m._matrix[0][2] = 0.0;	m._matrix[0][3] = 0.0;
	        m._matrix[1][0] = -Math.Sin(angle*PI/180);	m._matrix[1][1] = Math.Cos(angle*PI/180);	m._matrix[1][2] = 0.0;	m._matrix[1][3] = 0.0;
	        m._matrix[2][0] = 0.0;					    m._matrix[2][1] = 0.0;					    m._matrix[2][2] = 1.0;	m._matrix[2][3] = 0.0;
	        m._matrix[3][0] = 0.0;					    m._matrix[3][1] = 0.0;					    m._matrix[3][2] = 0.0;	m._matrix[3][3] = 1.0;

	        return m;
        }

	    ////////////////////////////////////////////////////////////////////////////////////////////
	    //Name:				Matrix3DScale.															
	    //In:				double x, y, z:		The amounts that the created matrix should			
	    //										scale a point by along each axis.					
	    //Out:				None.																	
        //Postcondition:	A matrix is created that can be used to scale a vector by.				
	    //Description:		This method creates a homogeneous scaling matrix that can be used		
	    //					to scale a vector.  The created matrix takes the form of:				
	    //																							
	    //				   | x		0.0		0.0		0.0|											
	    //				   |0.0		 y		0.0		0.0|											
	    //				   |0.0		0.0		 z		0.0|											
	    //				   |0.0		0.0		0.0		1.0|											
	    ////////////////////////////////////////////////////////////////////////////////////////////
        public static Matrix3D getScaleMatrix(double x, double y, double z)
        {
            Matrix3D m = new Matrix3D();

	        m._matrix[0][0] = x;
	        m._matrix[1][1] = y;
	        m._matrix[2][2] = z;
	        m._matrix[3][3] = 1.0;

            return m;
        }

        //Alternative method, use methods implemented above
        //with values stripped from supplied vector.
        public void Matrix3DTranslate(Vector3D vec)
        {
            Matrix3D translationMatrix = getTranslationMatrix(vec.x, vec.y, vec.z);
	        Matrix3D result = this * translationMatrix;
            _matrix = result._matrix;
        }

        public void Matrix3DRotate(Vector3D vec)
        {
            Matrix3D rotationMatrix = getRotationMatrix(vec.x, vec.y, vec.z);
            Matrix3D result = this * rotationMatrix;
            _matrix = result._matrix;
        }

        public void Matrix3DScale(Vector3D vec)
        {
            Matrix3D scaleMatrix = getScaleMatrix(vec.x, vec.y, vec.z);
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
			        output += +_matrix[i][j] + "\t";			
		        }
		        output += "\n";
	        }
	        return output;
        }
    }
}
