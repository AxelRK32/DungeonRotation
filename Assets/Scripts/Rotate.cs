using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    enum GravityDirection { Down, Left, Up, Right };
    GravityDirection m_GravityDirection;
    PlayerController controller;
    float zCam = 0;
    public int rotateSpeed = 100;
    bool rotateCam = false;
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
        if (Input.GetButtonDown("Jump") && !rotateCam)
        {
            ChangeGravity();
            rotateCam = true;
        }
        if (rotateCam)
        {
            RotateCamera();
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

    public void RotateCamera()
    {
        zCam += rotateSpeed * Time.deltaTime;
        if (m_GravityDirection == GravityDirection.Right && zCam >= 90)
        {
            zCam = 90;
            rotateCam = false;
        }
        if (m_GravityDirection == GravityDirection.Up && zCam >= 180)
        {
            zCam = 180;
            rotateCam = false;
        }
        if (m_GravityDirection == GravityDirection.Left && zCam >= 270)
        {
            zCam = 270;
            rotateCam = false;
        }
        if (m_GravityDirection == GravityDirection.Down && (zCam >= 360 || zCam <= 0))
        {
            zCam = 0;
            rotateCam = false;
        }
        transform.rotation = Quaternion.Euler(0, 0, zCam);
        player.transform.rotation = Quaternion.Euler(0, 0, zCam);
    }

    public void ResetRotation()
    {
        m_GravityDirection = GravityDirection.Left;
        ChangeGravity();
        zCam = 0;
        transform.rotation = Quaternion.Euler(0, 0, zCam);
        player.transform.rotation = Quaternion.Euler(0, 0, zCam);
        rotateCam = false;
    }
}
