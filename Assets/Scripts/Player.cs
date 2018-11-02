using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Unit {


	// Start e Update del player sono ereditati dalla classe Unit


	// Simile ad Update, ma viene usato per sincronizzare gli update con la fisica
	void FixedUpdate ()
	{
		// Ad ogni update controlliamo l'input degli assi (WASD, freccette o joystick) e lo passiamo alla funzione Move
		Move(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")));

		// Abilita il trigger del giocatore per interagire con gli oggetti solo quando premiamo F.
		EnableTrigger(Input.GetKeyDown(KeyCode.F));

	}

	
}
