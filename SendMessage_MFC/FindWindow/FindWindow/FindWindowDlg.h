
// FindWindowDlg.h : 헤더 파일
//

#pragma once


// CFindWindowDlg 대화 상자
class CFindWindowDlg : public CDialogEx
{
// 생성입니다.
public:
	CFindWindowDlg(CWnd* pParent = NULL);	// 표준 생성자입니다.

// 대화 상자 데이터입니다.
	enum { IDD = IDD_FINDWINDOW_DIALOG };

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
