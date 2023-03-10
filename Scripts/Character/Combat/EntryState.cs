namespace Character.Combat
{
    public class EntryState : MeleeBaseState
    {
        public override void OnEnter(StateMachine combatStateMachine)
        {
            base.OnEnter(combatStateMachine);

            AttackIndex = 1;
            Duration = Weapon.attackDuration.GetAttackDurationByAttackIndex(AttackIndex);
            AttackDamage = Weapon.attackDamage.GetAttackDamageByAttackIndex(AttackIndex);
            Animator.SetTrigger("Attack"+AttackIndex);
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
            
            if (FixedTime >= Duration)
            {
                if (ShouldCombo)
                {
                    StateMachineInstance.SetNextState(new ComboState());
                }
                else
                {
                    StateMachineInstance.SetNextStateToMain();
                }
            }
        }
    }
}