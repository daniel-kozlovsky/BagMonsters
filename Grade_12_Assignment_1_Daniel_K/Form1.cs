using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Grade_12_Assignment_1_Daniel_K
{
    public partial class Form1 : Form
    {
         
         Player MainPlayer;//New player instance
         BagMonster enemyMonster;//Enemy bagmonster instance of bagmonster

        public Form1()
        {
            InitializeComponent();
            InitializeMyComponents();//My Components
            
            
        }
        private void InitializeMyComponents()
        {
            
            //buttons
            btnAttack.Visible = false;
            
            btnMagicAttack.Visible = false;
            btnMagicHeal.Visible = false;
            btnLevelUp.Visible = false;
            btnMonsterRename.Visible = false;
            btnRelease.Visible = false;
            
            //misc
            picBoxEnemy.Image = null;
            picBoxPlayerMonster.Image = null;
            picBoxPlayerMonsterIcon.Image = null;
            pictureBox1.Image = null;
            picBoxPlayerMonster.BackColor = Color.Transparent;
            picBoxPlayerMonster.Location = new Point(220, 70);
            picBoxBackGround.BackColor = Color.Transparent;
            picBoxPlayerMonster.Parent = picBoxBackGround;
            picBoxEnemy.Parent = picBoxBackGround;
            picBoxEnemy.Location = new Point(10, 70);
            listBox1.Visible = false;
            pnlGameStart.BringToFront();
            pnlGameStart.Show();
            pictureBox1.Visible = true;
            listBox1.IntegralHeight = false;
            listBox1.Height = 5;
            listBoxPlayerStart.SelectedIndex = -1;
            txtBoxRename.Visible = false;
            txtBoxInitMonsterName.Text = "";
            txtBoxPlayerName.Text = "";
            //labels
            lblNarrator.Text = "";
            lblPlayerName.Text = "";
            lblActions.Text = "";
            ClearEnemyStatLabels();
            ClearStatLabels();
            
        }
        public void UpdateActions()
        {
            lblActions.Text = "Actions Left: " + MainPlayer.NumActions.ToString();
        }
        public void ClearStatLabels()//clears the stat labels
        {
            picBoxPlayerMonster.Image = null;
            picBoxPlayerMonsterIcon.Image = null;
            
            lblSelectedAttack.Text = "";
            lblSelectedDefense.Text = "";
            lblSelectedHealth.Text = "";
            lblSelectedMagic.Text = "";
            lblSelectedName.Text = "";
            lblSelectedType.Text = "";
            lblSelectedXP.Text = "";
            
        }
        public void ClearEnemyStatLabels()//clear enemy stats labels
        {
            picBoxEnemy.Image = null;
            

            lblEnemyAttack.Text = "";
            lblEnemyDefense.Text = "";
            lblEnemyMagic.Text = "";
            lblEnemyHealth.Text = "";
            lblEnemyAttack.Text = "";
            lblEnemyType.Text = "";
        }
        //update labels
        public void UpdateEnemyStatLabels()
        {
            if (enemyMonster != null)
            {
                switch (enemyMonster.Type)
                {
                    case "Boogey":
                        picBoxEnemy.Image = Properties.Resources.boogey_man;
                        break;
                    case "Boogey Boy":
                        picBoxEnemy.Image = Properties.Resources.boogey_boy;
                        break;
                    case "Slender":
                        picBoxEnemy.Image = Properties.Resources.slender_woman;
                        break;
                    case "Slender Girl":
                        picBoxEnemy.Image = Properties.Resources.slender_girl;
                        break;

                }
                picBoxEnemy.Image.RotateFlip(RotateFlipType.Rotate180FlipY);
                lblEnemyAttack.Text = "Attack Points: " + enemyMonster.AttackPoints.ToString();
                lblEnemyDefense.Text = "Defense: " + enemyMonster.DefensePoints.ToString();
                lblEnemyHealth.Text = "Health: " + enemyMonster.CurrentHealth.ToString() + "/" + enemyMonster.TotalHealth.ToString();
                lblEnemyMagic.Text = "Magic Points: " + enemyMonster.MagicPoints.ToString();
                lblEnemyType.Text = "Type: " + enemyMonster.Type;
            }
            else
            {
                ClearEnemyStatLabels();
            }
        
        }
        public void UpdateSelectedStatLabels()
        {
            if (listBox1.SelectedIndex != -1 && MainPlayer.bagMonsters[listBox1.SelectedIndex] != null)
            {
                
                    lblSelectedAttack.Text = "Attack Points: " + MainPlayer.bagMonsters[listBox1.SelectedIndex].AttackPoints.ToString();
                    lblSelectedName.Text = "Name: " + MainPlayer.bagMonsters[listBox1.SelectedIndex].Name;
                    lblSelectedDefense.Text = "Defense: " + MainPlayer.bagMonsters[listBox1.SelectedIndex].DefensePoints.ToString();
                    lblSelectedHealth.Text = "Health: " + MainPlayer.bagMonsters[listBox1.SelectedIndex].CurrentHealth.ToString() + "/" + MainPlayer.bagMonsters[listBox1.SelectedIndex].TotalHealth.ToString();
                    lblSelectedMagic.Text = "Magic Points: " + MainPlayer.bagMonsters[listBox1.SelectedIndex].MagicPoints.ToString();
                    lblSelectedType.Text = "Type: " + MainPlayer.bagMonsters[listBox1.SelectedIndex].Type;
                    lblSelectedXP.Text = "Xp: " + MainPlayer.bagMonsters[listBox1.SelectedIndex].ExperiencePoints.ToString();
            }
            else 
            { 
                ClearStatLabels(); 
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnGameStart_Click(object sender, EventArgs e)//Start game
        {
            if (txtBoxPlayerName.Text == "")//makes sure player has a name
            {
                MessageBox.Show("Must make a player name!");
            }
            else if(txtBoxInitMonsterName.Text == "")//makes sure monster is named
            {
                MessageBox.Show("Name your Bag Monster!");
            }
            else if (listBoxPlayerStart.SelectedIndex == -1)//checks that monster is selected
            {
                MessageBox.Show("Select a monster!");
            }
            else
            {
                MainPlayer = new Player(txtBoxPlayerName.Text);//new player definition
                
                

                switch (listBoxPlayerStart.SelectedIndex)//makes coresponding monster
                {
                    case 0://when Slender Girl is selected
                        World.CreatePlayerMonster(ref MainPlayer, txtBoxInitMonsterName.Text, "Slender Girl", ref listBox1);
                        break;
                    case 1://when Boogey Boy is selected
                        World.CreatePlayerMonster(ref MainPlayer, txtBoxInitMonsterName.Text, "Boogey Boy", ref listBox1);
                        break;
                }
                pnlGame.Show();
                pnlGameStart.Hide();
                lblPlayerName.Text = MainPlayer.PlayerName;
                UpdateActions();

            }
        }

        private void button3_Click(object sender, EventArgs e)//Display Bag
        {
            listBox1.SelectedIndex = -1;
            btnRelease.Visible = false;
            btnLevelUp.Visible = false;
            btnMonsterRename.Visible = false;
            btnMagicAttack.Visible = false;
            btnAttack.Visible = false;
            btnMagicHeal.Visible = false;
            
           
           

            switch(listBox1.Visible)//checks if visible or not and shows or hides depending on the state
            {
                case true:
                    listBox1.Visible = false;
                    break;
                case false:
                    listBox1.Visible = true;
                    break;
            }
            ClearStatLabels();

        }

        private void button1_Click(object sender, EventArgs e)//Look for bag monster
        {
            if (MainPlayer.NumActions == 0)
            {
                World.EndGame(ref MainPlayer, ref enemyMonster, listBox1);
                InitializeMyComponents();

            }
            else
            {
                //actions
                MainPlayer.NumActions--;
                UpdateActions();

                int r = World.rand.Next(0, 2);
                if (r == 0)
                {
                    lblNarrator.Text = "No monster found";
                    ClearEnemyStatLabels();

                }
                else if (r == 1)
                {
                    enemyMonster = World.GetRandomMonster();
                    lblNarrator.Text = "Found a " + enemyMonster.Type;

                    //stats for enemy label update
                    UpdateEnemyStatLabels();
                }


            }
        }

       

        private void listBoxPlayerStart_SelectedIndexChanged(object sender, EventArgs e)//when selected index changes
        {
            switch (listBoxPlayerStart.SelectedIndex)
            {
                case 0://when Slender Girl is selected
                    pictureBox1.Image = Properties.Resources.slender_girl;
                    break;
                case 1://when Boogey Boy is selected
                    pictureBox1.Image = Properties.Resources.boogey_boy;
                    break;
            }
        }

        private void button4_Click(object sender, EventArgs e)//Catch
        {
            if (MainPlayer.NumActions == 0)
            {
                World.EndGame(ref MainPlayer, ref enemyMonster,listBox1);
                InitializeMyComponents();
            }
            else
            {
                //actions
                MainPlayer.NumActions--;
                UpdateActions();


                int i = World.rand.Next(0, 101);
                if (enemyMonster == null)
                {
                    lblNarrator.Text = "No monster to catch!";
                }
                else if (i <= enemyMonster.CatchChance * 100)
                {
                    lblNarrator.Text = "You caught it!";

                    World.CreatePlayerMonster(ref MainPlayer, "N/a", enemyMonster.Type, ref listBox1);
                    enemyMonster = null;
                    ClearEnemyStatLabels();
                }
                else//fail to catch
                {
                    if (listBox1.Items.Count == 0)//ends game
                    {
                        World.EndGame(ref MainPlayer, ref enemyMonster, listBox1);
                        InitializeMyComponents();
                    }
                    else
                    {
                        int y = World.rand.Next(0, listBox1.Items.Count);//attacks random monster in bag
                        lblNarrator.Text = "Failed to catch! The enemy attacks!";
                        World.EnemyTurn(MainPlayer.bagMonsters[y], enemyMonster, lblNarrator);
                        if (MainPlayer.bagMonsters[y].IsAlive == false)//checks for player monster death
                        {
                            lblNarrator.Text = MainPlayer.bagMonsters[y].Name + " has died!";
                            World.RemoveMonster(ref MainPlayer, ref MainPlayer.bagMonsters[y], ref listBox1);//removes monster
                            //hides buttons
                            btnRelease.Visible = false;
                            btnLevelUp.Visible = false;
                            btnMonsterRename.Visible = false;
                            btnMagicAttack.Visible = false;
                            btnAttack.Visible = false;
                            btnMagicHeal.Visible = false;
                            //
                        }
                    }
                }


            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)//When bagmonster from bag is selected
        {
            
            
            if (listBox1.SelectedIndex != -1)
            {
                switch (MainPlayer.bagMonsters[listBox1.SelectedIndex].Type)
                {
                    case "Boogey":
                        picBoxPlayerMonsterIcon.Image = Properties.Resources.boogey_man;
                        picBoxPlayerMonster.Image = Properties.Resources.boogey_man;
                        break;
                    case "Boogey Boy":
                        picBoxPlayerMonsterIcon.Image = Properties.Resources.boogey_boy;
                        picBoxPlayerMonster.Image = Properties.Resources.boogey_boy;
                        break;
                    case "Slender":
                        picBoxPlayerMonsterIcon.Image = Properties.Resources.slender_woman;
                        picBoxPlayerMonster.Image = Properties.Resources.slender_woman;
                        break;
                    case "Slender Girl":
                        picBoxPlayerMonsterIcon.Image = Properties.Resources.slender_girl;
                        picBoxPlayerMonster.Image = Properties.Resources.slender_girl;
                        break;
                        
                }
                
                
                if (MainPlayer.bagMonsters[listBox1.SelectedIndex] is Slender || MainPlayer.bagMonsters[listBox1.SelectedIndex] is SlenderGirl)
                {
                    btnMagicHeal.Text = "Magic attack";

                }
                else if (MainPlayer.bagMonsters[listBox1.SelectedIndex] is Boogey ||
                    MainPlayer.bagMonsters[listBox1.SelectedIndex] is BoogeyChild)
                {
                    btnMagicHeal.Text = "Heal";
                }
            
                //picturebox image chosen
                UpdateSelectedStatLabels();//updates labels for stats

                btnMagicAttack.Visible = true;
                btnAttack.Visible = true;
                btnRelease.Visible = true;
                btnLevelUp.Visible = true;
                btnMonsterRename.Visible = true;
                btnMagicHeal.Visible = true;
                //checks for the type of monster to show the right buttons



            }
            else 
            { 
                picBoxPlayerMonsterIcon.Image = null;
                
            }
        }

        private void btnRelease_Click(object sender, EventArgs e)//release
        {
            DialogResult releaseWarning = MessageBox.Show("Are you sure?", "Release", MessageBoxButtons.YesNo);
            if(releaseWarning == DialogResult.Yes)
            {
                World.RemoveMonster(ref MainPlayer, ref MainPlayer.bagMonsters[listBox1.SelectedIndex],ref listBox1);//remove monster
                ClearStatLabels();
            }
            //remove buttons to prevent buggery
            btnAttack.Visible = false;
            btnMagicAttack.Visible = false;
            btnMagicHeal.Visible = false;
            btnLevelUp.Visible = false;
            btnMonsterRename.Visible = false;
            btnRelease.Visible = false;
            //************************************
            
        }

        private void btnMonsterRename_Click(object sender, EventArgs e)//rename
        {
            if(txtBoxRename.Visible == true)
            {
                 if(btnMonsterRename.Text == "Confirm?")
                 {
                    MainPlayer.bagMonsters[listBox1.SelectedIndex].Name = txtBoxRename.Text;
                    btnMonsterRename.Text = "Rename";
                 }
                 
                 txtBoxRename.Visible = false;
            }
            else 
            {
                
                txtBoxRename.Visible = true;
            }
            txtBoxRename.Text = MainPlayer.bagMonsters[listBox1.SelectedIndex].Name;
            
           
            
            UpdateSelectedStatLabels();
        }

        private void btnLevelUp_Click(object sender, EventArgs e)//level up
        {
            //xp condition//
                switch (MainPlayer.bagMonsters[listBox1.SelectedIndex].Type)
                {
                    case "Boogey Boy":
                        if (MainPlayer.bagMonsters[listBox1.SelectedIndex].ExperiencePoints >= 50)//50 xp needed for boogey
                        {
                            BagMonster tempA = new Boogey(MainPlayer.bagMonsters[listBox1.SelectedIndex].Name);
                            MainPlayer.bagMonsters[listBox1.SelectedIndex] = tempA;
                        }
                        else { MessageBox.Show("Not enough Experience!"); }
                        break;
                    case "Slender Girl":
                        if (MainPlayer.bagMonsters[listBox1.SelectedIndex].ExperiencePoints >= 30)//30 xp needed for Slender
                        {
                            BagMonster tempB = new Slender(MainPlayer.bagMonsters[listBox1.SelectedIndex].Name);
                            MainPlayer.bagMonsters[listBox1.SelectedIndex] = tempB;
                        }
                        else { MessageBox.Show("Not enough Experience!"); }
                        break;
                }
                listBox1.Items[listBox1.SelectedIndex] = MainPlayer.bagMonsters[listBox1.SelectedIndex].Type;
                UpdateSelectedStatLabels();


            }
        


        private void btnAttack_Click(object sender, EventArgs e)//attack
        {
            if (MainPlayer.NumActions == 0)
            {
                World.EndGame(ref MainPlayer, ref enemyMonster, listBox1);
                InitializeMyComponents();
            }
            else
            {
                if (enemyMonster != null)
                {
                    if (MainPlayer.bagMonsters[listBox1.SelectedIndex] != null)
                    {
                        //actions
                        MainPlayer.NumActions--;
                        UpdateActions();
                        MainPlayer.bagMonsters[listBox1.SelectedIndex].Attack(enemyMonster);//attack
                        if (enemyMonster.CurrentHealth == 0)
                        {
                            lblNarrator.Text = "You have defeated the monster";//kills the monster when at 0 health\
                            World.RefillHealth(MainPlayer.bagMonsters);//refill health

                            MainPlayer.bagMonsters[listBox1.SelectedIndex].ExperiencePoints += World.getXP(enemyMonster);//add xp
                            MainPlayer.TotalXPGained += World.getXP(enemyMonster);//add xp

                            enemyMonster = null;
                        }
                        else
                        {
                            World.EnemyTurn(MainPlayer.bagMonsters[listBox1.SelectedIndex], enemyMonster, lblNarrator);//enemy turn
                            if (MainPlayer.bagMonsters[listBox1.SelectedIndex].IsAlive == false)
                            {
                                lblNarrator.Text = MainPlayer.bagMonsters[listBox1.SelectedIndex].Name + " has died!";
                                World.RemoveMonster(ref MainPlayer, ref MainPlayer.bagMonsters[listBox1.SelectedIndex], ref listBox1);
                                //hides buttons
                                btnRelease.Visible = false;
                                btnLevelUp.Visible = false;
                                btnMonsterRename.Visible = false;
                                btnMagicAttack.Visible = false;
                                btnAttack.Visible = false;
                                btnMagicHeal.Visible = false;
                                //
                            }
                        }
                        
                    }
                    else
                    {
                        lblNarrator.Text = "No Bagmonster to fight with!";
                    }
                }
                else { lblNarrator.Text = "No monster to fight!"; }
                //label updates
                UpdateEnemyStatLabels();
                UpdateSelectedStatLabels();




            }
        }

        private void btnMagicAttack_Click(object sender, EventArgs e)//magic attack
        {
            if (MainPlayer.NumActions == 0)
            {
                World.EndGame(ref MainPlayer, ref enemyMonster, listBox1);
                InitializeMyComponents();
            }
            else
            {
                
                if (enemyMonster != null)
                {
                    if (MainPlayer.bagMonsters[listBox1.SelectedIndex] != null)
                    {
                        if (MainPlayer.bagMonsters[listBox1.SelectedIndex].MagicPoints >= 10)
                        {
                            //actions
                            MainPlayer.NumActions--;
                            UpdateActions();

                            MainPlayer.bagMonsters[listBox1.SelectedIndex].MagicAttack(enemyMonster);//magic attack
                            if (enemyMonster.CurrentHealth == 0)
                            {
                                lblNarrator.Text = "You have defeated the enemy!";
                                World.RefillHealth(MainPlayer.bagMonsters);//refill health
                                MainPlayer.bagMonsters[listBox1.SelectedIndex].ExperiencePoints += World.getXP(enemyMonster);//add xp
                                MainPlayer.TotalXPGained += World.getXP(enemyMonster);//add xp for player
                                enemyMonster = null;
                            }
                            else
                            {
                                World.EnemyTurn(MainPlayer.bagMonsters[listBox1.SelectedIndex], enemyMonster, lblNarrator);//enemy turn
                                if (MainPlayer.bagMonsters[listBox1.SelectedIndex].IsAlive == false)//checks for player monster death
                                {
                                    lblNarrator.Text = MainPlayer.bagMonsters[listBox1.SelectedIndex].Name + " has died!";
                                    World.RemoveMonster(ref MainPlayer, ref MainPlayer.bagMonsters[listBox1.SelectedIndex], ref listBox1);
                                    //hides buttons
                                    btnRelease.Visible = false;
                                    btnLevelUp.Visible = false;
                                    btnMonsterRename.Visible = false;
                                    btnMagicAttack.Visible = false;
                                    btnAttack.Visible = false;
                                    btnMagicHeal.Visible = false;
                                    ////removes monster
                                }
                            }
                            //label updates
                            UpdateEnemyStatLabels();
                            UpdateSelectedStatLabels();
                        }
                        else { MessageBox.Show("Not enough magic points!"); }
                    }
                    else
                    {
                        lblNarrator.Text = "No Bagmonster to fight with!";
                    }
                }
                else { lblNarrator.Text = "No monster to fight!"; }
                //label updates
                UpdateEnemyStatLabels();
                UpdateSelectedStatLabels();

            }
        }

        private void btnMagicBoost_Click(object sender, EventArgs e)//magic boost/ heal dual function
        {
            if (MainPlayer.NumActions == 0)
            {
                World.EndGame(ref MainPlayer, ref enemyMonster, listBox1);
                InitializeMyComponents();
            }
            else
            {
                if (MainPlayer.bagMonsters[listBox1.SelectedIndex].MagicPoints >= 10)
                {
                    //actions
                    MainPlayer.NumActions--;
                    UpdateActions();
                    if (MainPlayer.bagMonsters[listBox1.SelectedIndex] != null)
                    {
                        if (MainPlayer.bagMonsters[listBox1.SelectedIndex] is Slender || MainPlayer.bagMonsters[listBox1.SelectedIndex] is SlenderGirl)
                        {
                            MainPlayer.bagMonsters[listBox1.SelectedIndex].MagicBoost();//magic boost if slender type
                            lblNarrator.Text = "You have increased your magic points!";

                        }
                        else if (MainPlayer.bagMonsters[listBox1.SelectedIndex] is Boogey ||
                            MainPlayer.bagMonsters[listBox1.SelectedIndex] is BoogeyChild)
                        {
                            MainPlayer.bagMonsters[listBox1.SelectedIndex].Heal();//heal if slender type
                            lblNarrator.Text = "You have healed!";
                        }
                        World.EnemyTurn(MainPlayer.bagMonsters[listBox1.SelectedIndex], enemyMonster, lblNarrator);//enemy turn
                        if (MainPlayer.bagMonsters[listBox1.SelectedIndex].IsAlive == false)//checks for player monster death
                        {
                            lblNarrator.Text = MainPlayer.bagMonsters[listBox1.SelectedIndex].Name + " has died!";
                            World.RemoveMonster(ref MainPlayer, ref MainPlayer.bagMonsters[listBox1.SelectedIndex], ref listBox1);//removes monster
                            //hides buttons
                            btnRelease.Visible = false;
                            btnLevelUp.Visible = false;
                            btnMonsterRename.Visible = false;
                            btnMagicAttack.Visible = false;
                            btnAttack.Visible = false;
                            btnMagicHeal.Visible = false;
                            //
                        }

                    }
                    else { lblNarrator.Text = "No Bagmonster to play with!!!!!!!!"; }
                }
                else { MessageBox.Show("Not enough magic points!"); }
                //label updates
                UpdateEnemyStatLabels();
                UpdateSelectedStatLabels();
            }
        }

        private void txtBoxRename_TextChanged(object sender, EventArgs e)//when players type into textbox
        {
            if(txtBoxRename.Text != MainPlayer.bagMonsters[listBox1.SelectedIndex].Name)
            {
                btnMonsterRename.Text = "Confirm?";
            }
            
        }

        
    }
}
