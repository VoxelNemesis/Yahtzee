using System.Diagnostics.Metrics;

using static System.Formats.Asn1.AsnWriter;

namespace Yahtzee
{
    public partial class Yahtzee : Form
    {
        public Yahtzee()
        {
            InitializeComponent();
            CKB_DiceKeeper1.Visible = false;
            CKB_DiceKeeper2.Visible = false;
            CKB_DiceKeeper3.Visible = false;
            CKB_DiceKeeper4.Visible = false;
            CKB_DiceKeeper5.Visible = false;
        }

        #region Globus variables

        private static Random RNG = new Random();
        private static int[] StoreTMB = new int[5];

        private static bool DiceKeep1 = false;
        private static bool DiceKeep2 = false;
        private static bool DiceKeep3 = false;
        private static bool DiceKeep4 = false;
        private static bool DiceKeep5 = false;

        private static int Kept1 = 0;
        private static int Kept2 = 0;
        private static int Kept3 = 0;
        private static int Kept4 = 0;
        private static int Kept5 = 0;

        private static bool OnesButtonPressed = false;
        private static bool TwosButtonPressed = false;
        private static bool ThreesButtonPressed = false;
        private static bool FoursButtonPressed = false;
        private static bool FivesButtonPressed = false;
        private static bool SixesButtonPressed = false;
        private static bool ToakButtonPressed = false;
        private static bool FoakButtonPressed = false;
        private static bool FHouseButtonPressed = false;
        private static bool SStraightButtonPressed = false;
        private static bool LStraightButtonPressed = false;
        private static bool yahtzeeButtonPressed = false;
        private static bool ChanceButtonPressed = false;

        private static bool Ones = false;
        private static bool Twos = false;
        private static bool Threes = false;
        private static bool Fours = false;
        private static bool Fives = false;
        private static bool Sixes = false;
        private static bool Bonus = false;
        private static bool ThreeOfAKind = false;
        private static bool FourOfAKind = false;
        private static bool FullHouse = false;
        private static bool SmallStraight = false;
        private static bool LargeStraight = false;
        private static bool Chance = false;
        private static bool YahtzeePont = false;

        #endregion Globus variables

        private void Yahtzee_Load(object sender, EventArgs e)
        {
        }

        // Dice Roller
        private static int RollsRemaining = 2;

        private static int SumForElse(int a)
        {
            a = 0;
            foreach (var i in StoreTMB)
            {
                a += i;
            }
            return a;
        }

        private static int SumForNum(int keresett)
        {
            int a = 0;
            for (int i = 0; i < StoreTMB.Length; i++)
            {
                if (StoreTMB[i] == keresett)
                {
                    a += StoreTMB[i];
                }
            }
            return a;
        }

