using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using System.IO;

public class ButtonManager : MonoBehaviour
{
    // Method untuk berpindah scene
    public void ChangeScene(string sceneName)
    {
        // Menggunakan SceneManager untuk memuat scene baru berdasarkan nama scene yang diberikan
        SceneManager.LoadScene(sceneName);
    }

    public void GoToUnduhMateri()
    {
        Application.OpenURL("https://drive.usercontent.google.com/download?id=1UGeti6CmcNbn1r2HVq6qujD90kLIIbCp&export=download&authuser=0&confirm=t&uuid=300e025b-6c05-485e-ad1e-fe14d5755d37&at=APZUnTXjJX4WtKnVzS1LiKcgoZ8t:1720197441621");
    }
}