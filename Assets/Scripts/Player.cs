using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public float MovementSpeed = 1f;
	public float Health = 5f;
		

	void Start () {
		
	}
	

	void FixedUpdate ()
	{
		// Ad ogni update controlliamo l'input e lo passiamo alla funzione Move
		Move(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")));
	}


	// Muove questo oggetto nella direzione indicata
	void Move(Vector2 direction)
	{
		// transform.position contiene la posizione dell'oggetto a cui è attaccato questo script
		// lo spostiamo nella direzione passata come parametro, moltiplicata per la velocità.
		transform.position += (Vector3)(direction * MovementSpeed * Time.deltaTime);
	}
}
