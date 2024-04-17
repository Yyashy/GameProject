//Group 2 (Yash,Sumit Jain, Syed)
//Yash(100892788)
//Sumit Jain(100890788)
//Syed (100677016)

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace durak
{
    public partial class ruleForm : Form
    {
        public ruleForm()
        {
            InitializeComponent();
        }

        private void ruleForm_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            // Rules rich text box
           
            rulesRichTextBox.Text = "History of Durak:\n\n" +
                "Durak, which means \"fool\" in Russian, is a popular card game that originated in Russia during the 19th century. " +
                "The game gained popularity across Eastern Europe and eventually spread to other parts of the world.\n\n" +
                "Originally, Durak was a game played by peasants during their leisure time. " +
                "Its simple rules and the need for only a standard deck of cards made it accessible to a wide range of players.\n\n" +
                "The game's name, \"Durak,\" reflects its objective – to avoid being the last player left holding cards, as the last remaining player is often regarded as the \"fool.\"\n\n" +
                "Basic Rules of Durak:\n\n" +
                "1. Durak is typically played with a deck of 36 cards (from 6 to Ace).\n\n" +
                "2. The game can be played with 2 to 6 players.\n\n" +
                "3. At the start of the game, each player is dealt 6 cards.\n\n" +
                "4. The remaining cards are placed face down on the table as the draw pile, with the top card turned face up next to it, forming the discard pile.\n\n" +
                "5. The player to the dealer's left goes first and becomes the attacker.\n\n" +
                "6. The attacker plays a card face up in the center of the table.\n\n" +
                "7. The defender (the player to the attacker's left) must play a higher card of the same suit or any card from the trump suit to beat the attacker's card. If the defender cannot or does not wish to beat the card, they must pick up the entire attack.\n\n" +
                "8. If the defender successfully beats the attack, the turn passes to the next player to the left. If not, they become the new attacker, and the next player becomes the defender.\n\n" +
                "9. If the defender picks up the attack, they add the cards to their hand.\n\n" +
                "10. The round ends when all players have had a turn as the attacker, and the draw pile is empty.\n\n" +
                "11. The player who played the last card successfully becomes the first attacker in the next round.\n\n" +
                "12. The game continues until one player runs out of cards, at which point they are declared the winner.\n\n" +
                "13. If the draw pile is empty and no one has run out of cards, the player who was last able to successfully defend against an attack wins.\n\n" +
                "14. If multiple players run out of cards simultaneously, the player who had fewer cards remaining in their hand at the start of the round wins.\n\n" +
                "15. If multiple players have the same number of cards remaining, the player closest to the dealer's left wins.";
            rulesRichTextBox.Font = new Font("Arial", 10);
           
           
            rulesRichTextBox.ReadOnly = true;
            rulesRichTextBox.ScrollBars = RichTextBoxScrollBars.Vertical;

            // Apply styling to specific parts of the text

            // History of Durak
            rulesRichTextBox.Select(0, 16); // Select "History of Durak:"
            rulesRichTextBox.SelectionFont = new Font("Arial", 12, FontStyle.Bold);
            rulesRichTextBox.SelectionColor = Color.Blue;

            // Basic Rules of Durak
            rulesRichTextBox.Select(rulesRichTextBox.Text.IndexOf("Basic Rules of Durak:"), 20); // Select "Basic Rules of Durak:"
            rulesRichTextBox.SelectionFont = new Font("Arial", 12, FontStyle.Bold);
            rulesRichTextBox.SelectionColor = Color.Red;
        }
    }
}
