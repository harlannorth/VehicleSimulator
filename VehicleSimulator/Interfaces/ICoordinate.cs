using System;
namespace VehicleSimulator
{
	/// <summary>
	/// Interface that defines having a latitude and longitude on an instance
	/// </summary>
	public interface ICoordinate
	{
		double Latitude { get; }
		double Longitude { get; }
	}
}
