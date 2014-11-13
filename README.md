VehicleSimulator
================
The solution consists of two projects:
- The VehicleSimulator is an assembly designed to emulate a vehicle travelling at different speeds from waypoint to waypoint.
The main class in the assembly is Vehicle. Vehicle is constructed with an initial speed of the Vehicle and a list of way points 
that will be crossed. Each waypoint consists of a longitude and lattitude of the waypoint and the ability to calculate the distance between itself and another waypoint.

Also in this project is ICoordinateListener. This is an interface that an class may implement to see the pattern of how to create a listener for coordinate information. To receieve a set of coordinates a class must subscribe to the events being emitted by the Vehicle instance.


- The VehicleTest is a series of unit tests and a sample listener. Listener.cs implements VehicleSimulator's ICoordinateListener 




- The VehicleSimulatorTest is a series of unit tests for the VehicleSimulator assembly. 
