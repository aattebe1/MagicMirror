/* 
 * MagicMirrorObjects.cs
 * 
 * Author: Austin Atteberry
 * 
 * Description: Creates the Magic Mirror objects
 * 
 */

namespace MagicMirror
{
	public static class MagicMirrorObjects
    {
        /* Instantiates the Headlines array */
		public static Headlines[] SetupHeadlines()
        {
            Headlines[] NewsFeed = new Headlines[11];

            /*NewsFeed[0] = new Headlines("/MagicMirror/domesticNews.xml", "http://feeds.reuters.com/Reuters/domesticNews");
            NewsFeed[1] = new Headlines("/MagicMirror/topNews.xml", "http://feeds.reuters.com/reuters/topNews");
            NewsFeed[2] = new Headlines("/MagicMirror/peopleNews.xml", "http://feeds.reuters.com/reuters/peopleNews");
            NewsFeed[3] = new Headlines("/MagicMirror/technologyNews.xml", "http://feeds.reuters.com/reuters/technologyNews");
            NewsFeed[4] = new Headlines("/MagicMirror/businessNews.xml", "http://feeds.reuters.com/reuters/businessNews");
            NewsFeed[5] = new Headlines("/MagicMirror/entertainment.xml", "http://feeds.reuters.com/reuters/entertainment");
            NewsFeed[6] = new Headlines("/MagicMirror/PoliticsNews.xml", "http://feeds.reuters.com/Reuters/PoliticsNews");
            NewsFeed[7] = new Headlines("/MagicMirror/lifestyle.xml", "http://feeds.reuters.com/reuters/lifestyle");
            NewsFeed[8] = new Headlines("/MagicMirror/healthNews.xml", "http://feeds.reuters.com/reuters/healthNews");
            NewsFeed[9] = new Headlines("/MagicMirror/worldNews.xml", "http://feeds.reuters.com/Reuters/worldNews");
            NewsFeed[10] = new Headlines("/MagicMirror/sportsNews.xml", "http://feeds.reuters.com/reuters/sportsNews");*/

            NewsFeed[0] = new Headlines("/MagicMirror/domesticNews.xml", System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String(
                "aHR0cDovL2ZlZWRzLnJldXRlcnMuY29tL1JldXRlcnMvZG9tZXN0aWNOZXdz")));
            NewsFeed[1] = new Headlines("/MagicMirror/topNews.xml", System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String(
                "aHR0cDovL2ZlZWRzLnJldXRlcnMuY29tL3JldXRlcnMvdG9wTmV3cw==")));
            NewsFeed[2] = new Headlines("/MagicMirror/peopleNews.xml", System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String(
                "aHR0cDovL2ZlZWRzLnJldXRlcnMuY29tL3JldXRlcnMvcGVvcGxlTmV3cw==")));
            NewsFeed[3] = new Headlines("/MagicMirror/technologyNews.xml", System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String(
                "aHR0cDovL2ZlZWRzLnJldXRlcnMuY29tL3JldXRlcnMvdGVjaG5vbG9neU5ld3M=")));
            NewsFeed[4] = new Headlines("/MagicMirror/businessNews.xml", System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String(
                "aHR0cDovL2ZlZWRzLnJldXRlcnMuY29tL3JldXRlcnMvYnVzaW5lc3NOZXdz")));
            NewsFeed[5] = new Headlines("/MagicMirror/entertainment.xml", System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String(
                "aHR0cDovL2ZlZWRzLnJldXRlcnMuY29tL3JldXRlcnMvZW50ZXJ0YWlubWVudA==")));
            NewsFeed[6] = new Headlines("/MagicMirror/PoliticsNews.xml", System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String(
                "aHR0cDovL2ZlZWRzLnJldXRlcnMuY29tL1JldXRlcnMvUG9saXRpY3NOZXdz")));
            NewsFeed[7] = new Headlines("/MagicMirror/lifestyle.xml", System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String(
                "aHR0cDovL2ZlZWRzLnJldXRlcnMuY29tL3JldXRlcnMvbGlmZXN0eWxl")));
            NewsFeed[8] = new Headlines("/MagicMirror/healthNews.xml", System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String(
                "aHR0cDovL2ZlZWRzLnJldXRlcnMuY29tL3JldXRlcnMvaGVhbHRoTmV3cw==")));
            NewsFeed[9] = new Headlines("/MagicMirror/worldNews.xml", System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String(
                "aHR0cDovL2ZlZWRzLnJldXRlcnMuY29tL1JldXRlcnMvd29ybGROZXdz")));
            NewsFeed[10] = new Headlines("/MagicMirror/sportsNews.xml", System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String(
                "aHR0cDovL2ZlZWRzLnJldXRlcnMuY29tL3JldXRlcnMvc3BvcnRzTmV3cw==")));

            return NewsFeed;
        }

        /* Instantiates the Weather object */
        public static Weather SetupWeather()
        {
            //Weather WeatherInfo = new Weather("http://api.openweathermap.org/data/2.5/weather?APPID=5a382adb34e297ce647def1efbbfd4e7&id=4180439&mode=xml&units=imperial");

            Weather WeatherInfo = new Weather(System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String (
                        "aHR0cDovL2FwaS5vcGVud2VhdGhlcm1hcC5vcmcvZGF0YS8yLjUvd2VhdGhlcj9BUFBJRD01YTM4MmFkYjM0ZTI5N2NlNjQ3ZGVmMWVmYmJmZDRlNyZpZD00MTgwNDM5Jm1vZGU9eG1sJnVuaXRzPWltcGVyaWFs")));

            return WeatherInfo;
        }
    }
}