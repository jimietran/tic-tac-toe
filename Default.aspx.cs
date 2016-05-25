using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TicTacToe.Models;
using TicTacToe.Data;

namespace TicTacToe
{
    /// <summary>
    /// Code behind for the Tic Tac Toe page
    /// </summary>
    public partial class Default : System.Web.UI.Page
    {
        // Global variables
        private List<Button> columnLeft = new List<Button>(3);
        private List<Button> columnMiddle = new List<Button>(3);
        private List<Button> columnRight = new List<Button>(3);

        private List<Button> rowTop = new List<Button>(3);
        private List<Button> rowCenter = new List<Button>(3);
        private List<Button> rowBottom = new List<Button>(3);

        private List<Button> diagonalLeft = new List<Button>(3);
        private List<Button> diagonalRight = new List<Button>(3);

        private List<List<Button>> winList = new List<List<Button>>(8);

        TicTacToeModel ticTacToeModel = new TicTacToeModel();

        /// <summary>
        /// Current player viewstate
        /// </summary>
        private String currentPlayer
        {
            get
            {
                if (ViewState["CurrentPlayer"] != null)
                {
                    return (String)ViewState["CurrentPlayer"];
                }
                return null;
            }
            set
            {
                ViewState["CurrentPlayer"] = value;
            }
        }

        /// <summary>
        /// Set initial player and win combinations when page loads
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                currentPlayer = "X"; 
            }

            // Determine the win conditions on page load
            columnLeft.AddRange(new Button[] { btn_topLeft, btn_centerLeft, btn_bottomLeft });
            columnMiddle.AddRange(new Button[] { btn_topMiddle, btn_centerMiddle, btn_bottomMiddle });
            columnRight.AddRange(new Button[] { btn_topRight, btn_centerRight, btn_bottomRight });

            rowTop.AddRange(new Button[] { btn_topLeft, btn_topMiddle, btn_topRight });
            rowCenter.AddRange(new Button[] { btn_centerLeft, btn_centerMiddle, btn_centerRight });
            rowBottom.AddRange(new Button[] { btn_bottomLeft, btn_bottomMiddle, btn_bottomRight });

            diagonalLeft.AddRange(new Button[] { btn_topLeft, btn_centerMiddle, btn_bottomRight });
            diagonalRight.AddRange(new Button[] { btn_topRight, btn_centerMiddle, btn_bottomLeft });

            winList.AddRange(new List<Button>[] { columnLeft, columnMiddle, columnRight, rowTop, rowCenter, rowBottom,
                diagonalLeft, diagonalRight });
        }

        /// <summary>
        /// Determine game state on each button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void playerClick_Click(object sender, EventArgs e)
        {
            Button currentButton = (Button)sender;

            // Buttons are initially set to " " to keep proper formatting
            if ((currentButton.Text).Equals(" "))
            {
                currentButton.Text = currentPlayer;
            }

            bool currentPlayerWins = false;

            // If any of the win conditions are fulfilled, the player wins
            foreach (List<Button> button in winList)
            {
                if (!(button[0].Text).Equals(" "))
                {
                    if ((button[0].Text).Equals(button[1].Text) && (button[1].Text).Equals(button[2].Text))
                    {
                        currentPlayerWins = true;
                    }
                }
            }

            if (currentPlayerWins == true)
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Winner", "alert('" + currentPlayer +
                    " is the winner!');", true);

                // Every button is disabled after the game ends. Looping through buttons seems to destroy formatting so they are manually set.
                btn_topLeft.Enabled = false;
                btn_topMiddle.Enabled = false;
                btn_topRight.Enabled = false;
                btn_centerLeft.Enabled = false;
                btn_centerMiddle.Enabled = false;
                btn_centerRight.Enabled = false;
                btn_bottomLeft.Enabled = false;
                btn_bottomMiddle.Enabled = false;
                btn_bottomRight.Enabled = false;

                lnkbtn_resetGrid.Text = "Play Again";
            }
            else
            {
                // Switch players if the game has not ended
                if (currentPlayer.Equals("X"))
                {
                    currentPlayer = "O";
                }
                else if (currentPlayer.Equals("O"))
                {
                    currentPlayer = "X";
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), 
                        "PlayerError", "alert('An error has occurred. Contact Jimie Tran for assistance.');", true);
                }
            }
        }

        /// <summary>
        /// Redirects the user to see all previously saved games
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lnkbtn_viewHistory_Click(object sender, EventArgs e)
        {
            Response.Redirect("TicTacToe");
        }

        /// <summary>
        /// Reset the current grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lnkbtn_resetGrid_Click(object sender, EventArgs e)
        {
            currentPlayer = "X";
            lnkbtn_resetGrid.Text = "Reset Grid";

            foreach (List<Button> win in winList)
            {
                foreach (Button button in win)
                {
                    button.Text = " ";
                    button.Enabled = true;
                }
            }
        }

        /// <summary>
        /// Save the current game into the local database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lnkbtn_saveGame_Click(object sender, EventArgs e)
        {
            foreach (List<Button> win in winList)
            {
                foreach (Button button in win)
                {
                    button.Enabled = false;

                    if ((button.Text).Equals(" "))
                    {
                        button.Text = null;
                    }
                }
            }

            GameObject game = new GameObject();

            game.topLeft = btn_topLeft.Text;
            game.topMiddle = btn_topMiddle.Text;
            game.topRight = btn_topRight.Text;
            game.centerLeft = btn_centerLeft.Text;
            game.centerMiddle = btn_centerMiddle.Text;
            game.centerRight = btn_centerRight.Text;
            game.bottomLeft = btn_bottomLeft.Text;
            game.bottomMiddle = btn_bottomMiddle.Text;
            game.bottomRight = btn_bottomRight.Text;

            try
            {
                ticTacToeModel.insertGame(game);

                ScriptManager.RegisterStartupScript(Page, Page.GetType(),
                        "SaveSuccessful", "alert('Game successfully saved.');", true);
            }
            catch
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(),
                        "SaveError", "alert('Game could not be saved. Contact Jimie Tran for assistance.');", true);
            }
        }
    }
}