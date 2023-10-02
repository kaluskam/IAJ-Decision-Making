using Assets.Scripts.Game;
using Assets.Scripts.IAJ.Unity.DecisionMaking.ForwardModel;
using UnityEngine;

namespace Assets.Scripts.IAJ.Unity.DecisionMaking.ForwardModel.ForwardModelActions
{
    public class GetManaPotion : WalkToTargetAndExecuteAction
    {
        public GetManaPotion(AutonomousCharacter character, GameObject target) : base("GetManaPotion", character, target)
        {
        }

        public override bool CanExecute()
        {
            if (!base.CanExecute()) return false;
            return Character.baseStats.Mana < 10;
        }

        public override bool CanExecute(WorldModel worldModel)
        {
            //if (!base.CanExecute(worldModel)) return false;
            ////TODO
            //var currentHP = (int)worldModel.GetProperty(Properties.HP);
            //var maxHP = (int)worldModel.GetProperty(Properties.MAXHP);
            return true;
        }

        public override void Execute()
        {
            base.Execute();
            
            GameManager.Instance.GetManaPotion(this.Target);
        }

        public override float GetGoalChange(Goal goal)
        {
      
            return base.GetGoalChange(goal);
        }

        public override void ApplyActionEffects(WorldModel worldModel)
        {
            //base.ApplyActionEffects(worldModel);
            //var maxHP = (int)worldModel.GetProperty(Properties.MAXHP);
            //worldModel.SetProperty(Properties.HP, maxHP);
            //worldModel.SetGoalValue(AutonomousCharacter.SURVIVE_GOAL, 0.0f);

            ////disables the target object so that it can't be reused again
            //worldModel.SetProperty(this.Target.name, false);
        }

       
    }
}