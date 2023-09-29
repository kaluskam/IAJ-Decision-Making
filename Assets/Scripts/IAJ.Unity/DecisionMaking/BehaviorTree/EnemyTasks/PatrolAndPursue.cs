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
    class PatrolAndPursue : Task
    {
        protected GameObject Character { get; set; }

        public Vector3 Position1 { get; set; }

        public Vector3 Position2 { get; set; }

        public Orc myMonster { get; set; }

        // Parameter for resetting to patrol after a chase
        public bool inChase { get; set; }

        public float range;

        public List<Orc> orcs = new List<Orc>();


        public PatrolAndPursue(Orc monster, GameObject character, Vector3 position1, Vector3 position2, float _range)
        {
            this.Character = character;
            this.Position1 = position1;
            this.Position2 = position2;
            this.myMonster = monster;
            this.inChase = false;
            range = _range;
            this.SetOrcs();
        }


        private void SetOrcs(){
            foreach(var orc in GameObject.FindObjectsOfType(typeof(Orc)))
            {
                this.orcs.Add((Orc)orc);
            }
        }
        public override Result Run()
        {

       
            var playerPosition = this.Character.transform.position;
            var orcPosition = this.myMonster.transform.position;


            // Check if i am near player

            if (Vector3.Distance(orcPosition, playerPosition) <= 20f)
           
            {
                this.myMonster.currentTarget = playerPosition;
                
                if (!inChase)
                {
                    this.myMonster.shout.PlayOneShot((AudioClip)Resources.Load("OrcShout2sec"));
                    foreach(var orc in this.orcs)
                    {

                    }
                }
                this.inChase = true;

                if (Vector3.Distance(orcPosition, playerPosition) <= 5f)
                { 
                return Result.Success;
                }


            }
            else //Need to choose the patrol point
            {   

                if (Vector3.Distance(orcPosition, Position1) <= range)
                {
                    this.myMonster.currentTarget = this.Position2;
                }
                else if (Vector3.Distance(orcPosition, Position2) <= range)
                {
                    this.myMonster.currentTarget = this.Position1;
                }

                //Resetting after a chase
                if (inChase) {
                    this.myMonster.currentTarget = this.Position1;
                    this.inChase = false;

                }

              
            }




            myMonster.StartPathfinding(myMonster.currentTarget);
            return Result.Running;

        }

    }
}