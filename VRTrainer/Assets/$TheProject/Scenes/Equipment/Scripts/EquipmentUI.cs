using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EquipmentUI : MonoBehaviour
{
    static EquipmentUI instance;

    private float workPressure = 0;
    private float leakSpeed = 0;

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
        totalUI.CreateDoubleInputElement("Рабочее давление", 0, setWorkPressure);
        totalUI.CreateDoubleInputElement("Скорость стравливания МПа/с", 0, setWorkPressure);
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
