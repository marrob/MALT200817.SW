<?xml version='1.0' encoding='UTF-8'?>
<Project Type="Project" LVVersion="18008000">
	<Item Name="My Computer" Type="My Computer">
		<Property Name="server.app.propertiesEnabled" Type="Bool">true</Property>
		<Property Name="server.control.propertiesEnabled" Type="Bool">true</Property>
		<Property Name="server.tcp.enabled" Type="Bool">false</Property>
		<Property Name="server.tcp.port" Type="Int">0</Property>
		<Property Name="server.tcp.serviceName" Type="Str">My Computer/VI Server</Property>
		<Property Name="server.tcp.serviceName.default" Type="Str">My Computer/VI Server</Property>
		<Property Name="server.vi.callsEnabled" Type="Bool">true</Property>
		<Property Name="server.vi.propertiesEnabled" Type="Bool">true</Property>
		<Property Name="specify.custom.address" Type="Bool">false</Property>
		<Item Name="UnitTest" Type="Folder">
			<Item Name="Execute Cmd.vi" Type="VI" URL="/&lt;instrlib&gt;/AltonTech MALT/UnitTest/Execute Cmd.vi"/>
			<Item Name="Get Counter.vi" Type="VI" URL="/&lt;instrlib&gt;/AltonTech MALT/UnitTest/Get Counter.vi"/>
			<Item Name="Get Devices Test.vi" Type="VI" URL="/&lt;instrlib&gt;/AltonTech MALT/UnitTest/Get Devices Test.vi"/>
			<Item Name="Get One Status Test.vi" Type="VI" URL="/&lt;instrlib&gt;/AltonTech MALT/UnitTest/Get One Status Test.vi"/>
			<Item Name="Get Several Status Test.vi" Type="VI" URL="/&lt;instrlib&gt;/AltonTech MALT/UnitTest/Get Several Status Test.vi"/>
			<Item Name="MALT IOPS.vi" Type="VI" URL="/&lt;instrlib&gt;/AltonTech MALT/UnitTest/MALT IOPS.vi"/>
			<Item Name="MALT Set Rapidly.vi" Type="VI" URL="/&lt;instrlib&gt;/AltonTech MALT/UnitTest/MALT Set Rapidly.vi"/>
			<Item Name="MALT132 IOPS.vi" Type="VI" URL="/&lt;instrlib&gt;/AltonTech MALT/UnitTest/MALT132 IOPS.vi"/>
			<Item Name="MALT132.seq" Type="Document" URL="/&lt;instrlib&gt;/AltonTech MALT/UnitTest/MALT132.seq"/>
			<Item Name="ResponseTimeTest.vi" Type="VI" URL="/&lt;instrlib&gt;/AltonTech MALT/UnitTest/ResponseTimeTest.vi"/>
			<Item Name="Set One Test.vi" Type="VI" URL="/&lt;instrlib&gt;/AltonTech MALT/UnitTest/Set One Test.vi"/>
			<Item Name="Set Several Test.vi" Type="VI" URL="/&lt;instrlib&gt;/AltonTech MALT/UnitTest/Set Several Test.vi"/>
			<Item Name="ViTestFixture.vi" Type="VI" URL="/&lt;instrlib&gt;/AltonTech MALT/UnitTest/ViTestFixture.vi"/>
			<Item Name="YAV IOPSx.vi" Type="VI" URL="/&lt;instrlib&gt;/AltonTech MALT/UnitTest/YAV IOPSx.vi"/>
			<Item Name="YAV Set Rapidly.vi" Type="VI" URL="/&lt;instrlib&gt;/AltonTech MALT/UnitTest/YAV Set Rapidly.vi"/>
		</Item>
		<Item Name="AltonTech MALT200817.lvlib" Type="Library" URL="/&lt;instrlib&gt;/AltonTech MALT/AltonTech MALT200817.lvlib"/>
		<Item Name="Dependencies" Type="Dependencies">
			<Item Name="instr.lib" Type="Folder">
				<Item Name="CANNOU Close CANNOU.vi" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Tags/Phi6 Interface.llb/CANNOU Close CANNOU.vi"/>
				<Item Name="CANNOU Global Variables.gbl.vi" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/CANNOU Global Variables.llb/CANNOU Global Variables.gbl.vi"/>
				<Item Name="CANNOU Open CANNOU.vi" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Tags/Phi6 Interface.llb/CANNOU Open CANNOU.vi"/>
				<Item Name="YAV Card Total Info.ctl" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/YAV-System.llb/YAV Card Total Info.ctl"/>
				<Item Name="YAV General Send Command.vi" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/YAV-System.llb/YAV General Send Command.vi"/>
				<Item Name="YAV Info.ctl" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/YAV-System.llb/YAV Info.ctl"/>
				<Item Name="YAV90132 General Relay Action.vi" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/YAV-90132.llb/YAV90132 General Relay Action.vi"/>
				<Item Name="YAV90132 Mode Action.ctl" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/YAV-90132.llb/YAV90132 Mode Action.ctl"/>
				<Item Name="YAV90132 Type Action.ctl" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/YAV-90132.llb/YAV90132 Type Action.ctl"/>
			</Item>
			<Item Name="vi.lib" Type="Folder">
				<Item Name="BuildHelpPath.vi" Type="VI" URL="/&lt;vilib&gt;/Utility/error.llb/BuildHelpPath.vi"/>
				<Item Name="Check Special Tags.vi" Type="VI" URL="/&lt;vilib&gt;/Utility/error.llb/Check Special Tags.vi"/>
				<Item Name="Clear Errors.vi" Type="VI" URL="/&lt;vilib&gt;/Utility/error.llb/Clear Errors.vi"/>
				<Item Name="Convert property node font to graphics font.vi" Type="VI" URL="/&lt;vilib&gt;/Utility/error.llb/Convert property node font to graphics font.vi"/>
				<Item Name="Details Display Dialog.vi" Type="VI" URL="/&lt;vilib&gt;/Utility/error.llb/Details Display Dialog.vi"/>
				<Item Name="DialogType.ctl" Type="VI" URL="/&lt;vilib&gt;/Utility/error.llb/DialogType.ctl"/>
				<Item Name="DialogTypeEnum.ctl" Type="VI" URL="/&lt;vilib&gt;/Utility/error.llb/DialogTypeEnum.ctl"/>
				<Item Name="Error Code Database.vi" Type="VI" URL="/&lt;vilib&gt;/Utility/error.llb/Error Code Database.vi"/>
				<Item Name="ErrWarn.ctl" Type="VI" URL="/&lt;vilib&gt;/Utility/error.llb/ErrWarn.ctl"/>
				<Item Name="eventvkey.ctl" Type="VI" URL="/&lt;vilib&gt;/event_ctls.llb/eventvkey.ctl"/>
				<Item Name="Find Tag.vi" Type="VI" URL="/&lt;vilib&gt;/Utility/error.llb/Find Tag.vi"/>
				<Item Name="Format Message String.vi" Type="VI" URL="/&lt;vilib&gt;/Utility/error.llb/Format Message String.vi"/>
				<Item Name="General Error Handler Core CORE.vi" Type="VI" URL="/&lt;vilib&gt;/Utility/error.llb/General Error Handler Core CORE.vi"/>
				<Item Name="General Error Handler.vi" Type="VI" URL="/&lt;vilib&gt;/Utility/error.llb/General Error Handler.vi"/>
				<Item Name="Get String Text Bounds.vi" Type="VI" URL="/&lt;vilib&gt;/Utility/error.llb/Get String Text Bounds.vi"/>
				<Item Name="Get System Directory.vi" Type="VI" URL="/&lt;vilib&gt;/Utility/sysdir.llb/Get System Directory.vi"/>
				<Item Name="Get Text Rect.vi" Type="VI" URL="/&lt;vilib&gt;/picture/picture.llb/Get Text Rect.vi"/>
				<Item Name="GetHelpDir.vi" Type="VI" URL="/&lt;vilib&gt;/Utility/error.llb/GetHelpDir.vi"/>
				<Item Name="GetRTHostConnectedProp.vi" Type="VI" URL="/&lt;vilib&gt;/Utility/error.llb/GetRTHostConnectedProp.vi"/>
				<Item Name="Longest Line Length in Pixels.vi" Type="VI" URL="/&lt;vilib&gt;/Utility/error.llb/Longest Line Length in Pixels.vi"/>
				<Item Name="LVBoundsTypeDef.ctl" Type="VI" URL="/&lt;vilib&gt;/Utility/miscctls.llb/LVBoundsTypeDef.ctl"/>
				<Item Name="LVRectTypeDef.ctl" Type="VI" URL="/&lt;vilib&gt;/Utility/miscctls.llb/LVRectTypeDef.ctl"/>
				<Item Name="NI_XML.lvlib" Type="Library" URL="/&lt;vilib&gt;/xml/NI_XML.lvlib"/>
				<Item Name="Not Found Dialog.vi" Type="VI" URL="/&lt;vilib&gt;/Utility/error.llb/Not Found Dialog.vi"/>
				<Item Name="Search and Replace Pattern.vi" Type="VI" URL="/&lt;vilib&gt;/Utility/error.llb/Search and Replace Pattern.vi"/>
				<Item Name="Set Bold Text.vi" Type="VI" URL="/&lt;vilib&gt;/Utility/error.llb/Set Bold Text.vi"/>
				<Item Name="Set String Value.vi" Type="VI" URL="/&lt;vilib&gt;/Utility/error.llb/Set String Value.vi"/>
				<Item Name="Simple Error Handler.vi" Type="VI" URL="/&lt;vilib&gt;/Utility/error.llb/Simple Error Handler.vi"/>
				<Item Name="Space Constant.vi" Type="VI" URL="/&lt;vilib&gt;/dlg_ctls.llb/Space Constant.vi"/>
				<Item Name="System Directory Type.ctl" Type="VI" URL="/&lt;vilib&gt;/Utility/sysdir.llb/System Directory Type.ctl"/>
				<Item Name="TagReturnType.ctl" Type="VI" URL="/&lt;vilib&gt;/Utility/error.llb/TagReturnType.ctl"/>
				<Item Name="Three Button Dialog CORE.vi" Type="VI" URL="/&lt;vilib&gt;/Utility/error.llb/Three Button Dialog CORE.vi"/>
				<Item Name="Three Button Dialog.vi" Type="VI" URL="/&lt;vilib&gt;/Utility/error.llb/Three Button Dialog.vi"/>
				<Item Name="Trim Whitespace.vi" Type="VI" URL="/&lt;vilib&gt;/Utility/error.llb/Trim Whitespace.vi"/>
				<Item Name="whitespace.ctl" Type="VI" URL="/&lt;vilib&gt;/Utility/error.llb/whitespace.ctl"/>
			</Item>
			<Item Name="DOMUserDefRef.dll" Type="Document" URL="DOMUserDefRef.dll">
				<Property Name="NI.PreserveRelativePath" Type="Bool">true</Property>
			</Item>
			<Item Name="System.ServiceProcess" Type="Document" URL="System.ServiceProcess">
				<Property Name="NI.PreserveRelativePath" Type="Bool">true</Property>
			</Item>
		</Item>
		<Item Name="Build Specifications" Type="Build"/>
	</Item>
</Project>
