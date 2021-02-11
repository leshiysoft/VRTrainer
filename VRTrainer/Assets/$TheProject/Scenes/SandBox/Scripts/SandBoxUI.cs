using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class SandBoxUI : MonoBehaviour
{

    public GameObject K_Tools;
    public GameObject K_Water;

    public GameObject Y_Tools;
    public GameObject Y_Water;

    public GameObject T_Tools;
    public GameObject T_Water;

    public GameObject H_Tools;
    public GameObject H_Water;


    static SandBoxUI instance;

    UnityAction<bool> theToggles;


    SandBoxUI() : base()
    {
        instance = this;
    }

    static public void InitUI(TotalUI totalUI)
    {
        totalUI.CreateTextElement("Песочница");
        if (instance)
        {
            instance.InitExUI(totalUI);
        }
        else
        {
            totalUI.CreateButtonElement("Загрузить сцену", () => { SceneManager.LoadScene("SandBox"); });
        }
    }

    void InitExUI(TotalUI totalUI)
    {
        totalUI.CreateButtonElement("Перезагрузить сцену", () => { SceneManager.LoadScene("SandBox"); });
        totalUI.CreateTwiceToggleElement("К-набор", false, Activate_K_Tools, "Поток", false, Activate_K_Water);
        totalUI.CreateTwiceToggleElement("Y-набор", false, Activate_Y_Tools, "Поток", false, Activate_Y_Water);
        totalUI.CreateTwiceToggleElement("T-набор", false, Activate_T_Tools, "Поток", false, Activate_T_Water);
        totalUI.CreateTwiceToggleElement("H-набор", false, Activate_H_Tools, "Поток", false, Activate_H_Water);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Activate_K_Tools(bool active)
    {
        K_Tools.SetActive(active);
    }

    public void Activate_K_Water(bool active)
    {
        K_Water.SetActive(active);
    }


    public void Activate_Y_Tools(bool active)
    {
        Y_Tools.SetActive(active);
    }
    public void Activate_Y_Water(bool active)
    {
        Y_Water.SetActive(active);
    }


    public void Activate_T_Tools(bool active)
    {
        T_Tools.SetActive(active);
    }
    public void Activate_T_Water(bool active)
    {
        T_Water.SetActive(active);
    }


    public void Activate_H_Tools(bool active)
    {
        H_Tools.SetActive(active);
    }
    public void Activate_H_Water(bool active)
    {
        H_Water.SetActive(active);
    }
}
