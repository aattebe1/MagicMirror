 /*
 * WiringPi.cs
 *
 * Author Austin Atteberry
 *
 * Description: A wrapper class for the WiringPi C functions
 * 
 */
 
 using System;
 using System.Runtime.InteropServices;

namespace WiringPi
{
	public class Constants
	{
		public static int WPI_MODE_PINS = 0;
		public static int WPI_MODE_GPIO = 1;
		public static int WPI_MODE_GPIO_SYS = 2;
		public static int WPI_MODE_PHYS = 3;
		public static int WPI_MODE_PIFACE = 4;
		public static int WPI_MODE_UNINITIALISED = -1;
		public static int INPUT = 0;
		public static int OUTPUT = 1;
		public static int PWM_OUTPUT = 2;
		public static int GPIO_CLOCK = 3;
		public static int SOFT_PWM_OUTPUT = 4;
		public static int SOFT_TONE_OUTPUT = 5;
		public static int PWM_TONE_OUTPUT = 6;
		public static int LOW = 0;
		public static int HIGH = 1;
		public static int PUD_OFF = 0;
		public static int PUD_DOWN = 1;
		public static int PUD_UP = 2;
		public static int PWM_MODE_MS = 0;
		public static int PWM_MODE_BAL = 1;
		public static int INT_EDGE_SETUP = 0;
		public static int INT_EDGE_FALLING = 1;
		public static int INT_EDGE_RISING = 2;
		public static int INT_EDGE_BOTH = 3;
		public static int PI_MODEL_A = 0;
		public static int PI_MODEL_B = 1;
		public static int PI_MODEL_AP = 2;
		public static int PI_MODEL_BP = 3;
		public static int PI_MODEL_2 = 4;
		public static int PI_ALPHA = 5;
		public static int PI_MODEL_CM = 6;
		public static int PI_MODEL_07 = 7;
		public static int PI_MODEL_3 = 8;
		public static int PI_MODEL_ZERO = 9;
		public static int PI_MODEL_CM3 = 10;
		public static int PI_MODEL_ZERO_W = 12;
		public static int PI_VERSION_1 = 0;
		public static int PI_VERSION_1_1 = 1;
		public static int PI_VERSION_1_2 = 2;
		public static int PI_VERSION_2 = 3;
		public static int PI_MAKER_SONY = 0;
		public static int PI_MAKER_EGOMAN = 1;
		public static int PI_MAKER_EMBEST = 2;
		public static int PI_MAKER_UNKNOWN = 3;
	}

	/// <summary>
	/// Core Wiring Pi methods
	/// </summary>
	/// <remarks>
	/// wiringPiSetup(), wiringPiSetupSys(), wiringPiSetupGpio(), or wiringPiSetupPhys() must
	/// be called at the start of your program or your program will fail to work correctly.
	/// </remarks>
	public class Core
	{
		/// <summary>
		/// Determines whether Wiring Pi successful
		/// </summary>
		/// <param name="fatal">0 or 1</param>
		/// <param name="message">Message</param>
		/// <returns>0 if successful, -1 if unsuccessful</returns>
		[DllImport("libwiringPi.so", EntryPoint = "wiringPiFailure")]
		public static extern int wiringPiFailure(int fatal, ref char message, params object[] args);

		/// <summary>
		/// Returns the current Wiring Pi version number
		/// </summary>
		/// <param name="major">Major version</param>
		/// <param name="minor">Minor version</param>
		[DllImport("libwiringPi.so", EntryPoint = "wiringPiVersion")]
		public static extern void WiringPiSetup(ref int major, ref int minor);

		/// <summary>
		/// This initialises Wiring Pi and assumes that the calling program is going to be using the Wiring Pi pin numbering scheme.
		/// </summary>
		/// <returns>0 if successful, error code if unsuccessful</returns>
		[DllImport("libwiringPi.so", EntryPoint = "wiringPiSetup")]
		public static extern int wiringPiSetup();

		/// <summary>
		/// This initialises Wiring Pi but uses the /sys/class/gpio interface rather than accessing the hardware directly. Pin numbering in this mode is the native Broadcom GPIO numbers.
		/// </summary>
		/// <returns>0 if successful, otherwise returns error code.</returns>
		[DllImport("libwiringPi.so", EntryPoint = "wiringPiSetupSys")]
		public static extern int wiringPiSetupSys();

