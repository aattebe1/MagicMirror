/* 
 * News.cs
 * 
 * Author: Austin Atteberry
 * 
 * Description: Defines the News class for reading
 *              news headlines from an RSS feed
 * 
 */

namespace News
{
    public static class CurrentNews
    {
        public static string[] URL = new string[]
        {
            "http://rss.cnn.com/rss/cnn_topstories.rss",
            "http://rss.cnn.com/rss/cnn_world.rss",
            "http://rss.cnn.com/rss/cnn_us.rss",
            "http://rss.cnn.com/rss/money_latest.rss",
            "http://rss.cnn.com/rss/cnn_allpolitics.rss",
            "http://rss.cnn.com/rss/cnn_tech.rss",
            "http://rss.cnn.com/rss/cnn_health.rss",
            "http://rss.cnn.com/rss/cnn_showbiz.rss",
            "http://rss.cnn.com/rss/cnn_travel.rss",
            "http://rss.cnn.com/rss/cnn_freevideo.rss",
            "http://rss.cnn.com/rss/cnn_latest.rss"
        };

        public static string[] XmlFile = new string[]
        {
            "/News/cnn_topstories.rss",
            "/News/cnn_world.rss",
            "/News/cnn_us.rss",
            "/News/money_latest.rss",
            "/News/cnn_allpolitics.rss",
            "/News/cnn_tech.rss",
            "/News/cnn_health.rss",
            "/News/cnn_showbiz.rss",
            "/News/cnn_travel.rss",
            "/News/cnn_freevideo.rss",
            "/News/cnn_latest.rss"
        };

        public static string[] GetRss(string Url)
        {
            string[] RssArray = new string[5];

            /* Handle XmlReader and SyndicationFeed exceptions */
            try
            {
                //using (System.IO.FileStream RssReader = System.IO.File.Open(Url, System.IO.FileMode.Open))
                using (System.Net.WebClient RssReader = new System.Net.WebClient())
                {
                    System.Xml.XmlDocument NewsDoc = new System.Xml.XmlDocument();
                    //NewsDoc.Load(RssReader);
                    NewsDoc.LoadXml(RssReader.DownloadString(Url));

                    int n = 0;

                    foreach (System.Xml.XmlNode NewsItem in NewsDoc.SelectNodes("rss/channel/item/title"))
                    {
                        RssArray[n] = NewsItem.InnerText;

                        n++;

                        if (n == RssArray.Length)
                        {
                            break;
                        }
                    }
                }
            }
            catch (System.Net.WebException ex) {
                RssArray[0] = "WebException: " + ex.Message;
                RssArray[1] = "WebException: " + ex.Message;
                RssArray[2] = "WebException: " + ex.Message;
                RssArray[3] = "WebException: " + ex.Message;
                RssArray[4] = "WebException: " + ex.Message;
            }
            catch (System.ArgumentNullException ex)
            {
                RssArray[0] = "ArgumentNullException: " + ex.Message;
                RssArray[1] = "ArgumentNullException: " + ex.Message;
                RssArray[2] = "ArgumentNullException: " + ex.Message;
                RssArray[3] = "ArgumentNullException: " + ex.Message;
                RssArray[4] = "ArgumentNullException: " + ex.Message;
            }
            catch (System.InvalidOperationException ex)
            {
                RssArray[0] = "InvalidOperationException: " + ex.Message;
                RssArray[1] = "InvalidOperationException: " + ex.Message;
                RssArray[2] = "InvalidOperationException: " + ex.Message;
                RssArray[3] = "InvalidOperationException: " + ex.Message;
                RssArray[4] = "InvalidOperationException: " + ex.Message;
            }
            catch (System.UriFormatException ex)
            {
                RssArray[0] = "UriFormatException: " + ex.Message;
                RssArray[1] = "UriFormatException: " + ex.Message;
                RssArray[2] = "UriFormatException: " + ex.Message;
                RssArray[3] = "UriFormatException: " + ex.Message;
                RssArray[4] = "UriFormatException: " + ex.Message;
            }
            catch (System.IO.FileNotFoundException ex)
            {
                RssArray[0] = "FileNotFoundException: " + ex.Message;
                RssArray[1] = "FileNotFoundException: " + ex.Message;
                RssArray[2] = "FileNotFoundException: " + ex.Message;
                RssArray[3] = "FileNotFoundException: " + ex.Message;
                RssArray[4] = "FileNotFoundException: " + ex.Message;
            }
            catch (System.Security.SecurityException ex)
            {
                RssArray[0] = "SecurityException: " + ex.Message;
                RssArray[1] = "SecurityException: " + ex.Message;
                RssArray[2] = "SecurityException: " + ex.Message;
                RssArray[3] = "SecurityException: " + ex.Message;
                RssArray[4] = "SecurityException: " + ex.Message;
            }
            catch (System.Xml.XmlException ex)
            {
                RssArray[0] = "XmlException: " + ex.Message;
                RssArray[1] = "XmlException: " + ex.Message;
                RssArray[2] = "XmlException: " + ex.Message;
                RssArray[3] = "XmlException: " + ex.Message;
                RssArray[4] = "XmlException: " + ex.Message;
            }
            catch (System.Exception ex)
            {
                RssArray[0] = "Exception: " + ex.Message;
                RssArray[1] = "Exception: " + ex.Message;
                RssArray[2] = "Exception: " + ex.Message;
                RssArray[3] = "Exception: " + ex.Message;
                RssArray[4] = "Exception: " + ex.Message;
            }

            if(RssArray[0] == null)
            {
                RssArray[0] = "Falied to fetch news item";
            }

            if (RssArray[1] == null)
            {
                RssArray[1] = "Falied to fetch news item";
            }

            if (RssArray[2] == null)
            {
                RssArray[2] = "Falied to fetch news item";
            }

            if (RssArray[3] == null)
            {
                RssArray[3] = "Falied to fetch news item";
            }

            if (RssArray[4] == null)
            {
                RssArray[4] = "Falied to fetch news item";
            }

            return RssArray;
        }
    }
}