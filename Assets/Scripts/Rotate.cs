using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    enum GravityDirection { Down, Left, Up, Right };
    GravityDirection m_GravityDirection;
    // Start is called before the first frame update
    void Start()
    {
        m_GravityDirection = GravityDirection.Down;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            ChangeGravity();
        }
        
    }

    public void ChangeGravity()
    {
        switch (m_GravityDirection)
        {
            case GravityDirection.Left:
                //Change the gravity to be in a downward direction (default)
                Physics2D.gravity = new Vector2(0, -9.8f);
                m_GravityDirection = GravityDirection.Down;
                break;

            case GravityDirection.Up:
                //Change the gravity to go to the left
                Physics2D.gravity = new Vector2(-9.8f, 0);
                m_GravityDirection = GravityDirection.Left;
                break;

            case GravityDirection.Right:
                //Change the gravity to be in a upward direction
                Physics2D.gravity = new Vector2(0, 9.8f);
                m_GravityDirection = GravityDirection.Up;
                break;

            case GravityDirection.Down:
                //Change the gravity to go in the right direction
                Physics2D.gravity = new Vector2(9.8f, 0);
                m_GravityDirection = GravityDirection.Right;
                break;
        }
    }
}
