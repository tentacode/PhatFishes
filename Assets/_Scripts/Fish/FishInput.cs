using UnityEngine;

public class FishInput : MonoBehaviour
{
    private FishPhysics fishPhysics;
    private FishMover fishMover;
    private FishPlayer fishPlayer;

    void Start()
    {
        fishPhysics = GetComponent<FishPhysics>();
        fishMover = GetComponent<FishMover>();
        fishPlayer = GetComponent<FishPlayer>();
    }

    void Update()
    {
        var label = "P" + fishPlayer.playerIndex;
        if (Input.GetButtonDown(label + "Action")) {
            fishPhysics.ToggleBlow();
        }
    }

    void FixedUpdate()
    {
        var label = "P" + fishPlayer.playerIndex;
        float horizontalValue = Input.GetAxis(label + "Horizontal");
        float verticalValue = Input.GetAxis(label + "Vertical");

        fishMover.Move(horizontalValue, verticalValue);
    }
}
