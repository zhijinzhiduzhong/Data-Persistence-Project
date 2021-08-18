using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUI : MonoBehaviour
{
    private MainManagerX mainManagerX;
    public Text nameText;

    private void Start()
    {
        mainManagerX = MainManagerX.Instance;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        mainManagerX.SaveHighData();

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    public void ReadStringInput(string name)
    {
        nameText.text = name;
        mainManagerX.playerName = nameText.text;
        // print("Name: " + mainManagerX.playerName);
    }
}
