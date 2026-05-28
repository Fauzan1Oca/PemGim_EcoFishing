using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    [Header("Animator")]
    public Animator animator;

    [Header("State")]
    private bool isFishing = false;

    void Start()
    {
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }
    }

    void Update()
    {
        HandleWalkingAnimation();
        HandleJumpAnimation();
        HandleTalkAnimation();
        HandleFishingAnimation();
    }

    void HandleWalkingAnimation()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        float speed = new Vector2(horizontal, vertical).magnitude;

        animator.SetFloat("Speed", speed);
    }

    void HandleJumpAnimation()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("Jump");
        }
    }

    void HandleTalkAnimation()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            animator.SetTrigger("Talk");
        }
    }

    void HandleFishingAnimation()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (!isFishing)
            {
                StartFishing();
            }
            else
            {
                StopFishing();
            }
        }
    }

    void StartFishing()
    {
        isFishing = true;

        animator.SetBool("IsFishing", true);
        animator.SetTrigger("PlayAction");

        // Jika Anda punya fungsi lempar reel/umpan,
        // panggil di sini atau hubungkan dengan script fishing Anda.
        // ThrowReel();
    }

    void StopFishing()
    {
        isFishing = false;

        animator.SetBool("IsFishing", false);
        animator.SetTrigger("StopFishing");
    }
}