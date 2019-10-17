﻿using CSuperSocket.SocketBase;
using SuperNAT.Common;
using SuperNAT.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperNAT.Server
{
    public class NatAppSession : AppSession<NatAppSession, NatRequestInfo>
    {
        public Client Client { get; set; }
        public List<Map> MapList { get; set; }
        public void SendMsg(string msg)
        {
            try
            {
                //请求头 01 05 长度(4)
                var sendBytes = new List<byte>() { 0x1, 0x5 };
                var jsonBytes = Encoding.UTF8.GetBytes(msg);
                sendBytes.AddRange(BitConverter.GetBytes(jsonBytes.Length).Reverse());
                sendBytes.AddRange(jsonBytes);
            }
            catch(Exception ex)
            {
                HandleLog.WriteLine($"发送下次消息失败");
            }
        }
    }
}
