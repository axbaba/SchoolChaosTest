using UnityEngine;
using TMPro;

public class ChairInteraction : MonoBehaviour
{
    public Transform seatPoint;
    public TextMeshProUGUI interactText;
    public PlayerController playerController;

    private bool playerNear = false;
    private bool isSitting = false;

    void Start()
    {
        if (interactText != null)
            interactText.gameObject.SetActive(false);
    }

    void Update()
    {
        if (playerNear && Input.GetKeyDown(KeyCode.E))
        {
            if (!isSitting)
                Sit();
            else
                StandUp();
        }
    }

void Sit()
{
    isSitting = true;

    Transform player = playerController.transform;
    playerController.canMove = false;

    player.position = seatPoint.position + Vector3.up * 0.25f;
    player.rotation = seatPoint.rotation;
    playerController.ResetLook();

    interactText.text = "E - Kalk";
    interactText.gameObject.SetActive(true);
}

void StandUp()
{
    isSitting = false;

    Transform player = playerController.transform;
    player.position = seatPoint.position - seatPoint.forward * 1.2f + Vector3.up * 0.8f;

    playerController.canMove = true;

    interactText.text = "E - Otur";
}

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNear = true;
            interactText.text = "E - Otur";
            interactText.gameObject.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && !isSitting)
        {
            playerNear = false;
            interactText.gameObject.SetActive(false);
        }
    }
}