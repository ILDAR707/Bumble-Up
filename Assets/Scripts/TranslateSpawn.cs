using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslateSpawn : MonoBehaviour
{
    public void SpawnTranslate()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z + 1f);
    }
}