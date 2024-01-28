using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGoDown : MonoBehaviour
{
	readonly float speed = 40f;

	private void FixedUpdate()
	{
		transform.Translate(speed * Time.fixedDeltaTime * Vector3.down);
	}
}