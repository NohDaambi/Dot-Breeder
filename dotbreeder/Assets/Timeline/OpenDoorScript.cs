using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class OpenDoorScript : MonoBehaviour
{
    public PlayableDirector m_openDoor;

    void Start()
    {
        Interaction.openDoor = false;
    }

    // Update is called once per frame
    void Update()
    {
        //
        if(Interaction.openDoor == true)
        {
            m_openDoor.Play();
        }
    }
}
