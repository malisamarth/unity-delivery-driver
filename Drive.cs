using System.Collections;
using UnityEngine;

public class Drive : MonoBehaviour
{
    [SerializeField] float steerSpeed = 300f;
    [SerializeField] float moveSpeed = 80f;
    [SerializeField] float slowSpeed = 0.001f;
    [SerializeField] float boostSpeed = 90f;

    bool isGoal = false;
    bool isInGoal = false;
    int goalCounter = 0;


    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);

        if (isGoal && isInGoal)
        {
            Debug.Log("GoalGoalGoal");
            isInGoal = false; // prevent spamming
            goalCounter++;
            Debug.Log("Goals = " + goalCounter);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Bump")
        {
            moveSpeed = slowSpeed;
            Debug.Log("Slowed");
        }

        if (other.tag == "Boost")
        {
            moveSpeed = boostSpeed;
            Debug.Log("Boosted");
        }

        if (other.tag == "Goal" && isGoal)
        {
            isInGoal = true; 
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "FootBall")
        {
            StartCoroutine(SetGoalTrueTemporarily());
        }
    }

    IEnumerator SetGoalTrueTemporarily()
    {
        isGoal = true;
        Debug.Log("isGoal set to TRUE");
        yield return new WaitForSeconds(3f); 
        isGoal = false;
        Debug.Log("isGoal set to FALSE");
    }
}
