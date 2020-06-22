# ros-sharp-eventbroker
This is an eventbroker that allows Unity components to publish and subscribe strings to and from ROS via ROS#.
To subscribe a component has to implement the IEventSubscriber interface.

How to publish a message:
```C#
var eventBroker = EventBroker.GetEventBroker();
eventBroker.PublishToTopic("topic", "message");
```

How to subscribe to a message:
```C#
public class UnityComponent : IEventSubscriber {

...

var eventBroker = EventBroker.GetEventBroker();
eventBroker.SubscribeToTopicAndMessage("topic", "message", this);

...

public void onSubscribedMessage(string topic, string msg) {
    if (topic.Equals("topic")) {
        if (msg.Equals("message")) {
            doThing();
        }
    }
}
```
