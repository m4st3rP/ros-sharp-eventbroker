using System.Collections.Generic;
using RosSharp.RosBridgeClient;
using ROS = RosSharp.RosBridgeClient.MessageTypes.Std;

namespace EventBrokerNameSpace {

    /**
     * Subscribes to a Topic and redirects the messages of these to registered subscribers
     */
    public class EventSubscribeForwarder : UnitySubscriber<ROS.String> {
        private readonly Dictionary<string, HashSet<IEventSubscriber>> msgSubDict = new Dictionary<string, HashSet<IEventSubscriber>>();

        private void Awake() {
            Topic = "";
            TimeStep = 1;
        }

        /**
         * Gets called when there is a message on its topic and redirects them to registered subscribers
         */
        protected override void ReceiveMessage(ROS.String message) {
            print("Received message: " + message.data + "on topic: " + Topic);

            if (!msgSubDict.ContainsKey(message.data)) return;
            foreach (var sub in msgSubDict[message.data]) sub.OnSubscribedMessage(Topic, message.data);
            //print("Got message " + message.data);
        }

        /**
         * Registers a subscriber to the topic and a message within this topic
         */
        public void RegisterSubscriber(string msg, IEventSubscriber sub) {
            print("Registering subscriber on topic: " + Topic + " and message: " + msg);

            if (!msgSubDict.ContainsKey(msg)) msgSubDict[msg] = new HashSet<IEventSubscriber>();

            msgSubDict[msg].Add(sub);
        }
    }
}