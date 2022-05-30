using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    [SerializeField] private Animator animator; //Refeence to the player Animtor.
    [SerializeField] PlayerMovement Playermovement; //Reference to the playermovement script so that we can change the IsAlive bool in the script.
    [SerializeField] private AudioSource audioSource; //Reference to the audio source.
    [SerializeField] private AudioClip DeathSound; //Reference to the death sound clip
    [SerializeField] private Transform ParticleSpawner; //Reference to the ParticleSpawner(Where the particle spawns) 
    [SerializeField] private ParticleSystem Deathparticle; //reference to the particleSystem to Instantiate.
    [SerializeField] GameObject DeathCanvas; //Reference to the canvas which contains our restart button and Main menu button.
    public bool IsDead;

    [SerializeField] AudioSource BGMusicAudioSource;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle")) //Checks for any object tagged as "Obstacle".'
        {
            IsDead = true;
            BGMusicAudioSource.Stop();
            audioSource.PlayOneShot(DeathSound); //PLays the DeathSound
            Instantiate(Deathparticle, ParticleSpawner.position, Quaternion.identity); //Instantiates the DeathParticle at the ParticleSpawner which is near player.

            if (Playermovement.IsGrounded())// Checks if player is on the ground.
            {
                animator.SetBool("Dying", true); //Sets the animator "Dying" bool to true which plays the dying animation
                Playermovement.IsAlive = false; //Sets the IsAlive bool to false in the PlayerMovement script.
            }
            else if (!Playermovement.IsGrounded()) //If the player is not on the ground which means it is in the air then 
            {
                animator.SetBool("IsFalling", false); //Sets the animator bool "IsFalling" to false;
                animator.SetBool("Dying", true); //Sets the animator bool "Dying" to true
                Playermovement.IsAlive = false; //Sets the "IsAlive" bool to false in the playerMovement Script so it stops the movement;
            }

            DeathCanvas.SetActive(true); //Sets Death canvas active so that the player can restart or go to the main menu.
          
            
        }
    }
}
