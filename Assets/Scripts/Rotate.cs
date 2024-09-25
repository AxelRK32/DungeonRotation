using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    enum GravityDirection { Down, Left, Up, Right };
    GravityDirection m_GravityDirection;
    float zCam = 0;
    public int rotateSpeed = 100;
    bool rotateCam = false;
    bool clockWise;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Character");
        m_GravityDirection = GravityDirection.Down;
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (!rotateCam)
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                clockWise = true;
                ChangeGravity(clockWise);
                rotateCam = true;
            }
                
            else if (Input.GetKeyDown(KeyCode.J))
            {
                clockWise = false;
                ChangeGravity(clockWise);
                rotateCam = true;
            }
        }
        if (rotateCam)
        {
            RotateCamera(clockWise);
        }
    }

    public void ChangeGravity(bool clockwise)
    {
        switch (m_GravityDirection)
        {
            case GravityDirection.Left:
                if (clockwise)
                {
                    //Change the gravity to be in a downward direction (default)
                    Physics2D.gravity = new Vector2(0, -9.8f);
                    m_GravityDirection = GravityDirection.Down;
                    break;
                }
                else
                {
                    //Change the gravity to be in a upward direction
                    Physics2D.gravity = new Vector2(0, 9.8f);
                    m_GravityDirection = GravityDirection.Up;
                    break;
                }

            case GravityDirection.Up:
                if (clockWise)
                {
                    //Change the gravity to go to the left
                    Physics2D.gravity = new Vector2(-9.8f, 0);
                    m_GravityDirection = GravityDirection.Left;
                    break;
                }
                else
                {
                    //Change the gravity to go in the right direction
                    Physics2D.gravity = new Vector2(9.8f, 0);
                    m_GravityDirection = GravityDirection.Right;
                    break;
                }

            case GravityDirection.Right:
                if (clockWise)
                {
                    //Change the gravity to be in a upward direction
                    Physics2D.gravity = new Vector2(0, 9.8f);
                    m_GravityDirection = GravityDirection.Up;
                    break;
                }
                else
                {
                    //Change the gravity to be in a downward direction (default)
                    Physics2D.gravity = new Vector2(0, -9.8f);
                    m_GravityDirection = GravityDirection.Down;
                    break;
                }

            case GravityDirection.Down:
                if (clockWise)
                {
                    //Change the gravity to go in the right direction
                    Physics2D.gravity = new Vector2(9.8f, 0);
                    m_GravityDirection = GravityDirection.Right;
                    break;
                }
                else
                {
                    //Change the gravity to go to the left
                    Physics2D.gravity = new Vector2(-9.8f, 0);
                    m_GravityDirection = GravityDirection.Left;
                    break;
                }
        }
    }

    public void RotateCamera(bool clockwise)
    {
        if (clockwise)
            zCam += rotateSpeed * Time.deltaTime;
        else
             zCam -= rotateSpeed * Time.deltaTime;
        Debug.Log("zCam = " + zCam + " clockwise = " + clockwise + "Gravity = " + m_GravityDirection);
        if (m_GravityDirection == GravityDirection.Right && ((clockwise && zCam >= 90) || (!clockwise && zCam <= 90)))
        {
            Debug.Log("Camera stopped. zCam = " + zCam);
            zCam = 90;
            rotateCam = false;
        }
        if (m_GravityDirection == GravityDirection.Up && ((clockwise && zCam >= 180) || (!clockwise && zCam <= 180)))
        {
            Debug.Log("Camera stopped. zCam = " + zCam);
            zCam = 180;
            rotateCam = false;
        }
        if (m_GravityDirection == GravityDirection.Left && ((clockwise && zCam >= 270) || (!clockwise && zCam <= -90)))
        {
            Debug.Log("Camera stopped. zCam = " + zCam);
            zCam = 270;
            rotateCam = false;
        }
        if (m_GravityDirection == GravityDirection.Down && (zCam >= 360 || zCam <= 0))
        {
            Debug.Log("Camera stopped. zCam = " + zCam);
            zCam = 0;
            rotateCam = false;
        }
        transform.rotation = Quaternion.Euler(0, 0, zCam);
        player.transform.rotation = Quaternion.Euler(0, 0, zCam);
    }

    public void ResetRotation()
    {
        m_GravityDirection = GravityDirection.Left;
        clockWise = true;
        ChangeGravity(clockWise);
        zCam = 0;
        transform.rotation = Quaternion.Euler(0, 0, zCam);
        player.transform.rotation = Quaternion.Euler(0, 0, zCam);
        rotateCam = false;
    }
}
