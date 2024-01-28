using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Moving : MonoBehaviour {

    readonly float timeStep = 1f;
    float timeTotal = 0f;
    float timePast = 0f;
    float tCurves;
    Vector3 startPosition;

    readonly float speedRotation = 0.35f;
    Quaternion directionRotation;

    readonly float speed = 8f;
    readonly Vector3 rightUp = new Vector3(0.5f, 1.7f, 0f);
    readonly Vector3 rightDown = new Vector3(0.5f, -1.7f, 0f);
    readonly Vector3 leftUp = new Vector3(-0.5f, 1.7f, 0f);
    readonly Vector3 leftDown = new Vector3(-0.5f, -1.7f, 0f);
    readonly Vector3 forwardUp = new Vector3(0f, 2.2f, 0.6f);
    readonly Vector3 forwardDown = new Vector3(0f, -1.2f, 0.4f);
    readonly Vector3 forwardUpWhenHigh = new Vector3(0f, 1f, 1f);

    AudioSource audioSource;

    Vector3 positionToGOUp;
    Vector3 positionToGoDown;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        positionToGOUp = transform.position;
        positionToGoDown = transform.position;
    }

    void Update()
    {
        if
            (Input.GetKeyDown(KeyCode.D))
        {
            MoveRight();
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            MyEventManager.CallIncreaseScore();
            MoveUp();
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            MoveLeft();
        }
    }

    private void FixedUpdate()
    {
        if (timeTotal != 0)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, directionRotation, speedRotation);
            timePast += Time.fixedDeltaTime;

            tCurves = speed * timePast / timeTotal;

            if (tCurves > 1f)
            {
                tCurves = 1f;
            }
            float x = (1 - tCurves) * (1 - tCurves) * startPosition.x +
                2 * (1 - tCurves) * tCurves * positionToGOUp.x +
                tCurves * tCurves * positionToGoDown.x;
            float y = (1 - tCurves) * (1 - tCurves) * startPosition.y +
                2 * (1 - tCurves) * tCurves * positionToGOUp.y +
                tCurves * tCurves * positionToGoDown.y;
            float z = (1 - tCurves) * (1 - tCurves) * startPosition.z +
                2 * (1 - tCurves) * tCurves * positionToGOUp.z +
                tCurves * tCurves * positionToGoDown.z;

            transform.Translate(new Vector3(x, y, z) - transform.position, Space.World);

            if (tCurves == 1f)
            {
                timeTotal = 0f;
                timePast = 0f;
                positionToGOUp = transform.position;
                positionToGoDown = transform.position;
            }
        }
    }
    public void MoveRight()
    {
        audioSource.Play();
        directionRotation = Quaternion.Euler(new Vector3(0f, 90f, 0f));

        timeTotal += timeStep - timePast;
        timePast = 0f;
        startPosition = transform.position;
        
        if(tCurves >= 0.5f)
        {
            positionToGOUp = transform.position + rightUp;
        }
        else
            positionToGOUp += rightUp;
       
        positionToGoDown += rightUp + rightDown;
    }

    public void MoveLeft()
    {
        audioSource.Play();
        directionRotation = Quaternion.Euler(new Vector3(0f, -90f, 0f));

        timeTotal += timeStep - timePast;
        timePast = 0f;
        startPosition = transform.position;

        if (tCurves >= 0.5f)
        {
            positionToGOUp = transform.position + leftUp;
        }
        else
            positionToGOUp += leftUp;

        positionToGoDown += leftUp + leftDown;
    }

    public void MoveUp()
    {
        audioSource.Play();
        directionRotation = Quaternion.Euler(Vector3.zero);

        timeTotal += timeStep - timePast;
        timePast = 0f;
        startPosition = transform.position;

        if (Physics.Raycast(transform.position, Vector3.down, 0.75f))
        {
            if (positionToGOUp == Vector3.zero)
                positionToGOUp = transform.position;

            if (tCurves >= 0.7f)
            {
                positionToGOUp = transform.position + forwardUp;
            }
            else
                positionToGOUp += forwardUp;

            positionToGoDown += forwardUp + forwardDown;
        }
        else
        {
            positionToGOUp += forwardUpWhenHigh;
            positionToGoDown += forwardUpWhenHigh;
        }
    }
}