		/// <summary>
		/// This initialises Wiring Pi and allows the calling programs to use the Broadcom GPIO pin numbers directly with no re-mapping.
		/// </summary>
		/// <returns>Returns 0 if successful, otherwise returns error code.</returns>
		[DllImport("libwiringPi.so", EntryPoint = "wiringPiSetupGpio")]
		public static extern int wiringPiSetupGpio();

		/// <summary>
		/// This initialises Wiring Pi and allows the calling programs to use the physical pin numbers on the P1 connector only.
		/// </summary>
		/// <returns>Returns 0 if successful, otherwise returns error code.</returns>
		[DllImport("libwiringPi.so", EntryPoint = "wiringPiSetupPhys")]
		public static extern int wiringPiSetupPhys();

		/// <summary>
		/// Sets any pin to any mode (Undocumented) 
		/// </summary>
		/// <param name="pin">Pin number</param>
		/// <param name="mode">Pin mode</param>
		[DllImport("libwiringPi.so", EntryPoint = "pinModeAlt")]
		public static extern void pinModeAlt(int pin, int mode);

		/// <summary>
		/// Sets the mode of a pin to be input, output or PWM output
		/// </summary>
		/// <param name="pin">Pin number</param>
		/// <param name="mode">Pin mode</param>
		[DllImport("libwiringPi.so", EntryPoint = "pinMode")]
		public static extern void pinMode(int pin, int mode);

		/// <summary>
		/// Controls the internal pull-up/down resistors on a GPIO pin
		/// </summary>
		/// <param name="pin">Pin number</param>
		/// <param name="pud">PUD_OFF (no pull up/down), PUD_DOWN (pull to ground), or PUD_UP (pull to 3.3v)</param>
		[DllImport("libwiringPi.so", EntryPoint = "pullUpDnControl")]
		public static extern void pullUpDnControl(int pin, int pud) ;

		/// <summary>
		/// Reads the value of a given Pin
		/// </summary>
		/// <param name="pin">Pin number</param>
		/// <returns>1 if HIGH, 0 if LOW</returns>
		[DllImport("libwiringPi.so", EntryPoint = "digitalRead")]
		public static extern int digitalRead(int pin);

		/// <summary>
		/// Sets an output bit
		/// </summary>
		/// <param name="pin">Pin number</param>
		/// <param name="value">1 to set HIGH, 0 to set LOW</param>
		[DllImport("libwiringPi.so", EntryPoint = "digitalWrite")]
		public static extern void digitalWrite(int pin, int value);

		/// <summary>
		/// Reads 8-bits (a byte) from given start pin
		/// </summary>
		/// <param name="pin">Pin number</param>
		/// <returns>Node value</returns>
		[DllImport("libwiringPi.so", EntryPoint = "digitalRead8")]
		public static extern uint digitalRead8(int pin);

		/// <summary>
		/// Sets an output 8-bit byte on the device from the given pin number
		/// </summary>
		/// <param name="pin">Pin number</param>
		/// <param name="value">1 to set HIGH, 0 to set LOW</param>
		[DllImport("libwiringPi.so", EntryPoint = "digitalWrite8")]
		public static extern void digitalWrite8(int pin, int value);

		/// <summary>
		/// Sets an output PWM value
		/// </summary>
		/// <param name="pin">Pin number</param>
		/// <param name="value">PWM value (0-1024)</param>
		[DllImport("libwiringPi.so", EntryPoint = "pwmWrite")]
		public static extern void pwmWrite(int pin, int value);

		/// <summary>
		/// Reads the analog value of a given Pin
		/// </summary>
		/// <param name="pin">Pin number</param>
		/// <returns>Value of the analog input pin</returns>
		[DllImport("libwiringPi.so", EntryPoint = "analogRead")]
		public static extern int analogRead(int pin);

		/// <summary>
		/// Writes the analog value to the given Pin
		/// </summary>
		/// <param name="pin">Pin number</param>
		/// <param name="value">Analog value</param>
		[DllImport("libwiringPi.so", EntryPoint = "analogWrite")]
		public static extern void analogWrite(int pin, int value);
	}

	/// <summary>
	/// PiFace specifics (Deprecated)
	/// </summary>
	public class PiFace
	{
		/// <summary>
		/// Initializes the devLib module for the PiFace board
		/// </summary>
		/// <returns>0 if successful, error code if unsuccessful</returns>
		[DllImport("libwiringPi.so", EntryPoint = "wiringPiSetupPiFace")]
		public static extern int wiringPiSetupPiFace();

