
// EFU_SerialPrmDlg.cpp : ���� ����
//

#include "stdafx.h"
#include "EFU_SerialPrm.h"
#include "EFU_SerialPrmDlg.h"
#include "afxdialogex.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


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


// CEFU_SerialPrmDlg ��ȭ ����




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


// CEFU_SerialPrmDlg �޽��� ó����

BOOL CEFU_SerialPrmDlg::OnInitDialog()
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
	
	//ComboBox �ʱ�ȭ 
	ComportCBXSetting();

	return TRUE;  // ��Ŀ���� ��Ʈ�ѿ� �������� ������ TRUE�� ��ȯ�մϴ�.
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

// ��ȭ ���ڿ� �ּ�ȭ ���߸� �߰��� ��� �������� �׸�����
//  �Ʒ� �ڵ尡 �ʿ��մϴ�. ����/�� ���� ����ϴ� MFC ���� ���α׷��� ��쿡��
//  �����ӿ�ũ���� �� �۾��� �ڵ����� �����մϴ�.

void CEFU_SerialPrmDlg::OnPaint()
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
HCURSOR CEFU_SerialPrmDlg::OnQueryDragIcon()
{
	return static_cast<HCURSOR>(m_hIcon);
}


#pragma region Button Event / Serial OPen, Close

void CEFU_SerialPrmDlg::OnBnClickedBtnSerialOpen()
{
	// TODO: ���⿡ ��Ʈ�� �˸� ó���� �ڵ带 �߰��մϴ�.
	
}

void CEFU_SerialPrmDlg::OnBnClickedBtnSerialClose()
{
	// TODO: ���⿡ ��Ʈ�� �˸� ó���� �ڵ带 �߰��մϴ�.
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