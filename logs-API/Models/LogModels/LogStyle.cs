namespace logs_API.Models.LogModels
{
    public class LogStyle
    {
        public int FontSize;
        public string FontColour;
        public string BackgroundColour;

        public LogStyle(int fontSize = 16, string fontColour = "#000000", string backgroundColour= "#e3e3e3")
        {
            FontSize = fontSize;
            FontColour = fontColour;
            BackgroundColour = backgroundColour;
        }
    }
}
