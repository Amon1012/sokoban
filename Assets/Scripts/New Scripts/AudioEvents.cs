using UnityEngine;

public class AudioEvents : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip stepSfx;   
    public AudioClip pushSfx;   
    
    void BlockMoved(Vector2Int delta)
    {
        //see whos moving
        var caller = GetComponent<Block>();
        if (caller == null) return;

        if (caller is Player)
        {
            if (audioSource && stepSfx) audioSource.PlayOneShot(stepSfx);
        }
        else
        {
            if (audioSource && pushSfx) audioSource.PlayOneShot(pushSfx);
        }
    }
}