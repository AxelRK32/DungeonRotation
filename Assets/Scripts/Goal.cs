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
    public void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log(other + " entered goal");
        if (other.gameObject.CompareTag("Player"))
        {
            currentLvl ++;
            SceneManager.LoadScene("Level" + currentLvl.ToString());
            Camera.main.GetComponent<Rotate>().ResetRotation();
        }
    }
}
