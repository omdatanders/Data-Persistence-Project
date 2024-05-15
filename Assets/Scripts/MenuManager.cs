using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuManager : MonoBehaviour
{
    public TMP_InputField inputField;
    public TMP_Text highScore;

    public void Awake()
    {
    }

    public void Start()
    {
        PersistentData.Instance.LoadData();
        inputField.text = PersistentData.Instance.playerName;
        highScore.text = "Best Score: " + PersistentData.Instance.bestPlayer + " - " + PersistentData.Instance.bestScore;
    }

    public void StartGame()
    {
        SceneManager.LoadScene("main");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
