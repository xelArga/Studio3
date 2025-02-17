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
        Vector3 input = Vector2.zero;
        if (Input.GetKey(KeyCode.W))
        {
            input += cinemachineCamera.transform.forward;
        }
        if (Input.GetKey(KeyCode.A))
        {
            input += cinemachineCamera.transform.right * -1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            input += cinemachineCamera.transform.forward * -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            input += cinemachineCamera.transform.right;
        }
        OnMove?.Invoke(input);
    }
}
