#ifndef IRRIGATION_H_
#define IRRIGATION_H_

#include <Arduino.h>
#include <EEPROMHelper.h>

#define PUMP_PIN 13 // Mapped to physical pin 11 on Wemos D1

#define PUMP_MODE_OFF 0
#define PUMP_MODE_ON 1
#define PUMP_MODE_AUTO 2

extern int threshold;
extern bool pumpIsOn;
extern unsigned long pumpStartTime;
extern unsigned long lastPumpFinishTime;
extern long pumpBurstOnTime;
extern long pumpBurstOffTime;
extern int pumpMode;
extern int thresholdIsSetEEPROMFlagAddress;
extern int thresholdEEPROMAddress;
extern int pumpBurstOnTimeIsSetEEPROMFlagAddress;
extern int pumpBurstOnTimeEEPROMAddress;
extern int pumpBurstOffTimeIsSetEEPROMFlagAddress;
extern int pumpBurstOffTimeEEPROMAddress;

void setupIrrigation();
void setupThreshold();
void setupPumpBurstOnTime();
void setupPumpBurstOffTime();
void irrigateIfNeeded();
void pumpOn();
void pumpOff();

void setPumpMode(char* msg);
void setPumpMode(int newMode);

void setThreshold(char* msg);
void setThreshold(int newThreshold);
void setThresholdToCurrent();
int getThreshold();
void setThresholdIsSetEEPROMFlag();

void setPumpBurstOnTime(char* msg);
void setPumpBurstOnTime(long newPumpBurstOnTime);
long getPumpBurstOnTime();
void setPumpBurstOnTimeIsSetEEPROMFlag();
void removePumpBurstOnTimeEEPROMIsSetFlag();

void setPumpBurstOffTime(char* msg);
void setPumpBurstOffTime(long newPumpBurstOffTime);
long getPumpBurstOffTime();
void setPumpBurstOffTimeIsSetEEPROMFlag();
void removePumpBurstOffTimeEEPROMIsSetFlag();


void removeThresholdEEPROMIsSetFlag();
void restoreDefaultThreshold();
void restoreDefaultIrrigationSettings();
void restoreDefaultPumpBurstOnTime();
void restoreDefaultPumpBurstOffTime();
#endif
/* IRRIGATION_H_ */
