using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grade_12_Assignment_1_Daniel_K
{
    class SlenderGirl : Slender
    {
        protected const int SLENDERGIRL_HP = 40,
            SLENDERGIRL_ATTACK = 60,
            SLENDERGIRL_DEFENSE = 40,
            SLENDERGIRL_MAGIC = 60;
            
        protected const double SLENDERGIRL_CHANCE = 0.3;
        protected const string SLENDERGIRL_TYPE = "Slender Girl";

        public SlenderGirl() : this("") //0 Argument constructor for enemies
        {
        }
        /// <summary>
        /// //Constructs a SlenderGirl and applies stat values
        /// </summary>
        /// <param name="name">User made name</param>
        public SlenderGirl(string name)
            : base(name) 
        {
            TotalHealth = SLENDERGIRL_HP;
            CurrentHealth = SLENDERGIRL_HP;
            AttackPoints = SLENDERGIRL_ATTACK;
            DefensePoints = SLENDERGIRL_DEFENSE;
            MagicPoints = SLENDERGIRL_MAGIC;
            CatchChance = SLENDERGIRL_CHANCE;
            Type = SLENDERGIRL_TYPE;
            ExperiencePoints = GLOBAL_INIT_XP;
            IsAlive = true;
            IsWild = false;

        }
        public override void Attack(BagMonster enemy)
        {
            base.Attack(enemy);
        }
        public override void MagicAttack( BagMonster enemy)
        {
            MagicPoints -= 10;
            enemy.CurrentHealth -= 50;
        }
        
        public override void MagicBoost()
        {
            base.MagicBoost();
        }
        public override void Heal()
        {
            base.Heal();
        }
    }
}
