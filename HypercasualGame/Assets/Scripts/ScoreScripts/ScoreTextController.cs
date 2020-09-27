using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ScoreTextController : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI _scoreTextField = null;
	[SerializeField] private ScorePointsCounter _scorePoints = null;

	private float _defaultScoreTextFontSize;

	private void Start()
	{
		_defaultScoreTextFontSize = _scoreTextField.fontSize;
	}

	public void RefreshScoreTextField()
	{
		_scoreTextField.text = _scorePoints.ScoreCounter.ToString();
	}

	public void IncreaseScoreTextFont()
	{
		_scoreTextField.fontSize += 40f;
		StartCoroutine(DecreaseScoreTextFont());
	}

	private IEnumerator DecreaseScoreTextFont()
	{
		yield return new WaitForSeconds(0.1f);
		_scoreTextField.fontSize = _defaultScoreTextFontSize;
	}
}
