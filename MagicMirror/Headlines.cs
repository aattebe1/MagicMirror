/* 
 * Headlines.cs
 * 
 * Author: Austin Atteberry
 * 
 * Description: Defines the Headlines class for reading
 *              news headlines from an RSS feed
 * 
 */

namespace MagicMirror
{
    public class Headlines
    {
        private string fileName;
        private string rssUrl;

        /* Construct Headlines object */
        /* ENABLE FOR RASPBERRY PI, DISABLE FOR WINDOWS */
        /*public Headlines(string fileName, string rssUrl)
        {
            this.fileName = fileName;
            this.rssUrl = rssUrl;

            this.DownloadNews();
        }*/

        /* ENABLE FOR WINDOWS, DISABLE FOR RASPBERRY PI */
        public Headlines(string fileName, string rssUrl)
        {
            this.fileName = rssUrl;
            this.rssUrl = rssUrl;
        }

        /* ENABLE FOR RASPBERRY PI, DISABLE FOR WINDOWS */
        /*public void DownloadNews()
        {
            LibMagicMirror.Download.DownloadXML(this.fileName, this.rssUrl);
        }*/

        /* ENABLE FOR WINDOWS, DISABLE FOR RASPBERRY PI */
        public void DownloadNews()
        { }

        public void GetRss(ref string[] RssArray)
        {
            /* Handle XmlReader and SyndicationFeed exceptions */
            try
            {
                System.Xml.XmlReader rssReader = System.Xml.XmlReader.Create(this.fileName);
                System.ServiceModel.Syndication.SyndicationFeed rssFeed = System.ServiceModel.Syndication.SyndicationFeed.Load(rssReader);

                /* Clean up resource */
                rssReader.Close();
                rssReader.Dispose();

                int n = 0;

                foreach (System.ServiceModel.Syndication.SyndicationItem item in rssFeed.Items)
                {
                    RssArray[n] = item.Title.Text;
                    n++;

                    if(n == 5)
                    {
                        break;
                    }
                }
            }
            catch (System.ArgumentNullException e)
            {
                RssArray[0] = e.Message;
                RssArray[1] = e.Message;
                RssArray[2] = e.Message;
                RssArray[3] = e.Message;
                RssArray[4] = e.Message;
            }
            catch (System.InvalidOperationException e)
            {
                RssArray[0] = e.Message;
                RssArray[1] = e.Message;
                RssArray[2] = e.Message;
                RssArray[3] = e.Message;
                RssArray[4] = e.Message;
            }
            catch (System.UriFormatException e)
            {
                RssArray[0] = e.Message;
                RssArray[1] = e.Message;
                RssArray[2] = e.Message;
                RssArray[3] = e.Message;
                RssArray[4] = e.Message;
            }
            catch (System.IO.FileNotFoundException e)
            {
                RssArray[0] = e.Message;
                RssArray[1] = e.Message;
                RssArray[2] = e.Message;
                RssArray[3] = e.Message;
                RssArray[4] = e.Message;
            }
            catch (System.Security.SecurityException e)
            {
                RssArray[0] = e.Message;
                RssArray[1] = e.Message;
                RssArray[2] = e.Message;
                RssArray[3] = e.Message;
                RssArray[4] = e.Message;
            }
            catch (System.Xml.XmlException e)
            {
                RssArray[0] = e.Message;
                RssArray[1] = e.Message;
                RssArray[2] = e.Message;
                RssArray[3] = e.Message;
                RssArray[4] = e.Message;
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
        }
    }
}