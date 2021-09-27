using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{ 
    //Scnen Transition
    void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.gameObject.tag)
        {
            //Forest
            case "FoLeft":
                SceneManager.LoadScene("Forest1");
                gameObject.transform.position = new Vector3(8.5f, -5.5f, -1);
                break;
            case "FoRight":
                SceneManager.LoadScene("Forest2");
                gameObject.transform.position = new Vector3(8.5f, 5.5f, -1);
                break;
            case "GoForestDg":
                SceneManager.LoadScene("Forest Dungeon");
                gameObject.transform.position = new Vector3(0.5f, -3.4f, -1);
                break;
            case "OutForestDg":
                SceneManager.LoadScene("Forest2");
                gameObject.transform.position = new Vector3(-6.5f, 0.9f, -1);
                break;


            //Ocene
            case "GoForest":
                SceneManager.LoadScene("Forest2");
                gameObject.transform.position = new Vector3(9, -5, -1);
                break;
            case "GoOcene":
                SceneManager.LoadScene("Ocene1");
                gameObject.transform.position = new Vector3(-7.5f, -4.2f, -1);
                break;
            case "OcLeft":
                SceneManager.LoadScene("Ocene1");
                gameObject.transform.position = new Vector3(7f, -5.5f, -1);
                break;
            case "OcRight":
                SceneManager.LoadScene("Ocene2");
                gameObject.transform.position = new Vector3(7f, 5.5f, -1);
                break;
            case "GoOceneDg":
                SceneManager.LoadScene("Ice Dungeon");
                gameObject.transform.position = new Vector3(0.5f, -3.4f, -1);
                break;
            case "OutOceneDg":
                SceneManager.LoadScene("Ocene2");
                gameObject.transform.position = new Vector3(-5.5f, -3f, -1);
                break;

            //Desert
            case "BackOcene":
                SceneManager.LoadScene("Ocene2");
                gameObject.transform.position = new Vector3(8.9f, 0.1f, -1);
                break;
            case "GoDesert":
                SceneManager.LoadScene("Desert1");
                gameObject.transform.position = new Vector3(-9.2f, -2, -1);
                break;
            case "DeLeft":
                SceneManager.LoadScene("Desert1");
                gameObject.transform.position = new Vector3(6.5f, -5.5f, -1);
                break;
            case "DeRight":
                SceneManager.LoadScene("Desert2");
                gameObject.transform.position = new Vector3(6.5f, 5.5f, -1);
                break;
            case "GoDesertDg":
                SceneManager.LoadScene("Desert Dungeon");
                gameObject.transform.position = new Vector3(0.5f, -3.4f, -1);
                break;
            case "OutDesertDg":
                SceneManager.LoadScene("Desert2");
                gameObject.transform.position = new Vector3(-5.5f, -3.2f, -1);
                break;

            //House
            case "GoHouse":
                SceneManager.LoadScene("House");
                gameObject.transform.position = new Vector3(2.2f, -4.3f, -1);
                break;
            case "ExitHouse":
                SceneManager.LoadScene("Forest1");
                gameObject.transform.position = new Vector3(-2.3f, 0.5f, -1);
                break;

            //Igloo
            case "GoIgloo":
                SceneManager.LoadScene("House");
                gameObject.transform.position = new Vector3(0.05f, -3.3f, -1);
                break;
            case "ExitIgloo":
                SceneManager.LoadScene("Ocene1");
                gameObject.transform.position = new Vector3(6.8f, -1.5f, -1);
                break;

            //Tent
            case "GoTent":
                SceneManager.LoadScene("House");
                gameObject.transform.position = new Vector3(0.05f, -3.3f, -1);
                break;
            case "ExitTent":
                SceneManager.LoadScene("Desert1");
                gameObject.transform.position = new Vector3(-7.8f, -1.5f, -1);
                break;


        }
    }
}
