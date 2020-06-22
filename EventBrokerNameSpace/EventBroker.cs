using UnityEngine;

namespace EventBrokerNameSpace {

    /**
     * Brokers subscriptions to ROS message channels for objects that implement the IEventSubscriber interface and publishes to ROS for every object
     */
    public class EventBroker : MonoBehaviour {
        
        /**
         * Returns the EventBroker object
         * You need to change the parentComponent string to the name of the component the EventBroker script is attached to
         */
        public static EventBroker GetEventBroker() {
            const string parentComponent = "ParentComponentName";
            return GameObject.Find(parentComponent).GetComponent<EventBroker>();
        }

        /**
         * Subscribes the IEventSubscriber to a topic and a message
         * @string topic The topic that the IEventSubscriber is going to be subscribed to
         * @string msg The message within the topic that the IEventSubscriber is going to be subscribed to
         * @IEventSubscriber sub The subscriber that gets subscribed to topic and message
         */
        public void SubscribeToTopicAndMessage(string topic, string msg, IEventSubscriber sub) {
            // search EventSubscribeForwarder by topic and register IEventSubscriber to message
            foreach (var esf in gameObject.GetComponents<EventSubscribeForwarder>()) {
                if (esf.Topic != topic) continue;
                esf.RegisterSubscriber(msg, sub);
                return;
            }

            // if an EventSubscribeForwarder could not be found create a new one with the given topic subscribe the subscriber to the msg within the topic
            var newEs = gameObject.AddComponent<EventSubscribeForwarder>();
            newEs.Topic = topic;
            newEs.RegisterSubscriber(msg, sub);
        }

        /**
         * Publishes a message to a topic
         * @string topic The topic the message is going to be published to
         * @string msg The message is that going to be published
         */
        public void PublishMessageToTopic(string topic, string msg) {
            // search EventPublishForwarder by topic and publish message with it
            foreach (var epf in gameObject.GetComponents<EventPublishForwarder>()) {
                if (epf.Topic != topic) continue;
                epf.PublishMessage(msg);
                return;
            }

            // if an EventPublishForwarder could not be found create a new one with the given topic and publish the message with it
            var newEp = gameObject.AddComponent<EventPublishForwarder>();
            newEp.setTopic(topic);
            newEp.PublishMessage(msg);
        }
    }
}