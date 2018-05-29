using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
	[SerializeField] private Game _game;
	
	private const float CHARACTER_SPEED = 15.0f;
	private Transform _transform;
	
	private void Start()
	{
		_transform = this.transform;
	}

	private void FixedUpdate()
	{
		float horizon = Input.GetAxis("Horizontal");
		float xPos    = Mathf.Clamp(_transform.localPosition.x + horizon * CHARACTER_SPEED, -540, 580);
		_transform.localPosition = new Vector2(xPos,_transform.localPosition.y);
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag(ETag.Apple.ToString().ToLower()))
		{
			_game.score += 1;
		}
		else if (other.CompareTag(ETag.Bomb.ToString().ToLower()))
		{
			_game.GameOver();
		}
		Destroy(other.gameObject);
	}
}
