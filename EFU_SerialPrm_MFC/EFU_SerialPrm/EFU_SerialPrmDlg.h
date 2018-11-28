
// EFU_SerialPrmDlg.h : ��� ����
//

#pragma once
#include "afxwin.h"

namespace ComboboxSetting
{
	enum
	{
		COM_PORT = 30

	};

}

// CEFU_SerialPrmDlg ��ȭ ����
class CEFU_SerialPrmDlg : public CDialogEx
{
// �����Դϴ�.
public:
	CEFU_SerialPrmDlg(CWnd* pParent = NULL);	// ǥ�� �������Դϴ�.

// ��ȭ ���� �������Դϴ�.
	enum { IDD = IDD_EFU_SERIALPRM_DIALOG };

	protected:
	virtual void DoDataExchange(CDataExchange* pDX);	// DDX/DDV �����Դϴ�.


// �����Դϴ�.
protected:
	HICON m_hIcon;

	// ������ �޽��� �� �Լ�
	virtual BOOL OnInitDialog();
	afx_msg void OnSysCommand(UINT nID, LPARAM lParam);
	afx_msg void OnPaint();
	afx_msg HCURSOR OnQueryDragIcon();
	DECLARE_MESSAGE_MAP()
private:
	CComboBox m_cbxComPort;
	CComboBox m_cbxBandRate;
	CComboBox m_cbxDataBits;
	CComboBox m_cbxParity;
	CComboBox m_cbxStopBits;
public:
	
	afx_msg void OnBnClickedBtnSerialOpen();
	afx_msg void OnBnClickedBtnSerialClose();

private:
	void ComportCBXSetting ();
};
