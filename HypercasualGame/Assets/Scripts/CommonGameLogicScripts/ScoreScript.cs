using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreScript : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI _scoreText = null;
	private float _defaultScoreFontSize;

	private int _scoreCounter = 0;

	private void Start()
	{
		_defaultScoreFontSize = _scoreText.fontSize;
	}

	public void AddPointToScore()
	{
		_scoreCounter++;
		_scoreText.text = _scoreCounter.ToString();
		IncreaseScoreTextEffect();
	}

	private void IncreaseScoreTextEffect()
	{
		_scoreText.fontSize += 30f;
		StartCoroutine(DecreaseScoreText());
	}

	private IEnumerator DecreaseScoreText()
	{
		yield return new WaitForSeconds(0.1f);
		_scoreText.fontSize = _defaultScoreFontSize;
	}
}
