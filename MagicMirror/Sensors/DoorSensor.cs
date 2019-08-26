/* 
 * DoorSensor.cs
 * 
 * Author: Austin Atteberry
 * 
 * Description: Defines the DoorSensor class, which
 *              implements the Sensor interface
 * 
 */

namespace RaspberryPi.Sensors
{
	public class DoorSensor : Sensor
    {
        private int PinNumber;
        private bool Initialized;

        /// <summary>
        /// Creates a new door sensor instance
        /// </summary>
        /// <param name="PinNumber">wiringPi pin number of door sensor</param>
		public DoorSensor(int PinNumber)
        {
            this.PinNumber = PinNumber;    // Save pin number
            this.Initialized = false;      // Set initialization state
            this.InitializeSensor();       // Call initialization routine
        }

        /// <summary>
        /// Initializes the door sensor pin
        /// </summary>
        public void InitializeSensor()
        {
            if (!(this.Initialized))
            {
                WiringPi.Core.pinMode(this.PinNumber, WiringPi.Constants.INPUT);    // Set pin to input mode
                this.Initialized = true;                                            // Change initialization state
            }
        }

        /// <summary>
        /// Polls the door sensor
        /// </summary>
        /// <returns>false if door is closed, true otherwise</returns>
        public bool PollSensor()
        {
            if (WiringPi.Core.digitalRead(this.PinNumber) == 1)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Sets the door sensor's pin number
        /// </summary>
        /// <param name="PinNumber">wiringPi pin number</param>
        public void SetPinNumber(int PinNumber)
        {
            this.PinNumber = PinNumber;     // Save pin number
            this.Initialized = false;       // Reset initialization state
            this.InitializeSensor();        // Call initialization routine
        }

        /// <summary>
        /// Gets the door sensor's pin number
        /// </summary>
        /// <returns>The pin number</returns>
        public int GetPinNumber()
        {
            return this.PinNumber;
        }
    }
}