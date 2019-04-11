MagicMirror is a work in progress as of 2019-04-06.  Not all functionality has
been implemented.  The program has been tested on Windows 10 and Raspbian Stretch.

MagicMirror can be built in Windows with Visual Studio 2015 or in Raspbian using 
the mono C# compiler.  Both methods require the Gtk# 2.0 Toolkit.  Building and
running the program in Raspbian also requires the wiringPi library.

I have not tested the Windows builds on the Raspberry Pi, but the Raspberry Pi
builds do not run in Windows.  It's best to compile the program in the OS that
will be running the program.

When running the program in windows, the libwiringPi.so file must be in the same
directory as MagicMirror.exe.  This is because the program looks for the wiringPi
shared library, which obviously it will not find in Windows.  To get around this,
I wrote a dll file that contains empty wiringPi functions.  The source code for
this dll is in the libwiringPi folder and the compiled libwiringPi.so file is
included in the MagicMirror source.

Additionally, the image files for the weather need to be downloaded from
https://openweathermap.org/weather-conditions. They also need to be converted to
the gif format and placed in the images directory for the program to compile and
run correctly.  I did not include them because I do not own the copyright.
