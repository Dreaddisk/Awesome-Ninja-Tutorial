﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    #region Variables
    private Transform zombieTransform;

    public float chaseSped;

    private CapsuleCollider col;
    private Transform player;
    private Animator anim;
    // private EnemyHealth enemyHealth;
    // private PlayerHealth playerHealth;

    private bool victory;

    // Animations States
    private string ANIMATION_ATTACK = "Attack";
    private string ANIMATION_RUN = "Run";
    private string ANIMATION_SPEED = "Speed";
    private string ANIMATION_VICTORY = "Victory";

    private string BASE_LAYER_STAND = "Base Layer Stand";

    // Navmesh 
    private NavMeshAgent navAgent;
    public Transform[] navPoints;
    private int navigationIndex;

    #endregion


    #region UnityFunctions
    private void Awake()
    {
        col = GetComponent<CapsuleCollider>();
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;

        zombieTransform = this.transform;
        // enemyHealth = GetComponent<enemyHealth>();
        // playerHealth = player.gameObject.GetComponent<PlayerHealth>();

        navAgent = GetComponent<NavMeshAgent>();
        navigationIndex = Random.Range(0, navPoints.Length);
        navAgent.SetDestination(navPoints[navigationIndex].position);
       
    }

    private void Update()
    {
        float distance = Vector3.Distance(zombieTransform.position, player.position);

        /*
         		if (enemyHealth.realHealth > 0) {
			if (distance > 7f) {
				Search();
				navAgent.Resume ();
			} else {
				navAgent.Stop ();
				if (distance > 2.5f) {
					Chase ();
				} else {
					Attack ();	
				}
				transform.LookAt (player);
			}
		}

		if (enemyHealth.realHealth <= 0) {
			col.enabled = false;
		}

		if (playerHealth.realHealth <= 0) {
			EnemyVictory();
		}

		if (victory) {
			StopVictoryAnimation();
		}
         */
    }

    #endregion UnityFunctions

    void Search()
    {
        if(navAgent.remainingDistance <= 0.5f)
        {
            anim.SetFloat(ANIMATION_SPEED, 0f);
            anim.SetBool(ANIMATION_ATTACK, false);
            anim.SetBool(ANIMATION_RUN, false);

            if(navigationIndex == navPoints.Length - 1)
            {
                navigationIndex = 0;

            }
            else
            {
                navigationIndex++;
            }

            navAgent.SetDestination(navPoints[navigationIndex].position);
        }
        else
        {
            anim.SetFloat(ANIMATION_SPEED, 1f);
            anim.SetBool(ANIMATION_ATTACK, false);
            anim.SetBool(ANIMATION_RUN, false);
        }
    }

    void Chase()
    {
        anim.SetBool(ANIMATION_RUN, true);
        anim.SetFloat(ANIMATION_SPEED, chaseSped);
        anim.SetBool(ANIMATION_ATTACK, false);
    }

    void Attack()
    {
        anim.SetBool(ANIMATION_ATTACK, true);
    }

    void EnemyVictory()
    {
        anim.SetBool(ANIMATION_VICTORY, true);
        victory = true;
    }

    void StopVictoryAnimation()
    {
        if(anim.GetCurrentAnimatorStateInfo(0).IsName(BASE_LAYER_STAND))
        {
            anim.SetBool(ANIMATION_VICTORY, false);
        }
    }




} // EnemyAI class
