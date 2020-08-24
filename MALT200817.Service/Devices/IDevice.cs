﻿namespace MALT200817.Service.Devices
{
    using System;

    public interface IDevice
    {
        byte Address { get; }
        void Update(byte msgId, byte[] data);
        DateTime LastRxTimeStamp { get; }
    }
}