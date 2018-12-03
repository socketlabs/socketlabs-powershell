using System;
using System.Collections.Generic;
using System.Text;

namespace InjectionApi.Utilities
{
    public static class MessageTemplate
    {
        public static string BuildHtmlMessage(string body)
        {
            string html = 
$@"<!DOCTYPE html PUBLIC ""-//W3C//DTD HTML 4.0 Transitional//EN"" ""http://www.w3.org/TR/REC-html40/loose.dtd"">
<html><head></head><body>
<pre style=""font-family:consolas, courier, monospace;padding:8px;background-color:#012456;color:#fff;font-size:14px;"">
{body}
</pre></body></html>";
            return html;
        }
    }
}
