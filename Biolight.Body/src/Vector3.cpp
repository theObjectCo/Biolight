#include "Vector3.h"

void Vector3::print(int id)
{
	//pack into JSON
	Serial.print("Id: ");
	Serial.print(id);
	Serial.print(" Acc X: ");
	Serial.print(x);
	Serial.print(" Acc Y: ");
	Serial.print(y);
	Serial.print(" Acc Z: ");
	Serial.println(z);
}