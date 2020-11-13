using UnityEngine;

public class MarioController : MonoBehaviour
{
    private float speedMax = 5f;
    private SpriteRenderer sprite;
    private Animator animator;
    private Rigidbody2D rigidbody;
    private float horizontal = 0f;
    private bool isGrounded = false;
    private bool isCrounched = false;
    private bool isRunning = false;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {

        CheckGrounded();
        isCrounch();

        if (!isCrounched)
        {
            horizontal = Input.GetAxisRaw("Horizontal");

            // Jump
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rigidbody.AddForce(Vector2.up * 5, ForceMode2D.Impulse);
            }
            isRun();
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
        /* if (horizontal > 0f)
         {
             sprite.flipX = false;
         }
         else if (horizontal < 0f)
         {
             sprite.flipX = true;
         }*/

        if(horizontal != 0)
        {
            animator.SetFloat("direction", Mathf.Sign(horizontal));
        }
        

        animator.SetFloat("speed", Mathf.Abs(horizontal));
        animator.SetBool("isGrounded", isGrounded);
        animator.SetBool("isCrounch", isCrounched);
        animator.SetBool("isRunning", isRunning);
    }

    void CheckGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.1f);
        isGrounded = hit.collider != null;
        Debug.DrawRay(transform.position, Vector2.down * 0.1f, Color.red);
    }


    void isCrounch()
    {
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            isCrounched = true;
        }
        else
        {
            isCrounched = false;
        }
    }

    void isRun()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (horizontal < 0)
            {
                horizontal -= 1;
            }
            else if (horizontal > 0)
            {
                horizontal += 1;
            }
            isRunning = true;
        }
        else
        {
            isRunning = false;
        }
    }
}
