#pragma once
class IPAddressSetting
{
public:
	CString GetIpAddress();

	WSADATA wsaData;		//���� ���̺귯�� �ʱ�ȭ
	char name[16];			//ȣ��Ʈ�� �̸� ����
	PHOSTENT hostinfo;		//DNS ��ȸ �� ���� ȣ��Ʈ ���� ����
	CString strIpAddress;	//��ȯ�� ���� IP �ּ� ����
};

