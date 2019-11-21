using System;

namespace SoilMoistureSensorCalibratedPumpESP.Tests.Integration
{
  public class PumpModeCommandTestHelper : SerialCommandTestHelper
  {
    public PumpMode PumpCommand = PumpMode.Auto;

    public void TestPumpModeCommand ()
    {
      Key = "M";
      Value = ((int)PumpCommand).ToString ();
      Label = "pump mode";
      ValueIsSavedInEEPROM = false;

      TestCommand ();
    }
  }
}