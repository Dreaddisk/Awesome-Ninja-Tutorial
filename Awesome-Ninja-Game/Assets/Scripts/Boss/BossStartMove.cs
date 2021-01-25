using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStartMove : MonoBehaviour
{
    #region variables
    private SphereCollider col;

    private BossAI bossAI;
    #endregion

    // Use this for initialization
    void Awake()
    {
        col = GetComponent<SphereCollider>();
        bossAI = GameObject.FindGameObjectWithTag("Boss").GetComponent<BossAI>();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.tag == "Player")
        {
            bossAI.enabled = true;
            col.enabled = false;
        }
    }

}
