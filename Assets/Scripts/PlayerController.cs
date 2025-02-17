using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private InputManager inputManager;
    [SerializeField] private float speed;
    private Rigidbody rb;
    void Start()
    {
        inputManager.OnMove.AddListener(MovePlayer);
        rb = GetComponent<Rigidbody>();
    }
    void MovePlayer(Vector3 input)  
    {
        Vector3 moveDirection = new(input.x, 0f, input.y);
        rb.AddForce(speed * moveDirection, ForceMode.Acceleration);
    }
}
