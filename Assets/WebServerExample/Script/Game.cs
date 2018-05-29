using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ETag
{
	Bomb,
	Apple,
}

public class Game : MonoBehaviour
{
	[SerializeField] private Text _txtTime;
	[SerializeField] private Text _txtScore;
	[SerializeField] private GameObject _nameUI;
	[SerializeField] private InputField _nameInputField;
	
	[SerializeField] private RankView _rankView;
	[SerializeField] private Spawner _spawner;
	
	private double time
	{
		get { return _time; }
		set
		{
			_time = value;
			_txtTime.text = _time.ToString("N1");
		}
	}
	
	public int score
	{
		get { return _score; }
		set
		{
			_score = value;
			_txtScore.text = _score.ToString();
		}
	}

	private int    _score = 0;
	private double _time  = 0;

	private void FixedUpdate()
	{
		if (!_nameUI.gameObject.activeSelf && !_rankView.gameObject.activeSelf)
		{
			time += Time.fixedDeltaTime;
		}
	}

	public void OnStart()
	{
		_spawner.StartSpwan();
		_nameUI.SetActive(false);
	}
	
	public void GameOver()
	{
		Destroy(_spawner.gameObject);
		_rankView.Show(_nameInputField.text, score.ToString());
	}
}
