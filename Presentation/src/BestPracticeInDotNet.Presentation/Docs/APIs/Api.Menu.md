# Create Menu

### Create Menu Request
```
POST /hosts/{hostId}/menus
```
```json
{
    "name": "YummyMenu",
    "description": "A menu with pizza food",
    "sections": [
        {
            "name": "Fast food",
            "description": "Dinner",
            "items": [
                {
                    "name": "Pickles",
                    "description": "Deep fried pickles"
                }
            ]
        }
    ]
}
```

### Create Menu Response

```
200 OK
```
```json
{
    "id": "fc24468f-90f1-4d6f-a446-8f90f15d6fc1",
    "name": "Pizza Menu",
    "description": "A menu with pizza food",
    "averageRating": null,
    "sections": [
        {
            "name": "Fast food",
            "description": "Dinner",
            "items": [
                {
                    "name": "Pickles",
                    "description": "Deep fried pickles"
                }
            ]
        }
    ]
}
```
