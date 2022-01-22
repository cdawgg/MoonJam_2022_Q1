using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// derived from https://github.com/Acacia-Developer/Unity-FPS-Controller/blob/master/Assets/Script/PlayerController.cs under MIT license

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Transform playerCamera = null;
    [SerializeField] float mouseSensitivity = 3.5f;
    [SerializeField] float walkSpeed = 6.0f;
    [SerializeField] float gravity = -13.0f;
    [SerializeField] [Range(0.0f, 0.5f)] float moveSmoothTime = 0.3f;
    [SerializeField] [Range(0.0f, 0.5f)] float mouseSmoothTime = 0.03f;

    [SerializeField] bool lockCursor = true;

    float cameraPitch = 0.0f;
    float velocityY = 0.0f;
    CharacterController controller = null;

    Vector2 currentDir = Vector2.zero;
    Vector2 currentDirVelocity = Vector2.zero;

    Vector2 currentMouseDelta = Vector2.zero;
    Vector2 currentMouseDeltaVelocity = Vector2.zero;

    //interacting
    public float distance;
    public Dialogue dialogue;
    //public Animator animator;

    void Start()
    {
        controller = GetComponent<CharacterController>();

    }

    void Update()
    {
        if (!PauseMenu.isPaused)
        {
            UpdateMouseLook();
            UpdateMovement();
            MouseMove();
            if(Input.GetMouseButtonDown(0))
            {
                CheckInteraction();
            }
        }
    }

    void UpdateMouseLook()
    {
        Vector2 targetMouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        currentMouseDelta = Vector2.SmoothDamp(currentMouseDelta, targetMouseDelta, ref currentMouseDeltaVelocity, mouseSmoothTime);

        cameraPitch -= currentMouseDelta.y * mouseSensitivity;
        cameraPitch = Mathf.Clamp(cameraPitch, -5f, 40f);

        playerCamera.localEulerAngles = Vector3.right * cameraPitch;
        transform.Rotate(Vector3.up * currentMouseDelta.x * mouseSensitivity);
    }

    void UpdateMovement()
    {
        Vector2 targetDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        targetDir.Normalize();

        currentDir = Vector2.SmoothDamp(currentDir, targetDir, ref currentDirVelocity, moveSmoothTime);

        if (controller.isGrounded)
            velocityY = 0.0f;

        velocityY += gravity * Time.deltaTime;

        Vector3 velocity = (transform.forward * currentDir.y + transform.right * currentDir.x) * walkSpeed + Vector3.up * velocityY;

        controller.Move(velocity * Time.deltaTime);

    }

    void MouseMove()
    {
        if (lockCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    public void CheckInteraction()
    {
        //interacting, see https://www.youtube.com/watch?v=JID7YaHAtKA & https://www.youtube.com/watch?v=GaVADPZlO0o&t=429s & https://www.youtube.com/watch?v=cMp3kTyDmpw & https://www.youtube.com/watch?v=858X6_WHfuw&t=86s
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f, 0f));
            RaycastHit hit;

            Debug.DrawRay(ray.origin, ray.direction * 6f, Color.magenta);

            if (Physics.Raycast(ray, out hit, distance))
            {
                if (hit.collider != null)
                {
                    IClicked click = hit.collider.GetComponent<IClicked>();

                    if (click != null)
                    {
                        click.OnClickAction();
                    }
                }


            }
            else missHit();
    }



    public void missHit()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        Debug.Log("miss");
    }
}