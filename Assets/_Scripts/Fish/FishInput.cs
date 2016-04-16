using UnityEngine;

public class FishInput : MonoBehaviour
{
    private FishPhysics fishPhysics;
    private FishMover fishMover;

    void Start()
    {
        fishPhysics = GetComponent<FishPhysics>();
        fishMover = GetComponent<FishMover>();
    }

    void FixedUpdate()
    {
        if (Input.GetButtonDown("P1Action")) {
            fishPhysics.ToggleBlow();
        }

        float horizontalValue = Input.GetAxis("P1Horizontal");
        float verticalValue = Input.GetAxis("P1Vertical");

        fishMover.Move(horizontalValue, verticalValue);
    }
}
