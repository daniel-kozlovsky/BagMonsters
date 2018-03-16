using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grade_12_Assignment_1_Daniel_K
{
    class BoogeyChild : Boogey
    {
        protected const int BOOGEYBOY_HP = 50, //health
            BOOGEYBOY_ATTACK = 50, //attack points
            BOOGEYBOY_DEFENSE = 50, //defense points
            BOOGEYBOY_MAGIC = 50; //defense points
            
        protected const double BOOGEYBOY_CHANCE = 0.5;
        protected const string BOOGEYBOY_TYPE = "Boogey Boy";

        public BoogeyChild():this("")
        {

        }
        /// <summary>
        /// //Constructs a Boogeyboy and applies stat values
        /// </summary>
        /// <param name="name">User made name</param>
        public BoogeyChild(string name)
            : base(name)
        {
            TotalHealth = BOOGEYBOY_HP;
            CurrentHealth = BOOGEYBOY_HP;
            AttackPoints = BOOGEYBOY_ATTACK;
            DefensePoints = BOOGEYBOY_DEFENSE;
            MagicPoints = BOOGEYBOY_MAGIC;
            CatchChance = BOOGEYBOY_CHANCE;
            Type = BOOGEYBOY_TYPE;
            ExperiencePoints = GLOBAL_INIT_XP;
            IsAlive = true;
            IsWild = false;

        }

        public override void Attack(BagMonster enemy)
        {
            
            if(enemy is Boogey)
            {
                enemy.CurrentHealth -= 10;//10 damage to boogey men
            }
            else { enemy.CurrentHealth -= 15; }//everything else
        }
        public override void MagicAttack(BagMonster enemy)
        {
            enemy.CurrentHealth -= 25;
            MagicPoints -= 10;
        }
        public override void Heal() 
        {
            base.Heal();
        }
        public override void MagicBoost()
        {
            base.MagicBoost();
        }
    }
}
