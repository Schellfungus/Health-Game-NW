using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class HG_Neues_PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public float jumpCooldown = 2f; // Zeit zwischen den Sprüngen

    private Rigidbody rb;
    private bool isGrounded;
    private bool canJump = true;

     [SerializeField] private GameObject footsteps;

    private static HG_Neues_PlayerMovement diesess;

    public Animator anim;

    private bool movingBackwards = false;

    public SpriteRenderer spRe;

    private Animator flip;



  

    private void Awake()
    {
        if (diesess == null)
        {
            diesess = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);

        flip = gameObject.GetComponent<Animator>();
    }


    void Start()
    {
        Physics.gravity = new Vector3(0, -30, 0);
        rb = GetComponent<Rigidbody>();
        //  moveOnStart();
        footsteps = GameObject.FindWithTag("Footsteps");
        footsteps.SetActive(false);
    }

    void moveOnStart()
    {
        transform.position = new Vector3(-6, 40, 10);
    }

    void Update()
    {
        // Bewegung
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 moveDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;
        Vector3 moveVelocity = moveDirection * moveSpeed;
        rb.velocity = new Vector3(-moveVelocity.x, rb.velocity.y, -moveVelocity.z);

        anim.SetFloat("moveSpeed",rb.velocity.magnitude);

        // Springen
        if (canJump && Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            canJump = false;
            anim.SetBool("Jumped", true);
            StartCoroutine(JumpCooldown());
        }


        if (!GameObject.FindGameObjectWithTag("BauerBernsd"))
        {

            if (!spRe.flipX && horizontalInput < 0)
            {

                flip.SetTrigger("Flipper");
                spRe.flipX = true;
            }
            else if (spRe.flipX && horizontalInput > 0)
            {
                flip.SetTrigger("Flipper");
                spRe.flipX = false;
            }

        } else
        {
            if (!spRe.flipX && horizontalInput > 0)
            {

                flip.SetTrigger("Flipper");
                
            }
            else if (spRe.flipX && horizontalInput < 0)
            {
                flip.SetTrigger("Flipper");
               
            }
        }
     


           








            // if(GameObject.FindGameObjectWithTag("BauerBernsd"))
            //  {
            //          spRe.flipX = false;

            //    } else spRe.flipX = true;


        if (verticalInput > 0)
        {
            movingBackwards = true;

        }else if(verticalInput == 0)
        {

                       movingBackwards = false;
        }

        anim.SetBool("movingBackwards", movingBackwards);
        
               
    }
    
  

    IEnumerator ActiveFootsteos()
    {
        yield return new WaitForSeconds(2);
        footsteps.SetActive(true);
    }
  
    IEnumerator JumpCooldown()
    {
        yield return new WaitForSeconds(jumpCooldown);
        anim.SetBool("Jumped", false);
        canJump = true;

    
    }

    

   
}
