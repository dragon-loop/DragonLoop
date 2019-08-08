namespace DrexelBusApp
{
    public static class Settings
    {
        private const string _urlBase = "http://10.0.2.2:5001";

        public static string UrlBase
        {
            get
            {
                return _urlBase;
            }
        }
    }
}
