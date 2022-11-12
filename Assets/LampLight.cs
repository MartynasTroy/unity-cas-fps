using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampLight : MonoBehaviour
{
    public Light pointLight;

    public float lightIntensity;
    public float avgOnLength = 5;
    public float onRange = 2;
    public float avgOffLength = 0.5f;
    public float offRange = 0.2f;
    private float timer;

    bool isOn = true;

    void Start()
    {
        timer = GenerateRandomNumber(avgOnLength - onRange, avgOnLength + onRange);
    }


    void Update()
    {
        if (timer <= 0 && isOn)
        {
            timer = GenerateRandomNumber(avgOffLength - offRange, avgOffLength + offRange);
            pointLight.intensity = 0;
            isOn = false;
        }
        if (timer <= 0 && isOn == false)
        {
            timer = GenerateRandomNumber(avgOnLength - onRange, avgOnLength + onRange);
            pointLight.intensity = lightIntensity;
            isOn = true;
        }
        timer -= Time.deltaTime;
    }
    public float GenerateRandomNumber(float x, float y)
    {
        float flt = Random.Range(x, y);
        return (flt);
    }
}
