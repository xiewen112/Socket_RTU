using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Socket_RTU
{
    class CmdData
    {
        private static string rtu_id = "11111112";
        private static string cmd_query = "680600060068001111111221e716";
        private static string cmd_logout = "680600060068001111111212bb16";
        private string rtn_empty_flag = "680700070068E0111111122104B416";
        private string rtn_login_flag = "637E";
        private string rtn_logout_flag = "680600060068A01111111212E716";

        private string HEADER = string.Empty;
        private int DATA_BYTE_LENGTH = 0;
        private string USER_DATA = string.Empty;
        private string CMD = string.Empty;
        private string ADDRESS = string.Empty;
        private string CMD_CODE = string.Empty;
        private string RTU_SYS_TIME = string.Empty;
        private string WORK_STATE = string.Empty;
        private string SIGNAL_S = string.Empty;
        private string[] FD = null;
        private string CRC_DATA = string.Empty;


        public string cmd_generator(string cmd)
        {
            CRC crc = new CRC();
            string length_data = string.Empty;

            HEADER = string.Empty;
            DATA_BYTE_LENGTH = 0;
            USER_DATA = string.Empty;
            CMD = string.Empty;
            ADDRESS = string.Empty;
            CMD_CODE = string.Empty;
            RTU_SYS_TIME = string.Empty;
            WORK_STATE = string.Empty;
            SIGNAL_S = string.Empty;     
            CRC_DATA = string.Empty;


            string result=string.Empty;
            switch (cmd)
            {
                case "QUERY":

                    CMD = "00";
                    ADDRESS = rtu_id;
                    CMD_CODE = "21";
                    USER_DATA = CMD + ADDRESS + CMD_CODE;
                    CRC_DATA = Convert.ToString(crc.CRC8(USER_DATA, 0), 16);


                    DATA_BYTE_LENGTH = USER_DATA.Length / 2;
                    length_data = swapByte(DATA_BYTE_LENGTH.ToString("x8"));
                    HEADER = "68" + length_data + length_data + "68";
                    result = HEADER + USER_DATA + CRC_DATA + "16";
                    break;
                case "LOGOUT":

                    break;
                default:

                    break;
            }
            return result;
        }

        public string GetCmd_Query()
        {
            return cmd_query;
        }
        public string GetCmd_Logout()
        {
            return cmd_logout;
        }

        public string GetId()
        {
            return rtu_id;
        }

        public void SetId(string id)
        {
            rtu_id = id;
        }

        public void SetCmd_Query(string cmd)
        {
            cmd_query = cmd;
        }

        public void SetCmd_Logout(string cmd)
        {
            cmd_logout  = cmd; ;
        }

        public string GetRtn_flag(int flag)
        {
            string result = string.Empty;
            switch (flag)
            {
                case 1:
                    result = rtn_login_flag;
                    break;
                case 2:
                    result = rtn_empty_flag;
                    break;
                case 3:
                    result = rtn_logout_flag;
                    break;
                default:
                    result = "error";
                    break;
            }
            return result;
        }

        private string swapByte(string data)
        {
            string result = string.Empty;
            string str_temp = string.Empty;


            if (data.Length >= 4 && (data.Length % 2) == 0)
            {
                for (int i = data.Length - 2; i >= 0; i = i - 2)
                {
                    str_temp += data.Substring(i, 2);
                }

            }else if(data.Length == 2)
            {
                str_temp = data + "00";
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
