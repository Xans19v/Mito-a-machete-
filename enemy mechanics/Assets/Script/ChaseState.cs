using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.Rendering;

public class ChaseState : IEnemyState
{
    public void EnterState(AgentController enemy)
    {
        enemy._agent.isStopped = false;
        enemy.animator?.SetBool("IsWalking", true);
        // enemy.animator?.SetBool("isRunning", true);
        // enemy.animator?.SetBool("isWalking", false);
    }

    public void UpdateState(AgentController enemy)
    {
        float distance = Vector3.Distance(enemy.transform.position, enemy.target.position);
        if (enemy.target == null) return;

        // persigue siempre hacia el jugador
        enemy._agent.SetDestination(enemy.target.position);

        if(distance <= enemy.attackRange)
        {
            enemy.ChangeState(new AttackState());
            return;
        }
        // si el jugador se escapa del rango, vuelve a patrullar
        if (!enemy.IsPlayerInRange())
        {
            enemy.ChangeState(new PatrrolState());
        }
    }

    public void ExitState(AgentController enemy)
    {
        enemy.animator?.SetBool("IsWalking", false);
        // enemy.animator?.SetBool("isRunning", false);
    }
}
