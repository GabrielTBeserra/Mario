using Assets.Scripts.Base;
using Assets.Scripts.Interfaces;
using UnityEngine;


public class MarioController : Entity , IMove
{
    private float speedMax = 5f;
    private SpriteRenderer sprite;
    private Animator animator;
    private Rigidbody2D rigidbody;
    private float horizontal = 0f;

    void Start()
    {
        moviments = new Moviments();
        life = new Life(3);
        sprite = GetComponent<SpriteRenderer>();
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        CheckGrounded();

        if (!moviments.isCrounched)
        {
            // Caso nao esteja agachado permite andar e correr
            horizontal = Input.GetAxisRaw("Horizontal");
        }
        else
        {
            horizontal = 0;
        }
        UpdateAnimation();
    }

    void FixedUpdate()
    {
        // Direcao
        rigidbody.velocity = new Vector2(horizontal * speedMax, rigidbody.velocity.y);
    }

    void UpdateAnimation()
    {
        if (horizontal != 0)
        {
            animator.SetFloat("direction", Mathf.Sign(horizontal));
        }


        animator.SetFloat("speed", Mathf.Abs(horizontal));
        animator.SetBool("isGrounded", moviments.isGrounded);
        animator.SetBool("isCrounch", moviments.isCrounched);
        animator.SetBool("isRunning", moviments.isRunning);
    }

    void CheckGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.1f);
        moviments.isGrounded = hit.collider != null;
        Debug.DrawRay(transform.position, Vector2.down * 0.1f, Color.red);
    }

   

    public void Jump()
    {
        rigidbody.AddForce(Vector2.up * 8, ForceMode2D.Impulse);
    }

    public void Run()
    {
        if (horizontal < 0)
        {
            horizontal -= 0.5f;
        }
        else if (horizontal > 0)
        {
            horizontal += 0.5f;
        }
    }
   

    public void Crounch()
    {    
        moviments.isCrounched = true;
    }

    public void Move()
    {
        throw new System.NotImplementedException();
    }
}
