using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
	// Questo trigger è usato per interagire con gli oggetti nella mappa(tipo porte)
	// Viene attivato e disattivato con EnableTrigger()
	public Collider2D InteractionTrigger;
	public float MovementSpeed = 1f;
	public float Health = 5f;

	public SpriteRenderer SpriteRenderer;

	public bool Hidden = false;


	protected virtual void Start () {
		SpriteRenderer = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	protected virtual void Update () {
		// Quando questa unità è nascosta, lo coloriamo di grigio.
		SpriteRenderer.color = Hidden ? Color.gray : Color.white;

	}

	public void EnableTrigger(bool state)
	{
		// Se questo script ha un trigger assegnato all'interno dell'editor...
		if (InteractionTrigger != null)
		{
			// ...allora cambiamo lo stato
			InteractionTrigger.enabled = state;
		}
	}

	/// <summary>
	/// Muove questa unità verso il punto indicato.
	/// </summary>
	public void MoveTowardsPoint(Vector2 targetPoint)
	{
		// Calcoliamo la direzione per arrivare al targetPoint.
		Vector2 direction = targetPoint - (Vector2)transform.position;
		direction.Normalize();

		// E la passiamo alla funzione Move.
		Move(direction);
	}

	/// <summary>
	/// Muove questa unità nella direzione indicata.
	/// </summary>
	public void Move(Vector2 direction)
	{
		// Se la lunghezza del vettore del movimento è vicina a 0, non ci muoviamo.
		if (direction.sqrMagnitude <= 0.01f)
			return;

		

		// transform.position contiene la posizione dell'oggetto a cui è attaccato questo script
		// lo spostiamo nella direzione passata come parametro, moltiplicata per la velocità.
		transform.position += (Vector3)(direction * MovementSpeed * Time.fixedDeltaTime);

		// Atan2 restituisce l'angolo corrispondente alla direzione scelta
		float ang = Mathf.Atan2(-direction.x, direction.y) * Mathf.Rad2Deg;

		// Quindi possiamo girare il personaggio.
		transform.eulerAngles = new Vector3(0, 0, ang);
	}
}
