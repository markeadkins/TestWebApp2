<%@ Page Title="Brewing Session" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BrewSession.aspx.cs" Inherits="TestWebApp2.BrewSession" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

<div id="SessionContent" runat="server">
<asp:Timer runat="server" id="UpdateTemp" Interval="2000" OnTick="UpdateTemp_Tick" />
    
    <div id="BoilPID" class="col-md-4">
	    <asp:UpdatePanel runat="server" id="TempPanel1" UpdateMode="Conditional">
            <Triggers>
			    <asp:AsyncPostBackTrigger ControlID="UpdateTemp" EventName="Tick" />
		    </Triggers>
		    <ContentTemplate>
                <h2>Boil PID</h2>
                <h4>Current Boil Temp is:</h4>
			    <asp:Label runat="server" id="TempLabel1" Text="" /><br />
		    </ContentTemplate>
	    </asp:UpdatePanel>
	    <h4>Boil Temp is set to</h4>
	    <asp:Label runat="server" id="CurrentSetTemp1" OnInit="setCurrentTemp1" /><br />
	    <h3>Set Temp to</h3>
	    <asp:TextBox runat="server" id="TempSet1" /><br />
	    <asp:Button runat="server" id="SendTemp1" Text="Set" OnClick="sendTemp1" /><br />
	    <asp:UpdatePanel runat="server" id="TempIndicator1" UpdateMode="Conditional">
		    <Triggers>
			    <asp:AsyncPostBackTrigger ControlID="UpdateTemp" EventName="Tick" />
		    </Triggers>
		    <ContentTemplate>
			    <asp:Label runat="server" id="HeatingIndicator1" /><br />
		    </ContentTemplate>
	    </asp:UpdatePanel>
        </div><!---/#BoilPID-->

    <div id="MashPID" class="col-md-4">
		<asp:UpdatePanel runat="server" id="TempPanel2" UpdateMode="Conditional">
			<Triggers>
				<asp:AsyncPostBackTrigger ControlID="UpdateTemp" EventName="Tick" />
			</Triggers>
			<ContentTemplate>
                <h2>Mash PID</h2>
                <h4>Current Mash Temp is:</h4>
				<asp:Label runat="server" id="TempLabel2" Text="" /><br />
			</ContentTemplate>
		</asp:UpdatePanel>
	</div><!---/#MashPID-->

    <div id="HLT_RIMsPID" class="col-md-4">
		<asp:UpdatePanel runat="server" id="TempPanel3" UpdateMode="Conditional">
			<Triggers>
				<asp:AsyncPostBackTrigger ControlID="UpdateTemp" EventName="Tick" />
			</Triggers>
			<ContentTemplate>
                <h2>HLT_RIMs PID</h2>
                <h4>Current HLT_RIMs Temp is:</h4>
				<asp:Label runat="server" id="TempLabel3" Text="" /><br />
			</ContentTemplate>
		</asp:UpdatePanel>
		<h4>HLT_RIMs is set to</h4>
		<asp:Label runat="server" id="CurrentSetTemp3" OnInit="setCurrentTemp3" /><br />
		<h3>Set Temp to</h3>
		<asp:TextBox runat="server" id="TempSet3" /><br />
		<asp:Button runat="server" id="SendTemp3" Text="Set" OnClick="sendTemp3" /><br />
		<asp:UpdatePanel runat="server" id="TempIndicator3" UpdateMode="Conditional">
			<Triggers>
				<asp:AsyncPostBackTrigger ControlID="UpdateTemp" EventName="Tick" />
			</Triggers>
			<ContentTemplate>
				<asp:Label runat="server" id="HeatingIndicator3" /><br />
			</ContentTemplate>
		</asp:UpdatePanel>
	</div><!---/#HLT_RIMsPID-->


</div>

</asp:Content>
