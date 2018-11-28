
// FindWindowDlg.cpp : 구현 파일
//

#include "stdafx.h"
#include "FindWindow.h"
#include "FindWindowDlg.h"
#include "afxdialogex.h"
#include "string.h"
#include <windows.h>
#include <process.h>
#include <Tlhelp32.h>
#include <stdio.h>
#include <conio.h>

#ifdef _DEBUG
#define new DEBUG_NEW
#endif

#define WM_USER_MESSAGE		WM_USER +1
#define WM_NOT_USER_MESSAGE WM_USER +2

#define WM_CIM_TO_MVI								(WM_USER + 908)
#define WM_MVI_TO_CIM								(WM_USER + 909)

// 응용 프로그램 정보에 사용되는 CAboutDlg 대화 상자입니다.

class CAboutDlg : public CDialogEx
{
public:
	CAboutDlg();

// 대화 상자 데이터입니다.
	enum { IDD = IDD_ABOUTBOX };

	protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV 지원입니다.

// 구현입니다.
protected:
	DECLARE_MESSAGE_MAP()
	virtual LRESULT DefWindowProc(UINT message, WPARAM wParam, LPARAM lParam);
};

CAboutDlg::CAboutDlg() : CDialogEx(CAboutDlg::IDD)
{
}

void CAboutDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialogEx::DoDataExchange(pDX);
}

BEGIN_MESSAGE_MAP(CAboutDlg, CDialogEx)
END_MESSAGE_MAP()


// CFindWindowDlg 대화 상자




CFindWindowDlg::CFindWindowDlg(CWnd* pParent /*=NULL*/)
	: CDialogEx(CFindWindowDlg::IDD, pParent)
{
	m_hIcon = AfxGetApp()->LoadIcon(IDR_MAINFRAME);
}

void CFindWindowDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialogEx::DoDataExchange(pDX);
}

BEGIN_MESSAGE_MAP(CFindWindowDlg, CDialogEx)
	ON_WM_SYSCOMMAND()
	ON_WM_PAINT()
	ON_WM_QUERYDRAGICON()
	ON_BN_CLICKED(IDOK, &CFindWindowDlg::OnBnClickedOk)
	
	// 내가 정의한 Define 변수에 OnTipssoftMessage 이라는 함수를 연결 
	ON_MESSAGE(WM_USER_MESSAGE, Message)

	ON_BN_CLICKED(IDC_BTN_USERMESSAGE, &CFindWindowDlg::OnBnClickedBtnUsermessage)
	ON_BN_CLICKED(IDOK2, &CFindWindowDlg::OnBnClickedOk2)
END_MESSAGE_MAP()


// CFindWindowDlg 메시지 처리기

BOOL CFindWindowDlg::OnInitDialog()
{
	CDialogEx::OnInitDialog();

	// 시스템 메뉴에 "정보..." 메뉴 항목을 추가합니다.

	// IDM_ABOUTBOX는 시스템 명령 범위에 있어야 합니다.
	ASSERT((IDM_ABOUTBOX & 0xFFF0) == IDM_ABOUTBOX);
	ASSERT(IDM_ABOUTBOX < 0xF000);

	CMenu* pSysMenu = GetSystemMenu(FALSE);
	if (pSysMenu != NULL)
	{
		BOOL bNameValid;
		CString strAboutMenu;
		bNameValid = strAboutMenu.LoadString(IDS_ABOUTBOX);
		ASSERT(bNameValid);
		if (!strAboutMenu.IsEmpty())
		{
			pSysMenu->AppendMenu(MF_SEPARATOR);
			pSysMenu->AppendMenu(MF_STRING, IDM_ABOUTBOX, strAboutMenu);
		}
	}

	// 이 대화 상자의 아이콘을 설정합니다. 응용 프로그램의 주 창이 대화 상자가 아닐 경우에는
	//  프레임워크가 이 작업을 자동으로 수행합니다.
	SetIcon(m_hIcon, TRUE);			// 큰 아이콘을 설정합니다.
	SetIcon(m_hIcon, FALSE);		// 작은 아이콘을 설정합니다.

	// TODO: 여기에 추가 초기화 작업을 추가합니다.

	return TRUE;  // 포커스를 컨트롤에 설정하지 않으면 TRUE를 반환합니다.
}

