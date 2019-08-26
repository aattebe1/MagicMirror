/* 
 * MainForm.cs
 * 
 * Author: Austin Atteberry
 * 
 * Description: Creates the main window for
 *              the MagicMirror program
 * 
 */

namespace GUI
{
    public partial class Display : System.Windows.Forms.Form
    {
        delegate void SetCallback(string Text);
        delegate void SetCallback_Image(System.Drawing.Bitmap Image);

        private System.ComponentModel.IContainer components = null;
        private static System.Windows.Forms.Cursor NoCursor = MagicMirror.Cursor.None();
        private RaspberryPi.Sensors.Sensor[] SecuritySensors;
        private System.Timers.Timer EventTimer;
        private System.Windows.Forms.Label[] LblDateTime;
        private System.Windows.Forms.Label[] LblWeather;
        private System.Windows.Forms.Label[] LblNews;
        private System.Windows.Forms.PictureBox PicWeather;
        private System.Windows.Forms.Control[] CtlMain;
        private int NewsCount;
        private int EventCount;
        private bool[] SensorStatus;

        public Display()
        {
            this.SuspendLayout();
            this.SecuritySensors_Initialize();
            this.Interrupts_Initialize();
            this.EventCount_Initialize();
            this.NewsCount_Initialize();
            this.LblDateTime_Initialize();
            this.LblWeather_Initialize();
            this.PicWeather_Initialize();
            this.LblNews_Initialize();
            this.CtlMain_Initialize();
            this.FrmMain_Initialize();
            this.ResumeLayout(false);
            this.PerformLayout();
            this.LblWeather_SetText();
            this.LblNews_SetText();
            this.EventTimer_Initialize();
        }

        /* Initializes the security sensors */
        private void SecuritySensors_Initialize()
        {
            /* Initialize status array */
            this.SensorStatus = new bool[4] { false, false, false, false };

            /* Instantiate door sensors */
            this.SecuritySensors = new RaspberryPi.Sensors.Sensor[6];
            this.SecuritySensors[0] = new RaspberryPi.Sensors.DoorSensor(RaspberryPi.Pins.PIN_29);
            this.SecuritySensors[1] = new RaspberryPi.Sensors.DoorSensor(RaspberryPi.Pins.PIN_31);
            this.SecuritySensors[2] = new RaspberryPi.Sensors.WindowSensor(RaspberryPi.Pins.PIN_32);
            this.SecuritySensors[3] = new RaspberryPi.Sensors.MotionSensor(RaspberryPi.Pins.PIN_33);
            this.SecuritySensors[4] = new RaspberryPi.Sensors.MotionSensor(RaspberryPi.Pins.PIN_35);
            this.SecuritySensors[5] = new RaspberryPi.Sensors.FireSensor(RaspberryPi.Pins.PIN_36);

            /* Setup alarm pin */
            WiringPi.Core.pinMode(RaspberryPi.Pins.PIN_37, WiringPi.Constants.OUTPUT);
            WiringPi.Core.digitalWrite(RaspberryPi.Pins.PIN_37, WiringPi.Constants.LOW);
        }

        /* Initializes the hardware interrupts */
        private void Interrupts_Initialize()
        {
            /* Initialize button pins */
            WiringPi.Core.pinMode(RaspberryPi.Pins.PIN_38, WiringPi.Constants.INPUT);    // Reset button
            WiringPi.Core.pinMode(RaspberryPi.Pins.PIN_40, WiringPi.Constants.INPUT);    // Screen on/off button

            /* Set interrupts */
            WiringPi.Interrupts.wiringPiISR(RaspberryPi.Pins.PIN_29, WiringPi.Constants.INT_EDGE_BOTH, this.DoorSensor_Triggered);
            WiringPi.Interrupts.wiringPiISR(RaspberryPi.Pins.PIN_31, WiringPi.Constants.INT_EDGE_BOTH, this.DoorSensor_Triggered);
            WiringPi.Interrupts.wiringPiISR(RaspberryPi.Pins.PIN_32, WiringPi.Constants.INT_EDGE_BOTH, this.WindowSensor_Triggered);
            WiringPi.Interrupts.wiringPiISR(RaspberryPi.Pins.PIN_33, WiringPi.Constants.INT_EDGE_BOTH, this.MotionSensor_Triggered);
            WiringPi.Interrupts.wiringPiISR(RaspberryPi.Pins.PIN_35, WiringPi.Constants.INT_EDGE_BOTH, this.MotionSensor_Triggered);
            WiringPi.Interrupts.wiringPiISR(RaspberryPi.Pins.PIN_36, WiringPi.Constants.INT_EDGE_BOTH, this.FireSensor_Triggered);
            WiringPi.Interrupts.wiringPiISR(RaspberryPi.Pins.PIN_38, WiringPi.Constants.INT_EDGE_RISING, this.ResetButton_Triggered);
            WiringPi.Interrupts.wiringPiISR(RaspberryPi.Pins.PIN_40, WiringPi.Constants.INT_EDGE_RISING, this.ScreenButton_Triggered);
        }

