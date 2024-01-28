using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public bool canDoInOnePlace = true;
    public float timeMin = 1f;
    public float timeMax = 2f;
    public GameObject [] enemies;
    Vector3 whereCreate;
    Vector3 tempVector;

    void Start()
    {
        CreateEnemy();
    }

    void CreateEnemy()
    {
        tempVector = transform.position;
        if (canDoInOnePlace)
        {
            int index = Random.Range(0, enemies.Length);
            if(enemies[index].GetComponent<EnemyMoving>().leftPositionForSpawn != -3)
            {
                Instantiate(
                enemies[index],
                new Vector3(-2.5f + Random.Range(0,5), transform.position.y, transform.position.z),
                enemies[index].transform.rotation);
            }
            else
                Instantiate(
                enemies[index],
                new Vector3(
                    Random.Range(
                        enemies[index].GetComponent<EnemyMoving>().leftPositionForSpawn,
                        enemies[index].GetComponent<EnemyMoving>().rightPositionForSpawn),
                    transform.position.y, transform.position.z),
                enemies[index].transform.rotation);
        }
        else if(tempVector != whereCreate)
        {
            int index = Random.Range(0, enemies.Length);

            Instantiate(
                enemies[index], transform.position, enemies[index].transform.rotation);

            whereCreate = tempVector;
        }
        Invoke(nameof(CreateEnemy), Random.Range(timeMin, timeMax));
    }
}