using UnityEngine;

public class EnemysAttack : MonoBehaviour
{
    [SerializeField] GameObject ballPrefab; // 玉のプレハブ
    [SerializeField] Transform firePoint;         // 発射位置
    private float fireForce = 15f;       // 発射力
    private float fireInterval = 1.0f;     // 発射間隔

    private float fireTimer;

    void Update()
    {
        fireTimer += Time.deltaTime;

        if (fireTimer >= fireInterval)
        {
            Fire();
            fireTimer = 0f;
        }
    }

    public void Fire()
    {
        // 敵の前方にずらした位置に生成
        Vector3 spawnPos = transform.position + transform.forward * 1.0f;
        spawnPos.y += 1.0f;
        GameObject ball = Instantiate(ballPrefab, spawnPos, transform.rotation);

        // Rigidbody に前方への力を加える
        Rigidbody rb = ball.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(transform.forward * fireForce, ForceMode.Impulse);
        }

        Destroy(ball,4.0f);
    }


}