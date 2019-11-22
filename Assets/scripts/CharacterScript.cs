using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScript : MonoBehaviour {
    CharacterController characterController;

    public float speed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 9.81f;
    public float maxTimeToJump = 2.0f;

    private float jumpTime = 0f;
    private Vector3 moveDirection =new Vector3();

    void Start() {
        characterController = GetComponent<CharacterController>();
    }

    void Update() {
        // We are grounded, so recalculate
        // move direction directly from axes


        if (characterController.isGrounded) {
            jumpTime = 0.0f;
            moveDirection = Vector3.zero;

        }
        moveDirection.x = keyboard().x;// new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
        moveDirection.x *= speed;
        jumpTime += Time.deltaTime;
        if (Input.GetButton("Jump") && jumpTime < maxTimeToJump) {
            moveDirection.y = jumpSpeed;
        }
        // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
        // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
        // as an acceleration (ms^-2)
        moveDirection.y -= gravity * Time.deltaTime;

        // Move the controller
        characterController.Move(moveDirection * Time.deltaTime);
    }



    // Update is called once per frame
    Vector3 keyboard() {
        Vector3 result = new Vector3();
        //if (Input.GetKey(KeyCode.W)) {
        //    result.y += 1;
        //}

        //if (Input.GetKey(KeyCode.S)) {
        //    result.y -= 1;
        //}

        if (Input.GetKey(KeyCode.A)) {
            result.x -= 1;
        }

        if (Input.GetKey(KeyCode.D)) {
            result.x += 1;
        }
        return result;
    }
}
