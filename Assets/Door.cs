using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

	public bool IsOpen;

	Vector3 _defaultRotation;
	Vector3 _currentRotation;

	void Start () {
		
		// Manteniamo la rotazione iniziale della porta chiusa.
		_defaultRotation = transform.localEulerAngles;
		_currentRotation = _defaultRotation;
	}
	


	void Update ()
	{
		if (IsOpen)
			_currentRotation.z = Mathf.MoveTowards(_currentRotation.z, _defaultRotation.z+90f, Time.deltaTime * 150f);
		else
			_currentRotation.z = Mathf.MoveTowards(_currentRotation.z, _defaultRotation.z, Time.deltaTime * 150f);

		transform.localEulerAngles = _currentRotation;
	}


	private void OnTriggerEnter2D(Collider2D other)
	{
		// Quando qualcosa entra all'interno del trigger della porta, controlliamo se ha lo script di un giocatore attaccato
		// quindi cambiamo lo stato della porta di conseguenza.
		Player player = other.gameObject.GetComponent<Player>();

		if (player != null)
			IsOpen = true;
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		Player player = other.gameObject.GetComponent<Player>();

		if (player != null)
			IsOpen = false;
	}
}
