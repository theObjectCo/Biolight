#include <Imu.h>

Imu::Imu(int Cs)
{
	m_adxl = ADXL345(Cs);
	m_adxl.powerOn();
	m_adxl.setSpiBit(0);
	m_adxl.setRangeSetting(8);
}

Vector3 Imu::getAcceleration()
{
	//opakowanie spierdoliny
	m_adxl.readAccel(&m_accel.x, &m_accel.y, &m_accel.z);
	return m_accel;

}