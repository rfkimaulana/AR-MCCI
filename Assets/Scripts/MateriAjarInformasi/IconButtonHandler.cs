using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class IconButtonHandler : MonoBehaviour
{
    public GameObject[] panels; // Array untuk panel
    public Button[] buttons; // Array untuk button

    void Start()
    {
        // Pastikan semua panel tidak aktif pada awalnya
        foreach (GameObject panel in panels)
        {
            panel.SetActive(false);
        }

        // Tambahkan listener untuk setiap button
        for (int i = 0; i < buttons.Length; i++)
        {
            int index = i; // Perlu variabel lokal untuk menghindari masalah dengan closure
            buttons[i].onClick.AddListener(() => OnIconButtonClick(index));
        }
    }

    public void OnIconButtonClick(int index)
    {
        // Nonaktifkan semua panel terlebih dahulu
        foreach (GameObject panel in panels)
        {
            panel.SetActive(false);
        }

        // Aktifkan panel berdasarkan indeks button yang diklik
        if (index >= 0 && index < panels.Length)
        {
            panels[index].SetActive(true);
        }
        else
        {
            Debug.LogError("Index out of range!");
        }
    }
}