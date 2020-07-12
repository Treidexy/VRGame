using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    public TextMesh hpText;

    public UnityEvent OnDead;

    public float maxHealth = 20f;
    public float health;

    private bool displayHealth = false;

    private void Start()
    {
        health = maxHealth;
        hpText.gameObject.SetActive(false);
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
        hpText.gameObject.SetActive(true);
    }

    public void HideHealth()
    {
        hpText.gameObject.SetActive(false);
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
            OnDead.Invoke();

            GameManager.instance.ChangeGVRClick(true);
            Destroy(gameObject);
        }
    }
}