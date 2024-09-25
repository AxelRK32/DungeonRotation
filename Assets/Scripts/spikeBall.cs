using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spikeBall : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name.Equals("Character"))
            other.gameObject.GetComponent<Death>().Dead();
                
    }
}
