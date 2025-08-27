using UnityEngine;

public class AttackState : IEnemyState
{
    public void EnterState(AgentController controller)
    {

        controller._agent.isStopped = true;
        Debug.Log("¡Atacando al jugador!");
        controller.animator?.SetBool("Attack",true);
        // Aquí pondrías animación de ataque
    }

    public void UpdateState(AgentController controller)
    {
        float distance = Vector3.Distance(controller.transform.position, controller.target.position);

        if (distance > 2.5f) // Si el jugador se aleja, volver a perseguir
        {
            controller.ChangeState(new ChaseState());
        }
        else
        {
            controller.ChangeState(new AttackState());
        }
    }

    public void ExitState(AgentController controller) 
    {
        controller.animator?.SetBool("Attack",false);
    }
}
