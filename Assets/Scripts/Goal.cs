using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    int currentLvl = 1;
    Rotate rotate;
    public void Start()
    {
        Debug.Log("Goal start");
        //rotate = GetComponent<Rotate>();
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other + " entered goal");
        if (other.name.Equals("Character"))
        {
            currentLvl ++;
            SceneManager.LoadScene("Level" + currentLvl.ToString());
            Camera.main.GetComponent<Rotate>().ResetRotation();
        }
    }
}
