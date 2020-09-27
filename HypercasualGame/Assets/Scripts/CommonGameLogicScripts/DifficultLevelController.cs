using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;

public class DifficultLevelController : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI _scoreTextField = null;
	[SerializeField] private TextMeshProUGUI _nextLevelText = null;

	public delegate void LevelControllerCallBack(float _numToChange);
	public static event LevelControllerCallBack OnLevelIncrease;
	public static event LevelControllerCallBack OnLevelIncreaseSpawnChange;

	private int _secondLevelScore = 15;
	private int _thirdLevelScore = 40;

	public static float _levelObjectsMoveSpeed = 2f;

	private float _levelSpeedIncreaseNum = 0.5f;
	private float _levelSpawnDecreaseNum = 0.2f;

	private void Start()
	{
		_nextLevelText.gameObject.SetActive(false);
	}

	public void CheckScoreForLevelChange()
	{
		int score = int.Parse(_scoreTextField.text);
		if (score.Equals(_secondLevelScore) || score.Equals(_thirdLevelScore))
		{
			_levelObjectsMoveSpeed += _levelSpeedIncreaseNum;
			OnLevelIncrease?.Invoke(_levelSpeedIncreaseNum);
			OnLevelIncreaseSpawnChange?.Invoke(_levelSpawnDecreaseNum);
			StartCoroutine(ShowNextLevelText());
		}
	}

	private IEnumerator ShowNextLevelText()
	{
		_nextLevelText.gameObject.SetActive(true);
		yield return new WaitForSeconds(1f);
		_nextLevelText.gameObject.SetActive(false);
	}
}