		/// <summary>
		/// Initializes the devLib module for the PiFace board using GPIO pin numbers
		/// </summary>
		/// <returns>0 if successful, error code if unsuccessful</returns>
		[DllImport("libwiringPi.so", EntryPoint = "wiringPiSetupPiFaceForGpioProg")]
		public static extern int wiringPiSetupPiFaceForGpioProg();
	}

	/// <summary>
	/// On-Board Raspberry Pi hardware specific methods
	/// </summary>
	public class Hardware
	{
		/// <summary>
		/// Determines the device's board revision
		/// </summary>
		/// <returns>A number representing the hardware revision of the board</returns>
		[DllImport("libwiringPi.so", EntryPoint = "piGpioLayout")]
		public static extern int piGpioLayout();

		/// <summary>
		/// Determines the device's board revision (Deprecated)
		/// </summary>
		/// <returns>A number representing the hardware revision of the board</returns>
		[DllImport("libwiringPi.so", EntryPoint = "piBoardRev")]
		public static extern int piBoardRev();

		/// <summary>
		/// Returns the real details of the board
		/// </summary>
		/// <param name="model">Raspberry Pi model</param>
		/// <param name="rev">Board revision</param>
		/// <param name="mem">Memory</param>
		/// <param name="maker">Manufacturer</param>
		/// <param name="overVolted">Overvolted</param>
		[DllImport("libwiringPi.so", EntryPoint = "piBoardId")]
		public static extern void piBoardId(ref int model, ref int rev, ref int mem, ref int maker, ref int overVolted);

		/// <summary>
		/// Translates a wiringPi Pin number to native GPIO pin number
		/// </summary>
		/// <param name="wpiPin">Wiring Pi pin number</param>
		/// <returns>GPIO pin number</returns>
		[DllImport("libwiringPi.so", EntryPoint = "wpiPinToGpio")]
		public static extern int wpiPinToGpio(int wpiPin);

		/// <summary>
		/// Translates a physical Pin number to native GPIO pin number
		/// </summary>
		/// <param name="physPin">Physical pin number</param>
		/// <returns>GPIO pin number</returns>
		[DllImport("libwiringPi.so", EntryPoint = "physPinToGpio")]
		public static extern int physPinToGpio(int physPin);

		/// <summary>
		/// Sets the PAD driver value
		/// </summary>
		/// <param name="group">Pin group</param>
		/// <param name="value">Drive strength (0-7)</param>
		[DllImport("libwiringPi.so", EntryPoint = "setPadDrive")]
		public static extern void setPadDrive(int group, int value);

		/// <summary>
		/// Returns the ALT bits for a given port
		/// </summary>
		/// <param name="pin">Pin number</param>
		/// <returns>The ALT bits for a given port</returns>
		[DllImport("libwiringPi.so", EntryPoint = "getAlt")]
		public static extern int getAlt(int pin);

		/// <summary>
		/// Outputs the given frequency on the Pi's PWM pin
		/// </summary>
		/// <param name="pin">Pin number</param>
		/// <param name="freq">Signal frequency</param>
		[DllImport("libwiringPi.so", EntryPoint = "pwmToneWrite")]
		public static extern void pwmToneWrite(int pin, int freq);

		/// <summary>
		/// Selects the native "balanced" mode, or standard mark:space mode
		/// </summary>
		/// <param name="mode">PWM mode</param>
		[DllImport("libwiringPi.so", EntryPoint = "pwmSetMode")]
		public static extern void pwmSetMode(int mode);

		/// <summary>
		/// Sets the PWM range register
		/// </summary>
		/// <param name="range">Range register (Default: 1024)</param>
		[DllImport("libwiringPi.so", EntryPoint = "pwmSetRange")]
		public static extern void pwmSetRange(uint range);

		/// <summary>
		/// Sets/Changes the PWM clock
		/// </summary>
		/// <param name="divisor">Clock divisor</param>
		[DllImport("libwiringPi.so", EntryPoint = "pwmSetClock")]
		public static extern void pwmSetClock(int divisor);

		/// <summary>
		/// Sets the frequency on a GPIO clock pin
		/// </summary>
		/// <param name="pin">Pin number</param>
		/// <param name="freq">Signal frequency</param>
		[DllImport("libwiringPi.so", EntryPoint = "gpioClockSet")]
		public static extern void gpioClockSet(int pin, int freq);

		/// <summary>
		/// Reads the 8-bit byte from the first 8 GPIO pins
		/// </summary>
		/// <returns>GPIO pin values</returns>
		[DllImport("libwiringPi.so", EntryPoint = "digitalReadByte")]
		public static extern uint digitalReadByte();

