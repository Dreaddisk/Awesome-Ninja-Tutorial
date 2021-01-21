using UnityEngine;

public class Skill_DestroyOvertime : MonoBehaviour
{
    public float timer = 3f;

    private void Start()
    {
        Destroy(gameObject, timer);
    }
}
