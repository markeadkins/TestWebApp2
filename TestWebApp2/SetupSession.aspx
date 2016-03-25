<%@ Page Title="Setup Brewing Session" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SetupSession.aspx.cs" Inherits="TestWebApp2.SetupSession" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div id="SessionContent" runat="server">

        
        <br />
        

                <asp:Label ID="BoilProbeLabel" runat="server" Text="Boil Probe"></asp:Label>
                    <asp:RadioButtonList ID="radio1" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal" >
                    </asp:RadioButtonList>
                    <br />
                    <asp:Button ID="BoilProbeButton" runat="server" Text="Assign Boil Temp Probe" onClick="BoilProbeAssign" />
                    <br />

            <br />

     
                <asp:Label ID="MashProbeLabel" runat="server" Text="Mash Probe"></asp:Label>
                    <asp:RadioButtonList ID="radio2" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal"> 
                    </asp:RadioButtonList>
                    <br />
                    <asp:Button ID="MashProbeButton" runat="server" Text="Assign Mash Temp Probe" onClick="MashProbeAssign" />
                    <br />

            <br />
        
          
                <asp:Label ID="HLT_RIMsProbeLabel" runat="server" Text="HLT_RIMs Probe"></asp:Label>
                    <asp:RadioButtonList ID="radio3" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal">
                    </asp:RadioButtonList>
                    <br />
                    <asp:Button ID="HLT_RIMProbeButton" runat="server" Text="Assign HLT_RIMs Temp Probe" onClick="HLT_RIMsProbeAssign" />
                    <br />

            <br />
            <asp:Button ID="AssignProbes" runat="server" Text="Assign HLT_RIMs Temp Probe" onClick="ProbeAssign" />
            <br />
        
        <br />

    </div>

</asp:Content>