		/// <summary>
		/// Reads the 8-bit byte from the second 8 GPIO pins
		/// </summary>
		/// <returns>GPIO pin values</returns>
		[DllImport("libwiringPi.so", EntryPoint = "digitalReadByte2")]
		public static extern uint digitalReadByte2();

		/// <summary>
		/// Writes an 8-bit byte to the first 8 GPIO pins
		/// </summary>
		/// <param name="value">GPIO pin values</param>
		[DllImport("libwiringPi.so", EntryPoint = "digitalWriteByte")]
		public static extern void digitalWriteByte(int value);

		/// <summary>
		/// Writes an 8-bit byte to the second 8 GPIO pins
		/// </summary>
		/// <param name="value">GPIO pin values</param>
		[DllImport("libwiringPi.so", EntryPoint = "digitalWriteByte2")]
		public static extern void digitalWriteByte2(int value);
	}

	/// <summary>
	/// Methods to set the GPIO to interrupt on a rising, falling, or both edges of the incoming signal
	/// </summary>
	public class Interrupts
	{
		/// <summary>
		/// Wait for Interrupt on a GPIO pin
		/// </summary>
		/// <param name="pin">Pin number</param>
		/// <param name="mS">Timeout (milliseconds)</param>
		/// <returns>1 if successful, 0 if timed out, -1 if unsuccessful</returns>
		[DllImport("libwiringPi.so", EntryPoint = "waitForInterrupt")]
		public static extern int waitForInterrupt(int pin, int mS);

		/// <summary>
		/// Registers a function to received interrupts on the specified pin
		/// </summary>
		/// <param name="pin">Pin number</param>
		/// <param name="mode">INT_EDGE_FALLING, INT_EDGE_RISING, INT_EDGE_BOTH, or INT_EDGE_SETUP</param>
		/// <param name="interruptFunction">Function called on interrupt</param>
		/// <returns></returns>
		[DllImport("libwiringPi.so", EntryPoint = "wiringPiISR")]
		public static extern int wiringPiISR(int pin, int mode, Action function);
	}

	/// <summary>
	/// Methods to create a new process which runs concurrently with your main program, and using the mutex mechanisms, safely pass variables between them.
	/// </summary>
	public class Threads
	{
		/// <summary>
		/// Uses a key value to lock a thread to synchronise variable updates from the main program to any threads running in the program
		/// </summary>
		/// <param name="key">A number (0-3) that represents a "key"</param>
		[DllImport("libwiringPi.so", EntryPoint = "piLock")]
		public static extern void piLock(int key);

		/// <summary>
		/// Unlocks a thread that was previously locked with piLock
		/// </summary>
		/// <param name="key">A number (0-3) that represents a "key"</param>
		[DllImport("libwiringPi.so", EntryPoint = "piUnlock")]
		public static extern void piUnlock(int key);

		/// <summary>
		/// Attempts to shift the program (or thread in a multi-threaded program) to a higher priority and enables a real-time scheduling
		/// </summary>
		/// <param name="pri">0 (default) to 99</param>
		/// <returns>0 for success, -1 for error</returns>
		[DllImport("libwiringPi.so", EntryPoint = "piHiPri")]
		public static extern int piHiPri(int pri);
	}

	/// <summary>
	/// Methods to provide various timing and sleeping functions
	/// </summary>
	public class Timing
	{
		/// <summary>
		/// Causes program execution to pause for at least the specified number of milliseconds
		/// </summary>
		/// <param name="howLong">The number of milliseconds to delay</param>
		[DllImport("libwiringPi.so", EntryPoint = "delay")]
		public static extern void delay(uint howLong);

		/// <summary>
		/// Causes program execution to pause for at least the specified number of microseconds
		/// </summary>
		/// <param name="howLong">The number of microseconds to delay</param>
		[DllImport("libwiringPi.so", EntryPoint = "delayMicroseconds")]
		public static extern void delayMicroseconds(uint howLong);

		/// <summary>
		/// Determines the number of milliseconds since Wiring Pi was initialized
		/// </summary>
		/// <returns>A number representing the number of milliseconds since the program called one of the wiringPiSetup functions</returns>
		[DllImport("libwiringPi.so", EntryPoint = "millis")]
		public static extern uint millis();

		/// <summary>
		/// Determines the number of microseconds since Wiring Pi was initialized
		/// </summary>
		/// <returns>A number representing the number of microseconds since the program called one of the wiringPiSetup functions</returns>
		[DllImport("libwiringPi.so", EntryPoint = "micros")]
		public static extern uint micros();
	}

