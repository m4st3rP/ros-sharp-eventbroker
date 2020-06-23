# ros-sharp-eventbroker
This is an eventbroker that allows Unity components to publish and subscribe strings to and from ROS via ROS#.

1. Add the EventBroker script as a component to a Unity component
2. Change the parentComponent string in the GetEventBroker method to the name of the component you added the EventBroker script to
3. Get the EventBroker in your code with the GetEventBroker method
4. Publish with the PublishMessageToTopic method
5. Subscribe with the SubscribeToTopicAndMessage method; your object needs to implement the IEventSubscriber interface to do so.

How to publish a message:
```C#
var eventBroker = EventBroker.GetEventBroker();
eventBroker.PublishMessageToTopic("topic", "message");
```

How to subscribe to a message:
```C#
public class UnityComponent : IEventSubscriber {

...

var eventBroker = EventBroker.GetEventBroker();
eventBroker.SubscribeToTopicAndMessage("topic", "message", this);

...

public void OnSubscribedMessage(string topic, string msg) {
    if (topic.Equals("topic")) {
        if (msg.Equals("message")) {
            doThing();
        }
    }
}
```
