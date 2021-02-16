using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EquipmentUI : MonoBehaviour
{
    static EquipmentUI instance;

    private float workPressure = 29.5f;
    private float leakSpeed = 0;
    private float reserveSignalLevel = 5;
    private bool whistleDefect = false;
    private bool reducerDefect = false;

    public ValveInteraction valve;
    public Arrow arrow;
    public float reducerPressure = 0;

    private bool whistleActive = false;
    private bool reducerSoundActive = false;

    public AudioSource reducerAudio;
    public AudioSource whistleHighAudio;
    public AudioSource whistleLowAudio;

    public AudioSource valveOpendedLowAudio;
    public AudioSource valveClosedLowAudio;

    EquipmentUI() : base()
    {
        instance = this;
    }

    static public void InitUI(TotalUI totalUI)
    {
        totalUI.CreateTextElement("Экипировка");
        if (instance)
        {
            instance.InitExUI(totalUI);
        }
        else
        {
            totalUI.CreateButtonElement("Загрузить сцену", () => { SceneManager.LoadScene("Equipment"); });
        }
    }

    void InitExUI(TotalUI totalUI)
    {
        totalUI.CreateButtonElement("Перезагрузить сцену", () => { SceneManager.LoadScene("Equipment"); });
        totalUI.CreateDoubleInputElement("Рабочее давление", 29.5, setWorkPressure);
        totalUI.CreateDoubleInputElement("Скорость утечки МПа/с", 0, setLeakPressure);
        totalUI.CreateDoubleInputElement("Cигнал резерва МПа", 5, setReserveSignalLevel);
        totalUI.CreateToggleElement("Неисправность свистка", false, setWhistleDefect);
        totalUI.CreateToggleElement("Неисправность редуктора", false, setReducerDefect);
    }

    void setReducerDefect(bool value)
    {
        reducerDefect = value;
    }

    void setWhistleDefect(bool value)
    {
        whistleDefect = value;
    }

    void setReserveSignalLevel(string value)
    {
        reserveSignalLevel = (float)System.Convert.ToDouble(value);
    }

    void setLeakPressure(string value)
    {
        leakSpeed = (float)System.Convert.ToDouble(value);
    }

    void setWorkPressure(string value)
    {
        workPressure = (float)System.Convert.ToDouble(value);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private bool prevValveState = false;

    // Update is called once per frame
    void Update()
    {
        if (!prevValveState && valve.valveIsOpened)
        {
            valveOpendedLowAudio.Play();
        }
        if (prevValveState && !valve.valveIsOpened)
        {
            valveClosedLowAudio.Play();
        }
        prevValveState = valve.valveIsOpened;
        if (valve.valveIsOpened)
        {
            reducerPressure = workPressure;
        } else
        {
            workPressure -= leakSpeed * Time.deltaTime;
            reducerPressure -= reducerPressure * 0.1f * Time.deltaTime;
            if (reducerPressure > 0.6f * reserveSignalLevel && reducerPressure < reserveSignalLevel && !whistleDefect)
            {
                if (!whistleActive)
                {
                    whistleHighAudio.Play();
                    whistleActive = true;
                }
            }
            if (whistleActive)
            {
                if (reducerPressure > reserveSignalLevel)
                {
                    whistleHighAudio.Stop();
                    whistleActive = false;
                } else if (reducerPressure < 0.6f * reserveSignalLevel)
                {
                    whistleHighAudio.Stop();
                    whistleActive = false;
                    whistleLowAudio.Play();
                }
            }
        }
        if (reducerPressure > reserveSignalLevel && reducerDefect)
        {
            if (!reducerSoundActive)
            {
                reducerSoundActive = true;
                //Debug.Log("Редуктор застучал");
                reducerAudio.Play();
            }
        } else
        {
            if (reducerSoundActive)
            {
                reducerSoundActive = false;
                //Debug.Log("Редуктор перестал стучать");
                reducerAudio.Stop();
            }
        }
        arrow.value = reducerPressure;
    }
}
