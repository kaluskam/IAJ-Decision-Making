
using Assets.Scripts.Game;
using UnityEngine;

namespace Assets.Scripts.IAJ.Unity.DecisionMaking.BehaviorTree.BehaviourTrees
{
    public class ChangeTarget : Task{ 
        NPC Character { get; set; }
        Vector3 Position1 { get; set; }
        Vector3 Position2 { get; set; }
        public ChangeTarget(NPC character, Vector3 position1, Vector3 position2)
        {
            this.Character = character; 
            this.Position1 = position1;
            this.Position2 = position2;
        }

        public override Result Run()
        {
            if (Vector3.Distance(Character.gameObject.transform.position, Position1) <= 0.2f)
            {
                this.Character.currentTarget = this.Position2;
            } else if (Vector3.Distance(Character.gameObject.transform.position, Position2) <= 0.2f)
            { 
                this.Character.currentTarget = this.Position1;
            }
            return Result.Success;
        }

    }

}