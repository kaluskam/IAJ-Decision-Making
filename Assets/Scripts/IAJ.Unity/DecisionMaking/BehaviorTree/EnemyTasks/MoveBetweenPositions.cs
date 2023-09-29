using Assets.Scripts.Game;
using Assets.Scripts.Game.NPCs;
using Assets.Scripts.IAJ.Unity.DecisionMaking.BehaviorTree.EnemyTasks;
using System.Collections.Generic;
using System.IO.Pipes;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

namespace Assets.Scripts.IAJ.Unity.DecisionMaking.BehaviorTree.BehaviourTrees
{
    public class MoveBetweenPositions : Sequence
    {

        public MoveBetweenPositions(NPC character, Vector3 position1, Vector3 position2) {
            this.children = new List<Task>()
            {
                new ChangeTarget(character, position1, position2),
                new MoveTo(character, character.currentTarget, 1.0f),
                new MoveTo(character, position1, 1.0f)
            };
        }
    }
}