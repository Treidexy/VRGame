using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public TextMesh hpText;

    public float maxHealth;
    public float health;

    private bool displayHealth = false;

    private void Awake()
    {
        health = maxHealth;
    }

    private void Start()
    {
        hpText.text = "";
    }

    private void FixedUpdate()
    {
        if (displayHealth)
        {
            hpText.text = $"{health} ❤️";
            hpText.transform.LookAt(PlayerManager.instance.player.transform);
        }
    }

    public void ShowHealth()
    {
        displayHealth = true;
    }

    public void HideHealth()
    {
        hpText.text = "";
    }
     
    public void Damage(float amount)
    {
        health -= amount;

        CheckIfDead();
    }

    public void CheckIfDead()
    {
        if (health <= 0f)
        {
            GameManager.instance.ChangeGVRClick(true);
            Destroy(gameObject);
        }
    }
}