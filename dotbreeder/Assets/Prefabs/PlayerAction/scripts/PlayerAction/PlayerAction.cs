using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerAction : MonoBehaviour
{
    public GameManager Manager;
    public SoundManager sManager;
    public Interaction PlayerInteraction;

    public float Speed;
    public bool Attack;
    public int weaponstrength=1;
    public AudioClip clip;

    float h;
    float v;
    bool isHorizonMove;
    Vector3 DirVec;

    public GameObject scanObject;

    Rigidbody2D Rigid;
    Animator Anim;

    public bool isDelay;
    private static bool PlayerExist;

    void Awake()
    {
        Time.timeScale = 1;

        Rigid = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
    }

    void Update()
    {
        //Bool Attack
        Attack = Input.GetMouseButtonDown(0);

        //Move
        h = Manager.isAction ? 0 : Input.GetAxisRaw("Horizontal");
        v = Manager.isAction ? 0 : Input.GetAxisRaw("Vertical");

        //Check Button Down Up isAction으로 대화도중 움직임 제한
        bool hDown = Manager.isAction ? false : Input.GetButtonDown("Horizontal");
        bool vDown = Manager.isAction ? false : Input.GetButtonDown("Vertical");
        bool hUp = Manager.isAction ? false : Input.GetButtonUp("Horizontal");
        bool vUp = Manager.isAction ? false : Input.GetButtonUp("Vertical");

        //Check Horizontal Move
        if (hDown)
            isHorizonMove = true;
        else if (vDown)
            isHorizonMove = false;
        else if (hUp || vUp)
            isHorizonMove = h != 0;

        //Animation
        if (Anim.GetInteger("hAxisRaw") != h)
        {
            Anim.SetBool("isChange", true);
            Anim.SetInteger("hAxisRaw", (int)h);
        }
        else if (Anim.GetInteger("vAxisRaw") != v)
        {
            Anim.SetBool("isChange", true);
            Anim.SetInteger("vAxisRaw", (int)v);
        }
        else
        {
            Anim.SetBool("isChange", false);
        }  

        //Ray Direction
        if (vDown && v == 1) // up
            DirVec = Vector3.up;
        else if (vDown && v == -1) // down
            DirVec = Vector3.down;
        else if (hDown && h == -1) // left
            DirVec = Vector3.left;
        else if (hDown && h == 1) // right
            DirVec = Vector3.right;

        //Scan Object && Interaction 채집
        if (Input.GetMouseButtonDown(0) && scanObject != null)
        {
            //상호작용 키 딜레이
            if (!isDelay)
            {
                PlayerInteraction.Forage();

                //채집 시에만 사운드, 무한클릭방지
                if (scanObject.tag == "R" || scanObject.tag == "G" || scanObject.tag == "B")
                {
                    isDelay = true;
                    //코루틴 
                    StartCoroutine(CountAttackDelay());

                    Anim.SetTrigger("Attack");
                    //상호작용 사운드 재생            
                    SoundManager.instance.SFXPlay("Attack", clip);
                }

                //예람 추가: 자원 채집 시 ->
                if (scanObject.tag == "RedSpawner"||scanObject.tag == "GreenSpawner"||scanObject.tag == "BlueSpawner")
                {
                    Debug.Log("[!]System: ScanObject :"+scanObject.tag);
                    isDelay = true;
                    StartCoroutine(CountAttackDelay());

                    //코루틴        
                    StartCoroutine(scanObject.GetComponent<Resource>().Damage_Resources());                                   
                    Anim.SetTrigger("Attack");
                    //상호작용 사운드 재생            
                    SoundManager.instance.SFXPlay("Attack", clip);
                }            
            }
            else
            {
                Debug.Log("클릭 딜레이");
            }
        }
        //Scan Object && Interaction 그 외 상호작용
        if (Input.GetKeyDown(KeyCode.E) && scanObject != null)
        {
            PlayerInteraction.playerInteraction();
            PlayerInteraction.Action(scanObject); 
            //데이터조각얻기
        }
        //코루틴
        IEnumerator CountAttackDelay()
        {
            //0.3초 딜레이
            yield return new WaitForSecondsRealtime(0.3f);
            isDelay = false;
        }      
    }
    void FixedUpdate()
    {
        //Move Vec
        Vector2 moveVec = isHorizonMove ? new Vector2(h, 0) : new Vector2(0, v);
        Rigid.velocity = moveVec * Speed;

        //Scan
        Debug.DrawRay(Rigid.position, DirVec * 0.7f, new Color(0, 1, 0));
        RaycastHit2D rayHit = Physics2D.Raycast(Rigid.position, DirVec, 0.7f, LayerMask.GetMask("Object"));

        if (rayHit.collider != null)
        {
            scanObject = rayHit.collider.gameObject;
        }
        else
            scanObject = null;
    }
}
