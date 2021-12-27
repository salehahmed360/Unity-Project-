using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUnityService
{
    float GetDeltaTime();
    float GetAxis(string axisName);
}

public class UnityService : IUnityService
{

    public float GetDeltaTime()
    {
        return Time.deltaTime;
    }
    public float GetAxis(string axisName)
    {
        return Input.GetAxis(axisName);
    }
}
