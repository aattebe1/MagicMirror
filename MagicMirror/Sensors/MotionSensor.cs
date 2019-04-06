/* 
 * MotionSensor.cs
 * 
 * Author: Austin Atteberry
 * 
 * Description: Defines the MotionSensor class, which
 *              implements the Sensor interface
 * 
 */

namespace Sensors
{
	public class MotionSensor : Sensor
    {
        private int OutputPinNumber;
        private int InputPinNumber;
        private bool Initialized;

        /// <summary>
        /// Creates a new motion sensor instance
        /// </summary>
        /// <param name="PinNumber">wiringPi pin number of window sensor</param>
        public MotionSensor(int OutputPinNumber, int InputPinNumber)
        {
            this.OutputPinNumber = OutputPinNumber;    // Save output pin number
            this.InputPinNumber = InputPinNumber;      // Save input pin number
            this.Initialized = false;                  // Set initialization state
            this.InitializeSensor();                   // Call initialization routine
        }

        /// <summary>
        /// Initializes the door sensor pin
        /// </summary>
        public void InitializeSensor()
        {
            if (!(this.Initialized))
            {
                WiringPi.Core.pinMode(this.OutputPinNumber, 0);    // Set pin to output mode
                WiringPi.Core.pinMode(this.InputPinNumber, 0);     // Set pin to input mode
                this.Initialized = true;                           // Change initialization state
            }
        }

        /// <summary>
        /// Polls the door sensor
        /// </summary>
        /// <returns>false if no motion is detected, true otherwise</returns>
        public bool PollSensor()
        {
            return false;
        }

        /// <summary>
        /// Sets the motion sensor's output pin number
        /// </summary>
        /// <param name="PinNumber">wiringPi pin number</param>
        public void SetOutputPinNumber(int PinNumber)
        {
            this.OutputPinNumber = PinNumber;    // Save output pin number
            this.Initialized = false;            // Reset initialization state
            this.InitializeSensor();             // Call initialization routine
        }

        /// <summary>
        /// Sets the motion sensor's input pin number
        /// </summary>
        /// <param name="PinNumber">wiringPi pin number</param>
        public void SetInputPinNumber(int PinNumber)
        {
            this.InputPinNumber = PinNumber;     // Save input pin number
            this.Initialized = false;            // Reset initialization state
            this.InitializeSensor();             // Call initialization routine
        }

        /// <summary>
        /// Gets the motion sensor's output pin number
        /// </summary>
        /// <returns>The output pin number</returns>
        public int GetOutputPinNumber()
        {
            return this.OutputPinNumber;
        }

        /// <summary>
        /// Gets the motion sensor's input pin number
        /// </summary>
        /// <returns>The input pin number</returns>
        public int GetInputPinNumber()
        {
            return this.InputPinNumber;
        }
    }
}