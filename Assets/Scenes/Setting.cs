using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Setting : MonoBehaviour
{
    public GameObject Panel; 

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Active();
        }
    }

    public void Active()
    {
        if (Panel.activeSelf == false)
        {
            Panel.SetActive(true);
        }
        else
        {
            Panel.SetActive(false);
        }
    }
}
