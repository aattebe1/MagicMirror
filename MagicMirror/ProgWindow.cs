/* 
 * ProgWindow.cs
 * 
 * Author: Austin Atteberry
 * 
 * Description: Creates the main window for
 *              the MagicMirror program
 * 
 */

namespace MagicMirror
{
    public class ProgWindow
    {
        private int NewsCount;
        private bool[] SensorStatus;
        private System.Timers.Timer[] ProgTimers;
        private Gdk.Color WindowColor;
        private Gdk.Color FontColor;
        private Headlines[] NewsFeed;
        private Weather WeatherInfo;
        private Gtk.Label[] ProgLabels;
        private Gtk.Label[] SpaceLabel;
        private Gtk.Label SensorLabel;
        private Gtk.Image[] ProgImage;
        private Gtk.Frame[] ProgFrame;
        private Gtk.Alignment[] ProgAlignment;
        private Gtk.Box[] ProgBox;
        private Gtk.Window MagicWindow;
        private Sensors.Sensor[] ProgSensors;

        /* Constructs a ProgWindow object */
        public ProgWindow()
        {
            /* Setup wiringPi */
            WiringPi.Core.wiringPiSetup();

            /* Instantiate arrays */
            this.NewsFeed = MagicMirrorObjects.SetupHeadlines();
            this.WeatherInfo = MagicMirrorObjects.SetupWeather();
            this.ProgLabels = new Gtk.Label[10];
            this.SpaceLabel = new Gtk.Label[4];
            this.ProgImage = new Gtk.Image[2];
            this.ProgFrame = new Gtk.Frame[2];
            this.ProgAlignment = new Gtk.Alignment[2];
            this.ProgBox = new Gtk.Box[6];

            /* Instantiate label */
            this.SensorLabel = new Gtk.Label();

            /* Initialize NewsCount to 0 */
            this.NewsCount = 0;

            /* Define program colors */
            this.WindowColor = new Gdk.Color(0x00, 0x00, 0x00);
            this.FontColor = new Gdk.Color(0xff, 0xff, 0xff);

            /* Setup UI elements */
            UIElements.SetupProgLabels(ref this.ProgLabels, this.FontColor);
            UIElements.SetupSpaceLabels(ref this.SpaceLabel, this.FontColor);
            UIElements.SetupSensorLabel(ref this.SensorLabel, this.FontColor);
            UIElements.SetupImages(ref this.ProgImage);
            UIElements.SetupFrames(ref this.ProgFrame, ref this.ProgImage);
            UIElements.SetupAlignments(ref this.ProgAlignment, ref this.ProgFrame);
            UIElements.SetupBoxes(ref this.ProgBox, ref this.ProgLabels, ref this.SpaceLabel, ref this.ProgAlignment);
            UIElements.SetupWindow(ref this.MagicWindow, ref this.WindowColor, ref this.ProgBox);

            /* Timers */
            this.SetupTimers();

            this.WeatherInit();
            this.NewsFeedInit();

            this.ProgLabels[3].Text = this.WeatherInfo.GetCityName();

            /* Sensors */
            this.SensorStatus = new bool[4];
            this.SensorStatus[0] = false;
            this.SensorStatus[1] = false;
            this.SensorStatus[2] = false;
            this.SensorStatus[3] = false;
            this.SetupSensors();
            this.SetupInterrupts();
        }

        /* Displays the weather immediately without waiting for the timer */
        private void WeatherInit()
        {
            this.WeatherInfo.UpdateWeather();
            this.ProgLabels[2].Text = this.WeatherInfo.GetCurrentTemperature();
            this.ProgLabels[4].Text = this.WeatherInfo.GetWeatherCondition();
            this.ProgImage[0].Pixbuf = Gdk.Pixbuf.LoadFromResource(this.WeatherInfo.GetWeatherImage());
        }

        /* Displays the news feed immediately without waiting for the timer   *
         * Note: This code is identical to the UpdateNews method, but placing *
         *       it inside a separate method and calling it from both of the  *
         *       implementing methods was causing the program to crash        */
        private void NewsFeedInit()
        {
            try {
                /* Create string array to store news strings */
                string[] NewsStrings = new string[5];

                /* Download news and store to array */
                this.NewsFeed[this.NewsCount].DownloadNews();
                this.NewsFeed[this.NewsCount].GetRss(ref NewsStrings);

                /* Display news items in program */
                this.ProgLabels[5].Text = NewsStrings[0];
                this.ProgLabels[6].Text = NewsStrings[1];
                this.ProgLabels[7].Text = NewsStrings[2];
                this.ProgLabels[8].Text = NewsStrings[3];
                this.ProgLabels[9].Text = NewsStrings[4];

                /* Increment NewsCount, reset if 10 */
                switch (this.NewsCount)
                {
                    case 10:
                        this.NewsCount = 0;
                        break;
                    default:
                        this.NewsCount++;
                        break;
                }
            }
            catch (System.IndexOutOfRangeException ex) {
                /* This exception shouldn't occur because NewsCount is *
                 * reset before exceeding the range of NewsFeed[]      */

                /* Display error message in news feed */
                this.ProgLabels[5].Text = ex.Message;
                this.ProgLabels[6].Text = ex.Message;
                this.ProgLabels[7].Text = ex.Message;
                this.ProgLabels[8].Text = ex.Message;
                this.ProgLabels[9].Text = ex.Message;

                /* Reset NewsCount */
                this.NewsCount = 0;
            }
        }

