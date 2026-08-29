using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject spawnObject;
    public float interval = 2f;

    public Transform player;

    void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        while (true)
        {
            float y = player.position.y + Random.Range(-2f, 2f);

            Vector3 pos = new Vector3(
                transform.position.x,
                y,
                0
            );

            Instantiate(spawnObject, pos, Quaternion.identity);

            yield return new WaitForSeconds(interval);
        }
    }
}