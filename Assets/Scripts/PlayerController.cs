using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private InputManager inputManager;
    [SerializeField] private float speed;
    [SerializeField] private float jumpSpeed;
    bool isGrounded = true;
    private Rigidbody rb;
    private int jumpNum = 0;
    void Start()
    {
        inputManager.OnMove.AddListener(MovePlayer);
        inputManager.OnSpacePressed.AddListener(JumpPlayer);
        rb = GetComponent<Rigidbody>();
    }
    void MovePlayer(Vector3 input)
    {
        input.y = 0f;
        if (!isGrounded)
        {
            rb.AddForce(speed * input / 2);
        }
        else
        {
            rb.AddForce(speed * input);
        }
    }

    void JumpPlayer()
    {
        if (jumpNum == 0 && isGrounded)
        {
            Vector3 jump = new(0f, 1f, 0f);
            rb.AddForce(jump * jumpSpeed, ForceMode.Impulse);
            ++jumpNum;
            isGrounded = false;
        }
        else if (jumpNum == 1 && !isGrounded)
        {
            Vector3 jump = new(0f, 1f, 0f);
            rb.AddForce(jump * jumpSpeed, ForceMode.Impulse);
            ++jumpNum;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            jumpNum = 0;
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

}
