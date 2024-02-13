using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class SimplePlayerController : MonoBehaviour
{
    public Camera playerCamera;
    public float walkSpeed = 1.15f;
    public float runSpeed = 4.0f;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 60.0f;
    public float gravity = 150.0f;
    public float rotationThreshold = 0.1f;  // Umbral para la zona muerta

    private CharacterController characterController;
    private Animator characterAnimator;
    private Vector3 moveDirection = Vector3.zero;
    private float rotationX = 0;
    private bool canMove = true;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        characterAnimator = GetComponent<Animator>();  // Asignar el componente Animator

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // Obtener las direcciones hacia adelante y hacia la derecha del personaje
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        // Verificar si el jugador está corriendo
        bool isRunning = Input.GetKey(KeyCode.LeftShift);

        // Calcular la velocidad actual en los ejes X e Y
        float curSpeedX = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Horizontal") : 0;

        // Guardar la dirección del movimiento antes de aplicar la gravedad
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        // Aplicar la gravedad si el personaje no está en el suelo
        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        // Mover al personaje
        characterController.Move(moveDirection * Time.deltaTime);


        if (canMove)
        {
            // Obtener la entrada del mouse para la rotación en el eje Y
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;

            // Limitar la rotación en el eje Y
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);

            // Aplicar la rotación a la cámara localmente
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);

            // Rotar el personaje en el eje Y
            transform.Rotate(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }

        // Obtener la entrada del teclado para moverse hacia atrás (tecla S o flecha hacia abajo)
        bool isMovingBackward = Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow);

        // Obtener la entrada del ratón para rotar hacia la izquierda
        bool isRotatingLeft = Input.GetAxis("Mouse X") < -rotationThreshold;

        // Obtener la entrada del ratón para rotar hacia la derecha
        bool isRotatingRight = Input.GetAxis("Mouse X") > rotationThreshold;

        // Obtener la entrada del teclado para moverse hacia adelante (tecla W o flecha hacia arriba)
        bool isWalking = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow);

        // Activar la animación Backward si se está moviendo hacia atrás
        if (isMovingBackward && !isRotatingLeft && !isRotatingRight)
        {
            // Activar la animación Backward en el Animator
            characterAnimator.SetBool("Backward", true);
        }
        else
        {
            // Desactivar la animación Backward si no se está moviendo hacia atrás
            characterAnimator.SetBool("Backward", false);
        }

        // Activar la animación Left si se está rotando hacia la izquierda
        if (isRotatingLeft)
        {
            // Activar la animación Left en el Animator
            characterAnimator.SetBool("Left", true);
        }
        else
        {
            // Desactivar la animación Left si no se está rotando hacia la izquierda
            characterAnimator.SetBool("Left", false);
        }

        // Activar la animación Right si se está rotando hacia la derecha
        if (isRotatingRight)
        {
            // Activar la animación Right en el Animator
            characterAnimator.SetBool("Right", true);
        }
        else
        {
            // Desactivar la animación Right si no se está rotando hacia la derecha
            characterAnimator.SetBool("Right", false);
        }

        // Activar la animación Walk si se está moviendo hacia adelante
        if (isWalking)
        {
            // Activar la animación Walk en el Animator
            characterAnimator.SetBool("Walk", true);
        }
        else
        {
            // Desactivar la animación Walk si no se está moviendo hacia adelante
            characterAnimator.SetBool("Walk", false);
        }

    }
}