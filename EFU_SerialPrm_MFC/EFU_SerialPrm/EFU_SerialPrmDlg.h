
// EFU_SerialPrmDlg.h : 헤더 파일
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

// CEFU_SerialPrmDlg 대화 상자
class CEFU_SerialPrmDlg : public CDialogEx
{
// 생성입니다.
public:
	CEFU_SerialPrmDlg(CWnd* pParent = NULL);	// 표준 생성자입니다.

// 대화 상자 데이터입니다.
	enum { IDD = IDD_EFU_SERIALPRM_DIALOG };

	protected:
	virtual void DoDataExchange(CDataExchange* pDX);	// DDX/DDV 지원입니다.


// 구현입니다.
protected:
	HICON m_hIcon;

	// 생성된 메시지 맵 함수
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
