#include <Arduino.h>
#include <EEPROM.h>
#include <stdlib.h>

#include <duinocom2.h>

#include "Common.h"
#include "EEPROMHelper.h"
#include "WiFi.h"
#include "MQTT.h"
#include "Commands.h"
#include "SoilMoistureSensor.h"
#include "SerialOutput.h"
#include "Irrigation.h"
#include "DeviceName.h"

void setup()
{
  Serial.begin(9600);

  Serial.println("Starting WiFi irrigator");

  EEPROM.begin(512);

  //checkCommand();

  loadDeviceNameFromEEPROM();

  serialPrintDeviceInfo();

  Serial.println("Device started...");

  setupSoilMoistureSensor();

  setupIrrigation();

  serialOutputIntervalInSeconds = soilMoistureSensorReadingIntervalInSeconds;

  delay(200);
}

void loop()
{
// Disabled. Used for debugging
//  Serial.print(".");

  if (isDebugMode)
    loopNumber++;

  serialPrintLoopHeader();

  checkCommand();

  loopWiFi();

  loopMqtt();

  takeSoilMoistureSensorReading();

  serialPrintData();

  mqttPublishData();

  irrigateIfNeeded();

  // Reset flag for this loop
  soilMoistureSensorReadingHasBeenTaken = false;

  serialPrintLoopFooter();

  delay(1);
}
