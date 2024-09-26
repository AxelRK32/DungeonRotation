using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    string currentScene;
    string nextScene;
    int currentLvl = 1;
    public void Start()
    {
        Debug.Log("Goal start");
        currentScene = SceneManager.GetActiveScene().name;
        Debug.Log("Current scene: " + currentScene);
    }
    public void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log(other + " entered goal");
        if (other.gameObject.CompareTag("Player"))
        {
            currentLvl ++;
            nextScene = currentScene.Split("l")[0];
            currentLvl = Int32.Parse(currentScene.Split("l")[1]) + 1;
            Debug.Log("Next level: " + nextScene + " current level: " + currentLvl.ToString());
            nextScene += "l" + currentLvl.ToString();
            Debug.Log("Next scene will be: " + nextScene);
            SceneManager.LoadScene(nextScene);
            Camera.main.GetComponent<Rotate>().ResetRotation();
        }
    }
}
