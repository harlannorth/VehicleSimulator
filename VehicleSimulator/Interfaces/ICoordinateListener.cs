using System;

namespace VehicleSimulator
{
	/// <summary>
	/// An interfacethat defines having a function to listen for the NewCoordinate event
	/// </summary>
	public interface ICoordinateListener
	{
		void GotNewCoordinate(object sender, ICoordinate coordinates);
	}
}
