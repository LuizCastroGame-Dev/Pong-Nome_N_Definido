using UnityEngine;

public class PaddleInput : MonoBehaviour
{
    public float InputReader()
    {
        float moveinput = Input.GetAxis("Vertical");
        return moveinput;
    }
}