        /* Initializes the event count to 0 */
        private void EventCount_Initialize()
        {
            this.EventCount = 0;
        }

        /* Initializes the news count to 0 */
        private void NewsCount_Initialize()
        {
            this.NewsCount = 0;
        }

        /* Initializes the date & time labels */
        private void LblDateTime_Initialize()
        {
            /* Instantiation */
            this.LblDateTime = new System.Windows.Forms.Label[2];

            /* Properties */
            for (int n = 0; n < LblDateTime.Length; n++)
            {
                this.LblDateTime[n] = new System.Windows.Forms.Label();
                this.LblDateTime[n].AllowDrop = false;
                this.LblDateTime[n].AutoEllipsis = false;
                this.LblDateTime[n].AutoSize = false;
                this.LblDateTime[n].BackColor = System.Drawing.Color.Transparent;
                this.LblDateTime[n].BorderStyle = System.Windows.Forms.BorderStyle.None;
                this.LblDateTime[n].Cursor = NoCursor;
                this.LblDateTime[n].Enabled = true;
                this.LblDateTime[n].FlatStyle = System.Windows.Forms.FlatStyle.Standard;
                this.LblDateTime[n].Font = new System.Drawing.Font(this.LblDateTime[n].Font.FontFamily, 30.0F);
                this.LblDateTime[n].ForeColor = System.Drawing.Color.White;
                this.LblDateTime[n].Size = new System.Drawing.Size(384, 62);
                this.LblDateTime[n].UseMnemonic = false;
                this.LblDateTime[n].Visible = true;
            }

            this.LblDateTime[0].Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left);
            this.LblDateTime[0].Location = new System.Drawing.Point(0, 0);
            this.LblDateTime[0].Padding = new System.Windows.Forms.Padding(10, 10, 0, 0);
            this.LblDateTime[0].TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.LblDateTime[0].Name = "Date";
            this.LblDateTime[0].Text = "Date";
            this.LblDateTime[1].Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
            this.LblDateTime[1].Location = new System.Drawing.Point(384, 0);
            this.LblDateTime[1].Padding = new System.Windows.Forms.Padding(0, 10, 10, 0);
            this.LblDateTime[1].TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.LblDateTime[1].Name = "Time";
            this.LblDateTime[1].Text = "Time";
        }

        /* Initializes the weather labels */
        private void LblWeather_Initialize()
        {
            /* Instantiation */
            this.LblWeather = new System.Windows.Forms.Label[3];

            /* Properties */
            for (int n = 0; n < this.LblWeather.Length; n++)
            {
                this.LblWeather[n] = new System.Windows.Forms.Label();
                this.LblWeather[n].AllowDrop = false;
                this.LblWeather[n].Anchor = System.Windows.Forms.AnchorStyles.Right;
                this.LblWeather[n].AutoEllipsis = false;
                this.LblWeather[n].AutoSize = false;
                this.LblWeather[n].BackColor = System.Drawing.Color.Transparent;
                this.LblWeather[n].BorderStyle = System.Windows.Forms.BorderStyle.None;
                this.LblWeather[n].Cursor = NoCursor;
                this.LblWeather[n].Enabled = true;
                this.LblWeather[n].FlatStyle = System.Windows.Forms.FlatStyle.Standard;
                this.LblWeather[n].ForeColor = System.Drawing.Color.White;
                this.LblWeather[n].Padding = new System.Windows.Forms.Padding(0, 0, 0, 0);
                this.LblWeather[n].TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                this.LblWeather[n].UseMnemonic = false;
                this.LblWeather[n].Visible = true;
                this.LblWeather[n].Width = 748;
            }

            this.LblWeather[0].Size = new System.Drawing.Size(374, 40);
            this.LblWeather[0].Font = new System.Drawing.Font(this.LblWeather[0].Font.FontFamily, 28.0F);
            this.LblWeather[0].Location = new System.Drawing.Point(384, 130);
            this.LblWeather[0].Name = "City";
            this.LblWeather[0].Text = "City";
            this.LblWeather[1].Size = new System.Drawing.Size(374, 60);
            this.LblWeather[1].Font = new System.Drawing.Font(this.LblWeather[1].Font.FontFamily, 39.0F);
            this.LblWeather[1].Location = new System.Drawing.Point(384, 175);
            this.LblWeather[1].Name = "Temperature";
            this.LblWeather[1].Text = "Temperature";
            this.LblWeather[2].Size = new System.Drawing.Size(366, 20);
            this.LblWeather[2].Font = new System.Drawing.Font(this.LblWeather[2].Font.FontFamily, 10.0F);
            this.LblWeather[2].Location = new System.Drawing.Point(384, 238);
            this.LblWeather[2].Name = "Condition";
            this.LblWeather[2].Text = "Condition";
        }

