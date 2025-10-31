using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private bool alive;
    [SerializeField] private bool hostile;
    private Vector3 startPosition;

    [SerializeField] private Movement characterMovement;
    [SerializeField] private bool isPlayer;
    /*
     * [SerializeField] private Weapon[] weapons
     * [SerializeField] private Weapon activeWeapon;
     * [SerializeField] private Skill[] skills;
     * [SerializeField] private Skill activeSkill;
     */
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public void Die()
    {
        if(isPlayer)
        {
            transform.position = startPosition;
        }
        else { Destroy(this.gameObject); }
    }
    public bool Alive
    {
        get
        {
            return alive;
        }
        set
        {
            alive = value;
        }
    }
    public Movement CharacterMovement
    {
        get { return characterMovement; }
    }
    public bool IsPlayer
    {
        get { return isPlayer; }
    }
    public Vector3 StartPosition
    {
        get { return startPosition; }
        set { startPosition = value; }
    }
}
