using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityObject : MonoBehaviour
{
	private const float DESTROY_POSITION_Y = -500;
	
	public float gravityScale { get; set; }
	
	private Transform _transform;
	
	private void Start()
	{
		_transform   = this.transform;
		gravityScale = 5;
	}
	
	private void FixedUpdate()
	{
		_transform.localPosition = new Vector2(
			_transform.localPosition.x,
			_transform.localPosition.y - gravityScale);

		if (_transform.localPosition.y <= DESTROY_POSITION_Y)
		{
			Destroy(this.gameObject);
		}
	}
}