﻿using System;
using NUnit.Framework;
using duinocom;
using System.Threading;
using ArduinoSerialControllerClient;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.IO.Ports;

namespace SoilMoistureSensorCalibratedPumpESP.Tests.Integration
{
	[TestFixture(Category = "Integration")]
	public class PumpBurstOffTimeMqttCommandTestFixture : BaseTestFixture
	{
		[Test]
		public void Test_SetPumpBurstOffTime_0Seconds()
		{
			using (var helper = new PumpBurstOffTimeMqttCommandTestHelper())
			{
				helper.PumpBurstOffTime = 0;

				helper.DevicePort = GetDevicePort();
				helper.DeviceBaudRate = GetDeviceSerialBaudRate();

				helper.SimulatorPort = GetSimulatorPort();
				helper.SimulatorBaudRate = GetSimulatorSerialBaudRate();

				helper.TestPumpBurstOffTimeCommand();
			}
		}

		[Test]
		public void Test_SetPumpBurstOffTime_1Seconds()
		{
			using (var helper = new PumpBurstOffTimeMqttCommandTestHelper())
			{
				helper.PumpBurstOffTime = 1;

				helper.DevicePort = GetDevicePort();
				helper.DeviceBaudRate = GetDeviceSerialBaudRate();

				helper.SimulatorPort = GetSimulatorPort();
				helper.SimulatorBaudRate = GetSimulatorSerialBaudRate();

				helper.TestPumpBurstOffTimeCommand();
			}
		}

		[Test]
		public void Test_SetPumpBurstOffTime_5Seconds()
		{
			using (var helper = new PumpBurstOffTimeMqttCommandTestHelper())
			{
				helper.PumpBurstOffTime = 5;

				helper.DevicePort = GetDevicePort();
				helper.DeviceBaudRate = GetDeviceSerialBaudRate();

				helper.SimulatorPort = GetSimulatorPort();
				helper.SimulatorBaudRate = GetSimulatorSerialBaudRate();

				helper.TestPumpBurstOffTimeCommand();
			}
		}
	}
}
