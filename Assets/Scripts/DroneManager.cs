using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneManager : MonoBehaviour
{   
    public GameObject drone1;
    public Transform waypoints1Parent;

    private List<Transform> waypoints1 = new List<Transform>();
    private int currentWaypoint1 = 0;

    private float droneSpeed = 3f;

    void Start()
    {

        foreach(Transform waypoint in waypoints1Parent){

            waypoints1.Add(waypoint);

        }
        
    }

    void Update()
    {
        
        Vector3 distance = waypoints1[currentWaypoint1].transform.position - drone1.transform.position;
        Vector3 direction = distance.normalized;

        drone1.GetComponent<Rigidbody>().velocity = direction * droneSpeed;
        if(distance.magnitude < 1){
            
            if(currentWaypoint1 >= waypoints1.Count - 1){

                currentWaypoint1 = 0;

            }

            currentWaypoint1++;

        }

        drone1.transform.LookAt(waypoints1[currentWaypoint1], transform.up);

       
    }


}
