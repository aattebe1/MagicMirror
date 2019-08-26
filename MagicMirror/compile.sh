#!/bin/bash

mcs Core.cs MainForm.cs EventHandlers.cs WiringPi.cs LibMagicMirror.cs Weather.cs News.cs Cursor.cs Icon.cs Images.cs Sensors/Sensor.cs Sensors/Pins.cs Sensors/DoorSensor.cs Sensors/FireSensor.cs Sensors/MotionSensor.cs Sensors/WindowSensor.cs Properties/AssemblyInfo.cs -resource:Cursor/None.cur,MagicMirror.Cursor.None.cur -resource:Icon/1.ico,MagicMirror.Icon.1.ico -resource:Images/default.gif,MagicMirror.Images.default.gif -resource:Images/01d.gif,MagicMirror.Images.01d.gif -resource:Images/01n.gif,MagicMirror.Images.01n.gif -resource:Images/02d.gif,MagicMirror.Images.02d.gif -resource:Images/02n.gif,MagicMirror.Images.02n.gif -resource:Images/03d.gif,MagicMirror.Images.03d.gif -resource:Images/03n.gif,MagicMirror.Images.03n.gif -resource:Images/04d.gif,MagicMirror.Images.04d.gif -resource:Images/04n.gif,MagicMirror.Images.04n.gif -resource:Images/09d.gif,MagicMirror.Images.09d.gif -resource:Images/09n.gif,MagicMirror.Images.09n.gif -resource:Images/10d.gif,MagicMirror.Images.10d.gif -resource:Images/10n.gif,MagicMirror.Images.10n.gif -resource:Images/11d.gif,MagicMirror.Images.11d.gif -resource:Images/11n.gif,MagicMirror.Images.11n.gif -resource:Images/13d.gif,MagicMirror.Images.13d.gif -resource:Images/13n.gif,MagicMirror.Images.13n.gif -resource:Images/50d.gif,MagicMirror.Images.50d.gif -resource:Images/50n.gif,MagicMirror.Images.50n.gif -resource:Images/door1.gif,MagicMirror.Images.door1.gif -resource:Images/door2.gif,MagicMirror.Images.door2.gif -resource:Images/window1.gif,MagicMirror.Images.window1.gif -resource:Images/window2.gif,MagicMirror.Images.window2.gif -resource:Images/motion1.gif,MagicMirror.Images.motion1.gif -resource:Images/motion2.gif,MagicMirror.Images.motion2.gif -resource:Images/fire1.gif,MagicMirror.Images.fire1.gif -resource:Images/fire2.gif,MagicMirror.Images.fire2.gif -r:System.Windows.Forms.dll -r:System.Drawing.dll -win32icon:1.ico -target:winexe  -out:MagicMirror.exe