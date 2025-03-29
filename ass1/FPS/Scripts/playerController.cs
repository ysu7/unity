using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{   
    CharacterController controller; 
    public Transform face; //注意，当public一个变量时，他会出现一个专门的框在Unity inspector中  
    public float speed =8;
    float rotationX=0;
    //
    public float lookSpeed = 2;
    float lookXLimit =45;

    //jump
    float gravity = -9.81f;
    public bool grounded;
    float velocity = 0; //速度
    public float jumpForce= 9;

    //fire
    public GameObject bullet;
    GameObject [] bullets;
    int bulletCounter = 0;
    
    
    Transform muzzle;
    public float bulletTime = 0;
    public float reloadTime = 0.2f;


    //playSound
    public AudioSource mAudioSrc;   
    void Start()
    {
        controller = GetComponent<CharacterController>(); // CharacterController 代表我们在cyinder 中创建的那个CharacterController
        
        bullets = new GameObject[100];
        muzzle = GameObject.Find("muzzle").transform;

        for(int i=0;i<100;i++){
                bullets[i] = Instantiate(bullet);
                bullets[i].SetActive(false);
        }

        mAudioSrc = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {   
    
         //jump
        velocity += gravity * Time.deltaTime ;
        
        float jumpVal = Input.GetAxis("Jump");

        //Debug.Log("jumpval =" + jumpVal);

        if(jumpVal == 1)
        {   
            velocity = jumpForce;
        }
        controller.Move(new Vector3(0,velocity,0) * Time.deltaTime);
        

        //move,视角
        //float leftRight = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        //float frontBack = Input.GetAxis("Vertical") * Time.deltaTime * speed;

        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform. TransformDirection(Vector3.right);
        
        float currSpeedX = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        float currSpeedZ = Input.GetAxis("Horizontal")* speed * Time.deltaTime;
        
        Vector3 moveDirection = (forward * currSpeedX) + (right * currSpeedZ);

    //用于rotate上下，
        rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
        rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);

        //这里对应了 unity中 edit-> inputManger
        //使用debug来报错：
        //Debug.Log(leftRight);
        //controller.Move(new Vector3(leftRight,0,frontBack));

        controller.Move(moveDirection);

        face.localRotation = Quaternion.Euler(rotationX,0,0);

        transform.rotation *= Quaternion.Euler(0,Input.GetAxis("Mouse X")* lookSpeed , 0);
        
       //fire
       bulletTime += Time.deltaTime;

        if(Input.GetAxis("Fire1")==1)
        {   
            if(bulletTime > reloadTime){
            bullets[bulletCounter].SetActive(true);
            bullets[bulletCounter].transform.position = muzzle.position + forward;
            bullets[bulletCounter].GetComponent<Rigidbody>().velocity = forward * 60;
            bulletCounter++;
            bulletCounter = bulletCounter % 100;
            bulletTime =0;
            }

            mAudioSrc.Play();

        }

      

      }

    
    }

