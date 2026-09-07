using UnityEngine;

public class TabletController : MonoBehaviour
{
    public GameObject tabletPanel;

    public bool IsTabletOpen { get; private set; }

    void Start()
    {
        IsTabletOpen = false;

        if (tabletPanel != null)
            tabletPanel.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            IsTabletOpen = !IsTabletOpen;

            if (tabletPanel != null)
                tabletPanel.SetActive(IsTabletOpen);
        }
    }
}