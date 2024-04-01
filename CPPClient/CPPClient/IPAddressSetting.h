#pragma once
class IPAddressSetting
{
public:
	CString GetIpAddress();

	WSADATA wsaData;		//소켓 라이브러리 초기화
	char name[16];			//호스트의 이름 저장
	PHOSTENT hostinfo;		//DNS 조회 후 얻은 호스트 정보 저장
	CString strIpAddress;	//반환을 위한 IP 주소 저장
};

