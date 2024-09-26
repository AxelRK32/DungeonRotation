using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    Vector2 startPos = new Vector2(-8, -8);

    // Update is called once per frame
   private void Update()
    {
        if (Mathf.Abs(transform.position.x) > 10 || Mathf.Abs(transform.position.y) > 10)
        {
            Debug.Log("Player dead");
            transform.position = startPos;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            Camera.main.GetComponent<Rotate>().ResetRotation();
        }
    }

    public void Dead()
    {
        transform.position = startPos;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Camera.main.GetComponent<Rotate>().ResetRotation();

    }
}

