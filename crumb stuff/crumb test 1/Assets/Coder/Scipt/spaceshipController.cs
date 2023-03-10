using System.Collections;
using System.Collections.Generic;

using System.Security.Cryptography;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

public class spaceshipController : MonoBehaviour
{
    float vert;
    float horiz;
    public float turnspeed = 150.0f;    //75
    public float movespeed = 600.0f;   //300
    public float maxspeed = 40.0f;     //20
    float brakespeed = 100.0f;
    float steerval;
    float accelval;
    float brakeval;

    public int health = 1;
    public float crashSpeed = 10;

    private PlayerInput playerinput;
    private Controls playercontrols;
    public new Rigidbody rigidbody;
    public targetController target;
    private GameObject spawnertag;
    public GameObject Explosion;
    static public bool isDead = false;
    static public float SpaceShipSpeed;


    //VFX
    public MeshRenderer mainEngine;
    public MeshRenderer sideEngineR;
    public MeshRenderer sideEngineL;
    private float flameLengthMainEngine = 3.0f;
    private float flameLengthSideEngine = 3.0f;
    private float EngineDefault = 1.35f;
    private float SideEngineDefault = 3.0f;
    private float sideEngineDefault = 1.35f;
    private float sideEngineRS = 1.35f;
    private float sideEngineLS = 1.35f;
    private float maxEngineThrust = 0.6f;




    private void Awake()
    {
        spawnertag = GameObject.FindGameObjectWithTag("spawner");
        playerinput = GetComponent<PlayerInput>();
        playercontrols = new Controls();
        Explosion.SetActive(false);


        
    }


    private void OnEnable()
    {
        playercontrols.Enable();
    }

    private void OnDisable()
    {
        playercontrols.Disable();
    }

    public void OnSteer(InputAction.CallbackContext context)
    {
        steerval = context.ReadValue<float>();
        if (steerval == 0)
        {
            sideEngineRS = SideEngineDefault;
            sideEngineLS = SideEngineDefault;
        }
        else if (steerval < 0)
            sideEngineRS = maxEngineThrust;
        else
            sideEngineLS = maxEngineThrust;
    }
    public void OnAccel(InputAction.CallbackContext context)
    {
            accelval = context.ReadValue<float>();
        if (accelval == 0)
            flameLengthMainEngine = EngineDefault;
        else
        {
            flameLengthMainEngine = maxEngineThrust;
        }

    }
    public void OnBrake(InputAction.CallbackContext context)
    {
        //Debug.Log(playerinput.playerIndex);
        brakeval = context.ReadValue<float>();
        if (brakeval >= 1)
        {
            flameLengthMainEngine = 3.0f;
        }
        else
            flameLengthMainEngine = EngineDefault;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Contains("gold") && target.grabstatus == true)
        {
            target.grabstatus = false;
            Destroy(other.gameObject);
        }
    }


    // Update is called once per frame
    void Update()
    {
        SpaceShipSpeed = rigidbody.velocity.magnitude;
        

        Material engineFlame = mainEngine.material;
        Material SideEngineRight = sideEngineR.material;
        Material SideEngineLeft = sideEngineL.material;
        engineFlame.SetFloat("_Flame_length", flameLengthMainEngine);
        SideEngineRight.SetFloat("_Flame_length", sideEngineRS);
        SideEngineLeft.SetFloat("_Flame_length", sideEngineLS);


        rigidbody.AddTorque(0,turnspeed * steerval * Time.deltaTime, 0);
        rigidbody.AddForce(transform.forward * accelval * Time.deltaTime * movespeed - rigidbody.velocity * brakeval * Time.deltaTime * brakespeed);
        rigidbody.velocity = Vector3.ClampMagnitude(rigidbody.velocity, maxspeed);

        if(health <= 0)
        {
            isDead = true;
            spawnertag.SetActive(false);
            Explosion.SetActive(true);
            Destroy(gameObject);
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        Rigidbody otherRigidBody = collision.rigidbody;
        if (collision.gameObject.CompareTag("Warden"))
        {
            isDead= true;
            spawnertag.SetActive(false);
            Explosion.SetActive(true);
            Destroy(gameObject);
            //deathScene.DeathSceneActivate();
        }

        if (collision.relativeVelocity.magnitude > crashSpeed && !collision.gameObject.tag.Contains("grab"))
        {
            health -= 1;
        }
    }
    
}