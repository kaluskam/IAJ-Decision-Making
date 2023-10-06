using Assets.Scripts.Game;
using Assets.Scripts.IAJ.Unity.DecisionMaking.ForwardModel;
using UnityEngine;

namespace Assets.Scripts.IAJ.Unity.DecisionMaking.ForwardModel.ForwardModelActions
{
    public class Rest : Action
    {
        private AutonomousCharacter Character { get; set; }
        private int HPChange { get; set; }
        public Rest(AutonomousCharacter character) : base("Rest")
        {
            this.Character = character;
            this.HPChange = Mathf.Max(Character.baseStats.MaxHP - Character.baseStats.HP, 2);
        }

        public override bool CanExecute()
        {
            if (!base.CanExecute()) return false;
            return Character.baseStats.HP < Character.baseStats.MaxHP;
        }

        public override bool CanExecute(WorldModel worldModel)
        {
            if (!base.CanExecute(worldModel)) return false;

            return (int)worldModel.GetProperty(Properties.HP) < (int)worldModel.GetProperty(Properties.MAXHP);
        }

        public override void Execute()
        {
            base.Execute();
            GameManager.Instance.Rest();
        }

        public override float GetGoalChange(Goal goal)
        {
            var change = base.GetGoalChange(goal);

            if (goal.Name == AutonomousCharacter.SURVIVE_GOAL)
            {
                change -= this.HPChange;
            }

            return change;
        }

        public override void ApplyActionEffects(WorldModel worldModel)
        {
            base.ApplyActionEffects(worldModel);
            var hp = (int)worldModel.GetProperty(Properties.HP);
            var hpChangeWorldModel = Mathf.Max((int)worldModel.GetProperty(Properties.MAXHP) - hp, 2);
            worldModel.SetProperty(Properties.ShieldHP, hpChangeWorldModel + hp);

            var goalValue = worldModel.GetGoalValue(AutonomousCharacter.SURVIVE_GOAL);
            worldModel.SetGoalValue(AutonomousCharacter.SURVIVE_GOAL, goalValue - hpChangeWorldModel);
        }

        public override float GetHValue(WorldModel worldModel)
        {
            //TODO
            return 0;
        }
    }
}
