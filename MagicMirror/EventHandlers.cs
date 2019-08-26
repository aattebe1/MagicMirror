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

        /* Handles the LblNews[1] size changed event */
        private void LblNews1_SizeChanged(object sender, System.EventArgs e)
        {
            /* Set new position for the next label */
            this.LblNews[2].Location = new System.Drawing.Point(10, this.LblNews[1].Location.Y + this.LblNews[1].Height + 10);
        }

        /* Handles the LblNews[2] size changed event */
        private void LblNews2_SizeChanged(object sender, System.EventArgs e)
        {
            /* Set new position for the next label */
            this.LblNews[3].Location = new System.Drawing.Point(10, this.LblNews[2].Location.Y + this.LblNews[2].Height + 10);
        }

        /* Handles the LblNews[3] size changed event */
        private void LblNews3_SizeChanged(object sender, System.EventArgs e)
        {
            /* Set new position for the next label */
            this.LblNews[4].Location = new System.Drawing.Point(10, this.LblNews[3].Location.Y + this.LblNews[3].Height + 10);
        }

        /* Handles the door alarm event */
        private void DoorSensor_Triggered()
        {
            if (this.SensorStatus[0])
            {
                /* ADD CODE TO CHANGE DOOR PICTURE TO NOT ACTIVATED */
                WiringPi.Core.digitalWrite(RaspberryPi.Pins.PIN_37, WiringPi.Constants.LOW);
                this.SensorStatus[0] = false;
            }
            else
            {
                /* ADD CODE TO CHANGE DOOR PICTURE TO ACTIVATED */
                WiringPi.Core.digitalWrite(RaspberryPi.Pins.PIN_37, WiringPi.Constants.HIGH);
                this.SensorStatus[0] = true;
            }
        }

        /* Handles the window alarm event */
        private void WindowSensor_Triggered()
        {
            if (this.SensorStatus[1])
            {
                /* ADD CODE TO CHANGE WINDOW PICTURE TO NOT ACTIVATED */
                WiringPi.Core.digitalWrite(RaspberryPi.Pins.PIN_37, WiringPi.Constants.LOW);
                this.SensorStatus[1] = false;
            }
            else
            {
                /* ADD CODE TO CHANGE WINDOW PICTURE TO ACTIVATED */
                WiringPi.Core.digitalWrite(RaspberryPi.Pins.PIN_37, WiringPi.Constants.HIGH);
                this.SensorStatus[1] = true;
            }
        }

        /* Handles the motion alarm event */
        private void MotionSensor_Triggered()
        {
            if (this.SensorStatus[2])
            {
                /* ADD CODE TO CHANGE MOTION PICTURE TO NOT ACTIVATED */
                WiringPi.Core.digitalWrite(RaspberryPi.Pins.PIN_37, WiringPi.Constants.LOW);
                this.SensorStatus[2] = false;
            }
            else
            {
                /* ADD CODE TO CHANGE MOTION PICTURE TO ACTIVATED */
                WiringPi.Core.digitalWrite(RaspberryPi.Pins.PIN_37, WiringPi.Constants.HIGH);
                this.SensorStatus[2] = true;
            }
        }

        /* Handles the fire alarm event */
        private void FireSensor_Triggered()
        {
            if (this.SensorStatus[3])
            {
                /* ADD CODE TO CHANGE FIRE PICTURE TO NOT ACTIVATED */
                WiringPi.Core.digitalWrite(RaspberryPi.Pins.PIN_37, WiringPi.Constants.LOW);
                this.SensorStatus[3] = false;
            }
            else
            {
                /* ADD CODE TO CHANGE FIRE PICTURE TO ACTIVATED */
                WiringPi.Core.digitalWrite(RaspberryPi.Pins.PIN_37, WiringPi.Constants.HIGH);
                this.SensorStatus[3] = true;
            }
        }

        /* Handles the reset button event */
        private void ResetButton_Triggered()
        {

        }

        /* Handles the screen on/off button event */
        private void ScreenButton_Triggered()
        {

        }

        /* Handles the date/time timer elapsed event */
        private void EventTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
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

                /* Update news labels */
                SetNews1(news[0]);
                SetNews2(news[1]);
                SetNews3(news[2]);
                SetNews4(news[3]);
                SetNews5(news[4]);

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
                SetCondition_Image(GUI.Images.WeatherImages()[result]);
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

		/* Allows the timer thread to update the first news labels */
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

        /* Allows the timer thread to update the second news labels */
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

        /* Allows the timer thread to update the third news labels */
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

        /* Allows the timer thread to update the fourth news labels */
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

        /* Allows the timer thread to update the fifth news labels */
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