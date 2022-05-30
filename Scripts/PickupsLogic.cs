using UnityEngine;
using System.Collections;
using TMPro;

public class PickupsLogic : MonoBehaviour
{
    public int StarsCollected;
    [SerializeField] TextMeshProUGUI NumberofStarsCollected;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip StarSound;
    [SerializeField] ParticleSystem PickupParticle;
 
    public void WhenStarCollected()
    {
        StarsCollected++;
        audioSource.PlayOneShot(StarSound);
        PickupParticle.Play();
        NumberofStarsCollected.text = StarsCollected.ToString();

    }
}
