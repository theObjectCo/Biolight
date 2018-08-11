
#pragma once

#include <SparkFun_ADXL345.h>
#include <Vector3.h>

class Imu
{
public:
	Imu(int Cs); //constructor, Cs: PIN number
	Vector3 getAcceleration();

private:
	ADXL345 m_adxl;
	Vector3 m_accel;
};