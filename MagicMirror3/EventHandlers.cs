/* 
 * EventHandler.cs
 * 
 * Author: Austin Atteberry
 * 
 * Description: Defines the event handlers
 *              for the MagicMirror GUI
 * 
 */

namespace GUI
{
	public partial class Display : System.Windows.Forms.Form
    {
        /* Handles the FrmMain load event */
        private void FrmMain_Load(object sender, System.EventArgs e)
        {
            this.Show();    // Show the main form
        }

        /* Handles the LblNews[0] size changed event */
        private void LblNews0_SizeChanged(object sender, System.EventArgs e)
        {
            /* Set new position for the next label */
            this.LblNews[1].Location = new System.Drawing.Point(10, this.LblNews[0].Location.Y + this.LblNews[0].Height + 10);
        }

        /* Handles the LblNews[0] text changed event */
        private void LblNews0_TextChanged(object sender, System.EventArgs e)
        {
            LblNews[0].Size = new System.Drawing.Size(490, this.LblNews[0].GetPreferredSize(new System.Drawing.Size(490, 0)).Height);
        }

        /* Handles the LblNews[1] size changed event */
        private void LblNews1_SizeChanged(object sender, System.EventArgs e)
        {
            /* Set new position for the next label */
            this.LblNews[2].Location = new System.Drawing.Point(10, this.LblNews[1].Location.Y + this.LblNews[1].Height + 10);
        }

        /* Handles the LblNews[1] text changed event */
        private void LblNews1_TextChanged(object sender, System.EventArgs e)
        {
            LblNews[1].Size = new System.Drawing.Size(490, this.LblNews[1].GetPreferredSize(new System.Drawing.Size(490, 0)).Height);
        }

        /* Handles the LblNews[2] size changed event */
        private void LblNews2_SizeChanged(object sender, System.EventArgs e)
        {
            /* Set new position for the next label */
            this.LblNews[3].Location = new System.Drawing.Point(10, this.LblNews[2].Location.Y + this.LblNews[2].Height + 10);
        }

        /* Handles the LblNews[2] text changed event */
        private void LblNews2_TextChanged(object sender, System.EventArgs e)
        {
            LblNews[2].Size = new System.Drawing.Size(490, this.LblNews[2].GetPreferredSize(new System.Drawing.Size(490, 0)).Height);
        }

        /* Handles the LblNews[3] size changed event */
        private void LblNews3_SizeChanged(object sender, System.EventArgs e)
        {
            /* Set new position for the next label */
            this.LblNews[4].Location = new System.Drawing.Point(10, this.LblNews[3].Location.Y + this.LblNews[3].Height + 10);
        }

        /* Handles the LblNews[3] text changed event */
        private void LblNews3_TextChanged(object sender, System.EventArgs e)
        {
            LblNews[3].Size = new System.Drawing.Size(490, this.LblNews[3].GetPreferredSize(new System.Drawing.Size(490, 0)).Height);
        }

        /* Handles the LblNews[4] text changed event */
        private void LblNews4_TextChanged(object sender, System.EventArgs e)
        {
            LblNews[4].Size = new System.Drawing.Size(490, this.LblNews[4].GetPreferredSize(new System.Drawing.Size(490, 0)).Height);
        }

        /* Handles the door alarm event */
        private void DoorSensor_Triggered()
        {
            if (this.SensorStatus[0])
            {
                this.PicSensor[0].Image = GUI.Images.SensorImages[0];
                WiringPi.Core.digitalWrite(RaspberryPi.Pins.PIN_37, WiringPi.Constants.LOW);
                this.SensorStatus[0] = false;
            }
            else
            {
                this.PicSensor[0].Image = GUI.Images.SensorImages[1];
                WiringPi.Core.digitalWrite(RaspberryPi.Pins.PIN_37, WiringPi.Constants.HIGH);
                this.SensorStatus[0] = true;
            }
        }

