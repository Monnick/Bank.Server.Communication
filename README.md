# Overview
An EBICS server for simulating bank communication. For more information on EBICS standard: [http://www.ebics.org/home-page/](http://www.ebics.org/home-page/)   
The payment files will be accepted by an ASP.Net server. An EBICS handler will be created via dependency injection, which delegates the version selection (H002, H003 and H004). Afterwards the request will be forwarded to an EBICS worker, which creates the usable object based on XML serialization. Before the data is stored, it has to be checked whether it is valid or not. At the end, the request will generate an answer for the client.

## Layers within this service
Within this service, multiple layers are created to seperate the different business meanings (i.e. a database is much more basic data handler than a ASP.Net controller, which is more about validation). This service uses 4 layers with each layer represented with a contract project.
* Service: The communication service   
* Application: Delegates to the needed lower areas (i.e. data validation or data storage)   
* Domain: Handles the delegation the the infrastrucutre (i.e. which validation is needed?)   
* Infrastructure: Represents the basic data access to a storage or the EBICS version srialization   

Each layer contains at least 2 projects. A contract project to expose the interfaces and public needed value objects. The other project is a the conrete implementation of this layer. Both projects should never reference a concrete implementation.   
ATTENTION: By now, the Domain references to the Infrastructure until a better solution is found!

## Dependency injection
The service uses dependency injection to request objects and starts their methods. The user or a programmer can decide which classes are used via the appsettings file. The server has a basic implementation and does not need a fully configured dependency injection to run. But via the appsettings, the standard modules can be replaced.

## Word pool
This projects uses some selected words to identify certain steps, methods and objects. The wording is partly defined by external sources (i.e. EBICS standard) and partly defined in the documentation of this project. Once a word is selected to describe something it has to be used (i.e. an activity can also be described as process, method, action etc.).
1. External defined names: Mainly defined by the EBICS standard. If a standard or law defines something, its explicit name has to be used. I.e. the request to transfer a payment is called 'EbicsRequest' by the EBICS standard, it is not called 'PaymentRequest' or 'PaymentTransaction'. Therefor the class and referencing objects are also to be called 'EbicsRequest'.
2. Following word has been decided:
* 'Transaction': A single transmittion object of data from or towards the client (i.e. payment transfer or receiving a bank to customer statement). Not the data chunk, the complete data object to transfer.
* 'Nonce': A cryptographic value which is forbidden to be repeated within a certain timespan.
* 'EbicsActivity': A http request from the client to this server to start an activity. This http request has to be a valid ebics message and the concrete type will be determinte at a later processing step. An EbicsRequest is an EbicsActivity but the header data of this request is not.
* 'InitialHeader': The selected properties from an ebics request, which will only be filled during the ebics request during a complete communication.
* 'UserIdentificator': The combination of properties to identify an user (host, partner and user name).
