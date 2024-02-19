using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class TakingDamage : MonoBehaviourPunCallbacks
{
    [SerializeField]
    Image healthBar;
    private float startHealth = 100;

    public float health;
    void Start()
    {
        health = startHealth;
        healthBar.fillAmount = health / startHealth;
    }


    [PunRPC]
    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log(health);
        healthBar.fillAmount = health / startHealth;
        if (health < 0)
        {
            Die();
        }
    }
    public void Die()
    {
        if(photonView.IsMine)
        {
            GameManager.instance.LeaveRoom();
        }
    }
}
