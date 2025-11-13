using UnityEngine;

public class CreateSlime
{
    private GameObject SlimePrefab;

    public void Create()
    {
        Object.Instantiate(SlimePrefab);
    }
}
