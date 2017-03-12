# Bank.Communication.Application
This project is devided into two areas:   
1. EbicsHandler: Accepts the http request stream and returns the response data as a stream.   
2. EbicsWorker: Accepts an EbicsActivity specified to the concrete implementation and handles the relevant steps (i.e. starting the validation and requesting the result data).   

## EbicsHandler
The EbicsHandler accepts a data stream sent from the client. Following steps of are handled:   
1. Transform the data stream to an ebics activity by using the schema selector.   
2. Identify and request the correllating worker class for the resolved ebics activity.   
3. Start submit the ebics activity to the worker.   
4. Fetching the result from the worker and returning it as an answer to the client.   

## EbicsWorker
The EbicsWorker accepts an EbicsActivity and contains the logic to start the validation and process the orders within the ebics request. The interface forces a concrete definition which ebics activity can be handled and the implemented worker will be identified by it.   
Be defining the concrete ebics activity, the worker knows which validation has to be done, when the activity can be stored and when the result can be fetched from the activity.   
Attention: Be aware the ebics activity generates the answer, because this class is the only place to hold the version information.
