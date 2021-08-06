using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerAction : MonoBehaviour
{
    public GameManager Manager;
    public SoundManager sManager;
    public float Speed;
    public bool Attack;

    public AudioClip clip;

    private static bool PlayerExist;    

    float h;
    float v;
    bool isHorizonMove;
    Vector3 DirVec;

    public GameObject scanObject;

    Rigidbody2D Rigid;
    Animator Anim;

    public bool isDelay;

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

        //Check Button Down Up isAction���� ��ȭ���� ������ ����
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

        //Scan Object && Interaction ä��
        if (Input.GetMouseButtonDown(0) && scanObject != null)
        {
            //��ȣ�ۿ� Ű ������
            if (!isDelay)
            {
                Manager.Forage();

                //ä�� �ÿ��� ����, ����Ŭ������
                if (scanObject.tag == "R" || scanObject.tag == "G" || scanObject.tag == "B")
                {
                    isDelay = true;
                    //�ڷ�ƾ 
                    StartCoroutine(CountAttackDelay());

                    Anim.SetTrigger("Attack");
                    //��ȣ�ۿ� ���� ���            
                    SoundManager.instance.SFXPlay("Attack", clip);
                }          
            }
            else
            {
                Debug.Log("Ŭ�� ������");
            }
        }
        //Scan Object && Interaction �� �� ��ȣ�ۿ�
        if (Input.GetKeyDown(KeyCode.E) && scanObject != null)
        {
            Manager.Interaction();
            Manager.Action(scanObject); 
            //�������������
        }
        //�ڷ�ƾ
        IEnumerator CountAttackDelay()
        {
            //0.3�� ������
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

    //Scnen Transition
    void OnTriggerEnter2D(Collider2D other)
    {        
        switch (other.gameObject.tag)
        {
            //Forest
            case "FoLeft":
                SceneManager.LoadScene("Forest1");               
                gameObject.transform.position = new Vector3(9, 2.4f, -1);
                break;
            case "FoRight":
                SceneManager.LoadScene("Forest2");
                gameObject.transform.position = new Vector3(-9, -5, -1);
                break;

            //Ocene
            case "GoForest":
                SceneManager.LoadScene("Forest2");
                gameObject.transform.position = new Vector3(9, -5, -1);
                break;
            case "GoOcene":
                SceneManager.LoadScene("Ocene1");
                gameObject.transform.position = new Vector3(-8.8f, -3, -1);
                break;
            case "OcLeft":
                SceneManager.LoadScene("Ocene1");
                gameObject.transform.position = new Vector3(7.8f, -4, -1);
                break;
            case "OcRight":
                SceneManager.LoadScene("Ocene2");
                gameObject.transform.position = new Vector3(-8.8f, -3, -1);
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
                gameObject.transform.position = new Vector3(8.8f, -0.1f, -1);
                break;
            case "DeRight":
                SceneManager.LoadScene("Desert2");
                gameObject.transform.position = new Vector3(-9.2f, -2, -1);                
                break;

            //Volcano
            case "BackDesert":
                SceneManager.LoadScene("Desert2");
                gameObject.transform.position = new Vector3(9.2f, -4, -1);
                break;
            case "GoVolcano":
                SceneManager.LoadScene("Volcano1");
                gameObject.transform.position = new Vector3(-9, -4, -1);
                break;
            case "VoLeft":
                SceneManager.LoadScene("Volcano1");
                gameObject.transform.position = new Vector3(9.3f, -1, -1);
                break;
            case "VoRight":
                SceneManager.LoadScene("Volcano2");
                gameObject.transform.position = new Vector3(-9, -4, -1);
                break;


        }
    }
}
