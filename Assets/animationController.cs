using UnityEngine;

public class animationController : MonoBehaviour
{
    private Animator animator;
    private float velocity = 0.0f;
    private bool isWalking;
    [SerializeField] private float acceleration = 1.0f;
    [SerializeField] private float deceleration = 1.5f;
    private int velocityHash;
    private HealthSystem healthSystem;

    void Start()
    {
        animator = GetComponent<Animator>();
        velocityHash = Animator.StringToHash("Velocity");
        healthSystem = GetComponentInParent<HealthSystem>();
    }

    void Update()
    {

        if (healthSystem.isDead)
        {
            animator.SetBool("isDead", healthSystem.isDead);
            //enabled = false;
        }
        
        
        if (velocity < 0.0f)
        {
            velocity = 0.0f;
        }
        
        isWalking = Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0;
        
        animator.SetBool("isHitting", Input.GetMouseButtonDown(0));

        if (isWalking && velocity < 1.0f)
        {
            velocity += Time.deltaTime * acceleration;
        }
        if (!isWalking && velocity > 0.0f)
        {
            velocity -= Time.deltaTime * deceleration;
        }
        animator.SetFloat(velocityHash, velocity);
    }
}