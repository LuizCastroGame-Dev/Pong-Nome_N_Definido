using UnityEngine;

public class PaddleInput : MonoBehaviour
{
    public float InputReader()
    {
        float moveInput = Input.GetAxis("Vertical");
        return moveInput;
    }

    public bool InputParry() 
    {
        bool parryInput = Input.GetKeyDown(KeyCode.Space);
        return parryInput;
    }

    public bool InputSelectLeft()
    {
        bool leftInput = Input.GetKeyDown(KeyCode.A);
        return leftInput;
    }

    public bool InputSelectRight()
    {
        bool rightInput = Input.GetKeyDown(KeyCode.D);
        return rightInput;
    }

    public bool InputUsedPowerUp()
    {
        bool usedInput = Input.GetKeyDown(KeyCode.E);
        return usedInput;
    }
}
