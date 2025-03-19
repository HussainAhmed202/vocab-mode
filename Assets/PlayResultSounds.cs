using UnityEngine;

public class PlayResultSounds : MonoBehaviour
{
   public AudioSource audioSource;
    public AudioClip victoryClip;
    public AudioClip defeatClip;

    public void PlayVictorySound()
    {
        audioSource.clip = victoryClip;
        audioSource.Play();
    }

    public void PlayDefeatSound()
    {
        audioSource.clip = defeatClip;
        audioSource.Play();
    }
}
