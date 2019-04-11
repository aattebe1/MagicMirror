/* 
 * Core.cs
 * 
 * Author: Austin Atteberry
 * 
 * Description: The entry point for the
 *              MagicMirror program
 * 
 */

namespace MagicMirror3
{
    public static class Core
    {
        static void Main(string[] args)
        {
            WiringPi.Core.wiringPiSetup();
            System.Windows.Forms.Application.Run(new GUI.Display());
        }
    }
}
