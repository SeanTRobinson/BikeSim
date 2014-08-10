BikeSim
=======

*This Project is temporarily suspended as I focus on learning a new technology stack required for a new position.  I will restart work on the engine once I have settled into the new role.*

A physics library geared towards the modelling of a bicycle in motion.

Abstract
This project demonstrates the way in which a bicycle can be mathematically modelled. Extensive research and 
development has been completed iteratively. In order to conclusively prove that the calculations used in the 
final solution are accurate and that they adhere to real world mechanics, experiments have been devised
and carried out at each stage in development. 

When calculating the acceleration of the bicycle at each cycle, it has been shown that environmental 
factors such as rolling resistance and aerodynamic drag will have a substantial impact on the overall 
performance.  The experiments show that the force from rolling resistance, that is the friction between 
the tyre and the ground, remains constant at any velocity but will have an increased reduction in power
as the velocity increases. This increase is linear with velocity but is dependent on the rider’s weight.
Experimentation into aerodynamic drag has shown that it is usual for air resistance to increase cubically 
and to have a significantly larger effect on the rider. Drag will account for an approximately 60% of 
all power loss at lower speeds and will increase to almost 100% as the bicycle travels along a flat
surface and is accelerating.

The third environmental factor that has been modelled is gravity. Gravity only affects the rider in any
meaningful way when the bicycle is traversing a gradient. When moving downwards, gravity has been
shown to apply an accelerative force directly proportional to the rider’s weight and the steepness of the
slope. This increase in speed can account for nearly 100% of total power being used to accelerate the bicycle
at extreme gradients.

For uphill sections, the opposite has been shown to be true. The same factors mentioned above will apply a
negatively accelerative force on the rider and reduce the overall acceleration. Extreme inclines will account
for nearly 100% of power loss. Even though this increase is linear, gravity will account for so much power
loss at steeper gradients as the reduction from air resistance is limited by the current speed of the cyclist.

Experiments have also been demonstrated that show how a 4th order Runge-Kutta integration method can
be used to derive distances to move at each time step. Experimentation has shown that this method is
stable, accurate to a very high degree and can be easily modified to model alternative data such as spring
dynamics. The final stage of experiments with the RK4 method show it to be accurate when used in
conjunction with the other aspects and that the specific method chosen produces very smooth output with
small enough time steps, which is demonstrated in the final product.

The final aspect that was mathematically modelled in this solution is the lean of the bicycle. Experiments
have shown that the lean is directly

As this project is developed, all research pertaining to the work will be formatted and included.
