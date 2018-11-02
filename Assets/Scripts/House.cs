using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour {

	
	private void OnTriggerEnter2D(Collider2D other)
	{
		// Se il collider che entra in casa è taggato come Player...
		if (!other.tag.Equals("Player"))
			return;


		// ...allora recuperiamo il componente Player dal GameObject attaccato al collider ...

		Player player = other.gameObject.GetComponent<Player>();

		// ... se non è null (e quindi è effettivamente un player), allora lo settiamo come nascosto
		if (player != null)
			player.Hidden = true;
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		// Stessa cosa per l'exit, ma settiamo hidden su false.
		if (!other.tag.Equals("Player"))
			return;

		Player player = other.gameObject.GetComponent<Player>();

		if (player != null)
			player.Hidden = false;
	}

}
