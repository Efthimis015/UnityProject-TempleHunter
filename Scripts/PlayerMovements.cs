
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;
    private Rigidbody2D body;
    private Animator anim;
    //private bool grounded;
    private BoxCollider2D boxCollider;
    public GameObject[] players;
    private float wallJumpCooldown;
    

    void start()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Awake()
    {
        //grab references from...
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    //kinhseis de3ia-aristera-phdhma
    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

        if (horizontalInput > 0.01f)
            transform.localScale = Vector3.one;

        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-1, 1, 1);

        if (Input.GetKey(KeyCode.UpArrow) && isGrounded())
            jump();

     
       



            anim.SetBool("run", horizontalInput != 0);
        anim.SetBool("grounded", isGrounded());

       // if (Input.GetKeyDown(KeyCode.Z))
          //  Interact();

    }

    private void jump()
    {
        body.velocity = new Vector2(body.velocity.x, speed);
        anim.SetTrigger("jump");
        

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.gameObject.tag == "Ground")
            //grounded = true;
    }
    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }

    private bool OnWall()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, new Vector2(transform.localScale.x,0), 0.1f, wallLayer);
        return raycastHit.collider != null;
    }

    //private void OnLevelWasLoaded(int level)
    //{
       // FindStartPos();
        //players = GameObject.FindGameObjectsWithTag("Player");

        //if(players.Length > 1)
        //{
           // Destroy(players[1]);
        //}
    //}
    void FindStartPos()
    {
        transform.position = GameObject.FindWithTag("StartPos").transform.position;
    }


    // void Interact()
    //{
    // var interactPos = transform.position;
    //  var collider = Physics2D.OverlapCircle(interactPos, 0.3f);

    // if (collider != null)
    //{
    //   collider.GetComponent<Interactable>()?.Interact();
    //}

    //}

    
}
