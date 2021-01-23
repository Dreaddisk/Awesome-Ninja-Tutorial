using UnityEngine;

public class Skill_Move : MonoBehaviour
{

    #region Variables
    public float X, Y, Z = 0;

    public bool local = false;
    #endregion Variables


    #region UnityFunctions

    private void Update()
    {
        if(local)
        {
            transform.Translate(new Vector3(X, Y, Z) * Time.deltaTime, Space.World);
        }
    }
    #endregion UnityFunctions
}
