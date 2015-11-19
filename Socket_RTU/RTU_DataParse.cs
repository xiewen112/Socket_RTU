using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Socket_RTU
{
    class RTU_DataParse
    {
        public string HEADER;
        
        public int DATA_BYTE_LENGTH;
        public string CMD;
        public string ADDRESS;
        public string CMD_CODE;
        public string Usr_Data;

        public string ParseData(string rtu_data){
            string result = string.Empty;
            bool IsVaild = false;
            string S_DATA_LENGTH;

            //1. Vertify input data
            if (rtu_data.Substring(0, 2) == "68" && rtu_data.Substring(rtu_data.Length-2, 2) == "16")
            {
                IsVaild = true;
            }
            else
            {
                IsVaild = false;
            }
           
            if (IsVaild == true)
            {
                //2. split header to get length
                S_DATA_LENGTH = rtu_data.Substring(2, 8);
                DATA_BYTE_LENGTH = Convert.ToInt32(S_DATA_LENGTH.Substring(0, 2),16);

                if (S_DATA_LENGTH.Substring(0, 4) == S_DATA_LENGTH.Substring(4, 4))
                {
                    Console.WriteLine("{0}", "正常：L1 L2相等");
                    //DATA_BYTE_LENGTH*2 + 4 --- 2 means 1 bytes to 2 chars, 4 means "CRC" 2 chars + "end" 2 chars
                    if (rtu_data.Substring(12).Length == (DATA_BYTE_LENGTH*2 + 4))
                    {
                        Console.WriteLine("{0}", "正常：数据长度正确");
                        //3. GET CMD
                        CMD = rtu_data.Substring(12, 2);
                        ADDRESS = rtu_data.Substring(14, 8);
                        CMD_CODE = rtu_data.Substring(22, 2);
                        Console.WriteLine("Length:{0},Cmd:{1},Address:{2},Cmd_code:{3}", DATA_BYTE_LENGTH, CMD, ADDRESS, CMD_CODE);

                    }
                    else
                    {
                        Console.WriteLine("{0}", "错误：数据长度错误");
                        return "ERROR_LENGTH";
                    }
                    
                    

                }
                else
                {
                    Console.WriteLine("{0}", "错误：L1 L2不相等");
                    return "ERROR_L1_L2LENGTH";
                }
                

            }

           return result;
        }
    }
}
