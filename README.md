# CsvDemo
An example RESTful API with .NET 6.0

Exercise converting from one CSV format to another.

## Steps to run the app(you should have installed net 6 environment previously)
* In the folder `CsvDemo` run the following command `dotnet run`, this command will make the endpoint available for testing the application.

Public endpoints require no Authentication.

* Makes a conversion : `POST https://localhost:7286/DocumentDemo`


## Json format example to try the conversion.

```json
{
    "body": "\"Patient Name\", \"SSN\", \"Age\", \"Phone Number\", \"Status\" \"Prescott, Zeke\", \"542-51-6641\", \"21\", \"801-555-2134\",\"Opratory=2,PCP=1\", \"Goldstein, Bucky\",\"635-45-1254\", \"42\",\"435-555-1541\", \"Opratory=1, PCP=1\", \"Vox, Bono\", \"414-45-1475\", \"51\", \"801-555-2100\", \"Opratory=3, PCP=2\""
}
```

## Author

**Ariel Ruiz**

* [github.com/arielruizcr](https://github.com/arielruizcr)