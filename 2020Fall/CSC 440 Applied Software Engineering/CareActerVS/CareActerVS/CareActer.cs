using MySql.Data.MySqlClient;
using System;
using System.Collections; //ADD THIS TO USE AN ARRAY LIST
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CareActerVS
{
    public partial class CareActer : Form
    {
        // random for random uses
        Random rnd = new Random();
        Boolean statsAdd = false;
        //thomas added
        Item selectedItem = null;
        Skill selectedSkill = null;
        ArrayList itemList;
        ArrayList skillList;


        public CareActer()
        {
            InitializeComponent();
            // set locations of panels to be the same
            skillPanel.Location =  itemPanel.Location;
            statsPanel.Location = itemPanel.Location;
            diePanel.Location = itemPanel.Location;
            // fill the drop down with all available characters
            fillCharNames();
        }

        // thomas methods below
        public void updateItemList(String characterName)
        {
            //update item list
            itemSelect.Items.Clear();
            itemList = Item.getItemList(characterName);
            for (int i = 0; i < itemList.Count; i++)
            {
                Item currentItem = (Item)itemList[i];
                String iName = currentItem.getItemName();
                itemSelect.Items.Add(iName);
            }
        }

        public void updateSkillList(String characterName)
        {
            //update skill list
            skillSelect.Items.Clear();
            skillList = Skill.getSkillList(characterName);
            for (int i = 0; i < skillList.Count; i++)
            {
                Skill currentSkill = (Skill)skillList[i];
                String sName = currentSkill.getSkillName();
                skillSelect.Items.Add(sName);
            }
        }



        // john methods below
        private void fillCharNames()
        {            
            String[] charNames = Character.getCharNames();
            curCharDrop.Items.Clear();
            curCharDrop.Items.AddRange(charNames);
        }

        private void fillStatsInfo()
        {          

            //prepare an SQL query to retrieve all the events on the same, specified date
            DataTable myTable = new DataTable();
            DataTable myTable2 = new DataTable();
            string connStr = "server=157.89.28.130;user=ChangK;database=csc440;port=3306;password=Wallace#409;";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                string sql = "SELECT * FROM bms_character_main where `Character Name` = @name";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@name", curCharDrop.Text);
                MySqlDataAdapter myAdapter = new MySqlDataAdapter(cmd);
                myAdapter.Fill(myTable);
                Console.WriteLine("Table is ready.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            //get data from row and update the items in stats
            statsName.Text = myTable.Rows[0][0].ToString();
            statsRace.Text = myTable.Rows[0][1].ToString();
            statsClass.Text = myTable.Rows[0][2].ToString();
            statsLvl.Value = Int16.Parse(myTable.Rows[0][3].ToString());
            statsAlign.Text = myTable.Rows[0][4].ToString();
            statsBack.Text = myTable.Rows[0][5].ToString();


            try
            {
                Console.WriteLine("Connecting to MySQL For Attributes...");                
                string sql2 = "SELECT * FROM bms_attributes where `Character Name` = @name";
                MySqlCommand cmd2 = new MySqlCommand(sql2, conn);
                cmd2.Parameters.AddWithValue("@name", curCharDrop.Text);
                MySqlDataAdapter myAdapter = new MySqlDataAdapter(cmd2);
                myAdapter.Fill(myTable2);
                Console.WriteLine("Table is ready.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close();            
            statsSTR.Value = Int16.Parse(myTable2.Rows[0][1].ToString());
            statsDEX.Value = Int16.Parse(myTable2.Rows[0][2].ToString());
            statsCON.Value = Int16.Parse(myTable2.Rows[0][3].ToString());
            statsINT.Value = Int16.Parse(myTable2.Rows[0][4].ToString());
            statsWIS.Value = Int16.Parse(myTable2.Rows[0][5].ToString());
            statsCHA.Value = Int16.Parse(myTable2.Rows[0][6].ToString());
            statsAC.Value = Int16.Parse(myTable2.Rows[0][7].ToString());
            statsSpeed.Value = Int16.Parse(myTable2.Rows[0][8].ToString());
            statsHP.Value = Int16.Parse(myTable2.Rows[0][9].ToString());



        }
        

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        private void mainListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // set save buttons to invisible
            statsSave.Visible = false;
            itemSave.Visible = false;
            skillSave.Visible = false;
            statsPanel.Enabled = false;
            itemInfo.Enabled = false;
            skillInfo.Enabled = false;

            // set info invisible
            skillInfo.Visible = false;
            itemInfo.Visible = false;


            // clear selection boxes when main is changed
            skillSelect.SelectedItem = null;
            itemSelect.SelectedItem = null;

            // set adding character to false, since it would cancel the adding process
            statsAdd = false;

            if(curCharDrop.SelectedItem == null && (mainList.SelectedIndex != 3))
            {
                itemPanel.Visible = false;
                skillPanel.Visible = false;
                statsPanel.Visible = false;
                return;
            }

            // stats panel visible
            if (mainList.SelectedIndex == 0)
            {                
                // panels
                statsPanel.Visible = true;
                itemPanel.Visible = false;
                skillPanel.Visible = false;
                diePanel.Visible = false;

                //buttons
                editButton.Visible = true;
                deleteButton.Visible = true;
                addButton.Visible = true;

                //fill in info on current character
                fillStatsInfo();
            }

            // item panel visible 
            if (mainList.SelectedIndex == 1)
            {
                //update item list
                updateItemList(curCharDrop.Text);

                statsPanel.Visible = false;
                itemPanel.Visible = true;
                skillPanel.Visible = false;
                diePanel.Visible = false;

                //buttons
                editButton.Visible = false;
                deleteButton.Visible = false;
                addButton.Visible = true;

                //info panel                
                itemInfo.Visible = false;
            }

            // skill panel visible 
            if (mainList.SelectedIndex == 2)
            {
                //update skill list
                updateSkillList(curCharDrop.Text);

                statsPanel.Visible = false;
                itemPanel.Visible = false;
                skillPanel.Visible = true;
                diePanel.Visible = false;

                editButton.Visible = false;
                deleteButton.Visible = false;
                addButton.Visible = true;

                // info panel
                skillInfo.Visible = false;                
            }

            // die Roll visible
            if (mainList.SelectedIndex == 3) {
                statsPanel.Visible = false;
                itemPanel.Visible = false;
                skillPanel.Visible = false;
                diePanel.Visible = true;

                editButton.Visible = false;
                deleteButton.Visible = false;
                addButton.Visible = false;
            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void itemListBox_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (itemSelect.SelectedIndex == -1)
                itemSelect.SelectedIndex = 0;
            Item currentItem = (Item)itemList[itemSelect.SelectedIndex];

            selectedItem = currentItem;


            itemNameBox.Text = currentItem.getItemName();
            itemDescBox.Text = currentItem.getItemDesc();

            itemInfo.Visible = true;
            editButton.Visible = true;
            deleteButton.Visible = true;
            addButton.Visible = false;
            itemInfo.Enabled = false;
        }

        private void skillSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (skillSelect.SelectedIndex == -1)
                skillSelect.SelectedIndex = 0;
            Skill currentSkill = (Skill)skillList[skillSelect.SelectedIndex];

            selectedSkill = currentSkill;
            skillNameBox.Text = currentSkill.getSkillName();
            skillDescBox.Text = currentSkill.getSkillDesc();

            skillInfo.Visible = true;
            editButton.Visible = true;
            deleteButton.Visible = true;
            addButton.Visible = false;
            skillInfo.Enabled = false;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void skillInfo_Enter(object sender, EventArgs e)
        {

        }

        private void dieRoll_Click(object sender, EventArgs e)
        {
            int sum = 0;
            for (int i = 1; i <= (int)dieAmount.Value; i++)
            {
                sum += rnd.Next(1, (int)dieSides.Value + 1);                
            }
            dieTotal.Text = "" + sum;
        }

        private void curCharDrop_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //TO DO: need to refresh the selected main list of items
                if (mainList.SelectedIndex == 0)
                {
                    fillStatsInfo();
                }
                if (mainList.SelectedIndex == 1)
                {
                    updateItemList(curCharDrop.Text);
                }
                if (mainList.SelectedIndex == 2)
                {
                    updateSkillList(curCharDrop.Text);
                }
                mainListBox_SelectedIndexChanged(sender, e);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            


        }

        private void editButton_Click(object sender, EventArgs e)
        {
            // set add character to false
            statsAdd = false;
            // edit a character
            if(mainList.SelectedIndex == 0)
            {
                string oldName = statsName.Text;
                // set visibile save button
                statsSave.Visible = true;
                // enable editing
                statsPanel.Enabled = true;
                AttributesGroup.Enabled = true;
                foreach (Control c in statsPanel.Controls)
                    c.Enabled = true;
                foreach (Control c in AttributesGroup.Controls)
                    c.Enabled = true;
            }

            // edit an item
            if (mainList.SelectedIndex == 1)
            {                
                // set visibile save button
                itemSave.Visible = true;
                // enable editing
                // enable editing
                foreach (Control c in itemPanel.Controls)
                    c.Enabled = true;
                foreach (Control c in itemInfo.Controls)
                    c.Enabled = true;
            }


            // edit a skill
            if (mainList.SelectedIndex == 2)
            {                
                // set visibile save button
                skillSave.Visible = true;
                // enable editing                
                foreach (Control c in skillPanel.Controls)
                    c.Enabled = true;
                foreach (Control c in skillInfo.Controls)
                    c.Enabled = true;
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            
            // delete character
            if (mainList.SelectedIndex == 0) 
            {
                Debug.WriteLine("Deleting Character");
                Character.delCharacter(curCharDrop.Text);
                fillCharNames();
                statsPanel.Visible = false;
            }
            // delete item
            if (mainList.SelectedIndex == 1)
            {
                Debug.WriteLine("Deleting Item");
                Item.deleteItem(itemNameBox.Text.ToString());
                updateItemList(curCharDrop.Text);
                itemInfo.Visible = false;
            }
            // delete skill
            if (mainList.SelectedIndex == 2)
            {
                Debug.WriteLine("Deleting Skill");
                Skill.deleteSkill(skillNameBox.Text.ToString());
                updateSkillList(curCharDrop.Text);
                skillInfo.Visible = false;
            }
        }

        private void statsSave_Click(object sender, EventArgs e)
        {
            // adding a character 
            if (statsAdd)
            {
                Debug.WriteLine("Adding Character");

                if (!curCharDrop.Items.Contains(statsName.Text))
                {
                    Debug.WriteLine("Saving Added Character");

                    // REPLACED ********************************************************************************                    
                    Character newChar = new Character(statsName.Text, statsRace.Text, statsClass.Text, Decimal.ToInt32(statsLvl.Value), statsAlign.Text, statsBack.Text, Decimal.ToInt32(statsSTR.Value), Decimal.ToInt32(statsDEX.Value), Decimal.ToInt32(statsCON.Value), Decimal.ToInt32(statsINT.Value), Decimal.ToInt32(statsWIS.Value), Decimal.ToInt32(statsCHA.Value), Decimal.ToInt32(statsAC.Value), Decimal.ToInt32(statsSpeed.Value), Decimal.ToInt32(statsHP.Value));
                    newChar.addCharacter();
                    fillCharNames();

                    // show confirmation
                    MessageBoxButtons buttons;
                    string caption = "Save Successful!";
                    string message = "Your character has been saved successfully!";
                    buttons = MessageBoxButtons.OK;
                    MessageBox.Show(message, caption, buttons);

                    // disable panel
                    statsPanel.Enabled = false;
                    statsSave.Visible = false;

                }
                else
                {
                    Debug.WriteLine("Failed Added Character");

                    MessageBoxButtons buttons;
                    string caption = "FAILED!";
                    string message = "That character name is already in use, change the name to save properly";
                    buttons = MessageBoxButtons.OK;
                    MessageBox.Show(message, caption, buttons);
                }
            }

            // character saving with an edit, we don't need a check to include the old name
            else
            {
                Debug.WriteLine("Editing Character");
                Debug.WriteLine(statsName.Text == curCharDrop.SelectedItem.ToString());
                if ((!curCharDrop.Items.Contains(statsName.Text)) | (statsName.Text == curCharDrop.SelectedItem.ToString())) // is not in list, or is the name it was before
                {
                    Debug.WriteLine("Saving Edited Character");

                    // Replaced ********************************************************************************                    
                    Character newChar = new Character(statsName.Text, statsRace.Text, statsClass.Text, Decimal.ToInt32(statsLvl.Value), statsAlign.Text, statsBack.Text, Decimal.ToInt32(statsSTR.Value), Decimal.ToInt32(statsDEX.Value), Decimal.ToInt32(statsCON.Value), Decimal.ToInt32(statsINT.Value), Decimal.ToInt32(statsWIS.Value), Decimal.ToInt32(statsCHA.Value), Decimal.ToInt32(statsAC.Value), Decimal.ToInt32(statsSpeed.Value), Decimal.ToInt32(statsHP.Value));
                    newChar.editCharacter(curCharDrop.Text);
                    fillCharNames();

                    // display confirm
                    MessageBoxButtons buttons;
                    string caption = "Save Successful!";
                    string message = "Your character has been saved successfully!";
                    buttons = MessageBoxButtons.OK;
                    MessageBox.Show(message, caption, buttons);

                    // disable panel
                    statsPanel.Enabled = false;
                    statsSave.Visible = false;
                }
                else
                {
                    Debug.WriteLine("Failed Edited Character");
                    MessageBoxButtons buttons;
                    string caption = "FAILED!";
                    string message = "That characcter name is already in use, change the name to save properly";
                    buttons = MessageBoxButtons.OK;
                    MessageBox.Show(message, caption, buttons);
                }
            }
        }

        private void itemSave_Click(object sender, EventArgs e)
        {


            //get the item and character informatin
            String itemName = itemNameBox.Text.ToString();
            String itemDescription = itemDescBox.Text.ToString();

            MessageBoxButtons buttons;
            string caption;
            string message;
            //if no character selected return error
            String characterName = curCharDrop.GetItemText(curCharDrop.SelectedItem);
            if (characterName == "")
            {
                caption = "Save Unsuccessful!";
                message = "Your entry has NOT been saved successfully!";
                buttons = MessageBoxButtons.OK;
                MessageBox.Show(message, caption, buttons);
                return;
            }

            // saving a new item with add
            if (itemSelect.SelectedIndex == -1)
            {
                Debug.WriteLine("Adding an Item");

                if (!itemSelect.Items.Contains(itemNameBox.Text))
                {
                    Debug.WriteLine("Saving Added Item");

                    //add the new item to the database

                    //save item 
                    Item.saveItem(itemName, itemDescription, characterName);

                    //update item list
                    updateItemList(characterName);

                    // show confirmation
                    caption = "Save Successful!";
                    message = "Your entry has been saved successfully!";
                    buttons = MessageBoxButtons.OK;
                    MessageBox.Show(message, caption, buttons);

                    // disable panel
                    itemInfo.Enabled = false;
                    itemSave.Visible = false;
                }
                else
                {
                    Debug.WriteLine("Failed adding Item");
                    caption = "FAILED!";
                    message = "That item name is already in use, change the name to save properly";
                    buttons = MessageBoxButtons.OK;
                    MessageBox.Show(message, caption, buttons);
                }
            }

            // saving with an edit, we don't need a check to include the old name
            else
            {
                Debug.WriteLine("Editing an Item");
                if ((!itemSelect.Items.Contains(itemNameBox.Text)) | (itemNameBox.Text == itemSelect.SelectedItem.ToString())) // is not in list, or is the name it was before
                {
                    Debug.WriteLine("Saving edited  Item");
                    //edit item by deleting and resaving
                    Item.editItem(itemName, itemDescription, selectedItem.getItemName());

                    //update item list
                    updateItemList(characterName);


                    // display confirm
                    caption = "Edit Successful!";
                    message = "Your entry has been edited successfully!";
                    buttons = MessageBoxButtons.OK;
                    MessageBox.Show(message, caption, buttons);

                    // disable panel
                    itemInfo.Enabled = false;
                    itemSave.Visible = false;
                }
                else
                {
                    Debug.WriteLine("Failed Editing an Item");
                    caption = "FAILED!";
                    message = "That name is already in use, change the name to save properly";
                    buttons = MessageBoxButtons.OK;
                    MessageBox.Show(message, caption, buttons);
                }
            }
        }

        private void skillSave_Click(object sender, EventArgs e)
        {
            //get the skill and character informatin
            String skillName = skillNameBox.Text.ToString();
            String skillDescription = skillDescBox.Text.ToString();

            MessageBoxButtons buttons;
            string caption;
            string message;

            //if no character selected return error
            String characterName = curCharDrop.GetItemText(curCharDrop.SelectedItem);
            if (characterName == "")
            {
                caption = "Save Unsuccessful!";
                message = "Your entry has NOT been saved successfully!";
                buttons = MessageBoxButtons.OK;
                MessageBox.Show(message, caption, buttons);
                return;
            }
            if (skillSelect.SelectedIndex == -1)
            {
                if (!skillSelect.Items.Contains(skillNameBox.Text))
                {
                    //add the new skill to the database

                    //save skill 
                    Skill.saveSkill(skillName, skillDescription, characterName);

                    //update skill list
                    updateSkillList(characterName);


                    // show confirmation
                    caption = "Save Successful!";
                    message = "Your entry has been saved successfully!";
                    buttons = MessageBoxButtons.OK;
                    MessageBox.Show(message, caption, buttons);

                    // disable panel
                    skillInfo.Enabled = false;
                    skillSave.Visible = false;



                }
                else
                {
                    caption = "FAILED!";
                    message = "That skill name is already in use, change the name to save properly";
                    buttons = MessageBoxButtons.OK;
                    MessageBox.Show(message, caption, buttons);
                }
            }

            // saving with an edit, we don't need a check to include the old name
            else
            {
                if ((!skillSelect.Items.Contains(skillNameBox.Text)) | (skillNameBox.Text == skillSelect.SelectedItem.ToString())) // is not in list, or is the name it was before
                {
                    // REMOVE AND REPLACE WITH DATABASE AND REFRESH********************************************************************************
                    Skill.editSkills(skillName, skillDescription, selectedSkill.getSkillName());

                    //update the skill list
                    updateSkillList(characterName);


                    // display confirm
                    caption = "Save Successful!";
                    message = "Your entry has been saved successfully!";
                    buttons = MessageBoxButtons.OK;
                    MessageBox.Show(message, caption, buttons);

                    // disable panel
                    skillInfo.Enabled = false;
                    skillSave.Visible = false;
                }
                else
                {
                    caption = "FAILED!";
                    message = "That name is already in use, change the name to save properly";
                    buttons = MessageBoxButtons.OK;
                    MessageBox.Show(message, caption, buttons);
                }
            }




        }

        private void addButton_Click(object sender, EventArgs e)
        {   

            // add a character
            if (mainList.SelectedIndex == 0)
            {
                statsPanel.Visible = true;
                statsAdd = true;
                // set visibile save button
                statsSave.Visible = true;
                // enable editing
                statsPanel.Enabled = true;
                AttributesGroup.Enabled = true;
                foreach (Control c in statsPanel.Controls)
                    c.Enabled = true;
                foreach (Control c in AttributesGroup.Controls)
                    c.Enabled = true;
                statsAC.Enabled = true;                
            }

            // add an item
            if (mainList.SelectedIndex == 1)
            {
                // set visibiles
                itemInfo.Visible = true;
                itemSave.Visible = true;
                // enable editing
                // enable editing
                foreach (Control c in itemPanel.Controls)
                    c.Enabled = true;
                foreach (Control c in itemInfo.Controls)
                    c.Enabled = true;            

            }


            // add a skill
            if (mainList.SelectedIndex == 2)
            {
                skillInfo.Visible = true;
                // set visibile save button
                skillSave.Visible = true;
                // enable editing                
                foreach (Control c in skillPanel.Controls)
                    c.Enabled = true;
                foreach (Control c in skillInfo.Controls)
                    c.Enabled = true;
            }
        }

        private void itemDescBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
