using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Socket_RTU
{
    class RTU_DataParse
    {
        
        
        public int DATA_BYTE_LENGTH = 0;
        public int FD_DATA_LENGTH = 0;
        public string USER_DATA = string.Empty;
        public string CMD = string.Empty;
        public string ADDRESS = string.Empty;
        public string CMD_CODE = string.Empty;
        public string RTU_SYS_TIME = string.Empty;
        public string WORK_STATE = string.Empty;
        public string SIGNAL_S = string.Empty;
        public string[] FD_DATA = new string[50];
        public string CMD_TYPE = "ERROR";
        public string CRC_DATA = string.Empty;

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
                        USER_DATA = rtu_data.Substring(12, DATA_BYTE_LENGTH * 2);
                        CRC ccc = new CRC();
                        CRC_DATA = Convert.ToString(ccc.CRC8(USER_DATA, 0), 16);
                         Console.WriteLine("USER_dATA: {0}, {1}", USER_DATA, CRC_DATA);

                        //4. judge CMD_TYPE
                        if (CMD == "80" && CMD_CODE == "11")
                        {
                            CMD_TYPE = "RTU_LOGIN";
                        }
                        else if ((CMD == "A0" || CMD == "B0") && CMD_CODE == "21")
                        {
                            CMD_TYPE = "RTU_DATA";
                        }else if((CMD == "80" && CMD_CODE == "12"))
                        {
                            CMD_TYPE = "RTU_REQUIRE_LOGOUT";
                        }
                        else if(CMD == "E0")
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

                                FD_DATA = FD_DataParse(USER_DATA);
                                break;
                            case "RTU_REQUIRE_LOGOUT":

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
            RTU_SYS_TIME = timeReform(data.Substring(24,12)).ToString();
            WORK_STATE = data.Substring(36, 4);
            SIGNAL_S = data.Substring(40, 2);
        }
        public DateTime timeReform(string data)
        {
            DateTime result = new DateTime();
            int year;
            int month;
            int day;
            int hh;
            int mi;
            int sec;
            if(data.Length == 12)
            {
                year = Int32.Parse("20" + data.Substring(10, 2));
                month = Int32.Parse(data.Substring(8, 2));
                day = Int32.Parse(data.Substring(6, 2));
                hh = Int32.Parse(data.Substring(4, 2));
                mi = Int32.Parse(data.Substring(2, 2));
                sec = Int32.Parse(data.Substring(0, 2));
                result = new DateTime(year, month, day, hh, mi, sec);
            }

            return result;
        }

        private string[] FD_DataParse(string userdata)
        {
            string[] result = null;
            string temp_Data;
            int[] fd_index;
            int start_index=0;
            int count;
            // rtu_data.
            RTU_SYS_TIME = timeReform(userdata.Substring(12, 12)).ToString();
            WORK_STATE = userdata.Substring(24, 4);
            temp_Data = userdata.Substring(28);
            count = temp_Data.Length - temp_Data.Replace("FD", "D").Length;
            FD_DATA_LENGTH = count;
            fd_index = new int[count+1]; // count+1 for precation of overwrite
            result = new string[count];
            for (int i = 0; i< temp_Data.Length; i++)
            {
                if(i > 1 && i < temp_Data.Length - 1)
                    if(temp_Data[i] == 'F')
                    {
                        if (temp_Data[i+1] == 'D')
                        {
                                fd_index[start_index] = i - 2;
                                start_index++;
                        }
                    }
            }

            for(int j=0; j< count; j++)
            {
                if(j == count-1)
                {
                    result[j] = temp_Data.Substring(fd_index[j]);
                }
                else
                {
                    result[j] = temp_Data.Substring(fd_index[j], fd_index[j + 1] - fd_index[j]);
                }
                
            }

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
