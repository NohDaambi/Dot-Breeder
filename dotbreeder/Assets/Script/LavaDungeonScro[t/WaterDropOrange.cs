using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDropOrange : MonoBehaviour
{
    Animator waterDropCollisionAnimator;

    public bool isPlayerContactable;
    public bool isWaterDropExit;
    public static float waterDropOrange_unVisibleTime;
    public static bool isConectWaterDropOrange;
    private float orangeDelayTime;

    private void Awake() {
        waterDropCollisionAnimator = gameObject.GetComponent<Animator>();
    }
    private void Start() {
        waterDropOrange_unVisibleTime = 0;
        orangeDelayTime = 1.0f;
        isPlayerContactable = false;
        isWaterDropExit = true;
        isConectWaterDropOrange = false;
    }
    public bool TruePlayerContactable()
    {
        isPlayerContactable = true;
        return isPlayerContactable;
    }
    public bool FalsePlayerContactable()
    {
        isPlayerContactable = false;
        return isPlayerContactable;
    }
    private void OnTriggerExit2D(Collider2D other) {
        isWaterDropExit = true;
    }
    private void OnTriggerStay2D(Collider2D other) 
    {   //물방울 콜라이더 안에 있는데 인식을 안함 움직여야 인식함 왜이래? //해결
        if (other.gameObject.tag == "Plate")
        {
            isWaterDropExit = false;
        }
    }
    
    private void Update() {
        //bool값 하나 더 줘서 벗어나면 참 안 벗어나면 펄스로 해서 펄스일때 계속 해줄 예정
        //예: isPlayerContactable && isWaterDropExit 하면 저 위에꺼 넣으멸 될듯
        //Debug.Log("부딪히는중");
        if (isWaterDropExit == false && isPlayerContactable == true)
        {
            waterDropOrange_unVisibleTime = orangeDelayTime;
            isConectWaterDropOrange = true;
        }
        else
        {
            isConectWaterDropOrange = false;
        }
    }

    void OrangeDelayTimeController()
    {
        gameObject.GetComponent<Renderer>().enabled = false;
        waterDropCollisionAnimator.speed = 0.0f;
        StartCoroutine("OrangeDelayTime");
    }

    IEnumerator OrangeDelayTime()
    {
        yield return new WaitForSecondsRealtime(orangeDelayTime);
        waterDropCollisionAnimator.speed = 1.0f;
        gameObject.GetComponent<Renderer>().enabled = true;
    }
}
