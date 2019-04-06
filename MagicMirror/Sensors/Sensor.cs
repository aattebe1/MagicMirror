/* 
 * Sensors.cs
 * 
 * Author: Austin Atteberry
 * 
 * Description: 
 * 
 */

namespace Sensors
{
	public interface Sensor
    {
        void InitializeSensor();
        bool PollSensor();
    }
}