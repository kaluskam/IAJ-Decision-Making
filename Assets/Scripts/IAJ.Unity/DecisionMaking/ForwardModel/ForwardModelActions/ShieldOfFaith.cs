using Assets.Scripts.Game;
using Assets.Scripts.IAJ.Unity.DecisionMaking.ForwardModel;
using UnityEngine;

namespace Assets.Scripts.IAJ.Unity.DecisionMaking.ForwardModel.ForwardModelActions
{
    public class ShieldOfFaith : Action
    {

        private float ShieldHPChange;
        private AutonomousCharacter Character;
        public ShieldOfFaith(AutonomousCharacter character) : base("DivineSmite")
        {
            this.Character = character;
            this.ShieldHPChange = 5 - Character.baseStats.ShieldHP;
        }

        public override bool CanExecute()
        {
            if (!base.CanExecute()) return false;
            return Character.baseStats.Mana >= 5;
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
            GameManager.Instance.ShieldOfFaith();
        }

        public override float GetGoalChange(Goal goal)
        {
            var change = base.GetGoalChange(goal);

            if (goal.Name == AutonomousCharacter.SURVIVE_GOAL)
            {
                change -= this.ShieldHPChange;
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
