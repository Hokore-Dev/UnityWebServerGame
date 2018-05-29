using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
	private const float SPAWN_TIME = 0.2f;
	private float _timer = 0;
	private bool _bSpwan = false;

	public void StartSpwan()
	{
		_bSpwan = true;
	}
	
	private void FixedUpdate()
	{
		if (!_bSpwan)
			return;
		
		_timer += Time.fixedDeltaTime;
		if (_timer >= SPAWN_TIME)
		{
			_timer = 0;
			CreateRandomObject();			
		}
	}

	private Vector2 GetRandomPosition()
	{
		return new Vector2(Random.Range(0, 1280) - 640,450);
	}

	private void CreateRandomObject()
	{
		string prefab_path = string.Empty;
		int type = Random.Range(0, 3);
		if (type <= 1)
		{
			prefab_path = ETag.Apple.ToString();
		}
		else if (type == 2)
		{
			prefab_path = ETag.Bomb.ToString();
		}

		GameObject go = Instantiate(Resources.Load<GameObject>("Prefab/" + prefab_path));
		go.transform.SetParent(this.transform);
		go.transform.localPosition = GetRandomPosition();
		go.name = prefab_path;
	}
}