        /* Initializes the weather picture box */
        private void PicWeather_Initialize()
        {
            /* Instantiation */
            this.PicWeather = new System.Windows.Forms.PictureBox();

            /* Properties */
            this.PicWeather.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.PicWeather.BackColor = System.Drawing.Color.Transparent;
            this.PicWeather.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PicWeather.ClientSize = new System.Drawing.Size(43, 32);
            this.PicWeather.Cursor = NoCursor;
            this.PicWeather.Enabled = true;
            this.PicWeather.Image = GUI.Images.WeatherImages()[0];
            this.PicWeather.Location = new System.Drawing.Point(715, 270);
            this.PicWeather.Size = new System.Drawing.Size(43, 32);
            this.PicWeather.Visible = true;
        }

        /* Initializes the news label */
        private void LblNews_Initialize()
        {
            /* Instantiation */
            this.LblNews = new System.Windows.Forms.Label[5];

            /* Properties */
            for (int n = 0; n < this.LblNews.Length; n++)
            {
                this.LblNews[n] = new System.Windows.Forms.Label();
                this.LblNews[n].AllowDrop = false;
                this.LblNews[n].Anchor = System.Windows.Forms.AnchorStyles.Left;
                this.LblNews[n].AutoEllipsis = false;
                this.LblNews[n].AutoSize = true;
                this.LblNews[n].BackColor = System.Drawing.Color.Transparent;
                this.LblNews[n].BorderStyle = System.Windows.Forms.BorderStyle.None;
                this.LblNews[n].Cursor = NoCursor;
                this.LblNews[n].Enabled = true;
                this.LblNews[n].FlatStyle = System.Windows.Forms.FlatStyle.Standard;
                this.LblNews[n].ForeColor = System.Drawing.Color.White;
                this.LblNews[n].Font = new System.Drawing.Font(this.LblWeather[0].Font.FontFamily, (float)18.0);
                this.LblNews[n].MaximumSize = new System.Drawing.Size(490, 0);
                this.LblNews[n].Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
                this.LblNews[n].TextAlign = System.Drawing.ContentAlignment.TopLeft;
                this.LblNews[n].UseMnemonic = false;
                this.LblNews[n].Visible = true;
            }

            this.LblNews[0].Name = "News1";
            this.LblNews[0].SizeChanged += this.LblNews0_SizeChanged;
            this.LblNews[0].Text = "News headline 1";
            this.LblNews[0].Location = new System.Drawing.Point
                (
                    10, 312
                );

            this.LblNews[1].Name = "News2";
            this.LblNews[1].SizeChanged += this.LblNews1_SizeChanged;
            this.LblNews[1].Text = "News headline 2";
            this.LblNews[1].Location = new System.Drawing.Point
                (
                    10, this.LblNews[0].Location.Y + this.LblNews[0].Height + 10
                );

            this.LblNews[2].Name = "News3";
            this.LblNews[2].SizeChanged += this.LblNews2_SizeChanged;
            this.LblNews[2].Text = "News headline 3";
            this.LblNews[2].Location = new System.Drawing.Point
                (
                    10, this.LblNews[1].Location.Y + this.LblNews[1].Height + 10
                );

            this.LblNews[3].Name = "News4";
            this.LblNews[3].SizeChanged += this.LblNews3_SizeChanged;
            this.LblNews[3].Text = "News headline 4";
            this.LblNews[3].Location = new System.Drawing.Point
                (
                    10, this.LblNews[2].Location.Y + this.LblNews[2].Height + 10
                );

            this.LblNews[4].Name = "News5";
            this.LblNews[4].Text = "News headline 5";
            this.LblNews[4].Location = new System.Drawing.Point
                (
                    10, this.LblNews[3].Location.Y + this.LblNews[3].Height + 10
                );
        }

