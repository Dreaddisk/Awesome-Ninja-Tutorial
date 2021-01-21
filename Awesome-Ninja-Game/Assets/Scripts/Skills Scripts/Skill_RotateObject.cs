using UnityEngine;

public class Skill_RotateObject : MonoBehaviour
{
    #region Variables
    public float x = 0f;
    public float y = 0f;
    public float z = 0f;

    #endregion

    private void Update()
    {
        transform.Rotate(new Vector3(x, y, z) * Time.deltaTime);
    }
}