	/// <summary>
	/// Uses the GPIO pins to produce tones
	/// </summary>
	public class Tones
	{
		/// <summary>
		/// Creates a new tone thread
		/// </summary>
		/// <param name="pin">Pin number</param>
		/// <returns>0 for success, -1 for error</returns>
		[DllImport("libwiringPi.so", EntryPoint = "softToneCreate")]
		public static extern int softToneCreate(int pin);

		/// <summary>
		/// Stops an existing softTone thread
		/// </summary>
		/// <param name="pin">Pin number</param>
		[DllImport("libwiringPi.so", EntryPoint = "softToneStop")]
		public static extern void softToneStop(int pin);

		/// <summary>
		/// Writes a frequency value to the given pin
		/// </summary>
		/// <param name="pin">Pin number</param>
		/// <param name="freq">Tone frequency</param>
		[DllImport("libwiringPi.so", EntryPoint = "softToneWrite")]
		public static extern void softToneWrite(int pin, int freq);
	}

	/// <summary>
	/// Simplified I2C access routines
	/// </summary>
	public class I2C
	{
		public const int I2C_SMBUS_QUICK = 0;
		public const int I2C_SMBUS_BYTE = 1;
		public const int I2C_SMBUS_BYTE_DATA = 2;
		public const int I2C_SMBUS_WORD_DATA = 3;
		public const int I2C_SMBUS_PROC_CALL = 4;
		public const int I2C_SMBUS_BLOCK_DATA = 5;
		public const int I2C_SMBUS_I2C_BLOCK_BROKEN = 6;
		public const int I2C_SMBUS_BLOCK_PROC_CALL = 7;
		public const int I2C_SMBUS_I2C_BLOCK_DATA = 8;
		public const int I2C_SMBUS_BLOCK_MAX = 32;
		public const int I2C_SMBUS_I2C_BLOCK_MAX = 32;

		/// <summary>
		/// Simple device read
		/// </summary>
		/// <param name="fd">Device id</param>
		/// <returns>Data if successful, -1 unsuccessful</returns>
		[DllImport("libwiringPi.so", EntryPoint = "wiringPiI2CRead")]
		public static extern int wiringPiI2CRead(int fd);

		/// <summary>
		/// Reads an 8-bit value from a register on the device
		/// </summary>
		/// <param name="fd">Device id</param>
		/// <param name="reg">Register</param>
		/// <returns>Data if successful, -1 unsuccessful</returns>
		[DllImport("libwiringPi.so", EntryPoint = "wiringPiI2CReadReg8")]
		public static extern int wiringPiI2CReadReg8(int fd, int reg);

		/// <summary>
		/// Reads a 16-bit value from a register on the device
		/// </summary>
		/// <param name="fd">Device id</param>
		/// <param name="reg">Register</param>
		/// <returns>Data if successful, -1 unsuccessful</returns>
		[DllImport("libwiringPi.so", EntryPoint = "wiringPiI2CReadReg16")]
		public static extern int wiringPiI2CReadReg16(int fd, int reg);

		/// <summary>
		/// Simple device write
		/// </summary>
		/// <param name="fd">Device id</param>
		/// <param name="data">Data to be written</param>
		/// <returns>Status code</returns>
		[DllImport("libwiringPi.so", EntryPoint = "wiringPiI2CWrite")]
		public static extern int wiringPiI2CWrite(int fd, int data);

		/// <summary>
		/// Write an 8-bit value to the given register
		/// </summary>
		/// <param name="fd">Device id</param>
		/// <param name="reg">Register</param>
		/// <param name="data">Data to be written</param>
		/// <returns>Status code</returns>
		[DllImport("libwiringPi.so", EntryPoint = "wiringPiI2CWriteReg8")]
		public static extern int wiringPiI2CWriteReg8(int fd, int reg, int data);

		/// <summary>
		/// Write a 16-bit value to the given register
		/// </summary>
		/// <param name="fd">Device id</param>
		/// <param name="reg">Register</param>
		/// <param name="data">Data to be written</param>
		/// <returns>Status code</returns>
		[DllImport("libwiringPi.so", EntryPoint = "wiringPiI2CWriteReg16")]
		public static extern int wiringPiI2CWriteReg16(int fd, int reg, int data);

