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
        bool parryInput = Input.GetButtonDown("Fire1");
        return parryInput;
    }
}
