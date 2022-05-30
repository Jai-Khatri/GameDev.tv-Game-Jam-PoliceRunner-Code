using UnityEngine;
using UnityEngine.Events;

public class DetectingPickups : MonoBehaviour
{
    [SerializeField] UnityEvent CollectingStar;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Star"))
        {
            CollectingStar.Invoke();
            other.gameObject.SetActive(false);
        }
    }
}
