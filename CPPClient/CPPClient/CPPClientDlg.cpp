// CPPClientDlg.cpp: 구현 파일
//

#include "pch.h"
#include "CPPClient.h"
#include "CPPClientDlg.h"
#include "afxdialogex.h"
#include <atlstr.h>
#include <thread>

#ifdef _DEBUG
#define new DEBUG_NEW
#endif

// CCPPClientDlg 대화 상자
CCPPClientDlg::CCPPClientDlg(CWnd* pParent /*=nullptr*/)
	: CDialogEx(IDD_CPPCLIENT_DIALOG, pParent)
{
	m_hIcon = AfxGetApp()->LoadIcon(IDR_MAINFRAME);
}

void CCPPClientDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialogEx::DoDataExchange(pDX);
	DDX_Control(pDX, IDC_TXT_IP, m_txt_ip);
	DDX_Control(pDX, IDC_TXT_PORT, m_txt_port);
	DDX_Control(pDX, IDC_TXT_INT, m_txt_int);
	DDX_Control(pDX, IDC_TXT_DOUBLE, m_txt_double);
	DDX_Control(pDX, IDC_TXT_STRING, m_txt_string);
	DDX_Control(pDX, IDC_BTN_CONNECT, m_btn_connect);
	DDX_Control(pDX, IDC_BTN_INTSEND, m_btn_intsend);
	DDX_Control(pDX, IDC_BTN_DOUBLESEND, m_btn_doublesend);
	DDX_Control(pDX, IDC_BTN_STRINGSEND, m_btn_stringsend);
	DDX_Control(pDX, IDC_BTN_STRUCTSEND, m_btn_structsend);
	DDX_Control(pDX, IDC_LIST_RECEIVE, m_list_receive);
}

BEGIN_MESSAGE_MAP(CCPPClientDlg, CDialogEx)
	ON_WM_PAINT()
	ON_WM_QUERYDRAGICON()
	ON_BN_CLICKED(IDC_BTN_CONNECT, &CCPPClientDlg::OnBnClickedBtnConnect)
	ON_BN_CLICKED(IDC_BTN_INTSEND, &CCPPClientDlg::OnBnClickedBtnIntsend)
	ON_BN_CLICKED(IDC_BTN_DOUBLESEND, &CCPPClientDlg::OnBnClickedBtnDoublesend)
	ON_BN_CLICKED(IDC_BTN_STRINGSEND, &CCPPClientDlg::OnBnClickedBtnStringsend)
	ON_BN_CLICKED(IDC_BTN_STRUCTSEND, &CCPPClientDlg::OnBnClickedBtnStructsend)
	ON_EN_UPDATE(IDC_TXT_DOUBLE, &CCPPClientDlg::OnEnUpdateTxtDouble)
	ON_EN_UPDATE(IDC_TXT_STRING, &CCPPClientDlg::OnUpdateTxtString)
	ON_WM_DESTROY()
END_MESSAGE_MAP()

#pragma pack(1) // 메모리 정렬을 1바이트로 설정 (선택적)

struct STSend
{
	int TxtInt;
	double TxtDouble;
	char strTxtString[20];

	STSend()
	{
		TxtInt = 0;
		TxtDouble = 0.00;
		strTxtString[0] = ' ';
	}

	STSend(int StrTxtInt, double StrTxtDouble, char* StrTxtString)
	{
		TxtInt = StrTxtInt;
		TxtDouble = StrTxtDouble;

		strncpy(strTxtString, StrTxtString, sizeof(strTxtString) - 1);
		strTxtString[sizeof(strTxtString) - 1] = '\0';
	}
};

// CCPPClientDlg 메시지 처리기

BOOL CCPPClientDlg::OnInitDialog()
{
	CDialogEx::OnInitDialog();

	// 이 대화 상자의 아이콘을 설정합니다.  응용 프로그램의 주 창이 대화 상자가 아닐 경우에는
	//  프레임워크가 이 작업을 자동으로 수행합니다.
	SetIcon(m_hIcon, TRUE);			// 큰 아이콘을 설정합니다.
	SetIcon(m_hIcon, FALSE);		// 작은 아이콘을 설정합니다.

	// TODO: 여기에 추가 초기화 작업을 추가합니다.
	IPAddressSetting IPAddress; //IP주소를 받아오기 위한 생성자
	m_txt_ip.SetWindowTextW(IPAddress.GetIpAddress());
	m_txt_port.SetWindowTextW(_T("4000"));
	return TRUE;  // 포커스를 컨트롤에 설정하지 않으면 TRUE를 반환합니다.
}

