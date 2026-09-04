using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float scroll = 0.15f;
    public float moveSpeed = 5f;
    public Transform player;
    public ParticleSystem hitParticle; // パーティクルプレハブをInspectorでアサイン
    private Animator animator; // Animator参照用

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float speed = 0f;

        if (player != null)
        {
            Vector3 direction = (player.position - transform.position).normalized;
            Vector3 movement = direction * moveSpeed * Time.deltaTime;
            transform.Translate(movement, Space.World);

            speed = movement.magnitude / Time.deltaTime; // 実際の速度
        }

        if (animator != null)
        {
            animator.SetFloat("EnemySpeed", speed); // Speedパラメータに速度をセット
        }

        if (transform.position.x < -15f)
        {
            Destroy(this.gameObject);
        }
    }

    // 攻撃判定との当たり判定
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Attack"))
        {
            if (hitParticle != null)
            {
                // パーティクルを敵の位置に生成
                Instantiate(hitParticle, transform.position, Quaternion.identity);
            }
            Destroy(this.gameObject); // 敵を消す場合
        }
    }
}