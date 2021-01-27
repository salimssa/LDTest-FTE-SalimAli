using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float speed = 10;

    private GameManager gm;
    public GameObject hintBox;

    private float moveInput = 0;
    public float horizontalDampingBasic;
    public float horizontalDampingWhenStopping;
    public float horizontalDampingWhenTurning;

    public float jumpVelocity = 10.0f;

    public float fallMultiplier = 3f;
    public float lowJumpMultiplier = 6f;
    public float jumpHeldMultiplier = 2f;
    public bool applyJumpHeldMult { get; set; } = false;

    private bool isGrounded = false;
    public float groundCheckDist;
    public Transform feetPos;
    public LayerMask ground;


    public float hangTime = 0.2f;
    private float hangCounter;
    public float jumpBufferLength = 0.1f;
    private float jumpBufferCount;


    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
        transform.position = gm.lastCheckPointPos;
        rb = GetComponent<Rigidbody>();
    }

    void GroundCheck()
    {
        float radius = GetComponent<CapsuleCollider>().radius * 0.75f;
        Vector3 pos = feetPos.transform.position;
        isGrounded = Physics.CheckSphere(pos, radius, ground);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Death"))
        {
            // Add checkpoints
            SceneManager.LoadScene(0);
        }

    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Death"))
        {
            // Add checkpoints
            SceneManager.LoadScene(0);
        }
    }


    void FixedUpdate()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        float horizontalVelocity = rb.velocity.x;
        horizontalVelocity += moveInput;

        // speed ramps down to zero when stopping
        if (Mathf.Abs(moveInput) < 0.01f)
        { horizontalVelocity *= Mathf.Pow(1f - horizontalDampingWhenStopping, Time.deltaTime * 10f); }
        // Smooth turns
        else if (Mathf.Sign(moveInput) != Mathf.Sign(horizontalVelocity))
        { horizontalVelocity *= Mathf.Pow(1f - horizontalDampingWhenTurning, Time.deltaTime * 10f); }
        // smoothens speed ramp up to max from 0
        else
        { horizontalVelocity *= Mathf.Pow(1f - horizontalDampingBasic, Time.deltaTime * 10f); }

        rb.velocity = new Vector3(horizontalVelocity, rb.velocity.y, rb.velocity.z);

        if (rb.velocity.y < 0)
        { rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime; }
        else if (rb.velocity.y > 0 && Input.GetButton("Jump") && applyJumpHeldMult)
        { rb.velocity += Vector3.up * Physics.gravity.y * (jumpHeldMultiplier - 1) * Time.deltaTime; }
        else
        { rb.velocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime; }

        /* WIP to add hang time and jump buffer -> needs more polish and bug killing
        // Jump
        if (hangCounter > 0 && jumpBufferCount > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpVelocity);
            hangCounter = 0;
            jumpBufferCount = 0;
            isGrounded = false;
            applyJumpHeldMult = true;
        }
        */

        GroundCheck();
    }


    void Update()
    {

        /* WIP to add hang time and jump buffer -> needs more polish and bug killing
        // Jump hang time
        if (isGrounded) { hangCounter = hangTime; }
        else { hangCounter -= Time.deltaTime; }

        // jump buffer
        if (Input.GetButtonDown("Jump"))
        {
            jumpBufferCount = jumpBufferLength;
        }
        else
        if (Input.GetButtonDown("Jump") && isGrounded && rb.velocity.y == 0f)
        {
            jumpBufferCount -= Time.deltaTime;
            rb.velocity = new Vector2(rb.velocity.x, jumpVelocity);
            isGrounded = false;
            applyJumpHeldMult = true;
        }

        if (Input.GetButtonUp("Jump") && applyJumpHeldMult)
        {
            applyJumpHeldMult = false;
        }
        */

        if (Input.GetButtonDown("Jump") && isGrounded && rb.velocity.y == 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpVelocity);
            isGrounded = false;
            applyJumpHeldMult = true;
        }

        if (Input.GetButtonUp("Jump") && applyJumpHeldMult)
        {
            applyJumpHeldMult = false;
        }

        if (Input.GetButtonUp("Hint"))
        {
            hintBox.SetActive(!hintBox.activeInHierarchy);
        }


    }

}
