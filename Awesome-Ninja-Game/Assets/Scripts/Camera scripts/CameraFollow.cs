using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    #region Variables
    private Transform myTransform;
    private Transform target;

    public Vector3 offset = new Vector3(3, 7.5f, -3);
    #endregion Variables

    private void Awake()
    {
        target = GameObject.Find("Ninja").transform;
    }

    // Use this for initialization
    void Start()
    {
        myTransform = this.transform;
    }

    private void FixedUpdate()
    {
        if(target != null)
        {
            myTransform.position = target.position + offset;
            myTransform.LookAt(target.position, Vector3.up);
        }
    }
}
