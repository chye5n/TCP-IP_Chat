#include "pch.h"
#include "IPAddressSetting.h"

CString IPAddressSetting::GetIpAddress()		//로컬 IP주소 받아오는 함수
{
	if (WSAStartup(MAKEWORD(2, 0), &wsaData) == 0)
	{
		if (gethostname(name, sizeof(name)) == 0)
		{
			if ((hostinfo = gethostbyname(name)) != NULL)
			{
				strIpAddress = inet_ntoa(*(struct in_addr*)*hostinfo->h_addr_list);
			}
		}
		WSACleanup();
	}
	return strIpAddress;
}