        /* Initializes the the main groupbox */
        private void CtlMain_Initialize()
        {
            this.CtlMain = new System.Windows.Forms.Control[11];

            this.CtlMain[0] = this.LblDateTime[0];
            this.CtlMain[1] = this.LblDateTime[1];
            this.CtlMain[2] = this.LblWeather[0];
            this.CtlMain[3] = this.LblWeather[1];
            this.CtlMain[4] = this.LblWeather[2];
            this.CtlMain[5] = this.PicWeather;
            this.CtlMain[6] = this.LblNews[0];
            this.CtlMain[7] = this.LblNews[1];
            this.CtlMain[8] = this.LblNews[2];
            this.CtlMain[9] = this.LblNews[3];
            this.CtlMain[10] = this.LblNews[4];

            this.CtlMain[0].Name = "DateControl";
            this.CtlMain[1].Name = "TimeControl";
            this.CtlMain[2].Name = "CityControl";
            this.CtlMain[3].Name = "TemperatureControl";
            this.CtlMain[4].Name = "ConditionControl";
            this.CtlMain[5].Name = "ConditionImageControl";
            this.CtlMain[6].Name = "NewsControl1";
            this.CtlMain[7].Name = "NewsControl2";
            this.CtlMain[8].Name = "NewsControl3";
            this.CtlMain[9].Name = "NewsControl4";
            this.CtlMain[10].Name = "NewsControl5";
        }

        /* Initializes MagicMirror's main (only) form */
        private void FrmMain_Initialize()
        {
            /* Properties */
            this.AllowDrop = false;
            this.AllowTransparency = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.AddRange(this.CtlMain);
            this.Cursor = NoCursor;
            this.Enabled = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = MagicMirror.Icon.MainIcon();
            this.MaximumSize = new System.Drawing.Size(768, 1366);
            this.MinimumSize = new System.Drawing.Size(768, 1366);
            this.Name = "FrmMain";
            this.Size = new System.Drawing.Size(768, 1366);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Magic Mirror 3";
            this.TopMost = true;
            this.Visible = true;

            /* Events */
            this.Load += new System.EventHandler(this.FrmMain_Load);
        }

        /* Sets the text/image in the city, temperature, and condition labels */
        private void LblWeather_SetText()
        {
            string[] weather = Weather.CurrentWeather.GetWeather(Weather.CurrentWeather.URL);
            int result = 0;
            System.Int32.TryParse(weather[3], out result);

            try
            {
                this.LblWeather[0].Text = weather[0];
                this.LblWeather[1].Text = weather[1];
                this.LblWeather[2].Text = weather[2];
                this.PicWeather.Image = GUI.Images.WeatherImages()[result];
            }
            catch (System.IndexOutOfRangeException ex)
            {
                this.LblWeather[0].Text = ex.Message;
                this.LblWeather[1].Text = ex.Message;
                this.LblWeather[2].Text = ex.Message;
            }
            catch (System.Exception ex)
            {
                this.LblWeather[0].Text = ex.Message;
                this.LblWeather[1].Text = ex.Message;
                this.LblWeather[2].Text = ex.Message;
            }
        }

        private void LblNews_SetText()
        {
            string[] news = News.CurrentNews.GetRss(News.CurrentNews.URL[this.NewsCount]);

            if (news.Length == this.LblNews.Length)
            {
                for (int n = 0; n < this.LblNews.Length; n++)
                {
                    this.LblNews[n].Text = news[n];
                }

                this.NewsCount++;
            }
        }

        /* Initializes the program event timer */
        private void EventTimer_Initialize()
        {
            this.EventTimer = new System.Timers.Timer(500);
            this.EventTimer.Elapsed += EventTimer_Elapsed;
            this.EventTimer.AutoReset = true;
            this.EventTimer.Enabled = true;
            this.EventTimer.Start();
        }
    }
}
