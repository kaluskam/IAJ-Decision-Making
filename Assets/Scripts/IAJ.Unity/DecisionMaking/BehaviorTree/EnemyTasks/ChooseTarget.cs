using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.AI;
using Assets.Scripts.Game.NPCs;
using Assets.Scripts.Game;

namespace Assets.Scripts.IAJ.Unity.DecisionMaking.BehaviorTree.EnemyTasks
{
    class ChooseTarget : Task
    {
        protected GameObject Character { get; set; }

        public Vector3 Position1 { get; set; }
        
        public Vector3 Position2 { get; set; }
        
        public Orc myMonster { get; set; }
        public float range;

      
        public ChooseTarget(Orc monster, GameObject character, Vector3 position1 , Vector3 position2, float _range)
        {
            this.Character = character;
            this.Position1 = position1;
            this.Position2 = position2;
            this.myMonster = monster;
            range = _range;
        }

        public override Result Run()
        {

            
            var playerPosition = this.Character.transform.position;
            var orcPosition = this.myMonster.transform.position;

            // Check if i am near player
            this.myMonster.currentTarget = playerPosition;
            if (Vector3.Distance(orcPosition, playerPosition) <= range)
            {
                this.myMonster.currentTarget = playerPosition;
                
               
            }
            else //Need to choose the patrol point
            {
                if (Vector3.Distance(Character.gameObject.transform.position, Position1) <= range)
                {
                    this.myMonster.currentTarget = this.Position2;
                }
                else if (Vector3.Distance(Character.gameObject.transform.position, Position2) <= range)
                {
                    this.myMonster.currentTarget = this.Position1;
                }
                
            }

            var originalPos = myMonster.GetDistanceToTarget(orcPosition, this.myMonster.currentTarget);

            

            return Result.Success;
        }

    }
}