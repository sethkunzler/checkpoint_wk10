import { Account } from "./Account.js"

export class Recipe {
  constructor(data) {
    this.id = data.id
    this.createdAt = new Date(data.createdAt) || new Date()
    this.updatedAt = new Date(data.updatedAt) || new Date()
    this.title = data.title 
    this.instructions = data.instructions
    this.img = data.img 
    this.category = data.category
    this.creatorId = data.creatorId
    this.creator =  data.creator ? new Account(data.creator) : null
  }
}

const recipeData =
{
  "id": 1,
  "createdAt": "2024-03-27T22:02:08",
  "updatedAt": "2024-03-27T22:02:08",
  "title": "The Senior Jake Burrito",
  "instructions": "Take your burrito and cook it, then add hotdog.  Boom, Burrito.",
  "img": "https://images.unsplash.com/photo-1584031036380-3fb6f2d51880?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=900&q=80",
  "category": "mexican",
  "creatorId": "65e9fb59e1423c341b6d36f6",
  "creator": {
      "id": "65e9fb59e1423c341b6d36f6",
      "name": "goodboi@nice.com",
      "email": "goodboi@nice.com",
      "picture": "https://s.gravatar.com/avatar/217c84279b9299595edf3727755a2c54?s=480&r=pg&d=https%3A%2F%2Fcdn.auth0.com%2Favatars%2Fgo.png"
  }
}