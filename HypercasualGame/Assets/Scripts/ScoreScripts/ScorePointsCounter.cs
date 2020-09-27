using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScorePointsCounter : MonoBehaviour
{
	public int ScoreCounter { get; private set; }

	public UnityEvent OnScoreIncrease;

	private void Start()
	{
		ScoreCounter = 0;
	}

	public void AddPointToCounter()
	{
		ScoreCounter++;
		OnScoreIncrease?.Invoke();
	}
}
