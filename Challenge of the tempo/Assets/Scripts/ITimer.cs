 
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface ITimer
{
    float SetTimeValue(float value);
    string GetTimerText();

    string DisplayTime(float timeToDisplay);


}

public class DisplayTimer: ITimer
{
    public Text timerText;
    public float timevalue;
    public DisplayTimer(Text timerText)
    {
        this.timerText = timerText;

    }
     public string GetTimerText()
    {
        return timerText.text;
    }
    public float SetTimeValue(float value)
    {
        timevalue = value;
        return timevalue;
    }

    public string DisplayTime(float timeToDisplay)
    {
        if (timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);//round timer to minutes
        float seconds = Mathf.FloorToInt(timeToDisplay % 60); //round timer to seconds by using modula

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);//the format which the time will be displayed

        return timerText.text;
    }

}
