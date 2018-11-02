using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

	public bool IsOpen;

	float _direction = -1f;

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
			_currentRotation.z = Mathf.MoveTowards(_currentRotation.z, _defaultRotation.z+(90f*_direction), Time.deltaTime * 150f);
		else
			_currentRotation.z = Mathf.MoveTowards(_currentRotation.z, _defaultRotation.z, Time.deltaTime * 150f);

		transform.localEulerAngles = _currentRotation;
	}


	private void OnTriggerEnter2D(Collider2D other)
	{
		
		// In questo caso vogliamo far interagire il trigger della porta solo con gli altri collider marcati come trigger, quindi
		// scartiamo a priori le collisioni con collider non trigger.
		if (!other.isTrigger)
			return;

		// Scartiamo anche i trigger che non hanno lo stesso tag della porta.
		if (!other.tag.Equals(tag))
			return;

		
		IsOpen = !IsOpen;
	}
}