		/// <summary>
		/// Set the interface explicitly (Undocumented)
		/// </summary>
		/// <param name="device">Device address</param>
		/// <param name="devId">Device id</param>
		/// <returns>Device id if successful, error code if unsuccessful</returns>
		[DllImport("libwiringPi.so", EntryPoint = "wiringPiI2CSetupInterface")]
		public static extern int wiringPiI2CSetupInterface(ref char device, int devId);

		/// <summary>
		/// Opens the I2C device and registers the target device
		/// </summary>
		/// <param name="devId">Device id</param>
		/// <returns>Device id if successful, error code if unsuccessful</returns>
		[DllImport("libwiringPi.so", EntryPoint = "wiringPiI2CSetup")]
		public static extern int wiringPiI2CSetup(int devId);
	}

	/// <summary>
	/// Simplified SPI access routines
	/// </summary>
	public class SPI
	{
		/// <summary>
		/// Returns the file-descriptor for the given channel
		/// </summary>
		/// <param name="channel">Channel number (0 or 1)</param>
		/// <returns>The file-descriptor for the given channel</returns>
		[DllImport("libwiringPi.so", EntryPoint = "wiringPiSPIGetFd")]
		public static extern int wiringPiSPIGetFd(int channel);

		/// <summary>
		/// Writes and Reads a block of data over the SPI bus
		/// </summary>
		/// <param name="channel">Channel number (0 or 1)</param>
		/// <param name="data">Data to be written</param>
		/// <param name="len">Length of data</param>
		/// <returns>Status message</returns>
		[DllImport("libwiringPi.so", EntryPoint = "wiringPiSPIDataRW")]
		public static extern int wiringPiSPIDataRW(int channel, ref byte data, int len);

		/// <summary>
		/// Opens the SPI device, and sets it up, with the mode, etc
		/// </summary>
		/// <param name="channel">Channel number (0 or 1)</param>
		/// <param name="speed">SPI clock speed in Hz</param>
		/// <param name="mode">SPI mode (0-3)</param>
		/// <returns>Device id</returns>
		[DllImport("libwiringPi.so", EntryPoint = "wiringPiSPISetupMode")]
		public static extern int wiringPiSPISetupMode(int channel, int speed, int mode);

		/// <summary>
		/// Opens the SPI device, and sets it up, etc. in the default MODE 0
		/// </summary>
		/// <param name="channel">Channel number (0 or 1)</param>
		/// <param name="speed">SPI clock speed in Hz</param>
		/// <returns>Device id</returns>
		[DllImport("libwiringPi.so", EntryPoint = "wiringPiSPISetup")]
		public static extern int wiringPiSPISetup(int channel, int speed);
	}

	/// <summary>
	/// Methods for serial port handling
	/// </summary>
	public class Serial
	{
		/// <summary>
		/// Opens and initialises the serial port
		/// </summary>
		/// <param name="device">Device number</param>
		/// <param name="baud">Device speed</param>
		/// <returns>Device id</returns>
		[DllImport("libwiringPi.so", EntryPoint = "serialOpen")]
		public static extern int serialOpen(ref char device, int baud);

		/// <summary>
		/// Releases the serial port
		/// </summary>
		/// <param name="fd">Device id</param>
		[DllImport("libwiringPi.so", EntryPoint = "serialClose")]
		public static extern void serialClose(int fd);

		/// <summary>
		/// Flushes the serial buffers (both tx & rx)
		/// </summary>
		/// <param name="fd">Device id</param>
		[DllImport("libwiringPi.so", EntryPoint = "serialFlush")]
		public static extern void serialFlush(int fd);

		/// <summary>
		/// Sends a single character to the serial port
		/// </summary>
		/// <param name="fd">Device id</param>
		/// <param name="c">Character to be written</param>
		[DllImport("libwiringPi.so", EntryPoint = "serialPutchar")]
		public static extern void serialPutchar(int fd, byte c);

		/// <summary>
		/// Send a string to the serial port
		/// </summary>
		/// <param name="fd">Device id</param>
		/// <param name="s">String to be written</param>
		[DllImport("libwiringPi.so", EntryPoint = "serialPuts")]
		public static extern void serialPuts(int fd, ref string s);

		/// <summary>
		/// Printf over Serial
		/// </summary>
		/// <param name="fd">Device id</param>
		/// <param name="message">String to be written</param>
		[DllImport("libwiringPi.so", EntryPoint = "serialPrintf")]
		public static extern void serialPrintf(int fd, ref string message);

		/// <summary>
		/// Gets the serial port's available data bytes
		/// </summary>
		/// <param name="fd">Device id</param>
		/// <returns>The number of bytes of data available to be read in the serial port</returns>
		[DllImport("libwiringPi.so", EntryPoint = "serialDataAvail")]
		public static extern int serialDataAvail(int fd);

