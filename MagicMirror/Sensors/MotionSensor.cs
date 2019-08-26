/* 
 * MotionSensor.cs
 * 
 * Author: Austin Atteberry
 * 
 * Description: Defines the MotionSensor class, which
 *              implements the Sensor interface
 * 
 */

namespace RaspberryPi.Sensors
{
	public class MotionSensor : Sensor
    {
        private int PinNumber;
        private bool Initialized;

        /// <summary>
        /// Creates a new motion sensor instance
        /// </summary>
        /// <param name="PinNumber">wiringPi pin number of window sensor</param>
        public MotionSensor(int PinNumber)
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
                WiringPi.Core.pinMode(this.PinNumber, WiringPi.Constants.INPUT);    // Set pin to output mode
                this.Initialized = true;                                            // Change initialization state
            }
        }

        /// <summary>
        /// Polls the door sensor
        /// </summary>
        /// <returns>false if no motion is detected, true otherwise</returns>
        public bool PollSensor()
        {
            if (WiringPi.Core.digitalRead(this.PinNumber) == 1)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Sets the motion sensor's pin number
        /// </summary>
        /// <param name="PinNumber">wiringPi pin number</param>
        public void SetPinNumber(int PinNumber)
        {
            this.PinNumber = PinNumber;    // Save output pin number
            this.Initialized = false;      // Reset initialization state
            this.InitializeSensor();       // Call initialization routine
        }

        /// <summary>
        /// Gets the motion sensor's pin number
        /// </summary>
        /// <returns>The pin number</returns>
        public int GetPinNumber()
        {
            return this.PinNumber;
        }
    }
}