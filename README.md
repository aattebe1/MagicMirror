MagicMirror is a work in progress as of 2019-04-06.  Not all functionality has
been implemented.  The program has been tested on Windows 10 and Raspbian Stretch.

MagicMirror can be built in Windows with Visual Studio 2015 or in Raspbian using 
the mono C# compiler.  Both methods require the Gtk# 2.0 Toolkit.  Building and
running the program in Raspbian also requires the wiringPi library.

I have not tested the Windows builds on the Raspberry Pi, but the Raspberry Pi
builds do not run in Windows.  It's best to compile the program in the OS that
will be running the program.

The Headlines.cs file requires modification depending on which OS you are
planning to use.  Look for the following comments:
    /* ENABLE FOR RASPBERRY PI, DISABLE FOR WINDOWS */
    /* ENABLE FOR WINDOWS, DISABLE FOR RASPBERRY PI */
Comment/uncomment accordingly the methods following these comments (2 for each).

When running the program in windows, the libwiringPi.so file must be in the same
directory as MagicMirror.exe.  This is because the program looks for the wiringPi
shared library, which obviously it will not find in Windows.  To get around this,
I wrote a dll file that contains empty wiringPi functions.  The source code for
this dll is in the libwiringPi folder and the compiled libwiringPi.so file is
included in the MagicMirror source.

When running the program in Raspbian, the libmagicmirror.so file must be
installed in the /usr/lib folder.  For some reason the news feed was not
downloading correctly on the Raspberry Pi.  I solved this problem by writing the
libmagicmirror shared object that downloads the RSS feed to xml files.  The
default directory for the downloads is /MagicMirror.  To change this directory,
the strings in the NewsFeed initialization section of the MagicMirrorObjects.cs
file need to be changed.  The pre-compiled libmagicmirror.so and the source code
are included in the libmagicmirror folder.  The script compile.sh has the command
to compile MagicMirror in Raspbian.

Additionally, the image files for the weather need to be downloaded from
https://openweathermap.org/weather-conditions. They also need to be converted to
the gif format and placed in the images directory for the program to compile and
run correctly.  I did not include them because I do not own the copyright.