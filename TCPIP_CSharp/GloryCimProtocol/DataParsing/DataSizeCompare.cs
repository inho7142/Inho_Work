using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloryCimProtocol.DataParsing
{
   
    public static class DataSizeCompare
    {
        enum dataSize
        {
            SUSSCESS = 0,
            NG,
            ERROR
        };

        static int[] bacodsizeCompere = { 1, 1, 2, 2, 20, 20, 5, 5, 20, 1 };
        static int[] bacodsizeCompere1 = { 1, 1, 2, 2, 20, 20, 5, 5, 20, 1 };
        static int[] bacodsizeCompere2 = { 1, 1, 2, 2, 20, 20, 5, 5, 20, 1 };

        public static List<string> ReceiveDataCompare(List<string> data, int index)
        {
            int resultVaule = 1;

             switch (index)
            {
                case 0401:
                    resultVaule = DataCompare(data, bacodsizeCompere);
                    break;
                case 0411:
                    resultVaule = DataCompare(data, bacodsizeCompere);
                    break;
                case 0403:
                    resultVaule = DataCompare(data, bacodsizeCompere);
                    break;
                case 0419:
                    resultVaule = DataCompare(data, bacodsizeCompere);
                    break;
                case 0607:
                    //resultVaule = DataCompare(data, bacodsizeCompere);
                    break;
                case 0415:
                    resultVaule = DataCompare(data, bacodsizeCompere);
                    break;
                case 0413:
                    resultVaule = DataCompare(data, bacodsizeCompere);
                    break;
             }
            return data;

        }
        public static int DataCompare(List<string> data, int[] sizeArray)
        {
            int resultVaule = 1;
            
            for (int i = 0; i < data.Count; i++)
            {

                if (data[i].Length != sizeArray[i])
                {
                    resultVaule = (int)dataSize.ERROR;
                    return resultVaule;
                }
                else
                {
                    resultVaule = 0;
                }
            }
            return resultVaule;
        }
    }
}
