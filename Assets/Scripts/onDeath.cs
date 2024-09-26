using UnityEngine;

public class onDeath : MonoBehaviour
{

    public void Dead()
    {
        Vector2 startPos = new Vector2(-8, -8);
        transform.position = startPos;

    }
}