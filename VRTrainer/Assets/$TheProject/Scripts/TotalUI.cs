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

    void Start()
    {
        if (SceneManager.GetActiveScene().name == "SandBox")
        {
            InitSandBox(true);
            InitEquipment(false);
            InitPitching(false);
        } else if (SceneManager.GetActiveScene().name == "Equipment")
        {
            InitEquipment(true);
            InitSandBox(false);
            InitPitching(false);
        } else
        {
            InitPitching(true);
            InitEquipment(false);
            InitSandBox(false);
        }
    }

    private void CreateTextElement(string text)
    {
        var title = Instantiate(textPrefab.gameObject, transform, false) as GameObject;
        title.GetComponent<Text>().text = text;
    }

    private void CreateButtonElement(string text, UnityAction action)
    {
        var button = Instantiate(buttonPrefab.gameObject, transform, false) as GameObject;
        button.GetComponentInChildren<Text>().text = text;
        button.GetComponent<Button>().onClick.AddListener(action);
    }

    private void InitSandBox(bool full)
    {
        CreateTextElement("Песочница");
        if (full)
        {
            CreateButtonElement("Перезагрузить сцену", () => { SceneManager.LoadScene("SandBox"); });
        }
        else
        {
            CreateButtonElement("Загрузить сцену", () => { SceneManager.LoadScene("SandBox"); });
        }
        if (full)
        {
            CreateButtonElement("Песочная кнопка", () => { this.Invoke("Test", 0); });
        }
    }

    private void InitEquipment(bool full)
    {
        CreateTextElement("Экипировка");
        if (full)
        {
            CreateButtonElement("Перезагрузить сцену", () => { SceneManager.LoadScene("Equipment"); });
        }
        else
        {
            CreateButtonElement("Загрузить сцену", () => { SceneManager.LoadScene("Equipment"); });
        }
        if (full)
        {
            CreateButtonElement("Экипировочная кнопка", () => { this.Invoke("Test", 0); });
        }
    }

    private void InitPitching(bool full)
    {
        CreateTextElement("Качка");
        if (full)
        {
            CreateButtonElement("Перезагрузить сцену", () => { SceneManager.LoadScene("Pitching"); });
        }
        else
        {
            CreateButtonElement("Загрузить сцену", () => { SceneManager.LoadScene("Pitching"); });
        }
        if (full)
        {
            CreateButtonElement("Качковая кнопка", () => { this.Invoke("Test", 0); });
        }
    }

    private void Test()
    {
        Debug.Log("Test Test");
    }

    void Update()
    {
        
    }
}
