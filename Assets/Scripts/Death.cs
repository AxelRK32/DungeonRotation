using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{

    // Update is called once per frame
   private void Update()
    {
        if (Mathf.Abs(transform.position.x) > 10 || Mathf.Abs(transform.position.y) > 10)
        {
            Debug.Log("Player dead");
            Dead();
        }
    }

    public void Dead()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Camera.main.GetComponent<Rotate>().ResetRotation();

    }
}

