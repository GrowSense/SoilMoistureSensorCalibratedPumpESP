using System;

namespace SoilMoistureSensorCalibratedPumpESP.Tests.Integration
{
    public class SerialOutputTimeTestHelper : GrowSenseMqttHardwareTestHelper
    {
        public int ReadInterval = 1;

        public void TestSerialOutputTime ()
        {
            WriteTitleText ("Starting serial output time test");

            Console.WriteLine ("Read interval: " + ReadInterval);

            ConnectDevices ();

            SetDeviceReadInterval (ReadInterval);

            ReadFromDeviceAndOutputToConsole ();

            // Skip some data
            WaitForData (5); // TODO: See if this can be reduced

            // Get the time until the next data line
            var secondsBetweenDataLines = WaitUntilDataLine ();

            var expectedTimeBetweenDataLines = ReadInterval;

            Console.WriteLine ("Time between data lines: " + secondsBetweenDataLines + " seconds");

            AssertIsWithinRange ("serial output time", expectedTimeBetweenDataLines, secondsBetweenDataLines, TimeErrorMargin);
        }
    }
}
