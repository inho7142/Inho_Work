#include "StdAfx.h"
#include "DeviceSerialEFU.h"

#pragma region Constructor / Destructor
CDeviceSerialEFU::CDeviceSerialEFU(CString strSerialName) : m_strSerialName(strSerialName)
{
	m_Serial.m_QueueRead.SetStartChar(STX);
	m_Serial.m_QueueRead.SetEndChar(ETX);
}

CDeviceSerialEFU::~CDeviceSerialEFU(void)
{
	delete []m_pEFU;
}

#pragma endregion

#pragma region Serial On / off & Check
BOOL CDeviceSerialEFU::SerialOpen( short nPortNo )
{
	if(IsOpen()) 
	{
		return TRUE;
	}
	return m_Serial.InitCommPort(nPortNo,CBR_9600,8,ONESTOPBIT,NOPARITY);
}

void CDeviceSerialEFU::SerialClose()
{
	if(IsOpen() == FALSE)
	{
		return;
	}
	m_Serial.ClosePort();
}

BOOL CDeviceSerialEFU::IsOpen()
{
	return m_Serial.m_bConnected;
}

#pragma endregion 

#pragma region ReciveCommand 
BOOL CDeviceSerialEFU::ParsingReceiveValue()
{
	if(IsOpen() == FALSE) 
	{
		return FALSE;
	}
	
	BYTE buf[CMD_LENGTH::RECEIVE_MAX];
	BYTE bModeFirst = 0x00;

	int nReciveLength = m_Serial.m_QueueRead.GetDataSTX_To_ETX(buf, CMD_LENGTH::RECEIVE_MAX - 1);
	
	if(nReciveLength < 1)
	{	
		return FALSE;
	}
	// 동적 할당 (소멸자 생성 확인)
	m_pEFU = new BYTE[nReciveLength];
	// Mode1 값으로 체크한다 
	bModeFirst = buf[1];

	switch (bModeFirst)
	{
		case MODE_FIRST::GET_PV_ALRAM_ICPSV:
			
			for (int i = 0; i < nReciveLength; i++)
			{
				m_pEFU[i] = buf[i];
			}
			break;

		case MODE_FIRST::SET_ICU_SPEED:
			for (int i = 0; i < nReciveLength; i++)
			{
				m_pEFU[i] = buf[i];
			}
			break;

		case MODE_FIRST::SET_DP:
			for (int i = 0; i < nReciveLength; i++)
			{
				m_pEFU[i] = buf[i];
			}
			break;

		case MODE_FIRST::GET_DP:
			for (int i = 0; i < nReciveLength; i++)
			{
				m_pEFU[i] = buf[i];
			}
			break;
	}

	if(m_Serial.m_QueueRead.GetSizeStartChar_To_EndChar() <= 0)
	{
		return TRUE;
	}
		
	return FALSE;
}

#pragma endregion 

#pragma region SendCommand
// Process Value & Alram & Setting Value 요청 
DWORD CDeviceSerialEFU::SendPVAlram_ICUSpeedSV_GetCommand(int lv32_ID, int start_ICU_ID, int end_ICU_ID)
{
	BYTE	bySend[CMD_LENGTH::SEND_MAX];
	int		nLen = 0;

	bySend[nLen++]	= 0x02; // fix data
	bySend[nLen++]	= 0x8A; // fix data
	bySend[nLen++]	= 0x87; // fix data
	bySend[nLen++]	= (lv32_ID | 0x80);		
	bySend[nLen++]	= 0x9F; // fix data
	bySend[nLen++]	= (start_ICU_ID | 0x80);
	bySend[nLen++]	= (end_ICU_ID | 0x80);	
	bySend[nLen++]	= GetChecksum(bySend, nLen); 
	bySend[nLen++]	= 0x03; // fix data

	int nSendLen =  m_Serial.WriteComm( bySend, nLen );
	return nSendLen;
}
// ICU Speed Value Setting  (ICU 지정 속도 변경)
DWORD CDeviceSerialEFU::SendICUSpeedSetCommand(int lv32_ID, int start_ICU_ID, int end_ICU_ID, byte settingValue)
{
	BYTE	bySend[CMD_LENGTH::SEND_MAX];
	int		nLen = 0;

	bySend[nLen++]	= 0x02; // fix data
	bySend[nLen++]	= 0x89; // fix data
	bySend[nLen++]	= 0x84;	// fix data
	bySend[nLen++]	= (lv32_ID | 0x80);		
	bySend[nLen++]	= 0x9F;	// fix data				
	bySend[nLen++]	= (start_ICU_ID | 0x80);
	bySend[nLen++]	= (end_ICU_ID | 0x80);	
	bySend[nLen++]	= settingValue; // ICU 지정속도 변경				
	bySend[nLen++]	= GetChecksum(bySend, nLen); 
	bySend[nLen++]	= 0x03; // fix data

	int nSendLen =  m_Serial.WriteComm( bySend, nLen );
	return nSendLen;
}
// differential pressure (차압 데이터) Setting
DWORD CDeviceSerialEFU::SendDPSetCommand(int lv32_ID, BYTE highData, BYTE lowData)
{
	BYTE	bySend[CMD_LENGTH::SEND_MAX];
	int		nLen = 0;
	
	bySend[nLen++]	= 0x02; // fix data
	bySend[nLen++]	= 0xA1; // fix data
	bySend[nLen++]	= (lv32_ID | 0x80);		
	bySend[nLen++]	= highData;
	bySend[nLen++]	= lowData;
	bySend[nLen++]	= GetChecksum(bySend, nLen); 
	bySend[nLen++]	= 0x03; // fix data

	int nSendLen =  m_Serial.WriteComm( bySend, nLen );
	return nSendLen;
}
// Differential Pressure Value (차압 데이터) 요청
DWORD CDeviceSerialEFU::SendDPGetCommand(int lv32_ID)
{
	BYTE	bySend[CMD_LENGTH::SEND_MAX];
	int		nLen = 0;
	
	bySend[nLen++]	= 0x02; // fix data
	bySend[nLen++]	= 0xA2; // fix data
	bySend[nLen++]	= (lv32_ID | 0x80);		
	bySend[nLen++]	= GetChecksum(bySend, nLen); 
	bySend[nLen++]	= 0x03; // fix data

	int nSendLen =  m_Serial.WriteComm( bySend, nLen );
	return nSendLen;
}
#pragma endregion 

#pragma region other  
BYTE CDeviceSerialEFU::GetChecksum(BYTE* pData, int nLen)
{
	BYTE bySum = pData[0];

	for (int i = 1; i < nLen; i++) 
	{
		bySum = (bySum + pData[i]) & 0xFF;			
	}
	return ((~bySum + 1) & 0xFF);		
}

void CDeviceSerialEFU::SetSerialName(CString strValue)
{
	m_strSerialName = strValue;
}

void CDeviceSerialEFU::ClearQueue()
{
	if (m_Serial.m_QueueRead.GetSize() != NULL)
	{
		m_Serial.m_QueueRead.Clear();
	}
}
#pragma endregion