        private void Checker()
        {
            //Array.Sort(StoreTMB, (x, y) => x.CompareTo(y));
            //egyesek

            foreach (int i in StoreTMB)
            {
                if (i == 1) Ones = true;
            }
            if (OnesButtonPressed == false && SumForNum(1) != 0) RTB_Ones.Text = SumForNum(1).ToString();
            //Kettes Ellenõrzés

            foreach (int i in StoreTMB)
            {
                if (i == 2) Twos = true;
            }
            if (TwosButtonPressed == false && SumForNum(2) != 0) RTB_Twos.Text = SumForNum(2).ToString();
            //hármasok

            foreach (int i in StoreTMB)
            {
                if (i == 3) Threes = true;
            }
            // SumForNum(harmasSum, keresett3);
            if (ThreesButtonPressed == false && SumForNum(3) != 0) RTB_Threes.Text = SumForNum(3).ToString();
            // négyesek

            foreach (int i in StoreTMB)
            {
                if (i == 4) Fours = true;
            }
            //SumForNum(negyesSum, keresett4);
            if (FoursButtonPressed == false && SumForNum(4) != 0) RTB_Fours.Text = SumForNum(4).ToString();
            // ötösök

            foreach (int i in StoreTMB)
            {
                if (i == 5) Fives = true;
            }
            //SumForNum(otosSum, keresett5);
            if (FivesButtonPressed == false && SumForNum(5) != 0) RTB_Fives.Text = SumForNum(5).ToString();
            // hatosok

            foreach (int i in StoreTMB)
            {
                if (i == 6) Sixes = true;
            }
            if (SixesButtonPressed == false && SumForNum(6) != 0) RTB_Sixes.Text = SumForNum(6).ToString();
            //Three of a kind
            int score = 0;
            bool hasthree = false;
            int[] Counts = new int[6];

            for (int i = 0; i < StoreTMB.Length; i++)
            {
                if (StoreTMB[i] != 0)
                {
                    Counts[StoreTMB[i] - 1]++;
                    score += StoreTMB[i]; //add all dice for score
                }
            }
            foreach (int i in Counts)
            {
                if (i >= 3)
                {
                    hasthree = true;
                    break;
                }
            }
            if (!hasthree)
            {
                score = 0; //set score back to zero if array doesn't have 3
            }
            if (ToakButtonPressed == false && hasthree == true) RTB_Toak.Text = score.ToString();

            //Four of a kind
            int Foakscore = 0;
            bool hasFour = false;
            int[] CountsFoak = new int[6];

            for (int i = 0; i < StoreTMB.Length; i++)
            {
                if (StoreTMB[i] != 0)
                {
                    CountsFoak[StoreTMB[i] - 1]++;
                    Foakscore += StoreTMB[i]; //add to all dice for score
                }
            }
            //loop checks to see if any of the values in counts are 4 or greater. If so, sets hasFour to true
            foreach (int i in CountsFoak)
            {
                if (i >= 4)
                {
                    hasFour = true;
                    break;
                }
            }
            if (!hasFour)
            {
                Foakscore = 0; //set total back to zero if array doesn't have 4
            }
            if (FoakButtonPressed == false && hasFour == true) RTB_Foak.Text = Foakscore.ToString();
            // Full house

            int FHousescore = 0;
            bool hasTwo = false;
            bool hasThree = false;
            int[] counts = new int[6];

            for (int i = 0; i < StoreTMB.Length; i++)
            {
                if (StoreTMB[i] != 0)
                {
                    counts[StoreTMB[i] - 1]++;
                }
            }

            //loop checks to see if any of the values in counts are 2 or 3.
            //If so, sets hasTwo or hasThree to true.
            foreach (int i in counts)
            {
                if (i == 3)
                {
                    hasThree = true;
                }
                if (i == 2)
                {
                    hasTwo = true;
                }
            }

            if (hasTwo && hasThree)
            {
                FHousescore = 25; //if hand has set of 2 and 3 score = 25
            }
            if (FHouseButtonPressed == false && hasThree == true && hasTwo == true) RTB_FHouse.Text = FHousescore.ToString();

            //Small Straight
            int STRAscore = 0;
            int run = 1;
            for (int i = 0; i < StoreTMB.Length - 1; i++)
            {
                if (StoreTMB[i + 1] == StoreTMB[i] + 1)
                {
                    run++;
                }
            }
            if (run >= 4)
            {
                STRAscore = 30;
            }
            if (SStraightButtonPressed == false && STRAscore != 0) RTB_SStraight.Text = STRAscore.ToString();
            //Large straight
            int LARscore = 0;
            run = 1;
            for (int i = 0; i < StoreTMB.Length - 1; i++)
            {
                if (StoreTMB[i + 1] == StoreTMB[i] + 1)
                {
                    run++;
                }
            }
            if (run == 5)
            {
                LARscore = 40;
            }
            if (LStraightButtonPressed == false && LARscore != 0) RTB_LStraight.Text = LARscore.ToString();
            // YAHTZEE
            //counts is an array for each value on a die. A loop goes through the dice
            //and increases that index in the array.
            int YAHTscore = 0;
            int[] CountsYahtzee = new int[6];
            for (int i = 0; i < StoreTMB.Length; i++)
            {
                if (StoreTMB[i] != 0)
                {
                    CountsYahtzee[StoreTMB[i] - 1]++;
                }
            }

            //loop checks to see if any of the values in counts are 5. If so, sets score to 50
            foreach (int i in CountsYahtzee)
            {
                if (i == 5)
                {
                    YAHTscore = 50;
                    break;
                }
            }
            if (yahtzeeButtonPressed == false && YAHTscore != 0) RTB_Yahtzee.Text = YAHTscore.ToString();
            //Chance
            int CHAscore = 0;
            foreach (int i in StoreTMB)
            {
                CHAscore += i;
            }
            if (ChanceButtonPressed == false) RTB_Chance.Text = CHAscore.ToString();

            //Sum for 1st section
            if (RTB_Ones.TextLength != 0 && RTB_Twos.TextLength != 0 && RTB_Threes.TextLength != 0 && RTB_Fours.TextLength != 0 && RTB_Fives.TextLength != 0 && RTB_Sixes.TextLength != 0)
            {
                int adder = int.Parse(RTB_Ones.Text.ToString()) + int.Parse(RTB_Twos.Text.ToString()) + int.Parse(RTB_Threes.Text.ToString()) + int.Parse(RTB_Fours.Text.ToString()) + int.Parse(RTB_Fives.Text.ToString()) + int.Parse(RTB_Sixes.Text.ToString());
                RTB_Sum.Text = adder.ToString();
                if (adder >= 63) RTB_Bonus.Text = 35.ToString();
            }
            //Sum for 2nd section
            if (RTB_Toak.TextLength != 0 && RTB_Foak.TextLength != 0 && RTB_FHouse.TextLength != 0 && RTB_SStraight.TextLength != 0 && RTB_LStraight.TextLength != 0 && RTB_Chance.TextLength != 0 && RTB_Yahtzee.TextLength != 0)
            {
                int adder = int.Parse(RTB_Toak.Text.ToString()) + int.Parse(RTB_Foak.Text.ToString()) + int.Parse(RTB_FHouse.Text.ToString()) + int.Parse(RTB_SStraight.Text.ToString()) + int.Parse(RTB_LStraight.Text.ToString()) + int.Parse(RTB_Chance.Text.ToString()) + int.Parse(RTB_Yahtzee.Text.ToString());
                RTB_SSum.Text = adder.ToString();
            }
        }

