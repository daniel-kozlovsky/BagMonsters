using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Grade_12_Assignment_1_Daniel_K
{
    static class World
    {
        
        public static Random rand = new Random();//Random number generator
        //************************************************************************************************************************
        
        /// <summary>
        /// Creates a new monster in the bag
        /// </summary>
        /// <param name="player">User</param>
        /// <param name="name">Name of users monster</param>
        /// <param name="typeMonster">Boogey, BoogeyBoy, Slender, SlenderChild</param>
        public static void CreatePlayerMonster(ref Player player, string name, string typeMonster, ref ListBox lb) //Creates monster and related actions
        {
            lb.Height += lb.ItemHeight;
            player.MonsterCount++;//increases ammount of monsters.
            switch (typeMonster)
            {
                case "Boogey":
                    player.bagMonsters[player.MonsterCount - 1] = new Boogey(name);
                    break;
                case "Boogey Boy":
                    player.bagMonsters[player.MonsterCount - 1] = new BoogeyChild(name);
                    break;
                case "Slender":
                    player.bagMonsters[player.MonsterCount - 1] = new Slender(name);
                    break;
                case "Slender Girl":
                    player.bagMonsters[player.MonsterCount - 1] = new SlenderGirl(name);
                    break;
            }
            
            
            
            
            lb.Items.Add(player.bagMonsters[player.MonsterCount-1].Type);// new monster in the bag
            
            
            
        }
        //*************************************************************************************************************************
        public static void RemoveMonster(ref Player p, ref BagMonster b, ref ListBox lb)//Deletes monster and related actions
        {
            
            p.MonsterCount--;
            
            lb.Items.RemoveAt(Array.IndexOf(p.bagMonsters, b));
            lb.SelectedIndex = -1;
            lb.Height -= lb.ItemHeight;
            b = null;
            SortMonsterArray(p.bagMonsters);
            
        }
        public static void SortMonsterArray(BagMonster[] playerMonsters)//sorts the monsters so null gaps are full
        {
            int largestNonNullndex =0;
            for (int i = playerMonsters.Length-1; i > -1; i--)
            {
                if(playerMonsters[i] != null)
                {
                    largestNonNullndex = i;
                }
            }
            for (int i = 0; i < playerMonsters.Length; i++)
            {
                if(playerMonsters[i] == null)
                {
                    
                    playerMonsters[i] = playerMonsters[largestNonNullndex];
                    playerMonsters[largestNonNullndex] = null;
                    break;
                }
            }
        }
        public static BagMonster GetRandomMonster()//chooses random monster
        {

            int r = rand.Next(0, 4);
            switch (r)
            {
                case 0:
                    return new Slender();
                case 1:
                    return new SlenderGirl();
                case 2:
                    return new Boogey();
                case 3:
                    return new BoogeyChild();
            }
            return null;


        }
        public static int getXP(BagMonster enemy)//checks for type of monster and returns xp based on state
        {
            switch (enemy.Type)
            {
                case "Boogey":
                    return 50;
                case "Boogey Boy":
                    return 20;
                case "Slender":
                    return 100;
                case "Slender Girl":
                    return 30;
            }
            return 0;
        }
        public static void RefillHealth(BagMonster[] playerMonsters)//refills all boogey health
        {
            for(int i = 0; i<playerMonsters.Length; i++)
            {
                if(playerMonsters[i] != null && (playerMonsters[i] is Boogey || playerMonsters[i] is BoogeyChild))
                {
                    playerMonsters[i].CurrentHealth = playerMonsters[i].TotalHealth;
                }
            }
        }
        public static void EndGame(ref Player player, ref BagMonster enemy, ListBox lb)//Kicks the player out of the world, ending the game
        {
            //Resets stats
            enemy = null;
            for(int i = 0; i<player.bagMonsters.Length; i++)
            {
                player.bagMonsters[i] = null;
            }
            
            //reset listbox
            lb.Items.Clear();
            //total xp gained + clears player
            MessageBox.Show("You have been kicked out!\nYour total experience gained: " +player.TotalXPGained.ToString());
            player = null;
            
            
        }
        public static void EnemyTurn(BagMonster playerMonster, BagMonster enemy, Label narrator)//enemy turn (AI)
        {
            /************************************************************************************************************/
            if(enemy is Slender || enemy is SlenderGirl)//actions for enemy Slender type
            {
                if(enemy.MagicPoints <=20)//recharge magic if low
                {
                    enemy.MagicBoost();
                    narrator.Text = "The enemy has boosted their magic points!";
                }
                else if (playerMonster.CurrentHealth <=50 && enemy.MagicPoints >=10)//finish a player off if low health
                {
                    enemy.MagicAttack(playerMonster);
                    narrator.Text = "The enemy has attacked you with magic!";
                }
                else if(enemy.MagicPoints >= 10)//random attack if enough magic
                {
                    int x = rand.Next(0, 2);
                    if(x == 0)
                    {
                        enemy.MagicAttack(playerMonster);//magic attack
                        narrator.Text = "The enemy has attacked you with magic!";
                    }
                    else if(x==1)
                    {
                        enemy.Attack(playerMonster);//attack
                        narrator.Text = "The enemy has attacked you with fists!";
                    }
                }
                else
                {
                    enemy.Attack(playerMonster);
                    narrator.Text = "The enemy has attacked you with fists!";
                }
            }
            else if(enemy is Boogey || enemy is BoogeyChild)//actions for enemy boogey type
            {
                if (enemy.CurrentHealth <= 30 && enemy.MagicPoints >= 10)//heal when health is low
                {
                    enemy.Heal();
                    narrator.Text = "The enemy has healed!";

                }
                else if(enemy.MagicPoints >=10)//when enough magic
                {
                    int i = rand.Next(0, 2);//random between magic attack and normal attack
                    if(i == 0)
                    {
                        enemy.MagicAttack(playerMonster);
                        narrator.Text = "The enemy has attacked you with magic!";
                    }
                    else if(i ==1)
                    {
                        enemy.Attack(playerMonster);
                        narrator.Text = "The enemy has attacked you with fists!";
                    }
                }
                else//when no points for magic or heal uneccesary
                {
                    enemy.Attack(playerMonster);
                    narrator.Text = "The enemy has attacked you with fists!";
                }
            }
            /******************************************************************************************************/
            //Checks for death and sets it to dead
            if (playerMonster.CurrentHealth == 0)
            {
                playerMonster.IsAlive = false;
               
            }
            
            
            
        }

    }
}
