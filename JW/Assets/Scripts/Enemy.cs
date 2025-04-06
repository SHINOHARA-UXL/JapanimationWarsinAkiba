using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public AudioClip deathSound;  // 死亡時の音
    private AudioSource audioSource;  // AudioSource

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        // AudioSourceが存在しない場合にエラーメッセージを出す
        if (audioSource == null)
        {
            Debug.LogError("AudioSourceが見つかりません。");
        }

        // 死亡音が設定されていない場合に警告
        if (deathSound == null)
        {
            Debug.LogWarning("deathSoundが設定されていません！");
        };
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public int pointValue = 100; // 倒した時のスコア

    void OnDestroy()
    {
        audioSource.PlayOneShot(deathSound);
        if (ScoreControler.instance != null)
        {
            ScoreControler.instance.AddScore(pointValue);
        }
    }

    // 敵が倒される処理（例）
    public void TakeDamage()
    {
        
        Debug.Log("Play");
        //Destroy(gameObject); // 敵を削除
    }

}
