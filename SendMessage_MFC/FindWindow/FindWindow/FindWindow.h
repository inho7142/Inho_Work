
// FindWindow.h : PROJECT_NAME ���� ���α׷��� ���� �� ��� �����Դϴ�.
//

#pragma once

#ifndef __AFXWIN_H__
	#error "PCH�� ���� �� ������ �����ϱ� ���� 'stdafx.h'�� �����մϴ�."
#endif

#include "resource.h"		// �� ��ȣ�Դϴ�.


// CFindWindowApp:
// �� Ŭ������ ������ ���ؼ��� FindWindow.cpp�� �����Ͻʽÿ�.
//

class CFindWindowApp : public CWinApp
{
public:
	CFindWindowApp();

// �������Դϴ�.
public:
	virtual BOOL InitInstance();

// �����Դϴ�.

	DECLARE_MESSAGE_MAP()
};

extern CFindWindowApp theApp;