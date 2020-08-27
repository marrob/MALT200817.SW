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
		<Item Name="GetDevices.vi" Type="VI" URL="../GetDevices.vi"/>
		<Item Name="RelayOnOff.vi" Type="VI" URL="../RelayOnOff.vi"/>
		<Item Name="ResponseTimeTest.vi" Type="VI" URL="../ResponseTimeTest.vi"/>
		<Item Name="TcpWriteRead.vi" Type="VI" URL="../TcpWriteRead.vi"/>
		<Item Name="UserInterfaceEventPattern 1.vi" Type="VI" URL="../UserInterfaceEventPattern 1.vi"/>
		<Item Name="Dependencies" Type="Dependencies"/>
		<Item Name="Build Specifications" Type="Build"/>
	</Item>
</Project>
