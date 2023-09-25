# Domain Models

## Menu

```csharp
class Menu
{
    Menu Create();
    void AddFood(Food food);
    void RemovdeFood(Food food);
    void UpdateSection(MenuSection section);
}
```

```json
{
  "id": "1fbb9a0b-87bf-4450-bb9a-0b87bff45037",
  "name": "Menu Name",
  "description": "Description for the menu",
  "averageRating": 4.3,
  "sections": [
    {
      "id": "5ba00adf-66e9-4d7f-a00a-df66e95d7f21",
      "name": "Appetizers",
      "description": "Starters",
      "items": [
        {
          "id": "9e300fd2-65bc-49d3-b00f-d265bcc9d320",
          "name": "Fried Pickles",
          "description": "Deep fried pickles",
          "price": 250000
        }
      ]
    }
  ],
  "hostId": "ba79b801-56bd-46a9-b9b8-0156bdf6a96d",
  "foodIds": [
    "5a9dceb6-08fa-4101-9dce-b608fa510128",
    "44f906ae-f73d-46e2-b906-aef73db6e2ea",
    "23d8001d-e2a9-4474-9800-1de2a95474eb"
  ],
  "menuReviewIds": [
    "ac288a23-0494-4d4e-a88a-2304940d4e30",
    "a8e5d859-a803-40ee-a5d8-59a80330eec7",
    "8b07b050-5c92-4a25-87b0-505c922a258c",
    "5a668a70-bc0e-4a10-a68a-70bc0e5a10da",
    "12a46694-4a5a-4b07-a466-944a5a2b0774"
  ],
  "CreateAt": "2023-01-02T12:23:24",
  "ModifiedAt": "2023-02-02T12:23:24"
}
```