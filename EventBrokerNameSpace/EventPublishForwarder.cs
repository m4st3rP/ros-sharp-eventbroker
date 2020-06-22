using RosSharp.RosBridgeClient;
using ROS = RosSharp.RosBridgeClient.MessageTypes.Std;

namespace EventBrokerNameSpace {

    /**
     * A publisher that publishes a message on its topic
     */
    public class EventPublishForwarder : UnityPublisher<ROS.String> {
        private void Awake() {
            Topic = "";
        }

        /**
         * Sets the topic of the EventPublishForwarder
         * @string topic The new topic of the EventPublishForwarder
         */
        public void setTopic(string topic) {
            Topic = topic;
            Start();
        }

        /**
         * Publishes a message to the topic of the EventPublisher
         * @string msg The message that is going to be published to the topic 
         */
        public void PublishMessage(string msg) {
            print("Publishing msg: " + msg + " on topic: " + Topic + "...");
            Publish(new ROS.String(msg));
            print("Successfully published!");
        }
    }
}