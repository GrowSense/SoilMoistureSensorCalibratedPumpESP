using System;

namespace SoilMoistureSensorCalibratedPumpESP.Tests.Integration
{
  public class PumpModeMqttCommandTestHelper : GrowSenseIrrigatorHardwareTestHelper
  {
    public PumpMode PumpModeCommand = PumpMode.Auto;

    public void TestPumpModeCommand ()
    {
      WriteTitleText ("Starting pump mode command test");

      Console.WriteLine ("Pump command: " + PumpModeCommand);
      Console.WriteLine ("");

      RequireMqttConnection = true;

      ConnectDevices ();

      EnableMqtt ();

      Mqtt.SendCommand ("M", (int)PumpModeCommand);

      WaitForData (2);

      var dataEntry = WaitForDataEntry ();
      AssertDataValueEquals (dataEntry, "M", (int)PumpModeCommand);
    }
  }
}