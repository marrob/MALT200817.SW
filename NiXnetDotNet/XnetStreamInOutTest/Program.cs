using System;
using System.Collections.Generic;
using NiXnetDotNet;
using System.Runtime.InteropServices;

namespace XnetStreamInOutTest
{
    class Program
    {
        static void Main(string[] args)
        {
            new AppStreamOut();
         //   new AppStreamIn();
            Console.Read();
        }
    }


    class AppDevice
    {
        private NiXnetSystem _system = null;
        public AppDevice()
        {
            _system = new NiXnetSystem();

            var xnetDevices = new List<NiXnetDevice>();
            NiXnetDevice selectedDevice = null;
            foreach (NiXnetDevice device in _system.ListDevices())
            {
                xnetDevices.Add(device);
                selectedDevice = device;
                Console.WriteLine(device.ProductName);
                break;
            }            
        }
    }

class AppStreamIn
{
    [StructLayout(LayoutKind.Sequential)]
    public struct nxFrame
    {
        [MarshalAs(UnmanagedType.U8)]
        public UInt64 Timestamp;
        [MarshalAs(UnmanagedType.U4)]
        public UInt32 Id;
        [MarshalAs(UnmanagedType.U1)]
        public Byte Type;
        [MarshalAs(UnmanagedType.U1)]
        public Byte Flags;
        [MarshalAs(UnmanagedType.U1)]
        public Byte Info;
        [MarshalAs(UnmanagedType.U1)]
        public Byte Length;
        [MarshalAs(UnmanagedType.U8)]
        public UInt64 Payload;
    };
    private NiXnetSession _sessionIn = null;
    private string Interface = "CAN1";
    public AppStreamIn()
    {
        _sessionIn = new NiXnetSession(":memory:", "", Array.Empty<string>(), Interface, NiXnetMode.FrameInStream);
        _sessionIn.BaudRate64 = 500000;
        nxFrame[] bufferIn = new nxFrame[100];
        GCHandle gch = GCHandle.Alloc(bufferIn, GCHandleType.Pinned);
        IntPtr ptr = gch.AddrOfPinnedObject();
        UInt32 readBytes;
        UInt32 totalBytes = 0;
        UInt32 cycle = 0;
        unsafe
            {
                var timestamp = DateTime.Now.Ticks;
                do
                {
                    _sessionIn.ReadFrame((void*)ptr, (uint)bufferIn.Length * (uint)sizeof(nxFrame), 0, &readBytes);
                    totalBytes += readBytes;
                    System.Threading.Thread.Sleep(100);
                    Console.SetCursorPosition(0, 0);
                    Console.WriteLine("Cycles:" + cycle++);
                    Console.SetCursorPosition(0, 1);
                    Console.WriteLine("Total Read Byte:" + totalBytes);
                    Console.WriteLine("Total Read Frames:" + totalBytes / sizeof(nxFrame));

                } while (!(DateTime.Now.Ticks - timestamp > 10000 * 9000));
                for (int i = 0; i < totalBytes / sizeof(nxFrame); i++)
                {
                    Console.WriteLine(bufferIn[i].Id.ToString());
                    Console.WriteLine(bufferIn[i].Payload.ToString());
                }
            }
        Console.WriteLine("Complete");
    }
        
}

        
class AppStreamOut
{

    [StructLayout(LayoutKind.Sequential)]
    public struct nxFrame
    { 
        [MarshalAs(UnmanagedType.U8)]
        public UInt64 Timestamp;
        [MarshalAs(UnmanagedType.U4)]
        public UInt32 Id;
        [MarshalAs(UnmanagedType.U1)]
        public Byte Type;
        [MarshalAs(UnmanagedType.U1)]
        public Byte Flags;
        [MarshalAs(UnmanagedType.U1)]
        public Byte Info;
        [MarshalAs(UnmanagedType.U1)]
        public Byte Length;
        [MarshalAs(UnmanagedType.U8)]
        public UInt64 Payload;
    };

        
    private NiXnetSession _sessionOut = null;
    private string Interface = "CAN1";

    public AppStreamOut()
    {
        _sessionOut = new NiXnetSession(":memory:", "", Array.Empty<string>(), Interface, NiXnetMode.FrameOutStream);
        _sessionOut.BaudRate64 = 500000;
        nxFrame[] bufferOut = new nxFrame[2];
        bufferOut[0].Id = 1;
        bufferOut[0].Payload = 8;
        bufferOut[0].Length = 8;
        bufferOut[1].Id = 2;

        GCHandle gch = GCHandle.Alloc(bufferOut, GCHandleType.Pinned);
        IntPtr ptr = gch.AddrOfPinnedObject();

        unsafe
        {
            _sessionOut.WriteFrame((void*)ptr, (uint)bufferOut.Length * (uint)sizeof(nxFrame), 10000);


                _sessionOut.Dispose();
        }

    }
}
}
