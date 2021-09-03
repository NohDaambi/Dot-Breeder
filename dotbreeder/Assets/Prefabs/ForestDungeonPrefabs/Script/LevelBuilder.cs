using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LevelElement {
    public string m_Character;
    public GameObject m_Prefab;
}

public class LevelBuilder : MonoBehaviour {
    public Camera m_camera;
    public static int m_CurrentLevel;
    public List<LevelElement> m_LevelElement;
    private Level m_Level;

    private void Update()
    {
        if(ForestDungeonScript.isForestDungeon1Clear == true)
        {
            m_CurrentLevel = 1;
        }
    }

    GameObject GetPrefab(char c) {
        LevelElement levelElement = m_LevelElement.Find(le => le.m_Character == c.ToString());
        if (levelElement != null) {
            return levelElement.m_Prefab;
        }
        else {
            return null;
        }
    }

    public void NextLevel() {
        m_CurrentLevel++;
        if (m_CurrentLevel >= GetComponent<Levels>().m_Levels.Count) {
            m_CurrentLevel = 0;
        }
    }

    public void Build() {
        m_Level = GetComponent<Levels>().m_Levels[m_CurrentLevel];
        if(m_CurrentLevel == 0)
        {
            m_camera.transform.position = new Vector3(0, 0, -10);
            m_camera.GetComponent<Camera>().orthographicSize = 5;
        }
        else if (m_CurrentLevel == 1)
        {
            m_camera.transform.position = new Vector3(0, -0.5f, -10);
            m_camera.GetComponent<Camera>().orthographicSize = 8;
        }
        //Offset coordinates so that centre of level is roughly at 0,0
        int startx = -m_Level.Whdth / 2;//Save start x since needs to be reset in loop
        int x = startx;
        int y = -m_Level.Height / 2;
        foreach (var row in m_Level.m_Rows)
        {
            foreach (var ch in row)
            {
            //Debug.Log(ch);
            GameObject prefab = GetPrefab(ch);
                if (prefab)
                {
                //Debug.Log(prefab.name);
                Instantiate(prefab, new Vector3(x,y,0), Quaternion.identity);
                }
                x++;
            }
            y++;
            x = startx;
        }
    }

}
