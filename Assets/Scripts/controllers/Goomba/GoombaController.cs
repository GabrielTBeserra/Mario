using Assets.Scripts.Base;
using UnityEngine;

public class GoombaController : Entity
{
    private float speedMax = 5f;
    private Animator animator;
    private Rigidbody2D rigidbody;
    private float horizontal = 0f;

    public void Start()
    {
        moviments = new Moviments();
        life = new Life(1);
        sprite = GetComponent<SpriteRenderer>();
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        horizontal = 1;
    }

    public void Update()
    {
        IsColider();
        animator.SetFloat("Direction", Mathf.Sign(horizontal));
        animator.SetFloat("Speed", Mathf.Abs(horizontal));
    }

    void IsColider()
    {
        RaycastHit2D hitR = Physics2D.Raycast(transform.position, Vector2.right, 0.7f);
        RaycastHit2D hitL = Physics2D.Raycast(transform.position, Vector2.left, 0.7f);
        RaycastHit2D hitU = Physics2D.Raycast(transform.position, Vector2.up, 0.8f);


        if (hitU.collider != null)
        {
            Destroy(gameObject);
        }

        if (hitR.collider != null)
        {
            Destroy(hitR.collider.gameObject);
        }
        if (hitL.collider != null)
        {
            Destroy(hitL.collider.gameObject);
        }

    }

    public void FixedUpdate()
    {
        rigidbody.velocity = new Vector2(horizontal * speedMax, rigidbody.velocity.y);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Inverter"))
        {
            horizontal = horizontal * -1;
        }

        if (collision.CompareTag("JumpPoint"))
        {
            rigidbody.AddForce(Vector2.up * 2, ForceMode2D.Impulse);
        }

    }

}