// 대화 상자에 최소화 단추를 추가할 경우 아이콘을 그리려면
//  아래 코드가 필요합니다.  문서/뷰 모델을 사용하는 MFC 애플리케이션의 경우에는
//  프레임워크에서 이 작업을 자동으로 수행합니다.

void CCPPClientDlg::OnPaint()
{
	if (IsIconic())
	{
		CPaintDC dc(this); // 그리기를 위한 디바이스 컨텍스트입니다.

		SendMessage(WM_ICONERASEBKGND, reinterpret_cast<WPARAM>(dc.GetSafeHdc()), 0);

		// 클라이언트 사각형에서 아이콘을 가운데에 맞춥니다.
		int cxIcon = GetSystemMetrics(SM_CXICON);
		int cyIcon = GetSystemMetrics(SM_CYICON);
		CRect rect;
		GetClientRect(&rect);
		int x = (rect.Width() - cxIcon + 1) / 2;
		int y = (rect.Height() - cyIcon + 1) / 2;

		// 아이콘을 그립니다.
		dc.DrawIcon(x, y, m_hIcon);
	}
	else
	{
		CDialogEx::OnPaint();
	}
}

// 사용자가 최소화된 창을 끄는 동안에 커서가 표시되도록 시스템에서
//  이 함수를 호출합니다.
HCURSOR CCPPClientDlg::OnQueryDragIcon()
{
	return static_cast<HCURSOR>(m_hIcon);
}
//Connect 버튼
void CCPPClientDlg::OnBnClickedBtnConnect()
{
	// TODO: 여기에 컨트롤 알림 처리기 코드를 추가합니다.
	//ClientThread client;

	CString strServerIP, strServerPort;				//IP, PORT값 받아오기
	GetDlgItemText(IDC_TXT_IP, strServerIP);
	GetDlgItemText(IDC_TXT_PORT, strServerPort);
	UINT nServerPort = _tstoi(strServerPort);		//Server의 포트 번호 UINT형으로 변환
	WSADATA wsData;
	int nWsResult = WSAStartup(MAKEWORD(2, 2), &wsData);
	if (nWsResult != 0) { m_list_receive.InsertString(0, _T("Winsock Err")); return; }

	m_socket = socket(AF_INET, SOCK_STREAM, 0);
	sockaddr_in serverAddr;
	memset(&serverAddr, 0, sizeof(serverAddr));
	serverAddr.sin_family = AF_INET;
	serverAddr.sin_port = htons(nServerPort);
	if (inet_pton(AF_INET, CStringA(strServerIP), &serverAddr.sin_addr) != 1) { m_list_receive.InsertString(0, _T("IP 주소 변환 불가")); return; }

	if (connect(m_socket, (sockaddr*)(&serverAddr), sizeof(serverAddr)) == SOCKET_ERROR)
	{
		m_list_receive.InsertString(0, _T("서버와 접속할 수 없습니다."));
		closesocket(m_socket);
		return;
	}
	m_list_receive.InsertString(0, _T("서버 접속 완료"));
	m_AcceptThread_Run();
	/*CString strConnectMsg = client.ServerConnect(strServerIP, strServerPort);
	m_list_receive.InsertString(0, strConnectMsg);
	if (strConnectMsg == "서버 접속 완료")
	{
		client.m_AcceptThread_Run();
	}*/
}

