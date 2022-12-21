using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private PlayerTurn playerTurn;
    [SerializeField] private Rigidbody characterBody;
    [SerializeField] private float walkingSpeed = 2f;
    Vector3 position;
    bool going;

    private void Start()
    {
        Cursor.visible = false;
    }
    
    void Update()
    {
        if (playerTurn.IsPlayerTurn())
        {
            if (Input.GetAxis("Horizontal") != 0)
            {
                //transform.Rotate(transform.up * rotationSpeed * Time.deltaTime * Input.GetAxis("Horizontal"));
                transform.Translate(transform.right * walkingSpeed * Time.deltaTime * Input.GetAxis("Horizontal"), Space.World);
                going = true;
            }

            if (Input.GetAxis("Vertical") != 0)
            {
                //transform.Translate(transform.forward * speed * Time.deltaTime * Input.GetAxis("Vertical"), Space.World);
                transform.Translate(transform.forward * walkingSpeed * Time.deltaTime * Input.GetAxis("Vertical"), Space.World);
            }

            if (Input.GetKeyDown(KeyCode.Space) && IsTouchingFloor())
            {
                Jump();
            }
        }

        //position = transform.position;
        //Debug.Log("010a " + position);

    }

    private void Jump()
    {
        Debug.Log("010 :  " + characterBody.name);        
        characterBody.AddForce(Vector3.up * 500f);
    }

    private bool IsTouchingFloor()
    {
        RaycastHit hit;
        // Parameters:
        // - The center from where we shoot
        // - Radius of the sphere
        // - Direction of the sphere
        // - hit parameter
        // - Distance the sphere
        //bool result = Physics.SphereCast(transform.position, 0.15f, -transform.up, out hit, 1f);
        bool result = Physics.SphereCast(characterBody.transform.position, 0.16f, -transform.up, out hit, 1f);
        Debug.Log("011 :  " + result);
        Debug.Log("011a :  " + hit.collider.gameObject.name);
        return result;
    }

    //private void OnParticleCollision(GameObject other)
    //{
    //    Debug.Log("Collide");
    //}

    public void TakeDamage(float damage)
    {
        Debug.Log("22a3 :  " + damage);
        //currentHealth -= damage;

        //healthBar.fillAmount = currentHealth / maxHealth;

        //if (currentHealth <= 0)
        //{
        //    // Set back to initial position
        //    //transform.position = initialPosition;
        //    //transform.eulerAngles = initialRotation;

        //    Destroy(gameObject);
        //}
    }
    public bool GoingHorizontal()
    {
        return going;
    }
}