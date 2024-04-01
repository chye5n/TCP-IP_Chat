using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CSClient
{
    internal class IPAddressSetting
    {
        static public string GetIp()
        {
            IPHostEntry ipHost = Dns.GetHostEntry(Dns.GetHostName());   //로컬 IP 주소를 가져와 텍스트 상자에 표시
            return ipHost.AddressList[1].ToString();
        }
    }
}
