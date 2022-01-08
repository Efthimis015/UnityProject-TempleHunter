using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthCollectible : MonoBehaviour
{
    [SerializeField] private int healthValue;
    public int currentHealth;
    public HealthBar healthBar;
    
    
    public Gradient gradient;
    public Image fill;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            
            collision.GetComponent<PlayerCombat>().AddHealth(healthValue);
            gameObject.SetActive(false);


        }

    }


   




}
