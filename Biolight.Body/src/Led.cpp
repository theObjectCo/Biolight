#include "Led.h"

Led::Led(const int ledPin, const int blinkDelay, const int onState)
: m_ledPin(ledPin)
, m_blinkDelay(blinkDelay)
, m_onState(onState)
{
	pinMode(m_ledPin, OUTPUT);
}

void Led::switchOff()
{
	digitalWrite(m_ledPin, m_onState);
}
void Led::switchOn()
{
	digitalWrite(m_ledPin, !m_onState);
}
void Led::blink(const int howMany)
{
	for (int i = 0; i < howMany; i++)
	{
		switchOn();
		delay(m_blinkDelay);
		switchOff();
		delay(m_blinkDelay);
	}
}