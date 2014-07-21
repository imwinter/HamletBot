﻿using UnityEngine;
using System.Collections;

public class DialoguerExampleStart : MonoBehaviour {

	void Awake(){
		// You must initialize Dialoguer before using it!

	}

	void OnGUI(){
			// The preferred way to start dialogues is with the DialoguerDialogues enum
			// Like so:
			// Dialoguer.StartDialogue(DialoguerDialogues.My_First_Dialogue_Tree);

			// Or you can start it by passing the ID of the dialogue you want to start
			// Like so:
			// Dialoguer.StartDialogue(0);

			// We'll use the ID method for now, in order to avoid any errors when you start creating your own dialogues.

			
			// By default, the DialoguerDialogues enum is automatically updated when you save your dialogues.
			// You can turn this off in the Dialoguer preferences menu.

		}
	}

