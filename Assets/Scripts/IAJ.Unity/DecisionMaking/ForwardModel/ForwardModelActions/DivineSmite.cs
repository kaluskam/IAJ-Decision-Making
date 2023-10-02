using Assets.Scripts.Game;
using Assets.Scripts.IAJ.Unity.DecisionMaking.ForwardModel;
using UnityEngine;

namespace Assets.Scripts.IAJ.Unity.DecisionMaking.ForwardModel.ForwardModelActions
{
    public class DivineSmite : WalkToTargetAndExecuteAction
    {
        private float expectedXPChange;

        public DivineSmite(AutonomousCharacter character, GameObject target) : base("DivineSmite", character, target)
        {
            if(target.tag.Equals("Skeleton"))
            {
                this.expectedXPChange = 2.7f;
            }
            else if (target.tag.Equals("Orc"))
            {
                this.expectedXPChange = 7.0f;
            }
            else if (target.tag.Equals("Dragon"))
            {
                this.expectedXPChange = 10.0f;
            }
        }

        public override bool CanExecute()
        {
            if (!base.CanExecute()) return false;
            return Character.baseStats.Mana >= 2;
        }

        public override bool CanExecute(WorldModel worldModel)
        {
            //if (!base.CanExecute(worldModel)) return false;

            //var currentHP = (int)worldModel.GetProperty(Properties.HP);
            //var maxHP = (int)worldModel.GetProperty(Properties.MAXHP);
            return true;
        }

        public override void Execute()
        {
            base.Execute();
            GameManager.Instance.DivineSmite(this.Target);
        }

        public override float GetGoalChange(Goal goal)
        {
            var change = base.GetGoalChange(goal);

            if (goal.Name == AutonomousCharacter.GAIN_LEVEL_GOAL)
            {
                change -= this.expectedXPChange;
            }

            return change;
        }

        public override void ApplyActionEffects(WorldModel worldModel)
        {
        //    base.ApplyActionEffects(worldModel);
        //    var maxHP = (int)worldModel.GetProperty(Properties.MAXHP);
        //    worldModel.SetProperty(Properties.HP, maxHP);
        //    worldModel.SetGoalValue(AutonomousCharacter.SURVIVE_GOAL, 0.0f);

        //    //disables the target object so that it can't be reused again
        //    worldModel.SetProperty(this.Target.name, false);
        }

        public override float GetHValue(WorldModel worldModel)
        {
            //TODO
            return 0;
        }
    }
}
