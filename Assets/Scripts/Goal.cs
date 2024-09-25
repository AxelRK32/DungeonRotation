using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    int currentLvl = 1;
    public void Start()
    {
        Debug.Log("Goal start");
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other + " entered goal");
        if (other.name.Equals("Character"))
        {
            currentLvl ++;
            SceneManager.LoadScene("Level" + currentLvl.ToString());
        }
    }
}
