using UnityEngine;

public class ChaosEffectManager : MonoBehaviour
{
[Header("References")]
public Rigidbody2D playerRB;
public Transform groundCheck;

[Header("State")]
private bool spikyFloor = false;
private bool jumpFlipping = false;
private bool flappyMode = false;


public void ActivateChaos(string chaosName)
{
    switch (chaosName)
    {
        case "Gravity Flip":
            jumpFlipping = false;
            FlipGravity();
            break;

        case "Jump Flipping":
            jumpFlipping = true;
            break;

        case "Flappy Mode":
            DisableAllEffects();
            flappyMode = true;
            if (playerRB.gravityScale > 0)
            {
                playerRB.gravityScale = 6f;
            }
            else
            {
                playerRB.gravityScale = -6f;
            }
            break;

        case "Spiky Floor":
            DisableAllEffects();
            spikyFloor = true;
            break;
    }
}

void DisableAllEffects()
{
    jumpFlipping = false;
    flappyMode = false;
    spikyFloor = false;

    if (playerRB.gravityScale > 0)
        playerRB.gravityScale = 3f;
    else
        playerRB.gravityScale = -3f;
}

public void StopCurrentChaos()
{
    DisableAllEffects();
}

public void HandleJumpChaos()
{
    if (jumpFlipping)
    {
        FlipGravity();
    }
}

void FlipGravity()
{
    if (playerRB.gravityScale > 0)
    {
        playerRB.gravityScale = -4f;
    }
    else
    {
        playerRB.gravityScale = 4f;
    }

    Vector3 pos = groundCheck.localPosition;
    pos.y *= -1f;
    groundCheck.localPosition = pos;

}

public bool IsGravityFlipped()
{
    return playerRB.gravityScale < 0f;
}

public bool IsJumpFlipping()
{
    return jumpFlipping;
}

public bool IsFlappyMode()
{
    return flappyMode;
}

public bool IsSpikyFloor()
{
    return spikyFloor;
}

}


