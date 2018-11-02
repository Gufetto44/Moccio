using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : Unit {

	// Il target che questo nemico sta rincorrendo al momento
	public Unit CurrentTarget;

	protected override void Start()
	{
		base.Start();
		_currentWanderDirection = Random.insideUnitCircle;
	}

	void FixedUpdate()
	{
		if (CurrentTarget!=null && !CurrentTarget.Hidden)
		{
			// Se abbiamo il target e non è nascosto, allora lo curriamo
			MoveTowardsPoint(CurrentTarget.transform.position);
			_currentWanderDirection = Vector2.zero;
		}
		else
		{
			// Altrimenti giriamo a caso
			Wander();
		}
	}


	Vector2 _currentWanderDirection;
	void Wander()
	{
		// Muove il nemico a caso nella direzione scelta, ma a metà della velocità normale.
		Move(_currentWanderDirection * 0.5f);

		// Ogni tanto cambiamo direzione.
		if (Random.value > 0.99f)
			_currentWanderDirection = Random.insideUnitCircle ;
	}
	
	// Per il campo visivo del nemico, usiamo un trigger circolare attaccato al nemico
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (!other.tag.Equals("Player"))
			return;

		// Come per lo script della casa, recuperiamo lo script Player dal gameobject che è entrato nel trigger...
		Player player = other.gameObject.GetComponent<Player>();

		// ... se non è null e non è nascosto, lo settiamo come target di questo nemico
		if (player != null)
			if (!player.Hidden)
				CurrentTarget = player;

	}

	private void OnTriggerExit2D(Collider2D other)
	{
		Player player = other.gameObject.GetComponent<Player>();

		// Se il player uscito dal trigger è anche il target attuale, allora resettiamo la variabile CurrentTarget
		if (player == CurrentTarget)
			CurrentTarget = null;
	}
}
