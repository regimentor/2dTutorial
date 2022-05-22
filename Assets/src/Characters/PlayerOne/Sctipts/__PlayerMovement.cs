using UnityEngine;

public class __PlayerMovement : MonoBehaviour
{
    [SerializeField] private float horizontalDirectionVelocity = 10f;
    [SerializeField] private Vector2 movementVelocityVector;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private LayerMask jumpbleGround;

    private new Rigidbody2D rigidbody;
    private new BoxCollider2D collider;
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    private enum AnimationState { idle, running, jumping, falling }
    private AnimationState animationState;

    private float horizontalInputDirection;


    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        collider = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        rigidbody.velocity = movementVelocityVector;
    }


    // Update is called once per frame
    void Update()
    {
        horizontalInputDirection = Input.GetAxis("Horizontal");

        movementVelocityVector = new Vector2(
            horizontalInputDirection * horizontalDirectionVelocity, rigidbody.velocity.y);

        if (Input.GetButton("Jump") && IsOnGround())
            movementVelocityVector = new Vector2(rigidbody.velocity.x, jumpForce);


        UpdateAnimationState();
        UpdateSprite();
    }

    private void UpdateSprite()
    {
        switch (animationState)
        {
            case AnimationState.running:
            case AnimationState.idle:
            case AnimationState.jumping:
            case AnimationState.falling:
                if (horizontalInputDirection > 0f)
                    spriteRenderer.flipX = false;
                else if (horizontalInputDirection < 0f)
                    spriteRenderer.flipX = true;
                break;
            default:
                return;
        }
    }

    private void UpdateAnimationState()
    {
        if (horizontalInputDirection > 0f)
            animationState = AnimationState.running;
        else if (horizontalInputDirection < 0f)
            animationState = AnimationState.running;
        else
            animationState = AnimationState.idle;



        if (rigidbody.velocity.y > 0.1f)
            animationState = AnimationState.jumping;
        else if (rigidbody.velocity.y < -0.1f)
            animationState = AnimationState.falling;


        animator.SetInteger("state", (int)animationState);
    }

    private bool IsOnGround()
    {
        return Physics2D.BoxCast(collider.bounds.center,
            collider.bounds.size, 0f, Vector2.down, 0.1f, jumpbleGround);
    }
}