void CFindWindowDlg::OnSysCommand(UINT nID, LPARAM lParam)
{
	if ((nID & 0xFFF0) == IDM_ABOUTBOX)
	{
		CAboutDlg dlgAbout;
		dlgAbout.DoModal();
	}
	else
	{
		CDialogEx::OnSysCommand(nID, lParam);
	}
}

// 대화 상자에 최소화 단추를 추가할 경우 아이콘을 그리려면
//  아래 코드가 필요합니다. 문서/뷰 모델을 사용하는 MFC 응용 프로그램의 경우에는
//  프레임워크에서 이 작업을 자동으로 수행합니다.

void CFindWindowDlg::OnPaint()
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
HCURSOR CFindWindowDlg::OnQueryDragIcon()
{
	return static_cast<HCURSOR>(m_hIcon);
}



void CFindWindowDlg::OnBnClickedOk()
{
	HWND hwndNotePad;
	HWND hwndNotepadChild;
	CString strText = _T("test 이상하다");

	hwndNotePad = ::FindWindow(_T("Notepad"), NULL);
	hwndNotepadChild = ::FindWindowEx(hwndNotePad, NULL, _T("edit"), NULL);

//	USES_CONVERSION;
	//CStringA strTextA = W2A(strText);

	TCHAR tszText[MAX_PATH] = {0,};
	_stprintf_s(tszText, MAX_PATH, _T("%s"), _T("test 이상하다"));
	::SendMessage(hwndNotepadChild, WM_SETTEXT,0, (LPARAM)tszText);

	// TODO: 여기에 컨트롤 알림 처리기 코드를 추가합니다.
	//CDialogEx::OnOK();
}


LRESULT CFindWindowDlg::DefWindowProc(UINT message, WPARAM wParam, LPARAM lParam)
{
	// TODO: 여기에 특수화된 코드를 추가 및/또는 기본 클래스를 호출합니다.
	if(message == WM_NOT_USER_MESSAGE){
		// LM_TIPSSOFT_MESSAGE 메시지가 발생했을때, 처래해야할 작업을 정의한다.
		CString str;
		//str.Format("LM_TIPSSOFT_MESSAGE 메시지를 받았습니다. ( wParam = %d, lParam = %d )",
		//	wParam, lParam);

		/*	__in_opt HWND hWnd,
		__in_opt LPCWSTR lpText,
		__in_opt LPCWSTR lpCaption,
		__in UINT uType);

		MessageBox
		MessageBox(str, "메시지 확인", MB_OK);*/
	}

	return CDialogEx::DefWindowProc(message, wParam, lParam);
}

LRESULT CFindWindowDlg::Message(WPARAM wParam, LPARAM lParam)
{
	// LM_TIPSSOFT_MESSAGE 메시지가 발생했을때 처리할 코드 작성...
	CString str;
	/*str.Format("LM_TIPSWARE_MESSAGE 메시지를 받았습니다. ( wParam = %d, lParam = %d )",
	wParam, lParam);
	MessageBox(str, "메시지 확인", MB_OK);
	*/
	return 1;
}


void CFindWindowDlg::OnBnClickedBtnUsermessage()
{
	// TODO: 여기에 컨트롤 알림 처리기 코드를 추가합니다.
	
	//PostMessage(LM_TIPSSOFT_MESSAGE, 100, 200);

	// 내가 정의한 Define 변수에 OnTipssoftMessage 이라는 함수를 연결 
	SendMessage(WM_USER_MESSAGE, 100, 200);
	
	
	// 내가 정의한 Define 변수에 연결하지 않음 
	//SendMessage(WM_NOT_USER_MESSAGE, 100, 200);
}


BOOL CFindWindowDlg::DestroyWindow()
{
	// TODO: 여기에 특수화된 코드를 추가 및/또는 기본 클래스를 호출합니다.

	return CDialogEx::DestroyWindow();
}


LRESULT CAboutDlg::DefWindowProc(UINT message, WPARAM wParam, LPARAM lParam)
{
	// TODO: 여기에 특수화된 코드를 추가 및/또는 기본 클래스를 호출합니다.

	return CDialogEx::DefWindowProc(message, wParam, lParam);
}

BOOL CALLBACK MyChildWindowsProc(HWND hWnd, LPARAM lParam)
{
	TCHAR szClass[1024]={0,};

	int nFind = GetClassName(hWnd, szClass, 1024);
	if(nFind > 0)
		::PostMessage(hWnd, WM_CHAR, 'q', 0);//'q' 문자 메시지를 보낸다

	return TRUE;
}

