using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerWithEnemiesInteraction : MonoBehaviour
{
	[SerializeField] private string _simpleEnemyTag = "";
	[SerializeField] private string _targetEnemyTag = "";

	[SerializeField] private GameObject _playerDestroyEffect = null;

	public UnityEvent OnSimpleEnemyTriggered;
	public UnityEvent OnTargetEnemyTriggered;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag(_simpleEnemyTag))
		{
			GameObject effect = Instantiate(_playerDestroyEffect, collision.transform.position, Quaternion.identity);
			Destroy(effect, 2f);
			OnSimpleEnemyTriggered?.Invoke();
			Destroy(gameObject, 0.05f);
		}
		else if (collision.gameObject.CompareTag(_targetEnemyTag))
		{
			Destroy(collision.gameObject);
			OnTargetEnemyTriggered?.Invoke();
		}
	}
}
