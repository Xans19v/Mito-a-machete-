using UnityEngine;
using UnityEngine.AI;

public class AgentController : MonoBehaviour
{
    [Header("Componentes")]
    public NavMeshAgent _agent;
    public Transform target;
   public Animator animator;
    [Header("Parámetros de IA")]
    public float detectionRange; 
    public float waitTime;        
    public Vector3 patrolAreaCenter;
    public float patrolAreaRadius;
    public float attackRange;
    private IEnemyState currentState;

    private void Awake()
    {
         animator = GetComponent<Animator>(); 
        if (_agent == null) _agent = GetComponent<NavMeshAgent>();

    }
    private void Start()
    {
       
        _agent.stoppingDistance = attackRange;
        ChangeState(new PatrrolState());
       
        
      
        ChangeState(new PatrrolState());
    }

    private void Update()
    {
        // Actualizar el estado
        if (currentState != null)
        {
            currentState.UpdateState(this);
        }
    }

    public void ChangeState(IEnemyState newState)
    {
        // Salir del estado anterior
        if (currentState != null)
        {
            currentState.ExitState(this);
        }

        // Entrar al nuevo estado
        currentState = newState;

        if (currentState != null)
        {
            currentState.EnterState(this);
        }
    }

    public bool IsPlayerInRange()
    {
        if (target == null) return false;
        float distance = Vector3.Distance(transform.position, target.position);
        return distance < detectionRange;
    }

    public Vector3 GetRandomPatrolPoint()
    {
        Vector3 randomDirection = Random.insideUnitSphere * patrolAreaRadius;
        randomDirection += patrolAreaCenter;
        NavMeshHit hit;
        NavMesh.SamplePosition(randomDirection, out hit, patrolAreaRadius, 1);
        return hit.position;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRange);

        Gizmos.color= Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}

