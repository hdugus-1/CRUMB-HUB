using System.Collections;
using System.Collections.Generic;

using System.Security.Cryptography;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using System.Runtime.CompilerServices;

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

    

    private PlayerInput playerinput;
    private Controls playercontrols;
    static public GameObject Deatheventsystem;
    public new Rigidbody rigidbody;
    public targetController target;
    private GameObject spawnertag;
    public GameObject Explosion;
    static public bool isDead = false;
    static public float SpaceShipSpeed;

    //health
    public float crashSpeed = 10;

    public int health = 1;
    public int maxhealth = 1;
    public Image[] healthBar;
    public Sprite activeHealth;
    public Sprite inactiveHealth;

    //VFX
    public GameObject starShineEffect;
    static public GameObject staticStarShineEffect;
    public MeshRenderer mainEngine;
    public MeshRenderer[] UpgradeEngine;
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
    private float mainEngineScrollSpeed;
    private float upgradeEngineFlameLength;




    private void Awake()
    {
        staticStarShineEffect = starShineEffect;
        starShineEffect.SetActive(false);
        spawnertag = GameObject.FindGameObjectWithTag("spawner");
        Deatheventsystem = GameObject.FindGameObjectWithTag("DeathEvent");
        playerinput = GetComponent<PlayerInput>();
        playercontrols = new Controls();
        Explosion.SetActive(false);
        Deatheventsystem.SetActive(false);
        upgradeEngineFlameLength = EngineDefault;
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
        {
            flameLengthMainEngine = EngineDefault;
            upgradeEngineFlameLength = EngineDefault;
            mainEngineScrollSpeed = -1.2f;
        }

        else
        {
            flameLengthMainEngine = maxEngineThrust;
            upgradeEngineFlameLength = maxEngineThrust;
            mainEngineScrollSpeed = -2.0f;
        }

    }
    public void OnBrake(InputAction.CallbackContext context)
    {
        //Debug.Log(playerinput.playerIndex);
        brakeval = context.ReadValue<float>();
        if (brakeval >= 1)
        {
            flameLengthMainEngine = 3.0f;
            upgradeEngineFlameLength = 3.0f;
        }
        else
        {
            flameLengthMainEngine = EngineDefault;
            upgradeEngineFlameLength = EngineDefault;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Contains("grabgold") && target.grabstatus == true)
        {
            target.grabstatus = false;
            Destroy(other.gameObject);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("UpgradeZone"))
        {
            float maxSpeed = 8;
            if(rigidbody.velocity.magnitude >= maxSpeed)
            {
                rigidbody.velocity = rigidbody.velocity.normalized * maxSpeed;
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        SpaceShipSpeed = rigidbody.velocity.magnitude;
        
        for (int i = 0; i < healthBar.Length; i++)
        {
            if(i < health)
            {
                healthBar[i].sprite = activeHealth;
            }
            else
            {
                healthBar[i].sprite = inactiveHealth;
            }

            if(i < maxhealth)
            {
                healthBar[i].enabled = true;
            }
            else
            {
                healthBar[i].enabled = false;
            }
        }

        //UpgradeEngineFlame.SetFloat("_Flame_length", upgradeEngineFlameLength);

        MeshRenderer[] upgradeEngineRenderers = new MeshRenderer[UpgradeEngine.Length];
        for (int i = 0; i < UpgradeEngine.Length; i++)
        {
            upgradeEngineRenderers[i] = UpgradeEngine[i].GetComponent<MeshRenderer>();
            
        };
        for(int i = 0; i < upgradeEngineRenderers.Length; i++)
        {
            upgradeEngineRenderers[i].material.SetFloat("_Flame_length", upgradeEngineFlameLength);
            upgradeEngineRenderers[i].material.SetFloat("_ScrollSpeed", mainEngineScrollSpeed);
        }


        Material engineFlame = mainEngine.material;
        Material SideEngineRight = sideEngineR.material;
        Material SideEngineLeft = sideEngineL.material;
        engineFlame.SetFloat("_Flame_length", flameLengthMainEngine);
        engineFlame.SetFloat("_ScrollSpeed", mainEngineScrollSpeed);
        SideEngineRight.SetFloat("_Flame_length", sideEngineRS);
        SideEngineLeft.SetFloat("_Flame_length", sideEngineLS);


        rigidbody.AddTorque(0,turnspeed * steerval * Time.deltaTime, 0);
        rigidbody.AddForce(transform.forward * accelval * Time.deltaTime * movespeed - rigidbody.velocity * brakeval * Time.deltaTime * brakespeed);
        rigidbody.velocity = Vector3.ClampMagnitude(rigidbody.velocity, maxspeed);

        if(health <= 0)
        {
            Deatheventsystem.SetActive(true);
            isDead = true;
            spawnertag.SetActive(false);
            Explosion.SetActive(true);
            Destroy(gameObject);
            deathScene.DeathSceneActivate();
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        Rigidbody otherRigidBody = collision.rigidbody;
        if (collision.gameObject.CompareTag("Warden"))
        {
            Deatheventsystem.SetActive(true);
            deathScene.DeathSceneActivate();
            isDead= true;
            spawnertag.SetActive(false);
            Explosion.SetActive(true);
            Destroy(gameObject);
        }

        if (collision.relativeVelocity.magnitude > crashSpeed && !collision.gameObject.tag.Contains("grab"))
        {
            health -= 1;
        }
    }
    
}