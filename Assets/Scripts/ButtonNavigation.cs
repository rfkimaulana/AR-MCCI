using UnityEngine;

public class ButtonNavigation : MonoBehaviour
{
    public GameObject[] objects; // Array untuk menyimpan referensi ke semua objek
    public GameObject backwardButton; // Referensi ke tombol Backward
    public GameObject forwardButton; // Referensi ke tombol Forward

    private int currentIndex = 0; // Indeks objek saat ini

    void Start()
    {
        // Pastikan semua objek dan referensi sudah diatur
        if (objects.Length == 0 || backwardButton == null || forwardButton == null)
        {
            Debug.LogError("Objects or navigation buttons are not set in " + gameObject.name);
            return;
        }

        // Atur listener untuk tombol Backward dan Forward
        backwardButton.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(OnBackwardButtonClicked);
        forwardButton.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(OnForwardButtonClicked);

        // Tampilkan objek pertama dan tombol Forward
        UpdateObjectVisibility();
    }

    void OnBackwardButtonClicked()
    {
        if (currentIndex > 0)
        {
            currentIndex--;
            UpdateObjectVisibility();
        }
    }

    void OnForwardButtonClicked()
    {
        if (currentIndex < objects.Length - 1)
        {
            currentIndex++;
            UpdateObjectVisibility();
        }
    }

    void UpdateObjectVisibility()
    {
        // Sembunyikan semua objek
        foreach (GameObject obj in objects)
        {
            obj.SetActive(false);
        }

        // Tampilkan objek saat ini
        objects[currentIndex].SetActive(true);

        // Atur visibilitas tombol Backward dan Forward
        backwardButton.SetActive(currentIndex > 0);
        forwardButton.SetActive(currentIndex < objects.Length - 1);
    }
}