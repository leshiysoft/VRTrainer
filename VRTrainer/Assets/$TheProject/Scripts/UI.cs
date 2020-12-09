using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{

    public GameObject mainPanel;
    public GameObject unwrapButton;

    public void Unwrap()
    {
        mainPanel.SetActive(true);
        unwrapButton.SetActive(false);
    }

    public void Wrap()
    {
        mainPanel.SetActive(false);
        unwrapButton.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        mainPanel.SetActive(false);
        unwrapButton.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
