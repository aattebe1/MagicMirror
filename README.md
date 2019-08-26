MagicMirror development is complete as of 2019-04-11.  The program has been tested
on Windows 10 and Raspbian Stretch.

MagicMirror can be built in Windows with Visual Studio 2015 or in Raspbian using 
the mono C# compiler.  Building and running the program in Raspbian requires the
wiringPi library.

When running the program in windows, the libwiringPi.so file must be in the same
directory as MagicMirror.exe.  This is because the program looks for the wiringPi
shared library at runtime.  To get around this, I wrote a dll file that contains
empty wiringPi functions.  The compiled libwiringPi.so file is included with the
MagicMirror source.

Additionally, the image files for the weather need to be downloaded from
https://openweathermap.org/weather-conditions. They also need to be converted to
the gif format and placed in the images directory for the program to compile and
run correctly.