		/// <summary>
		/// Gets a single character from the serial device
		/// </summary>
		/// <param name="fd">Device id</param>
		/// <returns>A single character from the serial device</returns>
		[DllImport("libwiringPi.so", EntryPoint = "serialGetchar")]
		public static extern int serialGetchar(int fd);
	}

	/// <summary>
	/// Emulates some of the Arduino wiring functionality
	/// </summary>
	public class Wiring
	{
		/// <summary>
		/// Shifts data in from a clocked source
		/// </summary>
		/// <param name="dPin">Data pin</param>
		/// <param name="cPin">Clock pin</param>
		/// <param name="order">Order (LSBFIRST or MSBFIRST)</param>
		/// <returns>The shifted data</returns>
		[DllImport("libwiringPi.so", EntryPoint = "shiftIn")]
		public static extern byte shiftIn(byte dPin, byte cPin, byte order);

		/// <summary>
		/// Shifts data out to a clocked source
		/// </summary>
		/// <param name="dPin">Data pin</param>
		/// <param name="cPin">Clock pin</param>
		/// <param name="order">Order (LSBFIRST or MSBFIRST)</param>
		/// <param name="val">Data to be shifted</param>
		[DllImport("libwiringPi.so", EntryPoint = "shiftOut")]
		public static extern void shiftOut(byte dPin, byte cPin, byte order, byte val);
	}

	/// <summary>
	/// Part of the GPIO program to test, peek, poke and otherwise noodle with the GPIO hardware on the Raspberry Pi
	/// </summary>
	public class Extension
	{
		/// <summary>
		/// Loads in a Wiring Pi extension
		/// </summary>
		/// <param name="progName">Program name</param>
		/// <param name="extensionData">Starts with the name, a colon then the pinBase number</param>
		/// <param name="verbose">Enables (1) or disables (0) verbose output</param>
		/// <returns>Extension if successful</returns>
		[DllImport("libwiringPi.so", EntryPoint = "loadWPiExtension")]
		public static extern int loadWPiExtension(ref char progName, ref string extensionData, int verbose);
	}

	/// <summary>
	/// Extends Wiring Pi with a number of pseudo pins which can be digitally or analog written/read
	/// </summary>
	public class PseudoPins
	{
		/// <summary>
		/// Creates a new Wiring Pi device node for the pseudoPins driver
		/// </summary>
		/// <param name="pinBase">Pseudo pin number (>40)</param>
		/// <returns>0 if successful, -1 if unsuccessful</returns>
		[DllImport("libwiringPi.so", EntryPoint = "pseudoPinsSetup")]
		public static extern int pseudoPinsSetup(int pinBase);
	}

	/// <summary>
	/// Provides N channels of software driven PWM suitable for RC servo motors
	/// </summary>
	public class SoftServo
	{
		/// <summary>
		/// Sets up the software servo system
		/// </summary>
		/// <param name="p0">Pin 1 number</param>
		/// <param name="p1">Pin 2 number</param>
		/// <param name="p2">Pin 3 number</param>
		/// <param name="p3">Pin 4 number</param>
		/// <param name="p4">Pin 5 number</param>
		/// <param name="p5">Pin 6 number</param>
		/// <param name="p6">Pin 7 number</param>
		/// <param name="p7">Pin 8 number</param>
		/// <returns>0 if successful, error code if unsuccessful</returns>
		[DllImport("libwiringPi.so", EntryPoint = "softServoSetup")]
		public static extern int softServoSetup(int p0, int p1, int p2, int p3, int p4, int p5, int p6, int p7);

		/// <summary>
		/// Writes a Servo value to the given pin
		/// </summary>
		/// <param name="pin">Pin number</param>
		/// <param name="value">Value to be written</param>
		[DllImport("libwiringPi.so", EntryPoint = "softServoWrite")]
		public static extern void softServoWrite(int pin, int value);
	}

	/// <summary>
	/// Extends Wiring Pi with the ADS1115 I2C 16-bit ADC
	/// </summary>
	public class ADS1115
	{
		/// <summary>
		/// Creates a new wiringPi device node for an ads1115
		/// </summary>
		/// <param name="pinBase">Pseudo pin number (>40)</param>
		/// <param name="i2cAddress">I2C address</param>
		/// <returns>0 if successful, -1 if unsuccessful</returns>
		[DllImport("libwiringPi.so", EntryPoint = "ads1115Setup")]
		public static extern int ads1115Setup(int pinBase, int i2cAddress);
	}

