
// EFU_SerialPrm.h : PROJECT_NAME ���� ���α׷��� ���� �� ��� �����Դϴ�.
//

#pragma once

#ifndef __AFXWIN_H__
	#error "PCH�� ���� �� ������ �����ϱ� ���� 'stdafx.h'�� �����մϴ�."
#endif

#include "resource.h"		// �� ��ȣ�Դϴ�.


// CEFU_SerialPrmApp:
// �� Ŭ������ ������ ���ؼ��� EFU_SerialPrm.cpp�� �����Ͻʽÿ�.
//

class CEFU_SerialPrmApp : public CWinApp
{
public:
	CEFU_SerialPrmApp();

// �������Դϴ�.
public:
	virtual BOOL InitInstance();

// �����Դϴ�.

	DECLARE_MESSAGE_MAP()
};

extern CEFU_SerialPrmApp theApp;