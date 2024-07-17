using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelController : MonoBehaviour
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
        // Tambahkan logika lain sesuai kebutuhan
    }
}