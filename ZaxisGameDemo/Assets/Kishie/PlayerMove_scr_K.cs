using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove_scr_K : MonoBehaviour {

    public GameObject cam, swing, player;
    private Rigidbody rg;

    public float speed = 6.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    private Vector3 moveDirection = Vector3.zero;
    CharacterController controller;



	void Start () {
        controller = GetComponent<CharacterController>();
        rg = gameObject.GetComponent<Rigidbody>();
		
	}
	
	void Update () {
        if (controller.isGrounded){
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            //これいる？
            //moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            if (Input.GetKeyDown(KeyCode.B)){
                moveDirection.y = jumpSpeed;
            }
        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }	
}