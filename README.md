VehicleSimulator
================
The solution consists of two projects:
- The VehicleSimulator is an assembly designed to emulate a vehicle travelling at different speeds from waypoint to waypoint.
The main class in the assembly is Vehicle. Vehicle is constructed with an initial speed of the Vehicle and the number of way points 
that will be crossed. Each waypoint consists of a class which tells the vehicle the distance to the next waypoint.

To receieve a set of coordinates a class must subscribe to the events being emitted by the Vehicle instance.



- The VehicleSimulatorTest is a series of unit tests for the VehicleSimulator assembly. 
