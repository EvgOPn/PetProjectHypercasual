using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerWithEnemiesInteraction : MonoBehaviour
{
	[SerializeField] private string _simpleEnemyTag = "";
	[SerializeField] private string _targetEnemyTag = "";

	public UnityEvent OnSimpleEnemyTriggered;
	public UnityEvent OnTargetEnemyTriggered;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag(_simpleEnemyTag))
		{
			OnSimpleEnemyTriggered?.Invoke();
		}
		else if (collision.gameObject.CompareTag(_targetEnemyTag))
		{
			Destroy(collision.gameObject);
			OnTargetEnemyTriggered?.Invoke();
		}
	}
}
