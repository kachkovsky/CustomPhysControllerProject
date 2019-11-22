using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class UnitMoveScript2 : MonoBehaviour {
    //private int fightersLayer;
    private Rigidbody rb;
    //private Collider cldr;
    [SerializeField]
    protected MoveController moveController;
    [SerializeField]
    private Vector3 speed = new Vector3();
    private bool falling = true;

    void Start() {
        rb = GetComponent<Rigidbody>();
    }

    void OnTriggerEnter(Collider collider) {
        Debug.Log("triggerEnterParams" + collider.enabled + collider.isTrigger + collider.name);
    }

    void OnCollisionEnter(Collision collision) {
    }

    private void FixedUpdate() {
        Vector3 rbv = rb.velocity;

        //Debug.Log("ttt " + Time.fixedDeltaTime);
        //Debug.Log("velct" + rbv);
        float stepSize = 6f;
        float jumpStepSize = 6f * 0.8f;
        Vector3 dv = moveController.CalcMovement();
        dv.Scale(new Vector3(stepSize, jumpStepSize));
        //Debug.Log("dvy" + dv.y);
        if (falling) {
            //Debug.Log("Falling" + rbv.y);
            falling = rbv.y < 0f;
            dv.y = 0;
        } else {
            //start falling?
            if (((rbv.y * Time.fixedDeltaTime) + dv.y) < 0) {
                dv.y = 0;
                rb.velocity = rb.velocity.ChangeY(0);
                falling = true;
            }
        }
        dv.x = rb.velocity.RetrieveAdditionByIndexLimited(dv, 0, -stepSize, stepSize);
        Vector3 vy=new Vector3(0,rb.velocity.RetrieveAdditionByIndexLimited(dv, 1, -jumpStepSize, jumpStepSize));
        dv.y = 0;
        rb.AddForce(dv, ForceMode.VelocityChange);
        rb.AddForce(vy, ForceMode.VelocityChange);
        //if (!Vector3.zero.Equals(dv)) {
        Debug.Log("move:" + dv);
        //    rb.MovePosition(rb.position + dv * Time.fixedDeltaTime);
        //}


        //Debug.Log("imp_before:" + dv);
        //Debug.Log("vx:" + rb.velocity.RetrieveAdditionByIndexLimited(dv, 0, -stepSize, stepSize));

        //Debug.Log("imp_after:" + dv);
        //rb.AddForce(dv, ForceMode.VelocityChange);
        Debug.Log("velct" + rb.velocity);


    }



    // Update is called once per frame
    void Update() {
    }
}
