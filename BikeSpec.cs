using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeSim
{
    class BikeSpec
    {
<<<<<<< HEAD
=======
        public BikeSpec (
            double ObjectWeight = 80.0,
            double casterAngleInDegrees = 18.0,
            double frontalAreaInMSqrd = 0.5,
            double percentDriveTrainLoss = 3,
            double wheelBaseInCM = 115.0,
            double wheelRadiusInCM = 20.0,
            double tyreThicknessInCM = 2.5)
        {
            this.objectWeight = objectWeight;
            this.casterAngleInDegrees = casterAngleInDegrees;
            this.frontalAreaInMSqrd = frontalAreaInMSqrd;
            this.percentDriveTrainLoss = percentDriveTrainLoss;
            this.wheelBaseInCM = wheelBaseInCM;
            this.wheelRadiusInCM = wheelRadiusInCM;
            this.tyreThicknessInCM = tyreThicknessInCM;
        }

        double objectWeight
        {
            get { return objectWeight; }
            set
            {
                if (objectWeight > 0.0)
                {
                    this.objectWeight = objectWeight;
                }
                else
                {
                    throw new ArgumentException("Object weight cannot be less than 0");
                }
            }
        }

        double casterAngleInDegrees
        {
            get { return casterAngleInDegrees; }
            set
            {
                if (casterAngleInDegrees > 0.0)
                {
                    this.casterAngleInDegrees = casterAngleInDegrees;
                }
                else
                {
                    throw new ArgumentException("Caster angle cannot be less than 0");
                }
            }
        }

        double frontalAreaInMSqrd
        {
            get { return frontalAreaInMSqrd; }
            set
            {
                if (frontalAreaInMSqrd > 0.0)
                {
                    this.objectWeight = frontalAreaInMSqrd;
                }
                else
                {
                    throw new ArgumentException("Frontal area cannot be less than 0");
                }
            }
        }

        double percentDriveTrainLoss
        {
            get { return percentDriveTrainLoss; }
            set
            {
                if (percentDriveTrainLoss > 0.0)
                {
                    this.percentDriveTrainLoss = percentDriveTrainLoss;
                }
                else
                {
                    throw new ArgumentException("Drive train loss cannot be less than 0");
                }
            }
        }

        double wheelBaseInCM
        {
            get { return wheelBaseInCM; }
            set
            {
                if (wheelBaseInCM > 0.0)
                {
                    this.wheelBaseInCM = wheelBaseInCM;
                }
                else
                {
                    throw new ArgumentException("Wheelbase cannot be less than 0");
                }
            }
        }

        double wheelRadiusInCM
        {
            get { return wheelRadiusInCM; }
            set
            {
                if (wheelRadiusInCM > 0.0)
                {
                    this.wheelRadiusInCM = wheelRadiusInCM;
                }
                else
                {
                    throw new ArgumentException("Wheel radius cannot be less than 0");
                }
            }
        }

        double tyreThicknessInCM
        {
            get { return tyreThicknessInCM; }
            set
            {
                if (tyreThicknessInCM > 0.0)
                {
                    this.tyreThicknessInCM = tyreThicknessInCM;
                }
                else
                {
                    throw new ArgumentException("Tyre thickness cannot be less than 0");
                }
            }
        }

>>>>>>> Updates to Vector3D and Matrix3D
    }
}
