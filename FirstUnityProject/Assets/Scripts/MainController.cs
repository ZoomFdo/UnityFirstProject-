using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MainController : MonoBehaviour
{
    // Start is called before the first frame update

    public CharacterController controller;
    public float speed = 6;
    private Vector3 move; //движение

    public float gravity = -10f; //f - математичесмкое значение
    public float jumpHeight = 0.5f;
    private Vector3 velocity;

    public Transform groundCheck;
    public LayerMask groundLayer;
    private bool isGrounded;

    InputAction movement;
    InputAction jump;

    private float LastClickTime = 0.0f;

    void Start()
    {
        
        jump = new InputAction("Jump", binding: "<keyboard>/space");
        
        //jump.AddBinding("<keyboard>/space");
        movement = new InputAction("PlayerMovement", binding:"<Gamepad> /leftStick");
        
        movement.AddCompositeBinding("Dpad")//*******************************************////////////*****//
            .With("Up", "<keyboard>/w")
            .With("Up", "<keyboard>/upArrow")//
            .With("Down", "<keyboard>/s")
            .With("Down", "<keyboard>/downArrow")//
            .With("Left", "<keyboard>/a")
            .With("Left", "<keyboard>/leftArrow")//
            .With("Right", "<keyboard>/d")
            .With("Right", "<keyboard>/rightArrow");

        movement.Enable();// движения в действии
        jump.Enable();// прыжок в действии

        //movement = new InputAction("Movement", binding:"<Gamepad> /leftStick");
        //jump AddBinding("<Gamepad> /a");
        
    }

    // Update is called once per frame
    void Update()
    {

        float x = Input.GetAxis("Horizontal"); 
        float z = Input.GetAxis("Vertical"); 
        // float x = joystick.Horizontal;
        // float y = joystick.Vertical;
        

        move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);
        //StartCoroutine(acceleration());//ускорение каждве 2 секунды удержания клавиши W(подробнее в строке 89)
        
        if (Input.GetKeyDown(KeyCode.W))//ускорение по двойному нажатию 
        {
            float timeFromLastClick = Time.time - LastClickTime;
            LastClickTime = Time.time;
            if (timeFromLastClick < 0.2) {
                speed = 15;
            } 
        } else if(Input.GetKeyUp(KeyCode.W)) {
            speed = 6;
        }

        isGrounded = Physics.CheckSphere(groundCheck.position, 0.3f, groundLayer);

        if(isGrounded && velocity.y < 0) 
            velocity.y = -1f;
        
        if(isGrounded) {//jump
            if(Input.GetButtonDown("Jump")) {// jump.ReadValue<float>(), 1
                Jump();
            }
        }


        else {
            velocity.y += gravity * Time.deltaTime;
        }

        controller.Move(velocity * Time.deltaTime);
        
        //Jump();/////////////////********************************************/////////
    }

    private void Jump() {
        velocity.y = Mathf.Sqrt(jumpHeight * 2 * -gravity);
    }

    // IEnumerator acceleration() {//ускорение
    //      if(Input.GetKeyDown(KeyCode.W)) {
    //         for(float i = 0; i < 7; i++) {
    //             speed++;
    //             yield return new WaitForSeconds(2);
    //         }
    //     } else if(Input.GetKeyUp(KeyCode.W)){
    //         speed = 6;
    //     }
    // }



}
