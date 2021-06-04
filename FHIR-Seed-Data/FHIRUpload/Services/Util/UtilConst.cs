using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FHIRUpload.Services.Util
{
    public static class UtilConst
    {
        public static string Tenant { set; get; }
        public static string ClientId { set; get; }
        public static string ClientSecret { set; get; }
        public static string TeamDomain { set; get; }
        public static string SMTPFromAddress { set; get; }
        public static string SMTPPassword { set; get; }
        public static string SMTP { set; get; }
        public static String SMTPUser { set; get; }
        public static string StorageConn { set; get; }
        public static string Container { set; get; }
        public static string Blob { set; get; }
        public static string MSTeam1 { get; set; }
        public static string FHIRServer { get; set; }

        public static string Authority { get; set; }
        public static string Audience { get; set; }


    }
}
