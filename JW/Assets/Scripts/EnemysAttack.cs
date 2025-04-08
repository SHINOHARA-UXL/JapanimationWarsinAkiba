using UnityEngine;

public class EnemysAttack : MonoBehaviour
{
    [SerializeField] GameObject ballPrefab;
    [SerializeField] Transform firePoint; 
    private float fireForce = 15f;
    private float fireInterval = 1.0f;

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
        // �G�̑O���ɂ��炵���ʒu�ɐ����@����������
        Vector3 spawnPos = transform.position + transform.forward * 1.0f;
        spawnPos.y += 1.0f;
        GameObject ball = Instantiate(ballPrefab, spawnPos, transform.rotation);

        Rigidbody rb = ball.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(transform.forward * fireForce, ForceMode.Impulse);
        }

        Destroy(ball,4.0f);
    }


}