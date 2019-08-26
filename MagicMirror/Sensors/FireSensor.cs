/* 
 * FireSensor.cs
 * 
 * Author: Austin Atteberry
 * 
 * Description: Defines the FireSensor class, which
 *              implements the Sensor interface
 * 
 */

namespace RaspberryPi.Sensors
{
    public class FireSensor : Sensor
    {
        private int PinNumber;
        private bool Initialized;

        /// <summary>
        /// Creates a FireSensor object
        /// </summary>
        /// <param name="PinNumber">wiringPi pin number of fire sensor</param>
        public FireSensor(int PinNumber)
        {
            this.PinNumber = PinNumber;    // Save pin number
            this.Initialized = false;      // Set initialization state
            this.InitializeSensor();       // Call initialization routine
        }

        /// <summary>
        /// Initializes the fire sensor pin
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
        /// Polls the fire sensor
        /// </summary>
        /// <returns>false if no fire is detected, true otherwise</returns>
        public bool PollSensor()
        {
            if (WiringPi.Core.digitalRead(this.PinNumber) == 1)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Sets the fire sensor's pin number
        /// </summary>
        /// <param name="PinNumber">wiringPi pin number</param>
        public void SetPinNumber(int PinNumber)
        {
            this.PinNumber = PinNumber;     // Save pin number
            this.Initialized = false;       // Reset initialization state
            this.InitializeSensor();        // Call initialization routine
        }

        /// <summary>
        /// Gets the fire sensor's pin number
        /// </summary>
        /// <returns>The pin number</returns>
        public int GetPinNumber()
        {
            return this.PinNumber;
        }
    }
}