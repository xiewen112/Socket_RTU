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


        public string GetCmd_Query()
        {
            return cmd_query;
        }
        public string GetCmd_Logout()
        {
            return cmd_logout;
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

        
    }
}
