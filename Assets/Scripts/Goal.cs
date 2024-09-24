using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public void Start()
    {
        Debug.Log("Goal start");
    }
    public void OnTriggerEnter(Collider other)
    {
        Debug.Log(other + " entered goal");
    }
}
