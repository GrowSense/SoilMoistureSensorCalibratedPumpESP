using NUnit.Framework;

namespace SoilMoistureSensorCalibratedPumpESP.Tests.Integration
{
  [TestFixture (Category = "Integration")]
  public class PumpModeMqttCommandTestFixture : BaseTestFixture
  {
    [Test]
    public void Test_SetPumpToOn ()
    {
      using (var helper = new PumpModeMqttCommandTestHelper ()) {
        helper.PumpModeCommand = PumpMode.On;

        helper.DevicePort = GetDevicePort ();
        helper.DeviceBaudRate = GetDeviceSerialBaudRate ();

        helper.SimulatorPort = GetSimulatorPort ();
        helper.SimulatorBaudRate = GetSimulatorSerialBaudRate ();

        helper.TestPumpModeCommand ();
      }
    }

    [Test]
    public void Test_SetPumpToOff ()
    {
      using (var helper = new PumpModeMqttCommandTestHelper ()) {
        helper.PumpModeCommand = PumpMode.Off;

        helper.DevicePort = GetDevicePort ();
        helper.DeviceBaudRate = GetDeviceSerialBaudRate ();

        helper.SimulatorPort = GetSimulatorPort ();
        helper.SimulatorBaudRate = GetSimulatorSerialBaudRate ();

        helper.TestPumpModeCommand ();
      }
    }

    [Test]
    public void Test_SetPumpToAuto ()
    {
      using (var helper = new PumpModeMqttCommandTestHelper ()) {
        helper.PumpModeCommand = PumpMode.Auto;

        helper.DevicePort = GetDevicePort ();
        helper.DeviceBaudRate = GetDeviceSerialBaudRate ();

        helper.SimulatorPort = GetSimulatorPort ();
        helper.SimulatorBaudRate = GetSimulatorSerialBaudRate ();

        helper.TestPumpModeCommand ();
      }
    }
  }
}
