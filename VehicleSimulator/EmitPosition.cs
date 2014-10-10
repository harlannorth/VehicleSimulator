using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace VehicleSimulator
{

    public class EmitPosition
    {

		/// <summary>
		/// Constructor sets up the vehicle position emitting object
		/// Takes in an initial speed
		/// set the timespan to wait between emission based on that
		/// </summary>
		/// <param name="initialSpeed">Initial speed the vehicle is travelling at</param>
		public EmitPosition(int initialSpeed, List<WayPoint> waypoints)
		{
			//create event for when speed changes

			_currentSpeed = initialSpeed;
			_emissionWait = this.TimeSpanFactory(_currentSpeed);
			_waypoints = waypoints;
			MilesTravelled = 0;
		}

		/// <summary>
		/// the current speed of the vehicle
		/// the 'Go' function uses this to calculate distance travelled
		/// also used to determine how long to wait between emissions
		/// </summary>
		private int _currentSpeed;

		/// <summary>
		/// period to wait before giving a new location
		/// </summary>
		private TimeSpan _emissionWait;

		public double MilesTravelled { get; set; }

		public int CurrentSpeed { get { return _currentSpeed; } }

		public void ChangeSpeed(int newSpeed)
		{
			_currentSpeed = newSpeed;
			_emissionWait = this.TimeSpanFactory(_currentSpeed);
		}

		public List<WayPoint> Waypoints { get { return _waypoints; } }

		private List<WayPoint> _waypoints;

		/// <summary>
		/// Function that contains a loop that keeps giving updates on the vehicle's location
		/// </summary>
		/// <param name="cancel">a token to allow terminating the loop beyond the expected reasons</param>
		public void Control()
		{
			double milesToNextWayPoint = 0;

			foreach (WayPoint point in Waypoints)
			{

				milesToNextWayPoint = point.MileToNextWayPoint;

				do
				{
					System.Threading.Thread.Sleep(_emissionWait);
					var travelled = DistanceTravelled(_emissionWait, CurrentSpeed);
					milesToNextWayPoint = milesToNextWayPoint - travelled;
					MilesTravelled = MilesTravelled + travelled;
					Emit();
				}
				while (milesToNextWayPoint > 0);
			}

		}

		public double DistanceTravelled(TimeSpan span, int speed)
		{
			double distancetravelled = 0;

			distancetravelled = span.TotalSeconds * ((double)speed/3600);

			return distancetravelled;

		}

		/// <summary>
		/// The event we are emitting containing a set of Coordinates
		/// </summary>
		public event EventHandler<GeoCoordinate> NewCoordinate;

		/// <summary>
		/// functions that fires off the emission
		/// Could be overridden to get different behavior 
		/// </summary>
		public virtual void Emit()
		{
			NewCoordinate(this, new GeoCoordinate());
		}

		/// <summary>
		/// Takes in a speed and returns how long to wait before emitting again
		/// </summary>
		/// <param name="speed">The speed of the vehicle</param>
		/// <returns>TimeSpan object set to how long to wait until emitting location again</returns>
		public TimeSpan TimeSpanFactory(int speed)
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


    }
}
