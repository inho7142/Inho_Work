#pragma once
#include "../ModuleInternal/Serial/CommThread.h"

namespace MODE_FIRST
{
	enum
	{
		// 두번째 Bit : Mode1 로 구분한다. 
		GET_PV_ALRAM_ICPSV = 0x8A,
		SET_ICU_SPEED = 0x89,
		SET_DP = 0xA1,
		GET_DP =0xA2
	};	
}

namespace CMD_LENGTH
{
	enum
	{
		SEND_MAX = 10,
		RECEIVE_MAX = 20,
	};	
}

class CDeviceSerialEFU
{
public:
	CDeviceSerialEFU(CString strSerialName = _T("")); //: m_strSerialName(strSerialName)
	~CDeviceSerialEFU(void);

private:
	CCommThread m_Serial;
	double m_dOffset;
	CString m_strSerialName;

public:
	BYTE * m_pEFU;
public:
	// Constructor, Destructor
	BOOL SerialOpen(short nPortNo);
	void SerialClose();
	BOOL IsOpen();

	// Receive Command
	BOOL ParsingReceiveValue();

	// Send Command
	DWORD SendPVAlram_ICUSpeedSV_GetCommand(int lv32_ID, int start_ICU_ID, int end_ICU_ID);
	DWORD SendICUSpeedSetCommand(int lv32_ID, int start_ICU_ID, int end_ICU_ID, BYTE settingValue);
	DWORD SendDPSetCommand(int lv32_ID, BYTE highData, BYTE lowData);
	DWORD SendDPGetCommand(int lv32_ID);

	// other
	BYTE GetChecksum(BYTE* pData, int nLen);
	void SetSerialName(CString strValue);
	void ClearQueue();

	void SetValueOffset(double dOffset) 
	{ 
		m_dOffset = dOffset; 
	}

	CCommThread GetCommThreadHandler() 
	{
		return m_Serial;
	};
};
