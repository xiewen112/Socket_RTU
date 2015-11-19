using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Socket_RTU
{
    class CRC
    {
        
        public byte CRC8(byte crcPoly, byte[] crcData)
        {
            byte poly = crcPoly;
            byte crcResult = 0xFF;
            byte byteCRCTemp = 0x00;
            byte[] data = new byte[crcData.Length + 1];
            crcData.CopyTo(data, 0);
            data[crcData.Length] = 0x00;

            byteCRCTemp = (data[0]);
            for (int i = 1; i < data.Length; i++)
            {
                byte tempData = data[i];
                int j = 0;
                while (j < 8)
                {
                    j += 1;
                    byte moveOutBit = (byte)(byteCRCTemp & 0x80);
                    byteCRCTemp <<= 1;
                    byteCRCTemp |= (byte)(tempData >> 7);
                    tempData <<= 1;
                    if (moveOutBit == 0x80)//最高位为1，移出跟Poly的最高位消掉
                    {
                        byteCRCTemp = (byte)(byteCRCTemp ^ crcPoly);
                    }
                }
            }

            crcResult &= byteCRCTemp;

            return (byte)(crcResult ^ 0xFF);

        }
    }
}
