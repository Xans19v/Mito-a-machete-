using UnityEngine;

public interface IEnemyState 
{
  void EnterState(AgentController controller);
    void UpdateState(AgentController controller);
    void ExitState(AgentController controller);
}
