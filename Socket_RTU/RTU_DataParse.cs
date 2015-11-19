﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Socket_RTU
{
    class RTU_DataParse
    {
        public string HEADER;
        
        public int DATA_BYTE_LENGTH = 0;
        public string CMD = string.Empty;
        public string ADDRESS = string.Empty;
        public string CMD_CODE = string.Empty;
        public string RTU_SYS_TIME = string.Empty;
        public string WORK_STATE = string.Empty;
        public string SIGNAL_S = string.Empty;
        public string[] FD = null;
        public string CMD_TYPE = "ERROR";

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
                DATA_BYTE_LENGTH = Convert.ToInt32(swapByte(S_DATA_LENGTH.Substring(0, 4)),16);
                Console.WriteLine("C: {0}", rtu_data.Substring(12).Length);

                if (S_DATA_LENGTH.Substring(0, 4) == S_DATA_LENGTH.Substring(4, 4))
                {
                   
                    //DATA_BYTE_LENGTH*2 + 4 --- 2 means 1 bytes to 2 chars, 4 means "CRC" 2 chars + "end" 2 chars
                    if (rtu_data.Substring(12).Length == (DATA_BYTE_LENGTH*2 + 4))
                    {
                        Console.WriteLine("{0}", "正常：数据长度正确");
                        //3. GET CMD ADD CMD_CODE
                        CMD = rtu_data.Substring(12, 2);
                        ADDRESS = rtu_data.Substring(14, 8);
                        CMD_CODE = rtu_data.Substring(22, 2);
                        
                        //4. judge CMD_TYPE
                        if (CMD == "80" && CMD_CODE == "11")
                        {
                            CMD_TYPE = "RTU_LOGIN";
                        }else if ((CMD == "A0" || CMD == "B0") && CMD_CODE == "21")
                        {
                            CMD_TYPE = "RTU_DATA";
                        }else if(CMD == "E0")
                        {
                            CMD_TYPE = "CMD_ERROR--";
                            switch(rtu_data.Substring(24, 2))
                            {
                                case "01":
                                    break;
                                case "02":
                                    break;
                                case "03":
                                    break;
                                case "04":
                                    CMD_TYPE += "RTU_DATA_EMPTY";
                                    break;
                                default:
                                    CMD_TYPE += "ERROR_CODE";
                                    break;
                            }
                            
                        }else if (CMD == "A0" && CMD_CODE == "12")
                        {
                            CMD_TYPE = "RTU_LOGOUT";
                        }

                        //5. 
                        switch (CMD_TYPE)
                        {
                            case "RTU_LOGIN":
                                longCmdParse(rtu_data);
                                break;
                            case "RTU_DATA":
                                
                                break;
                            case "RTU_DATA_EMPTY":
                                break;
                            case "ERROR_READ_ERROR":
                                break;

                        }

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
        private void longCmdParse(string data)
        {
            RTU_SYS_TIME = timeReform(data).ToString();
            WORK_STATE = data.Substring(36, 4);
            SIGNAL_S = data.Substring(40, 2);
        }
        private DateTime timeReform(string data)
        {
            DateTime result = new DateTime();
            int year;
            int month;
            int day;
            int hh;
            int mi;
            int sec;
            if(data.Length > 40)
            {
                year = Int32.Parse("20" + data.Substring(34, 2));
                month = Int32.Parse(data.Substring(32, 2));
                day = Int32.Parse(data.Substring(30, 2));
                hh = Int32.Parse(data.Substring(28, 2));
                mi = Int32.Parse(data.Substring(26, 2));
                sec = Int32.Parse(data.Substring(24, 2));
                result = new DateTime(year, month, day, hh, mi, sec);
            }

            return result;
        }

        private string[] FD_DataParse(string data)
        {
            string[] result = null;
           // rtu_data.
            return result; 
        }


        private string swapByte(string data)
        {
            string result = string.Empty;
            string str_temp = string.Empty;
            
            if(data.Length >= 4 && (data.Length%2) == 0)
            {
                for (int i = data.Length-2; i  >=0 ; i = i - 2)
                {
                    str_temp += data.Substring(i, 2);
                }
     
            }
            else
            {
                result = string.Empty;
                throw new ArgumentException("swapByte: argument should >= 4 & must be even");
            }
            result = str_temp;

            return result;
        }
    }
}
