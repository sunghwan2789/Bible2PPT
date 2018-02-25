using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace Bible2PPT
{
    [System.ComponentModel.DesignerCategory("Code")]
    class TimeoutWebClient : WebClient
    {
        /// <summary>
        /// Gets or sets the length of time, in milliseconds,
        /// before the request times out.
        /// </summary>
        public int Timeout { get; set; } = 5000;

        protected override WebRequest GetWebRequest(Uri address)
        {
            var request = base.GetWebRequest(address);
            request.Timeout = Timeout;
            return request;
        }
    }
}
