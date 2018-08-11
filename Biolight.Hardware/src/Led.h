#pragma once
#include <Arduino.h>

class Led
{
public:
	Led(const int ledPin, const int blinkDelay, const int onState);
	virtual ~Led() = default;

	void switchOff();
	void switchOn();
	void blink(const int howMany);

private:
	const int m_ledPin;
	const int m_blinkDelay;
	const int m_onState;
};