	/// <summary>
	/// Extends Wiring Pi with the BMP180 I2C Pressure and Temperature sensor
	/// </summary>
	public class BMP180
	{
		/// <summary>
		/// Creates a new instance of a PCF8591 I2C GPIO interface
		/// </summary>
		/// <param name="pinBase">Pseudo pin number (>40)</param>
		/// <returns>0 if successful, -1 if unsuccessful</returns>
		[DllImport("libwiringPi.so", EntryPoint = "bmp180Setup")]
		public static extern int bmp180Setup(int pinBase);
	}

	/// <summary>
	/// Extends Wiring Pi with the DRC Network protocol
	/// </summary>
	public class DRCNetwork
	{
		/// <summary>
		/// Creates a new instance of an DRC GPIO interface
		/// </summary>
		/// <param name="pinBase">Pseudo pin number (>40)</param>
		/// <param name="numPins">Number of pins</param>
		/// <param name="ipAddress">IP address</param>
		/// <param name="port">Port number</param>
		/// <param name="password">Device password</param>
		/// <returns>0 if successful, -1 if unsuccessful</returns>
		[DllImport("libwiringPi.so", EntryPoint = "drcSetupNet")]
		public static extern int drcSetupNet(int pinBase, int numPins, ref string ipAddress, ref string port, ref string password);
	}

	/// <summary>
	/// Extends Wiring Pi with the DRC Serial protocol
	/// </summary>
	public class DRCSerial
	{
		/// <summary>
		/// Creates a new instance of a DRC GPIO interface
		/// </summary>
		/// <param name="pinBase">Pseudo pin number (>40)</param>
		/// <param name="numPins">Number of pins</param>
		/// <param name="device">Device name</param>
		/// <param name="baud">Device speed</param>
		/// <returns>0 if successful, -1 if unsuccessful</returns>
		[DllImport("libwiringPi.so", EntryPoint = "drcSetupSerial")]
		public static extern int drcSetupSerial(int pinBase, int numPins, ref string device, int baud);
	}

	/// <summary>
	/// Extends Wiring Pi with the DS18B20 1-Wire temperature sensor
	/// </summary>
	public class DS18B20
	{
		/// <summary>
		/// Creates a new instance of a DS18B20 temperature sensor
		/// </summary>
		/// <param name="pinBase">Pseudo pin number (>40)</param>
		/// <param name="serialNum">Device id</param>
		/// <returns>0 if successful, -1 if unsuccessful</returns>
		[DllImport("libwiringPi.so", EntryPoint = "ds18b20Setup")]
		public static extern int ds18b20Setup(int pinBase, ref string serialNum);
	}

	/// <summary>
	/// Extends Wiring Pi with the HTU21D I2C Humidity and Temperature
	/// </summary>
	public class HTU21D
	{
		/// <summary>
		/// Creates a new instance of a HTU21D I2C GPIO interface
		/// </summary>
		/// <param name="pinBase">Pseudo pin number (>40)</param>
		/// <returns>0 if successful, -1 if unsuccessful</returns>
		[DllImport("libwiringPi.so", EntryPoint = "htu21dSetup")]
		public static extern int htu21dSetup(int pinBase);
	}

	/// <summary>
	/// Extends Wiring Pi with the MAX5322 SPI Digital to Analog convertor
	/// </summary>
	public class MAX5322
	{
		/// <summary>
		/// Creates a new instance of a MAX5322 SPI GPIO interface
		/// </summary>
		/// <param name="pinBase">Pseudo pin number</param>
		/// <param name="spiChannel">SPI Channel (0 or 1)</param>
		/// <returns>1 if successful, 0 if unsuccessful</returns>
		[DllImport("libwiringPi.so", EntryPoint = "max5322Setup")]
		public static extern int max5322Setup(int pinBase, int spiChannel);
	}

	/// <summary>
	/// Extends Wiring Pi with the MAX31855 SPI Thermocouple driver
	/// </summary>
	public class MAX31855
	{
		/// <summary>
		/// Creates a new instance of a MAX31855 SPI Thermocouple
		/// </summary>
		/// <param name="pinBase">Pseudo pin number</param>
		/// <param name="spiChannel">SPI Channel (0 or 1)</param>
		/// <returns></returns>
		[DllImport("libwiringPi.so", EntryPoint = "max31855Setup")]
		public static extern int max31855Setup(int pinBase, int spiChannel);
	}
}