using System.Collections;



using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    public CameraShake camerashake;
    public UIManager uimanager;
    public SoundManager soundmanager;

    public GameObject cam;
    public GameObject VectorBack;
    public GameObject VectorForward;

    private Rigidbody rb;

    private Touch touch;
   
    public int speedModifier;
    public int forwardSpeed;

    private bool speedBallForward = false;
    private bool firstTouchControl = false;
    private int soundLimitCount;
    public void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    public void Update()
    {
        if (Variables.firstTouch == 1 && speedBallForward == false)
        {
            transform.position += new Vector3(0, 0, forwardSpeed * Time.deltaTime);

            VectorBack.transform.position += new Vector3(0, 0, forwardSpeed * Time.deltaTime);
            VectorForward.transform.position += new Vector3(0, 0, forwardSpeed * Time.deltaTime);
        }


        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Began)
            {
                if (!EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
                {
                    if (!firstTouchControl)
                    {
                        Variables.firstTouch = 1;
                        uimanager.FirstTouch();
                        firstTouchControl = true;
                    }
                } 
                
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                
                if (!EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
                {
                    rb.velocity = new Vector3(touch.deltaPosition.x * speedModifier * Time.deltaTime,
                                          0,
                                          touch.deltaPosition.y * speedModifier * Time.deltaTime);
                    if (firstTouchControl == false)
                    {
                        Variables.firstTouch = 1;
                        uimanager.FirstTouch();
                        firstTouchControl = true;
                    }
                }
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                rb.velocity = Vector3.zero;
            }
        }
    }

    public GameObject[] FractureItems;

    public void OnCollisionEnter(Collision hit)
    {
        if (hit.gameObject.CompareTag("Obstacle"))
        {
            soundmanager.BlowUpSound();
            camerashake.CameraShakesCall();
            uimanager.StartCoroutine("WhiteEffect");
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            if (PlayerPrefs.GetInt("Vibration") == 1)
            {
                Vibration.Vibrate(50);
            }
            foreach (GameObject item in FractureItems)
            {
                item.GetComponent<SphereCollider>().enabled = true;
                item.GetComponent<Rigidbody>().isKinematic = false;
            }
            StartCoroutine(nameof(TimeScaleControl));
        }

        if (hit.gameObject.CompareTag("Environment")) {

            soundLimitCount++;
        }
        if (hit.gameObject.CompareTag("Environment") && soundLimitCount % 5 == 0) {

            soundmanager.hitSound();
        }
    }

    public IEnumerator TimeScaleControl()
    {
        speedBallForward = true;
        yield return new WaitForSecondsRealtime(0.4f);
        Time.timeScale = 0.4f;
        yield return new WaitForSecondsRealtime(0.6f);
        uimanager.RestartButtonActive();
        rb.velocity = Vector3.zero;
    }
}
