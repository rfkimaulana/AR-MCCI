using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelTester : MonoBehaviour
{
    public PanelManager panelManager;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            panelManager.ShowPanel(0); // Tampilkan panel pertama
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            panelManager.ShowPanel(1); // Tampilkan panel kedua
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            panelManager.ShowPanel(2); // Tampilkan panel ketiga
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            panelManager.ShowPanel(3); // Tampilkan panel keempat
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            panelManager.ShowPanel(4); // Tampilkan panel kelima
        }
    }
}