/* 
 * Sensors.cs
 * 
 * Author: Austin Atteberry
 * 
 * Description: 
 * 
 */

namespace RaspberryPi.Sensors
{
	public interface Sensor
    {
        void InitializeSensor();
        bool PollSensor();
        void SetPinNumber(int PinNumber);
        int GetPinNumber();
    }
}