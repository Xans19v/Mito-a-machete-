using UnityEngine;
using UnityEngine.InputSystem.XR;

public class WaitState : IEnemyState
{
    private float timer;

    public void EnterState(AgentController controller)
    {
        timer = controller.waitTime;

       
        controller._agent.isStopped = true;
        controller._agent.ResetPath();

     
    }

    public void UpdateState(AgentController enemy)
    {
        // si el jugador entra en rango, interrumpe la espera y persigue
        if (enemy.IsPlayerInRange())
        {
            enemy.ChangeState(new ChaseState());
            return;
        }

        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            // termina la espera → vuelve a patrullar
            enemy._agent.isStopped = false;
            enemy.ChangeState(new PatrrolState());
        }
    }

    public void ExitState(AgentController enemy)
    {
        // por si acaso, habilita movimiento al salir
        enemy._agent.isStopped = false;
    }
}
