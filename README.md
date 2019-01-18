# sweet-text

### Table of Contents
**[Installation](#useage)**<br>
**[Useage](#useage)**<br>
**[Contributing](#contributing)**<br>


## Installation

## Usage

Register an account with Twilio and modify the app.config
```csharp
<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <appSettings>
    <add key="TimeUntilNextSentMessageInMS" value="5000" />
    <add key="PathToSweetMessages" value="C:/Users/Messages.json" />
    <add key="TwilioAccountSID" value="" />
    <add key="TwilioAuthToken" value="" />
    <!--Prepend with +1, and ensure to add a Verified Caller ID on twilio. This is given by Twilio-->
    <add key="TwilioFromPhoneNumber" value="" />
    <!--Prepend with +1, and ensure to add a Verified Caller ID on twilio-->
    <add key="TwilioToPhoneNumber" value="" />
    <!--Prepend with +1, and ensure to add a Verified Caller ID on twilio. This is the number that is reached when there are no more messages to send.-->
    <add key="TwilioToPhoneNumberEmpty" value="" />
     </appSettings>
</configuration>
```
The PathToSweetMessages setting should be a .json file that contains the messages.
```csharp
['message1','message2']
```


## Contributing

Pull requests are welcome. 

For large changes, please open an issue first to discuss what you would like to add.
