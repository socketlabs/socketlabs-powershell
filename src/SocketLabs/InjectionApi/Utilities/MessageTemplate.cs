namespace InjectionApi.Utilities
{
    public static class MessageTemplate
    {
        private const string DEFAULT_STYLE = "font-family:consolas, courier, monospace;padding:8px;background-color:#012456;color:#fff;font-size:14px;";

        public static string BuildHtmlMessage(string body, bool unformatted)
        {
            string innerHtml;

            if (unformatted)
            {
                innerHtml = body;
            }
            else
            {
                innerHtml = $@"<pre style=""{DEFAULT_STYLE}"">
{body}</pre>";
            }

            string html = $@"<!DOCTYPE html PUBLIC ""-//W3C//DTD HTML 4.0 Transitional//EN"" ""http://www.w3.org/TR/REC-html40/loose.dtd"">
<html><head></head><body>
{innerHtml}</body></html>";

            return html;
        }
    }
}
