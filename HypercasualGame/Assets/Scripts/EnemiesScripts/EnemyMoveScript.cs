using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveScript : MonoBehaviour
{
	private Vector3 _enemyMoveDirection = Vector2.down;
	private float _enemyMoveSpeed = 2f;
	private float _angleOfRotation = 0.5f;

	private void OnEnable()
	{
		DifficultLevelController.OnLevelIncrease += IncreaseMoveSpeed;
	}

	private void OnDisable()
	{
		DifficultLevelController.OnLevelIncrease -= IncreaseMoveSpeed;
	}

	private void Start()
	{
		_enemyMoveSpeed = DifficultLevelController._levelObjectsMoveSpeed;
	}

	private void Update()
	{
		transform.position += _enemyMoveDirection * _enemyMoveSpeed * Time.deltaTime;

		transform.Rotate(Vector3.forward, _angleOfRotation);
	}

	public void IncreaseMoveSpeed(float levelIncreaseNum)
	{
		_enemyMoveSpeed += levelIncreaseNum;
	}
}
