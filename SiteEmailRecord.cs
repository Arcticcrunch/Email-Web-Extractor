using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Email_Web_Extractor
{
    public class SiteEmailRecord
    {
        private string site = "EMPTY_SITE";
        private string page = "EMPTY_PAGE";
        private string[] emails;

        public SiteEmailRecord()
        {

        }
        public SiteEmailRecord(string site, string fullPage, string[] emails)
        {
            this.site = site;
            this.page = fullPage;
            this.emails = emails;
        }

        public string Site
        {
            get
            {
                return site;
            }

            set
            {
                site = value;
            }
        }
        public string Page
        {
            get
            {
                return page;
            }

            set
            {
                page = value;
            }
        }
        public string[] Emails
        {
            get
            {
                return emails;
            }

            set
            {
                emails = value;
            }
        }
    }
}
