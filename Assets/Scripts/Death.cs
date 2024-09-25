using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    Vector2 startPos = new Vector2(0, 0);

    // Update is called once per frame
   private void Update()
    {
        if (Mathf.Abs(transform.position.x) > 10 || Mathf.Abs(transform.position.y) > 10)
        {
            Debug.Log("Player dead");
            transform.position = startPos;
            Camera.main.GetComponent<Rotate>().ResetRotation();
        }
    }

        public void Dead()
    {
        Vector2 startPos = new Vector2(0, 0);
        transform.position = startPos;

    }
}

