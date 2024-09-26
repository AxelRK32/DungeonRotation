using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    Button start, exit;
    // Start is called before the first frame update
    void Start()
    {
        start = GetComponentsInChildren<Button>()[0];
        exit = GetComponentsInChildren<Button>()[1];

        start.onClick.AddListener(StartGame);
        exit.onClick.AddListener(ExitGame);
    }

    void StartGame()
    {
        SceneManager.LoadScene("Level1");
    }

    void ExitGame()
    {
        Debug.Log("Exiting game");
        Application.Quit();
    }
}