//int Send 버튼
void CCPPClientDlg::OnBnClickedBtnIntsend()
{
	// TODO: 여기에 컨트롤 알림 처리기 코드를 추가합니다
	CString strMsg;
	m_txt_int.GetWindowText(strMsg);
	IntDataSend(_tstoi(strMsg));
	m_txt_int.SetWindowTextW(_T(""));
}
//double Send 버튼
void CCPPClientDlg::OnBnClickedBtnDoublesend()
{
	// TODO: 여기에 컨트롤 알림 처리기 코드를 추가합니다.
	CString strMsg;
	m_txt_double.GetWindowText(strMsg);
	DoubleDataSend(_wtof(strMsg));
	m_txt_double.SetWindowTextW(_T(""));
}
//string Send 버튼
void CCPPClientDlg::OnBnClickedBtnStringsend()
{
	// TODO: 여기에 컨트롤 알림 처리기 코드를 추가합니다.
	CString strMsg;
	m_txt_string.GetWindowText(strMsg);
	StringDataSend(strMsg);
	m_txt_string.SetWindowTextW(_T(""));
}
//Struct Send 버튼
void CCPPClientDlg::OnBnClickedBtnStructsend()
{
	// TODO: 여기에 컨트롤 알림 처리기 코드를 추가합니다.
	CString strInt, strDouble, strString;
	m_txt_int.GetWindowText(strInt);
	m_txt_double.GetWindowText(strDouble);
	m_txt_string.GetWindowText(strString);

	int txt_int = _tstoi(strInt);
	double txt_double = _wtof(strDouble);
	char chStringArray[20]; // 20 characters + null

	strcpy_s(chStringArray, CT2A(strString));

	STSend SendStruct = STSend(txt_int, txt_double, chStringArray);

	char buffer[sizeof(SendStruct) + 1];
	buffer[0] = '1';
	memcpy(buffer + 1, &SendStruct, sizeof(SendStruct));
	if (send(m_socket, buffer, sizeof(buffer), 0) == SOCKET_ERROR)
	{
		m_list_receive.InsertString(-1, _T("전송 실패"));
	}
	else
	{
		CString strStructReceive(_T("송신 : int(")), strInt, strDouble;
		strInt.Format(_T("%d"), SendStruct.TxtInt);
		strDouble.Format(_T("%.2lf"), SendStruct.TxtDouble);
		strStructReceive += strInt;
		strStructReceive += _T("), double(");
		strStructReceive += strDouble;
		strStructReceive += _T("), string(");
		strStructReceive += SendStruct.strTxtString;
		strStructReceive += _T(")\n");

		m_list_receive.InsertString(-1, strStructReceive);
	}
	m_txt_int.SetWindowTextW(_T(""));
	m_txt_double.SetWindowTextW(_T(""));
	m_txt_string.SetWindowTextW(_T(""));
}
void CCPPClientDlg::m_AcceptThread_Run()
{
	std::thread dataReceiveThread(&CCPPClientDlg::DataReceiveThread, this);
	dataReceiveThread.detach(); // 스레드를 떼어냄
}
//데이터 받는 스레드
void CCPPClientDlg::DataReceiveThread()
{
	char buffer[256];
	int nBytesRead;
	while (true)
	{
		try
		{
			memset(buffer, 0, sizeof(buffer));
			nBytesRead = recv(m_socket, buffer, sizeof(buffer) - 1, 0);
		}
		catch (...) { m_list_receive.InsertString(-1, _T("서버가 종료되었습니다.\n")); break; }
		if (nBytesRead != 0)
		{
			if (buffer[0] == '0')
			{
				ReceiveStruct(buffer, _T("C# Sever"));
			}
			else if (buffer[0] == '1')
			{
				ReceiveStruct(buffer, _T("C# Client"));
			}
			else if (buffer[0] == '2')
			{
				ReceiveIntData(buffer, _T("C# Sever"));
			}
			else if (buffer[0] == '3')
			{
				ReceiveIntData(buffer, _T("C# Client"));
			}
			else if (buffer[0] == '4')
			{
				ReceiveDoubleData(buffer, _T("C# Sever"));
			}
			else if (buffer[0] == '5')
			{
				ReceiveDoubleData(buffer, _T("C# Client"));
			}
			else if (buffer[0] == '6')
			{
				ReceiveStringData(buffer, _T("C# Sever"));
			}
			else if (buffer[0] == '7')
			{
				ReceiveStringData(buffer, _T("C# Client"));
			}

		}
		else { m_list_receive.InsertString(-1, _T("서버가 종료되었습니다.\n")); break; }
	}
	// 소켓 및 Winsock 해제
	closesocket(m_socket);
	WSACleanup();
}
//int형 데이터 전송
void CCPPClientDlg::IntDataSend(int iMsg)
{
	int iMsgLen = sizeof(int);
	char* bytes = new char[iMsgLen + 1];
	bytes[0] = '3';
	memcpy(&bytes[1], &iMsg, iMsgLen);

	if (send(m_socket, bytes, iMsgLen + 1, 0) == SOCKET_ERROR)
	{
		m_list_receive.InsertString(-1, _T("전송 실패"));
	}
	else 
	{
		CString striMsg;
		striMsg.Format(_T("%d"), iMsg);
		m_list_receive.InsertString(-1, _T("송신 : ") + striMsg); 
	}
	delete[] bytes;
}
//double형 데이터 전송
void CCPPClientDlg::DoubleDataSend(double dMsg)
{
	double dMsgLen = sizeof(double);
	char* bytes = new char[dMsgLen + 1];
	bytes[0] = '5';
	memcpy(&bytes[1], &dMsg, dMsgLen);

	if (send(m_socket, bytes, dMsgLen + 1, 0) == SOCKET_ERROR)
	{
		m_list_receive.InsertString(-1, _T("전송 실패"));
	}
	else
	{
		CString strdMsg;
		strdMsg.Format(_T("%.2lf"), dMsg);
		m_list_receive.InsertString(-1, _T("송신 : ") + strdMsg);
	}
	delete[] bytes;
}
//string형 데이터 전송
void CCPPClientDlg::StringDataSend(CString strMsg)
{
	int nMsgLen = strMsg.GetLength() + 1;
	CString strFormatted(_T("7"));
	strFormatted += CString(strMsg);
	if (send(m_socket, CStringA(strFormatted), nMsgLen, 0) == SOCKET_ERROR)
	{
		m_list_receive.InsertString(-1, _T("전송 실패"));
	}
	else { m_list_receive.InsertString(-1, _T("송신 : ") + strMsg); }
}
//int형 데이터 받는 함수
void CCPPClientDlg::ReceiveIntData(char* buffer, CString language)
{
	int idata;
	memcpy(&idata, &buffer[1], sizeof(int));

	CString strReceivedData(language), stridata;
	stridata.Format(_T("%d"), idata);
	strReceivedData += _T(" : ") + stridata;
	m_list_receive.InsertString(-1, strReceivedData);
}
//double형 데이터 받는 함수
void CCPPClientDlg::ReceiveDoubleData(char* buffer, CString language)
{
	double ddata;
	memcpy(&ddata, &buffer[1], sizeof(double));

	CString strReceivedData(language), strddata;
	strddata.Format(_T("%.2lf"), ddata);
	strReceivedData += _T(" : ") + strddata;
	m_list_receive.InsertString(-1, strReceivedData);
}
//String형 데이터 받는 함수
void CCPPClientDlg::ReceiveStringData(char* buffer, CString language)
{
	CString strReceivedData(language);
	strReceivedData += _T(" : ");
	strReceivedData += CString(buffer).Mid(1);
	m_list_receive.InsertString(-1, strReceivedData);
}
//구조체 받는 함수
void CCPPClientDlg::ReceiveStruct(void* data, CString language)
{
	char buffer[74];
	// data 배열의 1번 인덱스부터 buffer에 복사
	memcpy(buffer, ((char*)data) + 1, sizeof(buffer));

	// 구조체에 버퍼의 데이터 복사
	STSend receivedStruct;
	memcpy(&receivedStruct, buffer, sizeof(STSend));

	CString Structreceive(language), strInt, strDouble;
	strInt.Format(_T("%d"), receivedStruct.TxtInt);
	strDouble.Format(_T("%.2lf"), receivedStruct.TxtDouble);
	Structreceive += _T(" : int(");
	Structreceive += strInt;
	Structreceive += _T("), double(");
	Structreceive += strDouble;
	Structreceive += _T("), string(");
	Structreceive += receivedStruct.strTxtString;
	Structreceive += _T(")\n");

	m_list_receive.InsertString(-1, Structreceive);
}

