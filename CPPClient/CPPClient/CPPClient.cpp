
// CPPClient.cpp: 애플리케이션에 대한 클래스 동작을 정의합니다.
//

#include "pch.h"
#include "framework.h"
#include "CPPClient.h"
#include "CPPClientDlg.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


// CPPClientApp

BEGIN_MESSAGE_MAP(CPPClientApp, CWinApp)
	ON_COMMAND(ID_HELP, &CWinApp::OnHelp)
END_MESSAGE_MAP()


// CPPClientApp 생성

CPPClientApp::CPPClientApp()
{
	// TODO: 여기에 생성 코드를 추가합니다.
	// InitInstance에 모든 중요한 초기화 작업을 배치합니다.
}


// 유일한 CPPClientApp 개체입니다.

CPPClientApp theApp;


// CPPClientApp 초기화

BOOL CPPClientApp::InitInstance()
{
	CWinApp::InitInstance();

	CCPPClientDlg dlg;
	m_pMainWnd = &dlg;
	dlg.DoModal();

	return FALSE;
}