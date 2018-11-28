
// EFU_SerialPrmDlg.cpp : 구현 파일
//

#include "stdafx.h"
#include "EFU_SerialPrm.h"
#include "EFU_SerialPrmDlg.h"
#include "afxdialogex.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


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


// CEFU_SerialPrmDlg 대화 상자




CEFU_SerialPrmDlg::CEFU_SerialPrmDlg(CWnd* pParent /*=NULL*/)
	: CDialogEx(CEFU_SerialPrmDlg::IDD, pParent)
{
	m_hIcon = AfxGetApp()->LoadIcon(IDR_MAINFRAME);
}

void CEFU_SerialPrmDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialogEx::DoDataExchange(pDX);
	DDX_Control(pDX, IDC_CBX_COMPORT, m_cbxComPort);
	DDX_Control(pDX, IDC_CBX_BAND_RATE, m_cbxBandRate);
	DDX_Control(pDX, IDC_CBX_DATA_BITS, m_cbxDataBits);
	DDX_Control(pDX, IDC_CBX_PARITY, m_cbxParity);
	DDX_Control(pDX, IDC_CBX_STOP_BITS, m_cbxStopBits);
}

BEGIN_MESSAGE_MAP(CEFU_SerialPrmDlg, CDialogEx)
	ON_WM_SYSCOMMAND()
	ON_WM_PAINT()
	ON_WM_QUERYDRAGICON()
	ON_BN_CLICKED(IDC_BTN_SERIAL_OPEN, &CEFU_SerialPrmDlg::OnBnClickedBtnSerialOpen)
	ON_BN_CLICKED(IDC_BTN_SERIAL_CLOSE, &CEFU_SerialPrmDlg::OnBnClickedBtnSerialClose)
END_MESSAGE_MAP()


// CEFU_SerialPrmDlg 메시지 처리기

BOOL CEFU_SerialPrmDlg::OnInitDialog()
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
	
	//ComboBox 초기화 
	ComportCBXSetting();

	return TRUE;  // 포커스를 컨트롤에 설정하지 않으면 TRUE를 반환합니다.
}

void CEFU_SerialPrmDlg::OnSysCommand(UINT nID, LPARAM lParam)
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

void CEFU_SerialPrmDlg::OnPaint()
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
HCURSOR CEFU_SerialPrmDlg::OnQueryDragIcon()
{
	return static_cast<HCURSOR>(m_hIcon);
}


#pragma region Button Event / Serial OPen, Close

void CEFU_SerialPrmDlg::OnBnClickedBtnSerialOpen()
{
	// TODO: 여기에 컨트롤 알림 처리기 코드를 추가합니다.
	
}

void CEFU_SerialPrmDlg::OnBnClickedBtnSerialClose()
{
	// TODO: 여기에 컨트롤 알림 처리기 코드를 추가합니다.
}

#pragma endregion

#pragma region ComboBox Setting 
void CEFU_SerialPrmDlg::ComportCBXSetting()
{
	CString strConvert;
	// ComPort
	for (int i = 0; i < ComboboxSetting::COM_PORT ; i++)
	{
		strConvert.Format(_T("%d"), i);
		m_cbxComPort.AddString(strConvert);
	}
	m_cbxComPort.SetCurSel(3);

	// BandRate
	m_cbxBandRate.AddString(_T("9600"));
	m_cbxBandRate.SetCurSel(0);
	
	// Data Bits
	m_cbxDataBits.AddString(_T("8"));
	m_cbxDataBits.SetCurSel(0);
	
	// Parity
	m_cbxParity.AddString(_T("NONE"));
	m_cbxParity.SetCurSel(0);
	
	// Stop Bits
	m_cbxStopBits.AddString(_T("1"));
	m_cbxStopBits.SetCurSel(0);
}
#pragma endregion 