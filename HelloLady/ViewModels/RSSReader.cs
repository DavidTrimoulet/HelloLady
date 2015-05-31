using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;

namespace HelloLady.ViewModels
{
    public class RSSReader
    {

        public WebClient Myclient;
        public IList<Item> MyElements { get; set; }
        DataModel myModel;
        
        public RSSReader(DataModel myModel, String URL)
        {
            this.myModel = myModel;
            Myclient = new WebClient();
            Myclient.DownloadStringCompleted += new DownloadStringCompletedEventHandler(webClient_DownloadStringCompleted);
            Myclient.DownloadStringAsync(new System.Uri(URL));

        }

        public IList<String> GetData()
        {
            List<string> test = new List<string>();

            return (IList<string>)test;
        }

        private void webClient_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                Deployment.Current.Dispatcher.BeginInvoke(() =>
                {
                    MessageBox.Show(e.Error.Message);
                });
            }
            else
            {
               
                UpdateFeedList(e.Result);
            }
        }

        private void UpdateFeedList(string p)
        {
            XDocument MyDocument = XDocument.Parse(p);
            foreach (XElement c in MyDocument.Descendants("item"))
            {
                try
                {
                    Item newItem = new Item();
                    String itemTitle = c.Element("title").Value;
                    Uri itemLink = new Uri(((c.Element("description").Value).Split('"'))[1], UriKind.Absolute);
                    newItem.Title = itemTitle;
                    newItem.Link = itemLink;
                    myModel.MyItems.Add(newItem);
                    
                }
                catch (Exception e)
                {

                    System.Diagnostics.Debug.WriteLine( c.Element("description").Value );
                }



                         
            }
          
        }

        private Uri GetImageStream(XElement c)
        {
            var myImage = new System.Windows.Media.Imaging.BitmapImage();


            return myImage.UriSource;
        }

    }
}
