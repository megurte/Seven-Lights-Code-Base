namespace Character.Combat
{
    public class ComboState : MeleeBaseState
    {
        public override void OnEnter(StateMachine combatStateMachine)
        {
            base.OnEnter(combatStateMachine);

            AttackIndex = 2;
            Duration = 0.5f;
            AttackDamage = Weapon.attacks.GetAttackDamageByAttackIndex(AttackIndex);
            Animator.SetTrigger("Attack"+AttackIndex);
        }
        
        public override void OnUpdate()
        {
            base.OnUpdate();

            if (FixedTime >= Duration)
            {
                if (ShouldCombo)
                {
                    StateMachineInstance.SetNextState(new FinisherState());
                }
                else
                {
                    StateMachineInstance.SetNextStateToMain();
                }
            }
        }
    }
}