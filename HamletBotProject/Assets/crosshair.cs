﻿/**************************************************************************
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
using DialoguerEditor;
using DialoguerCore;

public class crosshair : MonoBehaviour {

	public GameObject interactTex;
	public GameObject normalTex;

	[HideInInspector] public bool canInteract = false;
	[HideInInspector] public bool inDialogue;

	public static GameObject currGo = null;
	private Rect position;
	private Ray ray;
	private RaycastHit hit;
	private Vector3 screenPoint = new Vector3(Screen.width/2, Screen.height/2, 0);


	void Awake(){
		Dialoguer.Initialize();
	}


	void Update(){

		canInteract = false;
		ray = Camera.main.ScreenPointToRay( screenPoint );
		if (Physics.Raycast(ray, out hit, 7)){
			if(hit.transform.gameObject.tag =="Guest"){
				canInteract = true;
			}
		}

		//canInteract = true;
		updateVisual();

		if(canInteract && Input.GetKeyUp(KeyCode.E) && !inDialogue){
			inDialogue = true;
			Screen.lockCursor = false;
			Dialoguer.StartDialogue(3);
		}else if(!canInteract){
			inDialogue = false;
			Screen.lockCursor = true;
		}
	}
	

	void updateVisual(){
		if(canInteract){
			NGUITools.SetActive(interactTex, true);
			NGUITools.SetActive(normalTex, false);
		}
		else{
			NGUITools.SetActive(interactTex, false);
			NGUITools.SetActive(normalTex, true);
		}
	}
}
