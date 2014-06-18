using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeSim
{
    public class Matrix3DCreator
    {
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
            m[0, 0] = 1.0;  m[0, 1] = 0.0;  m[0, 2] = 0.0;  m[0, 3] = 0.0;
            m[1, 0] = 0.0;  m[1, 1] = 1.0;  m[1, 2] = 0.0;  m[1, 3] = 0.0;
            m[2, 0] = 0.0;  m[2, 1] = 0.0;  m[2, 2] = 1.0;  m[2, 3] = 0.0;
            m[3, 0] = x;    m[3, 1] = y;    m[3, 2] = z;    m[3, 3] = 1.0;
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
            Matrix3D Y = constructYRotationMat(y);
            Matrix3D Z = constructZRotationMat(z);

            Matrix3D rot = X * Y * Z;
            return rot;
        }

        //Rotation around X axis
        public static Matrix3D constructXRotationMat(double angle)
        {
            Matrix3D m = new Matrix3D();
            double PI = Math.PI;

            m[0, 0] = 1.0;  m[0, 1] = 0.0;                           m[0, 2] = 0.0;                             m[0, 3] = 0.0;
            m[1, 0] = 0.0;  m[1, 1] = Math.Cos(angle * PI / 180);    m[1, 2] = -Math.Sin(angle * PI / 180);     m[1, 3] = 0.0;
            m[2, 0] = 0.0;  m[2, 1] = Math.Sin(angle * PI / 180);    m[2, 2] = Math.Cos(angle * PI / 180);      m[2, 3] = 0.0;
            m[3, 0] = 0.0;  m[3, 1] = 0.0;                           m[3, 2] = 0.0;                             m[3, 3] = 1.0;

            return m;
        }

        //Rotation around Y axis
        public static Matrix3D constructYRotationMat(double angle)
        {
            Matrix3D m = new Matrix3D();
            double PI = Math.PI;

            m[0, 0] = Math.Cos(angle * PI / 180);   m[0, 1] = 0.0;  m[0, 2] = Math.Sin(angle * PI / 180);  m[0, 3] = 0.0;
            m[1, 0] = 0.0;                          m[1, 1] = 1.0;  m[1, 2] = 0.0;                          m[1, 3] = 0.0;
            m[2, 0] = -Math.Sin(angle * PI / 180);   m[2, 1] = 0.0;  m[2, 2] = Math.Cos(angle * PI / 180);   m[2, 3] = 0.0;
            m[3, 0] = 0.0;                          m[3, 1] = 0.0;  m[3, 2] = 0.0;                          m[3, 3] = 1.0;

            return m;
        }

        //Rotation around Z axis
        public static Matrix3D constructZRotationMat(double angle)
        {
            Matrix3D m = new Matrix3D();
            double PI = Math.PI;

            m[0, 0] = Math.Cos(angle * PI / 180);   m[0, 1] = -Math.Sin(angle * PI / 180);   m[0, 2] = 0.0;  m[0, 3] = 0.0;
            m[1, 0] = Math.Sin(angle * PI / 180);  m[1, 1] = Math.Cos(angle * PI / 180);   m[1, 2] = 0.0;  m[1, 3] = 0.0;
            m[2, 0] = 0.0;                          m[2, 1] = 0.0;                          m[2, 2] = 1.0;  m[2, 3] = 0.0;
            m[3, 0] = 0.0;                          m[3, 1] = 0.0;                          m[3, 2] = 0.0;  m[3, 3] = 1.0;

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

            m[0, 0] = x;
            m[1, 1] = y;
            m[2, 2] = z;
            m[3, 3] = 1.0;

            return m;
        }
    }
}
