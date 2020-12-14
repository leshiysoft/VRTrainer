using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SandBoxUI : MonoBehaviour
{

    public GameObject K_Tools;
    public GameObject Y_Tools;
    public GameObject T_Tools;
    public GameObject H_Tools;


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

    public void Activate_K_Tools()
    {
        K_Tools.SetActive(true);
    }

    public void Activate_Y_Tools()
    {
        Y_Tools.SetActive(true);
    }

    public void Activate_T_Tools()
    {
        T_Tools.SetActive(true);
    }

    public void Activate_H_Tools()
    {
        H_Tools.SetActive(true);
    }
}
