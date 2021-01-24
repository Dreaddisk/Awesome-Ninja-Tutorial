using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackColl : MonoBehaviour
{
    #region Variables
    public LayerMask enemyLayer;

    public float radius;

    public GameObject attackEffect;

    public Transform hitPoint;

    public float damageCount;

    private EnemyHealth enemyHealth;

    private bool collided;
    #endregion Variables


    #region UnityFunctions
    private void Update()
    {
        Collider[] hits = Physics.OverlapSphere(hitPoint.position, radius, enemyLayer);
        foreach(Collider c in hits)
        {
            if(c.isTrigger)
            {
                continue;
            }
            enemyHealth = c.gameObject.GetComponent<EnemyHealth>();
            collided = true;

            if(collided)
            {
                Instantiate(attackEffect, hitPoint.position, hitPoint.rotation);
                enemyHealth.EnemyTakeDamage(damageCount);
            }
        }
    }
    #endregion

    private void OnDisable()
    {
        if(enemyHealth != null)
        {
            enemyHealth = null;
        }
    }


} // AttackColl class
