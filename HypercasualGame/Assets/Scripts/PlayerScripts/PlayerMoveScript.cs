using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveScript : MonoBehaviour
{
	[SerializeField] private SpriteRenderer _playerSprite = null;
	[SerializeField] private float _moveSpeed = 2f;

	private float _minMovePosition;
	private float _maxMovePosition;

	private Vector3 _moveDirection = Vector3.right;

	private void Start()
	{
		_maxMovePosition = ScreenBounder.ScreenBounds.x - _playerSprite.bounds.extents.x;
		_minMovePosition = _maxMovePosition * -1;
	}

	private void Update()
	{
		transform.position += _moveSpeed * _moveDirection * Time.deltaTime;
		CheckScreenBounds();
	}

	public void ChangeMoveDirection()
	{
		_moveDirection *= -1;
	}

	private void CheckScreenBounds()
	{
		if (transform.position.x < _minMovePosition)
		{
			_moveDirection = Vector3.right;
		}
		else if (transform.position.x > _maxMovePosition)
		{
			_moveDirection = Vector3.left;
		}
	}
}
