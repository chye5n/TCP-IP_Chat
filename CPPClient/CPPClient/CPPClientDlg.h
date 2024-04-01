
// CPPClientDlg.h: 헤더 파일
//

#pragma once
#include "IPAddressSetting.h"

// CCPPClientDlg 대화 상자
class CCPPClientDlg : public CDialogEx
{
// 생성입니다.
public:
	CCPPClientDlg(CWnd* pParent = nullptr);	// 표준 생성자입니다.
	
// 대화 상자 데이터입니다.
#ifdef AFX_DESIGN_TIME
	enum { IDD = IDD_CPPCLIENT_DIALOG };
#endif

	protected:
	virtual void DoDataExchange(CDataExchange* pDX);	// DDX/DDV 지원입니다.

// 구현입니다.
protected:
	HICON m_hIcon;

	// 생성된 메시지 맵 함수
	virtual BOOL OnInitDialog();
	afx_msg void OnPaint();
	afx_msg HCURSOR OnQueryDragIcon();
	DECLARE_MESSAGE_MAP()
public:
	SOCKET m_socket;

	CEdit m_txt_ip;
	CEdit m_txt_port;
	CEdit m_txt_int;
	CEdit m_txt_double;
	CEdit m_txt_string;
	CButton m_btn_connect;
	CButton m_btn_intsend;
	CButton m_btn_doublesend;
	CButton m_btn_stringsend;
	CButton m_btn_structsend;
	CListBox m_list_receive;

	void IntDataSend(int strMsg);
	void DoubleDataSend(double strMsg);
	void StringDataSend(CString strMsg);
	void m_AcceptThread_Run();
	void DataReceiveThread();
	void ReceiveIntData(char* buffer, CString language);
	void ReceiveDoubleData(char* buffer, CString language);
	void ReceiveStringData(char* buffer, CString language);
	void ReceiveStruct(void* data, CString language);

	afx_msg void OnBnClickedBtnConnect();
	afx_msg void OnBnClickedBtnIntsend();
	afx_msg void OnBnClickedBtnDoublesend();
	afx_msg void OnBnClickedBtnStringsend();
	afx_msg void OnBnClickedBtnStructsend();
	afx_msg void OnEnUpdateTxtDouble();
	afx_msg void OnUpdateTxtString();
};
