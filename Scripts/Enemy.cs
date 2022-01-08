
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic; 

public class Enemy : MonoBehaviour
{

    [SerializeField] private float attackCooldown;
    [SerializeField] private float range;
    [SerializeField] private float colliderDistance;
    [SerializeField] private int damage;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private Animator anim;
    [SerializeField] private AudioSource KOsound;
    [SerializeField] private AudioSource SwordSoundEnemy;



    private float cooldownTimer = Mathf.Infinity;
    private EnemyPatrol enemyPatrol;
    public int maxHealth = 100;
    private PlayerCombat playerHealth;
    int currentHealth;
    public HealthBar healthBar;
    public Slider slider;
    public Gradient gradient;
    public Image fill;


   // void Start()
    //{
       // currentHealth = maxHealth;
    //}


    private void Awake()
    {
        anim = GetComponent<Animator>();
        enemyPatrol = GetComponentInParent<EnemyPatrol>();
    }
    

    private void Update()
    {
        cooldownTimer += Time.deltaTime;

        if (PlayerInSight())
        {
            if (cooldownTimer >= attackCooldown)
            {
                cooldownTimer = 0;
                anim.SetTrigger("meleeAttack");
                // akougetai hxos spathiou toy exthrou (kodikas terma kato)
                StartCoroutine(SwordEnemy());
            }
        }
        if (enemyPatrol != null)
            enemyPatrol.enabled = !PlayerInSight();

    }

    private bool PlayerInSight()
    {
        RaycastHit2D hit =
            Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z),
            0, Vector2.left, 0, playerLayer);
        if (hit.collider != null)
            playerHealth = hit.transform.GetComponent<PlayerCombat>();

        return hit.collider != null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }




    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        StartCoroutine(Hurt());

        if (currentHealth <= 0)
        {
            Die();

            StartCoroutine(Disapear());
            StartCoroutine(KO());
            

            
        }


    }

    void Die()
    {
        anim.SetBool("IsDead", true);

        GetComponent<BoxCollider2D>().enabled = false;
        this.enabled = false;
    }

    public IEnumerator Disapear()
    {
        yield return new WaitForSeconds(1.15f);
        transform.position = new Vector3(0, -50, 0);
        
    }

    public IEnumerator Hurt()
    {
        yield return new WaitForSeconds(0.35f);
        anim.SetTrigger("hurt");
        Damage(1);

    }

    // slow motion effect 

    public IEnumerator KO()
    {
        yield return new WaitForSeconds(0.5f);
        KOsound.Play();
        Time.timeScale = 0.3f;
        Time.fixedDeltaTime = 0.02f * Time.timeScale;
        



        yield return new WaitForSeconds(0.3f);
        Time.timeScale = 1f;




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




    void Start()
    {

        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

    }

    // Update is called once per frame
    //void Update()
    //{

        //if (Input.GetKeyDown(KeyCode.Q))
        //{
            //TakeDamage(20);
        //}


    //}

    void Damage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }

    private void DamagePlayer()
    {
        if(PlayerInSight())
            playerHealth.TakeDamage(damage);
        
    }

    // ηχος απο το σπαθι του εχθρου
    public IEnumerator SwordEnemy()
    {
        yield return new WaitForSeconds(0.4f);
        SwordSoundEnemy.Play();



    }

}



    





