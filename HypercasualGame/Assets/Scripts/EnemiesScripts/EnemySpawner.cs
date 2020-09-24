using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
	[SerializeField] private GameObject _simpleEnemy = null;
	[SerializeField] private GameObject _targetEnemy = null;

	private float _minSpawnPosition;
	private float _maxSpawnPosition;

	private float _simpleEnemySpawnInterval = 2f;
	private float _targetEnemySpawnInterval = 5f;

	private void Start()
	{
		_maxSpawnPosition = ScreenBounder.ScreenBounds.x - _simpleEnemy.GetComponent<SpriteRenderer>().bounds.extents.x;
		_minSpawnPosition = _maxSpawnPosition * -1;

		StartCoroutine(EnemiesSpawnCoroutine(_simpleEnemy, _simpleEnemySpawnInterval));
		StartCoroutine(EnemiesSpawnCoroutine(_targetEnemy, _targetEnemySpawnInterval));
	}

	private IEnumerator EnemiesSpawnCoroutine(GameObject enemy, float spawnInterval)
	{
		while (true)
		{
			SpawnEnemy(enemy);
			yield return new WaitForSeconds(spawnInterval);
		}
	}

	private void SpawnEnemy(GameObject enemy)
	{
		Vector2 spawnPosition = ChooseSpawnPosition();
		GameObject spawnedEnemy = Instantiate(enemy, spawnPosition, Quaternion.identity);
		PreventEnemiesSpawnOverlaping(spawnedEnemy);
	}

	private Vector2 ChooseSpawnPosition()
	{
		float xSpawnPos = Random.Range(_minSpawnPosition, _maxSpawnPosition);
		return new Vector2(xSpawnPos, transform.position.y);
	}

	private void PreventEnemiesSpawnOverlaping(GameObject spawnedEnemy)
	{
		BoxCollider2D enemyCollider = spawnedEnemy.GetComponent<BoxCollider2D>();
		enemyCollider.enabled = false;

		while (Physics2D.OverlapCircle(enemyCollider.bounds.center, enemyCollider.size.x))
		{
			spawnedEnemy.transform.position = ChooseSpawnPosition();
		}

		enemyCollider.enabled = true;
	}
}
