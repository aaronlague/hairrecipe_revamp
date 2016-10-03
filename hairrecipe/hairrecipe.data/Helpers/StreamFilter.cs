using System;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.Web;
using System.Web.Configuration;

namespace hairrecipe.data.Helpers.PageFilter
{
    public class StreamFilter : Stream
    {
        Stream responseStream;
        long position;
        StringBuilder responseHtml;

        public StreamFilter(Stream inputStream)
        {
            responseStream = inputStream;
            responseHtml = new StringBuilder();
        }

        #region Filter overrides
        public override bool CanRead
        {
            get
            {
                return true;
            }
        }

        public override bool CanSeek
        {
            get
            {
                return true;
            }
        }

        public override bool CanWrite
        {
            get
            {
                return true;
            }
        }

        public override void Close()
        {
            responseStream.Close();
        }

        public override void Flush()
        {
            responseStream.Flush();
        }

        public override long Length
        {
            get
            {
                return 0;
            }
        }

        public override long Position
        {
            get
            {
                return position;
            }
            set
            {
                position = value;
            }
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            return responseStream.Seek(offset, origin);
        }

        public override void SetLength(long length)
        {
            responseStream.SetLength(length);
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            return responseStream.Read(buffer, offset, count);
        }
        #endregion

        #region Dirty work
        public override void Write(byte[] buffer, int offset, int count)
        {
            string strBuffer = System.Text.UTF8Encoding.UTF8.GetString(buffer, offset, count);

            // ---------------------------------
            // Wait for the closing </html> tag
            // ---------------------------------
            Regex eof = new Regex("</html>", RegexOptions.IgnoreCase);

            if (!eof.IsMatch(strBuffer))
            {
                responseHtml.Append(strBuffer);
            }
            else
            {
                responseHtml.Append(strBuffer);

                string finalHtml = responseHtml.ToString();
                string CDNURL = WebConfigurationManager.AppSettings["CDNURL"];

                finalHtml = finalHtml.Replace("src=\"/Content", "src=\"" + CDNURL + "/Content");
                finalHtml = finalHtml.Replace("src=\"/Scripts", "src=\"" + CDNURL + "/Scripts");
                finalHtml = finalHtml.Replace("<link href=\"/Content", "<link href=\"" + CDNURL + "/Content");

                // Write the formatted HTML back
                byte[] data = System.Text.UTF8Encoding.UTF8.GetBytes(finalHtml);


                responseStream.Write(data, 0, data.Length);
            }

        }

        //---------------------------------------------------------------------------
        private static string TitleMatch(Match m)
        {
            return m.ToString().Replace(m.Groups[1].Value, string.Empty);
        }

        //---------------------------------------------------------------------------
        private static string JavaScriptMatch(Match m)
        {
            return m.ToString().Replace(m.Groups[1].Value, "type=\"text/javascript\"");
        }

        //---------------------------------------------------------------------------
        private static string ImageBorderMatch(Match m)
        {
            return m.ToString().Replace(m.Groups[1].Value, string.Empty);
        }

        //---------------------------------------------------------------------------
        private static string ViewStateMatch(Match m)
        {
            return string.Concat("<div>", m.Groups[1].Value, "</div>");
        }

        //---------------------------------------------------------------------------
        private static string FormNameMatch(Match m)
        {
            return m.ToString().Replace(m.Groups[1].Value, string.Empty);
        }
        #endregion

    }
}
