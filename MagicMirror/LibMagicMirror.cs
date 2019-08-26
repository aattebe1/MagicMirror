using System;
using System.Runtime.InteropServices;

namespace LibMagicMirror
{
    /// <summary>
    /// Adds libmagicmirror functionality to C#
    /// </summary>
    public class Download
    {
		/// <summary>
        /// Downloads an RSS feed to an XML file
        /// </summary>
        /// <param name="fileName">Name of the file </param>
        /// <param name="url">Web address of the RSS feed</param>
        [DllImport("libmagicmirror.so", EntryPoint = "DownloadXML")]
        public static extern void DownloadXML(string fileName, string url);
    }
}