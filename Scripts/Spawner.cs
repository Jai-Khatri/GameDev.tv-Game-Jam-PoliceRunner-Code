using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
    [SerializeField] Transform SpawnPosition; //Transform where the level will be spawned
    [SerializeField] GameObject NextLevel; //The next level GAMEOBJECT to spawn
     float Delay = 18; //Time untill the level disappers(So that the game doesn't become unplayable because of lag)
    [SerializeField] Death death;
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Instantiate(NextLevel, SpawnPosition.position, Quaternion.identity); //Spawning the nextLevel gameobject

            if(death.IsDead == true)
            {
                return; 
            }
            else
            {
                Destroy(NextLevel, Delay);
            }
           
          
        }
    }
}