        /* Configures the timers */
        private void SetupTimers()
        {
            this.ProgTimers = new System.Timers.Timer[3];

            this.ProgTimers[0] = new System.Timers.Timer(500);       // Clock timer
            this.ProgTimers[1] = new System.Timers.Timer(60000);     // Weather update timer
            this.ProgTimers[2] = new System.Timers.Timer(30000);     // News feed timer

            this.ProgTimers[0].Elapsed += this.UpdateClock;
            this.ProgTimers[1].Elapsed += this.RefreshWeather;
            this.ProgTimers[2].Elapsed += this.UpdateNews;

            this.ProgTimers[0].Start();
            this.ProgTimers[1].Start();
            this.ProgTimers[2].Start();
        }

        /* Updates the clock label with the current time */
        private void UpdateClock(System.Object sender, System.Timers.ElapsedEventArgs e)
        {
            string MonthName = null;

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

            this.ProgLabels[0].Text = e.SignalTime.DayOfWeek.ToString() + ", " + MonthName + " " + e.SignalTime.Day.ToString();
            this.ProgLabels[1].Text = e.SignalTime.ToShortTimeString();
                 
        }

        /* Updates the news feed                                              *
         * Note: This code is identical to the UpdateNews method, but placing *
         *       it inside a separate method and calling it from both of the  *
         *       implementing methods was causing the program to crash        */
        private void UpdateNews(System.Object sender, System.Timers.ElapsedEventArgs e)
        {
            try {
                /* Create string array to store news strings */
                string[] NewsStrings = new string[5];

                /* Download news and store to array */
                this.NewsFeed[this.NewsCount].DownloadNews();
                this.NewsFeed[this.NewsCount].GetRss(ref NewsStrings);

                /* Display news items in program */
                this.ProgLabels[5].Text = NewsStrings[0];
                this.ProgLabels[6].Text = NewsStrings[1];
                this.ProgLabels[7].Text = NewsStrings[2];
                this.ProgLabels[8].Text = NewsStrings[3];
                this.ProgLabels[9].Text = NewsStrings[4];

                /* Increment NewsCount, reset if 10 */
                switch (this.NewsCount)
                {
                    case 10:
                        this.NewsCount = 0;
                        break;
                    default:
                        this.NewsCount++;
                        break;
                }
            }
            catch (System.IndexOutOfRangeException ex) {
                /* This exception shouldn't occur because NewsCount is *
                 * reset before exceeding the range of NewsFeed[]      */

                /* Display error message in news feed */
                this.ProgLabels[5].Text = ex.Message;
                this.ProgLabels[6].Text = ex.Message;
                this.ProgLabels[7].Text = ex.Message;
                this.ProgLabels[8].Text = ex.Message;
                this.ProgLabels[9].Text = ex.Message;

                /* Reset NewsCount */
                this.NewsCount = 0;
            }
        }

        /* Updates the weather information */
        private void RefreshWeather(System.Object sender, System.Timers.ElapsedEventArgs e)
        {
            this.WeatherInfo.UpdateWeather();
            this.ProgLabels[2].Text = this.WeatherInfo.GetCurrentTemperature();
            this.ProgLabels[4].Text = this.WeatherInfo.GetWeatherCondition();
            this.ProgImage[0].Pixbuf = Gdk.Pixbuf.LoadFromResource(this.WeatherInfo.GetWeatherImage());
        }

        /* Configures the home-monitoring sensors */
        private void SetupSensors()
        {
            this.ProgSensors = new Sensors.Sensor[4];

            this.ProgSensors[0] = new Sensors.DoorSensor(29);
            this.ProgSensors[1] = new Sensors.WindowSensor(28);
            this.ProgSensors[2] = new Sensors.FireSensor(25);
            this.ProgSensors[3] = new Sensors.MotionSensor(23, 24);
        }

        /* Sets the hardware interrupts for the sensors */
        private void SetupInterrupts()
        {
            WiringPi.Interrupts.wiringPiISR(29, WiringPi.Constants.INT_EDGE_BOTH, DoorSensor_OnInterrupt);
            WiringPi.Interrupts.wiringPiISR(28, WiringPi.Constants.INT_EDGE_BOTH, WindowSensor_OnInterrupt);
        }

        private void DoorSensor_OnInterrupt()
        {
            this.SensorStatus[0] = !this.SensorStatus[0];
        }

        private void WindowSensor_OnInterrupt()
        {
            this.SensorStatus[1] = !this.SensorStatus[1];
        }

        /* Exits the program */
        public static void MainWindow_Delete(object o, Gtk.DeleteEventArgs args)
        {
            Gtk.Application.Quit();    // Exit program
        }
    }
}
