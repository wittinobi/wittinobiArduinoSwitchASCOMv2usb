/*
 Name:		wittinobiArduinoSwitchASCOMv2usbINO.ino
 Created:	26.06.2022 23:51:46
 Author:	Tobias Wittmann (wittinobi)
*/

int CurrentStatusRelay0 = 0;
int CurrentStatusRelay1 = 0;
int CurrentStatusRelay2 = 0;
int CurrentStatusRelay3 = 0;
int CurrentStatusRelay4 = 0;
int CurrentStatusRelay5 = 0;
int CurrentStatusRelay6 = 0;
int CurrentStatusRelay7 = 0;

const int GPIO_PIN_NUMBER_4 = 4;
const int GPIO_PIN_NUMBER_5 = 5;
const int GPIO_PIN_NUMBER_6 = 6;
const int GPIO_PIN_NUMBER_7 = 7;
const int GPIO_PIN_NUMBER_8 = 8;
const int GPIO_PIN_NUMBER_9 = 9;
const int GPIO_PIN_NUMBER_10 = 10;
const int GPIO_PIN_NUMBER_11 = 11;

// the setup function runs once when you press reset or power the board
void setup()
{
    pinMode(GPIO_PIN_NUMBER_4, OUTPUT);
    pinMode(GPIO_PIN_NUMBER_5, OUTPUT);
    pinMode(GPIO_PIN_NUMBER_6, OUTPUT);
    pinMode(GPIO_PIN_NUMBER_7, OUTPUT);
    pinMode(GPIO_PIN_NUMBER_8, OUTPUT);
    pinMode(GPIO_PIN_NUMBER_9, OUTPUT);
    pinMode(GPIO_PIN_NUMBER_10, OUTPUT);
    pinMode(GPIO_PIN_NUMBER_11, OUTPUT);

    digitalWrite(GPIO_PIN_NUMBER_4, HIGH);
    digitalWrite(GPIO_PIN_NUMBER_5, HIGH);
    digitalWrite(GPIO_PIN_NUMBER_6, HIGH);
    digitalWrite(GPIO_PIN_NUMBER_7, HIGH);
    digitalWrite(GPIO_PIN_NUMBER_8, HIGH);
    digitalWrite(GPIO_PIN_NUMBER_9, HIGH);
    digitalWrite(GPIO_PIN_NUMBER_10, HIGH);
    digitalWrite(GPIO_PIN_NUMBER_11, HIGH);

    Serial.begin(9600);
    Serial.flush();
}

// the loop function runs over and over again until power down or reset
void loop()
{
    String cmd;

    if (Serial.available() > 0) {
        cmd = Serial.readStringUntil('#');
        if (cmd == "GETSTATUSRELAY0") {
            Serial.print(CurrentStatusRelay0);
            Serial.println("#");
        }
        else if (cmd == "SETSTATUSRELAY0_0") SetStatusRelay0Off();
        else if (cmd == "SETSTATUSRELAY0_1") SetStatusRelay0On();
        else if (cmd == "GETSTATUSRELAY1") {
            Serial.print(CurrentStatusRelay1);
            Serial.println("#");
        }
        else if (cmd == "SETSTATUSRELAY1_0") SetStatusRelay1Off();
        else if (cmd == "SETSTATUSRELAY1_1") SetStatusRelay1On();
        else if (cmd == "GETSTATUSRELAY2") {
            Serial.print(CurrentStatusRelay2);
            Serial.println("#");
        }
        else if (cmd == "SETSTATUSRELAY2_0") SetStatusRelay2Off();
        else if (cmd == "SETSTATUSRELAY2_1") SetStatusRelay2On();
        else if (cmd == "GETSTATUSRELAY3") {
            Serial.print(CurrentStatusRelay3);
            Serial.println("#");
        }
        else if (cmd == "SETSTATUSRELAY3_0") SetStatusRelay3Off();
        else if (cmd == "SETSTATUSRELAY3_1") SetStatusRelay3On();
        else if (cmd == "GETSTATUSRELAY4") {
            Serial.print(CurrentStatusRelay4);
            Serial.println("#");
        }
        else if (cmd == "SETSTATUSRELAY4_0") SetStatusRelay4Off();
        else if (cmd == "SETSTATUSRELAY4_1") SetStatusRelay4On();
        else if (cmd == "GETSTATUSRELAY5") {
            Serial.print(CurrentStatusRelay5);
            Serial.println("#");
        }
        else if (cmd == "SETSTATUSRELAY5_0") SetStatusRelay5Off();
        else if (cmd == "SETSTATUSRELAY5_1") SetStatusRelay5On();
        else if (cmd == "GETSTATUSRELAY6") {
            Serial.print(CurrentStatusRelay6);
            Serial.println("#");
        }
        else if (cmd == "SETSTATUSRELAY6_0") SetStatusRelay6Off();
        else if (cmd == "SETSTATUSRELAY6_1") SetStatusRelay6On();
        else if (cmd == "GETSTATUSRELAY7") {
            Serial.print(CurrentStatusRelay7);
            Serial.println("#");
        }
        else if (cmd == "SETSTATUSRELAY7_0") SetStatusRelay7Off();
        else if (cmd == "SETSTATUSRELAY7_1") SetStatusRelay7On();
    }
}

