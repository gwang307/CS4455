using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;


//[RequireComponent(typeof(NavMeshAgent))]
public class Chase : MonoBehaviour {

    public Transform player;
    //private NavMeshAgent nma;
    static Animator anim;
    public AudioSource zombieSound;

    public GameObject[] waypoints;
    public int currWaypoint = -1;
    //public Image damageImage;
    //public float flashSpeed = 1f;
    //public Color flashColour = new Color(255f, 255f, 255f, 1f);

    private void SetNextWaypoint()
    {
        if (waypoints.Length == 0)
        {
            throw (new System.IndexOutOfRangeException("Array size 0"));
        }
        currWaypoint++;
        if (currWaypoint >= waypoints.Length)
        {
            currWaypoint = 0;
        }
        //nma.SetDestination(waypoints[currWaypoint].transform.position);
    }

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        zombieSound = GetComponent<AudioSource>();
        //nma = GetComponent<NavMeshAgent>();
        SetNextWaypoint();
	}
	
	// Update is called once per frame
	void Update () {
        // player is near
        if (Vector3.Distance(player.position, this.transform.position) < 30)
        {
            Vector3 direction = player.position - this.transform.position;
            direction.y = 0;
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.1f);
            anim.SetBool("isWalking", true);

            if (direction.magnitude < 10)
            {
                zombieSound.Play();
            }

            if (direction.magnitude > 2)
            {
                this.transform.Translate(0, 0, 0.1f);
                anim.SetBool("isAttacking", false);
                //player.position = player.position - player.position;
                //player.transform.Translate(-136.98f, 8, 169.3f);
            }
            else
            {
                //damageImage.color = flashColour;
                //damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
                anim.SetBool("isAttacking", true);
                anim.SetBool("isWalking", false);
                Invoke("changePos", 0f);
            }
        }
        // player far; chase balls
        else
        {
            Vector3 wayDir = waypoints[currWaypoint].transform.position - this.transform.position;
            wayDir.y = 0;
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(wayDir), 0.1f);
            anim.SetBool("isWalking", true);
            this.transform.Translate(0, 0, 0.1f);
            if (Vector3.Distance(this.transform.position, waypoints[currWaypoint].transform.position) <= 5)
            //if (nma.remainingDistance <= 0.1 && nma.pathPending != true)
            {
                SetNextWaypoint();
            }
            //anim.SetFloat("vely", nma.velocity.magnitude / nma.speed);
        }

    }

    void changePos() {
        //damageImage.color = new Color(255f, 255f, 255f, 0f);
        player.position = new Vector3(-136.98f, 11, 169.3f);
    }
}