void CFindWindowDlg::OnBnClickedOk2()
{

	// TODO: 여기에 컨트롤 알림 처리기 코드를 추가합니다.
	
	HWND hwndProcess;
	hwndProcess = ::FindWindow(NULL, _T("CimGate2.2018.08.16.1[TESTER]"));
	
	DWORD dwError;
	if(hwndProcess == NULL)
	{
		dwError = ::GetLastError();
	}
	
	::SendMessage(hwndProcess, WM_MVI_TO_CIM, 0, 0);

	


	HWND hwndProcess1;
	hwndProcess1 = ::FindWindow(NULL, _T("CimGate2"));
	if(hwndProcess1 == NULL)
	{
		dwError = ::GetLastError();
	}
	::SendMessage(hwndProcess1, WM_MVI_TO_CIM,100, 100);

	//HWND hTargetWnd = GetWindowFromPID(GetProcessID(_T("")));

	//::SendMessage(hTargetWnd, WM_MVI_TO_CIM, 0, 0);
	////EnumChildWindows(hTargetWnd, MyChildWindowsProc, NULL);


}
struct CallbackInfo
{
	DWORD m_dwPID;
	HWND m_hWnd;
};



BOOL CALLBACK EnumProc(HWND hWnd, LPARAM lParam)
{
	DWORD dwPID = 0;
	CallbackInfo *pst_Callback = (CallbackInfo *)lParam;

	GetWindowThreadProcessId(hWnd, &dwPID);

	if (pst_Callback->m_dwPID != dwPID)
		return TRUE;

	pst_Callback->m_hWnd = hWnd;
	return FALSE;
}

HWND CFindWindowDlg::GetWindowFromPID(DWORD dwPID)
{
	CallbackInfo st_Callback;

	if (dwPID == 0)
		return NULL;

	st_Callback.m_dwPID = dwPID;
	st_Callback.m_hWnd = NULL;

	EnumWindows(EnumProc, (LPARAM)&st_Callback);

	return st_Callback.m_hWnd;
}

DWORD CFindWindowDlg::GetProcessID(LPCTSTR pszProcessName)
{

	HANDLE         hProcessSnap = NULL;
	BOOL           bRet      = FALSE;
	PROCESSENTRY32 pe32      = {0};

	hProcessSnap = CreateToolhelp32Snapshot(TH32CS_SNAPPROCESS, 0);
	if (hProcessSnap == (HANDLE)-1)
		return false;

	pe32.dwSize = sizeof(PROCESSENTRY32);
	DWORD dwProcessID = 0;

	//프로세스가 메모리상에 있으면 첫번째 프로세스를 얻는다
	if (Process32First(hProcessSnap, &pe32))
	{
		BOOL          bCurrent = FALSE;
		MODULEENTRY32 me32       = {0};
		do
		{
			bCurrent = GetProcessModule(pe32.th32ProcessID, pszProcessName);
			if(bCurrent)
			{
				dwProcessID = pe32.th32ProcessID;
				break;
			}

		} while (Process32Next(hProcessSnap, &pe32)); //다음 프로세스의 정보를 구하여 있으면 루프
	}

	CloseHandle (hProcessSnap);
	return dwProcessID;
}

BOOL CFindWindowDlg::GetProcessModule(DWORD dwPID, LPCTSTR pszProcessName)
{
	HANDLE        hModuleSnap = NULL;
	MODULEENTRY32 me32        = {0};

	hModuleSnap = CreateToolhelp32Snapshot(TH32CS_SNAPMODULE, dwPID);

	if (hModuleSnap == (HANDLE)-1)
		return FALSE;

	me32.dwSize = sizeof(MODULEENTRY32);
	//해당 프로세스의 모듈리스트를 루프로 돌려서 프로세스이름과 동일하면
	//true를 리턴한다.
	if(Module32First(hModuleSnap, &me32))
	{
		do
		{
			if(_tcscmp(me32.szModule, pszProcessName) == 0)
			{
				CloseHandle (hModuleSnap);
				return TRUE;
			}
		}while(Module32Next(hModuleSnap, &me32));
	}

	CloseHandle (hModuleSnap);

	return FALSE;
}

