using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float scroll = 0.15f;
    public float moveSpeed = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);


        if (transform.position.x < -15f)
        {
            Destroy(this.gameObject);
        }
    }
}