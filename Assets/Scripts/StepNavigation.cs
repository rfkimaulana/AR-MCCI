using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StepNavigation : MonoBehaviour
{
    public GameObject forwardButtonPrefab;
    public GameObject backwardButtonPrefab;
    public ButtonAnimasi buttonAnimasi; // Tambahkan referensi ke ButtonAnimasi

    private GameObject forwardButton;
    private GameObject backwardButton;

    private int currentStepIndex = 0;
    private List<GameObject> steps = new List<GameObject>();

    void Start()
    {
        // Inisialisasi langkah-langkah
        foreach (Transform child in transform)
        {
            steps.Add(child.gameObject);
            child.gameObject.SetActive(false);
        }

        if (steps.Count > 0)
        {
            steps[currentStepIndex].SetActive(true);
            SetupButtons();
        }
    }

    void SetupButtons()
    {
        if (forwardButton == null)
        {
            forwardButton = Instantiate(forwardButtonPrefab, transform);
            forwardButton.GetComponent<Button>().onClick.AddListener(GoToNextStep);
        }

        if (backwardButton == null)
        {
            backwardButton = Instantiate(backwardButtonPrefab, transform);
            backwardButton.GetComponent<Button>().onClick.AddListener(GoToPreviousStep);
        }

        UpdateButtonVisibility();
    }

    void UpdateButtonVisibility()
    {
        forwardButton.SetActive(currentStepIndex < steps.Count - 1);
        backwardButton.SetActive(currentStepIndex > 0);
    }

    void GoToNextStep()
    {
        if (currentStepIndex < steps.Count - 1)
        {
            steps[currentStepIndex].SetActive(false);
            currentStepIndex++;
            steps[currentStepIndex].SetActive(true);
            UpdateButtonVisibility();

            // Panggil metode OnForwardButtonClick dari ButtonAnimasi
            if (buttonAnimasi != null)
            {
                buttonAnimasi.OnForwardButtonClick();
            }
        }
    }

    void GoToPreviousStep()
    {
        if (currentStepIndex > 0)
        {
            steps[currentStepIndex].SetActive(false);
            currentStepIndex--;
            steps[currentStepIndex].SetActive(true);
            UpdateButtonVisibility();
        }
    }
}