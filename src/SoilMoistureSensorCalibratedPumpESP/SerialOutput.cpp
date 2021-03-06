#include <Arduino.h>
#include <EEPROM.h>

#include "Common.h"
#include "SoilMoistureSensor.h"
#include "Irrigation.h"
#include "MQTT.h"
#include "DeviceName.h"

void serialPrintDeviceInfo()
{
  Serial.println("");
  Serial.println("-- Start Device Info");
  Serial.println("Family: GrowSense");
  Serial.println("Group: irrigator");
  Serial.println("Project: SoilMoistureSensorCalibratedPumpESP");
  Serial.print("Board: ");
  Serial.println(BOARD_TYPE);
  Serial.print("Device name: ");
  Serial.println(deviceName);
  Serial.print("Version: ");
  Serial.println(VERSION);
  Serial.println("ScriptCode: irrigator");
  Serial.println("-- End Device Info");
  Serial.println("");
}

void serialPrintData()
{
  bool isTimeToPrintData = millis() - lastSerialOutputTime >= secondsToMilliseconds(serialOutputIntervalInSeconds)
      || lastSerialOutputTime == 0;

  bool isReadyToPrintData = isTimeToPrintData && soilMoistureSensorReadingHasBeenTaken;

  if (isReadyToPrintData)
  {
    lastSerialOutputTime = millis();

    if (isDebugMode)
    {
      Serial.println("Printing serial data");
    }

    Serial.print("D;"); // This prefix indicates that the line contains data.
    Serial.print("Name:");
    Serial.print(deviceName);
    Serial.print(";");
    Serial.print("R:");
    Serial.print(soilMoistureLevelRaw);
    Serial.print(";");
    Serial.print("C:");
    Serial.print(soilMoistureLevelCalibrated);
    Serial.print(";");
    Serial.print("T:");
    Serial.print(threshold);
    Serial.print(";");
    Serial.print("M:");
    Serial.print(pumpMode);
    Serial.print(";");
    Serial.print("I:");
    Serial.print(soilMoistureSensorReadingIntervalInSeconds);
    Serial.print(";");
    Serial.print("B:");
    Serial.print(pumpBurstOnTime);
    Serial.print(";");
    Serial.print("O:");
    Serial.print(pumpBurstOffTime);
    Serial.print(";");
    Serial.print("WN:"); // Water needed
    Serial.print(soilMoistureLevelCalibrated < threshold);
    Serial.print(";");
    Serial.print("PO:");
    Serial.print(pumpIsOn);
    Serial.print(";");
    Serial.print("D:"); 
    Serial.print(drySoilMoistureCalibrationValue);
    Serial.print(";");
    Serial.print("W:");
    Serial.print(wetSoilMoistureCalibrationValue);
    Serial.print(";");
    Serial.print("WC:");
    Serial.print(isWiFiConnected);
    Serial.print(";");
    Serial.print("MC:");
    Serial.print(isMqttConnected);
    Serial.print(";");
    Serial.print("V:");
    Serial.print(VERSION);
    Serial.print(";;");
    Serial.println();

    if (isDebugMode)
    {
      Serial.print("Last pump start time:");
      Serial.println(pumpStartTime);
      Serial.print("Last pump finish time:");
      Serial.println(lastPumpFinishTime);
    }

  }
}

void forceSerialOutput()
{
    // Reset the last serial output time 
    lastSerialOutputTime = 0;//millis()-secondsToMilliseconds(serialOutputIntervalInSeconds);
}
