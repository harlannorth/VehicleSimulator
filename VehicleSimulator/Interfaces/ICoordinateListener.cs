using System;

namespace VehicleSimulator
{
	public interface ICoordinateListener
	{
		void GotNewCoordinate(object sender, ICoordinate coordinates);
	}
}
