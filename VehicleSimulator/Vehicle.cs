using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace VehicleSimulator
{

    public class Vehicle
    {

		/// <summary>
		/// Constructor sets up the vehicle 
		/// Takes in an initial speed and a list of waypoints to travel through
		/// </summary>
		/// <param name="initialSpeed">Initial speed the vehicle is travelling at</param>
		/// <param name="waypoints">A list of way points</param>
		public Vehicle(int initialSpeed, List<WayPoint> waypoints)
		{
			ChangeSpeed(initialSpeed);
			Waypoints = waypoints;
			MilesTravelled = 0;
		}


		/// <summary>
		/// period to wait before giving a new location
		/// </summary>
		private TimeSpan _emissionWait;

		/// <summary>
		/// Number of Miles travelled 
		/// </summary>
		public double MilesTravelled { get; set; }

		/// <summary>
		/// the current speed of the vehicle
		/// the 'Go' function uses this to calculate distance travelled
		/// also used to determine how long to wait between emissions
		/// </summary>
		public int CurrentSpeed { get; private set; }	

		/// <summary>
		/// Function to update the speed the vehicle is travelling at.
		/// </summary>
		/// <param name="newSpeed">New speed in MPH</param>
		public void ChangeSpeed(int newSpeed)
		{
			CurrentSpeed = newSpeed;
			_emissionWait = TimeSpanFactory(CurrentSpeed);
		}

		/// <summary>
		/// List of points the vehicle will travel through
		/// </summary>
		public List<WayPoint> Waypoints { get; private set; }

		/// <summary>
		/// Function that contains a loop that keeps giving updates on the vehicle's location
		/// </summary>
		/// <param name="cancel">a token to allow terminating the loop beyond the expected reasons</param>
		public void Drive()
		{
			double milesToNextWayPoint = 0;

			//loop until the second to last element
			for (int i = 0; i <= Waypoints.Count()-2; i++)
			{
			
				var currentPosition = Waypoints[i];
				var nextPosition = Waypoints[i + 1];

				milesToNextWayPoint = currentPosition.DistanceToNextWayPoint(nextPosition.Position);

				//do this until we reach the waypoint
				do
				{
					//wait for the vehicle to move the distance until it is time to emit a location again
					System.Threading.Thread.Sleep(_emissionWait);
					//find out how far was travelled 
					var travelled = DistanceTravelled(_emissionWait, CurrentSpeed);
					//update how far until the next waypoint is reached
					milesToNextWayPoint = milesToNextWayPoint - travelled;
					//update total miles travelled
					MilesTravelled = MilesTravelled + travelled;
					//emit the coordinates to any listeners (actual coordinates have not been calculated
					NewCoordinate(this, new Coordinate());
				}
				while (milesToNextWayPoint > 0);
			}

		}

		/// <summary>
		/// The event we are emitting containing a set of Coordinates
		/// </summary>
		public event EventHandler<ICoordinate> NewCoordinate;

		/// <summary>
		/// Takes in a speed and returns how long to wait before emitting again
		/// </summary>
		/// <param name="speed">The speed of the vehicle</param>
		/// <returns>TimeSpan object set to how long to wait until emitting location again</returns>
		public static TimeSpan TimeSpanFactory(int speed)
		{
			//if we are travelling at less that 25 mph return every 9 seconds
 			if (speed <= 25)
			{
				return new TimeSpan(0, 0, 9);
			}
			//if we are above 25 and got past the first if but 50 or below the return every 6 seconds
			else if (speed <= 50)
			{
				return new TimeSpan(0, 0, 6);
			}
			else // if we are above 50 then we always return every 3 seconds
			{
				return new TimeSpan(0, 0, 3);
			}
		}

		/// <summary>
		/// Get the distance, in miles, one travels in a peroid of time at a particular speed
		/// </summary>
		/// <param name="span"amount of time the travel is allowed to go on for</param>
		/// <param name="speed">The speed at which the travel is happening</param>
		/// <returns></returns>
		public static double DistanceTravelled(TimeSpan span, int speed)
		{
			double distancetravelled = 0;

			distancetravelled = span.TotalSeconds * ((double)speed / 3600);

			return distancetravelled;

		}



    }
}
