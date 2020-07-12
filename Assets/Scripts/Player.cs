using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    public GameObject deathScreen;
    public TextMeshProUGUI hpText;

    public UnityEvent OnDead;

    public float maxHealth = 40f;
    public float health;

    public float strength = 1.2f;

    public float attackDelay = 0.24f;

    public bool canAttack;

    private float attackTimer = 0f;

    private void Start()
    {
        health = maxHealth;
        canAttack = true;

        deathScreen.SetActive(false);
    }

    private void FixedUpdate()
    {
        hpText.SetText($"{health} HP");

        attackTimer += Time.deltaTime;

        if (attackTimer >= attackDelay)
        {
            canAttack = true;

           /*
              if (Input.GetMouseButtonDown((int) MouseButton.LeftMouse))
                attackTimer = 0;
           */
        }
        else
            canAttack = false;
    }

    public void Attack(Enemy enemy) =>
        enemy.Damage(strength);

    public void Damage(float amount)
    {
        health -= amount;

        CheckIfDead();
    } 

    public void CheckIfDead()
    {
        if (health <= 0f)
            OnDead.Invoke();
    }

    public void ChangeShowDeathScreen(bool value) =>
        deathScreen.SetActive(value);

    public void Respawn() =>
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
}