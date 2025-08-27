using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem.XR;

public class PatrrolState : IEnemyState
{
    [SerializeField] private float patrolRadius = 7f;

    public void EnterState(AgentController controller)
    {
        controller.animator?.SetBool("IsWalking",true);
        GoToRandomPoint(controller);
       
    }
    public void UpdateState(AgentController controller) 
    {
        if(!controller._agent.pathPending &&
            controller._agent.remainingDistance <= controller._agent.stoppingDistance)
        {
            controller.ChangeState(new WaitState());
        }
    }

    public void ExitState(AgentController controller)
    {
        controller.animator?.SetBool("IsWalking", false);
    }
    private void GoToRandomPoint(AgentController controller)
    {
        Vector3 randomDirection = Random.insideUnitSphere * patrolRadius + controller.transform.position;
        NavMeshHit hit;
        if(NavMesh.SamplePosition(randomDirection, out hit, patrolRadius, NavMesh.AllAreas))
        {
            controller._agent.SetDestination(hit.position);
        }
    }

}
