using System;

namespace SoilMoistureSensorCalibratedPumpESP.Tests.Integration
{
    public class ReadIntervalMqttCommandTestHelper : GrowSenseMqttHardwareTestHelper
    {
        public int ReadInterval = 1;

        public void TestSetReadIntervalCommand ()
        {
            WriteTitleText ("Starting read interval command test");

            Console.WriteLine ("Read interval: " + ReadInterval);

            RequireMqttConnection = true;

            ConnectDevices ();

            EnableMqtt ();

            Mqtt.SendCommand ("I", ReadInterval);

            WaitForData (1);

            var dataEntry = WaitForDataEntry ();

            AssertDataValueEquals (dataEntry, "I", ReadInterval);
        }
    }
}