//switch relay1 off
void SetStatusRelay0Off() {
    digitalWrite(GPIO_PIN_NUMBER_4, HIGH);
    CurrentStatusRelay0 = 0;
    Serial.print(CurrentStatusRelay0);
    Serial.println("#");
}

//switch relay1 on
void SetStatusRelay0On() {
    digitalWrite(GPIO_PIN_NUMBER_4, LOW);
    CurrentStatusRelay0 = 1;
    Serial.print(CurrentStatusRelay0);
    Serial.println("#");
}

//switch relay2 off
void SetStatusRelay1Off() {
    digitalWrite(GPIO_PIN_NUMBER_5, HIGH);
    CurrentStatusRelay1 = 0;
    Serial.print(CurrentStatusRelay0);
    Serial.println("#");
}

//switch relay2 on
void SetStatusRelay1On() {
    digitalWrite(GPIO_PIN_NUMBER_5, LOW);
    CurrentStatusRelay1 = 1;
    Serial.print(CurrentStatusRelay0);
    Serial.println("#");
}
//switch relay3 off
void SetStatusRelay2Off() {
    digitalWrite(GPIO_PIN_NUMBER_6, HIGH);
    CurrentStatusRelay2 = 0;
    Serial.print(CurrentStatusRelay0);
    Serial.println("#");
}

//switch relay3 on
void SetStatusRelay2On() {
    digitalWrite(GPIO_PIN_NUMBER_6, LOW);
    CurrentStatusRelay2 = 1;
    Serial.print(CurrentStatusRelay0);
    Serial.println("#");
}

//switch relay4 off
void SetStatusRelay3Off() {
    digitalWrite(GPIO_PIN_NUMBER_7, HIGH);
    CurrentStatusRelay3 = 0;
    Serial.print(CurrentStatusRelay0);
    Serial.println("#");
}

//switch relay4 on
void SetStatusRelay3On() {
    digitalWrite(GPIO_PIN_NUMBER_7, LOW);
    CurrentStatusRelay3 = 1;
    Serial.print(CurrentStatusRelay0);
    Serial.println("#");
}

//switch relay5 off
void SetStatusRelay4Off() {
    digitalWrite(GPIO_PIN_NUMBER_8, HIGH);
    CurrentStatusRelay4 = 0;
    Serial.print(CurrentStatusRelay0);
    Serial.println("#");
}

//switch relay5 on
void SetStatusRelay4On() {
    digitalWrite(GPIO_PIN_NUMBER_8, LOW);
    CurrentStatusRelay4 = 1;
    Serial.print(CurrentStatusRelay0);
    Serial.println("#");
}

//switch relay6 off
void SetStatusRelay5Off() {
    digitalWrite(GPIO_PIN_NUMBER_9, HIGH);
    CurrentStatusRelay5 = 0;
    Serial.print(CurrentStatusRelay0);
    Serial.println("#");
}

//switch relay6 on
void SetStatusRelay5On() {
    digitalWrite(GPIO_PIN_NUMBER_9, LOW);
    CurrentStatusRelay5 = 1;
    Serial.print(CurrentStatusRelay0);
    Serial.println("#");
}

//switch relay7 off
void SetStatusRelay6Off() {
    digitalWrite(GPIO_PIN_NUMBER_10, HIGH);
    CurrentStatusRelay6 = 0;
    Serial.print(CurrentStatusRelay0);
    Serial.println("#");
}

//switch relay7 on
void SetStatusRelay6On() {
    digitalWrite(GPIO_PIN_NUMBER_10, LOW);
    CurrentStatusRelay6 = 1;
    Serial.print(CurrentStatusRelay0);
    Serial.println("#");
}

//switch relay8 off
void SetStatusRelay7Off() {
    digitalWrite(GPIO_PIN_NUMBER_11, HIGH);
    CurrentStatusRelay7 = 0;
    Serial.print(CurrentStatusRelay0);
    Serial.println("#");
}

//switch relay8 on
void SetStatusRelay7On() {
    digitalWrite(GPIO_PIN_NUMBER_11, LOW);
    CurrentStatusRelay7 = 1;
    Serial.print(CurrentStatusRelay0);
    Serial.println("#");
}
