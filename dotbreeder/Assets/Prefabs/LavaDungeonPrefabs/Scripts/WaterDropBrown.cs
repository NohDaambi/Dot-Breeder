using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDropBrown : MonoBehaviour
{
    Animator waterDropCollisionAnimator;

    public bool isPlayerContactable;
    public bool isWaterDropExit;
    public static float waterDropBrown_unVisibleTime;
    public static bool isConectWaterDropBrown;
    private float brownDelayTime;

    private void Awake() {
        waterDropCollisionAnimator = gameObject.GetComponent<Animator>();
    }
    private void Start() {
        waterDropBrown_unVisibleTime = 0;
        brownDelayTime = 0.7f;
        isPlayerContactable = false;
        isWaterDropExit = true;
        isConectWaterDropBrown = false;
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
    
    private void FixedUpdate() {
        //bool값 하나 더 줘서 벗어나면 참 안 벗어나면 펄스로 해서 펄스일때 계속 해줄 예정
        //예: isPlayerContactable && isWaterDropExit 하면 저 위에꺼 넣으멸 될듯
        if (isWaterDropExit == false && isPlayerContactable == true)
        {
            waterDropBrown_unVisibleTime = brownDelayTime;
            isConectWaterDropBrown = true;
        }
        else
        {
            isConectWaterDropBrown = false;
        }
    }

    void BrownDelayTimeController()
    {
        gameObject.GetComponent<Renderer>().enabled = false;
        waterDropCollisionAnimator.speed = 0.0f;
        StartCoroutine("BrownDelayTime");
    }

    IEnumerator BrownDelayTime()
    {
        yield return new WaitForSecondsRealtime(brownDelayTime);
        waterDropCollisionAnimator.speed = 1.0f;
        gameObject.GetComponent<Renderer>().enabled = true;
    }
}
