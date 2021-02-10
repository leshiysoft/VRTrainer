using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class TotalUI : MonoBehaviour
{
    public GameObject textPrefab;
    public GameObject buttonPrefab;
    public GameObject togglePrefab;
    public GameObject inputPrefab;
    public GameObject doubleInputPrefab;

    void Start()
    {
        if (SceneManager.GetActiveScene().name == "SandBox")
        {
            SandBoxUI.InitUI(this);
            EquipmentUI.InitUI(this);
            PitchingUI.InitUI(this);
        } else if (SceneManager.GetActiveScene().name == "Equipment")
        {
            EquipmentUI.InitUI(this);
            SandBoxUI.InitUI(this);
            PitchingUI.InitUI(this);
        } else
        {
            PitchingUI.InitUI(this);
            EquipmentUI.InitUI(this);
            SandBoxUI.InitUI(this);
        }
    }

    public void CreateInputElement(string text, UnityAction<string> action)
    {
        var input = Instantiate(inputPrefab.gameObject, transform, false) as GameObject;
        input.GetComponentInChildren<Text>().text = text;
        input.GetComponent<InputField>().onValueChanged.AddListener(action);
    }

    public GameObject CreateDoubleInputElement(string text, double value, UnityAction<string> action)
    {
        var input = Instantiate(doubleInputPrefab.gameObject, transform, false) as GameObject;
        input.GetComponentInChildren<Text>().text = text;
        input.GetComponentInChildren<InputField>().text = value.ToString();
        input.GetComponentInChildren<InputField>().onValueChanged.AddListener(action);
        return input;
    }

    public void CreateTextElement(string text)
    {
        var title = Instantiate(textPrefab.gameObject, transform, false) as GameObject;
        title.GetComponent<Text>().text = text;
    }

    public void CreateButtonElement(string text, UnityAction action)
    {
        var button = Instantiate(buttonPrefab.gameObject, transform, false) as GameObject;
        button.GetComponentInChildren<Text>().text = text;
        button.GetComponent<Button>().onClick.AddListener(action);
    }

    public void CreateToggleElement(string text, bool isActive, UnityAction<bool> action)
    {
        var toggle = Instantiate(togglePrefab.gameObject, transform, false) as GameObject;
        toggle.GetComponentInChildren<Text>().text = text;
        toggle.GetComponent<Toggle>().onValueChanged.AddListener(action);
    }

    void Update()
    {
        
    }
}
