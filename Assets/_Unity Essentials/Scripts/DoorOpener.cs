using UnityEngine;

public class DoorOpener : MonoBehaviour
{
    // Ѕуло animator, м≥н€Їмо на doorAnimator
    private Animator doorAnimator;

    void Start()
    {
        // “епер ц€ назва сп≥впадаЇ з оголошеною вище
        doorAnimator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (doorAnimator != null)
            {
                doorAnimator.SetTrigger("Open");
            }
        }
    }
}