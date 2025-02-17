using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.Events;

public class InputManager : MonoBehaviour
{
    public UnityEvent<Vector3> OnMove = new UnityEvent<Vector3>();
    public UnityEvent OnSpacePressed = new UnityEvent();
    public CinemachineCamera cinemachineCamera;

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            OnSpacePressed?.Invoke();
        }
        Vector3 forward = cinemachineCamera.transform.forward;
        Vector3 right = cinemachineCamera.transform.right;
        forward.Normalize();
        right.Normalize();

        forward.y = 0f;
        right.y = 0f;
        Vector3 moveDirection = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
        {
            moveDirection += forward;
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveDirection -= right;
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveDirection -= forward;
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveDirection += right;
        }
        moveDirection.Normalize();
        OnMove?.Invoke(moveDirection);
    }
}
