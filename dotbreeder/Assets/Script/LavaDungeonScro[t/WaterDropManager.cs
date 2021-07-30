using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDropManager : MonoBehaviour
{
    private bool nonWaterDrop;
    public GameObject waterDropBlue_gameObjcet;
    public GameObject waterDropBrown_gameObjcet;
    public GameObject waterDropGreen_gameObjcet;
    public GameObject waterDropOrange_gameObjcet;
    public GameObject waterDropWhite_gameObjcet;
    Stack<GameObject> goStack;
    public bool isLavaDungeonClear;
    public GameObject SqureBluePrefab;
    public GameObject SqureBrownPrefab;
    public GameObject SqureGreenPrefab;
    public GameObject SqureOrangePrefab;
    public GameObject Plate;//target
    private float waitTimeBlue;
    private float waitTimeBrown;
    private float waitTimeGreen;
    private float waitTimeOrange;
    private float waitTimeWhite;
    private bool isWaitBlue;
    private bool isWaitBrown;
    private bool isWaitGreen;
    private bool isWaitOrange;
    private bool isWaitWhite;
    public GameObject nonActivePortal;
    public GameObject ActivePortal;
    private void Start()
    {
        nonWaterDrop = false;
        goStack = new Stack<GameObject>();
        isLavaDungeonClear = false;
        isWaitBlue = false;
        isWaitBrown = false;
        isWaitGreen = false;
        isWaitOrange = false;
        isWaitWhite = false;
        nonActivePortal.SetActive(true);
        ActivePortal.SetActive(false);
    }
    private void FixedUpdate()
    {
        if (isLavaDungeonClear == false)
        {
            //todo 파란색 블럭 쌓는 부분
            if (goStack.Count == 0 && WaterDropBlue.isConectWaterDropBlue == true && isWaitBlue == false)
            {   //Instantiate하고 크기 조정하고 스택에 넣는 내용
                GameObject obj = Instantiate(SqureBluePrefab, new Vector2(Plate.transform.position.x, Plate.transform.position.y + 0.6f), Quaternion.identity, Plate.transform);
                obj.transform.localScale = new Vector3(0.8f, 0.2f, 1.0f);
                goStack.Push(obj);
                isWaitBlue = true;
                waitTimeBlue = 2.2f;
            }
            if (goStack.Count == 1 && WaterDropBlue.isConectWaterDropBlue == true && isWaitBlue == false)
            {
                GameObject obj = Instantiate(SqureBluePrefab, new Vector2(Plate.transform.position.x, Plate.transform.position.y + 0.8f), Quaternion.identity, Plate.transform);
                obj.transform.localScale = new Vector3(0.6f, 0.2f, 1.0f);
                goStack.Push(obj);
                isWaitBlue = true;
                waitTimeBlue = 2.2f;
            }
            if (goStack.Count == 2 && WaterDropBlue.isConectWaterDropBlue == true && isWaitBlue == false)
            {
                GameObject obj = Instantiate(SqureBluePrefab, new Vector2(Plate.transform.position.x, Plate.transform.position.y + 1.0f), Quaternion.identity, Plate.transform);
                obj.transform.localScale = new Vector3(0.4f, 0.2f, 1.0f);
                goStack.Push(obj);
                isWaitBlue = true;
                waitTimeBlue = 2.2f;
            }
            if (goStack.Count == 3 && WaterDropBlue.isConectWaterDropBlue == true && isWaitBlue == false)
            {
                GameObject obj = Instantiate(SqureBluePrefab, new Vector2(Plate.transform.position.x, Plate.transform.position.y + 1.2f), Quaternion.identity, Plate.transform);
                obj.transform.localScale = new Vector3(0.2f, 0.2f, 1.0f);
                goStack.Push(obj);
                isWaitBlue = true;
                waitTimeBlue = 2.2f;
            }
            //todo 갈색 블럭 쌓는 부분
            if (goStack.Count == 0 && WaterDropBrown.isConectWaterDropBrown == true && isWaitBrown == false)
            {   //Instantiate하고 크기 조정하고 스택에 넣는 내용
                GameObject obj = Instantiate(SqureBrownPrefab, new Vector2(Plate.transform.position.x, Plate.transform.position.y + 0.6f), Quaternion.identity, Plate.transform);
                obj.transform.localScale = new Vector3(0.8f, 0.2f, 1.0f);
                goStack.Push(obj);
                isWaitBrown = true;
                waitTimeBrown = 0.9f;
            }
            if (goStack.Count == 1 && WaterDropBrown.isConectWaterDropBrown == true && isWaitBrown == false)
            {
                GameObject obj = Instantiate(SqureBrownPrefab, new Vector2(Plate.transform.position.x, Plate.transform.position.y + 0.8f), Quaternion.identity, Plate.transform);
                obj.transform.localScale = new Vector3(0.6f, 0.2f, 1.0f);
                goStack.Push(obj);
                isWaitBrown = true;
                waitTimeBrown = 0.9f;
            }
            if (goStack.Count == 2 && WaterDropBrown.isConectWaterDropBrown == true && isWaitBrown == false)
            {
                GameObject obj = Instantiate(SqureBrownPrefab, new Vector2(Plate.transform.position.x, Plate.transform.position.y + 1.0f), Quaternion.identity, Plate.transform);
                obj.transform.localScale = new Vector3(0.4f, 0.2f, 1.0f);
                goStack.Push(obj);
                isWaitBrown = true;
                waitTimeBrown = 0.9f;
            }
            if (goStack.Count == 3 && WaterDropBrown.isConectWaterDropBrown == true && isWaitBrown == false)
            {
                GameObject obj = Instantiate(SqureBrownPrefab, new Vector2(Plate.transform.position.x, Plate.transform.position.y + 1.2f), Quaternion.identity, Plate.transform);
                obj.transform.localScale = new Vector3(0.2f, 0.2f, 1.0f);
                goStack.Push(obj);
                isWaitBrown = true;
                waitTimeBrown = 0.9f;
            }
            //todo 초록색 블럭 쌓는 부분
            if (goStack.Count == 0 && WaterDropGreen.isConectWaterDropGreen == true && isWaitGreen == false)
            {   //Instantiate하고 크기 조정하고 스택에 넣는 내용
                GameObject obj = Instantiate(SqureGreenPrefab, new Vector2(Plate.transform.position.x, Plate.transform.position.y + 0.6f), Quaternion.identity, Plate.transform);
                obj.transform.localScale = new Vector3(0.8f, 0.2f, 1.0f);
                goStack.Push(obj);
                isWaitGreen = true;
                waitTimeGreen = 1.7f;
            }
            if (goStack.Count == 1 && WaterDropGreen.isConectWaterDropGreen == true && isWaitGreen == false)
            {
                GameObject obj = Instantiate(SqureGreenPrefab, new Vector2(Plate.transform.position.x, Plate.transform.position.y + 0.8f), Quaternion.identity, Plate.transform);
                obj.transform.localScale = new Vector3(0.6f, 0.2f, 1.0f);
                goStack.Push(obj);
                isWaitGreen = true;
                waitTimeGreen = 1.7f;
            }
            if (goStack.Count == 2 && WaterDropGreen.isConectWaterDropGreen == true && isWaitGreen == false)
            {
                GameObject obj = Instantiate(SqureGreenPrefab, new Vector2(Plate.transform.position.x, Plate.transform.position.y + 1.0f), Quaternion.identity, Plate.transform);
                obj.transform.localScale = new Vector3(0.4f, 0.2f, 1.0f);
                goStack.Push(obj);
                isWaitGreen = true;
                waitTimeGreen = 1.7f;
            }
            if (goStack.Count == 3 && WaterDropGreen.isConectWaterDropGreen == true && isWaitGreen == false)
            {
                GameObject obj = Instantiate(SqureGreenPrefab, new Vector2(Plate.transform.position.x, Plate.transform.position.y + 1.2f), Quaternion.identity, Plate.transform);
                obj.transform.localScale = new Vector3(0.2f, 0.2f, 1.0f);
                goStack.Push(obj);
                isWaitGreen = true;
                waitTimeGreen = 1.7f;
            }
            //todo 주황색 블럭 쌓는 부분
            if (goStack.Count == 0 && WaterDropOrange.isConectWaterDropOrange == true && isWaitOrange == false)
            {   //Instantiate하고 크기 조정하고 스택에 넣는 내용
                GameObject obj = Instantiate(SqureOrangePrefab, new Vector2(Plate.transform.position.x, Plate.transform.position.y + 0.6f), Quaternion.identity, Plate.transform);
                obj.transform.localScale = new Vector3(0.8f, 0.2f, 1.0f);
                goStack.Push(obj);
                isWaitOrange = true;
                waitTimeOrange = 1.2f;
            }
            if (goStack.Count == 1 && WaterDropOrange.isConectWaterDropOrange == true && isWaitOrange == false)
            {
                GameObject obj = Instantiate(SqureOrangePrefab, new Vector2(Plate.transform.position.x, Plate.transform.position.y + 0.8f), Quaternion.identity, Plate.transform);
                obj.transform.localScale = new Vector3(0.6f, 0.2f, 1.0f);
                goStack.Push(obj);
                isWaitOrange = true;
                waitTimeOrange = 1.2f;
            }
            if (goStack.Count == 2 && WaterDropOrange.isConectWaterDropOrange == true && isWaitOrange == false)
            {
                GameObject obj = Instantiate(SqureOrangePrefab, new Vector2(Plate.transform.position.x, Plate.transform.position.y + 1.0f), Quaternion.identity, Plate.transform);
                obj.transform.localScale = new Vector3(0.4f, 0.2f, 1.0f);
                goStack.Push(obj);
                isWaitOrange = true;
                waitTimeOrange = 1.2f;
            }
            if (goStack.Count == 3 && WaterDropOrange.isConectWaterDropOrange == true && isWaitOrange == false)
            {
                GameObject obj = Instantiate(SqureOrangePrefab, new Vector2(Plate.transform.position.x, Plate.transform.position.y + 1.2f), Quaternion.identity, Plate.transform);
                obj.transform.localScale = new Vector3(0.2f, 0.2f, 1.0f);
                goStack.Push(obj);
                isWaitOrange = true;
                waitTimeOrange = 1.2f;
            }
            //todo 하얀색 물방울
            //todo 쌓인 블럭을 없애는 부분
            if (!(goStack.Count == 0) && WaterDropWhite.isConectWaterDropWhite == true && isWaitWhite == false)
            {
                //goStack.Pop();
                GameObject destroyMe = goStack.Pop();
                Destroy(destroyMe);
                isWaitWhite = true;
                waitTimeWhite = 1.4f;
            }

            //먄약 첫번째 블럭이 파란색, 두번째 블럭이 갈색, 세번째 블럭이 초록색, 네번째 블럭이 주황색이라면 isLavaDungeonClear를 true로 하고 포탈을 활성화한다.
            if (goStack.Count == 4)
            {
                Stack<GameObject> goStackCopy = new Stack<GameObject>(goStack.ToArray());
                if (goStackCopy.Pop().CompareTag("SqureBlue"))
                {
                    if (goStackCopy.Pop().CompareTag("SqureBrown"))
                    {
                        if (goStackCopy.Pop().CompareTag("SqureGreen"))
                        {
                            if (goStackCopy.Pop().CompareTag("SqureOrange"))
                            {
                                isLavaDungeonClear = true;
                                nonWaterDrop = true;
                            }
                        }
                    }
                }
            }
            if (!isLavaDungeonClear)
            {
                nonActivePortal.SetActive(true);
                ActivePortal.SetActive(false);
            }
            else
            {
                nonActivePortal.SetActive(false);
                ActivePortal.SetActive(true);
            }
            //Debug.Log("스택 갯수 :" + goStack.Count);
            WaitTimer();
        }
        if (nonWaterDrop)
        {
            waterDropBlue_gameObjcet.SetActive(false);
            waterDropBrown_gameObjcet.SetActive(false);
            waterDropGreen_gameObjcet.SetActive(false);
            waterDropOrange_gameObjcet.SetActive(false);
            waterDropWhite_gameObjcet.SetActive(false);
        }
        StartCoroutine("WaterDropBrownTimeController");
        StartCoroutine("WaterDropBlueTimeController");
        StartCoroutine("WaterDropGreenTimeController");
        StartCoroutine("WaterDropOrangeTimeController");
        StartCoroutine("WaterDropWhiteTimeController");
    }
    public void WaitTimer()
    {
        //todo 파란색 물방울 부딪히고 다시 부딪히는 시간관리 부분
        if (isWaitBlue == true)
        {
            if (waitTimeBlue >= 0)
                waitTimeBlue -= Time.deltaTime;
            if (waitTimeBlue <= 0)
                isWaitBlue = false;
        }
        //todo 갈색 물방울 부딪히고 다시 부딪히는 시간관리 부분
        if (isWaitBrown == true)
        {
            if (waitTimeBrown >= 0)
                waitTimeBrown -= Time.deltaTime;
            if (waitTimeBrown <= 0)
                isWaitBrown = false;
        }
        //todo 초록색 물방울 부딪히고 다시 부딪히는 시간관리 부분
        if (isWaitGreen == true)
        {
            if (waitTimeGreen >= 0)
                waitTimeGreen -= Time.deltaTime;
            if (waitTimeGreen <= 0)
                isWaitGreen = false;
        }
        //todo 주황색 물방울 부딪히고 다시 부딪히는 시간관리 부분
        if (isWaitOrange == true)
        {
            if (waitTimeOrange >= 0)
                waitTimeOrange -= Time.deltaTime;
            if (waitTimeOrange <= 0)
                isWaitOrange = false;
        }
        //todo 하얀색 물방울 부딪히고 다시 부딪히는 시간관리 부분
        if (isWaitWhite == true)
        {
            if (waitTimeWhite >= 0)
                waitTimeWhite -= Time.deltaTime;
            if (waitTimeWhite <= 0)
                isWaitWhite = false;
        }
    }
    IEnumerator WaterDropBlueTimeController()
    {
        if (WaterDropBlue.waterDropBlue_unVisibleTime > 0)
        {
            waterDropBlue_gameObjcet.gameObject.SetActive(false);
            WaterDropBlue.waterDropBlue_unVisibleTime -= Time.deltaTime;
        }
        else
        {
            waterDropBlue_gameObjcet.gameObject.SetActive(true);
        }
        yield return new WaitForFixedUpdate();
    }
    IEnumerator WaterDropBrownTimeController()
    {
        if (WaterDropBrown.waterDropBrown_unVisibleTime > 0)
        {
            waterDropBrown_gameObjcet.gameObject.SetActive(false);
            WaterDropBrown.waterDropBrown_unVisibleTime -= Time.deltaTime;
        }
        else
        {
            waterDropBrown_gameObjcet.gameObject.SetActive(true);
        }
        yield return new WaitForFixedUpdate();
    }
    IEnumerator WaterDropGreenTimeController()
    {
        if (WaterDropGreen.waterDropGreen_unVisibleTime > 0)
        {
            waterDropGreen_gameObjcet.gameObject.SetActive(false);
            WaterDropGreen.waterDropGreen_unVisibleTime -= Time.deltaTime;
        }
        else
        {
            waterDropGreen_gameObjcet.gameObject.SetActive(true);
        }
        yield return new WaitForFixedUpdate();
    }
    IEnumerator WaterDropOrangeTimeController()
    {
        if (WaterDropOrange.waterDropOrange_unVisibleTime > 0)
        {
            waterDropOrange_gameObjcet.gameObject.SetActive(false);
            WaterDropOrange.waterDropOrange_unVisibleTime -= Time.deltaTime;
        }
        else
        {
            waterDropOrange_gameObjcet.gameObject.SetActive(true);
        }
        yield return new WaitForFixedUpdate();
    }
    IEnumerator WaterDropWhiteTimeController()
    {
        if (WaterDropWhite.waterDropWhite_unVisibleTime > 0)
        {
            waterDropWhite_gameObjcet.gameObject.SetActive(false);
            WaterDropWhite.waterDropWhite_unVisibleTime -= Time.deltaTime;
        }
        else
        {
            waterDropWhite_gameObjcet.gameObject.SetActive(true);
        }
        yield return new WaitForFixedUpdate();
    }
}
