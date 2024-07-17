using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelManager : MonoBehaviour
{
    public GameObject panelPrefab; // Prefab untuk panel utama
    public GameObject stepPrefab; // Prefab untuk sub-panel (step)
    public Transform panelParent; // Parent untuk panel utama yang dibuat
    public int numberOfPanels = 5; // Jumlah panel utama yang ingin dibuat
    private List<GameObject> panels = new List<GameObject>(); // List untuk menyimpan panel utama yang dibuat

    // List untuk menyimpan jumlah step untuk setiap panel utama
    public List<int> stepsPerPanel;

    // List untuk menyimpan properti button dan image untuk setiap step
    public List<Sprite> buttonSprites;
    public List<Sprite> imageSprites;

    void Start()
    {
        // Buat panel utama secara dinamis berdasarkan jumlah yang ditentukan
        for (int i = 0; i < numberOfPanels; i++)
        {
            GameObject newPanel = Instantiate(panelPrefab, panelParent);
            newPanel.name = "Panel" + (i + 1);
            panels.Add(newPanel);

            // Buat step di dalam panel utama
            int numberOfSteps = (i < stepsPerPanel.Count) ? stepsPerPanel[i] : 0;
            for (int j = 0; j < numberOfSteps; j++)
            {
                GameObject newStep = Instantiate(stepPrefab, newPanel.transform);
                newStep.name = "Step" + (j + 1);

                // Atur properti button dan image di setiap step
                SetStepProperties(newStep, j);
            }

            // Nonaktifkan panel utama setelah diatur
            newPanel.SetActive(false);
        }

        // Aktifkan panel utama pertama sebagai default
        if (panels.Count > 0)
        {
            panels[0].SetActive(true);
        }
    }

    void SetStepProperties(GameObject step, int index)
    {
        Button button = step.GetComponentInChildren<Button>();
        Image buttonImage = button?.GetComponent<Image>();
        Image childImage = null;

        // Cari komponen Image yang merupakan child dari step dan bukan milik Button
        foreach (Image img in step.GetComponentsInChildren<Image>())
        {
            if (img.gameObject != button.gameObject && img.transform.parent == step.transform)
            {
                childImage = img;
                break;
            }
        }

        if (buttonImage != null && index < buttonSprites.Count)
        {
            buttonImage.sprite = buttonSprites[index];
        }

        if (childImage != null && index < imageSprites.Count)
        {
            childImage.sprite = imageSprites[index];
            Debug.Log("Image set for Step" + (index + 1) + ": " + imageSprites[index].name);
        }
    }

    public void ShowPanel(int index)
    {
        // Nonaktifkan semua panel utama terlebih dahulu
        panels.ForEach(panel => panel.SetActive(false));

        // Aktifkan panel utama yang dipilih berdasarkan index
        if (index >= 0 && index < panels.Count)
        {
            panels[index].SetActive(true);
        }
    }
}