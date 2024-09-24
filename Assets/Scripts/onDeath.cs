using UnityEngine;

public class onDeath : MonoBehaviour
{

    public void Dead()
    {
        Vector2 startPos = new Vector2(0, 0);
        transform.position = startPos;

    }
}