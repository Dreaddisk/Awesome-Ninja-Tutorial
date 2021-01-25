﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveJoystick : MonoBehaviour
{
    #region Variables
    private Transform playerTransform;
    private Animator anim;

    private AudioSource audioSource;

    public AudioClip footStep1;
    public AudioClip footStep2;

    private string ANIMATION_RUN = "Run";

    #endregion Variables

    void Awake()
    {
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        playerTransform = this.transform;
    }

    void OnEnable()
    {
        EasyJoystick.On_JoystickMove += JoystickMove;
        EasyJoystick.On_JoystickMoveEnd += JoystickMoveEnd;
    }

    void OnDisable()
    {
        EasyJoystick.On_JoystickMove -= JoystickMove;
        EasyJoystick.On_JoystickMoveEnd -= JoystickMoveEnd;
    }

    void JoystickMove(MovingJoystick move)
    {
        float angle = move.Axis2Angle(true);
        playerTransform.rotation = Quaternion.Euler(new Vector3(0, angle - 45, 0));
        anim.SetBool(ANIMATION_RUN, true);
    }

    void JoystickMoveEnd(MovingJoystick move)
    {
        anim.SetBool(ANIMATION_RUN, false);
    }

    void FootStepOne(bool play)
    {
        if (play)
        {
            audioSource.PlayOneShot(footStep1);
        }
    }

    void FootStepTwo(bool play)
    {
        if (play)
        {
            audioSource.PlayOneShot(footStep2);
        }
    }
}
