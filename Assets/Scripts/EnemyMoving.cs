using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class EnemyMoving : MonoBehaviour {
	
	public int leftPositionForSpawn;
	public int rightPositionForSpawn;
	public bool turn = false;
	public bool horizontal = false;
	bool goRight = true;

	public Vector3 rotationAngle = new Vector3(-90f, 0f, 0f);
	public float speed = 8f;

	public Vector3 forwardUp = new Vector3(0f, 0.8f, -0.5f);
	public Vector3 forwardDown = new Vector3(0f, -1.8f, -0.5f);

    Vector3 forwardUpWhenGoLeft;
    Vector3 forwardDownWhenGoLeft;

    float distanseMoving;
	Vector3 nextPosition;

	Vector3 positionToGOUp;
	Vector3 positionToGoDown;

	private void Start()
    {
        if (turn)
        {
			forwardUpWhenGoLeft = new Vector3(-forwardUp.x, forwardUp.y, forwardUp.z);
			forwardDownWhenGoLeft = new Vector3(-forwardDown.x, forwardDown.y, forwardDown.z);
		}
		distanseMoving = forwardUp.magnitude + forwardDown.magnitude;
		MoveUp();
    }
    private void FixedUpdate()
    {		
		if (transform.position != positionToGOUp && positionToGOUp != Vector3.zero)
        {
			nextPosition = Vector3.MoveTowards(transform.position, positionToGOUp, Time.fixedDeltaTime * speed);
			if(goRight)
				transform.Rotate(rotationAngle * ((nextPosition - transform.position).magnitude/distanseMoving),Space.World);			
			else
				transform.Rotate(- rotationAngle * ((nextPosition - transform.position).magnitude / distanseMoving), Space.World);

			transform.position = nextPosition;

			if (transform.position == positionToGOUp)
				positionToGOUp = Vector3.zero;
		}
		else if(transform.position != positionToGoDown && positionToGoDown != Vector3.zero)
        {
			nextPosition = Vector3.MoveTowards(transform.position, positionToGoDown, Time.fixedDeltaTime * speed);
			if (goRight)
				transform.Rotate(rotationAngle * ((nextPosition - transform.position).magnitude / distanseMoving), Space.World);
			else
				transform.Rotate(-rotationAngle * ((nextPosition - transform.position).magnitude / distanseMoving), Space.World);
			transform.position = nextPosition;

			if (transform.position == positionToGoDown)
            {
				positionToGoDown = Vector3.zero;
				if (turn && goRight)
					goRight = false;
				else if (turn && !goRight)
						goRight = true;

				MoveUp();
            }
        }		
	}
	public void MoveUp()
    {
		if(horizontal)
        {
			positionToGOUp = transform.position + forwardUp;
			positionToGoDown = transform.position + forwardUp + forwardDown;
		}
        else if (!turn)
        {
            positionToGOUp = transform.position + forwardUp;
            positionToGoDown = transform.position + forwardUp + forwardDown;
        }
		else if(turn && goRight)
        {
			positionToGOUp = transform.position + forwardUp;
			positionToGoDown = transform.position + forwardUp + forwardDown;
		}
		else if(turn && !goRight)
        {
			positionToGOUp = transform.position + forwardUpWhenGoLeft;
			positionToGoDown = transform.position + forwardUpWhenGoLeft + forwardDownWhenGoLeft;
		}       
    }
}