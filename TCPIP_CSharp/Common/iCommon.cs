using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Common
{
    [Guid("2F640996-D86A-487B-A776-B88D5DCEAC53")]
    public interface iCommon
    {
        void ServerCreate(int port, bool otherPrm);
        string[] ClientCreate(string ipAddress, int port, int index, string[] data);
        string[] ReceiveDataSaving();
    }
}



