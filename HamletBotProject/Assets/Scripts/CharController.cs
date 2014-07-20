/**************************************************************************
 **                                                                       *
 **                COPYRIGHT AND CONFIDENTIALITY NOTICE                   *
 **                                                                       *
 **    Copyright (c) 2014 Hacksaw Games. All rights reserved.             *
 **                                                                       *
 **    This software contains information confidential and proprietary    *
 **    to Hacksaw Games. It shall not be reproduced in whole or in        *
 **    part, or transferred to other documents, or disclosed to third     *
 **    parties, or used for any purpose other than that for which it was  *
 **    obtained, without the prior written consent of Hacksaw Games.      *
 **                                                                       *
 **************************************************************************/

using UnityEngine;
using System.Collections;

public class CharController : MonoBehaviour {
	
	public const float CHARSPEED = 10;
	public const float GRAVITY = 1000;


	public Animator anim;

	

	private float speedMult = 1;
	private float camSpeedMult = 1;
	private Vector3 correctPlayerPos;
	private Quaternion correctPlayerRot;
	private bool canRegen;
	private int curRandomAnim;
	private bool isIdleAnimating;

	void Start() {
		//Get References to Animator and Collider
		anim.speed = 1.0f;
	}


	public void FixedUpdate(){
		//Rotating Character and Gravity
		charControl();
	}

	void charControl(){

		Vector3 moveDirection = Vector3.zero;
		moveDirection.x += Input.GetAxis("Horizontal") * CHARSPEED * speedMult;


		anim.SetFloat("Speed", Input.GetAxis("Vertical"));
		anim.SetFloat("Direction", Input.GetAxis("Horizontal"));
		moveDirection.z += Input.GetAxis("Vertical") * CHARSPEED * speedMult;

		moveDirection = transform.TransformDirection(moveDirection);
		moveDirection.y -= GRAVITY * Time.deltaTime;

		GetComponent<CharacterController>().Move(moveDirection * Time.deltaTime); 
	}

}
