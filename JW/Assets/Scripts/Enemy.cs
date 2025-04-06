using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public AudioClip deathSound;  // ���S���̉�
    private AudioSource audioSource;  // AudioSource

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        // AudioSource�����݂��Ȃ��ꍇ�ɃG���[���b�Z�[�W���o��
        if (audioSource == null)
        {
            Debug.LogError("AudioSource��������܂���B");
        }

        // ���S�����ݒ肳��Ă��Ȃ��ꍇ�Ɍx��
        if (deathSound == null)
        {
            Debug.LogWarning("deathSound���ݒ肳��Ă��܂���I");
        };
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public int pointValue = 100; // �|�������̃X�R�A

    void OnDestroy()
    {
        audioSource.PlayOneShot(deathSound);
        if (ScoreControler.instance != null)
        {
            ScoreControler.instance.AddScore(pointValue);
        }
    }

    // �G���|����鏈���i��j
    public void TakeDamage()
    {
        
        Debug.Log("Play");
        //Destroy(gameObject); // �G���폜
    }

}
