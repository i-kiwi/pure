using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    public const float maxHealth = 100;
    public float currentHealth = maxHealth;
    public RectTransform hearthBar;

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        if(currentHealth <= 0)
        {
            currentHealth = 0;
            Debug.Log("dead!");
        }
        hearthBar.sizeDelta = new Vector2(currentHealth, hearthBar.sizeDelta.y);
    }
}
