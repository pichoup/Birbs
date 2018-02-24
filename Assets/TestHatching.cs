using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestHatching : MonoBehaviour {
    public float coal;

    public float progress;

    public float temperature;
    public float humidity;

    public float roomTemp = 20f;
    public float coolingConstant = 0.001f;
    public float humidityConstant = 0.1f;

    public float multiplier = 2f;

    public float tempMin;
    public float tempMax;

    public float humidMin;
    public float humidMax;

    public Transform temp;
    public Transform humid;

    public Transform tempSlider;
    public Transform humidSlider;

    public Transform progressTransform;

    private void Start()
    {
        transform.GetChild(0).GetComponent<Birb>().SetBirbSpritesAndColours();
        temp.GetChild(1).GetComponent<RectTransform>().anchorMin = new Vector2(tempMin, 0f);
        temp.GetChild(1).GetComponent<RectTransform>().anchorMax = new Vector2(tempMax, .5f);
        humid.GetChild(1).GetComponent<RectTransform>().anchorMin = new Vector2(humidMin, 0f);
        humid.GetChild(1).GetComponent<RectTransform>().anchorMax = new Vector2(humidMax, .5f);
    }

    private void Update()
    {
        UpdateTemperature(Time.deltaTime);
        UpdateHumidity(Time.deltaTime);

        if (temperature <= tempMax * 100f && temperature >= tempMin * 100f)
            if (humidity <= humidMax * 100f && humidity >= humidMin * 100f)
            {
                progress += Time.deltaTime * 0.04f;
                if (progress >= 1)
                {
                    transform.GetChild(0).GetComponent<Birb>().hatched = true;
                    transform.GetChild(0).GetComponent<Birb>().SetBirbSpritesAndColours();
                }
            }

        progressTransform.localScale = new Vector2(progress, 1f);
    }

    public void UpdateTemperature(float time)
    {
        float usedCoal = 0f;

        if (coal >= time)
        {
            usedCoal = time;
            coal = coal - time;
        }
        else
        {
            usedCoal = coal;
            coal = 0f;
        }

        temperature += usedCoal * time * multiplier;

        //Newton's cooling equation
        temperature = roomTemp + ((temperature - roomTemp) * Mathf.Exp(-coolingConstant * time));

        tempSlider.localScale = new Vector2(temperature / 100f, 1);
    }

    public void UpdateHumidity(float time)
    {
        humidity -= humidity * temperature * humidityConstant * time;
        humidSlider.localScale = new Vector2(humidity / 100f, 1);
    }

    public void AddCoal()
    {
        coal += 1f;
    }

    public void AddMist()
    {
        humidity += 5f;
        temperature = temperature >= 5f ? temperature - 5f : 0f;
    }
}
