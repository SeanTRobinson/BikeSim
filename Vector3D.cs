using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeSim
{
    ////////////////////////////////////////////////////////////////////////////////////////////
    //Name:			Vector3D																	
    //Author:		Sean Robinson (Sean.T.Robinson@googemail.com)														
    //Description:	This class supplies a user with all of the 	necessary functionality to
    //              create and manipulate vectors.  A Vector3D object can be used to 
    //              represent either points in 3D space (Called point vectors) or directional 
    //              vectors that can be used to move points.  This class is	often used in 
    //              conjunction with the supplied Matrix3D class.  Vectors are all of the
    //              type [X, Y, Z, W].												
    ////////////////////////////////////////////////////////////////////////////////////////////
    class Vector3D
    {
        public double x
        {
            get { return this.x; }
            set
            {
                this.x = x;
                calcLength();
            }
        }

        public double y
        {
            get { return this.y; }
            set
            {
                this.y = y;
                calcLength();
            }
        }

        public double z
        {
            get { return this.z; }
            set
            {
                this.z = z;
                calcLength();
            }
        }

        public double w
        {
            get { return this.w; }
            set
            {
                this.w = w;
                calcLength();
            }
        }

        public double _length;
        public double length()
        {
            calcLength();
            return _length;
        }
        private void setLength(double len)
        {
            _length = len;
        }

        public Vector3D(double xIn = 0.0, double yIn = 0.0, double zIn = 0.0)
        {
	        x = xIn;
	        y = yIn;
	        z = zIn;
	        w = 1.0;
	        calcLength();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////
        //Name:				calcLength.																
        //Postcondition:	The length of the vector (It's magnitude) is calculated.				
        //Description:		The magnitude of a vector is used to normalise it, this is then used	
        //					in the creation or modification of direction vectors.					
        ////////////////////////////////////////////////////////////////////////////////////////////
        public void calcLength()
        {
	        _length = Math.Sqrt((x * x) + (y * y) + (z * z));
        }

        ////////////////////////////////////////////////////////////////////////////////////////////
        //Name:				normalise.																
        //Postcondition:	The vector is normalised such that its magnitude is equal to 1.			
        //Description:		Normalised vectors are used to modify points, a normalised vector is one
        //					where it's magnitude it equal to 1, this is also called a unit length	
        //					vector.																	
        ////////////////////////////////////////////////////////////////////////////////////////////
        public void normalise()
        {
	        calcLength();
	        x /= _length;
	        y /= _length;
	        z /= _length;
        }
        public Vector3D getNormalised()
        {
	        calcLength();
	        Vector3D v = new Vector3D(x, y, z);
	        v.normalise();
	        return v;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////
        //Name:				dot																		
        //In:				Vector3D vec:	The second vector.										
        //Out:				double:			The dot (Or Scalar) product.							
        //Precondition:		Both vectors should be of equal length for a correct result.																	
        //Postcondition:	The dot product of both vectors is returned.							
        //Description:		The dot product of two vectors can be used to determine the angle		
        //					between them by taking the arc (Inverse) cosine of the dot product.  	
        //					This value can be used to determine the rotation required to transform	
        //					a vector.																		
        ////////////////////////////////////////////////////////////////////////////////////////////
        public double dot(Vector3D vec) {
	        double dotProduct = 0.0;
	        Vector3D vec1 = getNormalised();
	        Vector3D vec2 = vec.getNormalised();

	        dotProduct = (	(vec1.x * vec2.x) +
					        (vec1.y * vec2.y) +
					        (vec1.z * vec2.z));

	        return dotProduct;
        }
        public static double dot(Vector3D lhs, Vector3D rhs)
        {
            return lhs.dot(rhs);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////
        //Name:				cross																	
        //In:				Vector3D vec:	The second vector.										
        //Out:				Vector3D:		The cross product of the two vectors.					
        //Precondition:		Both vectors should be of equal length for a correct result.																	
        //Postcondition:	The cross product of both vectors is returned.							
        //Description:		The cross product of two vectors can be used to derive the vector that	
        //					is perpendicular to both of them, this gives the normal of the plane	
        //					that both vectors reside on.											
        ////////////////////////////////////////////////////////////////////////////////////////////
        public Vector3D cross(Vector3D vec)
        {
	        Vector3D crossProduct = new Vector3D(0.0, 0.0, 0.0);
	        Vector3D vec1 = getNormalised();
	        Vector3D vec2 = vec.getNormalised();

	        crossProduct.x = ((vec1.y * vec2.z) - (vec1.z * vec2.y));
	        crossProduct.y = ((vec1.z * vec2.x) - (vec1.x * vec2.z));
	        crossProduct.z = ((vec1.x * vec2.y) - (vec1.y * vec2.x));

	        return crossProduct;
        }
        public static Vector3D cross(Vector3D lhs, Vector3D rhs)
        {
            return lhs.cross(rhs);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////
        //Name:				getAngle																
        //In:				Vector3D vec:	The second vector.										
        //Out:				double:			Angle between the vectors.								
        //Precondition:		Both vectors should be of equal length for a correct result.																	
        //Postcondition:	The angle between both vectors is returned.								
        //Description:		The angle between the vectors is calculated by taking the arc cosine	
        //					of the dot product between them.										
        ////////////////////////////////////////////////////////////////////////////////////////////
        public double getAngle(Vector3D vec)
        {
	        double dotProduct = dot(vec);
	        return Math.Acos(dotProduct);
        }
        public static double getAngle(Vector3D lhs, Vector3D rhs)
        {
            return lhs.getAngle(rhs);
        }

        //Adds corresponding variables,
        public static Vector3D operator+ (Vector3D lhs, Vector3D rhs)
        {
	        Vector3D temp = new Vector3D();
	        temp.x = lhs.x + rhs.x;
	        temp.y = lhs.y + rhs.y;
	        temp.z = lhs.z + rhs.z;
	        return (temp);
        }

        //Subtracts corresponding variables,
        public static Vector3D operator- (Vector3D lhs, Vector3D rhs)
        {
	        Vector3D temp = new Vector3D();
	        temp.x = lhs.x - rhs.x;
            temp.y = lhs.y - rhs.y;
            temp.z = lhs.z - rhs.z;
	        return (temp);
        }

        //Multiples each variable in the vector by a scalar,
        public static Vector3D operator *(Vector3D vec, double scalar)
        {
	        Vector3D temp = new Vector3D();
	        temp.x = vec.x * scalar;
	        temp.y = vec.y * scalar;
	        temp.z = vec.z * scalar;
	        return (temp);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////
        //Name:				* operator																
        //In:				Matrix m:	The matrix to transform with.								
        //Out:				Vector3D:	A copy of the vector that has been transformed.						
        //Postcondition:	A  new vector that represents the transformed original is returned.		
        //Description:		The * operator, when used in conjunction with a matrix instead of a		
        //					vector, applies a transformation to a copy of the vector using the		
        //					matrix.  This transformation is completed using the Matrix3D class.		
        ////////////////////////////////////////////////////////////////////////////////////////////
        public static Vector3D operator *(Vector3D vec, Matrix3D m)
        {
	        Vector3D temp = new Vector3D(vec.x, vec.y, vec.z);
	        temp.transform(m);
	        return (temp);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////
        //Name:				rotate																	
        //In:				double x, y, z:		The amount to rotate around the specified axis.		
        //Postcondition:	The vector is rotated around each axis by the values specified.			
        //Description:		The process involved in rotating the vector by the matrix is covered 	
        //					in greater detail in the Matrix3D file.  Generally, three matrices are
        //					created that represent the rotations around the X, Y and Z axis, these	
        //					are then concatenated.  The output matrix is used to transform the		
        //					vector.																	
        ////////////////////////////////////////////////////////////////////////////////////////////
        public void rotate(double x, double y, double z)
        {
	        Matrix3D m = Matrix3DCreator.getRotationMatrix(x, y, z);
	        transform(m);	
        }

        ////////////////////////////////////////////////////////////////////////////////////////////
        //Name:				scale																	
        //In:				double x, y, z:		The amount to multiply the specified axis by.																					
        //Postcondition:	The vector is scaled on each axis by the values specified.				
        //Description:		Scaling a vector simply	multiplies each axis by the appropriate			
        //					parameter.  This is accomplished through the use of automatically		
        //					generated matrices.														
        ////////////////////////////////////////////////////////////////////////////////////////////
        public void scale(double x, double y, double z)
        {
            Matrix3D m = Matrix3DCreator.getScaleMatrix(x, y, z);
	        transform(m);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////
        //Name:				translate																
        //In:				double x, y, z:		The amount to translate the specified axis by.		
        //Postcondition:	The vector is translated on each axis by the values specified.			
        //Description:		Translating a vector simply	moving each axis by the appropriate			
        //					parameter.  This is accomplished through the use of automatically		
        //					generated matrices.														
        ////////////////////////////////////////////////////////////////////////////////////////////
        public void translate(double x, double y, double z)
        {
            Matrix3D m = Matrix3DCreator.getTranslationMatrix(x, y, z);
	        transform(m);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////
        //Name:				transform																
        //In:				Matrix m:		The matrix to transform with.																	//
        //Postcondition:	The vector is transformed using the supplied matrix.					
        //Description:		This is the method that transforms all vectors using the generated		
        //					matrices.  Matrices are generated depending on which function call was	
        //					used, those functions then call for the vector to be transformed here.	
        ////////////////////////////////////////////////////////////////////////////////////////////
        public void transform(Matrix3D m)
        {
	        x = ((m[0, 0] * x) + 
		         (m[1, 0] * y) + 
		         (m[2, 0] * z) + 
		         (m[3, 0]));

	        y = ((m[0, 1] * x) + 
		         (m[1, 1] * y) + 
		         (m[2, 1] * z) + 
		         (m[3, 1]));

	        z = ((m[0, 2] * x) + 
		         (m[1, 2] * y) + 
		         (m[2, 2] * z) + 
		         (m[3, 2]));

	        w = ((m[0, 3] * x) + 
		         (m[1, 3] * y) + 
		         (m[2, 3] * z) + 
		         (m[3, 3]));
        }

        //Returns the vector in string format: [x, y, z]
        public override string ToString()
        {
	        return "[" + x + ", " + y + ", " + z + "]";
        }
    }
}
