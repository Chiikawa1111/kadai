using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject spawnObject;
    public float interval = 2f;

    public Transform player;

    // 3D空間でのランダム範囲
    public float spawnRangeY = 2f;
    public float spawnRangeZ = 2f;

    void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        while (true)
        {
            float y = player.position.y + Random.Range(-spawnRangeY, spawnRangeY);
            float z = player.position.z + Random.Range(-spawnRangeZ, spawnRangeZ);

            Vector3 pos = new Vector3(
                transform.position.x,
                y,
                z
            );

            GameObject obj = Instantiate(spawnObject, pos, Quaternion.identity);
            obj.SetActive(true); // 生成直後にアクティブ化

            yield return new WaitForSeconds(interval);
        }
    }
}