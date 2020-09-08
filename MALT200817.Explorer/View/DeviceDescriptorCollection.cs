using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MALT200817.Explorer.View
{
    public class Library
    {
        public static DeviceDescriptorCollection Descriptors { get; private set; }

        static Library()
        {
            Descriptors = new DeviceDescriptorCollection();
            Descriptors.Add(new DescriptorItem()
            {

                CardTypeName = "MALT132",
                CardType = 0x03,
                Options = 0x00,
                FirstName = "MALT132",
                Components = new ComponentCollection() { 
                    new ComponentItem()
                    { 
                        Type = ComponetType.RELAY_SPDT,
                        Port = 0,
                        RelayLabel = "K1",
                        PinLabel_COM = "36",
                        PinLabel_NC = "3",
                        PinLabel_NO = "67"
                    },
                    new ComponentItem()
                    {
                        Type = ComponetType.RELAY_SPDT,
                        Port = 1,
                        RelayLabel = "K2",
                        PinLabel_COM = "37",
                        PinLabel_NC = "4",
                        PinLabel_NO = "68"
                    },       
                    new ComponentItem()
                    {
                        Type = ComponetType.RELAY_SPDT,
                        Port = 2,
                        RelayLabel = "K3",
                        PinLabel_COM = "38",
                        PinLabel_NC = "5",
                        PinLabel_NO = "69"
                    },            
                    new ComponentItem()
                    {
                        Type = ComponetType.RELAY_SPDT,
                        Port = 3,
                        RelayLabel = "K4",
                        PinLabel_COM = "39",
                        PinLabel_NC = "6",
                        PinLabel_NO = "70"
                    }
                },
            });

            Descriptors.Add(new DescriptorItem()
            {
                CardTypeName = "MALT132",
                CardType = 0x03,
                Options = 0x01,
                FirstName = "MALT23HVT",
                Components = new ComponentCollection() {
                    new ComponentItem()
                    {
                        Type = ComponetType.RELAY_SPST,
                        Port = 0,
                        RelayLabel = "K1",
                        PinLabel_COM = "PI1",
                        PinLabel_NO = "PO1"
                    },
                    new ComponentItem()
                    {
                        Type = ComponetType.RELAY_SPST,
                        Port = 1,
                        RelayLabel = "K2",
                        PinLabel_COM = "PI1",
                        PinLabel_NO = "PO2"
                    },                
                    new ComponentItem()
                    {
                        Type = ComponetType.RELAY_SPST,
                        Port = 2,
                        RelayLabel = "K3",
                        PinLabel_COM = "PI2",
                        PinLabel_NO = "PO1"
                    },
                }

            });

            Descriptors.Add(new DescriptorItem()
            {
                CardTypeName = "MALT160T",
                CardType = 0x15,
                Options = 0x05,
                FirstName = "MALT160T",
                Components = new ComponentCollection() {
                    new ComponentItem()
                    {
                        Type = ComponetType.RELAY_SPST,
                        Port = 0,
                        RelayLabel = "K1",
                        PinLabel_COM = "COM1",
                        PinLabel_NO = "A-BUS"
                    },
                    new ComponentItem()
                    {
                        Type = ComponetType.RELAY_SPST,
                        Port = 1,
                        RelayLabel = "K2",
                        PinLabel_COM = "COM2",
                        PinLabel_NO = "A-BUS"
                    },
                    new ComponentItem()
                    {
                        Type = ComponetType.RELAY_SPST,
                        Port = 2,
                        RelayLabel = "K3",
                        PinLabel_COM = "COM1",
                        PinLabel_NO = "A-BUS"
                    },
                }

            });

        }

    }

    public class DeviceDescriptorCollection:BindingList<DescriptorItem>
    {
        
    
        public DescriptorItem Search(int familyCode, int optionCode)
        {
            var retval = Library.Descriptors.FirstOrDefault(n => n.CardType == familyCode && n.Options == optionCode);
            return retval;
        }

      

    }








}
