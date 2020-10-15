using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform Planet;
    public bool canMove;
    public float speed = 4;
    public float JumpHeight = 1.2f;
    float gravity = 100;
    bool OnGround = false;
    float distanceToGround;
    Vector3 Groundnormal;
    public LayerMask planetsLayer;
    public PlayerOxygen playerOxygen;

    public delegate void ItemCollectedDel(int id);
    public event ItemCollectedDel ItemCollected;

    public delegate void VisitSSDel();
    public event VisitSSDel VisitSS;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        playerOxygen = GetComponent<PlayerOxygen>();
    }

    // Update is called once per frame
    void Update()
    {

        //MOVEMENT
        float x = canMove ? Input.GetAxis("Horizontal") * Time.deltaTime * speed : 0;
        float z = canMove ? Input.GetAxis("Vertical") * Time.deltaTime * speed : 0;

        transform.Translate(x, 0, z);

        //Local Rotation

        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(0, 150 * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(0, -150 * Time.deltaTime, 0);
        }

        //Jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(transform.up * 40000 * JumpHeight * Time.deltaTime);
        }

        //GroundControl
        RaycastHit hit = new RaycastHit();
        if (Physics.Raycast(transform.position, -transform.up, out hit, 10, planetsLayer))
        {
            distanceToGround = hit.distance;
            Groundnormal = hit.normal;

            if (distanceToGround <= 0.1f)
            {
                OnGround = true;
            }
            else
            {
                OnGround = false;
            }
        }

        //GRAVITY and ROTATION
        Vector3 gravDirection = (transform.position - Planet.transform.position).normalized;

        if (OnGround == false)
        {
            rb.AddForce(gravDirection * -gravity);
        }

        Quaternion toRotation = Quaternion.FromToRotation(transform.up, Groundnormal) * transform.rotation;
        transform.rotation = toRotation;
    }
    
    //CHANGE PLANET
    private void OnTriggerEnter(Collider collision)
    {
        Item item = collision.GetComponent<Item>();
        if (item)
        {
            ItemCollected?.Invoke(item.id);
            return;
        }
        Spaceship spaceship = collision.GetComponent<Spaceship>();
        if (spaceship)
        {
            VisitSS?.Invoke();
            playerOxygen.counting = false;
            playerOxygen.RefillOxygen();
            return;
        }
        OxygenBubble oxygenBubble = collision.GetComponent<OxygenBubble>();
        if (oxygenBubble)
        {
            playerOxygen.RefillOxygen(oxygenBubble.oxygenCapacity);
            oxygenBubble.gameObject.SetActive(false);
            return;
        }
        //if (collision.transform != Planet.transform)
        //{
        //    Planet = collision.transform;

        //    Vector3 gravDirection = (transform.position - Planet.transform.position).normalized;

        //    Quaternion toRotation = Quaternion.FromToRotation(transform.up, gravDirection) * transform.rotation;
        //    transform.rotation = toRotation;

        //    rb.velocity = Vector3.zero;
        //    rb.AddForce(gravDirection * gravity);
        //}
    }

    private void OnTriggerExit(Collider other)
    {
        Spaceship spaceship = other.GetComponent<Spaceship>();
        if (spaceship)
        {
            playerOxygen.counting = true;
        }
    }
}