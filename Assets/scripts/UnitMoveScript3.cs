using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class UnitMoveScript3 : MonoBehaviour {

    public static readonly float myEpsilon = 0.0001f;

    //private int fightersLayer;
    private Rigidbody rb;
    //private Collider cldr;

    public enum FlyState { falling, stay, flying };

    [SerializeField]
    protected FlyState flyState = FlyState.stay;



    [SerializeField]
    protected MoveController moveController;
    [SerializeField]
    private Vector3 speed = new Vector3();
    private bool fallingDown;
    private bool waitForFallingDown;
    private bool isJump;
    float jumpTime = 0f;
    private bool grounded = false;
    void Start() {
        rb = GetComponent<Rigidbody>();
    }

    void OnTriggerEnter(Collider collider) {
        Debug.Log("triggerEnterParams" + collider.enabled + collider.isTrigger + collider.name);
    }

    void OnCollisionEnter(Collision collision) {
    }



    private void FixedUpdate() {
        //Debug.Log("start:" + rb.velocity);
        CalcFlyStateInFixUpdate();

        float stepSize = 6f;
        float jumpSpeedSize = 6f * 0.8f;
        Vector3 move = moveController.CalcMovement();
        //dv.Scale(new Vector3(stepSize, jumpStepSize));

        if (fallingDown || waitForFallingDown) {
            move.y = 0;
            isJump = false;
            jumpTime = 0f;
        }
        if (isJump) {
            jumpTime += Time.fixedDeltaTime;
        }
        float upSpeed = 0f;
        if (move.y > myEpsilon) {
            int multiplier = (jumpTime < 0.5f) ? 1 : 0;
            if (!isJump) {
                isJump = true;
                upSpeed += move.y * multiplier * jumpSpeedSize;
            }
            rb.AddForce(Vector3.up * 9.81f * multiplier, ForceMode.Acceleration);
        } else if(!fallingDown) {
            waitForFallingDown = true;
        }


        Vector3 dv = new Vector3(rb.velocity.RetrieveAdditionByIndexLimited(move * stepSize, 0, -stepSize, stepSize),
            upSpeed,
            0);

        rb.AddForce(dv, ForceMode.VelocityChange);
        
        if (Mathf.Abs(rb.velocity.y) < myEpsilon) {
            waitForFallingDown = false;
            if (move.y < myEpsilon) {
                isJump = false;
                if (!grounded) {
                    grounded = true;
                    Debug.Log("Grounded event");//can we recalculate horizontal acceleration after this ground event?
                }
            }
        }
        //Debug.Log("End:" + jumpTime);
        //Debug.Log("End:"+rb.velocity);
    }



    // Update is called once per frame
    void Update() {
    }

    void CalcFlyStateInFixUpdate() {
        fallingDown = rb.velocity.y < -myEpsilon;
    }
}
