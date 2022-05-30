using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
   [Header("Movement")]
    [SerializeField] Rigidbody rb;
    [SerializeField] public bool IsAlive;
    [SerializeField][Range(0, 10000)] float MovementSpeed;
    [SerializeField][Range(0, 10000)] float HorizontalSpeed;
    [SerializeField][Range(0, 100000)] float JumpSpeed;
    [SerializeField] private CapsuleCollider coll;
    [SerializeField] private LayerMask Ground;



    [Header("Additional Game Logic")]

    [SerializeField] [Range(0,3)]float Cooldown;
    private bool CanJump = true;
    [SerializeField] Animator animator;
    [SerializeField] private float Timer;
    [SerializeField] private float SpeedChange;

    void Start()
    {
        rb.GetComponent<Rigidbody>();
    }


    private void FixedUpdate()
    {
        IsGrounded();
    }

    void Update()
    {
       
        SprintLogic();
        SpeedChanger();
        JumpLogic();
    }


    void JumpLogic()
    {
        if (!IsAlive)
        {
            return;
        }

        if (!IsGrounded())
        {
            animator.SetBool("IsFalling", true);
        }
        else
        {
            animator.SetBool("IsFalling", false);
        }

        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space) && CanJump)
        {
            rb.AddForce (Vector3.up * JumpSpeed , ForceMode.VelocityChange);
            StartCoroutine(JumpCooldown(Cooldown));
        }
    }


    IEnumerator JumpCooldown(float Cooldown)
    {
        CanJump = false;

        yield return new WaitForSeconds(Cooldown);

        CanJump = true;
  
    }

    public bool IsGrounded()
    {
        return Physics.CheckCapsule(coll.bounds.center, new Vector3(coll.bounds.center.x, coll.bounds.min.y, coll.bounds.center.z), coll.radius * 0.9f, Ground);
    
    }

    private void SprintLogic()
    {
        if(IsAlive == true) //To prevent moving even after the game is over
        {
            float HorizontalInput = Input.GetAxis("Horizontal") * -HorizontalSpeed; //Detects input and Added the speed variable
            Vector3 MovementVector = new Vector3(MovementSpeed, rb.velocity.y, HorizontalInput); //Making a vector towards the direction we wanna move
            rb.velocity = MovementVector * Time.fixedDeltaTime; //Implementing that vector to the rigidbody's velocity and adding time.fixeDeltaTime so that it becomes frame independent

           Timer = Timer + Time.deltaTime; // Add 1 every second to the timer variable / float
        }else
        {
            return;
        }
    }

     private void SpeedChanger() // Goes through if Statements and changes speed accoring to the value of timer
    {

        if (Timer >= 10 && MovementSpeed <= 4020)
        {
            MovementSpeed = MovementSpeed + SpeedChange;
        }

        if (Timer >= 35 && MovementSpeed <= 4040)
        {
            MovementSpeed = MovementSpeed + SpeedChange;
        }

        if (Timer >= 55 && MovementSpeed <= 4060)
        {
            MovementSpeed = MovementSpeed + SpeedChange;
        }
        if (Timer >= 80  && MovementSpeed <= 4080)
        {
            MovementSpeed = MovementSpeed + SpeedChange;
        }

        if (Timer >= 100 && MovementSpeed <= 4100)
        {
            MovementSpeed = MovementSpeed + SpeedChange;
        }

        if (Timer >= 125  && MovementSpeed <= 4120)
        {
            MovementSpeed = MovementSpeed + SpeedChange;
        }

        if (Timer >= 150 && MovementSpeed <= 4140)
        {
            MovementSpeed = MovementSpeed + SpeedChange;
        }
        if (Timer >= 160 && MovementSpeed <= 4160)
        {
            MovementSpeed = MovementSpeed + SpeedChange;
        }
    }
}
