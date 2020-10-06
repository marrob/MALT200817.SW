namespace MALT200817.Explorer.Events
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;

    [TestClass()]
    public class UnitTest_EventAggregator
    {

        [TestMethod()]
        public void _0001_SubscribeModel()
        {
            EventAggregator ea = new EventAggregator();
            ea.Subscribe((Action<MocAppEvent>)(e => { Console.WriteLine(e.Message); }));
        }

        [TestMethod()]
        public void _0002_SubscribeMode()
        {
            EventAggregator ea = new EventAggregator();
            Action<MocAppEvent> fucDel = (e) =>
            {
                Console.WriteLine(e.Message);
            };
            ea.Subscribe(fucDel);
        }

        [TestMethod()]
        public void _0003_SubscribeModel()
        {
            EventAggregator ea = new EventAggregator();
            ea.Subscribe((Action<MocAppEvent>)MocShowMessage);
        }

        [TestMethod()]
        public void _0004_SubscribePublishEvent()
        {
            EventAggregator ea = new EventAggregator();
            bool isFired = false;
            ea.Subscribe((Action<MocAppEvent>)(e => { isFired = true; }));
            ea.Publish(new MocAppEvent("Test"));
            Assert.IsTrue(isFired);
        }

        [TestMethod()]
        public void _0005_SubscribePublishEvent()
        {
            //EventAggregator ea = new EventAggregator();
            //bool isFired = false;
            //ea.Subscribe(Action<MocAppEvent>)(e => { isFired = true; }));
            //ea.Publish(new MocAppEvent("Test"));
            //Assert.IsTrue(isFired);
        }
        [TestMethod()]
        public void _0006_MultipleSubscribe()
        {
            EventAggregator ea = new EventAggregator();
            int i = 0;
            ea.Subscribe((Action<MocAppEvent>)(e => { i++; }));
            ea.Subscribe((Action<MocAppEvent>)(e => { i++; }));
            ea.Subscribe((Action<MocAppEvent>)(e => { i++; }));
            ea.Publish(new MocAppEvent("Increment"));
            Assert.AreEqual(3, i);
        }

        [TestMethod()]
        public void _0007_SubscribePublishAsyncEvent()
        {
            EventAggregator ea = new EventAggregator();
            bool isFired = false;
            ea.Subscribe((Action<MocAppEvent>)(e => { isFired = true; }));
            int thId = 0;

            Action action = () =>
            {
                ea.Publish(new MocAppEvent("Test"));
                thId = System.Threading.Thread.CurrentThread.ManagedThreadId;
            };

            IAsyncResult iftAR = action.BeginInvoke(null, null);
            action.EndInvoke(iftAR);

            Assert.IsTrue(isFired);
            Assert.AreNotEqual(System.Threading.Thread.CurrentThread.ManagedThreadId, thId);
        }

        [TestMethod()]
        public void _0008_Unsubscribe()
        {
            EventAggregator ea = new EventAggregator();
            bool isFired = false;
            Action<MocAppEvent> fucDel = (e) => { isFired = true; };

            ea.Subscribe(fucDel);
            ea.Publish(new MocAppEvent("Test"));
            Assert.IsTrue(isFired);

            isFired = false;
            ea.Unsubscribe(fucDel);
            ea.Publish(new MocAppEvent("Test"));
            Assert.IsFalse(isFired);
        }

        void MocShowMessage(MocAppEvent e)
        {
            Console.WriteLine(e.Message);
        }

        class MocAppEvent : IApplicationEvent
        {
            public MocAppEvent(string message)
            {
                Message = message;
            }
            public string Message { get; private set; }
        }
    }
}
