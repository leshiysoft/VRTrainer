using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PitchingUI : MonoBehaviour
{

    static PitchingUI instance;

    public GameObject scene;

    private GameObject xAmpl;
    private GameObject xFreq;
    private GameObject zAmpl;
    private GameObject zFreq;

    PitchingUI() : base()
    {
        instance = this;
    }

    static public void InitUI(TotalUI totalUI)
    {
        totalUI.CreateTextElement("Качка");
        if (instance)
        {
            instance.InitExUI(totalUI);
        }
        else
        {
            totalUI.CreateButtonElement("Загрузить сцену", () => { SceneManager.LoadScene("Pitching"); });
        }
    }

    void InitExUI(TotalUI totalUI)
    {
        totalUI.CreateButtonElement("Перезагрузить сцену", () => { SceneManager.LoadScene("Pitching"); });

        xAmpl = totalUI.CreateDoubleInputElement("X-Амплитуда", 0.0, changeXAmpl);
        xFreq = totalUI.CreateDoubleInputElement("X-Частота", 1.0, changeXFreq);
        zAmpl = totalUI.CreateDoubleInputElement("Z-Амплитуда", 0.0, changeZAmpl);
        zFreq = totalUI.CreateDoubleInputElement("Z-Частота", 1.3, changeZFreq);
        totalUI.CreateButtonElement("Сбросить значения", Reset);

    }

    private void Reset()
    {
        xAmpl.GetComponentInChildren<InputField>().text = "0,0";
        xFreq.GetComponentInChildren<InputField>().text = "1,0";
        zAmpl.GetComponentInChildren<InputField>().text = "0,0";
        zFreq.GetComponentInChildren<InputField>().text = "1,3";

        changeXAmpl("0,0");
        changeXFreq("1,0");
        changeZAmpl("0,0");
        changeZFreq("1,3");

    }

    private void changeXAmpl(string value)
    {
        scene.GetComponent<Pitching>().xAmplitude = (float)System.Convert.ToDouble(value);
    }

    private void changeXFreq(string value)
    {
        scene.GetComponent<Pitching>().xfreq = (float)System.Convert.ToDouble(value);
    }

    private void changeZAmpl(string value)
    {
        scene.GetComponent<Pitching>().zAmplitude = (float)System.Convert.ToDouble(value);
    }

    private void changeZFreq(string value)
    {
        scene.GetComponent<Pitching>().zfreq = (float)System.Convert.ToDouble(value);
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
