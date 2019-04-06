/* 
 * Weather.cs
 * 
 * Author: Austin Atteberry
 * 
 * Description: Defines the Weather class for reading
 *              weather data from an RSS feed
 * 
 */

namespace MagicMirror
{
	public class Weather
    {
        private string weatherUrl, cityName, curTemperature, weatherCondition;
        private string[] conditionImage;
        private int imageIndex;

        public Weather(string weatherUrl)
        {
            this.weatherUrl = weatherUrl;
            this.cityName = "null";
            this.curTemperature = "null";
            this.imageIndex = 0;
            this.conditionImage = new string[19];
            this.InitializeImageResources();
        }

        private void InitializeImageResources()
        {
            this.conditionImage[0] = "MagicMirror.images.default.gif";
            this.conditionImage[1] = "MagicMirror.images.01d.gif";
            this.conditionImage[2] = "MagicMirror.images.01n.gif";
            this.conditionImage[3] = "MagicMirror.images.02d.gif";
            this.conditionImage[4] = "MagicMirror.images.02n.gif";
            this.conditionImage[5] = "MagicMirror.images.03d.gif";
            this.conditionImage[6] = "MagicMirror.images.03n.gif";
            this.conditionImage[7] = "MagicMirror.images.04d.gif";
            this.conditionImage[8] = "MagicMirror.images.04n.gif";
            this.conditionImage[9] = "MagicMirror.images.09d.gif";
            this.conditionImage[10] = "MagicMirror.images.09n.gif";
            this.conditionImage[11] = "MagicMirror.images.10d.gif";
            this.conditionImage[12] = "MagicMirror.images.10n.gif";
            this.conditionImage[13] = "MagicMirror.images.11d.gif";
            this.conditionImage[14] = "MagicMirror.images.11n.gif";
            this.conditionImage[15] = "MagicMirror.images.13d.gif";
            this.conditionImage[16] = "MagicMirror.images.13n.gif";
            this.conditionImage[17] = "MagicMirror.images.50d.gif";
            this.conditionImage[18] = "MagicMirror.images.50n.gif";
        }

        /* Sets the correct image index for the current weather condition */
        private void SetImageIndex(string iconString)
        {
            switch(iconString)
            {
                case "01d":
                    this.imageIndex = 1;
                    break;
                case "01n":
                    this.imageIndex = 2;
                    break;
                case "02d":
                    this.imageIndex = 3;
                    break;
                case "02n":
                    this.imageIndex = 4;
                    break;
                case "03d":
                    this.imageIndex = 5;
                    break;
                case "03n":
                    this.imageIndex = 6;
                    break;
                case "04d":
                    this.imageIndex = 7;
                    break;
                case "04n":
                    this.imageIndex = 8;
                    break;
                case "09d":
                    this.imageIndex = 9;
                    break;
                case "09n":
                    this.imageIndex = 10;
                    break;
                case "10d":
                    this.imageIndex = 11;
                    break;
                case "10n":
                    this.imageIndex = 12;
                    break;
                case "11d":
                    this.imageIndex = 13;
                    break;
                case "11n":
                    this.imageIndex = 14;
                    break;
                case "13d":
                    this.imageIndex = 15;
                    break;
                case "13n":
                    this.imageIndex = 16;
                    break;
                case "50d":
                    this.imageIndex = 17;
                    break;
                case "50n":
                    this.imageIndex = 18;
                    break;
                default:
                    this.imageIndex = 0;
                    break;
            }
        }

        public void UpdateWeather()
        {
			try {
                System.Net.WebClient weatherClient = new System.Net.WebClient();
                System.Xml.XmlDocument weatherDoc = new System.Xml.XmlDocument();
                System.Globalization.TextInfo CondTextInfo = new System.Globalization.CultureInfo("en-US", false).TextInfo;
                double tempDbl;
                int tempInt;
                string iconString;

                /* Download weather feed */
                weatherDoc.LoadXml(weatherClient.DownloadString(this.weatherUrl));
                System.Xml.XmlNode cityNode = weatherDoc.SelectSingleNode("current/city");
                System.Xml.XmlNode temperatureNode = weatherDoc.SelectSingleNode("current/temperature");
                System.Xml.XmlNode conditionNode = weatherDoc.SelectSingleNode("current/weather");
                this.cityName = cityNode.Attributes["name"].Value;

                /* Round the temperature to whole number */
                System.Double.TryParse(temperatureNode.Attributes["value"].Value, out tempDbl);
                tempDbl = System.Math.Round(tempDbl, System.MidpointRounding.AwayFromZero);
                tempInt = (int)tempDbl;
                this.curTemperature = tempInt.ToString() + "° F";

                /* Get weather icon */
                this.weatherCondition = CondTextInfo.ToTitleCase(conditionNode.Attributes["value"].Value);
                iconString = conditionNode.Attributes["icon"].Value;
                this.SetImageIndex(iconString);

                /* Clean up resource */
                if (weatherDoc != null)
                {
                    weatherClient.Dispose();
                }
            }
			catch (System.Net.WebException ex) {
                System.Console.WriteLine("{0}", ex);
                Gtk.Application.Quit();
            }
			catch (System.Exception ex) {
                System.Console.WriteLine("{0}", ex);
                Gtk.Application.Quit();
            }
        }

        /* Returns the city name as a string */
        public string GetCityName()
        {
            return this.cityName;
        }

        /* Returns the current temperature as a string */
        public string GetCurrentTemperature()
        {
            return this.curTemperature;
        }

        /* Returns a string with all weather information */
        public string GetWeatherInfo()
        {
            return this.cityName + " " + this.curTemperature;
        }

        /* Returns weather condition string */
        public string GetWeatherCondition()
        {
            return this.weatherCondition;
        }

        /* Returns weather condition icon */
        public string GetWeatherImage()
        {
            return this.conditionImage[this.imageIndex];
        }
    }
}