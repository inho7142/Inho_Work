
// FindWindowDlg.h : ��� ����
//

#pragma once


// CFindWindowDlg ��ȭ ����
class CFindWindowDlg : public CDialogEx
{
// �����Դϴ�.
public:
	CFindWindowDlg(CWnd* pParent = NULL);	// ǥ�� �������Դϴ�.

// ��ȭ ���� �������Դϴ�.
	enum { IDD = IDD_FINDWINDOW_DIALOG };

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
public:
	afx_msg void OnBnClickedOk();

protected:

	virtual LRESULT DefWindowProc(UINT message, WPARAM wParam, LPARAM lParam);
	virtual LRESULT Message(WPARAM wParam, LPARAM lParam);
public:
	afx_msg void OnBnClickedBtnUsermessage();
	virtual BOOL DestroyWindow();
	afx_msg void OnBnClickedOk2();
	
	HWND GetWindowFromPID(DWORD dwPID);
	DWORD GetProcessID(LPCTSTR pszProcessName);
	BOOL GetProcessModule(DWORD dwPID, LPCTSTR pszProcessName);
};
