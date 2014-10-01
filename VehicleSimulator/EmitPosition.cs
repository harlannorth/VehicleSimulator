using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleSimulator
{
    public class EmitPosition
    {
		public string Control(int speed, System.Threading.CancellationToken cancel)
		{

			
			//wait.

			//as long as we haven't cancelled this speed
			while(!cancel.IsCancellationRequested)
			{
				System.Threading.Thread.Sleep(TimeSpanFactory(speed));
				Emit();
			}

			return null;

		}

		public event EventHandler<GeoCoordinate> NewCoordinate;

		public void Emit()
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
