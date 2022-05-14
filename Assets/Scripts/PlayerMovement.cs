using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float horizontalDirectionVelocity = 10f;
    [SerializeField] private float jumpForce = 15f;

    private new Rigidbody2D rigidbody;
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    private enum AnimationState { idle, running, jumping, falling }
    private AnimationState animationState;

    private float horizontalInputDirection;


    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInputDirection = Input.GetAxis("Horizontal");

        rigidbody.velocity = new Vector2(
            horizontalInputDirection * horizontalDirectionVelocity, rigidbody.velocity.y);

        if (Input.GetButtonDown("Jump"))
        {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpForce);
        }


        UpdateAnimationState();
        UpdateSpriteState();
    }

    private void UpdateSpriteState()
    {
        switch (animationState)
        {
            case AnimationState.running:
                if (horizontalInputDirection > 0f)
                    spriteRenderer.flipX = false;
                else if (horizontalInputDirection < 0f)
                    spriteRenderer.flipX = true;
                break;
            case AnimationState.idle:
            case AnimationState.jumping:
            case AnimationState.falling:
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


        if (rigidbody.velocity.y > 1f)
            animationState = AnimationState.jumping;
        else if (rigidbody.velocity.y < 1f)
            animationState = AnimationState.falling;


        animator.SetInteger("state", (int)animationState);
    }
}