#pragma once

#include "Serial\CommThread.h"
#include <vector>
#include "DeviceSerialGMS.h"
#include "DeviceSerialPrinter.h"
#include "DeviceSerialServoTorque.h"
#include "DeviceSerialTemperature.h"
#include "DeviceSerialVacuum.h"
//ihjo 2018-06-19 EFU Controller �������� �߰� 
#include "DeviceSerialEFU.h"


using namespace std;

struct SERIAL_MODE_SET
{
	SERIAL_MODE SerialMode;
	int			nPort;
	CString		m_sPortNickName;
};


static SERIAL_MODE_SET SerialModeSet[] = 
{	
	//kjpark2017/09/01 Serial ���� - Temp �߰�, �� 2 ����, ��ũ ����, ���ο���
	//kjpark 20170922 �µ����� ��� ����
	//kjpark 20170922 GMS ��� �Ϸ�

	{SERIAL_AD_BOARD				, 4, _T("SERIAL_AD_BOARD")},
	{SERIAL_TEMP_CONTROLLER			, 6, _T("SERIAL_TEMP_CONTROLLER")},	
	{SERIAL_GMS_PGMS				, 8, _T("SERIAL_GMS_PGMS")},
	{SERIAL_LABELPRINT				, 10, _T("SERIAL_LABELPRINT")},
	{SERIAL_EFU_CONTROLLER          , 11, _T("SERIAL_EFU_CONTROLLER")},

		
};

class CSerialManager
{
public:
	CSerialManager(void);
	~CSerialManager(void);

	std::vector<CCommThread> m_vctNPortReal;
	std::vector<std::vector<unsigned char>> m_vctStrData; 

	DWORD	SerialSendData(SERIAL_MODE nPort, BYTE *pBuff, DWORD nToWrite); 
	int		SerialGetDataBuffer(SERIAL_MODE nPort, BYTE *cstr, int nMaxSize);

	BOOL SerialOpen(SERIAL_MODE nPort);
	BOOL SerialClose(SERIAL_MODE nPort);
	BOOL SerialCodeSend(int nCode, int nPort);
	BOOL SerialAckCheck(SERIAL_MODE nPort);
		
	//kjpark2017/09/01 Serial ���� - Temp �߰�, �� 2 ����, ��ũ ����, ���ο���
	CDeviceSerialVacuum* GetVacuumMainHandler() {return &m_DeviceVacuumMain;}
	CDeviceSerialTemperature* GetPCTemperatureHandler() {return &m_pDevicePCTemperature;}
	CDeviceSerialGMS* GetDeviceGMSHandler1() {return &m_DeviceGMS1;}
	CDeviceSerialGMS* GetDeviceGMSHandler2() {return &m_DeviceGMS2;}
	CDeviceSerialPrinter* GetLabelPrinterHandler() {return &m_DeviceLabelPrinter;}	
	
	void SendCommand();		
	void PacketReceive(SERIAL_MODE serialMode, BYTE *byBuf, int nSize);

	//////////////////////////////////////////////////////////////////////////
	// Vacuum [12/11/2016 OSC]
public:
	void SendSetVacRange();

	//kjpark 20170928 Adboard Read
	void SendVacRead(int nSlot);
	void SendVacReadLD();
	void SendVacReadUD();

	//kjpark2017/09/01 Serial ���� - Temp �߰�, �� 2 ����, ��ũ ����, ���ο���
	BOOL ParsingLDMainVacuumValue();
		
	int GetDeviceAddr();
	BOOL ParsingTemperatureValue();
	void CopyTempValue_to_FDCBank(int nAddr);
	void SendTempRead(int nAddr);

private:
	BOOL m_bFirst;
public:
	// �ѹ��� �ϳ��� �ۿ� �� �б� ������ ���α׷� ���� Ű�� ���� �� �ޱ� �� ������ 0�� ���� �����Ѵ�.
	// ���δ� �޾Ҵ��� Ȯ�� ���� �Ʒ� BOOL ���� �߰�
	BOOL m_bADBoardReadable;

	void CopyLoadADBoardValue_to_FDCBank();	
	//////////////////////////////////////////////////////////////////////////
	// Label Printer [12/16/2016 OSC]
	void SendLabelPrintOut(CCellInfo *pCell);
	//////////////////////////////////////////////////////////////////////////
		
private:	
	//kjpark2017/09/01 Serial ���� - Temp �߰�, �� 2 ����, ��ũ ����, ���ο���
	CDeviceSerialVacuum m_DeviceVacuumMain;
	CDeviceSerialTemperature m_pDevicePCTemperature;
	CDeviceSerialGMS m_DeviceGMS1;	
	CDeviceSerialGMS m_DeviceGMS2;	
	CDeviceSerialPrinter m_DeviceLabelPrinter;
	//ihjo 2018-06-19 EFU Controller �������� �߰� 
	CDeviceSerialEFU m_DeviceEFUCtrl;
	
	FDC_ALARM_STATE m_stateMainAir;
	CStopWatch m_timerMainAirAlarm;

};
