#include "Imu.h"
#include <Arduino.h>
//klasa obiekt
Imu imu1(8);
Imu imu2(9);
Vector3 acc;

void setup()
{
	Serial.begin(9600);
}

void loop()
{
	acc = imu1.getAcceleration();
	acc.print(1);
	acc = imu2.getAcceleration();
	acc.print(2);

	delay(1000);
}