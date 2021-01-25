using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackButton : MonoBehaviour
{
    private PlayersAttacks playerAttack;

    private void Awake()
    {
        playerAttack = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayersAttacks>();
    }

    public void OnPointerDown()
    {
        if(gameObject.name == "Attack Button")
        {
            playerAttack.AttackButtonPressed();
        }
    }

    public void OnPointerUp()
    {
        if (gameObject.name == "Attack Button")
        {
            playerAttack.AttackButtonReleased();
        }
    }
}
