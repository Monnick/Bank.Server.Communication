# Bank.Communication.Domain
This project contains the infrastructure delegation. This project introduces a storage privder, the schema selector and a validator:   
1. 'StorageProvicer': The storage provider delegates the access to the storage for persiting data or validate against stored data.   
2. 'SchemaSelector': Reads the first characters of the request data and chooses the used EBICS schema (H002, H003 or H004).   
3. 'RequestValidator': Manages the validation process and selects which parts can or should be validated.   

## StorageProvider
This class contains three storages (administration, nonce and transaction) and manages the access to them. When the RequestValidator starts the validation of a transaction id, the storage provider selects the correct storage depending on its internal configuration. Following methods are exposed:   
1. 'StoreRequest': Stores the data to the transaction storage.   
2. 'ValidateTransaction': Validates the transaction internal data (i.e. transaction id).   
3. 'ValidateRequestHeader': Validates the ebics request header data (i.e. for continuing transactions).   
4. 'ValidateInitialHeader': Validates the initial request header with host, parnter, order id and more properties.   
5. 'AddNonce': Stores the nonce of the ebics activity.   

The storage provider only contains methods to store requet data and nonces. The bank and user data can not be changed by this class by design! The creation and administration of bank data will be implemented in a different project with no access to this sources for security reasons.   

## RequestValidator
The RequestValidator selects which data has to be validated and which general combination of objects within a request is valid.
