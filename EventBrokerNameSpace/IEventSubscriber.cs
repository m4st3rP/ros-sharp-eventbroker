namespace EventBrokerNameSpace {

    /**
     * Interface for objects that want to subscribe to a ROS message via the EventBroker
     */
    public interface IEventSubscriber {
        
        /**
         * The action the subscriber is doing on receiving the topic and message it subscribed to
         * @string topic The topic the subscriber subscribed to
         * @string msg The message within the topic the subscriber subscribed to
         */
        void OnSubscribedMessage(string topic, string msg);
    }
}