using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveKeyboard : MonoBehaviour
{
    #region Variables
    private Animator anim;

    // Objects to drag in
    public FreeMoveMotor motor;
    public Transform playerTransform;

    private Quaternion screenMovementSpace;
    private Vector3 screenMovementForward;
    private Vector3 screenMovementRight;

    private string AXIS_X = "Horizontal";
    private string AXIS_Y = "Vertical";

    private string ANIMATION_RUN = "Run";

    #endregion Variables


    #region UnityFunctions

    private void Awake()
    {
        anim = GetComponent<Animator>();
        motor.movementDirection = Vector2.zero;
    }

    private void Start()
    {
        screenMovementSpace = Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0);
        screenMovementForward = screenMovementSpace * Vector3.forward;
        screenMovementRight = screenMovementSpace * Vector3.right;
    }

    // Update is called once per frame
    void Update()
    {
        motor.movementDirection = Input.GetAxis(AXIS_X) * 
            screenMovementRight + Input.GetAxis(AXIS_Y) * screenMovementForward;


        if(Input.GetAxis(AXIS_X) != 0 || Input.GetAxis(AXIS_X) != 0)
        {
            anim.SetBool(ANIMATION_RUN, true);
        }
        else
        {
            anim.SetBool(ANIMATION_RUN, false);
        }
    }


    #endregion UnityFunctions




} // PlayerMoveKeyboard class
