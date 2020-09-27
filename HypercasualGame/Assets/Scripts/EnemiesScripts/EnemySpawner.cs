using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
	[SerializeField] private GameObject _simpleEnemy = null;
	[SerializeField] private GameObject _targetEnemy = null;

	private float _minSpawnPosition;
	private float _maxSpawnPosition;

	private float _simpleEnemySpawnInterval = 1f;
	private float _targetEnemySpawnInterval = 4f;

	private void OnEnable()
	{
		DifficultLevelController.OnLevelIncreaseSpawnChange += DecreaseSpawnIntervals;
	}

	private void OnDisable()
	{
		DifficultLevelController.OnLevelIncreaseSpawnChange -= DecreaseSpawnIntervals;
	}

	private void Start()
	{
		_maxSpawnPosition = ScreenBounder.ScreenBounds.x - _simpleEnemy.GetComponent<SpriteRenderer>().bounds.extents.x;
		_minSpawnPosition = _maxSpawnPosition * -1;

		StartCoroutine(SimpleEnemiesSpawnCoroutine());
		StartCoroutine(TargetEnemiesSpawnCoroutine());
	}

	private void DecreaseSpawnIntervals(float numToDecrease)
	{
		_simpleEnemySpawnInterval -= numToDecrease;
		_targetEnemySpawnInterval -= numToDecrease;
	}

	private IEnumerator SimpleEnemiesSpawnCoroutine()
	{
		while (true)
		{
			SpawnEnemy(_simpleEnemy);
			yield return new WaitForSeconds(_simpleEnemySpawnInterval);
		}
	}

	private IEnumerator TargetEnemiesSpawnCoroutine()
	{
		while (true)
		{
			SpawnEnemy(_targetEnemy);
			yield return new WaitForSeconds(_targetEnemySpawnInterval);
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
