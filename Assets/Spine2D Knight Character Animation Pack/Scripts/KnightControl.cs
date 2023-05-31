using UnityEngine;
using System.Collections;
using Spine;
using Spine.Unity;

public class KnightControl : MonoBehaviour
{
    #region Inspector
    // [SpineAnimation] attribute allows an Inspector dropdown of Spine animation names coming form SkeletonAnimation.
    [SpineAnimation]
    public string runAnimationName;

    [SpineAnimation]
    public string idleAnimationName;

    [SpineAnimation]
    public string walkAnimationName;

    [SpineAnimation]
    public string atkAnimationName_1;

    [SpineAnimation]
    public string atkAnimationName_2;

    [SpineAnimation]
    public string jumpAnimationName;

    [SpineAnimation]
    public string hitAnimationName;

    [SpineAnimation]
    public string deathAnimationName;

    [SpineAnimation]
    public string stunAnimationName;

    [SpineAnimation]
    public string skillAnimationName_1;
    [SpineAnimation]
    public string skillAnimationName_2;
    [SpineAnimation]
    public string skillAnimationName_3;

   
    [SerializeField]
    private SkeletonAnimation skeletonAnimation;


    // Other animation names...

    #endregion

    private bool isMoving;
    private bool isJumping;
    private bool isFacingRight = true;

    [SerializeField]
    private float moveSpeed = 5f;

    [SerializeField]
    private float jumpForce = 5f;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        if (skeletonAnimation == null)
        {
            skeletonAnimation = GetComponent<SkeletonAnimation>();
        }

        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get horizontal input for movement
        float moveInput = Input.GetAxisRaw("Horizontal");

        // Set the movement state based on the movement input
        isMoving = moveInput != 0;

        // Set the animation based on the movement and jumping state
        if (isJumping)
        {
            skeletonAnimation.AnimationName = jumpAnimationName;
        }
        else if (isMoving)
        {
            skeletonAnimation.AnimationName = runAnimationName;
        }
        else
        {
            skeletonAnimation.AnimationName = idleAnimationName;
        }

        // Move the character horizontally
        float moveVelocity = moveInput * moveSpeed;
        rb.velocity = new Vector2(moveVelocity, rb.velocity.y);

        // Flip the character's direction based on input
        if (moveInput < 0)
        {
            FlipCharacter(false);
        }
        else if (moveInput > 0)
        {
            FlipCharacter(true);
        }

        // Jumping logic
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            isJumping = true;
        }
    }

    // Method to flip the character's direction
    private void FlipCharacter(bool faceRight)
    {
        if (faceRight && !isFacingRight || !faceRight && isFacingRight)
        {
            isFacingRight = !isFacingRight;
            transform.Rotate(0f, 180f, 0f);
        }
    }

    // OnCollisionEnter2D is called when the character collides with another object
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the character is touching the ground to allow jumping again
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }

    // OnCollisionEnter2D is called when the character collides with another object
    


    // OnCollisionEnter2D is called when the character collides with another object
    // private void OnCollisionEnter2D(Collision2D collision)
    // {
    //     // Check if the character is touching the ground to allow jumping again
    //     if (collision.gameObject.CompareTag("Ground"))
    //     {
    //         isGrounded = true;
    //         isJumping = false;
    //         canJump = true;
    //     }
    // }

    // OnCollisionExit2D is called when the character stops colliding with an object
    // private void OnCollisionExit2D(Collision2D collision)
    // {
    //     // Check if the character is no longer touching the ground
    //     if (collision.gameObject.CompareTag("Ground"))
    //     {
    //         isGrounded = false;
    //     }
    // }

    








    // Spine.AnimationState and Spine.Skeleton are not Unity-serialized objects. You will not see them as fields in the inspector.
    public Spine.AnimationState spineAnimationState;
    public Spine.Skeleton skeleton;
    // Start is called before the first frame update
    // void Start()
    // {
    //     skeletonAnimation = GetComponent<SkeletonAnimation>();
    //     spineAnimationState = skeletonAnimation.AnimationState;
    //     skeleton = skeletonAnimation.Skeleton;
    // }

    public void running()
    {
        spineAnimationState.SetAnimation(0, runAnimationName, true);
    }
    public void walking()
    {
        spineAnimationState.SetAnimation(0, walkAnimationName, true);
    }
    public void idle()
    {
        spineAnimationState.SetAnimation(0, idleAnimationName, true);
    }
    public void jump()
    {
        spineAnimationState.SetAnimation(0, jumpAnimationName, true);
    }
    public void getHit()
    {
        spineAnimationState.SetAnimation(0, hitAnimationName, true);
    }
    public void death()
    {
        spineAnimationState.SetAnimation(0, deathAnimationName, true);
    }
    public void stun()
    {
        spineAnimationState.SetAnimation(0, stunAnimationName, true);
    }
    public void attack_1()
    {
        spineAnimationState.SetAnimation(0, atkAnimationName_1, true);
    }
    public void attack_2()
    {
        spineAnimationState.SetAnimation(0, atkAnimationName_2, true);
    }
    public void skill_1()
    {
        spineAnimationState.SetAnimation(0, skillAnimationName_1, true);
    }
    public void skill_2()
    {
        spineAnimationState.SetAnimation(0, skillAnimationName_2, true);
    }
    public void skill_3()
    {
        spineAnimationState.SetAnimation(0, skillAnimationName_3, true);
    }


}
