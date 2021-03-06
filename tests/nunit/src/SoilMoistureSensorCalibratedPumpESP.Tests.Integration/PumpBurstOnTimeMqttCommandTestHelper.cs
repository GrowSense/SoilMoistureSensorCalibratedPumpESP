﻿using System;

namespace SoilMoistureSensorCalibratedPumpESP.Tests.Integration
{
    public class PumpBurstOnTimeMqttCommandTestHelper : GrowSenseIrrigatorHardwareTestHelper
    {
        public int PumpBurstOnTime = 1;

        public void TestPumpBurstOnTimeCommand ()
        {
            WriteTitleText ("Starting pump burst on time command test");

            Console.WriteLine ("Pump burst on time: " + PumpBurstOnTime);
            Console.WriteLine ("");

            RequireMqttConnection = true;

            ConnectDevices ();

            EnableMqtt ();

            Mqtt.SendCommand ("B", PumpBurstOnTime);

            Console.WriteLine ("Skipping the next data entires in case they're out of date...");

            WaitForData (2);

            var dataEntry = WaitForDataEntry ();

            AssertDataValueEquals (dataEntry, "B", PumpBurstOnTime);
        }
    }
}