using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class OpenDoorScript : MonoBehaviour
{
    public PlayableDirector m_openDoor;
    public GameObject treasureChest;
    public Sprite closetreasureChestSprite;
    public Sprite opentreasureChestSprite;

    void Start()
    {
        Interaction.ForestopenDoor = false;
    }

    void Update()
    {
        if(Interaction.ForestopenDoor == true)
        {
            m_openDoor.Play();
            treasureChest.GetComponent<SpriteRenderer>().sprite = opentreasureChestSprite;
        }
    }
}
