
// ServerFindWindwPrm.h : PROJECT_NAME ���� ���α׷��� ���� �� ��� �����Դϴ�.
//

#pragma once

#ifndef __AFXWIN_H__
	#error "PCH�� ���� �� ������ �����ϱ� ���� 'stdafx.h'�� �����մϴ�."
#endif

#include "resource.h"		// �� ��ȣ�Դϴ�.


// CServerFindWindwPrmApp:
// �� Ŭ������ ������ ���ؼ��� ServerFindWindwPrm.cpp�� �����Ͻʽÿ�.
//

class CServerFindWindwPrmApp : public CWinApp
{
public:
	CServerFindWindwPrmApp();

// �������Դϴ�.
public:
	virtual BOOL InitInstance();

// �����Դϴ�.

	DECLARE_MESSAGE_MAP()
};

extern CServerFindWindwPrmApp theApp;