using System;
using UnityEngine;

public class Clock : MonoBehaviour
{

    const float hoursToDegrees = -30, minutesToDegrees = -6f, secondsToDegrees = -6f;

    [SerializeField]
    Transform hoursPivot = default, minutesPivot = default, secondsPivot = default;

    [SerializeField]
    bool smoothHands = false;

    void Update() {
        if(smoothHands) {
            TimeSpan time = DateTime.Now.TimeOfDay;
            hoursPivot.localRotation = 
                Quaternion.Euler(0, 0, hoursToDegrees * (float)time.TotalHours);
            minutesPivot.localRotation = 
                Quaternion.Euler(0, 0, minutesToDegrees * (float)time.TotalMinutes);
            secondsPivot.localRotation = 
                Quaternion.Euler(0, 0, secondsToDegrees * (float)time.TotalSeconds);
        } else {
            var time = DateTime.Now;
            hoursPivot.localRotation = 
                Quaternion.Euler(0, 0, hoursToDegrees * time.Hour);
            minutesPivot.localRotation = 
                Quaternion.Euler(0, 0, minutesToDegrees * time.Minute);
            secondsPivot.localRotation = 
                Quaternion.Euler(0, 0, secondsToDegrees * time.Second);

        }
        

    }
}