        /* Handles the window alarm event */
        private void WindowSensor_Triggered()
        {
            if (this.SensorStatus[1])
            {
                this.PicSensor[1].Image = GUI.Images.SensorImages[2];
                WiringPi.Core.digitalWrite(RaspberryPi.Pins.PIN_37, WiringPi.Constants.LOW);
                this.SensorStatus[1] = false;
            }
            else
            {
                this.PicSensor[1].Image = GUI.Images.SensorImages[3];
                WiringPi.Core.digitalWrite(RaspberryPi.Pins.PIN_37, WiringPi.Constants.HIGH);
                this.SensorStatus[1] = true;
            }
        }

        /* Handles the motion alarm event */
        private void MotionSensor_Triggered()
        {
            if (this.SensorStatus[2])
            {
                this.PicSensor[2].Image = GUI.Images.SensorImages[4];
                WiringPi.Core.digitalWrite(RaspberryPi.Pins.PIN_37, WiringPi.Constants.LOW);
                this.SensorStatus[2] = false;
            }
            else
            {
                this.PicSensor[2].Image = GUI.Images.SensorImages[5];
                WiringPi.Core.digitalWrite(RaspberryPi.Pins.PIN_37, WiringPi.Constants.HIGH);
                this.SensorStatus[2] = true;
            }
        }

        /* Handles the fire alarm event */
        private void FireSensor_Triggered()
        {
            if (this.SensorStatus[3])
            {
                this.PicSensor[3].Image = GUI.Images.SensorImages[6];
                WiringPi.Core.digitalWrite(RaspberryPi.Pins.PIN_37, WiringPi.Constants.LOW);
                this.SensorStatus[3] = false;
            }
            else
            {
                this.PicSensor[3].Image = GUI.Images.SensorImages[7];
                WiringPi.Core.digitalWrite(RaspberryPi.Pins.PIN_37, WiringPi.Constants.HIGH);
                this.SensorStatus[3] = true;
            }
        }