void CCPPClientDlg::OnEnUpdateTxtDouble()	//숫자와 '.'만 입력
{
	// TODO:  여기에 컨트롤 알림 처리기 코드를 추가합니다.
	CString allowedChars = _T("0123456789.");	// EditBox에서 허용되는 문자 집합 정의

	// EditBox 컨트롤의 포인터를 얻어옴
	CWnd* pEditCtrl = GetDlgItem(IDC_TXT_DOUBLE);

	if (pEditCtrl != nullptr)
	{
		// 현재 텍스트를 가져옴
		CString text;
		pEditCtrl->GetWindowText(text);

		// 변경된 문자 확인
		int textLength = text.GetLength();
		int lastCharIndex = textLength - 1;

		if (textLength > 0)
		{
			// 허용되는 문자인지 확인
			if (allowedChars.Find(text.GetAt(lastCharIndex)) == -1)
			{
				// 허용되지 않는 문자인 경우, 마지막 입력을 삭제
				text.Delete(lastCharIndex);
				pEditCtrl->SetWindowText(text);
			}
		}
	}
}

void CCPPClientDlg::OnUpdateTxtString()	//문자만 입력
{
	// TODO:  여기에 컨트롤 알림 처리기 코드를 추가합니다.
	CString allowedChars = _T("0123456789");	// EditBox에서 허용되지 않는 문자 집합 정의

	// EditBox 컨트롤의 포인터를 얻어옴
	CWnd* pEditCtrl = GetDlgItem(IDC_TXT_STRING);

	if (pEditCtrl != nullptr)
	{
		// 현재 텍스트를 가져옴
		CString text;
		pEditCtrl->GetWindowText(text);

		// 변경된 문자 확인
		int textLength = text.GetLength();
		int lastCharIndex = textLength - 1;

		if (textLength > 0)
		{
			// 허용되는 문자인지 확인
			if (allowedChars.Find(text.GetAt(lastCharIndex)) != -1)
			{
				// 허용되지 않는 문자인 경우, 마지막 입력을 삭제
				text.Delete(lastCharIndex);
				pEditCtrl->SetWindowText(text);
			}
		}
	}
}
