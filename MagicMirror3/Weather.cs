/* 
 * Weather.cs
 * 
 * Author: Austin Atteberry
 * 
 * Description: Defines the static Weather class for
 *              retrieving weather data from an RSS feed
 * 
 */

namespace Weather
{
	public static class CurrentWeather
    {
        public static string URL = System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String(
            "aHR0cDovL2FwaS5vcGVud2VhdGhlcm1hcC5vcmcvZGF0YS8yLjUvd2VhdGhlcj9BUFBJRD01YTM4MmFkYjM0ZTI5N2NlNjQ3ZGVmMWVmYmJmZDRlNyZpZD00MTgwNDM5Jm1vZGU9eG1sJnVuaXRzPWltcGVyaWFs"));

        /* Sets the correct image index for the current weather condition */
        private static string SetImageIndex(string IconString)
        {
            switch(IconString)
            {
                case "01d":
                    return "1";
                case "01n":
                    return "2";
                case "02d":
                    return "3";
                case "02n":
                    return "4";
                case "03d":
                    return "5";
                case "03n":
                    return "6";
                case "04d":
                    return "7";
                case "04n":
                    return "8";
                case "09d":
                    return "9";
                case "09n":
                    return "10";
                case "10d":
                    return "11";
                case "10n":
                    return "12";
                case "11d":
                    return "13";
                case "11n":
                    return "14";
                case "13d":
                    return "15";
                case "13n":
                    return "16";
                case "50d":
                    return "17";
                case "50n":
                    return "18";
            }

            return "0";
        }

        /* Retrieves the weather information and returns it in a string array */
        public static string[] GetWeather(string WeatherUrl)
        {
            string[] weatherInfo = new string[4];

            try
            {
                System.Net.WebClient weatherClient = new System.Net.WebClient();
                System.Xml.XmlDocument weatherDoc = new System.Xml.XmlDocument();
                System.Globalization.TextInfo CondTextInfo = new System.Globalization.CultureInfo("en-US", false).TextInfo;
                double tempDbl;
                int tempInt;
                string iconString;

                /* Download weather feed */
                weatherDoc.LoadXml(weatherClient.DownloadString(WeatherUrl));
                System.Xml.XmlNode cityNode = weatherDoc.SelectSingleNode("current/city");
                System.Xml.XmlNode temperatureNode = weatherDoc.SelectSingleNode("current/temperature");
                System.Xml.XmlNode conditionNode = weatherDoc.SelectSingleNode("current/weather");
                weatherInfo[0] = cityNode.Attributes["name"].Value;

                /* Round the temperature to whole number */
                System.Double.TryParse(temperatureNode.Attributes["value"].Value, out tempDbl);
                tempDbl = System.Math.Round(tempDbl, System.MidpointRounding.AwayFromZero);
                tempInt = (int)tempDbl;
                weatherInfo[1] = tempInt.ToString() + "° F";

                /* Get weather icon */
                weatherInfo[2] = CondTextInfo.ToTitleCase(conditionNode.Attributes["value"].Value);
                iconString = conditionNode.Attributes["icon"].Value;
                weatherInfo[3] = SetImageIndex(iconString);

                /* Clean up resource */
                if (weatherDoc != null)
                {
                    weatherClient.Dispose();
                }
            }
			catch (System.Net.WebException ex)
            {
                System.Console.WriteLine();
                return new string[] { ex.Message, ex.Message, ex.Message, "0" };
            }
			catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.Message);
                return new string[] { ex.Message, ex.Message, ex.Message, "0" };
            }

            return weatherInfo;
        }
    }
}