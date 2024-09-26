using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GateButton : MonoBehaviour
{
    public GameObject gate;
    SpriteRenderer btnSprite;
    Sprite pressedSprite;

    public void Start()
    {
        btnSprite = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name.Equals("Character"))
        {
            Debug.Log("player toched button");
            btnSprite.sprite = pressedSprite;
            //Start/Play gate open animation
            gate.GetComponent<Animation>().Play();
            gate.GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<GateButton>().enabled = false;
        }
    }
}
