using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public static BallController instance;
    public GameObject particle;
    [SerializeField]
    public float speed;
    bool started;
    bool gameOver;
    Rigidbody rb;
    public AudioSource source;
    public AudioSource gameOverAudio;
    void Awake(){
        rb = GetComponent<Rigidbody>();
        instance = this;

    }
    // Start is called before the first frame update
    void Start()
    {
        started = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!started){
            if(Input.GetMouseButtonDown(0)){
                rb.velocity = new Vector3(speed, 0, 0);
                started = true;
                source.gameObject.SetActive(true);
                source.Play();
                GameManager.instance.StartGame();
            }
        }
        Debug.DrawRay(transform.position, Vector3.down, Color.red);
        if(!Physics.Raycast(transform.position, Vector3.down, 1f)) {
            gameOver = true;
              

            rb.velocity = new Vector3(0, -25f, 0);

            Camera.main.GetComponent<CameraFollow>().gameOver = true;
            gameOverAudio.gameObject.SetActive(true);
            gameOverAudio.Play(); 
            GameManager.instance.GameOver();
        }
        if(Input.GetMouseButtonDown(0) && !gameOver){
            SwitchDirection();
        }
    }

    void SwitchDirection(){
        if(rb.velocity.z > 0)
        {
            rb.velocity = new Vector3(speed, 0 , 0);
        }
        else if(rb.velocity.x >0){
            rb.velocity = new Vector3(0, 0, speed);
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Diamond"){
           GameObject part = Instantiate(particle,col.gameObject.transform.position, Quaternion.identity) as GameObject;
            Destroy(col.gameObject);
            Destroy(part, 1f);
        }
    }
}
