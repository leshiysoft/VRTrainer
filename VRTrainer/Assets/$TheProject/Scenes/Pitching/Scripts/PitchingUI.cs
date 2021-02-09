using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PitchingUI : MonoBehaviour
{

    static PitchingUI instance;

    UnityAction<bool> theToggles;


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
        totalUI.CreateButtonElement("Качковая кнопка", () => { this.Invoke("Test", 0); });

        theToggles += Toggle;
        totalUI.CreateToggleElement("Ткни меня", true, theToggles);
    }

    private void Toggle(bool isActive)
    {
        Debug.Log("toggled");
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
