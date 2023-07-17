using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialOpenDoor : MonoBehaviour
{
    [SerializeField] EnterDoor openDoor;

    private void Start()
    {
        openDoor.OpenDoor();
    }
}
