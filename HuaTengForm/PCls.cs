using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuaTengForm
{
    public class PCls
    {
        public static int TypeILF = 0;
        public static int TypeB1 = 1;
        public static int TypeB0 = 2;
        public static int TypeBT = 3;

        public static int StepPath;
        public static int OpenPicNo;
        public static int ClosePicNo;

        /// <summary>
        /// 以下为客户填写部分
        /// </summary>
        public static string mIP = "192.168.0.2";
        public static int mPort = 502;

        //创建COM1
        public static ComClassLib.ModbusEthernet COM1 = new ComClassLib.ModbusEthernet(2, mIP, mPort);//<参数1>连接编号<参数2>IP地址<参数3>端口号
        //public static ComClassLib.yokoEthernet COM1 = new ComClassLib.yokoEthernet(2, mIP, mPort);//<参数1>连接编号<参数2>IP地址<参数3>端口号
        public static ComClassLib.tagFile mInterface = new ComClassLib.tagFile();      //界面读取部分

    }
}