        private void BTN_Roll_Click(object sender, EventArgs e)
        {
            #region Textbox Clearer

            if (OnesButtonPressed == false) RTB_Ones.Text = null;
            if (TwosButtonPressed == false) RTB_Twos.Text = null;
            if (ThreesButtonPressed == false) RTB_Threes.Text = null;
            if (FoursButtonPressed == false) RTB_Fours.Text = null;
            if (FivesButtonPressed == false) RTB_Fives.Text = null;
            if (SixesButtonPressed == false) RTB_Sixes.Text = null;
            if (ToakButtonPressed == false) RTB_Toak.Text = null;
            if (FoakButtonPressed == false) RTB_Foak.Text = null;
            if (FHouseButtonPressed == false) RTB_FHouse.Text = null;
            if (SStraightButtonPressed == false) RTB_SStraight.Text = null;
            if (LStraightButtonPressed == false) RTB_LStraight.Text = null;
            if (yahtzeeButtonPressed == false) RTB_Yahtzee.Text = null;
            if (ChanceButtonPressed == false) RTB_Yahtzee.Text = null;

            #endregion Textbox Clearer

            // Checks if out of rolls
            if (RollsRemaining == 0)
            {
                BTN_Roll.Enabled = false;
                BTN_Roll.Text = "Out Of Rolls";
            }
            Kept1 = StoreTMB[0];
            Kept2 = StoreTMB[1];
            Kept3 = StoreTMB[2];
            Kept4 = StoreTMB[3];
            Kept5 = StoreTMB[4];
            for (int i = 0; i < StoreTMB.Length; i++)
            {
                StoreTMB[i] = RNG.Next(1, 7);
            }
            CKB_DiceKeeper1.Visible = true;
            CKB_DiceKeeper2.Visible = true;
            CKB_DiceKeeper3.Visible = true;
            CKB_DiceKeeper4.Visible = true;
            CKB_DiceKeeper5.Visible = true;

            #region DICE

            //Dice 1 Faces

            if (DiceKeep1 == false)
            {
                if (StoreTMB[0] == 1)
                {
                    PCB_Dice1.Image = Image.FromFile($@"..\..\..\RES\Dice1.png");
                    PCB_Dice1.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                if (StoreTMB[0] == 2)
                {
                    PCB_Dice1.Image = Image.FromFile(@"..\..\..\RES\Dice2.png");
                    PCB_Dice1.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                if (StoreTMB[0] == 3)
                {
                    PCB_Dice1.Image = Image.FromFile(@"..\..\..\RES\Dice3.png");
                    PCB_Dice1.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                if (StoreTMB[0] == 4)
                {
                    PCB_Dice1.Image = Image.FromFile(@"..\..\..\RES\Dice4.png");
                    PCB_Dice1.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                if (StoreTMB[0] == 5)
                {
                    PCB_Dice1.Image = Image.FromFile(@"..\..\..\RES\Dice5.png");
                    PCB_Dice1.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                if (StoreTMB[0] == 6)
                {
                    PCB_Dice1.Image = Image.FromFile(@"..\..\..\RES\Dice6.png");
                    PCB_Dice1.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }

            //Dice 2 Faces
            if (DiceKeep2 == false)
            {
                if (StoreTMB[1] == 1)
                {
                    PCB_Dice2.Image = Image.FromFile($@"..\..\..\RES\Dice1.png");
                    PCB_Dice2.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                if (StoreTMB[1] == 2)
                {
                    PCB_Dice2.Image = Image.FromFile(@"..\..\..\RES\Dice2.png");
                    PCB_Dice2.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                if (StoreTMB[1] == 3)
                {
                    PCB_Dice2.Image = Image.FromFile(@"..\..\..\RES\Dice3.png");
                    PCB_Dice2.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                if (StoreTMB[1] == 4)
                {
                    PCB_Dice2.Image = Image.FromFile(@"..\..\..\RES\Dice4.png");
                    PCB_Dice2.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                if (StoreTMB[1] == 5)
                {
                    PCB_Dice2.Image = Image.FromFile(@"..\..\..\RES\Dice5.png");
                    PCB_Dice2.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                if (StoreTMB[1] == 6)
                {
                    PCB_Dice2.Image = Image.FromFile(@"..\..\..\RES\Dice6.png");
                    PCB_Dice2.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }

            //Dice 3 Faces
            if (DiceKeep3 == false)
            {
                if (StoreTMB[2] == 1)
                {
                    PCB_Dice3.Image = Image.FromFile($@"..\..\..\RES\Dice1.png");
                    PCB_Dice3.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                if (StoreTMB[2] == 2)
                {
                    PCB_Dice3.Image = Image.FromFile(@"..\..\..\RES\Dice2.png");
                    PCB_Dice3.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                if (StoreTMB[2] == 3)
                {
                    PCB_Dice3.Image = Image.FromFile(@"..\..\..\RES\Dice3.png");
                    PCB_Dice3.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                if (StoreTMB[2] == 4)
                {
                    PCB_Dice3.Image = Image.FromFile(@"..\..\..\RES\Dice4.png");
                    PCB_Dice3.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                if (StoreTMB[2] == 5)
                {
                    PCB_Dice3.Image = Image.FromFile(@"..\..\..\RES\Dice5.png");
                    PCB_Dice3.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                if (StoreTMB[2] == 6)
                {
                    PCB_Dice3.Image = Image.FromFile(@"..\..\..\RES\Dice6.png");
                    PCB_Dice3.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }

            //Dice 4 Faces
            if (DiceKeep4 == false)
            {
                if (StoreTMB[3] == 1)
                {
                    PCB_Dice4.Image = Image.FromFile($@"..\..\..\RES\Dice1.png");
                    PCB_Dice4.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                if (StoreTMB[3] == 2)
                {
                    PCB_Dice4.Image = Image.FromFile(@"..\..\..\RES\Dice2.png");
                    PCB_Dice4.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                if (StoreTMB[3] == 3)
                {
                    PCB_Dice4.Image = Image.FromFile(@"..\..\..\RES\Dice3.png");
                    PCB_Dice4.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                if (StoreTMB[3] == 4)
                {
                    PCB_Dice4.Image = Image.FromFile(@"..\..\..\RES\Dice4.png");
                    PCB_Dice4.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                if (StoreTMB[3] == 5)
                {
                    PCB_Dice4.Image = Image.FromFile(@"..\..\..\RES\Dice5.png");
                    PCB_Dice4.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                if (StoreTMB[3] == 6)
                {
                    PCB_Dice4.Image = Image.FromFile(@"..\..\..\RES\Dice6.png");
                    PCB_Dice4.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }

            //Dice 5 Faces
            if (DiceKeep5 == false)
            {
                if (StoreTMB[4] == 1)
                {
                    PCB_Dice5.Image = Image.FromFile($@"..\..\..\RES\Dice1.png");
                    PCB_Dice5.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                if (StoreTMB[4] == 2)
                {
                    PCB_Dice5.Image = Image.FromFile(@"..\..\..\RES\Dice2.png");
                    PCB_Dice5.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                if (StoreTMB[4] == 3)
                {
                    PCB_Dice5.Image = Image.FromFile(@"..\..\..\RES\Dice3.png");
                    PCB_Dice5.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                if (StoreTMB[4] == 4)
                {
                    PCB_Dice5.Image = Image.FromFile(@"..\..\..\RES\Dice4.png");
                    PCB_Dice5.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                if (StoreTMB[4] == 5)
                {
                    PCB_Dice5.Image = Image.FromFile(@"..\..\..\RES\Dice5.png");
                    PCB_Dice5.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                if (StoreTMB[4] == 6)
                {
                    PCB_Dice5.Image = Image.FromFile(@"..\..\..\RES\Dice6.png");
                    PCB_Dice5.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }

            #endregion DICE

            if (CKB_DiceKeeper1.Checked == true)
            {
                StoreTMB[0] = Kept1;
            }
            if (CKB_DiceKeeper2.Checked == true)
            {
                StoreTMB[1] = Kept2;
            }
            if (CKB_DiceKeeper3.Checked == true)
            {
                StoreTMB[2] = Kept3;
            }
            if (CKB_DiceKeeper4.Checked == true)
            {
                StoreTMB[3] = Kept4;
            }
            if (CKB_DiceKeeper5.Checked == true)
            {
                StoreTMB[4] = Kept5;
            }

            Checker();

            RollsRemaining--;
        }

        //Dice 1 Keeper
        private void CKB_DiceKeeper1_CheckedChanged(object sender, EventArgs e)
        {
            DiceKeep1 = true;
            if (CKB_DiceKeeper1.Checked == false)
                DiceKeep1 = false;
        }

        //Dice 2 Keeper
        private void CKB_DiceKeeper2_CheckedChanged(object sender, EventArgs e)
        {
            DiceKeep2 = true;
            if (CKB_DiceKeeper2.Checked == false)
                DiceKeep2 = false;
        }

        //Dice 3 Keeper
        private void CKB_DiceKeeper3_CheckedChanged(object sender, EventArgs e)
        {
            DiceKeep3 = true;
            if (CKB_DiceKeeper3.Checked == false)
                DiceKeep3 = false;
        }

        //Dice 4 Keeper
        private void CKB_DiceKeeper4_CheckedChanged(object sender, EventArgs e)
        {
            DiceKeep4 = true;
            if (CKB_DiceKeeper4.Checked == false)
                DiceKeep4 = false;
        }

        //Dice 5 Keeper
        private void CKB_DiceKeeper5_CheckedChanged(object sender, EventArgs e)
        {
            DiceKeep5 = true;
            if (CKB_DiceKeeper5.Checked == false)
                DiceKeep5 = false;
        }

        private void RollReseter()
        {
            RollsRemaining = 2;
            BTN_Roll.Text = "Roll";
            BTN_Roll.Enabled = true;
            PCB_Dice1.Image = null;
            PCB_Dice2.Image = null;
            PCB_Dice3.Image = null;
            PCB_Dice4.Image = null;
            PCB_Dice5.Image = null;
            CKB_DiceKeeper1.Checked = false;
            CKB_DiceKeeper2.Checked = false;
            CKB_DiceKeeper3.Checked = false;
            CKB_DiceKeeper4.Checked = false;
            CKB_DiceKeeper5.Checked = false;
        }

        private void BTN_Ones_Click(object sender, EventArgs e)
        {
            RollReseter();
            OnesButtonPressed = true;
            BTN_Ones.Enabled = false;
        }

        private void BTN_Twos_Click(object sender, EventArgs e)
        {
            RollReseter();
            TwosButtonPressed = true;
            BTN_Twos.Enabled = false;
        }

        private void BTN_Threes_Click(object sender, EventArgs e)
        {
            RollReseter();
            ThreesButtonPressed = true;
            BTN_Threes.Enabled = false;
        }

        private void BTN_Fours_Click(object sender, EventArgs e)
        {
            RollReseter();
            FoursButtonPressed = true;
            BTN_Fours.Enabled = false;
        }

        private void BTN_Fives_Click(object sender, EventArgs e)
        {
            RollReseter();
            FivesButtonPressed = true;
            BTN_Fives.Enabled = false;
        }

        private void BTN_Sixes_Click(object sender, EventArgs e)
        {
            RollReseter();
            SixesButtonPressed = true;
            BTN_Sixes.Enabled = false;
        }

        private void BTN_Toak_Click(object sender, EventArgs e)
        {
            RollReseter();
            ToakButtonPressed = true;
            BTN_Toak.Enabled = false;
        }

        private void BTN_Foak_Click(object sender, EventArgs e)
        {
            RollReseter();
            FoakButtonPressed = true;
            BTN_Foak.Enabled = false;
        }

        private void BTN_FHouse_Click(object sender, EventArgs e)
        {
            RollReseter();
            FHouseButtonPressed = true;
            BTN_FHouse.Enabled = false;
        }

        private void BTN_SStraight_Click(object sender, EventArgs e)
        {
            RollReseter();
            SStraightButtonPressed = true;
            BTN_SStraight.Enabled = false;
        }

        private void BTN_LStraight_Click(object sender, EventArgs e)
        {
            RollReseter();
            LStraightButtonPressed = true;
            BTN_LStraight.Enabled = false;
        }

        private void BTN_Yaht_Click(object sender, EventArgs e)
        {
            RollReseter();
            yahtzeeButtonPressed = true;
            BTN_Yaht.Enabled = false;
        }

        private void BTN_Chance_Click(object sender, EventArgs e)
        {
            RollReseter();
            ChanceButtonPressed = true;
            BTN_Chance.Enabled = false;
        }
    }
}