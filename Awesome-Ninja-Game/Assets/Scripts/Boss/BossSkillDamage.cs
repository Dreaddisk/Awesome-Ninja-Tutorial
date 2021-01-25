using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSkillDamage : MonoBehaviour
{
    #region Varaibles
    public LayerMask playerMask;
    public float radius;
    private bool collided;
    public float damageCount;

    private PlayerHealth playerHealth;

    #endregion Variables

    void Awake()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }

    void Update()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, radius, playerMask);
        foreach (Collider c in hits)
        {
            if (c.isTrigger)
            {
                continue;
            }
            collided = true;
            if (collided)
            {
                playerHealth.TakeDamage(damageCount);
                Destroy(gameObject);
            }
        }
    }
}
