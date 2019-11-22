using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class UnitMoveScript : MonoBehaviour {
    //private int fightersLayer;
    private Rigidbody rb;
    //private Collider cldr;
    [SerializeField]
    protected MoveController moveController;
    [SerializeField]
    private Vector3 speed = new Vector3();
    private Vector3 gravity = new Vector3(0, -9.8f);
    private bool falling = true;
    // Start is called before the first frame update
    void Start() {
        //fightersLayer = LayerMask.NameToLayer("Fighters");
        rb = GetComponent<Rigidbody>();
        //cldr = GetComponent<Collider>();
    }
    void OnTriggerEnter(Collider collider) {
        Debug.Log("triggerEnterParams" + collider.enabled + collider.isTrigger + collider.name);
        //if (fightersLayer == collider.gameObject.layer) {       
        //    Debug.Log("layers!!!" + this);
        //}


    }

    void OnCollisionEnter(Collision collision) {

        //Debug.Log("collision" + this);
        //if (this.gameObject.layer == collision.gameObject.layer) {

        //    Debug.Log("layers!!!" + this);
        //}

        //ContactPoint contact = collision.contacts[0];
        //Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
        //Vector3 pos = contact.point;
        //Instantiate(explosionPrefab, pos, rot);
        //Destroy(gameObject);
    }

    private void FixedUpdate() {
        //if (Input.GetKey(KeyCode.W)) {
        //    rb.AddForce(Vector3.right * Time.fixedDeltaTime,ForceMode.Force);
        //}

        //if (Input.GetKey(KeyCode.S)) {
        //    rb.AddForce(Vector3.right * Time.fixedDeltaTime, ForceMode.Acceleration);
        //}

        //if (Input.GetKey(KeyCode.A)) {
        //    rb.AddForce(Vector3.right * Time.fixedDeltaTime, ForceMode.Impulse);
        //}

        //if (Input.GetKey(KeyCode.D)) {
        //    rb.AddForce(Vector3.right * Time.fixedDeltaTime, ForceMode.VelocityChange);
        //}
        //Debug.Log("rb:" + rb.position);


        //speed += moveController.CalcMovement() * Time.fixedDeltaTime;
        //speed += gravity;
        //rb.transform.Translate(speed * Time.fixedDeltaTime, Space.World);
        //if (rb.transform.position.y < -1) {
        //    Vector3 position = rb.transform.position;
        //    position.y = -1;
        //    rb.transform.position = position;
        //    speed = speed.ChangeY(0);
        //}

        Vector3 rbv = rb.velocity;
        if (this.name == "FirstUint") {

            //Debug.Log("ttt " + Time.fixedDeltaTime);
            //Debug.Log("velct" + rbv);
            float stepSize = Time.fixedDeltaTime * 10f;
            Vector3 dv = moveController.CalcMovement();
            dv.Scale(new Vector3(stepSize, stepSize * 0.8f));
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
            rb.MovePosition(rb.position + dv);
            //Debug.Log("imp_before:" + dv);
            //Debug.Log("vx:" + rb.velocity.RetrieveAdditionByIndexLimited(dv, 0, -stepSize, stepSize));
            //dv = dv.Change(rb.velocity.RetrieveAdditionByIndexLimited(dv, 0, -stepSize, stepSize), null, null);
            //Debug.Log("imp_after:" + dv);
            //rb.AddForce(dv, ForceMode.VelocityChange);
            //Debug.Log("velct" + rb.velocity);


        }
        //if (rb.transform.position.y < -1) {
        //Vector3 position = rb.transform.position;
        //position.y = -1;
        //rb.transform.position = position;
        //rb.velocity = rb.velocity.ChangeY(0);
        //}
    }



    // Update is called once per frame
    void Update() {
        ////Component rigidbody = GetComponent(typeof(Rigidbody));
        //Rigidbody rigidbody = GetComponent<Rigidbody>();


        //float x = Input.GetAxis("Horizontal");
        //Vector3 keyboard = new Vector3(x * Time.deltaTime, 0, 0);

        //Debug.Log(rigidbody.position);

        //rigidbody.transform.Translate(keyboard, Space.World);
    }
}
