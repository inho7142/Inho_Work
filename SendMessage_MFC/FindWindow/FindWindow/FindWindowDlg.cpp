
// FindWindowDlg.cpp : ���� ����
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

// ���� ���α׷� ������ ���Ǵ� CAboutDlg ��ȭ �����Դϴ�.

class CAboutDlg : public CDialogEx
{
public:
	CAboutDlg();

// ��ȭ ���� �������Դϴ�.
	enum { IDD = IDD_ABOUTBOX };

	protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV �����Դϴ�.

// �����Դϴ�.
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


// CFindWindowDlg ��ȭ ����




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
	
	// ���� ������ Define ������ OnTipssoftMessage �̶�� �Լ��� ���� 
	ON_MESSAGE(WM_USER_MESSAGE, Message)

	ON_BN_CLICKED(IDC_BTN_USERMESSAGE, &CFindWindowDlg::OnBnClickedBtnUsermessage)
	ON_BN_CLICKED(IDOK2, &CFindWindowDlg::OnBnClickedOk2)
END_MESSAGE_MAP()


// CFindWindowDlg �޽��� ó����

BOOL CFindWindowDlg::OnInitDialog()
{
	CDialogEx::OnInitDialog();

	// �ý��� �޴��� "����..." �޴� �׸��� �߰��մϴ�.

	// IDM_ABOUTBOX�� �ý��� ��� ������ �־�� �մϴ�.
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

	// �� ��ȭ ������ �������� �����մϴ�. ���� ���α׷��� �� â�� ��ȭ ���ڰ� �ƴ� ��쿡��
	//  �����ӿ�ũ�� �� �۾��� �ڵ����� �����մϴ�.
	SetIcon(m_hIcon, TRUE);			// ū �������� �����մϴ�.
	SetIcon(m_hIcon, FALSE);		// ���� �������� �����մϴ�.

	// TODO: ���⿡ �߰� �ʱ�ȭ �۾��� �߰��մϴ�.

	return TRUE;  // ��Ŀ���� ��Ʈ�ѿ� �������� ������ TRUE�� ��ȯ�մϴ�.
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

// ��ȭ ���ڿ� �ּ�ȭ ���߸� �߰��� ��� �������� �׸�����
//  �Ʒ� �ڵ尡 �ʿ��մϴ�. ����/�� ���� ����ϴ� MFC ���� ���α׷��� ��쿡��
//  �����ӿ�ũ���� �� �۾��� �ڵ����� �����մϴ�.

void CFindWindowDlg::OnPaint()
{
	if (IsIconic())
	{
		CPaintDC dc(this); // �׸��⸦ ���� ����̽� ���ؽ�Ʈ�Դϴ�.

		SendMessage(WM_ICONERASEBKGND, reinterpret_cast<WPARAM>(dc.GetSafeHdc()), 0);

		// Ŭ���̾�Ʈ �簢������ �������� ����� ����ϴ�.
		int cxIcon = GetSystemMetrics(SM_CXICON);
		int cyIcon = GetSystemMetrics(SM_CYICON);
		CRect rect;
		GetClientRect(&rect);
		int x = (rect.Width() - cxIcon + 1) / 2;
		int y = (rect.Height() - cyIcon + 1) / 2;

		// �������� �׸��ϴ�.
		dc.DrawIcon(x, y, m_hIcon);
	}
	else
	{
		CDialogEx::OnPaint();
	}
}

// ����ڰ� �ּ�ȭ�� â�� ���� ���ȿ� Ŀ���� ǥ�õǵ��� �ý��ۿ���
//  �� �Լ��� ȣ���մϴ�.
HCURSOR CFindWindowDlg::OnQueryDragIcon()
{
	return static_cast<HCURSOR>(m_hIcon);
}



void CFindWindowDlg::OnBnClickedOk()
{
	HWND hwndNotePad;
	HWND hwndNotepadChild;
	CString strText = _T("test �̻��ϴ�");

	hwndNotePad = ::FindWindow(_T("Notepad"), NULL);
	hwndNotepadChild = ::FindWindowEx(hwndNotePad, NULL, _T("edit"), NULL);

//	USES_CONVERSION;
	//CStringA strTextA = W2A(strText);

	TCHAR tszText[MAX_PATH] = {0,};
	_stprintf_s(tszText, MAX_PATH, _T("%s"), _T("test �̻��ϴ�"));
	::SendMessage(hwndNotepadChild, WM_SETTEXT,0, (LPARAM)tszText);

	// TODO: ���⿡ ��Ʈ�� �˸� ó���� �ڵ带 �߰��մϴ�.
	//CDialogEx::OnOK();
}


LRESULT CFindWindowDlg::DefWindowProc(UINT message, WPARAM wParam, LPARAM lParam)
{
	// TODO: ���⿡ Ư��ȭ�� �ڵ带 �߰� ��/�Ǵ� �⺻ Ŭ������ ȣ���մϴ�.
	if(message == WM_NOT_USER_MESSAGE){
		// LM_TIPSSOFT_MESSAGE �޽����� �߻�������, ó���ؾ��� �۾��� �����Ѵ�.
		CString str;
		//str.Format("LM_TIPSSOFT_MESSAGE �޽����� �޾ҽ��ϴ�. ( wParam = %d, lParam = %d )",
		//	wParam, lParam);

		/*	__in_opt HWND hWnd,
		__in_opt LPCWSTR lpText,
		__in_opt LPCWSTR lpCaption,
		__in UINT uType);

		MessageBox
		MessageBox(str, "�޽��� Ȯ��", MB_OK);*/
	}

	return CDialogEx::DefWindowProc(message, wParam, lParam);
}

LRESULT CFindWindowDlg::Message(WPARAM wParam, LPARAM lParam)
{
	// LM_TIPSSOFT_MESSAGE �޽����� �߻������� ó���� �ڵ� �ۼ�...
	CString str;
	/*str.Format("LM_TIPSWARE_MESSAGE �޽����� �޾ҽ��ϴ�. ( wParam = %d, lParam = %d )",
	wParam, lParam);
	MessageBox(str, "�޽��� Ȯ��", MB_OK);
	*/
	return 1;
}


void CFindWindowDlg::OnBnClickedBtnUsermessage()
{
	// TODO: ���⿡ ��Ʈ�� �˸� ó���� �ڵ带 �߰��մϴ�.
	
	//PostMessage(LM_TIPSSOFT_MESSAGE, 100, 200);

	// ���� ������ Define ������ OnTipssoftMessage �̶�� �Լ��� ���� 
	SendMessage(WM_USER_MESSAGE, 100, 200);
	
	
	// ���� ������ Define ������ �������� ���� 
	//SendMessage(WM_NOT_USER_MESSAGE, 100, 200);
}


BOOL CFindWindowDlg::DestroyWindow()
{
	// TODO: ���⿡ Ư��ȭ�� �ڵ带 �߰� ��/�Ǵ� �⺻ Ŭ������ ȣ���մϴ�.

	return CDialogEx::DestroyWindow();
}


LRESULT CAboutDlg::DefWindowProc(UINT message, WPARAM wParam, LPARAM lParam)
{
	// TODO: ���⿡ Ư��ȭ�� �ڵ带 �߰� ��/�Ǵ� �⺻ Ŭ������ ȣ���մϴ�.

	return CDialogEx::DefWindowProc(message, wParam, lParam);
}

BOOL CALLBACK MyChildWindowsProc(HWND hWnd, LPARAM lParam)
{
	TCHAR szClass[1024]={0,};

	int nFind = GetClassName(hWnd, szClass, 1024);
	if(nFind > 0)
		::PostMessage(hWnd, WM_CHAR, 'q', 0);//'q' ���� �޽����� ������

	return TRUE;
}

void CFindWindowDlg::OnBnClickedOk2()
{

	// TODO: ���⿡ ��Ʈ�� �˸� ó���� �ڵ带 �߰��մϴ�.
	
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

	//���μ����� �޸𸮻� ������ ù��° ���μ����� ��´�
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

		} while (Process32Next(hProcessSnap, &pe32)); //���� ���μ����� ������ ���Ͽ� ������ ����
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
	//�ش� ���μ����� ��⸮��Ʈ�� ������ ������ ���μ����̸��� �����ϸ�
	//true�� �����Ѵ�.
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

