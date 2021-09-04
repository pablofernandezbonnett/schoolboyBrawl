
using TMPro;
using UnityEngine;


public enum ComboState
{
    NONE,
    PUNCH1,
    PUNCH2,
    PUNCH3,
    KICK1,
    KICK2
}
public class PlayerAttack : MonoBehaviour
{
    public Transform attackPoint;
    public float attackRange;
    public LayerMask enemyLayers;

    private Animator myAnimator;
    private bool punch;
    private bool kick;
    [SerializeField] private int attackDmg;
    [SerializeField] private AudioClip attackSound, hitSound;
    public TextMeshProUGUI textMeshPro;
    
    private float defcounterTimer = 1f;
    private float currentTimer;
   
    [HideInInspector] public int hitCount;
    [HideInInspector] public bool activateTimerToReset;
    [HideInInspector] public float default_ComboTimer = 0.4f;
    [HideInInspector] public float current_ComboTimer;
    private ComboState currentComboState;


    private void Awake()
    {
        textMeshPro = this.GetComponent<TextMeshProUGUI>();
    }

    // Start is called before the first frame update
    void Start()
    {
        punch = false;
        kick = false;
        myAnimator = this.GetComponent<Animator>();
        //myRB = this.GetComponent<Rigidbody>();
        current_ComboTimer = default_ComboTimer;
        currentComboState = ComboState.NONE;
        textMeshPro.enabled = false;
        hitCount = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        Punch();
        Kick();
        ResetValues();
        ComboAttacks();
        ResetComboState();
        ResetCounter();
        Debug.Log(currentComboState);
    }

    void Punch()
    {
        if (Input.GetKeyDown(KeyCode.RightControl) || (Input.GetKeyDown(KeyCode.LeftControl)))
        {
            punch = true;
            if (punch) //&& !this.myAnimator.GetCurrentAnimatorStateInfo(0).IsTag("Punch"))
            {
                //myAnimator.SetTrigger("Punch");
                Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayers);
                Debug.Log(hitEnemies.Length);
                foreach (Collider enemy in hitEnemies)
                {
                    Debug.Log("Hit" + enemy.name);
                    enemy.GetComponent<EnemyController>().TakeDamage(attackDmg);
                    
                }

                AudioSource.PlayClipAtPoint(attackSound, this.transform.position);
                if (hitEnemies.Length > 0)
                {
                    IncreaseHitCounter();
                    AudioSource.PlayClipAtPoint(hitSound, this.transform.position);
                }
               

            }
        }
    }

    void Kick()
    {
        if (Input.GetKeyDown(KeyCode.Z) || (Input.GetKeyDown(KeyCode.Minus)))
        {
            kick = true;
            if (kick)// && !this.myAnimator.GetCurrentAnimatorStateInfo(0).IsTag("Kick"))
            {
                //myAnimator.SetTrigger("Kick");
                Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayers);
                Debug.Log(hitEnemies.Length);
                foreach (Collider enemy in hitEnemies)
                {
                    Debug.Log("Hit" + enemy.name);
                    enemy.GetComponent<EnemyController>().TakeDamage(attackDmg);
                }
                AudioSource.PlayClipAtPoint(attackSound, this.transform.position);
                if (hitEnemies.Length > 0)
                {
                    IncreaseHitCounter();
                    AudioSource.PlayClipAtPoint(hitSound, this.transform.position);
                }
            }
        }
    }

    void ComboAttacks()
    {
        if (Input.GetKeyDown(KeyCode.RightControl) || (Input.GetKeyDown(KeyCode.LeftControl)))
        {
            currentComboState++;
            activateTimerToReset = true;
            current_ComboTimer = default_ComboTimer;

            if (currentComboState == ComboState.KICK1 || currentComboState == ComboState.KICK2)
                return;

            if(currentComboState == ComboState.PUNCH1)
            {
                myAnimator.Play("Jab");
            }
            if (currentComboState == ComboState.PUNCH2)
            {
                myAnimator.Play("ElbowPunch");
            }
            if (currentComboState == ComboState.PUNCH3)
            {
                myAnimator.Play("CrossPunch");
            }
        }

        if (Input.GetKeyDown(KeyCode.Minus) || (Input.GetKeyDown(KeyCode.Less)))
        {

            if (currentComboState == ComboState.KICK2 || currentComboState == ComboState.PUNCH3)
                return;

            if(currentComboState == ComboState.NONE || currentComboState == ComboState.PUNCH1 || currentComboState == ComboState.PUNCH2)
            {
                currentComboState = ComboState.KICK1;
            }else if(currentComboState == ComboState.KICK1) {
                currentComboState++;
            }
            
            activateTimerToReset = true;
            current_ComboTimer = default_ComboTimer;

            if(currentComboState == ComboState.KICK1)
            {
                myAnimator.Play("HiKick");
            }

            if (currentComboState == ComboState.KICK2)
            {
                myAnimator.Play("ScissorKick");
            }
        }
    }

    void ResetComboState()
    {
        if (activateTimerToReset)
        {
            current_ComboTimer -= Time.deltaTime;

            if(current_ComboTimer <= 0)
            {
                currentComboState = ComboState.NONE;
                activateTimerToReset = false;
                current_ComboTimer = default_ComboTimer;
            }
        }
    }


    void ResetValues()
    {
        punch = false;
        kick = false;
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, this.attackRange);
    }

    private void IncreaseHitCounter()
    {
        textMeshPro.enabled = true;
        hitCount++;
        textMeshPro.text = hitCount.ToString() + "HITS";

    }

    private void ResetCounter() {

        if (activateTimerToReset)
        {
            currentTimer -= Time.deltaTime;

            if (currentTimer <= 0)
            {
                hitCount = 0;
                activateTimerToReset = false;
                currentTimer = defcounterTimer;
                textMeshPro.enabled = false;
            }
        }
        
        

    }

}
