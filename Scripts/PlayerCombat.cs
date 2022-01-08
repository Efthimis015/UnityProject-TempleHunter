using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public int attackDamage = 50;
    public float attackRate = 2f;
    float nextAttackTime = 0f;
    float nextAbilityTime = 0f;
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;
    public Slider slider;
    public Gradient gradient; 
    public Image fill;
    [SerializeField] private AudioSource SwordSound;
    [SerializeField] private AudioSource DeathSwordSound;




    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {


                Attack();
                nextAttackTime = Time.time + 1f / attackRate;

            }

        }

        if (Time.time >= nextAbilityTime)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {


                StartCoroutine(Ability());
                nextAbilityTime = Time.time + 20f / attackRate;

            }

        }
    }

    void Attack()
    {
        animator.SetTrigger("attack");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);

            StartCoroutine(Sword());



        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }


    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);

        animator.SetTrigger("PHurt");

        if (currentHealth <= 0)
        {
            Death();
            
            


        }
    }

    // pethainei kai paei sto respawn scene
    void Death()
    {
        animator.SetBool("PDie", true);
        StartCoroutine(DeathCall());
        



    }

    public IEnumerator DeathCall()
    {
        yield return new WaitForSeconds(0f);
        Time.timeScale = 0.2f;
        Time.fixedDeltaTime = 0.02f * Time.timeScale;
        DeathSwordSound.Play();





        yield return new WaitForSeconds(0.35f);
        Time.timeScale = 1f;
        SceneManager.LoadScene(4);




    }

    //

    public void AddHealth(int _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, maxHealth);

        healthBar.SetHealth(currentHealth);


    }


    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;

        fill.color = gradient.Evaluate(1f);
    }


    public void SetHealth(int health)
    {
        slider.value = health;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    public IEnumerator Sword()
    {
        yield return new WaitForSeconds(0.4f);
        SwordSound.Play();
       


    }

    // hxos apo spathi KO enemy ston xarakthra mas otan pethainei
    public IEnumerator DeathSword()
    {
        yield return new WaitForSeconds(0.4f);




    }

    public IEnumerator Ability()
    {
        yield return new WaitForSeconds(0.1f);
        Attack();
        yield return new WaitForSeconds(0.23f);
        Attack();
        yield return new WaitForSeconds(0.3f);
        Attack();



    }







}