        /* Handles the reset button event */
        private void ResetButton_Triggered()
        {
            int Debounce = 0;

            /* Debounce the button to prevent transient voltage from resetting device */
            while (WiringPi.Core.digitalRead(RaspberryPi.Pins.PIN_38) == WiringPi.Constants.HIGH)
            {
                Debounce++;

                if (Debounce >= 700)
                {
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "sudo",
                        Arguments = "reboot"
                    });
                }
            }
        }

        /* Handles the screen on/off button event */
        private void ScreenButton_Triggered()
        {
            int Debounce = 0;

            /* Debounce the button to prevent transient voltage from turning off screen */
            while (WiringPi.Core.digitalRead(RaspberryPi.Pins.PIN_40) == WiringPi.Constants.HIGH)
            {
                if (Debounce < 2147483647)
                {
                    Debounce++;
                }

                if (Debounce >= 10000)
                {
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = "sudo",
                        Arguments = "reboot"
                    });
                }
                else if (Debounce >= 700)
                {
                    if (this.ScreenStatus)
                    {
                        this.ScreenStatus = false;

                        SetDate_Visibility(false);
                        SetTime_Visibility(false);
                        SetCity_Visibility(false);
                        SetTemperature_Visibility(false);
                        SetCondition_Visibility(false);
                        SetConditionImage_Visibility(false);
                        SetNews1_Visibility(false);
                        SetNews2_Visibility(false);
                        SetNews3_Visibility(false);
                        SetNews4_Visibility(false);
                        SetNews5_Visibility(false);
                        SetDoor_Visibility(false);
                        SetWindow_Visibility(false);
                        SetMotion_Visibility(false);
                        SetFire_Visibility(false);
                    }
                    else
                    {
                        this.ScreenStatus = true;

                        SetDate_Visibility(true);
                        SetTime_Visibility(true);
                        SetCity_Visibility(true);
                        SetTemperature_Visibility(true);
                        SetCondition_Visibility(true);
                        SetConditionImage_Visibility(true);
                        SetNews1_Visibility(true);
                        SetNews2_Visibility(true);
                        SetNews3_Visibility(true);
                        SetNews4_Visibility(true);
                        SetNews5_Visibility(true);
                        SetDoor_Visibility(true);
                        SetWindow_Visibility(true);
                        SetMotion_Visibility(true);
                        SetFire_Visibility(true);
                    }
                }
            }
        }

        /* Handles the date/time timer elapsed event */
        private void EventTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            /* Check security sensors */
            if ((!this.SensorStatus[0]) && this.SecuritySensors[0].PollSensor())
            {
                /* Door open */
                this.SetDoor_Image(GUI.Images.SensorImages[1]);
                WiringPi.Core.digitalWrite(RaspberryPi.Pins.PIN_37, WiringPi.Constants.HIGH);
                this.SensorStatus[0] = true;
            }
            else if (this.SensorStatus[0] && (!this.SecuritySensors[0].PollSensor()))
            {
                /* Door closed */
                this.SetDoor_Image(GUI.Images.SensorImages[0]);
                WiringPi.Core.digitalWrite(RaspberryPi.Pins.PIN_37, WiringPi.Constants.HIGH);
                this.SensorStatus[0] = false;
            }

            if ((!this.SensorStatus[1]) && this.SecuritySensors[1].PollSensor())
            {
                /* Door open */
                this.SetDoor_Image(GUI.Images.SensorImages[1]);
                WiringPi.Core.digitalWrite(RaspberryPi.Pins.PIN_37, WiringPi.Constants.HIGH);
                this.SensorStatus[1] = true;
            }
            else if (this.SensorStatus[1] && (!this.SecuritySensors[1].PollSensor()))
            {
                /* Door closed */
                this.SetDoor_Image(GUI.Images.SensorImages[0]);
                WiringPi.Core.digitalWrite(RaspberryPi.Pins.PIN_37, WiringPi.Constants.HIGH);
                this.SensorStatus[1] = false;
            }

            if ((!this.SensorStatus[2]) && this.SecuritySensors[2].PollSensor())
            {
                /* Window Open */
                this.SetWindow_Image(GUI.Images.SensorImages[3]);
                WiringPi.Core.digitalWrite(RaspberryPi.Pins.PIN_37, WiringPi.Constants.HIGH);
                this.SensorStatus[2] = true;
            }
            else if (this.SensorStatus[2] && (!this.SecuritySensors[2].PollSensor()))
            {
                /* Window closed */
                this.SetWindow_Image(GUI.Images.SensorImages[2]);
                WiringPi.Core.digitalWrite(RaspberryPi.Pins.PIN_37, WiringPi.Constants.HIGH);
                this.SensorStatus[2] = false;
            }

            if ((!this.SensorStatus[3]) && this.SecuritySensors[3].PollSensor())
            {
                /* Motion detected */
                this.SetMotion_Image(GUI.Images.SensorImages[5]);
                WiringPi.Core.digitalWrite(RaspberryPi.Pins.PIN_37, WiringPi.Constants.HIGH);
                this.SensorStatus[3] = true;
            }
            else if (this.SensorStatus[3] && (!this.SecuritySensors[3].PollSensor()))
            {
                /* Motion not detected */
                this.SetMotion_Image(GUI.Images.SensorImages[4]);
                WiringPi.Core.digitalWrite(RaspberryPi.Pins.PIN_37, WiringPi.Constants.HIGH);
                this.SensorStatus[3] = false;
            }

            if ((!this.SensorStatus[4]) && this.SecuritySensors[4].PollSensor())
            {
                this.SetMotion_Image(GUI.Images.SensorImages[5]);
                WiringPi.Core.digitalWrite(RaspberryPi.Pins.PIN_37, WiringPi.Constants.HIGH);
                this.SensorStatus[4] = true;
            }
            else if (this.SensorStatus[4] && (!this.SecuritySensors[4].PollSensor()))
            {
                this.SetMotion_Image(GUI.Images.SensorImages[4]);
                WiringPi.Core.digitalWrite(RaspberryPi.Pins.PIN_37, WiringPi.Constants.HIGH);
                this.SensorStatus[4] = false;
            }

            if ((!this.SensorStatus[5]) && this.SecuritySensors[5].PollSensor())
            {
                this.SetFire_Image(GUI.Images.SensorImages[7]);
                WiringPi.Core.digitalWrite(RaspberryPi.Pins.PIN_37, WiringPi.Constants.HIGH);
                this.SensorStatus[5] = true;
            }
            else if (this.SensorStatus[5] && (!this.SecuritySensors[5].PollSensor()))
            {
                this.SetFire_Image(GUI.Images.SensorImages[6]);
                WiringPi.Core.digitalWrite(RaspberryPi.Pins.PIN_37, WiringPi.Constants.HIGH);
                this.SensorStatus[5] = false;
            }

            /* Check screen on/off button */
            ScreenButton_Triggered();

            string MonthName = null;    // Name of month

            /* Convert month number to name string */
            switch (e.SignalTime.Month.ToString())
            {
                case "1":
                    MonthName = "January";
                    break;
                case "2":
                    MonthName = "February";
                    break;
                case "3":
                    MonthName = "March";
                    break;
                case "4":
                    MonthName = "April";
                    break;
                case "5":
                    MonthName = "May";
                    break;
                case "6":
                    MonthName = "June";
                    break;
                case "7":
                    MonthName = "July";
                    break;
                case "8":
                    MonthName = "August";
                    break;
                case "9":
                    MonthName = "September";
                    break;
                case "10":
                    MonthName = "October";
                    break;
                case "11":
                    MonthName = "November";
                    break;
                case "12":
                    MonthName = "December";
                    break;
                default:
                    MonthName = "Smarch";
                    break;
            }

            /* Update time and date labels */
            SetDate(e.SignalTime.DayOfWeek.ToString() + ", " + MonthName + " " + e.SignalTime.Day.ToString());
            SetTime(e.SignalTime.ToShortTimeString());

            this.EventCount++;

            /* Update news every 30s */
            if (((this.EventCount % 60) == 1) && (this.EventCount != 1))
            {
                string[] news = News.CurrentNews.GetRss(News.CurrentNews.URL[this.NewsCount]);

                /* Update news labels, resize, and relocate*/
                SetNews1(news[0]);
                SetNews1_Size(new System.Drawing.Size(490, this.LblNews[0].GetPreferredSize(new System.Drawing.Size(490, 0)).Height));
                SetNews2_Position(new System.Drawing.Point(10, this.LblNews[0].Location.Y + this.LblNews[0].Height + 10));
                SetNews2(news[1]);
                SetNews2_Size(new System.Drawing.Size(490, this.LblNews[1].GetPreferredSize(new System.Drawing.Size(490, 0)).Height));
                SetNews3_Position(new System.Drawing.Point(10, this.LblNews[1].Location.Y + this.LblNews[1].Height + 10));
                SetNews3(news[2]);
                SetNews3_Size(new System.Drawing.Size(490, this.LblNews[2].GetPreferredSize(new System.Drawing.Size(490, 0)).Height));
                SetNews4_Position(new System.Drawing.Point(10, this.LblNews[2].Location.Y + this.LblNews[2].Height + 10));
                SetNews4(news[3]);
                SetNews4_Size(new System.Drawing.Size(490, this.LblNews[3].GetPreferredSize(new System.Drawing.Size(490, 0)).Height));
                SetNews5_Position(new System.Drawing.Point(10, this.LblNews[3].Location.Y + this.LblNews[3].Height + 10));
                SetNews5(news[4]);
                SetNews5_Size(new System.Drawing.Size(490, this.LblNews[4].GetPreferredSize(new System.Drawing.Size(490, 0)).Height));

                /* Increase NewsCount, reset at 10 */
                if (this.NewsCount < 10)
                {
                    this.NewsCount++;
                }
                else
                {
                    this.NewsCount = 0;
                }
            }

            /* Update weather every 5m */
            if (this.EventCount >= 600)
            {
                this.EventCount = 0;    // Reset EventCount

                /* Get string array of weather items */
                string[] weather = Weather.CurrentWeather.GetWeather(Weather.CurrentWeather.URL);
                int result = 0;
                System.Int32.TryParse(weather[3], out result);

                /* Set weather labels to array elements */
                SetTemperature(weather[1]);
                SetCondition(weather[2]);
                SetCondition_Image(GUI.Images.WeatherImages[result]);
            }
        }

        /* Allows the timer thread to update the date label */
        private void SetDate(string Text)
        {
            if (this.LblDateTime[0].InvokeRequired)
            {
                SetCallback Callback = new SetCallback(SetDate);
                this.Invoke(Callback, new object[] { Text });
            }
            else
            {
                this.LblDateTime[0].Text = Text;
            }
        }

        /* Allows the timer thread to update the time label */
        private void SetTime(string Text)
        {
            if (this.LblDateTime[1].InvokeRequired)
            {
                SetCallback Callback = new SetCallback(SetTime);
                this.Invoke(Callback, new object[] { Text });
            }
            else
            {
                this.LblDateTime[1].Text = Text;
            }
        }

		/* Allows the timer thread to update the temperature label */
		private void SetTemperature(string Text)
        {
			if (this.LblWeather[1].InvokeRequired)
            {
                SetCallback Callback = new SetCallback(SetTemperature);
                this.Invoke(Callback, new object[] { Text });
            }
			else
            {
                this.LblWeather[1].Text = Text;
            }
        }

		/* Allows the timer thread to update the condition label */
		private void SetCondition(string Text)
        {
            if (this.LblWeather[2].InvokeRequired)
            {
                SetCallback Callback = new SetCallback(SetCondition);
                this.Invoke(Callback, new object[] { Text });
            }
			else
            {
                this.LblWeather[2].Text = Text;
            }
        }

		/* Allows the timer thread to update the condition image */
		private void SetCondition_Image(System.Drawing.Bitmap Image)
        {
			if (this.PicWeather.InvokeRequired)
            {
                SetCallback_Image Callback = new SetCallback_Image(SetCondition_Image);
                this.Invoke(Callback, new object[] { Image });
            }
            else
            {
                this.PicWeather.Image = Image;
            }
        }

		/* Allows the timer thread to update the first news label's text */
		private void SetNews1(string Text)
		{
            if (this.LblNews[0].InvokeRequired)
            {
                SetCallback Callback = new SetCallback(SetNews1);
				this.Invoke(Callback, new object[] { Text });
            }
            else
            {
                this.LblNews[0].Text = Text;
            }
        }

        /* Allows the timer thread to update the second news label's text */
        private void SetNews2(string Text)
        {
            if (this.LblNews[1].InvokeRequired)
            {
                SetCallback Callback = new SetCallback(SetNews2);
                this.Invoke(Callback, new object[] { Text });
            }
            else
            {
                this.LblNews[1].Text = Text;
            }
        }

        /* Allows the timer thread to update the third news label's text */
        private void SetNews3(string Text)
        {
            if (this.LblNews[2].InvokeRequired)
            {
                SetCallback Callback = new SetCallback(SetNews3);
                this.Invoke(Callback, new object[] { Text });
            }
            else
            {
                this.LblNews[2].Text = Text;
            }
        }

        /* Allows the timer thread to update the fourth news label's text */
        private void SetNews4(string Text)
        {
            if (this.LblNews[3].InvokeRequired)
            {
                SetCallback Callback = new SetCallback(SetNews4);
                this.Invoke(Callback, new object[] { Text });
            }
            else
            {
                this.LblNews[3].Text = Text;
            }
        }

        /* Allows the timer thread to update the fifth news label's text */
        private void SetNews5(string Text)
        {
            if (this.LblNews[4].InvokeRequired)
            {
                SetCallback Callback = new SetCallback(SetNews5);
                this.Invoke(Callback, new object[] { Text });
            }
            else
            {
                this.LblNews[4].Text = Text;
            }
        }

        /* Allows the timer thread to update the second news label's position */
        private void SetNews2_Position(System.Drawing.Point NewLocation)
        {
            if (this.LblNews[1].InvokeRequired)
            {
                SetCallback_Point Callback = new SetCallback_Point(SetNews2_Position);
                this.Invoke(Callback, new object[] { NewLocation });
            }
            else
            {
                this.LblNews[1].Location = NewLocation;
            }
        }

        /* Allows the timer thread to update the third news label's position */
        private void SetNews3_Position(System.Drawing.Point NewLocation)
        {
            if (this.LblNews[2].InvokeRequired)
            {
                SetCallback_Point Callback = new SetCallback_Point(SetNews3_Position);
                this.Invoke(Callback, new object[] { NewLocation });
            }
            else
            {
                this.LblNews[2].Location = NewLocation;
            }
        }

        /* Allows the timer thread to update the fourth news label's position */
        private void SetNews4_Position(System.Drawing.Point NewLocation)
        {
            if (this.LblNews[3].InvokeRequired)
            {
                SetCallback_Point Callback = new SetCallback_Point(SetNews4_Position);
                this.Invoke(Callback, new object[] { NewLocation });
            }
            else
            {
                this.LblNews[3].Location = NewLocation;
            }
        }

        /* Allows the timer thread to update the fifth news label's position */
        private void SetNews5_Position(System.Drawing.Point NewLocation)
        {
            if (this.LblNews[4].InvokeRequired)
            {
                SetCallback_Point Callback = new SetCallback_Point(SetNews5_Position);
                this.Invoke(Callback, new object[] { NewLocation });
            }
            else
            {
                this.LblNews[4].Location = NewLocation;
            }
        }

        /* Allows the timer thread to update the first news label's size */
        private void SetNews1_Size(System.Drawing.Size NewSize)
        {
            if (this.LblNews[0].InvokeRequired)
            {
                SetCallback_Size Callback = new SetCallback_Size(SetNews1_Size);
                this.Invoke(Callback, new object[] { NewSize });
            }
            else
            {
                this.LblNews[0].Size = NewSize;
            }
        }

        /* Allows the timer thread to update the second news label's size */
        private void SetNews2_Size(System.Drawing.Size NewSize)
        {
            if (this.LblNews[1].InvokeRequired)
            {
                SetCallback_Size Callback = new SetCallback_Size(SetNews2_Size);
                this.Invoke(Callback, new object[] { NewSize });
            }
            else
            {
                this.LblNews[1].Size = NewSize;
            }
        }

        /* Allows the timer thread to update the third news label's size */
        private void SetNews3_Size(System.Drawing.Size NewSize)
        {
            if (this.LblNews[2].InvokeRequired)
            {
                SetCallback_Size Callback = new SetCallback_Size(SetNews3_Size);
                this.Invoke(Callback, new object[] { NewSize });
            }
            else
            {
                this.LblNews[2].Size = NewSize;
            }
        }

        /* Allows the timer thread to update the fourth news label's size */
        private void SetNews4_Size(System.Drawing.Size NewSize)
        {
            if (this.LblNews[3].InvokeRequired)
            {
                SetCallback_Size Callback = new SetCallback_Size(SetNews4_Size);
                this.Invoke(Callback, new object[] { NewSize });
            }
            else
            {
                this.LblNews[3].Size = NewSize;
            }
        }

        /* Allows the timer thread to update the fifth news label's size */
        private void SetNews5_Size(System.Drawing.Size NewSize)
        {
            if (this.LblNews[4].InvokeRequired)
            {
                SetCallback_Size Callback = new SetCallback_Size(SetNews5_Size);
                this.Invoke(Callback, new object[] { NewSize });
            }
            else
            {
                this.LblNews[4].Size = NewSize;
            }
        }

        /* Allows the timer thread to update the door sensor image */
        private void SetDoor_Image(System.Drawing.Bitmap Image)
        {
            if (this.PicSensor[0].InvokeRequired)
            {
                SetCallback_Image Callback = new SetCallback_Image(SetDoor_Image);
                this.Invoke(Callback, new object[] { Image });
            }
            else
            {
                this.PicSensor[0].Image = Image;
            }
        }

        /* Allows the timer thread to update the window sensor image */
        private void SetWindow_Image(System.Drawing.Bitmap Image)
        {
            if (this.PicSensor[1].InvokeRequired)
            {
                SetCallback_Image Callback = new SetCallback_Image(SetWindow_Image);
                this.Invoke(Callback, new object[] { Image });
            }
            else
            {
                this.PicSensor[1].Image = Image;
            }
        }

        /* Allows the timer thread to update the motion sensor image */
        private void SetMotion_Image(System.Drawing.Bitmap Image)
        {
            if (this.PicSensor[2].InvokeRequired)
            {
                SetCallback_Image Callback = new SetCallback_Image(SetMotion_Image);
                this.Invoke(Callback, new object[] { Image });
            }
            else
            {
                this.PicSensor[2].Image = Image;
            }
        }

        /* Allows the timer thread to update the fire sensor image */
        private void SetFire_Image(System.Drawing.Bitmap Image)
        {
            if (this.PicSensor[3].InvokeRequired)
            {
                SetCallback_Image Callback = new SetCallback_Image(SetFire_Image);
                this.Invoke(Callback, new object[] { Image });
            }
            else
            {
                this.PicSensor[3].Image = Image;
            }
        }

        /* Allows the timer thread to change the date's visibility */
        private void SetDate_Visibility(bool Value)
        {
            if (this.LblDateTime[0].InvokeRequired)
            {
                SetCallback_bool Callback = new SetCallback_bool(SetDate_Visibility);
                this.Invoke(Callback, new object[] { Value });
            }
            else
            {
                this.LblDateTime[0].Visible = Value;
            }
        }

        /* Allows the timer thread to change the time's visibility */
        private void SetTime_Visibility(bool Value)
        {
            if (this.LblDateTime[1].InvokeRequired)
            {
                SetCallback_bool Callback = new SetCallback_bool(SetTime_Visibility);
                this.Invoke(Callback, new object[] { Value });
            }
            else
            {
                this.LblDateTime[1].Visible = Value;
            }
        }

        /* Allows the timer thread to change the city's visibility */
        private void SetCity_Visibility(bool Value)
        {
            if (this.LblWeather[0].InvokeRequired)
            {
                SetCallback_bool Callback = new SetCallback_bool(SetCity_Visibility);
                this.Invoke(Callback, new object[] { Value });
            }
            else
            {
                this.LblWeather[0].Visible = Value;
            }
        }

        /* Allows the timer thread to change the temperature's visibility */
        private void SetTemperature_Visibility(bool Value)
        {
            if (this.LblWeather[1].InvokeRequired)
            {
                SetCallback_bool Callback = new SetCallback_bool(SetTemperature_Visibility);
                this.Invoke(Callback, new object[] { Value });
            }
            else
            {
                this.LblWeather[1].Visible = Value;
            }
        }

        /* Allows the timer thread to change the weather conditon's visibility */
        private void SetCondition_Visibility(bool Value)
        {
            if (this.LblWeather[2].InvokeRequired)
            {
                SetCallback_bool Callback = new SetCallback_bool(SetCondition_Visibility);
                this.Invoke(Callback, new object[] { Value });
            }
            else
            {
                this.LblWeather[2].Visible = Value;
            }
        }

        /* Allows the timer thread to change the condition image's visibility */
        private void SetConditionImage_Visibility(bool Value)
        {
            if (this.PicWeather.InvokeRequired)
            {
                SetCallback_bool Callback = new SetCallback_bool(SetConditionImage_Visibility);
                this.Invoke(Callback, new object[] { Value });
            }
            else
            {
                this.PicWeather.Visible = Value;
            }
        }

        /* Allows the timer thread to change the first news label's visibility */
        private void SetNews1_Visibility(bool Value)
        {
            if (this.LblNews[0].InvokeRequired)
            {
                SetCallback_bool Callback = new SetCallback_bool(SetNews1_Visibility);
                this.Invoke(Callback, new object[] { Value });
            }
            else
            {
                this.LblNews[0].Visible = Value;
            }
        }

        /* Allows the timer thread to change the second news label's visibility */
        private void SetNews2_Visibility(bool Value)
        {
            if (this.LblNews[1].InvokeRequired)
            {
                SetCallback_bool Callback = new SetCallback_bool(SetNews2_Visibility);
                this.Invoke(Callback, new object[] { Value });
            }
            else
            {
                this.LblNews[1].Visible = Value;
            }
        }

        /* Allows the timer thread to change the third news label's visibility */
        private void SetNews3_Visibility(bool Value)
        {
            if (this.LblNews[2].InvokeRequired)
            {
                SetCallback_bool Callback = new SetCallback_bool(SetNews3_Visibility);
                this.Invoke(Callback, new object[] { Value });
            }
            else
            {
                this.LblNews[2].Visible = Value;
            }
        }

        /* Allows the timer thread to change the fourth news label's visibility */
        private void SetNews4_Visibility(bool Value)
        {
            if (this.LblNews[3].InvokeRequired)
            {
                SetCallback_bool Callback = new SetCallback_bool(SetNews4_Visibility);
                this.Invoke(Callback, new object[] { Value });
            }
            else
            {
                this.LblNews[3].Visible = Value;
            }
        }

        /* Allows the timer thread to change the fifth news label's visibility */
        private void SetNews5_Visibility(bool Value)
        {
            if (this.LblNews[4].InvokeRequired)
            {
                SetCallback_bool Callback = new SetCallback_bool(SetNews5_Visibility);
                this.Invoke(Callback, new object[] { Value });
            }
            else
            {
                this.LblNews[4].Visible = Value;
            }
        }

        /* Allows the timer thread to change the door sensor image's visibility */
        private void SetDoor_Visibility(bool Value)
        {
            if (this.PicSensor[0].InvokeRequired)
            {
                SetCallback_bool Callback = new SetCallback_bool(SetDoor_Visibility);
                this.Invoke(Callback, new object[] { Value });
            }
            else
            {
                this.PicSensor[0].Visible = Value;
            }
        }

        /* Allows the timer thread to change the window sensor image's visibility */
        private void SetWindow_Visibility(bool Value)
        {
            if (this.PicSensor[1].InvokeRequired)
            {
                SetCallback_bool Callback = new SetCallback_bool(SetWindow_Visibility);
                this.Invoke(Callback, new object[] { Value });
            }
            else
            {
                this.PicSensor[1].Visible = Value;
            }
        }

        /* Allows the timer thread to change the motion sensor image's visibility */
        private void SetMotion_Visibility(bool Value)
        {
            if (this.PicSensor[2].InvokeRequired)
            {
                SetCallback_bool Callback = new SetCallback_bool(SetMotion_Visibility);
                this.Invoke(Callback, new object[] { Value });
            }
            else
            {
                this.PicSensor[2].Visible = Value;
            }
        }

        /* Allows the timer thread to change the fire sensor image's visibility */
        private void SetFire_Visibility(bool Value)
        {
            if (this.PicSensor[3].InvokeRequired)
            {
                SetCallback_bool Callback = new SetCallback_bool(SetFire_Visibility);
                this.Invoke(Callback, new object[] { Value });
            }
            else
            {
                this.PicSensor[3].Visible = Value;
            }
        }

        /* Disposes resources */
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                EventTimer.Stop();
                EventTimer.Dispose();
                components.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
