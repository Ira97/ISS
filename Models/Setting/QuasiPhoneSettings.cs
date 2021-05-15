namespace Models.Setting
{
    public class QuasiPhoneSettings
    {
        public string STUNServerHostname { get; set; }
        public string SIPUsername { get; set; }
        public string SIPPassword { get; set; }
        public string SIPServer { get; set; }
        public string SIPFromName { get; set; }
        public string DnsServer { get; set; }
        public string UseAudioScope { get; set; }
        public string AudioOutDeviceIndex { get; set; }
        public string WebApiServer { get; set; }
        public string AuthServer { get; set; }
    }
}
