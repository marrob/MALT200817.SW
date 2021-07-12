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
				<Item Name="Action CAN.ctl" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Lower Layer/MultiCAN.llb/Action CAN.ctl"/>
				<Item Name="AK087 Info.ctl" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/AK-087.llb/AK087 Info.ctl"/>
				<Item Name="AK087 Info.vi" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/AK-087.llb/AK087 Info.vi"/>
				<Item Name="AK087 Message Dispatcher.vi" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/AK-087.llb/AK087 Message Dispatcher.vi"/>
				<Item Name="CAN Frame Array To XNET Frame array.vi" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Lower Layer/NI-XNET.llb/CAN Frame Array To XNET Frame array.vi"/>
				<Item Name="CANNOU All YAVS Init.vi" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/CANNOU.llb/CANNOU All YAVS Init.vi"/>
				<Item Name="CANNOU CAN OPTIONS File Control.vi" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/CANNOU.llb/CANNOU CAN OPTIONS File Control.vi"/>
				<Item Name="CANNOU Card Stat.ctl" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/CANNOU Global Variables.llb/CANNOU Card Stat.ctl"/>
				<Item Name="CANNOU Close CANNOU.vi" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Tags/Phi6 Interface.llb/CANNOU Close CANNOU.vi"/>
				<Item Name="CANNOU General.vi" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/CANNOU.llb/CANNOU General.vi"/>
				<Item Name="CANNOU Global Variables.gbl.vi" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/CANNOU Global Variables.llb/CANNOU Global Variables.gbl.vi"/>
				<Item Name="CANNOU Open CANNOU.vi" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Tags/Phi6 Interface.llb/CANNOU Open CANNOU.vi"/>
				<Item Name="CANNOU Program Loop.vi" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/CANNOU.llb/CANNOU Program Loop.vi"/>
				<Item Name="Communication Interface.ctl" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Lower Layer/MultiCAN.llb/Communication Interface.ctl"/>
				<Item Name="General CAN Control.vi" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Lower Layer/MultiCAN.llb/General CAN Control.vi"/>
				<Item Name="H710060 General Action.vi" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/H7100-60.llb/H710060 General Action.vi"/>
				<Item Name="H710060 Info.ctl" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/H7100-60.llb/H710060 Info.ctl"/>
				<Item Name="H710060 Info.vi" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/H7100-60.llb/H710060 Info.vi"/>
				<Item Name="H710060 Init Actions.vi" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/H7100-60.llb/H710060 Init Actions.vi"/>
				<Item Name="H710060 Message Dispatcher.vi" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/H7100-60.llb/H710060 Message Dispatcher.vi"/>
				<Item Name="H710060 Type Action .ctl" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/H7100-60.llb/H710060 Type Action .ctl"/>
				<Item Name="H710061 Command.ctl" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/H7100-61.llb/H710061 Command.ctl"/>
				<Item Name="H710061 General Action.vi" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/H7100-61.llb/H710061 General Action.vi"/>
				<Item Name="H710061 Info.ctl" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/H7100-61.llb/H710061 Info.ctl"/>
				<Item Name="H710061 Info.vi" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/H7100-61.llb/H710061 Info.vi"/>
				<Item Name="H710061 Init Actions.vi" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/H7100-61.llb/H710061 Init Actions.vi"/>
				<Item Name="H710061 Message Dispatcher.vi" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/H7100-61.llb/H710061 Message Dispatcher.vi"/>
				<Item Name="H710061 Type Action .ctl" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/H7100-61.llb/H710061 Type Action .ctl"/>
				<Item Name="H730050 Action.ctl" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/H7300-50.llb/H730050 Action.ctl"/>
				<Item Name="H730050 General Action .vi" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/H7300-50.llb/H730050 General Action .vi"/>
				<Item Name="H730050 Info.ctl" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/H7300-50.llb/H730050 Info.ctl"/>
				<Item Name="H730050 Info.vi" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/H7300-50.llb/H730050 Info.vi"/>
				<Item Name="H730050 Init Actions.vi" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/H7300-50.llb/H730050 Init Actions.vi"/>
				<Item Name="H730050 Message Dispatcher.vi" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/H7300-50.llb/H730050 Message Dispatcher.vi"/>
				<Item Name="MALT132 Set One.vi" Type="VI" URL="/&lt;instrlib&gt;/AltonTech MALT/Public/Devices/MALT132/MALT132 Set One.vi"/>
				<Item Name="message.ctl" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Lower Layer/MultiCAN.llb/message.ctl"/>
				<Item Name="MMI Action.ctl" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/MMI-Core.llb/MMI Action.ctl"/>
				<Item Name="MMI Info.ctl" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/MMI-Core.llb/MMI Info.ctl"/>
				<Item Name="MMI Info.vi" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/MMI-Core.llb/MMI Info.vi"/>
				<Item Name="MMI Init Actions.vi" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/MMI-Core.llb/MMI Init Actions.vi"/>
				<Item Name="MMI Message Dispatcher.vi" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/MMI-Core.llb/MMI Message Dispatcher.vi"/>
				<Item Name="MMI Output Action.vi" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/MMI-Core.llb/MMI Output Action.vi"/>
				<Item Name="Module CAN.ctl" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Lower Layer/MultiCAN.llb/Module CAN.ctl"/>
				<Item Name="NI-CAN Close general multi CAN.vi" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Lower Layer/NI-CANMultiCAN.llb/NI-CAN Close general multi CAN.vi"/>
				<Item Name="NI-CAN General CAN Control.vi" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Lower Layer/NI-CANMultiCAN.llb/NI-CAN General CAN Control.vi"/>
				<Item Name="NI-CAN Open general multi CAN.vi" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Lower Layer/NI-CANMultiCAN.llb/NI-CAN Open general multi CAN.vi"/>
				<Item Name="NI-CAN Read general multi CAN.vi" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Lower Layer/NI-CANMultiCAN.llb/NI-CAN Read general multi CAN.vi"/>
				<Item Name="NI-CAN Write general multi CAN.vi" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Lower Layer/NI-CANMultiCAN.llb/NI-CAN Write general multi CAN.vi"/>
				<Item Name="NI-XNET Close general multi CAN.vi" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Lower Layer/NI-XNET.llb/NI-XNET Close general multi CAN.vi"/>
				<Item Name="NI-XNET General CAN Control.vi" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Lower Layer/NI-XNET.llb/NI-XNET General CAN Control.vi"/>
				<Item Name="NI-XNET Open general multi CAN.vi" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Lower Layer/NI-XNET.llb/NI-XNET Open general multi CAN.vi"/>
				<Item Name="NI-XNET Read general multi CAN.vi" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Lower Layer/NI-XNET.llb/NI-XNET Read general multi CAN.vi"/>
				<Item Name="NI-XNET Write general multi CAN.vi" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Lower Layer/NI-XNET.llb/NI-XNET Write general multi CAN.vi"/>
				<Item Name="Phi6Config Finder.vi" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/CANNOU.llb/Phi6Config Finder.vi"/>
				<Item Name="Type Communication.gbl.vi" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Lower Layer/MultiCAN.llb/Type Communication.gbl.vi"/>
				<Item Name="UDP Avoid Timeout Message.vi" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Lower Layer/UPDMultiCAN.llb/UDP Avoid Timeout Message.vi"/>
				<Item Name="UDP CAN Message to UDPString.vi" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Lower Layer/UPDMultiCAN.llb/UDP CAN Message to UDPString.vi"/>
				<Item Name="UDP Close general multi CAN.vi" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Lower Layer/UPDMultiCAN.llb/UDP Close general multi CAN.vi"/>
				<Item Name="UDP General CAN Control.vi" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Lower Layer/UPDMultiCAN.llb/UDP General CAN Control.vi"/>
				<Item Name="UDP Get Packet from correct IP.vi" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Lower Layer/UPDMultiCAN.llb/UDP Get Packet from correct IP.vi"/>
				<Item Name="UDP Kernel Actions.vi" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Lower Layer/UPDMultiCAN.llb/UDP Kernel Actions.vi"/>
				<Item Name="UDP Open general multi CAN.vi" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Lower Layer/UPDMultiCAN.llb/UDP Open general multi CAN.vi"/>
				<Item Name="UDP Read general multi CAN.vi" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Lower Layer/UPDMultiCAN.llb/UDP Read general multi CAN.vi"/>
				<Item Name="UDP UDPString to CAN Message.vi" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Lower Layer/UPDMultiCAN.llb/UDP UDPString to CAN Message.vi"/>
				<Item Name="UDP Write general multi CAN.vi" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Lower Layer/UPDMultiCAN.llb/UDP Write general multi CAN.vi"/>
				<Item Name="XNET Frame Array To CAN Frame array.vi" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Lower Layer/NI-XNET.llb/XNET Frame Array To CAN Frame array.vi"/>
				<Item Name="YAV Card Total Info.ctl" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/YAV-System.llb/YAV Card Total Info.ctl"/>
				<Item Name="YAV General Send Command.vi" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/YAV-System.llb/YAV General Send Command.vi"/>
				<Item Name="YAV Info.ctl" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/YAV-System.llb/YAV Info.ctl"/>
				<Item Name="YAV90CLR Byte to High-Low.vi" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/YAV-90CLR.llb/YAV90CLR Byte to High-Low.vi"/>
				<Item Name="YAV90CLR Get RGB &amp; Gain.vi" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/YAV-90CLR.llb/YAV90CLR Get RGB &amp; Gain.vi"/>
				<Item Name="YAV90CLR High-Low To Word.vi" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/YAV-90CLR.llb/YAV90CLR High-Low To Word.vi"/>
				<Item Name="YAV90CLR info.ctl" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/YAV-90CLR.llb/YAV90CLR info.ctl"/>
				<Item Name="YAV90CLR Info.vi" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/YAV-90CLR.llb/YAV90CLR Info.vi"/>
				<Item Name="YAV90CLR Init Actions.vi" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/YAV-90CLR.llb/YAV90CLR Init Actions.vi"/>
				<Item Name="YAV90CLR Message Dispatcher.vi" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/YAV-90CLR.llb/YAV90CLR Message Dispatcher.vi"/>
				<Item Name="YAV90HVT Action.ctl" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/YAV-90HVT.llb/YAV90HVT Action.ctl"/>
				<Item Name="YAV90HVT General Action .vi" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/YAV-90HVT.llb/YAV90HVT General Action .vi"/>
				<Item Name="YAV90HVT Info.ctl" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/YAV-90HVT.llb/YAV90HVT Info.ctl"/>
				<Item Name="YAV90HVT Info.vi" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/YAV-90HVT.llb/YAV90HVT Info.vi"/>
				<Item Name="YAV90HVT Init Actions.vi" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/YAV-90HVT.llb/YAV90HVT Init Actions.vi"/>
				<Item Name="YAV90HVT Message Dispatcher.vi" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/YAV-90HVT.llb/YAV90HVT Message Dispatcher.vi"/>
				<Item Name="YAV90MMU Action.ctl" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/YAV-90MMU.llb/YAV90MMU Action.ctl"/>
				<Item Name="YAV90MMU General Action .vi" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/YAV-90MMU.llb/YAV90MMU General Action .vi"/>
				<Item Name="YAV90MMU Info.ctl" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/YAV-90MMU.llb/YAV90MMU Info.ctl"/>
				<Item Name="YAV90MMU Info.vi" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/YAV-90MMU.llb/YAV90MMU Info.vi"/>
				<Item Name="YAV90MMU Init Actions.vi" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/YAV-90MMU.llb/YAV90MMU Init Actions.vi"/>
				<Item Name="YAV90MMU Message Dispatcher.vi" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/YAV-90MMU.llb/YAV90MMU Message Dispatcher.vi"/>
				<Item Name="YAV90MUX General Relay Action.vi" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/YAV-90MUX.llb/YAV90MUX General Relay Action.vi"/>
				<Item Name="YAV90MUX Info.ctl" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/YAV-90MUX.llb/YAV90MUX Info.ctl"/>
				<Item Name="YAV90MUX Info.vi" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/YAV-90MUX.llb/YAV90MUX Info.vi"/>
				<Item Name="YAV90MUX Init Actions.vi" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/YAV-90MUX.llb/YAV90MUX Init Actions.vi"/>
				<Item Name="YAV90MUX Message Dispatcher.vi" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/YAV-90MUX.llb/YAV90MUX Message Dispatcher.vi"/>
				<Item Name="YAV90MUX Type Action.ctl" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/YAV-90MUX.llb/YAV90MUX Type Action.ctl"/>
				<Item Name="YAV90PIN General Relay Action.vi" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/YAV-90PIN.llb/YAV90PIN General Relay Action.vi"/>
				<Item Name="YAV90PIN Info.ctl" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/YAV-90PIN.llb/YAV90PIN Info.ctl"/>
				<Item Name="YAV90PIN Info.vi" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/YAV-90PIN.llb/YAV90PIN Info.vi"/>
				<Item Name="YAV90PIN Init Actions.vi" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/YAV-90PIN.llb/YAV90PIN Init Actions.vi"/>
				<Item Name="YAV90PIN Message Dispatcher.vi" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/YAV-90PIN.llb/YAV90PIN Message Dispatcher.vi"/>
				<Item Name="YAV90PIN Mode Action.ctl" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/YAV-90PIN.llb/YAV90PIN Mode Action.ctl"/>
				<Item Name="YAV90PIN Type Action.ctl" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/YAV-90PIN.llb/YAV90PIN Type Action.ctl"/>
				<Item Name="YAV90PNE Action.vi" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/YAV-90PNE.llb/YAV90PNE Action.vi"/>
				<Item Name="YAV90PNE Build Info Data.vi" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/YAV-90PNE.llb/YAV90PNE Build Info Data.vi"/>
				<Item Name="YAV90PNE Info.ctl" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/YAV-90PNE.llb/YAV90PNE Info.ctl"/>
				<Item Name="YAV90PNE Info.vi" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/YAV-90PNE.llb/YAV90PNE Info.vi"/>
				<Item Name="YAV90PNE Init Actions.vi" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/YAV-90PNE.llb/YAV90PNE Init Actions.vi"/>
				<Item Name="YAV90PNE Message Dispatcher.vi" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/YAV-90PNE.llb/YAV90PNE Message Dispatcher.vi"/>
				<Item Name="YAV90PNE Type Action .ctl" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/YAV-90PNE.llb/YAV90PNE Type Action .ctl"/>
				<Item Name="YAV90xxx Action.ctl" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/YAV-90xxx.llb/YAV90xxx Action.ctl"/>
				<Item Name="YAV90xxx Info.ctl" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/YAV-90xxx.llb/YAV90xxx Info.ctl"/>
				<Item Name="YAV90xxx Info.vi" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/YAV-90xxx.llb/YAV90xxx Info.vi"/>
				<Item Name="YAV90xxx Init Actions.vi" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/YAV-90xxx.llb/YAV90xxx Init Actions.vi"/>
				<Item Name="YAV90xxx Message Dispatcher.vi" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/YAV-90xxx.llb/YAV90xxx Message Dispatcher.vi"/>
				<Item Name="YAV90xxx Output Action.vi" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/YAV-90xxx.llb/YAV90xxx Output Action.vi"/>
				<Item Name="YAV904x8 General Relay Action.vi" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/YAV-904x8.llb/YAV904x8 General Relay Action.vi"/>
				<Item Name="YAV904X8 Info.ctl" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/YAV-904x8.llb/YAV904X8 Info.ctl"/>
				<Item Name="YAV904X8 Info.vi" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/YAV-904x8.llb/YAV904X8 Info.vi"/>
				<Item Name="YAV904x8 Init Actions.vi" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/YAV-904x8.llb/YAV904x8 Init Actions.vi"/>
				<Item Name="YAV904X8 Message Dispatcher.vi" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/YAV-904x8.llb/YAV904X8 Message Dispatcher.vi"/>
				<Item Name="YAV904X8 Mode Action.ctl" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/YAV-904x8.llb/YAV904X8 Mode Action.ctl"/>
				<Item Name="YAV904X8 Type Action.ctl" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/YAV-904x8.llb/YAV904X8 Type Action.ctl"/>
				<Item Name="YAV90059 General Relay Action.vi" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/YAV-90059.llb/YAV90059 General Relay Action.vi"/>
				<Item Name="YAV90059 Info.ctl" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/YAV-90059.llb/YAV90059 Info.ctl"/>
				<Item Name="YAV90059 Info.vi" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/YAV-90059.llb/YAV90059 Info.vi"/>
				<Item Name="YAV90059 Init Actions.vi" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/YAV-90059.llb/YAV90059 Init Actions.vi"/>
				<Item Name="YAV90059 Message Dispatcher.vi" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/YAV-90059.llb/YAV90059 Message Dispatcher.vi"/>
				<Item Name="YAV90059 Type Action.ctl" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/YAV-90059.llb/YAV90059 Type Action.ctl"/>
				<Item Name="YAV90060 General Relay Action.vi" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/YAV-90060.llb/YAV90060 General Relay Action.vi"/>
				<Item Name="YAV90060 Info.ctl" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/YAV-90060.llb/YAV90060 Info.ctl"/>
				<Item Name="YAV90060 Info.vi" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/YAV-90060.llb/YAV90060 Info.vi"/>
				<Item Name="YAV90060 Init Actions.vi" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/YAV-90060.llb/YAV90060 Init Actions.vi"/>
				<Item Name="YAV90060 Message Dispatcher.vi" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/YAV-90060.llb/YAV90060 Message Dispatcher.vi"/>
				<Item Name="YAV90060 Type Action.ctl" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/YAV-90060.llb/YAV90060 Type Action.ctl"/>
				<Item Name="YAV90096 Action.vi" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/YAV-90096.llb/YAV90096 Action.vi"/>
				<Item Name="YAV90096 Info.ctl" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/YAV-90096.llb/YAV90096 Info.ctl"/>
				<Item Name="YAV90096 Info.vi" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/YAV-90096.llb/YAV90096 Info.vi"/>
				<Item Name="YAV90096 Init Actions.vi" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/YAV-90096.llb/YAV90096 Init Actions.vi"/>
				<Item Name="YAV90096 Message Dispatcher.vi" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/YAV-90096.llb/YAV90096 Message Dispatcher.vi"/>
				<Item Name="YAV90096 Type Action .ctl" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/YAV-90096.llb/YAV90096 Type Action .ctl"/>
				<Item Name="YAV90128 General Relay Action.vi" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/YAV-90128.llb/YAV90128 General Relay Action.vi"/>
				<Item Name="YAV90128 Info.ctl" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/YAV-90128.llb/YAV90128 Info.ctl"/>
				<Item Name="YAV90128 Info.vi" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/YAV-90128.llb/YAV90128 Info.vi"/>
				<Item Name="YAV90128 Init Actions.vi" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/YAV-90128.llb/YAV90128 Init Actions.vi"/>
				<Item Name="YAV90128 Message Dispatcher.vi" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/YAV-90128.llb/YAV90128 Message Dispatcher.vi"/>
				<Item Name="YAV90128 Mode Action.ctl" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/YAV-90128.llb/YAV90128 Mode Action.ctl"/>
				<Item Name="YAV90128 Type Action.ctl" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/YAV-90128.llb/YAV90128 Type Action.ctl"/>
				<Item Name="YAV90132 General Relay Action.vi" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/YAV-90132.llb/YAV90132 General Relay Action.vi"/>
				<Item Name="YAV90132 Info.ctl" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/YAV-90132.llb/YAV90132 Info.ctl"/>
				<Item Name="YAV90132 Info.vi" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/YAV-90132.llb/YAV90132 Info.vi"/>
				<Item Name="YAV90132 Init Actions.vi" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/YAV-90132.llb/YAV90132 Init Actions.vi"/>
				<Item Name="YAV90132 Message Dispatcher.vi" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/YAV-90132.llb/YAV90132 Message Dispatcher.vi"/>
				<Item Name="YAV90132 Mode Action.ctl" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/YAV-90132.llb/YAV90132 Mode Action.ctl"/>
				<Item Name="YAV90132 Type Action.ctl" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/YAV-90132.llb/YAV90132 Type Action.ctl"/>
				<Item Name="YAV90304 Info.ctl" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/YAV-90304.llb/YAV90304 Info.ctl"/>
				<Item Name="YAV90304 Info.vi" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/YAV-90304.llb/YAV90304 Info.vi"/>
				<Item Name="YAV90304 Init Actions.vi" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/YAV-90304.llb/YAV90304 Init Actions.vi"/>
				<Item Name="YAV90304 Message Dispatcher.vi" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/YAV-90304.llb/YAV90304 Message Dispatcher.vi"/>
				<Item Name="YAV90304 Mode Action.ctl" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/YAV-90304.llb/YAV90304 Mode Action.ctl"/>
				<Item Name="YAV90304 Output Action.vi" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/YAV-90304.llb/YAV90304 Output Action.vi"/>
				<Item Name="YAV90304 Type Action.ctl" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/YAV-90304.llb/YAV90304 Type Action.ctl"/>
				<Item Name="YAV90832 Analog Action.vi" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/YAV-90832.llb/YAV90832 Analog Action.vi"/>
				<Item Name="YAV90832 Info.ctl" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/YAV-90832.llb/YAV90832 Info.ctl"/>
				<Item Name="YAV90832 Info.vi" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/YAV-90832.llb/YAV90832 Info.vi"/>
				<Item Name="YAV90832 Init Actions.vi" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/YAV-90832.llb/YAV90832 Init Actions.vi"/>
				<Item Name="YAV90832 Message Dispatcher.vi" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/YAV-90832.llb/YAV90832 Message Dispatcher.vi"/>
				<Item Name="YAV90832 Mode Action.ctl" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/YAV-90832.llb/YAV90832 Mode Action.ctl"/>
				<Item Name="YAV90832 Relay Action.vi" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/YAV-90832.llb/YAV90832 Relay Action.vi"/>
				<Item Name="YAV90832 Type Action.ctl" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/YAV-90832.llb/YAV90832 Type Action.ctl"/>
				<Item Name="YAV91616 Data Conversor.vi" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/YAV-91616.llb/YAV91616 Data Conversor.vi"/>
				<Item Name="YAV91616 General Action.vi" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/YAV-91616.llb/YAV91616 General Action.vi"/>
				<Item Name="YAV91616 Info.ctl" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/YAV-91616.llb/YAV91616 Info.ctl"/>
				<Item Name="YAV91616 Info.vi" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/YAV-91616.llb/YAV91616 Info.vi"/>
				<Item Name="YAV91616 Init Actions.vi" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/YAV-91616.llb/YAV91616 Init Actions.vi"/>
				<Item Name="YAV91616 Message Dispatcher.vi" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/YAV-91616.llb/YAV91616 Message Dispatcher.vi"/>
				<Item Name="YAV91616 Mode Action.ctl" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/YAV-91616.llb/YAV91616 Mode Action.ctl"/>
				<Item Name="YAV91775 General Relay Action.vi" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/YAV-91775.llb/YAV91775 General Relay Action.vi"/>
				<Item Name="YAV91775 Info.ctl" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/YAV-91775.llb/YAV91775 Info.ctl"/>
				<Item Name="YAV91775 Info.vi" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/YAV-91775.llb/YAV91775 Info.vi"/>
				<Item Name="YAV91775 Init Actions.vi" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/YAV-91775.llb/YAV91775 Init Actions.vi"/>
				<Item Name="YAV91775 Message Dispatcher.vi" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/YAV-91775.llb/YAV91775 Message Dispatcher.vi"/>
				<Item Name="YAV91775 Mode Action.ctl" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/YAV-91775.llb/YAV91775 Mode Action.ctl"/>
				<Item Name="YAV91775 Type Action.ctl" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/YAV-91775.llb/YAV91775 Type Action.ctl"/>
				<Item Name="YAVCANCON Action.ctl" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/YAV-CANCON.llb/YAVCANCON Action.ctl"/>
				<Item Name="YAVCANCON Info.ctl" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/YAV-CANCON.llb/YAVCANCON Info.ctl"/>
				<Item Name="YAVCANCON Info.vi" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/YAV-CANCON.llb/YAVCANCON Info.vi"/>
				<Item Name="YAVCANCON Init Actions.vi" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/YAV-CANCON.llb/YAVCANCON Init Actions.vi"/>
				<Item Name="YAVCANCON Message Dispatcher.vi" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/YAV-CANCON.llb/YAVCANCON Message Dispatcher.vi"/>
				<Item Name="YAVCANCON Send Action.vi" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/YAV-CANCON.llb/YAVCANCON Send Action.vi"/>
				<Item Name="YAVSystem Common Action.ctl" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/YAV-System.llb/YAVSystem Common Action.ctl"/>
				<Item Name="YAVSystem Find Identificator.vi" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/YAV-System.llb/YAVSystem Find Identificator.vi"/>
				<Item Name="YAVSystem Find Slot and Base.vi" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/YAV-System.llb/YAVSystem Find Slot and Base.vi"/>
				<Item Name="YAVSystem General Common Action.vi" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/YAV-System.llb/YAVSystem General Common Action.vi"/>
				<Item Name="YAVSystem Module Transformer.vi" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/YAV-System.llb/YAVSystem Module Transformer.vi"/>
				<Item Name="YAVSystem Slot String Control.vi" Type="VI" URL="/&lt;instrlib&gt;/Phi6/Common/Instrum/Phi6 Core/YAV-System.llb/YAVSystem Slot String Control.vi"/>
			</Item>
			<Item Name="vi.lib" Type="Folder">
				<Item Name="8.6CompatibleGlobalVar.vi" Type="VI" URL="/&lt;vilib&gt;/Utility/config.llb/8.6CompatibleGlobalVar.vi"/>
				<Item Name="_XNET Convert List From Array To Comma.vi" Type="VI" URL="/&lt;vilib&gt;/xnet/xnet.llb/_XNET Convert List From Array To Comma.vi"/>
				<Item Name="_XNET Create Session.vi" Type="VI" URL="/&lt;vilib&gt;/xnet/xnet.llb/_XNET Create Session.vi"/>
				<Item Name="_XNET Split Database Cluster.vi" Type="VI" URL="/&lt;vilib&gt;/xnet/xnet.llb/_XNET Split Database Cluster.vi"/>
				<Item Name="Acquire Semaphore.vi" Type="VI" URL="/&lt;vilib&gt;/Utility/semaphor.llb/Acquire Semaphore.vi"/>
				<Item Name="AddNamedSemaphorePrefix.vi" Type="VI" URL="/&lt;vilib&gt;/Utility/semaphor.llb/AddNamedSemaphorePrefix.vi"/>
				<Item Name="BuildHelpPath.vi" Type="VI" URL="/&lt;vilib&gt;/Utility/error.llb/BuildHelpPath.vi"/>
				<Item Name="CAN Convert Time U64 to LV DBL.vi" Type="VI" URL="/&lt;vilib&gt;/nican/Utilities.llb/CAN Convert Time U64 to LV DBL.vi"/>
				<Item Name="Check if File or Folder Exists.vi" Type="VI" URL="/&lt;vilib&gt;/Utility/libraryn.llb/Check if File or Folder Exists.vi"/>
				<Item Name="Check Special Tags.vi" Type="VI" URL="/&lt;vilib&gt;/Utility/error.llb/Check Special Tags.vi"/>
				<Item Name="Clear Errors.vi" Type="VI" URL="/&lt;vilib&gt;/Utility/error.llb/Clear Errors.vi"/>
				<Item Name="Close Registry Key.vi" Type="VI" URL="/&lt;vilib&gt;/registry/registry.llb/Close Registry Key.vi"/>
				<Item Name="Convert property node font to graphics font.vi" Type="VI" URL="/&lt;vilib&gt;/Utility/error.llb/Convert property node font to graphics font.vi"/>
				<Item Name="Details Display Dialog.vi" Type="VI" URL="/&lt;vilib&gt;/Utility/error.llb/Details Display Dialog.vi"/>
				<Item Name="DialogType.ctl" Type="VI" URL="/&lt;vilib&gt;/Utility/error.llb/DialogType.ctl"/>
				<Item Name="DialogTypeEnum.ctl" Type="VI" URL="/&lt;vilib&gt;/Utility/error.llb/DialogTypeEnum.ctl"/>
				<Item Name="Error Cluster From Error Code.vi" Type="VI" URL="/&lt;vilib&gt;/Utility/error.llb/Error Cluster From Error Code.vi"/>
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
				<Item Name="GetNamedSemaphorePrefix.vi" Type="VI" URL="/&lt;vilib&gt;/Utility/semaphor.llb/GetNamedSemaphorePrefix.vi"/>
				<Item Name="GetRTHostConnectedProp.vi" Type="VI" URL="/&lt;vilib&gt;/Utility/error.llb/GetRTHostConnectedProp.vi"/>
				<Item Name="Longest Line Length in Pixels.vi" Type="VI" URL="/&lt;vilib&gt;/Utility/error.llb/Longest Line Length in Pixels.vi"/>
				<Item Name="LVBoundsTypeDef.ctl" Type="VI" URL="/&lt;vilib&gt;/Utility/miscctls.llb/LVBoundsTypeDef.ctl"/>
				<Item Name="LVRectTypeDef.ctl" Type="VI" URL="/&lt;vilib&gt;/Utility/miscctls.llb/LVRectTypeDef.ctl"/>
				<Item Name="ncAction.vi" Type="VI" URL="/&lt;vilib&gt;/nican/nican.llb/ncAction.vi"/>
				<Item Name="ncClose.vi" Type="VI" URL="/&lt;vilib&gt;/nican/nican.llb/ncClose.vi"/>
				<Item Name="ncConfigCANNet.vi" Type="VI" URL="/&lt;vilib&gt;/nican/nican.llb/ncConfigCANNet.vi"/>
				<Item Name="ncGetAttr.vi" Type="VI" URL="/&lt;vilib&gt;/nican/nican.llb/ncGetAttr.vi"/>
				<Item Name="ncGetTimer.vi" Type="VI" URL="/&lt;vilib&gt;/nican/nican.llb/ncGetTimer.vi"/>
				<Item Name="ncNetAttr.ctl" Type="VI" URL="/&lt;vilib&gt;/nican/nican.llb/ncNetAttr.ctl"/>
				<Item Name="ncOpen.vi" Type="VI" URL="/&lt;vilib&gt;/nican/nican.llb/ncOpen.vi"/>
				<Item Name="ncReadNet.vi" Type="VI" URL="/&lt;vilib&gt;/nican/nican.llb/ncReadNet.vi"/>
				<Item Name="ncWriteNet.vi" Type="VI" URL="/&lt;vilib&gt;/nican/nican.llb/ncWriteNet.vi"/>
				<Item Name="NI_FileType.lvlib" Type="Library" URL="/&lt;vilib&gt;/Utility/lvfile.llb/NI_FileType.lvlib"/>
				<Item Name="NI_LVConfig.lvlib" Type="Library" URL="/&lt;vilib&gt;/Utility/config.llb/NI_LVConfig.lvlib"/>
				<Item Name="NI_PackedLibraryUtility.lvlib" Type="Library" URL="/&lt;vilib&gt;/Utility/LVLibp/NI_PackedLibraryUtility.lvlib"/>
				<Item Name="NI_XML.lvlib" Type="Library" URL="/&lt;vilib&gt;/xml/NI_XML.lvlib"/>
				<Item Name="Not A Semaphore.vi" Type="VI" URL="/&lt;vilib&gt;/Utility/semaphor.llb/Not A Semaphore.vi"/>
				<Item Name="Not Found Dialog.vi" Type="VI" URL="/&lt;vilib&gt;/Utility/error.llb/Not Found Dialog.vi"/>
				<Item Name="Obtain Semaphore Reference.vi" Type="VI" URL="/&lt;vilib&gt;/Utility/semaphor.llb/Obtain Semaphore Reference.vi"/>
				<Item Name="Open Registry Key.vi" Type="VI" URL="/&lt;vilib&gt;/registry/registry.llb/Open Registry Key.vi"/>
				<Item Name="Read Registry Value DWORD.vi" Type="VI" URL="/&lt;vilib&gt;/registry/registry.llb/Read Registry Value DWORD.vi"/>
				<Item Name="Read Registry Value Simple STR.vi" Type="VI" URL="/&lt;vilib&gt;/registry/registry.llb/Read Registry Value Simple STR.vi"/>
				<Item Name="Read Registry Value Simple U32.vi" Type="VI" URL="/&lt;vilib&gt;/registry/registry.llb/Read Registry Value Simple U32.vi"/>
				<Item Name="Read Registry Value Simple.vi" Type="VI" URL="/&lt;vilib&gt;/registry/registry.llb/Read Registry Value Simple.vi"/>
				<Item Name="Read Registry Value STR.vi" Type="VI" URL="/&lt;vilib&gt;/registry/registry.llb/Read Registry Value STR.vi"/>
				<Item Name="Read Registry Value.vi" Type="VI" URL="/&lt;vilib&gt;/registry/registry.llb/Read Registry Value.vi"/>
				<Item Name="Registry Handle Master.vi" Type="VI" URL="/&lt;vilib&gt;/registry/registry.llb/Registry Handle Master.vi"/>
				<Item Name="Registry refnum.ctl" Type="VI" URL="/&lt;vilib&gt;/registry/registry.llb/Registry refnum.ctl"/>
				<Item Name="Registry RtKey.ctl" Type="VI" URL="/&lt;vilib&gt;/registry/registry.llb/Registry RtKey.ctl"/>
				<Item Name="Registry SAM.ctl" Type="VI" URL="/&lt;vilib&gt;/registry/registry.llb/Registry SAM.ctl"/>
				<Item Name="Registry Simplify Data Type.vi" Type="VI" URL="/&lt;vilib&gt;/registry/registry.llb/Registry Simplify Data Type.vi"/>
				<Item Name="Registry View.ctl" Type="VI" URL="/&lt;vilib&gt;/registry/registry.llb/Registry View.ctl"/>
				<Item Name="Registry WinErr-LVErr.vi" Type="VI" URL="/&lt;vilib&gt;/registry/registry.llb/Registry WinErr-LVErr.vi"/>
				<Item Name="Release Semaphore Reference.vi" Type="VI" URL="/&lt;vilib&gt;/Utility/semaphor.llb/Release Semaphore Reference.vi"/>
				<Item Name="Release Semaphore.vi" Type="VI" URL="/&lt;vilib&gt;/Utility/semaphor.llb/Release Semaphore.vi"/>
				<Item Name="RemoveNamedSemaphorePrefix.vi" Type="VI" URL="/&lt;vilib&gt;/Utility/semaphor.llb/RemoveNamedSemaphorePrefix.vi"/>
				<Item Name="Search and Replace Pattern.vi" Type="VI" URL="/&lt;vilib&gt;/Utility/error.llb/Search and Replace Pattern.vi"/>
				<Item Name="Semaphore RefNum" Type="VI" URL="/&lt;vilib&gt;/Utility/semaphor.llb/Semaphore RefNum"/>
				<Item Name="Semaphore Refnum Core.ctl" Type="VI" URL="/&lt;vilib&gt;/Utility/semaphor.llb/Semaphore Refnum Core.ctl"/>
				<Item Name="Set Bold Text.vi" Type="VI" URL="/&lt;vilib&gt;/Utility/error.llb/Set Bold Text.vi"/>
				<Item Name="Set String Value.vi" Type="VI" URL="/&lt;vilib&gt;/Utility/error.llb/Set String Value.vi"/>
				<Item Name="Simple Error Handler.vi" Type="VI" URL="/&lt;vilib&gt;/Utility/error.llb/Simple Error Handler.vi"/>
				<Item Name="Space Constant.vi" Type="VI" URL="/&lt;vilib&gt;/dlg_ctls.llb/Space Constant.vi"/>
				<Item Name="STR_ASCII-Unicode.vi" Type="VI" URL="/&lt;vilib&gt;/registry/registry.llb/STR_ASCII-Unicode.vi"/>
				<Item Name="System Directory Type.ctl" Type="VI" URL="/&lt;vilib&gt;/Utility/sysdir.llb/System Directory Type.ctl"/>
				<Item Name="TagReturnType.ctl" Type="VI" URL="/&lt;vilib&gt;/Utility/error.llb/TagReturnType.ctl"/>
				<Item Name="Three Button Dialog CORE.vi" Type="VI" URL="/&lt;vilib&gt;/Utility/error.llb/Three Button Dialog CORE.vi"/>
				<Item Name="Three Button Dialog.vi" Type="VI" URL="/&lt;vilib&gt;/Utility/error.llb/Three Button Dialog.vi"/>
				<Item Name="Trim Whitespace.vi" Type="VI" URL="/&lt;vilib&gt;/Utility/error.llb/Trim Whitespace.vi"/>
				<Item Name="Validate Semaphore Size.vi" Type="VI" URL="/&lt;vilib&gt;/Utility/semaphor.llb/Validate Semaphore Size.vi"/>
				<Item Name="whitespace.ctl" Type="VI" URL="/&lt;vilib&gt;/Utility/error.llb/whitespace.ctl"/>
				<Item Name="XNET CAN Comm State.ctl" Type="VI" URL="/&lt;vilib&gt;/xnet/xnet.llb/XNET CAN Comm State.ctl"/>
				<Item Name="XNET CAN Comm.ctl" Type="VI" URL="/&lt;vilib&gt;/xnet/xnet.llb/XNET CAN Comm.ctl"/>
				<Item Name="XNET CAN Last Err.ctl" Type="VI" URL="/&lt;vilib&gt;/xnet/xnet.llb/XNET CAN Last Err.ctl"/>
				<Item Name="XNET Clear.vi" Type="VI" URL="/&lt;vilib&gt;/xnet/xnet.llb/XNET Clear.vi"/>
				<Item Name="XNET Create Session (Conversion).vi" Type="VI" URL="/&lt;vilib&gt;/xnet/xnet.llb/XNET Create Session (Conversion).vi"/>
				<Item Name="XNET Create Session (Frame Input Queued).vi" Type="VI" URL="/&lt;vilib&gt;/xnet/xnet.llb/XNET Create Session (Frame Input Queued).vi"/>
				<Item Name="XNET Create Session (Frame Input Single-point).vi" Type="VI" URL="/&lt;vilib&gt;/xnet/xnet.llb/XNET Create Session (Frame Input Single-point).vi"/>
				<Item Name="XNET Create Session (Frame Input Stream).vi" Type="VI" URL="/&lt;vilib&gt;/xnet/xnet.llb/XNET Create Session (Frame Input Stream).vi"/>
				<Item Name="XNET Create Session (Frame Output Queued).vi" Type="VI" URL="/&lt;vilib&gt;/xnet/xnet.llb/XNET Create Session (Frame Output Queued).vi"/>
				<Item Name="XNET Create Session (Frame Output Single-point).vi" Type="VI" URL="/&lt;vilib&gt;/xnet/xnet.llb/XNET Create Session (Frame Output Single-point).vi"/>
				<Item Name="XNET Create Session (Frame Output Stream).vi" Type="VI" URL="/&lt;vilib&gt;/xnet/xnet.llb/XNET Create Session (Frame Output Stream).vi"/>
				<Item Name="XNET Create Session (Generic).vi" Type="VI" URL="/&lt;vilib&gt;/xnet/xnet.llb/XNET Create Session (Generic).vi"/>
				<Item Name="XNET Create Session (PDU Input Queued).vi" Type="VI" URL="/&lt;vilib&gt;/xnet/xnet.llb/XNET Create Session (PDU Input Queued).vi"/>
				<Item Name="XNET Create Session (PDU Input Single-point).vi" Type="VI" URL="/&lt;vilib&gt;/xnet/xnet.llb/XNET Create Session (PDU Input Single-point).vi"/>
				<Item Name="XNET Create Session (PDU Output Queued).vi" Type="VI" URL="/&lt;vilib&gt;/xnet/xnet.llb/XNET Create Session (PDU Output Queued).vi"/>
				<Item Name="XNET Create Session (PDU Output Single-point).vi" Type="VI" URL="/&lt;vilib&gt;/xnet/xnet.llb/XNET Create Session (PDU Output Single-point).vi"/>
				<Item Name="XNET Create Session (Signal Input Single-point).vi" Type="VI" URL="/&lt;vilib&gt;/xnet/xnet.llb/XNET Create Session (Signal Input Single-point).vi"/>
				<Item Name="XNET Create Session (Signal Input Waveform).vi" Type="VI" URL="/&lt;vilib&gt;/xnet/xnet.llb/XNET Create Session (Signal Input Waveform).vi"/>
				<Item Name="XNET Create Session (Signal Input XY).vi" Type="VI" URL="/&lt;vilib&gt;/xnet/xnet.llb/XNET Create Session (Signal Input XY).vi"/>
				<Item Name="XNET Create Session (Signal Output Single-point).vi" Type="VI" URL="/&lt;vilib&gt;/xnet/xnet.llb/XNET Create Session (Signal Output Single-point).vi"/>
				<Item Name="XNET Create Session (Signal Output Waveform).vi" Type="VI" URL="/&lt;vilib&gt;/xnet/xnet.llb/XNET Create Session (Signal Output Waveform).vi"/>
				<Item Name="XNET Create Session (Signal Output XY).vi" Type="VI" URL="/&lt;vilib&gt;/xnet/xnet.llb/XNET Create Session (Signal Output XY).vi"/>
				<Item Name="XNET Create Session.vi" Type="VI" URL="/&lt;vilib&gt;/xnet/xnet.llb/XNET Create Session.vi"/>
				<Item Name="XNET Fill In Error Info.vi" Type="VI" URL="/&lt;vilib&gt;/xnet/xnet.llb/XNET Fill In Error Info.vi"/>
				<Item Name="XNET FlexRay Comm.ctl" Type="VI" URL="/&lt;vilib&gt;/xnet/xnet.llb/XNET FlexRay Comm.ctl"/>
				<Item Name="XNET FlexRay POC State.ctl" Type="VI" URL="/&lt;vilib&gt;/xnet/xnet.llb/XNET FlexRay POC State.ctl"/>
				<Item Name="XNET FlexRay Stats.ctl" Type="VI" URL="/&lt;vilib&gt;/xnet/xnet.llb/XNET FlexRay Stats.ctl"/>
				<Item Name="XNET Frame CAN.ctl" Type="VI" URL="/&lt;vilib&gt;/xnet/xnet.llb/XNET Frame CAN.ctl"/>
				<Item Name="XNET Frame Ethernet.ctl" Type="VI" URL="/&lt;vilib&gt;/xnet/xnet.llb/XNET Frame Ethernet.ctl"/>
				<Item Name="XNET Frame FlexRay.ctl" Type="VI" URL="/&lt;vilib&gt;/xnet/xnet.llb/XNET Frame FlexRay.ctl"/>
				<Item Name="XNET Frame LIN.ctl" Type="VI" URL="/&lt;vilib&gt;/xnet/xnet.llb/XNET Frame LIN.ctl"/>
				<Item Name="XNET Frame Type CAN.ctl" Type="VI" URL="/&lt;vilib&gt;/xnet/xnet.llb/XNET Frame Type CAN.ctl"/>
				<Item Name="XNET Frame Type Ethernet.ctl" Type="VI" URL="/&lt;vilib&gt;/xnet/xnet.llb/XNET Frame Type Ethernet.ctl"/>
				<Item Name="XNET Frame Type FlexRay.ctl" Type="VI" URL="/&lt;vilib&gt;/xnet/xnet.llb/XNET Frame Type FlexRay.ctl"/>
				<Item Name="XNET Frame Type LIN.ctl" Type="VI" URL="/&lt;vilib&gt;/xnet/xnet.llb/XNET Frame Type LIN.ctl"/>
				<Item Name="XNET J1939 Comm.ctl" Type="VI" URL="/&lt;vilib&gt;/xnet/xnet.llb/XNET J1939 Comm.ctl"/>
				<Item Name="XNET LIN Comm State.ctl" Type="VI" URL="/&lt;vilib&gt;/xnet/xnet.llb/XNET LIN Comm State.ctl"/>
				<Item Name="XNET LIN Comm.ctl" Type="VI" URL="/&lt;vilib&gt;/xnet/xnet.llb/XNET LIN Comm.ctl"/>
				<Item Name="XNET LIN Diag Schedule Type.ctl" Type="VI" URL="/&lt;vilib&gt;/xnet/xnet.llb/XNET LIN Diag Schedule Type.ctl"/>
				<Item Name="XNET LIN Last Err.ctl" Type="VI" URL="/&lt;vilib&gt;/xnet/xnet.llb/XNET LIN Last Err.ctl"/>
				<Item Name="XNET Mode.ctl" Type="VI" URL="/&lt;vilib&gt;/xnet/xnet.llb/XNET Mode.ctl"/>
				<Item Name="XNET Read (Frame CAN).vi" Type="VI" URL="/&lt;vilib&gt;/xnet/xnet.llb/XNET Read (Frame CAN).vi"/>
				<Item Name="XNET Read (Frame Ethernet).vi" Type="VI" URL="/&lt;vilib&gt;/xnet/xnet.llb/XNET Read (Frame Ethernet).vi"/>
				<Item Name="XNET Read (Frame FlexRay).vi" Type="VI" URL="/&lt;vilib&gt;/xnet/xnet.llb/XNET Read (Frame FlexRay).vi"/>
				<Item Name="XNET Read (Frame LIN).vi" Type="VI" URL="/&lt;vilib&gt;/xnet/xnet.llb/XNET Read (Frame LIN).vi"/>
				<Item Name="XNET Read (Frame Raw).vi" Type="VI" URL="/&lt;vilib&gt;/xnet/xnet.llb/XNET Read (Frame Raw).vi"/>
				<Item Name="XNET Read (Signal Single-point).vi" Type="VI" URL="/&lt;vilib&gt;/xnet/xnet.llb/XNET Read (Signal Single-point).vi"/>
				<Item Name="XNET Read (Signal Waveform) .vi" Type="VI" URL="/&lt;vilib&gt;/xnet/xnet.llb/XNET Read (Signal Waveform) .vi"/>
				<Item Name="XNET Read (Signal XY).vi" Type="VI" URL="/&lt;vilib&gt;/xnet/xnet.llb/XNET Read (Signal XY).vi"/>
				<Item Name="XNET Read (State CAN Comm).vi" Type="VI" URL="/&lt;vilib&gt;/xnet/xnet.llb/XNET Read (State CAN Comm).vi"/>
				<Item Name="XNET Read (State FlexRay Comm).vi" Type="VI" URL="/&lt;vilib&gt;/xnet/xnet.llb/XNET Read (State FlexRay Comm).vi"/>
				<Item Name="XNET Read (State FlexRay Cycle Macrotick).vi" Type="VI" URL="/&lt;vilib&gt;/xnet/xnet.llb/XNET Read (State FlexRay Cycle Macrotick).vi"/>
				<Item Name="XNET Read (State FlexRay Stats).vi" Type="VI" URL="/&lt;vilib&gt;/xnet/xnet.llb/XNET Read (State FlexRay Stats).vi"/>
				<Item Name="XNET Read (State J1939 Comm).vi" Type="VI" URL="/&lt;vilib&gt;/xnet/xnet.llb/XNET Read (State J1939 Comm).vi"/>
				<Item Name="XNET Read (State LIN Comm).vi" Type="VI" URL="/&lt;vilib&gt;/xnet/xnet.llb/XNET Read (State LIN Comm).vi"/>
				<Item Name="XNET Read (State Session Info).vi" Type="VI" URL="/&lt;vilib&gt;/xnet/xnet.llb/XNET Read (State Session Info).vi"/>
				<Item Name="XNET Read (State Time Comm).vi" Type="VI" URL="/&lt;vilib&gt;/xnet/xnet.llb/XNET Read (State Time Comm).vi"/>
				<Item Name="XNET Read (State Time Current).vi" Type="VI" URL="/&lt;vilib&gt;/xnet/xnet.llb/XNET Read (State Time Current).vi"/>
				<Item Name="XNET Read (State Time Start).vi" Type="VI" URL="/&lt;vilib&gt;/xnet/xnet.llb/XNET Read (State Time Start).vi"/>
				<Item Name="XNET Read (State Time Trigger).vi" Type="VI" URL="/&lt;vilib&gt;/xnet/xnet.llb/XNET Read (State Time Trigger).vi"/>
				<Item Name="XNET Read.vi" Type="VI" URL="/&lt;vilib&gt;/xnet/xnet.llb/XNET Read.vi"/>
				<Item Name="XNET Session Info State.ctl" Type="VI" URL="/&lt;vilib&gt;/xnet/xnet.llb/XNET Session Info State.ctl"/>
				<Item Name="XNET String To IO Name (Cluster).vi" Type="VI" URL="/&lt;vilib&gt;/xnet/xnet.llb/XNET String To IO Name (Cluster).vi"/>
				<Item Name="XNET String To IO Name (Database Alias).vi" Type="VI" URL="/&lt;vilib&gt;/xnet/xnet.llb/XNET String To IO Name (Database Alias).vi"/>
				<Item Name="XNET String To IO Name (Database Filepath).vi" Type="VI" URL="/&lt;vilib&gt;/xnet/xnet.llb/XNET String To IO Name (Database Filepath).vi"/>
				<Item Name="XNET String To IO Name (ECU).vi" Type="VI" URL="/&lt;vilib&gt;/xnet/xnet.llb/XNET String To IO Name (ECU).vi"/>
				<Item Name="XNET String To IO Name (Frame).vi" Type="VI" URL="/&lt;vilib&gt;/xnet/xnet.llb/XNET String To IO Name (Frame).vi"/>
				<Item Name="XNET String To IO Name (Interface).vi" Type="VI" URL="/&lt;vilib&gt;/xnet/xnet.llb/XNET String To IO Name (Interface).vi"/>
				<Item Name="XNET String To IO Name (LIN Schedule Entry).vi" Type="VI" URL="/&lt;vilib&gt;/xnet/xnet.llb/XNET String To IO Name (LIN Schedule Entry).vi"/>
				<Item Name="XNET String To IO Name (LIN Schedule).vi" Type="VI" URL="/&lt;vilib&gt;/xnet/xnet.llb/XNET String To IO Name (LIN Schedule).vi"/>
				<Item Name="XNET String To IO Name (PDU).vi" Type="VI" URL="/&lt;vilib&gt;/xnet/xnet.llb/XNET String To IO Name (PDU).vi"/>
				<Item Name="XNET String To IO Name (Session).vi" Type="VI" URL="/&lt;vilib&gt;/xnet/xnet.llb/XNET String To IO Name (Session).vi"/>
				<Item Name="XNET String To IO Name (Signal).vi" Type="VI" URL="/&lt;vilib&gt;/xnet/xnet.llb/XNET String To IO Name (Signal).vi"/>
				<Item Name="XNET String To IO Name (Subframe).vi" Type="VI" URL="/&lt;vilib&gt;/xnet/xnet.llb/XNET String To IO Name (Subframe).vi"/>
				<Item Name="XNET String To IO Name.vi" Type="VI" URL="/&lt;vilib&gt;/xnet/xnet.llb/XNET String To IO Name.vi"/>
				<Item Name="XNET Write (Frame CAN).vi" Type="VI" URL="/&lt;vilib&gt;/xnet/xnet.llb/XNET Write (Frame CAN).vi"/>
				<Item Name="XNET Write (Frame Ethernet).vi" Type="VI" URL="/&lt;vilib&gt;/xnet/xnet.llb/XNET Write (Frame Ethernet).vi"/>
				<Item Name="XNET Write (Frame FlexRay).vi" Type="VI" URL="/&lt;vilib&gt;/xnet/xnet.llb/XNET Write (Frame FlexRay).vi"/>
				<Item Name="XNET Write (Frame LIN).vi" Type="VI" URL="/&lt;vilib&gt;/xnet/xnet.llb/XNET Write (Frame LIN).vi"/>
				<Item Name="XNET Write (Frame Raw).vi" Type="VI" URL="/&lt;vilib&gt;/xnet/xnet.llb/XNET Write (Frame Raw).vi"/>
				<Item Name="XNET Write (Signal Single-point).vi" Type="VI" URL="/&lt;vilib&gt;/xnet/xnet.llb/XNET Write (Signal Single-point).vi"/>
				<Item Name="XNET Write (Signal Waveform) .vi" Type="VI" URL="/&lt;vilib&gt;/xnet/xnet.llb/XNET Write (Signal Waveform) .vi"/>
				<Item Name="XNET Write (Signal XY).vi" Type="VI" URL="/&lt;vilib&gt;/xnet/xnet.llb/XNET Write (Signal XY).vi"/>
				<Item Name="XNET Write (State FlexRay Symbol).vi" Type="VI" URL="/&lt;vilib&gt;/xnet/xnet.llb/XNET Write (State FlexRay Symbol).vi"/>
				<Item Name="XNET Write (State LIN Diagnostic Schedule Change).vi" Type="VI" URL="/&lt;vilib&gt;/xnet/xnet.llb/XNET Write (State LIN Diagnostic Schedule Change).vi"/>
				<Item Name="XNET Write (State LIN Schedule Change).vi" Type="VI" URL="/&lt;vilib&gt;/xnet/xnet.llb/XNET Write (State LIN Schedule Change).vi"/>
				<Item Name="XNET Write.vi" Type="VI" URL="/&lt;vilib&gt;/xnet/xnet.llb/XNET Write.vi"/>
				<Item Name="xobjhandle.ctl" Type="VI" URL="/&lt;vilib&gt;/nican/nican.llb/xobjhandle.ctl"/>
			</Item>
			<Item Name="Advapi32.dll" Type="Document" URL="Advapi32.dll">
				<Property Name="NI.PreserveRelativePath" Type="Bool">true</Property>
			</Item>
			<Item Name="DOMUserDefRef.dll" Type="Document" URL="DOMUserDefRef.dll">
				<Property Name="NI.PreserveRelativePath" Type="Bool">true</Property>
			</Item>
			<Item Name="kernel32.dll" Type="Document" URL="kernel32.dll">
				<Property Name="NI.PreserveRelativePath" Type="Bool">true</Property>
			</Item>
			<Item Name="ncvi.dll" Type="Document" URL="ncvi.dll">
				<Property Name="NI.PreserveRelativePath" Type="Bool">true</Property>
			</Item>
			<Item Name="nican.dll" Type="Document" URL="nican.dll">
				<Property Name="NI.PreserveRelativePath" Type="Bool">true</Property>
			</Item>
			<Item Name="nixlvapi.dll" Type="Document" URL="nixlvapi.dll">
				<Property Name="NI.PreserveRelativePath" Type="Bool">true</Property>
			</Item>
			<Item Name="System.ServiceProcess" Type="Document" URL="System.ServiceProcess">
				<Property Name="NI.PreserveRelativePath" Type="Bool">true</Property>
			</Item>
		</Item>
		<Item Name="Build Specifications" Type="Build"/>
	</Item>
</Project>
