using UnityEngine;

public class PlaySoundOnAnimation : StateMachineBehaviour
{
    private AudioSource audioSource;
    public AudioClip soundClip; //パンチかキック

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (audioSource == null)
        {
            audioSource = animator.GetComponent<AudioSource>();
        }

        if (audioSource != null && soundClip != null)
        {
            audioSource.PlayOneShot(soundClip);
        }
    }
}
