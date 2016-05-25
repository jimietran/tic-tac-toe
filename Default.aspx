<%@ Page Language="C#" MasterPageFile="~/TicTacToe.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TicTacToe.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager runat="server" ID="scriptManager"></asp:ScriptManager>

    <asp:UpdatePanel runat="server" ID="updpnl_ticTacToe">
        <ContentTemplate>
            <div id="div_header">
                <h1>Tic Tac Toe</h1>
            </div>

            <div id="div_ticTacToeGrid">
                <asp:Table CssClass="table" runat="server" ID="tbl_ticTacToeGrid">
                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:Button CssClass="table-input" runat="server" ID="btn_topLeft" Text=" " OnClick="playerClick_Click" />
                            <asp:Button CssClass="table-input" runat="server" ID="btn_topMiddle" Text=" " OnClick="playerClick_Click" />
                            <asp:Button CssClass="table-input" runat="server" ID="btn_topRight" Text=" " OnClick="playerClick_Click" />
                        </asp:TableCell>
                    </asp:TableRow>

                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:Button CssClass="table-input" runat="server" ID="btn_centerLeft" Text=" " OnClick="playerClick_Click" />
                            <asp:Button CssClass="table-input" runat="server" ID="btn_centerMiddle" Text=" " OnClick="playerClick_Click" />
                            <asp:Button CssClass="table-input" runat="server" ID="btn_centerRight" Text=" " OnClick="playerClick_Click" />
                        </asp:TableCell>
                    </asp:TableRow>

                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:Button CssClass="table-input" runat="server" ID="btn_bottomLeft" Text=" " OnClick="playerClick_Click" />
                            <asp:Button CssClass="table-input" runat="server" ID="btn_bottomMiddle" Text=" " OnClick="playerClick_Click" />
                            <asp:Button CssClass="table-input" runat="server" ID="btn_bottomRight" Text=" " OnClick="playerClick_Click" />
                        </asp:TableCell>
                    </asp:TableRow>

                    <asp:TableRow>
                        <asp:TableCell>
                            <br />
                            <asp:LinkButton runat="server" ID="lnkbtn_viewHistory" Text="View Saved Games" Visible="true" OnClick="lnkbtn_viewHistory_Click"></asp:LinkButton>
                            &nbsp
                            <asp:LinkButton runat="server" ID="lnkbtn_resetGrid" Text="Reset Grid" OnClick="lnkbtn_resetGrid_Click"></asp:LinkButton>
                            &nbsp
                            <asp:LinkButton runat="server" ID="lnkbtn_saveGame" Text="Save and Quit" OnClick="lnkbtn_saveGame_Click"></asp:LinkButton>
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>